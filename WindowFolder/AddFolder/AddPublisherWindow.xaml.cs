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
    /// Логика взаимодействия для AddPublisherWindow.xaml
    /// </summary>
    public partial class AddPublisherWindow : Window
    {
        SqlConnection sqlConnection =
           new SqlConnection(@"Data Source=10.128.14.64\SQLEXPRESS;
                                     Initial Catalog=user149;
                                 User ID=user149;Password=wsruser149");
        SqlCommand sqlCommand;
        public AddPublisherWindow()
        {
            InitializeComponent();
        }


        private void AddCityBtn_Click_1(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(PublisherTb.Text))
            {
                MBClass.ErrorMB("Заполните пустое поле");
            }
            else
            {
                try
                {
                    sqlConnection.Open();
                    sqlCommand = new SqlCommand("Insert Into dbo.[Publisher] " +
                        "(NamePublisher) " +
                        "Values " +
                        $"('{PublisherTb.Text}')",
                        sqlConnection);
                    sqlCommand.ExecuteNonQuery();
                    MBClass.InformationMB("Издательство успешно добавлено");
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



        private void CloseIm_MouseLeftButtonDown_1(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }


        private void Border_MouseDown_1(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }
    }
}
