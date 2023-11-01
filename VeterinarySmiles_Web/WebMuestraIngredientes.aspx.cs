using DifficilBankDAO.Implementations;
using DifficilBankDAO.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VeterinarySmiles_Web
{
    public partial class WebMuestraIngredientes : System.Web.UI.Page
    {

        Plato p;
        PlatoImpl impPlato;

        int id;

        DataTable tablaMuestraIngredientes;


        protected void Page_Load(object sender, EventArgs e)
        {
            compruebaSesion();
            capturaId();
            muestraIngredientes();
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

        void muestraIngredientes()
        {
            try
            {
                if (id > 0)
                {
                    impPlato = new PlatoImpl();

                    tablaMuestraIngredientes = impPlato.SelectIngredientesSeleccionado(id);



                    DataTable table = new DataTable("Ingredientes");

                    table.Columns.Add("Nombre", typeof(string));
                    table.Columns.Add("Tipo de Alimento", typeof(string));        
                    table.Columns.Add("Calorias (g)", typeof(string));
                    table.Columns.Add("Proteina (g)", typeof(string));
                    table.Columns.Add("Grasa (g)", typeof(string));
                    table.Columns.Add("Porcentaje de Azucar %", typeof(string));


                    foreach (DataRow dr in tablaMuestraIngredientes.Rows)
                    {
                        table.Rows.Add(dr[1].ToString(), dr[2].ToString(),
                                       dr[3].ToString(), dr[4].ToString(),
                                       dr[5].ToString(), dr[6].ToString());
                    }


                    gridData.DataSource = table;
                    gridData.DataBind();

                    /*
                    for (int i = 0; i < gridData.Rows.Count; i++)
                    {
                        string id = tablaMuestraPlatos.Rows[i][0].ToString();
                        string detallePlatos = " <a class='btn btn-secondary' style='background-color:#2a3547' href='WebMuestraIngredientes.aspx?id=" + id + "'> VerIngredientes  </a> ";
                        //string del = " <a class='btn btn-secondary' style='background-color:#2a3547' href='WebAdmMuestraClientes.aspx?id=" + id + "&type=De' onclick='return ConfirmDelete();'> Eliminar  </a>  ";

                        gridData.Rows[i].Cells[7].Text = detallePlatos;
                        //gridData.Rows[i].Cells[6].Text += del;
                        gridData.Rows[i].Attributes["data-id"] = id;
                    }
                    */






                }
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}