using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.System;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace LoginForm
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        string toconnectoDB = "Data Source=R103-PC16;Initial Catalog=loginnewDB;User ID=sa;Password=sap;Encrypt=False";
        public MainPage()
        {
            this.InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {


            if (UsernameBox is null && PasswordBox is null)
            {
                await new MessageDialog("Please enter your username and password").ShowAsync();
                return;
            }
            else if (UsernameBox is null)
            {
                return;
            }
            else if (PasswordBox is null)
            {
                return;
            }

            //link to database through connection string.
            SqlConnection con = new SqlConnection(toconnectoDB);

            //to manoulate the databe you need to open the connection and..see below
            con.Open();

            //to manipulate database we need to use a command.
            //to write quueries to a database we need to use a command
            SqlCommand cmd = con.CreateCommand();
            cmd.Connection = con;
            cmd.CommandText = "select *from login_tbl where employeeName=" + UsernameBox.Text + "' and Employee_PAssword'" + PasswordBox.Password+ "' ;";

            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                await new MessageDialog("Login Successful").ShowAsync();
            }
            else
            {
                await new MessageDialog("Login Failed").ShowAsync();
            }
        }
    }
}
