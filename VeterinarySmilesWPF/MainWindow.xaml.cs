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
using VeterinarySmilesDAO.Models;
using VeterinarySmilesDAO.Implementations;
using VeterinarySmilesDAO;
using System.Data;

namespace VeterinarySmilesWPF
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnPet_Click(object sender, RoutedEventArgs e)
        {

            WinAdmPet ventanaPet = new WinAdmPet();
            ventanaPet.Owner = this;
            ventanaPet.Show();
            this.Visibility = Visibility.Hidden;

        }
        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnClient_Click(object sender, RoutedEventArgs e)
        {
            WinAdmClient ventanaClient = new WinAdmClient();
            ventanaClient.Owner = this;
            ventanaClient.Show();
        }

        private void btnConsultation_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnMedicalAppointment_Click(object sender, RoutedEventArgs e)
        {

        }


        private void btnVaccine_Click(object sender, RoutedEventArgs e)
        {
            WinAdmVeterinaryProduct wav = new WinAdmVeterinaryProduct();
            wav.Show();
            this.Visibility = Visibility.Hidden;
        }

       

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            lblInfo.Content = "Bienvenido" + SessionClass.SessionUserName + " - ROL : " + SessionClass.SessionRole + " " + SessionClass.SessionID;
        }

        private void btnRegistra_Click(object sender, RoutedEventArgs e)
        {
            WinRegistra wr = new WinRegistra();
            wr.Show();
            this.Visibility = Visibility.Hidden;
        }

        private void btnRecuperaContra_Click(object sender, RoutedEventArgs e)
        {
            WinCambioContra wcc = new WinCambioContra();
            wcc.Show();
            this.Visibility = Visibility.Hidden;
        }
    }
}
