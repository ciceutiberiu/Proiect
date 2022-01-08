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
    /// Interaction logic for Imprumut.xaml
    /// </summary>
    public partial class Imprumut : Page
    {
        public Imprumut()
        {
            InitializeComponent();
        }

        BibliotecaContext db = new BibliotecaContext();
        Imprumuturi imprumut = new Imprumuturi();
      

        private void adaugaImprumut_Click(object sender, RoutedEventArgs e)
        {
            var idCartee = Convert.ToInt32(idCarte.Text.Trim());
            var checkClient = db.Clients.Single(client => client.CNP == cnpClient.Text.Trim());
            var checkBook = db.Cartis.Single(carte => carte.id == idCartee);
            if (checkClient != null)
            {
            imprumut.cnp_client = cnpClient.Text.Trim();

            } else
            {
                MessageBox.Show("Clientul nu exista");
            }

            if(checkBook != null)
            {
                imprumut.id_carte = idCartee;
            } else
            {
                MessageBox.Show("Carte nu exista");
            }
            var date = dataRetur.SelectedDate.Value;
            imprumut.data_retur = date;

            db.Imprumuturis.Add(imprumut);
            db.SaveChanges();
            loadImprumuturi();
            clearControl();
        }

        private void clearControl()
        {
            idCarte.Clear();
            cnpClient.Clear();
            dataRetur.SelectedDate = null;
        }

        private void loadImprumuturi()
        {
            var imprumutt = from imprumut in db.Imprumuturis select imprumut;
            dataGrid.ItemsSource = imprumutt.ToList();
        }

        private void imprumuturiChecked(object sender, RoutedEventArgs e)
        {
            loadImprumuturi();
        }

        private void imprumuturiUnchecked(object sender, RoutedEventArgs e)
        {
            dataGrid.ItemsSource = null;
        }

        Imprumuturi result;
        private void editImprumut_Click(object sender, RoutedEventArgs e)
        {
            var id = Convert.ToInt32(idToEdit.Text);
            result = db.Imprumuturis.Single(imprumut => imprumut.id == id);
            cnpClient.Text = result.cnp_client;
            idCarte.Text = result.id_carte.ToString();  
        }

        private void actualizeazaImprumut_Click(object sender, RoutedEventArgs e)
        {
            result.cnp_client = cnpClient.Text.Trim();
            result.id_carte = Convert.ToInt32(idCarte.Text.Trim());
            result.data_retur = dataRetur.SelectedDate.Value;

            db.Imprumuturis.Add(result);
            db.Entry(result).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            clearControl();
            loadImprumuturi();  
        }

        private void stergeImprumut_Click(object sender, RoutedEventArgs e)
        {
            int id = Convert.ToInt32(idToEdit.Text.Trim());
            var deleteImprumut = db.Imprumuturis.Single(imprumut => imprumut.id == id);
            db.Imprumuturis.Remove(deleteImprumut);
            db.SaveChanges();
            clearControl();
            loadImprumuturi();
        }
    }
}
