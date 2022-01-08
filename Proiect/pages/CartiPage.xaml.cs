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
    /// Interaction logic for CartiPage.xaml
    /// </summary>
    public partial class CartiPage : Page
    {
        public CartiPage()
        {
            InitializeComponent();
        }

        BibliotecaContext db = new BibliotecaContext();
        Carti carte = new Carti();

        private void insertBtn_Click(object sender, RoutedEventArgs e)
        {
            carte.nume_carte = numeCarte.Text;
            carte.nume_autor = numeAutor.Text;
            carte.prenume_autor = prenumeAutor.Text;
            carte.numar_pagini = Int16.Parse(numarPagini.Text);
            carte.categorie = categorie.Text;




            db.Cartis.Add(carte);
            db.SaveChanges();
            MessageBox.Show("Carte Adaugata");
            loadBooks();
            clearControl();
        }

        private void loadBooks()
        {
            var toateCartile = from carte in db.Cartis select carte;
            dataGrid.ItemsSource = toateCartile.ToList();
        }

        private void cartiChecked(object sender, RoutedEventArgs e)
        {
            loadBooks();
        }

        private void cartiUnchecked(object sender, RoutedEventArgs e)
        {
            dataGrid.ItemsSource = null;
        }


        private void clearControl()
        {
            numeCarte.Clear();
            numeAutor.Clear();
            prenumeAutor.Clear();
            numarPagini.Clear();
            categorie.Clear();
            idToEdit.Clear();
        }
        private void clearBtn_Click(object sender, RoutedEventArgs e)
        {
            clearControl();
        }

        Carti result;
        private void editBtn_Click(object sender, RoutedEventArgs e)
        {
            int id = Convert.ToInt32(idToEdit.Text);
            result = db.Cartis.Single(carte => carte.id == id);
            numeCarte.Text = result.nume_carte;
            numeAutor.Text = result.nume_autor;
            prenumeAutor.Text = result.prenume_autor;
            numarPagini.Text = Convert.ToString(result.numar_pagini);
            categorie.Text = result.categorie;
        }

        private void updateBtn_Click(object sender, RoutedEventArgs e)
        {
            result.nume_carte = numeCarte.Text;
            result.nume_autor = numeAutor.Text;
            result.prenume_autor = prenumeAutor.Text;
            result.numar_pagini = Int16.Parse(numarPagini.Text);
            result.categorie = categorie.Text;

            db.Cartis.Add(result);
            db.Entry(result).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            clearControl();
            loadBooks();
        }

        private void deleteBtn_Click(object sender, RoutedEventArgs e)
        {
            int id = Convert.ToInt32(idToEdit.Text);
            var deleteBook = db.Cartis.Single(carte => carte.id == id);
            db.Cartis.Remove(deleteBook);
            db.SaveChanges();
            clearControl();
            loadBooks();
        }

    }
}
