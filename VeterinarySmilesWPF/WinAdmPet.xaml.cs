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
using VeterinarySmilesDAO.Models;
using VeterinarySmilesDAO.Implementations;
using VeterinarySmilesDAO;
using System.Data;
using DifficilBankDAO.utils;

namespace VeterinarySmilesWPF
{
    /// <summary>
    /// Lógica de interacción para WinAdmPet.xaml
    /// </summary>
    public partial class WinAdmPet : Window
    {
        ControlMio cs;

        byte op = 0;
        Pet p;
        PetImpl impPet;
        public WinAdmPet()
        {
            InitializeComponent();
        }

        private void btnVuelveLogin_Click(object sender, RoutedEventArgs e)
        {
            //WinLogin wl = new WinLogin();
            //wl.Show();
            MainWindow mw = new MainWindow();
            mw.Show();
            this.Close();
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

            txtName.IsEnabled = true;
            txtPeso.IsEnabled = true;
            txtRaza.IsEnabled = true;
            txtColor.IsEnabled = true;
            dpBirthDate.IsEnabled = true;

            txtName.Focus();
        }

        void DisableSave()
        {

            btnRegister.IsEnabled = true;
            //btnDelete.IsEnabled = true;
            //btnUpdate.IsEnabled = true;

            btnSave.IsEnabled = false;
            btnCancel.IsEnabled = false;

            txtName.IsEnabled = false;
            txtPeso.IsEnabled = false;
            txtRaza.IsEnabled = false;
            txtColor.IsEnabled = false;
            dpBirthDate.IsEnabled = false;

            txtName.Text = "";
            txtColor.Text = "";
            txtRaza.Text = "";
            txtPeso.Text = "";
            dpBirthDate.Text = "";
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            //insertaUsuario();
            EnableSave();

            //this.op = 1;

            WinInsertPet wi = new WinInsertPet();
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
                p = null;

                DataRowView dataRow = (DataRowView)dgVista.SelectedItem;
                //dataRow.Row.ItemArray[0].ToString();

                
                int id = int.Parse(dataRow.Row.ItemArray[0].ToString());

                try
                {

                    impPet = new PetImpl();
                    p = impPet.Get(id);
                    //MessageBox.Show(impPet.Get(id).ToString());
                    if (p != null)
                    {
                        txtName.Text = p.Name;
                        txtColor.Text = p.Color;
                        txtPeso.Text = p.Weigth.ToString();
                        txtRaza.Text = p.Breed;
                        dpBirthDate.Text = p.BirtDate.ToString();
                       
                        //dataPiker

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

            if (p != null && dgVista.SelectedItem != null)
            {
                if (MessageBox.Show("¿Esta realmente seguro de querer eliminar el registro?", "Eliminar", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    try
                    {
                        //delete
                        impPet = new PetImpl();
                        int n = impPet.Delete(p);
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
                impPet = new PetImpl();
                dgVista.ItemsSource = null;
                dgVista.ItemsSource = impPet.Select().DefaultView;

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
                        p.Name = txtName.Text;
                        p.Color = txtColor.Text;
                        p.Weigth = double.Parse(txtPeso.Text);
                        p.Breed = txtRaza.Text;
                        p.RegisterDate = DateTime.Parse(dpBirthDate.ToString());


                        lblError.Content = "";

                        cs = new ControlMio();
                        /*
                        bool banderaNombre = cs.ValidarTextoConÑSinEspacios(txtName.Text);
                        bool banderaFecha = cs.CompruebaFechaAnimal(DateTime.Parse(dpBirthDate.Text));
                        bool banderaColor = cs.ValidarTextoConÑSinEspacios(txtColor.Text);
                        bool banderaRaza = cs.ValidarTextoConÑSinEspacios(txtRaza.Text);
                        bool banderaPeso = cs.validaPeso(txtPeso.Text);*/
                        //bool banderaCompruebaArroba = cs.compruebaArroba(txtEmail.Text);
                        //bool banderaCorreoEspacios = cs.validaEspaciosConPunto(txtEmail.Text);
                        //bool banderaCorreo = cs.validarCorreo(txtEmail.Text);


                        bool banderaNombre = false;
                        bool banderaFecha = false;
                        bool banderaColor = false;
                        bool banderaRaza = false;
                        bool banderaPeso = false;


                        if (txtName.Text != "")
                        {
                            banderaNombre = cs.ValidarTextoConÑSinEspacios(txtName.Text);
                            if (banderaNombre == false)
                            {
                                lblError.Content += "El nombre solo acepta letras sin espacios al \n principio ni al final ni mas de uno entre medias \n";
                            }
                        }
                        else
                        {
                            lblError.Content += "El Campo nombre esta vacio \n";
                        }
                        if (dpBirthDate.Text != "")
                        {
                            banderaFecha = cs.CompruebaFechaAnimal(DateTime.Parse(dpBirthDate.Text));
                            if (banderaFecha == false)
                            {
                                lblError.Content += "No pongas fechas futuristas \n";
                            }
                        }
                        else
                        {
                            lblError.Content += "El Campo fecha nacimiento esta vacio \n";
                        }
                        if (txtPeso.Text != "")
                        {
                            banderaPeso = cs.validaPeso(txtPeso.Text);
                            if (banderaPeso == false)
                            {
                                lblError.Content += "El peso solo acepta numeros postivos hasta 200 \n";
                            }
                        }
                        else
                        {
                            lblError.Content += "El Campo Peso esta vacio \n";
                        }
                        if (txtRaza.Text != "")
                        {
                            banderaRaza = cs.ValidarTextoConÑSinEspacios(txtRaza.Text);
                            if (banderaRaza == false)
                            {
                                lblError.Content += "La especie solo acepta letras sin espacios al \n principio ni al final ni mas de uno entre medias \n";
                            }
                        }
                        else
                        {
                            lblError.Content += "El Campo especie esta vacio \n";
                        }
                        if (txtColor.Text != "")
                        {
                            banderaColor = cs.ValidarTextoConÑSinEspacios(txtColor.Text);
                            if (banderaColor == false)
                            {
                                lblError.Content += "El color solo acepta letras sin espacios al \n principio ni al final ni mas de uno entre medias \n";
                            }
                        }
                        else
                        {
                            lblError.Content += "El Campo color esta vacio \n";
                        }



                        //MessageBox.Show(banderaNombre.ToString() + banderaFecha.ToString() + banderaColor.ToString() + banderaPeso.ToString() + banderaRaza.ToString());

                        if (banderaNombre == true && banderaFecha == true && banderaColor == true &&
                            banderaPeso == true && banderaRaza == true)
                        {

                            //si pasa los controles
                            impPet = new PetImpl();
                            int n = impPet.Update(p);

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
        }

        
    }
}
