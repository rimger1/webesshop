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
    /// Interaction logic for UserControlTermekek.xaml
    /// </summary>
    public partial class UserControlTermekek : UserControl
    {
        List<Termekek> termek;
        Termekek kivalasztotttermek;

        public UserControlTermekek()
        {
            InitializeComponent();
            AdatbazisLekerdezes();
            termek = new List<Termekek>();

        }

        private void AdatbazisLekerdezes()
        {
            var termekRepo = new GenericRepository<Termekek>(App.databasePath);
            var lekerdezes = termekRepo.GetAll();
            datagridtermekek.ItemsSource = lekerdezes;
            mentesBtnter.Visibility = Visibility.Visible;
            modBtnter.Visibility = Visibility.Collapsed;
            torlesBtnter.Visibility = Visibility.Collapsed;
        }

        private void datagridtermekek_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            mentesBtnter.Visibility = Visibility.Collapsed;
            modBtnter.Visibility = Visibility.Visible;
            torlesBtnter.Visibility = Visibility.Visible;
            if (datagridtermekek.SelectedItem != null)
            {
                kivalasztotttermek = (Termekek)datagridtermekek.SelectedItem;
                nevTxt.Text = kivalasztotttermek.Nev;
                arTxt.Text = Convert.ToString(kivalasztotttermek.Ar);
            }
        }

        private void modBtnter_Click(object sender, RoutedEventArgs e)
        {
            kivalasztotttermek.Nev = nevTxt.Text;
            kivalasztotttermek.Ar = Convert.ToInt32(arTxt.Text);

            var TermekRepo = new GenericRepository<Termekek>(App.databasePath);
            TermekRepo.Update(kivalasztotttermek);
            AdatbazisLekerdezes();
        }

        private void torlesBtnter_Click(object sender, RoutedEventArgs e)
        {
            var TermekRepo = new GenericRepository<Termekek>(App.databasePath);
            TermekRepo.Delete(kivalasztotttermek);
            AdatbazisLekerdezes();
        }

        private void mentesBtnter_Click(object sender, RoutedEventArgs e)
        {
            Termekek ujtermek = new Termekek(nevTxt.Text, Convert.ToInt32(arTxt.Text), kategoriaTxt.Text);

            var TermekRepo = new GenericRepository<Termekek>(App.databasePath);
            TermekRepo.Insert(ujtermek);
            AdatbazisLekerdezes();
        }
    }
}
