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
    /// Lógica de interacción para WinInsertVacunation.xaml
    /// </summary>
    public partial class WinInsertVacunation : Window
    {

        ControlMio cs;

        Vacunation v;
        VacunationImp impVac;
        public WinInsertVacunation()
        {
            InitializeComponent();        
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

        void insertaVacunacion()
        {
            try
            {
                v = new Vacunation((int)cbNamePet.SelectedValue, (int)cbNameVaccine.SelectedValue, DateTime.Parse(dpDate.Text), txtDescription.Text);

                impVac = new VacunationImp();

                int n = impVac.Insert(v);

                if (n > 0)
                {
                    MessageBox.Show("Registro Insertado Con Exito");


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

            bool banderaFecha = false;
            bool banderaDescripcion = false;



            if (cbNamePet.SelectedIndex == -1)
            {
                lblError.Content += "Seleccione una mascota \n";
            }

            if (cbNameVaccine.SelectedIndex == -1)
            {
                lblError.Content += "Seleccione una vacuna \n";
            }

            if (dpDate.Text != "")
            {
                banderaFecha = cs.CompruebaFechaCita(DateTime.Parse(dpDate.Text));
                if (banderaFecha == false)
                {
                    lblError.Content += "Pon fechas apartir de hoy \n";
                }
            }
            else
            {
                lblError.Content += "El Campo fecha de la cita esta vacio \n";
            }
            if (txtDescription.Text != "")
            {
                banderaDescripcion = cs.ValidarTextoConÑSinEspacios(txtDescription.Text);
                if (banderaDescripcion == false)
                {
                    lblError.Content += "La descripcion solo acepta letras numeros y caracteres raros \n";
                }
            }
            else
            {
                lblError.Content += "El Campo Descripcion esta vacio \n";
            }
            



            //MessageBox.Show(banderaFecha.ToString() + banderaDescripcion.ToString() );

            if (banderaFecha == true && banderaDescripcion)
            {

                insertaVacunacion();
                WinAdmVacunation wp = new WinAdmVacunation();
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

        void listPets()
        {


            VacunationImp vp = new VacunationImp();
            //cbNamePet.ItemsSource = null;
            DataTable tablePet = new DataTable();
            //impVac = new VacunationImp();


            tablePet = vp.listPets();

            //MessageBox.Show(tablePet.ToString());

            cbNamePet.DisplayMemberPath = "name";
            cbNamePet.SelectedValuePath = "id";
            cbNamePet.ItemsSource = tablePet.DefaultView;



        }


        void listVac()
        {

            //cbNamePet.ItemsSource = null;
            DataTable tableVac = new DataTable();
            impVac = new VacunationImp();


            tableVac = impVac.listVacs();

            //MessageBox.Show(tableVac.ToString());

            cbNameVaccine.DisplayMemberPath = "name";
            cbNameVaccine.SelectedValuePath = "id";
            cbNameVaccine.ItemsSource = tableVac.DefaultView;



        }

       

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            listPets();
            listVac();
        }
    }
}
