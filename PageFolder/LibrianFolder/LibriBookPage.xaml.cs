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
using BiblioMollaev.ClassFolder;
using MaterialDesignThemes.Wpf;

namespace BiblioMollaev.PageFolder.LibrianFolder
{
    /// <summary>
    /// Логика взаимодействия для LibriBookPage.xaml
    /// </summar>
    public partial class LibriBookPage : Page
    {
        DGClass dGClass;
        public LibriBookPage()
        {
            InitializeComponent();
            dGClass = new DGClass(ListBookDG);
        }

        private void SearchTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            dGClass.LoadDG("SELECT * FROM dbo.ViewBook " +
              $"Where FIOAuthor Like '%{SearchTb.Text}%'");
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            dGClass.LoadDG("SELECT * FROM dbo.ViewBook");
        }

        private void ListBookDG_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (ListBookDG.SelectedItem == null)
            {
                MBClass.ErrorMB("Вы не выбрали строку");
            }
            else
            {
                VariableClass.BookId = dGClass.SelectId();
                try
                {
                    NavigationService.Navigate(new EditBookPage());

                    dGClass.LoadDG("Select * From dbo.[Book]");
                }
                catch (Exception ex)
                {
                    MBClass.ErrorMB(ex);
                }
            }
        }
    }
}
