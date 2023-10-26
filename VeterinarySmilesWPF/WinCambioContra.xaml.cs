using DifficilBankDAO.Models;
using DifficilBankDAO.utils;
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

namespace VeterinarySmilesWPF
{
    /// <summary>
    /// Lógica de interacción para WinCambioContra.xaml
    /// </summary>
    public partial class WinCambioContra : Window
    {

        ControlMio cs;

        User u;

        UserImp usImp;

        public WinCambioContra()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnRegistra_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnVuelveLogin_Click(object sender, RoutedEventArgs e)
        {
            WinLogin wl = new WinLogin();
            wl.Show();
            this.Close();
        }



        bool hayMayuscula(string texto)
        {
            bool salida = false;

            for (int i = 0; i < texto.Length; i++)
            {
                if (char.IsUpper(texto[i]))
                {
                    salida = true;
                }
            }
            return salida;
        }

        bool hayMinuscula(string texto)
        {
            bool salida = false;

            for (int i = 0; i < texto.Length; i++)
            {
                if (char.IsLower(texto[i]))
                {
                    salida = true;
                }
            }
            return salida;
        } 

        

        private void btnCambioContra_Click(object sender, RoutedEventArgs e)
        {

            try
            {

                cs = new ControlMio();

                //guardamos en variables los txts para que se haga mas corto
                string login = txtLogin.Text;
                string contraAntigua = txtPasswordAntiguo.Password;
                string contraNueva = txtNuevoPassword.Password;
                string repetirPasword = txtRepetirPassword.Password;

                usImp = new UserImp();  //para el actualiza contra

                UserImp compruebaExiste; //para el select comprueba si existe
                compruebaExiste = new UserImp();

                DataTable compruebaSiExiste = compruebaExiste.CompruebaUsuExistente(login);    //Comprueba si ya existe ese usuario 
                if (compruebaSiExiste.Rows.Count > 0) //si existe nos devolvera x lo menos una fila
                {
                    if (txtNuevoPassword.Password != "")
                    {
                        //Una vez visto que exite el usuario y que escribe una contraseña verificamos si es la contra del usuario


                        


                        if (contraNueva.Length >= 8)
                        {
                            bool banderaLetrasNumerosYCaracteresRaros = cs.ValidarContraseñaLetrasNumerosYCaracteresRaros(contraNueva);
                            if (banderaLetrasNumerosYCaracteresRaros == true)
                            {
                               

                                    if (contraNueva == repetirPasword) //comprobamos que la contraseña sea la misma
                                    {
                                        int l = usImp.UpdatePassword(login, txtPasswordAntiguo.Password, txtNuevoPassword.Password); //nos devuelve mas de uno si todo bien

                                        if (l > 0)
                                        {
                                            MessageBox.Show("Se cambio la contraseña correctamente","¡¡¡Se actualizo la contrseña!!!",MessageBoxButton.OK,MessageBoxImage.Information);

                                            WinLogin wl = new WinLogin();
                                            wl = new WinLogin();
                                            this.Close();
                                        }
                                        else
                                        {
                                            MessageBox.Show("Tu contraseña temporal esta mal escrita", "contraseña inexistente", MessageBoxButton.OK, MessageBoxImage.Error);
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("Las contraseñas no coinciden", "No coinciden", MessageBoxButton.OK, MessageBoxImage.Error);
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("La contraseña tiene que contener una minuscula una mayuscula un numero y un caracter raro ", "Contraseña sin minusculas", MessageBoxButton.OK, MessageBoxImage.Error);
                                }
                            
                        }
                        else
                        {
                            MessageBox.Show("La contraseña tiene que tener minimo 8 caracteres", "contraseña menor a 8 caracteres", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("El campo contraseña esta vacia", "contraseña vacia", MessageBoxButton.OK, MessageBoxImage.Error);
                    }               
                }
                else
                {
                    MessageBox.Show("No se encontro el usuario pon un usuario valido","Usurio inexistente",MessageBoxButton.OK,MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

            

            





            
        }
    }
}
