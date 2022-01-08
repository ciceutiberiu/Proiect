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
    /// Interaction logic for Clienti.xaml
    /// </summary>
    public partial class Clienti : Page
    {
        public Clienti()
        {
            InitializeComponent();
        }

        BibliotecaContext db = new BibliotecaContext();
        Client client = new Client();

        private void adaugaClient_Click(object sender, RoutedEventArgs e)
        {
            client.CNP = cnpClient.Text.Trim();
            client.nume_client = nameClient.Text.Trim();
            client.prenume_client = prenumeClient.Text.Trim();  
            client.numar_tel = numarClient.Text.Trim();

            db.Clients.Add(client); 
            db.SaveChanges();
            MessageBox.Show("Client Adaugat");
            loadClienti();
            clearControl();
        }

        private void clearControl()
        {
            cnpClient.Clear();
            nameClient.Clear();
            prenumeClient.Clear();
            numarClient.Clear();
            cnpToEdit.Clear();
        }

        private void loadClienti()
        {
            var clients = from client in db.Clients select client;
            dataGrid.ItemsSource = clients.ToList();
        }

        private void clientiChecked(object sender, RoutedEventArgs e)
        {
            loadClienti();
        }
        private void clientiUnchecked(object sender, RoutedEventArgs e)
        {
            dataGrid.ItemsSource = null;
        }

        Client result;

        private void editClient_Click(object sender, RoutedEventArgs e)
        {
            var cnp = cnpToEdit.Text;
            result = db.Clients.Single(client => client.CNP == cnp);
            nameClient.Text = result.nume_client;
            prenumeClient.Text = result.prenume_client;
            numarClient.Text = result.numar_tel;
            cnpClient.Text = result.CNP;
            
        }

        private void actualizeazaClient_Click(object sender, RoutedEventArgs e)
        {
            result.CNP = cnpClient.Text.Trim();
            result.nume_client = nameClient.Text.Trim();
            result.prenume_client = prenumeClient.Text.Trim();
            result.numar_tel = numarClient.Text.Trim(); 

            db.Clients.Add(result);
            db.Entry(result).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            clearControl();
            loadClienti();
        }

        private void stergeClient_Click(object sender, RoutedEventArgs e)
        {
            var cnp = cnpToEdit.Text;
            var stergeClient = db.Clients.Single(client => client.CNP == cnp);
            db.Clients.Remove(stergeClient);
            db.SaveChanges();
            clearControl();
            loadClienti();
        }
    }
}
