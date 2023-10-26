using DifficilBankDAO.Implementations;
using DifficilBankDAO.Models;
using DifficilBankDAO.utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VeterinarySmiles_Web
{
    public partial class WebAdmTypeProduct : System.Web.UI.Page
    {


        TypeProduct product;
        TypeProductImp tpImp;
        int id;

        ControlMio cs;

        protected void Page_Load(object sender, EventArgs e)
        {
            compruebaSesion();
            Select2();
            load();
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

                if (type == "De")
                {
                    //lblError.Text = " no Nulooooooooooooo";
                    Delete();

                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }



        public string limpia(string cadena)
        {
            string cadena2 = "";
            cadena2 = cadena.Trim();
            cadena2 = Regex.Replace(cadena, @"\s+", " ");

            return cadena2;
        }



        /*
           void Delete()
           {
               id = int.Parse(Request.QueryString["id"]);
               if (id > 0)
               {
                   try
                   {
                       tpImp = new TypeProductImp();
                       product = tpImp.Get(id);

                       if (product != null)
                       {
                           int n = tpImp.Delete(product);
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
           }*/


        void Delete()
        {
            id = int.Parse(Request.QueryString["id"]);
            if (id > 0)
            {
                try
                {
                    tpImp = new TypeProductImp();
                   
                    product = tpImp.Get(id);
                    //lblError.Text = " no Nulooooooooooooo";
                    if (product != null)
                    {
                        int n = tpImp.Delete(product);
                        // Realizar cualquier acción adicional después de la eliminación
                        //lblError.Text = " no Nulooooooooooooo";
                        Select2();
                    }
                    else
                    {
                        //lblError.Text = "Nulooooooooooooo";
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
                tpImp = new TypeProductImp();
                DataTable dt = tpImp.Select();
                DataTable table = new DataTable("Supplier");
                table.Columns.Add("Nombre", typeof(string));
                table.Columns.Add("Descripcion", typeof(string));
               

                table.Columns.Add("Acciones", typeof(string));
                //table.Columns.Add("Eliminar", typeof(string));

                foreach (DataRow dr in dt.Rows)
                {
                    table.Rows.Add(dr[1].ToString(), dr[2].ToString());
                }
                //GridData.DataSource = implSize.Select();
                gridData.DataSource = table;
                gridData.DataBind();

                for (int i = 0; i < gridData.Rows.Count; i++)
                {
                    string id = dt.Rows[i][0].ToString();
                    string up = " <a class='btn btn-secondary' style='background-color:#2a3547' href='WebUpdateTypeProduct.aspx?id=" + id + "&type=U'> Actualizar  </a> ";
                    string del = " <a class='btn btn-secondary' style='background-color:#2a3547' href='WebAdmTypeProduct.aspx?id=" + id + "&type=De' onclick='return ConfirmDelete();'> Eliminar  </a>  ";

                    gridData.Rows[i].Cells[2].Text = up;
                    gridData.Rows[i].Cells[2].Text += del;
                    gridData.Rows[i].Attributes["data-id"] = id;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        void Select()
        {


            try
            {

                tpImp = new TypeProductImp();
                //implSuple.Select();

                gridData.DataSource = tpImp.Select(); //lo igualamos porque en el datasource
                                                          //podemos poner drectamente el datatable

                gridData.DataBind();





                //gridData.Columns[1].Visible = false;



            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        protected void btnInsert_Click(object sender, EventArgs e)
        {
            try
            {


                lblError.Text = "";

                cs = new ControlMio();

                bool banderaNombre = false;
                bool banderaDescripcion = false;
                

                if (txtName.Text != "")
                {

                    string nombreMio = limpia(txtName.Text);
                    banderaNombre = cs.ValidarTextoConÑSinEspacios(nombreMio);
                    if (banderaNombre == false)
                    {
                        lblError.Text += "El nombre solo acepta letras \n";
                    }
                }
                else
                {
                    lblError.Text += "El Campo Nombre esta vacio \n";
                }
                if (txtDescription.Text != "")
                {
                    string descripcionMia=limpia(txtDescription.Text);
                    banderaDescripcion = cs.validarDireccionConNumeros(descripcionMia);
                    if (banderaDescripcion == false)
                    {
                        lblError.Text += "La descripcion solo acepta letras \n";
                    }
                }
                else
                {
                    lblError.Text += "El Campo Descripcion esta vacio \n";
                }

                if (banderaNombre == true && banderaDescripcion == true)
                {

                    //si pasa los controles
                    string nombreMio = limpia(txtName.Text);
                    string descripcionMia = limpia(txtDescription.Text);

                    product = new TypeProduct(nombreMio, descripcionMia);

                    tpImp = new TypeProductImp();

                    int n = tpImp.Insert(product);


                    if (n > 0)
                    {
                        lblError.Text = "Se inserto con exito";
                        Select2();

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
                    tpImp = new TypeProductImp();
                    product = tpImp.Get(id);
                    txtName.Text = product.Name.ToString();
                    txtDescription.Text = product.Description.ToString();

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}