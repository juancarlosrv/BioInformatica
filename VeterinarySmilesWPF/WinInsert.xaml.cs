using DifficilBankDAO.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
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
using DifficilBankDAO.utils;



namespace VeterinarySmilesWPF
{
    /// <summary>
    /// Lógica de interacción para WinInsert.xaml
    /// </summary>
    public partial class WinInsert : Window
    {
        ControlMio cs;

        User us;
        UserImp impUs;


        public WinInsert()
        {
            InitializeComponent();
        }

        void insertaUsuario()
        {
            try
            {

                //bool bandera = false;

                string user = "";
                string contra = "";
                string primerApellido = txtPrimerApellido.Text;
                string segundoApellido = txtSegundoApellido.Text;
                string nombre = txtName.Text;
                string rol = "";

                UserImp compruebaExistente = new UserImp();
         
                    string inicialApellidoPaternoMinuscula = primerApellido.Substring(0, 1).ToLower();
                    string inicialApellidoMaternoMinuscula = "";


                if (txtSegundoApellido.Text != "")
                {
                   
                    inicialApellidoMaternoMinuscula = segundoApellido.Substring(0, 1).ToLower();
                }
                

                    string nombreCompletoSinEspacios = Regex.Replace(nombre, @"\s", "").ToLower();

                    user = inicialApellidoPaternoMinuscula + inicialApellidoMaternoMinuscula + nombreCompletoSinEspacios + txtCi.Text + "-" + cbRol.Text.Substring(0, 1);

                    //Creamos contraseña aleatoria
                    var characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
                    var Charsarr = new char[8];
                    var random = new Random();

                    for (int i = 0; i < Charsarr.Length; i++)
                    {
                        Charsarr[i] = characters[random.Next(characters.Length)];
                    }

                    var resultString = new String(Charsarr);
                    contra = resultString;

                    //contra = "123";

                    switch (cbRol.SelectedIndex)
                    {
                        case 0:
                            rol = "Administrador";
                            break;

                        case 1:
                            rol = "Veterinario";
                            break;


                        case 2:
                            rol = "Cajero";
                            break;

                    }

                    DataTable table2 = compruebaExistente.CompruebaUsuExistente(user);    //Comprueba si ya existe ese usuario 
                    if (table2.Rows.Count > 0)
                    {
                        MessageBox.Show("Usuario Ya existente", "", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    else
                    {
                        us = new User(txtCi.Text, txtName.Text, txtPrimerApellido.Text, txtSegundoApellido.Text, DateTime.Parse(dpBirthDate.ToString()), char.Parse(cbGenero.Text), txtTelefono.Text, txtDireccion.Text, txtEmail.Text, user, contra, rol);
                        impUs = new UserImp();

                        int n = impUs.Insert(us);
                        if (n > 0)
                        {
                            MessageBox.Show("Registro Insertado Con Exito" + " user : " + user + " Contra :" + contra + " Se envio a tu correo electronico", "Registro exitoso!!!", MessageBoxButton.OK, MessageBoxImage.Information);
                           //MessaboxPositivo mp = new MessaboxPositivo();
                            //mp.Show();

                            //enviar correo

                            impUs.enviaEmailConCredenciales(us.Email, user, contra);

                            //Select();
                            //DisableSave();

                        }

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
            WinRegistra wr = new WinRegistra();
            wr.Show();
        }
        private void btnVuelveLogin_Click(object sender, RoutedEventArgs e)
        {
            WinLogin wl = new WinLogin();
            wl.Show();
            this.Close();
        }


        /*
        private bool compruebaFecha(DateTime fecha)
        {
            bool bandera = false;
            DateTime fechaHoy = DateTime.Now;
            //DateTime fecha = DateTime.Parse("2031-12-25");

            int comparacion = fechaHoy.CompareTo(fecha);

            if (comparacion < 0)
            {             
                //fecha futurista

            }
            else if (comparacion > 0)
            {

                //fecha buena


                TimeSpan diferencia = fechaHoy.Subtract(fecha);
                bool tiene15Anios = diferencia.TotalDays >= 365 * 15;

                if (tiene15Anios)
                {
                    //Console.WriteLine("Hay una diferencia de 15 años entre las fechas.");
                    bandera = true;
                }
                else
                {
                    //Console.WriteLine("No hay una diferencia de 15 años entre las fechas.");
                    bandera = false;
                }

            }
            else
            {
                //Console.WriteLine("La fecha de hoy);
            }

            return bandera;


        }
        */


        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            lblError.Content = "";

            cs = new ControlMio();

            bool banderaCi = false;
            bool banderaNombre = false;
            bool banderaApellidoPaterno = false;
            bool banderaTelefono = false;
            bool banderaDireccion = false;
            //bool banderaCompruebaArroba = cs.compruebaArroba(txtEmail.Text);
            //bool banderaCorreoEspacios = false;
            bool banderaCorreo = false;
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
                if (cbRol.SelectedIndex == -1)
                {
                    lblError.Content += "Seleccione un rol \n";
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
                    lblError.Content += "El telefono de 7 a 12 digitos \n";
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
                        lblError.Content += "Solo acepta letras y numeros sin espacios al \n principio ni al final ni mas de uno entre medias \n";
                    }
                }
                else
                {
                    lblError.Content += "El Campo Direccion esta vacio \n";
                }
                if (txtEmail.Text != "")
                {
                    banderaCorreo = cs.ValidarCorreoDominio(txtEmail.Text);
                    if (banderaCorreo == false)
                    {
                        lblError.Content += "Ingrese Email Valido \n";
                    }
                }
                else
                {
                    lblError.Content += "El Campo Email esta vacio \n";
                }

            if (banderaCi == true && banderaNombre == true && banderaApellidoPaterno == true &&
                banderaFecha == true && banderaTelefono == true && banderaDireccion == true &&
                banderaCorreo == true) {

                //MessageBox.Show("Insertado con exito");
                insertaUsuario();
                WinRegistra wr = new WinRegistra();
                wr.Show();
                this.Close();
            }

        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("¿Esta realmente seguro de querer salir?", "Salir", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                WinRegistra wr = new WinRegistra();
                wr.Show();
                this.Close();
            }
        }
    }

}
