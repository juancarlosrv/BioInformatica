using DifficilBankDAO.Implementations;
using DifficilBankDAO.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.DynamicData;
using System.Web.UI;
using System.Web.UI.WebControls;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace VeterinarySmiles_Web
{
    public partial class WebMenu : System.Web.UI.Page
    {

        MenuMio menu;
        MenuImpl menuImpl;
        int id;

        string tipoIMC = "";


        protected void Page_Load(object sender, EventArgs e)
        {
            Select2();
        }




       


void Select2()
        {
            try
            {


                id = int.Parse(Session["userID"].ToString());



                menuImpl = new MenuImpl();
                DataTable imcDT = menuImpl.MuestraIMC(id);

                //float dato = float.Parse(imcDT.Rows[0][0]);
                int dato = Convert.ToInt32(imcDT.Rows[0][0]); // nos devulve el imc en int
                float imc = (float) dato;


                tipoIMC = ClasificarIMC(imc);

                DataTable dt = menuImpl.MuestraMenusSegunIMC(tipoIMC);


                /*
                 SELECT P.ci AS 'CI',P.name AS 'Nombre',P.firstName AS 'Primer Apellido',
                P.secondLastName AS 'Segundo Apellido',VD.vetCode AS 'Codigo Veterinario', 
                VD.specialty AS 'Especialidad' */


                DataTable table = new DataTable("Menus");
                //table.Columns.Add("ID", typeof(string));
                //table.Columns.Add("CI", typeof(string));
                table.Columns.Add("Nombre", typeof(string));
                table.Columns.Add("Descripcion", typeof(string));
                //table.Columns.Add("Segundo Apellido", typeof(string));
                //table.Columns.Add("Usuario", typeof(string));
                //table.Columns.Add("Rol", typeof(string));


                //table.Columns.Add("Acciones", typeof(string));
                //table.Columns.Add("Eliminar", typeof(string));

                foreach (DataRow dr in dt.Rows)
                {
                    table.Rows.Add(dr[0].ToString(), dr[1].ToString());
                }
                //GridData.DataSource = implSize.Select();
                gridData.DataSource = table;
                gridData.DataBind();

                /*for (int i = 0; i < gridData.Rows.Count; i++)
                {
                    string id = dt.Rows[i][0].ToString();
                    string up = " <a class='btn btn-secondary' style='background-color:#2a3547' href='WebUpdateCliente.aspx?id=" + id + "&type=U'> Actualizar  </a> ";
                    string del = " <a class='btn btn-secondary' style='background-color:#2a3547' href='WebAdmMuestraClientes.aspx?id=" + id + "&type=De' onclick='return ConfirmDelete();'> Eliminar  </a>  ";

                    gridData.Rows[i].Cells[6].Text = up;
                    gridData.Rows[i].Cells[6].Text += del;
                    gridData.Rows[i].Attributes["data-id"] = id;
                }*/
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public static int GetSingleValueFromDataTable(DataTable dataTable)
        {
            if (dataTable.Rows.Count > 0 && dataTable.Columns.Count > 0)
            {
                // Obtener el valor de la primera fila y primera columna
                return Convert.ToInt32(dataTable.Rows[0][0]);
            }
            else
            {
                // Si el DataTable está vacío, puedes manejar este caso de error de la manera que desees.
                // En este ejemplo, estamos devolviendo un valor predeterminado, pero puedes lanzar una excepción u otro enfoque según tus necesidades.
                return 0;
            }
        }







        public string ClasificarIMC(float imc)
        {
            string categoria = "";

            switch (imc)
            {
                case float imcValue when imcValue < 18.5f:
                    categoria = "Bajo Peso";
                    break;
                case float imcValue when imcValue >= 18.5f && imcValue <= 24.9f:
                    categoria = "Normal";
                    break;
                case float imcValue when imcValue >= 25f && imcValue <= 29.9f:
                    categoria = "Sobre Peso";
                    break;
                case float imcValue when imcValue > 30f:
                    categoria = "Obeso";
                    break;
            }

            return categoria;
        }




    }
}