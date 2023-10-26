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
    /// Lógica de interacción para WinInsertVeterinaryProduct.xaml
    /// </summary>
    public partial class WinInsertVeterinaryProduct : Window
    {

        ControlMio cs;

        VeterinaryProduct v;
        VeterinaryProductImp impVac;
        public WinInsertVeterinaryProduct()
        {
            InitializeComponent();
            listTypeProduct();
            listSupplier();
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

        void insertaProductoVeterinario()
        {
            try
            {
                v = new VeterinaryProduct(txtNombre.Text,int.Parse(txtStock.Text),double.Parse(txtPrecio.Text),(int)cbTipoProducto.SelectedValue, (int)cbProveedor.SelectedValue);

                impVac = new VeterinaryProductImp();

                int n = impVac.Insert(v);

                if (n > 0)
                {
                    //MessageBox.Show("Registro Insertado Con Exito");
                    MessaboxPositivo mp = new MessaboxPositivo();
                    mp.Show();

                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }


        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
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

                insertaProductoVeterinario();
                WinAdmVeterinaryProduct wp = new WinAdmVeterinaryProduct();
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



        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            listTypeProduct();
            listSupplier();
        }



    }
}
