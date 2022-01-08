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

namespace Proiect.pages
{
    /// <summary>
    /// Interaction logic for autoriPage.xaml
    /// </summary>
    public partial class autoriPage : Page
    {
        public autoriPage()
        {
            InitializeComponent();
        }

        BibliotecaContext db = new BibliotecaContext();
        Autori autor = new Autori(); 
        private void adaugaAutor_Click(object sender, RoutedEventArgs e)
        {
            autor.nume_autor = numeAutor.Text.Trim();
            autor.prenume_autor = prenumeAutor.Text.Trim();

            db.Autoris.Add(autor);
            db.SaveChanges();
            MessageBox.Show("Autor adaugat");
            loadAutori();
            clearControl();
        }

        private void clearControl()
        {
            numeAutor.Clear();
            prenumeAutor.Clear();
        }

        private void loadAutori()
        {
            var autorr = from autor in db.Autoris select autor;
            dataGrid.ItemsSource = autorr.ToList();
        }

        private void autoriChecked(object sender, RoutedEventArgs e)
        {
            loadAutori();
        }
        private void autoriUnchecked(object sender, RoutedEventArgs e)
        {
            dataGrid.ItemsSource = null;    
        }

        Autori result;

        private void editAutor_Click(object sender, RoutedEventArgs e)
        {
            int id = Convert.ToInt32(idToEdit.Text);
            result = db.Autoris.Single(autor => autor.id == id);
            numeAutor.Text = result.nume_autor;
            prenumeAutor.Text= result.prenume_autor;
        }

        private void actualizeazaAutor_Click(object sender, RoutedEventArgs e)
        {
            result.nume_autor = numeAutor.Text.Trim();
            result.prenume_autor = prenumeAutor.Text.Trim();
            db.Autoris.Add(result);
            db.Entry(result).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            clearControl();
            loadAutori();
        }

        private void stergeAutor_Click(object sender, RoutedEventArgs e)
        {
            int id = Convert.ToInt32(idToEdit.Text);
            var deleteAutor = db.Autoris.Single(autor => autor.id == id);
            db.Autoris.Remove(deleteAutor);
            db.SaveChanges();
            clearControl();
            loadAutori();
        }
    }
}
