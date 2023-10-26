using DifficilBankDAO.Implementations;
using DifficilBankDAO.Models;
using DifficilBankDAO.utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using VeterinarySmilesDAO.Implementations;

namespace VeterinarySmiles_Web
{
    public partial class WebUpdatePassword : System.Web.UI.Page
    {

        ControlMio cs;

        UserImp2 impUser;
        UserImp2 impUser2;

        static int id;

        protected void Page_Load(object sender, EventArgs e)
        {
            xd();
        }



        void xd()
        {

            if (!IsPostBack)
            {


                   if (Session["userID"] != null)
                    {
                        id = int.Parse(Session["userID"].ToString());
                        //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('"+ Session["userID"].ToString() + "')", true);

                        //lblError.Text = Session["userID"].ToString() + Session["userName"].ToString() +
                        //Session["role"].ToString();

                        if (Session["role"].ToString() == "Administrador" || Session["role"].ToString() == "Cajero"
                            || Session["role"].ToString() == "Veterinario")
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








        protected void btnCambiar_Click(object sender, EventArgs e)
        {
            lblError.Text="";


            try
            {

                cs = new ControlMio();

                //guardamos en variables los txts para que se haga mas corto
                //string login = txtLogin.Text;
                string contraAntigua = txtpasswordActual.Text;
                string contraNueva = txtPasswordNueva.Text;
                string repetirPasword = txtRepetirPassword.Text;

                impUser = new UserImp2();  //para el actualiza contra
                impUser2 = new UserImp2();  //para el actualiza contra


                UserImp2 compruebaExiste; //para el select comprueba si existe
                compruebaExiste = new UserImp2();

                DataTable compruebaSiExiste;
                DataTable compruebaSiEsSuContra;

                //bool banderaUsuario = false;
                bool banderaContraActual = false;
                bool banderaContrasNueva = false;
                bool banderaRepetirContra = false;

                /*
                if (txtLogin.Text != "")
                {
                    compruebaSiExiste = compruebaExiste.CompruebaUsuExistente(login);    //Comprueba si ya existe ese usuario 
                    if (compruebaSiExiste.Rows.Count > 0) //si existe nos devolvera x lo menos una fila
                    {
                        banderaUsuario = true;
                    }
                    if (banderaUsuario == false)
                    {
                        lblError.Text += "No se encontro el usuario pon un usuario valido \n";
                    }
                }
                else
                {
                    lblError.Text += "El Campo Login esta vacio \n";
                }*/




                if (txtpasswordActual.Text != "")
                {
                    

                        compruebaSiEsSuContra = impUser2.CompruebaContraDeUsu(id, txtpasswordActual.Text);
                        if (compruebaSiEsSuContra.Rows.Count > 0)
                        {
                            banderaContraActual = true;
                        }
                        else
                        {
                            lblError.Text += "contraseña actual erronea";
                        }


                    
                }
                else
                {
                    lblError.Text += "Campo Contraseña Actual Vacio";
                }



                if (txtPasswordNueva.Text != "")
                {
                    if (banderaContraActual==true) {

                        banderaContrasNueva = cs.ValidarContraseñaLetrasNumerosYCaracteresRaros(txtPasswordNueva.Text);

                        if (banderaContrasNueva == true)
                        {


                        }
                        else
                        {

                            lblError.Text += "La contraseña tiene que tener minimo 8 caracteres \n un numero una minuscula una mayuscula y un \n caracter raro";
                        }
                    }

                    
                }
                else
                {
                    lblError.Text += "El Campo Contraseña nueva esta vacio \n";
                }

                if (txtRepetirPassword.Text != "")
                {

                    if (banderaContrasNueva == true)
                    {
                        if (contraNueva == repetirPasword) //comprobamos que la contraseña sea la misma
                        {
                            banderaRepetirContra = true;
                        }
                        else
                        {
                            lblError.Text += "Las contraseñas no coinciden";
                        }

                    }
                    

                }
                else
                {
                    lblError.Text += "El Campo repetir Contraseña esta vacio \n";
                }




                if (banderaContraActual == true &&
                    banderaContrasNueva == true && banderaRepetirContra == true)
                {
                    int l = impUser.UpdatePassword(id, txtpasswordActual.Text, txtPasswordNueva.Text); //nos devuelve mas de uno si todo bien

                    if (l > 0)
                    {

                        lblError.Text = "Tu contraseña se cambio correctamente";

                        //string url = "Default.aspx";
                        //Response.Redirect(url);
                    }
                    else
                    {
                        lblError.Text = "Tu contraseña temporal esta mal escrita";
                    }
                }
                else {
                    lblError.Text += "No entro";
                }









                /*
                DataTable compruebaSiExiste = compruebaExiste.CompruebaUsuExistente(login);    //Comprueba si ya existe ese usuario 
                if (compruebaSiExiste.Rows.Count > 0) //si existe nos devolvera x lo menos una fila
                {
                    if (txtpasswordActual.Text != "")
                    {
                        //Una vez visto que exite el usuario y que escribe una contraseña verificamos si es la contra del usuario
                        


                        DataTable compruebaSiEsSuContra = impUser.CompruebaContraDeUsu(login, contraAntigua);
                        if (compruebaSiEsSuContra.Rows.Count > 1)
                        {
                            

                            if (contraNueva.Length >= 8)
                            {
                                bool banderaLetrasNumerosYCaracteresRaros = cs.ValidarContraseñaLetrasNumerosYCaracteresRaros(contraNueva);
                                if (banderaLetrasNumerosYCaracteresRaros == true)
                                {


                                    if (contraNueva == repetirPasword) //comprobamos que la contraseña sea la misma
                                    {
                                        int l = impUser.UpdatePassword(login, txtpasswordActual.Text, txtPasswordNueva.Text); //nos devuelve mas de uno si todo bien

                                        if (l > 0)
                                        {

                                            lblError.Text = "Tu contraseña se cambio correctamente";
                                            //string url = "Default.aspx";
                                            //Response.Redirect(url);
                                        }
                                        else
                                        {
                                            lblError.Text = "Tu contraseña temporal esta mal escrita";
                                        }
                                    }
                                    else
                                    {
                                        lblError.Text = "Las contraseñas no coinciden";
                                    }
                                }
                                else
                                {
                                    lblError.Text = "La contraseña tiene que contener una minuscula una mayuscula un numero y un caracter raro ";
                                }

                                }
                                else
                                {
                                    lblError.Text = "La contraseña tiene que tener minimo 8 caracteres";
                                }

                        }else
                        {
                            lblError.Text = "No coinciden usuario y contraseña";
                        }



                    }
                    else
                    {
                        lblError.Text = "El campo contraseña actual esta vacia";
                    }
                    if (txtPasswordNueva.Text == "" || txtRepetirPassword.Text == "")
                    {
                        lblError.Text = "El campo contraseña Nueva vacia";
                    }
                }
                else
                {
                    lblError.Text = "No se encontro el usuario pon un usuario valido";
                 }

                */
         }
         catch (Exception ex)
         {

            throw ex;
        }






        }
    }
}