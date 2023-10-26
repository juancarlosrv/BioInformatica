using DifficilBankDAO.Models;
using DifficilBankDAO.utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
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
    /// Lógica de interacción para WinRegistra.xaml
    /// </summary>
    public partial class WinRegistra : Window
    {

        User us;
        UserImp impUs;
        public static int cont = 1;

        ControlMio cs;

        byte op = 0;

        public WinRegistra()
        {
            InitializeComponent();
            //botonActualiza();

        }

        void EnableSave()
        {
            btnRegister.IsEnabled = false;
            //btnDelete.IsEnabled = false;
            //btnUpdate.IsEnabled = false;

            btnSave.IsEnabled = true;
            btnCancel.IsEnabled = true;

           


            txtCi.IsEnabled = true;
            txtName.IsEnabled = true;
            txtPrimerApellido.IsEnabled = true;
            txtSegundoApellido.IsEnabled = true;
            dpBirthDate.IsEnabled = true;
            cbGenero.IsEnabled = true;
            txtDireccion.IsEnabled = true;
            txtTelefono.IsEnabled = true;
            cbRol.IsEnabled = true;
            txtEmail.IsEnabled = true;

            txtCi.Focus();
        }

        void DisableSave()
        {

            btnRegister.IsEnabled = true;
            //btnDelete.IsEnabled = true;
            //btnUpdate.IsEnabled = true;

            btnSave.IsEnabled = false;
            btnCancel.IsEnabled = false;

            txtCi.IsEnabled = false;
            txtName.IsEnabled = false;
            txtPrimerApellido.IsEnabled = false;
            txtSegundoApellido.IsEnabled = false;
            dpBirthDate.IsEnabled = false;
            cbGenero.IsEnabled = false;
            txtDireccion.IsEnabled = false;
            txtTelefono.IsEnabled = false;
            txtEmail.IsEnabled = false;

            txtCi.Focus();

            txtCi.Text = "";
            txtName.Text = "";
            txtPrimerApellido.Text = "";
            txtSegundoApellido.Text = "";
            dpBirthDate.Text = "";
            cbGenero.Text = "";
            txtDireccion.Text = "";
            txtTelefono.Text = "";
            txtEmail.Text = "";
            cbRol.Text = "";
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            MainWindow mw = new MainWindow();
            mw.Show();
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
                    txtTelefono.Text != "" && txtDireccion.Text != ""&&txtEmail.Text!="" && cbRol.SelectedIndex != -1)

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
                        us = new User(txtCi.Text, txtName.Text, txtPrimerApellido.Text, txtSegundoApellido.Text, DateTime.Parse(dpBirthDate.ToString()), char.Parse(cbGenero.Text), txtTelefono.Text, txtDireccion.Text,txtEmail.Text, user, contra, rol);
                        impUs = new UserImp();

                        int n = impUs.Insert(us);
                        if (n > 0)
                        {
                            MessageBox.Show("Registro Insertado Con Exito" + " user : " + user + " Contra :" + contra + " Se envio a tu correo electronico","Registro exitoso!!!",MessageBoxButton.OK,MessageBoxImage.Information);


                            //enviar correo

                            impUs.enviaEmailConCredenciales(us.Email,user,contra);

                            Select();
                            DisableSave();

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

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            //insertaUsuario();
            EnableSave();
            ocultaLogin();
            //this.op = 1;
     
            WinInsert wi = new WinInsert();
            wi.Show();
            Visibility = Visibility.Hidden;
        }

        private void btnVuelveLogin_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            mw.Show();
            this.Close();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            Select();
        }


        void Select()
        {
            try
            {
                impUs = new UserImp();
                dgVista.ItemsSource = null;
                dgVista.ItemsSource = impUs.Select().DefaultView;

    
                // Obtén una referencia a la primera columna del DataGrid
                DataGridColumn firstColumn = dgVista.Columns[0];

                // Remueve la primera columna del DataGrid
                dgVista.Columns.Remove(firstColumn);

                // Agrega la primera columna al final del DataGrid
                dgVista.Columns.Add(firstColumn);


                //ocultar el id
                dgVista.Columns[0].Visibility = Visibility.Collapsed;

                //MessageBox.Show(dgVista.Columns[0].Header.ToString());

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        
        private void btnModificaDatos_Click(object sender, RoutedEventArgs e)
        {
            WinModificaUser wmu = new WinModificaUser();
            wmu.Show();
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            EnableSave();
            muestraLogin();
            this.op = 2;

        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            //EnableSave();
            //ocultaLogin();
            if (us != null && dgVista.SelectedItem != null)
            {
                if (MessageBox.Show("¿Esta realmente seguro de querer eliminar el registro?", "Eliminar", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    try
                    {
                        //delete
                        impUs = new UserImp();
                        int n = impUs.Delete(us);
                        if (n > 0)
                        {
                            MessageBox.Show("Registro Eliminado","", MessageBoxButton.OK, MessageBoxImage.Information);
                            Select();
                            DisableSave();
                            ocultaLogin();
                        }
                    }
                    catch (Exception ex)
                    {

                        throw ex;
                    }
                }
            }
            else
            {
                MessageBox.Show("Debe de seleccionar un registro a eliminar","", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
        
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            switch (this.op)
            {
                case 1:
                    //Insert                 
                    //insertaUsuario();
                    break;
                case 2:

                    //update
                    try
                    {
                        muestraLogin();
                        //EnableSave();
                        

                        us.Ci = txtCi.Text;
                        us.Name = txtName.Text;
                        us.FirsName = txtPrimerApellido.Text;
                        us.SecondLastName = txtSegundoApellido.Text;
                        us.Rol = cbRol.Text;
                        us.BirtDate = DateTime.Parse(dpBirthDate.ToString());
                        us.Gender = char.Parse(cbGenero.Text);
                        us.Address = txtDireccion.Text;
                        us.Phone = txtTelefono.Text;
                        us.Email = txtEmail.Text;
                        us.UserName = txtUserName.Text;


                        lblError.Content = "";

                        cs = new ControlMio();

                        bool banderaCi = false;
                        bool banderaNombre = false;
                        bool banderaApellidoPaterno = false;
                        bool banderaTelefono = false;
                        bool banderaDireccion = false;
                        
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
                            banderaCorreo == true)
                        {

                            impUs = new UserImp();
                            int n = impUs.Update(us);

                            if (n > 0)
                            {
                                Messabox mp = new Messabox();
                                mp.Show();
                                //MessageBox.Show("Registro Actualizado con exito", "Actualizo!!!!", MessageBoxButton.OK, MessageBoxImage.Information);
                                Select();
                                DisableSave();
                                ocultaLogin();
                            }
                        }
                        
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    break;
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            DisableSave();
            ocultaLogin();
        }

        private void dgVista_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgVista.Items.Count > 0 && dgVista.SelectedItems != null)
            {
                us = null;

                DataRowView dataRow = (DataRowView)dgVista.SelectedItem;
                //dataRow.Row.ItemArray[0].ToString();

                int id = int.Parse(dataRow.Row.ItemArray[0].ToString());
                try
                {
                    impUs = new UserImp();
                    us = impUs.Get(id);
                    //MessageBox.Show(impPet.Get(id).ToString());
                    if (us != null)
                    {
                        //MessageBox.Show(us.Email);

                        txtCi.Text = us.Ci;
                        txtName.Text = us.Name;
                        txtPrimerApellido.Text = us.FirsName;
                        txtSegundoApellido.Text = us.SecondLastName;
                        //cbGenero.Text = cl.Gender.ite;
                        txtDireccion.Text = us.Address;
                        txtEmail.Text = us.Email;
                        txtTelefono.Text = us.Phone;
                        txtUserName.Text = us.UserName;
                        
                        cbGenero.Text = us.Gender.ToString();
                        cbRol.Text = us.Rol.ToString();
                        dpBirthDate.Text = us.BirtDate.ToString();

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        void ocultaLogin()
        {         
            lblUserName.Visibility = Visibility.Hidden;
            txtUserName.Visibility = Visibility.Hidden;
            
            txtUserName.IsEnabled = false;
            lblUserName.IsEnabled = false;
        }
        void muestraLogin()
        {
            lblUserName.Visibility = Visibility.Visible;
            txtUserName.Visibility = Visibility.Visible;
            
            txtUserName.IsEnabled = true;
            lblUserName.IsEnabled = true;       
        }
    }
}
