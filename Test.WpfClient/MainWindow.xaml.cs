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
using Microsoft.Extensions.DependencyInjection;
using Test.Maui.Shared.Services;
using Test.WpfClient.Services;

namespace Test.WpfClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OpenBlazorPage_Click(object sender, RoutedEventArgs e)
        {
            // Открытие окна с BlazorPage
            var blazorPage = new BlazorPage();
            blazorPage.Show();
        }
    }
}