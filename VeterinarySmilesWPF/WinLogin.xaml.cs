using System;
using System.Collections.Generic;
using System.Data;
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
using System.Windows.Shapes;
using VeterinarySmilesDAO.Implementations;
using VeterinarySmilesDAO.Models;

namespace VeterinarySmilesWPF
{
    /// <summary>
    /// Lógica de interacción para WinLogin.xaml
    /// </summary>
    public partial class WinLogin : Window
    {
        public WinLogin()
        {
            InitializeComponent();
        }

        private void btnRecuperaContra_Click(object sender, RoutedEventArgs e)
        {
            WinCambioContra wcc = new WinCambioContra();
            wcc.Show();
            this.Visibility = Visibility.Hidden;
        }

        private void btnRegistra_Click(object sender, RoutedEventArgs e)
        {
            WinRegistra wr = new WinRegistra();
            wr.Show();
            this.Visibility= Visibility.Hidden;

        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            xd();
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnLogin_KeyDown(object sender, KeyEventArgs e)
        {
            //MessageBox.Show("Entraste");
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter) {


                xd();
            }
        }
        void xd()
        {
            try
            {
                UserImp impLUser = new UserImp();
                DataTable table = impLUser.login(txtLogin.Text, txtPassword.Password);

                DataTable primeraVez = impLUser.loginPrimeraVez(txtLogin.Text, txtPassword.Password);


                if (table.Rows.Count > 0)
                {

                    SessionClass.SessionID = int.Parse(table.Rows[0][0].ToString());
                    SessionClass.SessionUserName = table.Rows[0][1].ToString();
                    SessionClass.SessionRole = table.Rows[0][2].ToString();

                    switch (table.Rows[0][2].ToString()) // Nos devuelve el rol

                    {
                        case "Administrador":


                            if (primeraVez.Rows.Count > 0)
                            {
                                MessageBox.Show("Tienes que cambiar tu contraseña tienes una temporal se te envio a tu correo", "Contraseña Temporal", MessageBoxButton.OK, MessageBoxImage.Information);
                                WinCambioContra wcc = new WinCambioContra();
                                wcc.Show();
                            }
                            else
                            {
                                MainWindow admin = new MainWindow();
                                admin.Show();
                                this.Visibility = Visibility.Hidden;

                            }

                            break;

                        case "Veterinario":

                            if (primeraVez.Rows.Count > 0)
                            {
                                MessageBox.Show("Tienes que cambiar tu contraseña tienes una temporal se te envio a tu correo", "Contraseña Temporal", MessageBoxButton.OK, MessageBoxImage.Information);
                                WinCambioContra wcc = new WinCambioContra();
                                wcc.Show();
                            }

                            else
                            {
                                WinMenuVet vet = new WinMenuVet();
                                vet.ShowDialog();
                                this.Visibility = Visibility.Hidden;

                            }

                            break;



                        case "Cajero":
                            if (primeraVez.Rows.Count > 0)
                            {
                                MessageBox.Show("Tienes que cambiar tu contraseña tienes una temporal", "Contraseña Temporal", MessageBoxButton.OK, MessageBoxImage.Information);
                                WinCambioContra wcc = new WinCambioContra();
                                wcc.Show();
                            }
                            else
                            {

                                WinMenuCajero cajero = new WinMenuCajero();
                                cajero.ShowDialog();

                            }

                            break;

                    }
                }
                else
                {
                    MessageBox.Show("Datos Incorrectos", "Datos Incorrectos", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
