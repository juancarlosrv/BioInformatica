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

namespace VeterinarySmilesWPF
{
    /// <summary>
    /// Lógica de interacción para WinModificaUser.xaml
    /// </summary>
    public partial class WinModificaUser : Window
    {

        User us;
        UserImp impUs;
        public WinModificaUser()
        {
            InitializeComponent();
            
        }

        void insertaUsuario()
        {
            try
            {

                bool bandera = false;

                string user = "";
                string contra = "";
                string primerApellido = txtPrimerApellido.Text;
                string segundoApellido = txtSegundoApellido.Text;
                string nombre = txtName.Text;
                string rol = "";

                UserImp compruebaExistente = new UserImp();



                if (txtCi.Text != "" && txtName.Text != "" && txtPrimerApellido.Text != "" && txtSegundoApellido.Text != "" &&
                    txtTelefono.Text != "" && txtDireccion.Text != "" && txtEmail.Text != "" && cbRol.SelectedIndex != -1)

                {
                    bandera = true;
                }

                if (bandera == true)
                {
                    string inicialApellidoPaternoMinuscula = primerApellido.Substring(0, 1).ToLower();
                    string inicialApellidoMaternoMinuscula = segundoApellido.Substring(0, 1).ToLower();
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


                            //enviar correo

                            impUs.enviaEmailConCredenciales(us.Email, user, contra);

                            //Select();
                            //DisableSave();

                        }

                    }
                }
                else
                {
                    MessageBox.Show("Ingrese todos los valores", "", MessageBoxButton.OK, MessageBoxImage.Error);
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
            insertaUsuario();
            WinRegistra wr = new WinRegistra();
            wr.Show();
            this.Close();
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
