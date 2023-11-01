using DifficilBankDAO.Implementations;
using DifficilBankDAO.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace VeterinarySmiles_Web
{
    public partial class WebMuestraPlato : System.Web.UI.Page
    {


        Plato p;
        PlatoImpl impPlato;

        int id;

        DataTable tablaMuestraPlatos;

        protected void Page_Load(object sender, EventArgs e)
        {
            compruebaSesion();
            capturaId();
            muestraPlatos();

        }


        void capturaId()
        {
            if (!IsPostBack)
            {
                id = int.Parse(Request.QueryString["id"]);
            }
        }

        void compruebaSesion()
        {

            if (!IsPostBack)
            {
                if (Session["userID"] != null)
                {
                    if (Session["role"].ToString() == "Cliente")
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

        void muestraPlatos()
        {
            try
            {
                if (id > 0)
                {
                    impPlato = new PlatoImpl();

                    tablaMuestraPlatos = impPlato.SelectPlatosSeleccionado(id);



                    DataTable table = new DataTable("Platos");

                    table.Columns.Add("Nombre", typeof(string));
                    table.Columns.Add("Descripcion", typeof(string));

                    table.Columns.Add(" ", typeof(string));


                    foreach (DataRow dr in tablaMuestraPlatos.Rows)
                    {
                        table.Rows.Add(dr[1].ToString(), dr[2].ToString());
                    }






                    gridData.DataSource = table;
                    gridData.DataBind();


                    for (int i = 0; i < gridData.Rows.Count; i++)
                    {
                        string id = tablaMuestraPlatos.Rows[i][0].ToString();
                        string detallePlatos = " <a class='btn btn-secondary' style='background-color:#2a3547' href='WebMuestraIngredientes.aspx?id=" + id + "'> VerIngredientes  </a> ";
                        //string del = " <a class='btn btn-secondary' style='background-color:#2a3547' href='WebAdmMuestraClientes.aspx?id=" + id + "&type=De' onclick='return ConfirmDelete();'> Eliminar  </a>  ";

                        gridData.Rows[i].Cells[2].Text = detallePlatos;
                        //gridData.Rows[i].Cells[6].Text += del;
                        gridData.Rows[i].Attributes["data-id"] = id;
                    }







                }
            }
            catch (Exception)
            {

                throw;
            }
            
        }






    }
}