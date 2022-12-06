using BiblioMollaev.ClassFolder;
using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace BiblioMollaev.WindowFolder
{
    /// <summary>
    /// Логика взаимодействия для AuthorizationWindow.xaml
    /// </summary>
    public partial class AuthorizationWindow : Window
    {
        SqlConnection sqlConnection =
            new SqlConnection(@"Data Source=10.128.14.64\SQLEXPRESS;Initial Catalog=user149;User ID=user149;Password=wsruser149");

        SqlCommand sqlCommand;
        SqlDataReader dataReader;
        public AuthorizationWindow()
        {
            InitializeComponent();
        }



        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(LoginTb.Text))
            {
                MBClass.ErrorMB("Вы не ввели логин");
            } 
            else if (string.IsNullOrWhiteSpace(PasswordTb.Password))
            {
                MBClass.ErrorMB("Вы не ввели пароль");
                PasswordTb.Focus();
            }
            else
            {
                try
                {
                    sqlConnection.Open();
                    sqlCommand = new SqlCommand("Select PasswordUser, IDRole " +
                        "From dbo.[User] " +
                        $"Where LoginUser='{LoginTb.Text}'",
                        sqlConnection);
                    dataReader = sqlCommand.ExecuteReader();
                    dataReader.Read();

                    if (dataReader[0].ToString() != PasswordTb.Password)
                    {
                        MBClass.ErrorMB("Вы ввели не верный пароль");
                        PasswordTb.Focus();
                    }
                    else
                    {

                        {
                            switch (dataReader[1].ToString())
                            {
                                case "1":
                                    MBClass.InformationMB("Библитекарь");
                                    new MainWindow().ShowDialog();
                                    break;
                                case "2":
                                    MBClass.InformationMB("Читатель");
                                    break;
                                        case "3":
                                    MBClass.InformationMB("Администрация библиотеки");
                                    break;



                            }

                        }
                    }
                }
                catch (Exception ex)
                {
                    MBClass.ErrorMB(ex);
                }
                finally
                {
                    sqlConnection.Close();
                }
            }
        }

        private void CloseIm_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MBClass.ExitMB();
        }

        private void Registrationtb_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            new RegistrationWindow().ShowDialog();
        }
    }
}
