using BiblioMollaev.ClassFolder;
using BiblioMollaev.PageFolder.LibrianFolder;
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
using System.Windows.Shapes;

namespace BiblioMollaev.WindowFolder
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            MaiFrame.Navigate(new PageFolder.LibrianFolder.LibriBookPage());
            MaiFrame.Navigate(new PageFolder.LibrianFolder.AddBookPage());
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

        }

        private void ListBookBtn_Click(object sender, RoutedEventArgs e)
        {
            MaiFrame.Navigate(new LibriBookPage());
        }

        private void AddBookBtn_Click(object sender, RoutedEventArgs e)
        {
            MaiFrame.Navigate(new AddBookPage());
        }

        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void CloseIm_MouseLeftButtonDown_1(object sender, MouseButtonEventArgs e)
        {
            MBClass.ExitMB();
        }
    }
}
