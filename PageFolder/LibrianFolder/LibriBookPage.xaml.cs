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

namespace BiblioMollaev.PageFolder.LibrianFolder
{
    /// <summary>
    /// Логика взаимодействия для LibriBookPage.xaml
    /// </summary>
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
    }
}
