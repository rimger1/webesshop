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

namespace Webesshop
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
  
        private void felhasznalokmenu_Click(object sender, RoutedEventArgs e)
        {
            feladatpanel.Children.Clear();
            feladatpanel.Children.Add(new UserControls.UserControlFelhasznalok());

        }

        private void ertekessegekmenu_Click(object sender, RoutedEventArgs e)
        {
            feladatpanel.Children.Clear();
            feladatpanel.Children.Add(new UserControls.UserControlTermekek());
        }
    }
}