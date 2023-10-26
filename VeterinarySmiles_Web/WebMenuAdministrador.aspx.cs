using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VeterinarySmiles_Web
{
    public partial class WebMenuAdministrador : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            xd();
        }

        void xd()
        {

            if (!IsPostBack)
            {

                if (Session["userID"]!=null) {

                    // ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('"+ Session["userID"].ToString() + "')", true);

                    //lblError.Text= Session["userID"].ToString() + Session["userName"].ToString()+ 
                    //Session["role"].ToString() ;


                    lblError.Text = "Bienvenido " + Session["userName"].ToString() + " con rol " + Session["role"].ToString();

                    if (Session["role"].ToString() == "Administrador")
                    {
                        //string urlVet = "WebMenuAdministrador.aspx";
                        //Response.Redirect(urlVet);


                        //Uri urlActual = Request.Url;


                    }
                    else{
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



    }
}