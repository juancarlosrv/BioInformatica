using DifficilBankDAO.Implementations;
using DifficilBankDAO.Models;
using DifficilBankDAO.utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VeterinarySmiles_Web
{
    public partial class WebAdmSupplier : System.Web.UI.Page
    {
        SupplierImp implSuple;
        Supplier sup;

        int id;

        ControlMio cs;


        protected void Page_Load(object sender, EventArgs e)
        {

            Select2();
            load();
            compruebaSesion();

        }


      

        void DisableSave()
        {

            

            

            txtName.Focus();

            txtName.Text = "";
            txtPhone.Text = "";
            txtAddress.Text = "";
            txtEmail.Text = "";
            
        }

        public string limpia(string cadena)
        {
            string cadena2 = "";
            cadena2 = cadena.Trim();
            cadena2 = Regex.Replace(cadena, @"\s+", " ");

            return cadena2;
        }
        void compruebaSesion()
        {

            if (!IsPostBack)
            {
                if (Session["userID"] != null)
                {                
                    if (Session["role"].ToString() == "Administrador")
                    {

                    }
                    else
                    {
                        string urlVet = "Default.aspx";
                        Response.Redirect(urlVet);

                    }
                }
                else
                {
                    string urlVet = "Default.aspx";
                    Response.Redirect(urlVet);
                }
            }
        }


        void load()
        {
            try
            {
                string type = Request.QueryString["type"];

                if (type == "D")
                {
                    Delete();

                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        /*
        void Delete()
        {
            id = byte.Parse(Request.QueryString["id"]);
            if (id > 0)
            {
                try
                {

                    implSuple = new SupplierImp();
                    
                    int n = implSuple.Delete2(id);

                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }*/
        
        void Delete()
        {
            id = int.Parse(Request.QueryString["id"]);
            if (id > 0)
            {
                try
                {
                    implSuple = new SupplierImp();

                    // Obtener el objeto Customer antes de llamar al método Delete
                    sup = implSuple.Get(id);



                    if (sup != null)
                    {
                        int n = implSuple.Delete(sup);
                        Select2();
                        // Realizar cualquier acción adicional después de la eliminación
                    }
                    else
                    {
                        
                        // El objeto Customer no existe en la base de datos, manejar el caso de error
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        

        void Select2()
        {   
                try
                {
                    implSuple = new SupplierImp();    //instancias el implimentador
                    DataTable dt = implSuple.Select();  //en datatable capturas los datos del select
                    DataTable table = new DataTable("Supplier"); //creams una tabla
                    table.Columns.Add("Nombre", typeof(string));
                    table.Columns.Add("Telefono", typeof(string));
                    table.Columns.Add("Direccion", typeof(string));
                    table.Columns.Add("Email", typeof(string));
                
                    table.Columns.Add("Acciones", typeof(string));
                    //table.Columns.Add("Eliminar", typeof(string));

                    foreach (DataRow dr in dt.Rows)
                    {
                        table.Rows.Add(dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString());
                    }
                    //GridData.DataSource = implSize.Select();
                    gridData.DataSource = table;
                    gridData.DataBind();

                    for (int i = 0; i < gridData.Rows.Count; i++)
                    {
                        string id = dt.Rows[i][0].ToString();
                        string up = " <a class='btn btn-secondary' style='background-color:#2a3547' href='WebUpdateSupplier.aspx?id=" + id + "&type=U'> Actualizar  </a> ";
                        string del = " <a class='btn btn-secondary' style='background-color:#2a3547' href='WebAdmSupplier.aspx?id=" + id + "&type=D' onclick='return ConfirmDelete();'> Eliminar  </a>  ";


                        gridData.Rows[i].Cells[4].Text = up;
                        gridData.Rows[i].Cells[4].Text += del;
                        //gridData.Rows[i].Cells[5].Text = del;
                    gridData.Rows[i].Attributes["data-id"] = id;
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }          
        }
        /*
        void Select()
        {


            try
            {

                implSuple = new SupplierImp();
                //implSuple.Select();

                gridData.DataSource = implSuple.Select(); //lo igualamos porque en el datasource
                                                          //podemos poner drectamente el datatable

                gridData.DataBind();





                //gridData.Columns[1].Visible = false;



            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        */
        protected void btnInsert_Click(object sender, EventArgs e)
        {
            try
            {
                lblError.Text = "";

                cs = new ControlMio();

                bool banderaNombre = false;
                bool banderaTelefono = false;
                bool banderaDireccion = false;
                bool banderaCorreo = false;


                if (txtName.Text != "")
                {
                    string nombreMio = limpia(txtName.Text);
                    banderaNombre = cs.validarDireccionConNumeros(nombreMio);
                    if (banderaNombre == false)
                    {
                        lblError.Text += "El nombre solo acepta letras y numeros \n";
                    }
                }
                else
                {
                    lblError.Text += "El Campo Nombre esta vacio \n";
                }

                if (txtPhone.Text != "")
                {
                    string telefonoMio = limpia(txtPhone.Text);
                    banderaTelefono = cs.validatePhone2(telefonoMio);
                    if (banderaTelefono == false)
                    {
                        lblError.Text += "El telefono esta mal tiene que tener entre 7 a 12 numeros\n";
                    }
                }
                else
                {
                    lblError.Text += "El Campo Telefono esta vacio \n";
                }

                if (txtAddress.Text != "")
                {
                    string direccionMia = limpia(txtAddress.Text);
                    banderaDireccion = cs.validarDireccionConNumeros(direccionMia);
                    if (banderaDireccion == false)
                    {
                        lblError.Text += "La direccion solo acepta letras y numeros \n";
                    }
                }
                else
                {
                    lblError.Text += "El Campo Direccion esta vacio \n";
                }
                if (txtEmail.Text != "")
                {
                    string emailMio = limpia(txtEmail.Text);
                    banderaCorreo = cs.ValidarCorreoDominio(emailMio);
                    if (banderaCorreo == false)
                    {
                        lblError.Text += "Ingrese Email Valido \n";
                    }
                }
                else
                {
                    lblError.Text += "El Campo Email esta vacio \n";
                }

                if (banderaNombre == true && banderaTelefono == true && banderaDireccion == true &&
                            banderaCorreo == true)
                {

                    //si pasa los controles


                    string nombreMio = limpia(txtName.Text);
                    string telefonoMio = limpia(txtPhone.Text);
                    string direccionMia = limpia(txtAddress.Text);
                    string emailMio = limpia(txtEmail.Text);

                    sup = new Supplier(nombreMio, telefonoMio, direccionMia, emailMio);

                    implSuple = new SupplierImp();

                    int n = implSuple.Insert(sup);


                    if (n > 0)
                    {

                        Select2();
                        lblError.Text = "Inserto con exito;";
                        //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Inserto Con exito')", true);
                    }
                }


               


            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                Get();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
           
            Delete();
        }

        

        void Get()
        {
            try
            {
                id = int.Parse(Request.QueryString["id"]);
                if (id > 0)
                {
                    implSuple = new SupplierImp();
                    sup = implSuple.Get(id);
                    txtName.Text = sup.Name.ToString();
                    txtAddress.Text = sup.Address.ToString();
                    txtPhone.Text = sup.Phone.ToString();
                    txtEmail.Text = sup.Email.ToString();

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}