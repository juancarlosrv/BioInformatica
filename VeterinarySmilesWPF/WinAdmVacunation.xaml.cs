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
    /// Lógica de interacción para WinAdmVacunation.xaml
    /// </summary>
    public partial class WinAdmVacunation : Window
    {

        ControlMio cs;

        byte op = 0;
        Vacunation v;
        VacunationImp impVac;

        public WinAdmVacunation()
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

        void EnableSave()
        {

            btnRegister.IsEnabled = false;
            //btnDelete.IsEnabled = false;
            //btnUpdate.IsEnabled = false;

            btnSave.IsEnabled = true;
            btnCancel.IsEnabled = true;

            
            cbNamePet.IsEnabled = true;
            cbNameVaccine.IsEnabled = true;
            dpDate.IsEnabled = true;
            txtDescription.IsEnabled = true;

            cbNamePet.Focus();
        }

        void DisableSave()
        {

            btnRegister.IsEnabled = true;
            //btnDelete.IsEnabled = true;
            //btnUpdate.IsEnabled = true;

            btnSave.IsEnabled = false;
            btnCancel.IsEnabled = false;


            cbNamePet.IsEnabled = false;
            cbNameVaccine.IsEnabled = false;
            dpDate.IsEnabled = false;
            txtDescription.IsEnabled = false;


            cbNamePet.Text = "";
            cbNameVaccine.Text = "";
            dpDate.Text = "";
            txtDescription.Text = "";
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            //insertaUsuario();
            EnableSave();
            //this.op = 1;

            WinInsertVacunation wi = new WinInsertVacunation();
            wi.Show();
            Visibility = Visibility.Hidden;
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            EnableSave();
            this.op = 2;
        }

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

                int id = int.Parse(dataRow.Row.ItemArray[0].ToString());

                try
                {

                    impVac = new VacunationImp();
                    v = impVac.Get(id);
                    //MessageBox.Show(impVac.Get(id).ToString());
                    if (v != null)
                    {

                        cbNamePet.SelectedValue = v.IdPet.ToString();
                        cbNameVaccine.SelectedValue = v.IdVaccine.ToString();

                        dpDate.Text = v.Date.ToString();
                        txtDescription.Text = v.Description;                     
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
                        impVac = new VacunationImp();
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
                impVac = new VacunationImp();
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

                    break;
                case 2:

                    //update

                    try
                    {
                        //(int)cbNamePet.SelectedValue, (int)cbNameVaccine.SelectedValue, DateTime.Parse(dpDate.Text), txtDescription.Text);

                        v.IdPet = int.Parse(cbNamePet.SelectedValue.ToString());
                        v.IdVaccine = int.Parse(cbNameVaccine.SelectedValue.ToString());
                        v.Date = DateTime.Parse(dpDate.Text);
                        v.Description = txtDescription.Text;


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
                                lblError.Content += "Pon una fecha apartir de hoy \n";
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


                        //MessageBox.Show(banderaFecha.ToString() + banderaDescripcion.ToString());

                        if (banderaFecha == true && banderaDescripcion)
                        {

                            //si pasa los controles
                            impVac = new VacunationImp();
                            int n = impVac.Update(v);

                            if (n > 0)
                            {
                                MessageBox.Show("Registro Actualizado con exito");
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
            listPets();
            listVac();
        }

        private void cbNamePet_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
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
    }
}
