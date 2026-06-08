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
using Webesshop.Models;

namespace Webesshop.UserControls
{
    /// <summary>
    /// Interaction logic for UserControlFelhasznalok.xaml
    /// </summary>
    public partial class UserControlFelhasznalok : UserControl
    {
        List<Felhasznalok> felhasznalok;
        Felhasznalok kivalasztottfelhasznalo;

        public UserControlFelhasznalok()
        {
            InitializeComponent();
            AdatbazisLekerdezes();

        }

        private void AdatbazisLekerdezes()
        {
            var felhasznaloRepo = new GenericRepository<Felhasznalok>(App.databasePath);
            var lekerdezes = felhasznaloRepo.GetAll();
            datagridfelhasznalok.ItemsSource = lekerdezes;
            mentesBtn.Visibility = Visibility.Visible;
            modBtn.Visibility = Visibility.Collapsed;
            torlesBtn.Visibility = Visibility.Collapsed;

        }

        private void datagridfelhasznalok_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void mentesBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void torlesBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void modBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
