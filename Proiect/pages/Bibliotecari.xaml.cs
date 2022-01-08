using Proiect.EntityModel;
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

namespace Proiect
{
    /// <summary>
    /// Interaction logic for Bibliotecari.xaml
    /// </summary>
    public partial class Bibliotecari : Page
    {
        public Bibliotecari()
        {
            InitializeComponent();
        }

        BibliotecaContext db = new BibliotecaContext();
        Bibliotecar bibliotecar = new Bibliotecar();


        private void adaugaBibliotecar_Click(object sender, RoutedEventArgs e)
        {
            bibliotecar.CNP = cnpBibliotecar.Text.Trim();
            bibliotecar.nume_bibliotecar = numeBibliotecar.Text.Trim();
            bibliotecar.prenume_bibliotecar = prenumeBibliotecar.Text.Trim();
            bibliotecar.numar_tel = numarTelBibliotecar.Text.Trim();
           
            db.Bibliotecars.Add(bibliotecar);
            db.SaveChanges();
            MessageBox.Show("Bibliotecar Adaugat");
            loadBibliotecar();
            clearControl();
        }

        private void clearControl()
        {
            numeBibliotecar.Clear();
            cnpBibliotecar.Clear();
            prenumeBibliotecar.Clear();
            numarTelBibliotecar.Clear();
            nameToEdit.Clear();
        }

        private void loadBibliotecar()
        {
            var bibliotecare = from bibliotecar in db.Bibliotecars select bibliotecar;
            dataGrid.ItemsSource = bibliotecare.ToList();
        }

        private void bibliotecariChecked(object sender, RoutedEventArgs e)
        {
            loadBibliotecar();
        }

        private void bibliotecariUnchecked(object sender, RoutedEventArgs e)
        {
            dataGrid.ItemsSource = null;
        }

        Bibliotecar result;
        private void editBibliotecar_Click(object sender, RoutedEventArgs e)
        {
                var nume = nameToEdit.Text;
                result = db.Bibliotecars.Single(bibliotecar => bibliotecar.nume_bibliotecar == nume);
                numeBibliotecar.Text = result.nume_bibliotecar;
                cnpBibliotecar.Text = result.CNP;
                prenumeBibliotecar.Text = result.prenume_bibliotecar;
                numarTelBibliotecar.Text = result.numar_tel;   
        }

        private void updateBibliotecar_Click(object sender, RoutedEventArgs e)
        {
            result.nume_bibliotecar = numeBibliotecar.Text.Trim();
            result.CNP = cnpBibliotecar.Text.Trim();
            result.prenume_bibliotecar = prenumeBibliotecar.Text.Trim();
            result.numar_tel = numarTelBibliotecar.Text.Trim();
           

            db.Bibliotecars.Add(result);
            db.Entry(result).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            clearControl();
            loadBibliotecar();
        }

        private void deleteBibliotecar_Click(object sender, RoutedEventArgs e)
        {
            var name = nameToEdit.Text;
            var deleteBibliotecar = db.Bibliotecars.Single(bibliotecar => bibliotecar.nume_bibliotecar == name);
            db.Bibliotecars.Remove(deleteBibliotecar);
            db.SaveChanges();
            clearControl();
            loadBibliotecar();
        }
    }
}
