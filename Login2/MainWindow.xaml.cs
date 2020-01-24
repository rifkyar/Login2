using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
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
using Dapper;

namespace Login2
{
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class MainWindow : Window
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Myconnection"].ConnectionString);
        public MainWindow()
        {
            InitializeComponent();
        }

        private void loginbtn_Click(object sender, RoutedEventArgs e)
        {
            var check = con.QueryAsync<Class1>("exec SP_Retrieve_Login @email,@password",
              new { email = emailtext.Text, password = passwordtext.Password }).Result.SingleOrDefault();
            if (check != null)
            {
                this.Hide();
                new Dashboard().Show();
                MessageBox.Show(this, "Welcome to The Jungle", "Message");
            }
            else
                MessageBox.Show(this, "Username Atau Password Salah", "Message");
        }
    }
}
