using DifficilBankDAO.utils;
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
using System.Windows.Shapes;
using VeterinarySmilesDAO.Implementations;
using VeterinarySmilesDAO.Models;

namespace VeterinarySmilesWPF
{
    /// <summary>
    /// Lógica de interacción para WinInsertPet.xaml
    /// </summary>
    public partial class WinInsertPet : Window
    {
        ControlMio cs;

        Pet p;
        PetImpl impPet;

        public WinInsertPet()
        {
            InitializeComponent();
        }

        void insertaMascota()
        {
            try
            {
                p = new Pet(txtName.Text + "-" + txtRaza.Text.Substring(0,1) + txtColor.Text.Substring(0, 1), DateTime.Parse(dpBirthDate.ToString()), float.Parse(txtPeso.Text), txtRaza.Text, txtColor.Text);

                impPet = new PetImpl();

                int n = impPet.Insert(p);

                if (n > 0)
                {
                    //MessageBox.Show("Registro Insertado Con Exito");
                    MessaboxPositivo ms = new MessaboxPositivo();
                    ms.Show();
                   
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void btnVuelveLogin_Click(object sender, RoutedEventArgs e)
        {
            WinLogin wl = new WinLogin();
            wl.Show();
            this.Close();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            lblError.Content = "";

            cs = new ControlMio();
            
            bool banderaNombre = false;
            bool banderaFecha = false;
            bool banderaColor = false;
            bool banderaRaza = false;
            bool banderaPeso = false;

                if (txtName.Text != "")
                {
                    banderaNombre = cs.ValidarTextoConÑSinEspacios(txtName.Text);
                    if (banderaNombre == false)
                    {
                        lblError.Content += "El nombre solo acepta letras sin espacios al \n principio ni al final ni mas de uno entre medias \n";
                    }
                }
                else
                {
                    lblError.Content += "El Campo nombre esta vacio \n";
                }
                if (dpBirthDate.Text != "")
                {
                    banderaFecha = cs.CompruebaFechaAnimal(DateTime.Parse(dpBirthDate.Text));
                    if (banderaFecha == false)
                    {
                        lblError.Content += "No pongas fechas futuristas \n";
                    }
                }
                else
                {
                    lblError.Content += "El Campo fecha nacimiento esta vacio \n";
                }
                if (txtPeso.Text != "")
                {
                    banderaPeso = cs.validaPeso(txtPeso.Text);
                    if (banderaPeso == false)
                    {
                        lblError.Content += "El peso solo acepta numeros postivos hasta 200 \n";
                    }
                }
                else
                {
                    lblError.Content += "El Campo Peso esta vacio \n";
                }
                if (txtRaza.Text != "")
                {
                    banderaRaza = cs.ValidarTextoConÑSinEspacios(txtRaza.Text);
                    if (banderaRaza == false)
                    {
                        lblError.Content += "La especie solo acepta letras sin espacios al \n principio ni al final ni mas de uno entre medias \n";
                    }
                }
                else
                {
                    lblError.Content += "El Campo especie esta vacio \n";
                }
                if (txtColor.Text != "")
                {                   
                    banderaColor = cs.ValidarTextoConÑSinEspacios(txtColor.Text);
                    if (banderaColor == false)
                    {
                        lblError.Content += "El color solo acepta letras sin espacios al \n principio ni al final ni mas de uno entre medias \n";
                    }
                }
                else
                {
                    lblError.Content += "El Campo color esta vacio \n";
                }                      
            
            

                //MessageBox.Show(banderaNombre.ToString() + banderaFecha.ToString() + banderaColor.ToString() + banderaPeso.ToString() + banderaRaza.ToString() );

                if (banderaNombre==true && banderaFecha == true && banderaColor == true &&
                    banderaPeso == true && banderaRaza == true) {

                    insertaMascota();
                    WinAdmPet wp = new WinAdmPet();
                    wp.Show();
                    this.Close();
                    //MessageBox.Show("Entro A sin errores ");
                            
            }        
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("¿Esta realmente seguro de querer salir?", "Salir", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                WinAdmPet wp = new WinAdmPet();
                wp.Show();
                this.Close();
            }
        }
    }
}
