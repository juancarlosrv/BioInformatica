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
using VeterinarySmilesDAO.Implementations;
using VeterinarySmilesDAO.Models;

namespace VeterinarySmiles_Web
{
    public partial class WebUpdateSupplier : System.Web.UI.Page
    {
        SupplierImp implSuple;
        Supplier sup;

        int id;
        ControlMio cs;

        protected void Page_Load(object sender, EventArgs e)
        {
            compruebaSesion();
            LoadType();
            //id = int.Parse(Request.QueryString["id"]);
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
                bool banderaTelefono = false;
                bool banderaDireccion = false;
                bool banderaCorreo = false;

                if (txtName.Text != "")
                {
                    banderaNombre = cs.validarDireccionConNumeros(txtName.Text.Trim());
                    if (banderaNombre == false)
                    {
                        lblError.Text += "El nombre solo acepta letras sin espacios al principio ni \n al final ni mas de uno entre medias \n";
                    }
                }
                else
                {
                    lblError.Text += "El Campo Nombre esta vacio \n";
                }

                if (txtPhone.Text != "")
                {
                    banderaTelefono = cs.validatePhone2(txtPhone.Text.Trim());
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
                    banderaDireccion = cs.validarDireccionConNumeros(txtAddress.Text.Trim());
                    if (banderaDireccion == false)
                    {
                        lblError.Text += "La direccion solo acepta letras y numeros sin espacios al \n principio ni al final ni mas de uno entre medias \n";
                    }
                }
                else
                {
                    lblError.Text += "El Campo Direccion esta vacio \n";
                }
                if (txtEmail.Text != "")
                {
                    banderaCorreo = cs.ValidarCorreoDominio(txtEmail.Text.Trim());
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

                    implSuple = new SupplierImp();
                    sup = new Supplier(int.Parse(Request.QueryString["id"]), txtName.Text, txtPhone.Text, txtAddress.Text, txtEmail.Text);

                    int num = implSuple.Update(sup);

                    if (num > 0)
                    {
                        string mensaje = "Se actualizo con exito";
                        lblMensaje.Text = mensaje;


                        string url = "WebAdmSupplier.aspx";
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
                        implSuple = new SupplierImp();
                        sup = implSuple.Get(id);
                        txtName.Text = sup.Name.ToString().Trim();
                        txtAddress.Text = sup.Address.ToString().Trim();
                        txtPhone.Text = sup.Phone.ToString().Trim();
                        txtEmail.Text = sup.Email.ToString().Trim();

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