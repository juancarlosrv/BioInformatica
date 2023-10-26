using DifficilBankDAO.Implementations;
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

namespace VeterinarySmilesWPF
{
    /// <summary>
    /// Lógica de interacción para WinAdmVeterinaryProduct.xaml
    /// </summary>
    public partial class WinAdmVeterinaryProduct : Window
    {

        ControlMio cs;

        byte op = 0;
        VeterinaryProduct v;
        VeterinaryProductImp impVac;


        public WinAdmVeterinaryProduct()
        {
            InitializeComponent();
        }



        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            MainWindow mw = new MainWindow();
            mw.Show();
        }

        void EnableSave()
        {

            btnRegister.IsEnabled = false;
            //btnDelete.IsEnabled = false;
            //btnUpdate.IsEnabled = false;

            btnSave.IsEnabled = true;
            btnCancel.IsEnabled = true;

            txtNombre.IsEnabled = true;
            txtPrecio.IsEnabled = true;
            txtStock.IsEnabled = true;
            cbProveedor.IsEnabled = true;
            cbTipoProducto.IsEnabled = true;


            txtNombre.Focus();
        }

        void DisableSave()
        {

            btnRegister.IsEnabled = true;
            //btnDelete.IsEnabled = true;
            //btnUpdate.IsEnabled = true;

            btnSave.IsEnabled = false;
            btnCancel.IsEnabled = false;

            txtNombre.IsEnabled = false;
            txtPrecio.IsEnabled = false;
            txtStock.IsEnabled = false;
            cbProveedor.IsEnabled = false;
            cbTipoProducto.IsEnabled = false;
          

            txtNombre.Focus();

            txtNombre.Text = "";
            txtPrecio.Text = "";
            txtStock.Text = "";
            cbProveedor.Text = "";
            cbTipoProducto.Text = "";
           
        }
        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            //insertaUsuario();
            EnableSave();

            //this.op = 1;

            WinInsertVeterinaryProduct wi = new WinInsertVeterinaryProduct();
            wi.Show();
            Visibility = Visibility.Hidden;
        }


        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            EnableSave();
            this.op = 2;
        }
        /*
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

                    cl = new Client(txtCi.Text, txtName.Text, txtPrimerApellido.Text, txtSegundoApellido.Text, DateTime.Parse(dpBirthDate.ToString()), char.Parse(cbGenero.Text), txtTelefono.Text, txtDireccion.Text);
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
        }*/
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            DisableSave();
        }

        private void dgVista_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if (dgVista.Items.Count > 0 && dgVista.SelectedItems != null)
            {
                v = null;

                DataRowView dataRow = (DataRowView)dgVista.SelectedItem;
                //dataRow.Row.ItemArray[0].ToString();


                

                int id = int.Parse(dataRow.Row.ItemArray[0].ToString());

                try
                {

                    impVac = new VeterinaryProductImp();
                    v = impVac.Get(id);
                    //MessageBox.Show(impPet.Get(id).ToString());
                    if (v != null)
                    {

                        txtNombre.Text = v.Name;
                        txtStock.Text = v.Stock.ToString();
                        txtPrecio.Text = v.Price.ToString();
                        cbTipoProducto.SelectedValue = v.IdTypeProduct.ToString();
                        cbProveedor.SelectedValue = v.IdSupplier.ToString();

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

            if (v != null && dgVista.SelectedItem != null)
            {
                if (MessageBox.Show("¿Esta realmente seguro de querer eliminar el registro?", "Eliminar", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    try
                    {
                        //delete
                        impVac = new VeterinaryProductImp();
                        int n = impVac.Delete(v);
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
                impVac = new VeterinaryProductImp();
                dgVista.ItemsSource = null;
                dgVista.ItemsSource = impVac.Select().DefaultView;

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

                        v.Name = txtNombre.Text;
                        v.Stock = int.Parse(txtStock.Text);
                        v.Price = double.Parse(txtPrecio.Text);
                        v.IdTypeProduct = int.Parse(cbTipoProducto.SelectedValue.ToString());
                        v.IdSupplier = int.Parse(cbProveedor.SelectedValue.ToString());



                        lblError.Content = "";

                        cs = new ControlMio();

                        bool banderaNombre = false;
                        bool banderaStock = false;
                        bool banderaPrecio = false;

                        if (txtNombre.Text != "")
                        {
                            banderaNombre = cs.ValidarTextoConÑSinEspacios(txtNombre.Text);
                            if (banderaNombre == false)
                            {
                                lblError.Content += "El nombre solo acepta letras sin caracteres raros \n";
                            }
                        }
                        else
                        {
                            lblError.Content += "El Campo nombre esta vacio \n";
                        }
                        if (txtStock.Text != "")
                        {
                            banderaStock = cs.validaNumeroPositivo(txtStock.Text);
                            if (banderaStock == false)
                            {
                                lblError.Content += "El stock no puede ser negativo \n";
                            }
                        }
                        else
                        {
                            lblError.Content += "El Campo stock esta vacio \n";
                        }
                        if (txtPrecio.Text != "")
                        {
                            banderaPrecio = cs.validaNumeroPositivoMayor0(txtPrecio.Text);
                            if (banderaPrecio == false)
                            {
                                lblError.Content += "El precio no puede ser negativo ni igual a 0 \n";
                            }
                        }
                        else
                        {
                            lblError.Content += "El Campo precio esta vacio \n";
                        }

                        if (cbTipoProducto.SelectedIndex == -1)
                        {
                            lblError.Content += "Seleccione un tipo de Producto Veterinario \n";
                        }

                        if (cbProveedor.SelectedIndex == -1)
                        {
                            lblError.Content += "Seleccione un proveedor \n";
                        }






                        //MessageBox.Show(banderaFecha.ToString() + banderaDescripcion.ToString() );

                        if (banderaPrecio == true && banderaNombre == true && banderaStock == true)
                        {

                            //si pasa los controles
                            impVac = new VeterinaryProductImp();
                            int n = impVac.Update(v);

                            if (n > 0)
                            {
                                //MessageBox.Show("Registro Actualizado con exito");
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
            listTypeProduct();
            listSupplier();
        }

        void listTypeProduct()
        {


            VeterinaryProductImp vp = new VeterinaryProductImp();
            //cbNamePet.ItemsSource = null;
            DataTable tablePet = new DataTable();
            //impVac = new VacunationImp();


            tablePet = vp.listTypeProduct();

            //MessageBox.Show(tablePet.ToString());

            cbTipoProducto.DisplayMemberPath = "name";
            cbTipoProducto.SelectedValuePath = "id";
            cbTipoProducto.ItemsSource = tablePet.DefaultView;



        }


        void listSupplier()
        {

            //cbNamePet.ItemsSource = null;
            DataTable tableVac = new DataTable();
            impVac = new VeterinaryProductImp();


            tableVac = impVac.listSupplier();

            //MessageBox.Show(tableVac.ToString());

            cbProveedor.DisplayMemberPath = "name";
            cbProveedor.SelectedValuePath = "id";
            cbProveedor.ItemsSource = tableVac.DefaultView;



        }

    }
}
