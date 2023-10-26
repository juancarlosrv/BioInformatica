using DifficilBankDAO.Implementations;
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
using VeterinarySmilesDAO.Models;

namespace VeterinarySmilesWPF
{
    /// <summary>
    /// Lógica de interacción para WinAdmClient.xaml
    /// </summary>
    public partial class WinAdmClient : Window
    {
        ControlMio cs;

        byte op = 0;
        Client cl;
        ClientImpl impCli;
       

        public WinAdmClient()
        {
            InitializeComponent();
        }

        

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            
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

            txtCi.Focus();

            txtCi.Text = "";
            txtName.Text = "";
            txtPrimerApellido.Text = "";
            txtSegundoApellido.Text = "";
            dpBirthDate.Text = "";
            cbGenero.Text = "";
            txtDireccion.Text = "";
            txtTelefono.Text = "";
        }
        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            //insertaUsuario();
            EnableSave();
          
            //this.op = 1;

            WinInsertClient wi = new WinInsertClient();
            wi.Show();
            Visibility = Visibility.Hidden;
        }


        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            EnableSave();
            this.op = 2;
        }

        void insertaUsuario()
        {
            try
            {

                bool bandera = false;  

                if (txtCi.Text != "" && txtName.Text != "" && txtPrimerApellido.Text != "" && txtSegundoApellido.Text != "" &&
                    txtTelefono.Text != "" && txtDireccion.Text != "" && cbGenero.SelectedIndex != -1)

                {
                    bandera = true;
                }

                if (bandera == true)
                {
         
                        cl = new Client(txtCi.Text,txtName.Text, txtPrimerApellido.Text, txtSegundoApellido.Text, DateTime.Parse(dpBirthDate.ToString()), char.Parse(cbGenero.Text), txtTelefono.Text, txtDireccion.Text);
                        impCli = new ClientImpl();

                        int n = impCli.Insert(cl);
                        if (n > 0)
                        {
                            MessageBox.Show("Registro Insertado Con Exito", "Registro exitoso!!!", MessageBoxButton.OK, MessageBoxImage.Information);

                            Select();
                            DisableSave();

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
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            DisableSave();
        }

        private void dgVista_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if (dgVista.Items.Count > 0 && dgVista.SelectedItems != null)
            {
                cl = null;

                DataRowView dataRow = (DataRowView)dgVista.SelectedItem;
                //dataRow.Row.ItemArray[0].ToString();

                int id = int.Parse(dataRow.Row.ItemArray[0].ToString());

                try
                {

                    impCli = new ClientImpl();
                    cl = impCli.Get(id);
                    //MessageBox.Show(impPet.Get(id).ToString());
                    if (cl != null)
                    {

                        txtCi.Text = cl.Ci;
                        txtName.Text = cl.Name;
                        txtPrimerApellido.Text = cl.FirsName;
                        txtSegundoApellido.Text = cl.SecondLastName;
                        //cbGenero.Text = cl.Gender.ite;
                        txtDireccion.Text = cl.Address;
                        txtTelefono.Text = cl.Phone;
                        cbGenero.Text = cl.Gender.ToString();
                        dpBirthDate.Text = cl.BirtDate.ToString();
 

                    }
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }
        }

        
        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {

            if (cl != null && dgVista.SelectedItem != null)
            {
                if (MessageBox.Show("¿Esta realmente seguro de querer eliminar el registro?", "Eliminar", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    try
                    {
                        //delete
                        impCli = new ClientImpl();
                        int n = impCli.Delete(cl);
                        if (n > 0)
                        {
                            MessageBox.Show("Registro Eliminado");
                            Select();
                            DisableSave();
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
                MessageBox.Show("Debe de seleccionar un registro a eliminar");
            }



        }

        void Select()
        {
            try
            {
                impCli = new ClientImpl();
                dgVista.ItemsSource = null;
                dgVista.ItemsSource = impCli.Select().DefaultView;

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

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {


            switch (this.op)
            {
                case 1:

                    //Insert
                   
                    //inserta();


                    break;
                case 2:

                    //update

                    try
                    {

                        cl.Ci = txtCi.Text;
                        cl.Name = txtName.Text;
                        cl.FirsName= txtPrimerApellido.Text;
                        cl.SecondLastName = txtSegundoApellido.Text;
                        //cbGenero.Text = cl.Gender.ite;
                        cl.Address = txtDireccion.Text;
                        cl.Phone = txtTelefono.Text;



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
                                lblError.Content += "El telefono esta mal tiene que tener entre 7 a 12 numeros\n";
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

                            impCli = new ClientImpl();
                            int n = impCli.Update(cl);

                            if (n > 0)
                            {
                                // MessageBox.Show("Registro Actualizado con exito");
                                Messabox mb = new Messabox();
                                mb.Show();
                                Select();
                                DisableSave();
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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Select();
        }

        
    }
}
