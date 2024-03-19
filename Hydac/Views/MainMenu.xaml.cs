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

namespace Hydac.Views
{
    /// <summary>
    /// Interaction logic for MainMenu.xaml
    /// </summary>
    public partial class MainMenu : Window
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NewPost newPost = new NewPost();
            newPost.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            newPost.Show();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            RemovePostDialog dialog = new RemovePostDialog();
            dialog.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            dialog.Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            EditWindow editWindow = new EditWindow();
            editWindow.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            editWindow.Show();
            this.Close();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.WindowStartupLocation= WindowStartupLocation.CenterScreen;
            mainWindow.Show();
            this.Close();
        }
    }
}
