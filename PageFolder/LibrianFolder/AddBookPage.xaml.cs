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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BiblioMollaev.PageFolder.LibrianFolder
{
 
    public partial class AddBookPage : Page
    {
        SqlConnection sqlConnection =
            new SqlConnection(@"Data Source=10.128.14.64\SQLEXPRESS;
                                     Initial Catalog=user149;
                                 User ID=user149;Password=wsruser149");
        SqlCommand sqlCommand;
        SqlDataReader sqlDataReader;
        ClassFolder.CBClass cBClass;
        public AddBookPage()
        {
            InitializeComponent();
            cBClass = new ClassFolder.CBClass();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            cBClass.LoadFIO(AuthorCb);
            cBClass.LoadCBCity(IDCityCb);
            cBClass.LoadCBPublisher(IDPublisherCb);
        }

        private void ReadIdAuthor()
        {
            try
            {
                SplitFIO();
                sqlConnection.Open();
                sqlCommand = new SqlCommand("Select IDAuthor " +
                    "From dbo.Author " +
                    $"Where LastNameAuthor ='{lastName}' " +
                    $"AND FirstNameAuthor ='{firstName}' " +
                    $"OR MiddliNameAuthor ='{middleName}'", 
                    sqlConnection);
                sqlDataReader = sqlCommand.ExecuteReader();
                sqlDataReader.Read();
                idAuthor = Int32.Parse(sqlDataReader[0].ToString());
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

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void AddBookBtn_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(UniqueCodeTb.Text)||
            string.IsNullOrWhiteSpace(NameTb.Text)||
            string.IsNullOrWhiteSpace(AuthorCb.Text) || 
            string.IsNullOrWhiteSpace(NumberOfPagesTb.Text)||
            string.IsNullOrWhiteSpace(IDPublisherCb.Text) ||
            string.IsNullOrWhiteSpace(YearOfPublicationTb.Text)||
            string.IsNullOrWhiteSpace(IDCityCb.Text) ||
            string.IsNullOrWhiteSpace(CostBookTb.Text)||
            string.IsNullOrWhiteSpace(NumberOfCopiesTb.Text))
            {
                MBClass.ErrorMB("Заполните все поля");
            }
            else
            {
                try
                {
                    ReadIdAuthor();
                    sqlConnection.Open();
                    sqlCommand = new SqlCommand("Insert Into dbo.Book " +
                        "(UniqueCode,Name,IDAvtors,IDCity, " +
                        "IDPublisher,YearOfPublication,NumberOfPages, " +
                        "CostBook,NumberOfCopies) Values " +
                        $"('{UniqueCodeTb.Text}', '{NameTb.Text}', " +
                        $"'{idAuthor}', " +
                        $"'{IDCityCb.SelectedValue.ToString()}', " +
                        $"'{IDPublisherCb.SelectedValue.ToString()}', " +
                        $"'{YearOfPublicationTb.Text}', " +
                        $" '{NumberOfPagesTb.Text}', " +
                        $"'{CostBookTb.Text}', " +
                        $"'{NumberOfCopiesTb.Text}')",
                        sqlConnection);
                    sqlCommand.ExecuteNonQuery();
                    MBClass.InformationMB("Книга успешна добавлена");
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

        int idAuthor;
        string lastName;
        string firstName;
        string middleName;

        private void SplitFIO()
        {
            string fioAuthor = AuthorCb.Text;
            string[] fioAuthorMass = fioAuthor.Split(new char[]{' '});
            lastName=fioAuthorMass[0];
            firstName=fioAuthorMass[1];
            middleName=fioAuthorMass[2];
        }

        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            new WindowFolder.AddFioWindow().ShowDialog();
            cBClass.LoadFIO(AuthorCb);
        }

        private void Image_MouseLeftButtonDown_1(object sender, MouseButtonEventArgs e)
        {
            new WindowFolder.AddPublisherWindow().ShowDialog();
            cBClass.LoadCBPublisher(IDPublisherCb);
        }
        private void Image_MouseLeftButtonDown_2(object sender, MouseButtonEventArgs e)
        {
            new WindowFolder.AddCityWindow().ShowDialog();
            cBClass.LoadCBCity(IDCityCb);
        }
    }
}
