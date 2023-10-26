using DifficilBankDAO.Implementations;
using DifficilBankDAO.Models;
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

namespace VeterinarySmilesWPF
{
    /// <summary>
    /// Lógica de interacción para WinInsertClient.xaml
    /// </summary>
    public partial class WinInsertClient : Window
    {

        ControlMio cs;

        Client cl;
        ClientImpl impCli;

        public WinInsertClient()
        {
            InitializeComponent();
        }


        void insertaCliente()
        {
            try
            {
                /*
                bool bandera = false;

                if (txtCi.Text != "" && txtName.Text != "" && txtPrimerApellido.Text != "" && txtSegundoApellido.Text != "" &&
                    txtTelefono.Text != "" && txtDireccion.Text != "" && cbGenero.SelectedIndex != -1)

                {
                    bandera = true;
                }

                if (bandera == true)
                {*/

                    cl = new Client(txtCi.Text, txtName.Text, txtPrimerApellido.Text, txtSegundoApellido.Text, DateTime.Parse(dpBirthDate.ToString()), char.Parse(cbGenero.Text), txtTelefono.Text, txtDireccion.Text);
                    impCli = new ClientImpl();

                    int n = impCli.Insert(cl);
                    if (n > 0)
                    {
                        //MessageBox.Show("Registro Insertado Con Exito", "Registro exitoso!!!", MessageBoxButton.OK, MessageBoxImage.Information);                     
                        MessaboxPositivo ms = new MessaboxPositivo();
                        ms.Show();
                    }
               // }
               /* else
                {
                    MessageBox.Show("Ingrese todos los valores", "", MessageBoxButton.OK, MessageBoxImage.Error);
                }*/
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

            bool banderaCi = false;
            bool banderaNombre = false;
            bool banderaApellidoPaterno = false;
            bool banderaTelefono = false;
            bool banderaDireccion = false;    
            bool banderaFecha = false;

            if (txtCi.Text != "")
            {
                banderaCi = cs.ValidarNumeroCi3(txtCi.Text);
                if (banderaCi == false)
                {
                    lblError.Content += "Tipo formato ci 9999999 ó 9999999-A ó A-9999999\n";
                }
            }
            else
            {
                lblError.Content += "El Campo CI esta vacio \n";
            }
            if (txtName.Text != "")
            {
                banderaNombre = cs.ValidarTextoConÑSinEspacios(txtName.Text);
                if (banderaNombre == false)
                {
                    lblError.Content += "El nombre solo acepta letras sin espacios al principio ni \n al final ni mas de uno entre medias \n";
                }
            }
            else
            {
                lblError.Content += "El Campo Nombre esta vacio \n";
            }
            if (txtPrimerApellido.Text != "")
            {
                banderaApellidoPaterno = cs.ValidarTextoConÑSinEspacios(txtPrimerApellido.Text);
                if (banderaApellidoPaterno == false)
                {
                    lblError.Content += "El Apellido paterno solo acepta letras sin espacios al \n principio ni al final ni mas de uno entre medias \n";
                }
            }
            else
            {
                lblError.Content += "El Campo Primer Apellido esta vacio \n";
            }       

            if (dpBirthDate.Text != "")
            {
                banderaFecha = cs.CompruebaFecha(DateTime.Parse(dpBirthDate.Text));
                if (banderaFecha == false)
                {
                    lblError.Content += "Ingrese fecha Valida de mas de 15 años\n";
                }
            }
            else
            {
                lblError.Content += "El Campo fecha nacimiento esta vacio \n";
            }
            if (cbGenero.SelectedIndex == -1)
            {
                lblError.Content += "Seleccione un Genero \n";
            }

            if (txtTelefono.Text != "")
            {
                banderaTelefono = cs.validatePhone2(txtTelefono.Text);
                if (banderaTelefono == false)
                {
                    lblError.Content += "El telefono esta mal\n";
                }
            }
            else
            {
                lblError.Content += "El Campo Telefono esta vacio \n";
            }
            if (txtDireccion.Text != "")
            {
                banderaDireccion = cs.ValidarTextoConÑSinEspacios(txtDireccion.Text);
                if (banderaDireccion == false)
                {
                    lblError.Content += "La direccion solo acepta letras y numeros sin espacios al \n principio ni al final ni mas de uno entre medias \n";
                }
            }
            else
            {
                lblError.Content += "El Campo Direccion esta vacio \n";
            }           

            
            //MessageBox.Show(banderaCi.ToString() + banderaNombre.ToString() + banderaFecha.ToString() + banderaApellidoPaterno.ToString() +
                //banderaTelefono.ToString() + banderaDireccion.ToString());

            if (banderaCi == true && banderaNombre == true && banderaApellidoPaterno == true &&
                banderaFecha == true && banderaTelefono == true && banderaDireccion == true)
            {

                //si pasa los controles
                insertaCliente();
                WinAdmClient wc = new WinAdmClient();
                wc.Show();
                this.Close();
            }

        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("¿Esta realmente seguro de querer salir?", "Salir", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                WinAdmClient wc = new WinAdmClient();
                wc.Show();
                this.Close();
            }
        }
    }
}
