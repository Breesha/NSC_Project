using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SqlClient;
using System.Data;
using NSC_Model;
using NSC_Business;

namespace NSC_WPF_Core
{
    /// <summary>
    /// Interaction logic for SignIn.xaml
    /// </summary>
    public partial class SignIn : Page
    {
        public SignIn()
        {
            InitializeComponent();
        }

        private void ButtonLogin_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=NSC;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            SqlDataAdapter sda = new SqlDataAdapter("select * from Members where Username='" + TextUsername.Text + "' and Passwrd='" + TextPassword.Text + "'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (TextUsername.Text == "" || TextPassword.Text == "")
            {
                TextMessage.Text = "Insert username and passowrd";
            }
            else if (dt.Rows.Count == 1)
            {
                //Staff_Users staffuserpage = new Staff_Users(TextLogEmail.Text);
                //this.NavigationService.Navigate(staffuserpage);
            }
            else
            {
                TextMessage.Text = "No account for these details, please register or try again";
            }
        }

        private void ButtonRegister_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=NSC;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            SqlDataAdapter sda = new SqlDataAdapter("select * from Members where Username='" + TextUsername.Text + "'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            if (TextUsername.Text == "" || TextPassword.Text == "")
            {
                TextMessage.Text = "Insert username and passowrd";
            }
            else if (dt.Rows.Count == 1)
            {
                TextMessage.Text = "Username already registered, please submit a new username";
            }
            else
            {
                TextMessage.Text = "Hold on";
            }
        }
    }
}
    