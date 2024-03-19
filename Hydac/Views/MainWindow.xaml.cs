using Hydac.Views;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Hydac
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            InitializeComponent();
            BitmapImage Hydac = new BitmapImage(new Uri(@"https://media.licdn.com/dms/image/C4E0BAQF5lP_FItQWQw/company-logo_200_200/0/1630655847640/hydac_international_gmbh_logo?e=2147483647&v=beta&t=tQd8VuZm2OqWL8Eiu3BgO5M62MQbETPt40VVFnQYUxM"));
            imgLogin.HorizontalAlignment = HorizontalAlignment.Center;
            imgLogin.Source = Hydac;
        }

        public void LoginPicture(object sender, RoutedEventArgs e)
        {
           
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainMenu mainMenu = new MainMenu();
            mainMenu.WindowStartupLocation = WindowStartupLocation.CenterScreen;    
            mainMenu.Show();
            this.Close();
        }

    }
}