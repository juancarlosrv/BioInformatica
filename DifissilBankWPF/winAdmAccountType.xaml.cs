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
using VeterinarySmiles.Model;
using VeterinarySmiles.Implementacion;
using VeterinarySmiles;
using System.Data;

namespace DifissilBankWPF
{
    /// <summary>
    /// Lógica de interacción para winAdmAccountType.xaml
    /// </summary>
    public partial class winAdmAccountType : Window
    {
        byte op = 0;
        AccountType t;
        AccountTypeImpl implAccountType;
        public winAdmAccountType()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        void EnableSave()
        {
            btnInsert.IsEnabled = false;
            btnDelete.IsEnabled = false;
            btnUpdate.IsEnabled = false;

            btnCancel.IsEnabled =       true;
            btnSave.IsEnabled =         true;
            txtDescription.IsEnabled =  true;
            txtName.IsEnabled =         true;
            txtInterestedRate.IsEnabled = true;
            txtName.Focus();
        }
        void DisableSave()
        {
            btnInsert.IsEnabled = true;
            btnDelete.IsEnabled = true;
            btnUpdate.IsEnabled = true;

            btnCancel.IsEnabled = false;
            btnSave.IsEnabled = false;
            txtDescription.IsEnabled = false;
            txtName.IsEnabled = false;
            txtInterestedRate.IsEnabled = false;  
            txtName.Text = "";
            txtInterestedRate.Text = "";
            txtDescription.Text = "";
        }

        private void btnInsert_Click(object sender, RoutedEventArgs e)
        {
            EnableSave();
            this.op = 1;
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            EnableSave();
            this.op = 2;
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            
            if (t!=null && dgvData.SelectedItem!=null)
            {
                if (MessageBox.Show("Esta realmente segur@ de eliminar el registro?","Eliminar",MessageBoxButton.YesNo,MessageBoxImage.Warning)==MessageBoxResult.Yes)
                {
                    implAccountType = new AccountTypeImpl();
                    int n=implAccountType.Delete(t);
                    if (n>0)
                    {
                        MessageBox.Show("Registro Eliminado");
                        Select();
                        DisableSave();
                    }
                }
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            
            switch (this.op) 
            {
                case 1:
                    //insert
                    try
                    {
                        t = new AccountType(txtName.Text,txtDescription.Text, double.Parse(txtInterestedRate.Text));
                        implAccountType = new AccountTypeImpl();
                        int n=implAccountType.Insert(t);
                        if (n>0)
                        {
                            MessageBox.Show("Registro insertado con exito");
                            //select
                            Select();
                            DisableSave();
                        }
                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show(ex.Message);
                    }


                    break;
                    case 2:
                        try
                        //update

                        {
                            t.Name = txtName.Text;
                            t.Descripcion = txtDescription.Text;
                            t.InterestRate = double.Parse(txtInterestedRate.Text);

                            implAccountType=new AccountTypeImpl();
                            int n= implAccountType.Update(t);

                            if (n>0)
                            {
                                MessageBox.Show("Registro modificado con exito");
                                Select(); 
                                DisableSave();    
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
        }
        void Select()
        {
            try
            {
                implAccountType = new AccountTypeImpl();
                dgvData.ItemsSource = null;
                dgvData.ItemsSource = implAccountType.Select().DefaultView;
                dgvData.Columns[0].Visibility = Visibility.Collapsed;
                
            
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void dgvData_Loaded(object sender, RoutedEventArgs e)
        {
            Select();
        }

        private void dgvData_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgvData.Items.Count>0 && dgvData.SelectedItem!=null)
            {
                t = null;
                DataRowView dataRorw = (DataRowView)dgvData.SelectedItem;
                byte id = byte.Parse(dataRorw.Row.ItemArray[0].ToString());
                try
                {
                    implAccountType = new AccountTypeImpl();
                    t = implAccountType.Get(id);
                    if(t != null) 
                    {
                        txtName.Text = t.Name;
                        txtDescription.Text = t.Descripcion;
                        txtInterestedRate.Text= t.InterestRate.ToString();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    
                }
                
                
            }
        }
    }
}
