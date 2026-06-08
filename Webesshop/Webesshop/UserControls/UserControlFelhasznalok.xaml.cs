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
using Webesshop.Services;

namespace Webesshop.UserControls
{
    /// <summary>
    /// Interaction logic for UserControlFelhasznalok.xaml
    /// </summary>
    public partial class UserControlFelhasznalok : UserControl
    {
        List<Felhasznalok> felhasznalo;
        Felhasznalok kivalasztottfelhasznalo;

        public UserControlFelhasznalok()
        {
            InitializeComponent();
            AdatbazisLekerdezes();
            felhasznalo = new List<Felhasznalok>();

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
            mentesBtn.Visibility = Visibility.Collapsed;
            modBtn.Visibility = Visibility.Visible;
            torlesBtn.Visibility = Visibility.Visible;
            if (datagridfelhasznalok.SelectedItem != null)
            {
                kivalasztottfelhasznalo = (Felhasznalok)datagridfelhasznalok.SelectedItem;
                felhasznalonevTxt.Text = kivalasztottfelhasznalo.FelhasznaloNev;
                teljesnevTxt.Text = kivalasztottfelhasznalo.TeljesNev;
            }
        }

        private void mentesBtn_Click(object sender, RoutedEventArgs e)
        {
            Felhasznalok ujfelhasznalo = new Felhasznalok(felhasznalonevTxt.Text, teljesnevTxt.Text, PasswordHelper.HashPassword(jelszoText.Password));

            var felhasznaloRepo = new GenericRepository<Felhasznalok>(App.databasePath);
            felhasznaloRepo.Insert(ujfelhasznalo);
            AdatbazisLekerdezes();
        }

        private void torlesBtn_Click(object sender, RoutedEventArgs e)
        {
            var felhasznaloRepo = new GenericRepository<Felhasznalok>(App.databasePath);
            felhasznaloRepo.Delete(kivalasztottfelhasznalo);
            AdatbazisLekerdezes();
        }

        private void modBtn_Click(object sender, RoutedEventArgs e)
        {
            kivalasztottfelhasznalo.FelhasznaloNev = felhasznalonevTxt.Text;
            kivalasztottfelhasznalo.TeljesNev = teljesnevTxt.Text;

            if (jelszoText.Password != "")
            {
                kivalasztottfelhasznalo.Jelszo = PasswordHelper.HashPassword(jelszoText.Password);
            }
            var felhasznaloRepo = new GenericRepository<Felhasznalok>(App.databasePath);
            felhasznaloRepo.Update(kivalasztottfelhasznalo);
            AdatbazisLekerdezes();
        }
    }
}
