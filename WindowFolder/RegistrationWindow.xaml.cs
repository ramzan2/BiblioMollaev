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
    /// Логика взаимодействия для RegistrationWindow.xaml
    /// </summary>
    public partial class RegistrationWindow : Window
    {
        SqlConnection sqlConnection =
           new SqlConnection(@"Data Source=DESKTOP-C30H7UE\SQLEXPRESS;
                                Initial Catalog=PP03Mollaev;
                                Integrated Security=True");
        SqlCommand sqlCommand;
        public RegistrationWindow()
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

        private void CloseIm_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MBClass.ExitMB();
        }

        private void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            string pass = PasswordTb.Password;
            string zagl = "QWERTYUIOPASDFGHJKLZXCVBNM";
            string mal = "qwertyuiopasdfghjklzxcvbnm";
            string cif = "123457890";
            string znak = "!@#$%^&*()_+";

            if (string.IsNullOrWhiteSpace(LoginTb.Text))
            {
                MBClass.ErrorMB("Некоректный логин");
                LoginTb.Focus();
            }
            else if (string.IsNullOrWhiteSpace(PasswordTb.Password))
            {
                MBClass.ErrorMB("Некоректный пароль");
                PasswordTb.Focus();
            }
            else if (zagl.IndexOfAny(pass.ToCharArray()) == -1)
            {
                MBClass.ErrorMB("Пароль должен содержать заглавную букву");
                PasswordTb.Focus();
            }
            else if (mal.IndexOfAny(pass.ToCharArray()) == -1)
            {
                MBClass.ErrorMB("Пароль должен содержать маленькую букву");
                PasswordTb.Focus();
            }
            else if (cif.IndexOfAny(pass.ToCharArray()) == -1)
            {
                MBClass.ErrorMB("Пароль должен содержать цифру");
                PasswordTb.Focus();
            }
            else if (znak.IndexOfAny(pass.ToCharArray()) == -1)
            {
                MBClass.ErrorMB("Пароль должен содержать " +
                    "один из этих знаков " + znak);
                PasswordTb.Focus();
            }
            else if (string.IsNullOrWhiteSpace(DoubllePasswordTb.Password))
            {
                MBClass.ErrorMB("Некоректный повтор пароля");
                DoubllePasswordTb.Focus();
            }
            else if (DoubllePasswordTb.Password != PasswordTb.Password)
            {
                MBClass.ErrorMB("Пароли не совпадают");
                DoubllePasswordTb.Focus();
                PasswordTb.Focus();
            }
            else
            {
                try
                {
                    sqlConnection.Open();
                    sqlCommand = new SqlCommand("Insert Into dbo.[User] " +
                        "(LoginUser, PasswordUser, IDRole) Values " +
                        $"('{LoginTb.Text}','{PasswordTb.Password}',2)",
                        sqlConnection);
                    sqlCommand.ExecuteNonQuery();
                    MBClass.InformationMB("Пользователь зарегистрирован");
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
    }
}
