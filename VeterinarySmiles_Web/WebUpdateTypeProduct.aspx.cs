using DifficilBankDAO.Implementations;
using DifficilBankDAO.Models;
using DifficilBankDAO.utils;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VeterinarySmiles_Web
{
    public partial class WebUpdateTypeProduct : System.Web.UI.Page
    {

        TypeProduct product;
        TypeProductImp tpImp;
        int id;

        ControlMio cs;

        protected void Page_Load(object sender, EventArgs e)
        {
            compruebaSesion();
            LoadType();
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


        protected void btnSave_Click(object sender, EventArgs e)
        {

            try
            {




                lblError.Text = "";

                cs = new ControlMio();

                bool banderaNombre = false;
                bool banderaDescripcion = false;


                if (txtName.Text != "")
                {
                    banderaNombre = cs.ValidarTextoConÑSinEspacios(txtName.Text.Trim());
                    if (banderaNombre == false)
                    {
                        lblError.Text += "El nombre solo acepta letras sin espacios al principio ni \n al final ni mas de uno entre medias \n";
                    }
                }
                else
                {
                    lblError.Text += "El Campo Nombre esta vacio \n";
                }
                if (txtDescription.Text != "")
                {
                    banderaDescripcion = cs.validarDireccionConNumeros(txtDescription.Text.Trim());
                    if (banderaDescripcion == false)
                    {
                        lblError.Text += "La descripcion solo acepta letras sin espacios al principio ni \n al final ni mas de uno entre medias \n";
                    }
                }
                else
                {
                    lblError.Text += "El Campo Descripcion esta vacio \n";
                }

                if (banderaNombre == true && banderaDescripcion == true)
                {

                    tpImp = new TypeProductImp();
                    product = new TypeProduct(int.Parse(Request.QueryString["id"]), txtName.Text, txtDescription.Text);

                    int num = tpImp.Update(product);

                    if (num > 0)
                    {
                        string mensaje = "Se actualizo con exito";
                        lblMensaje.Text = mensaje;
                        string url = "WebAdmTypeProduct.aspx";
                        Response.Redirect(url);
                    }
                    else
                    {
                        string mensaje = "No se actualizo + \n";
                        lblMensaje.Text += mensaje + num.ToString();
                    }

                }




                
            }
            catch (Exception ex)
            {

                throw ex;
            }


        }

        void LoadType()
        {
            try
            {
                string type = Request.QueryString["type"];

                if (type == "U")
                {
                    Get();

                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        void Get()
        {
            try
            {
                if (!IsPostBack)
                {
                    id = int.Parse(Request.QueryString["id"]);
                    if (id > 0)
                    {
                        tpImp = new TypeProductImp();
                        product = tpImp.Get(id);
                        txtName.Text = product.Name.ToString().Trim();
                        txtDescription.Text = product.Description.ToString().Trim();
                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        
    }
}