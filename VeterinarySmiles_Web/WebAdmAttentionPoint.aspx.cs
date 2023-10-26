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
    public partial class WebAdmAttentionPoint : System.Web.UI.Page
    {
        
        AttentionPointImp impAp;
        AttentionPoint ap;


        TownImp impTown;

        ControlMio cs;

        int id;

        List<State> states = new List<State>();
        List<Town> towns = new List<Town>();

        public static int idTown;



        public static int indiceState, indiceTown;

        string valueTown;

        protected void Page_Load(object sender, EventArgs e)
        {
            compruebaSesion();
            Select();
            cargaCombo();
            load();
            //cargaTows();
        }


        void compruebaSesion()
        {

            if (!IsPostBack)
            {

                //lblError.Text = Session["userID"].ToString() + " no entrooooo";
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('" + Session["userID"].ToString() + " holaaaaaa')", true);

                if (Session["userID"] != null)
                {

                    // ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('"+ Session["userID"].ToString() + "')", true);

                    //lblError.Text = Session["userID"].ToString() + Session["userName"].ToString() +
                    //Session["role"].ToString();

                    if (Session["role"].ToString() == "Administrador")
                    {
                        //string urlVet = "WebMenuAdministrador.aspx";
                        //Response.Redirect(urlVet);


                        //Uri urlActual = Request.Url;
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



        public string limpia(string cadena)
        {
            string cadena2 = "";
            cadena2 = cadena.Trim();
            cadena2 = Regex.Replace(cadena, @"\s+", " ");

            return cadena2;
        }




        void Select()
        {
            try
            {
                impAp = new AttentionPointImp();    //instancias el implimentador
                DataTable dt = impAp.Select();  //en datatable capturas los datos del select
                DataTable table = new DataTable("AttentionPoint"); //creams una tabla
                table.Columns.Add("Nombre", typeof(string));
                table.Columns.Add("Telefono", typeof(string));
                table.Columns.Add("Direccion", typeof(string));
                table.Columns.Add("Latitud", typeof(string));
                table.Columns.Add("Longitud", typeof(string));
                table.Columns.Add("Ciudad", typeof(string));

                table.Columns.Add("Acciones", typeof(string));
                //table.Columns.Add("Eliminar", typeof(string));

                foreach (DataRow dr in dt.Rows)
                {
                    table.Rows.Add(dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5].ToString(), dr[6].ToString());
                }
                //GridData.DataSource = implSize.Select();
                gridData.DataSource = table;
                gridData.DataBind();

                impTown = new TownImp();

                //
                for (int i = 0; i < gridData.Rows.Count; i++)
                {
                    string id = dt.Rows[i][0].ToString();
                    
                    DataTable dt3 = impTown.SelectTownMio(int.Parse(id));
                    DataTable dt4 = impTown.SelectStateMio(int.Parse(id));

                    //indiceState = 0;
                    string idTown = dt3.Rows[0][0].ToString();
                    string idState = dt4.Rows[0][0].ToString();
                    string up = " <a class='btn btn-secondary' style='background-color:#2a3547' href='WebUpdateAttentionPoint.aspx?id=" + id + "&iTown="+ idTown + "&iState="+ idState + "&type=U'> Actualizar  </a> ";
                    string del = " <a class='btn btn-secondary' style='background-color:#2a3547' href='WebAdmAttentionPoint.aspx?id=" + id + "&type=D' onclick='return ConfirmDelete();'> Eliminar  </a>  ";


                    gridData.Rows[i].Cells[6].Text = up;
                    gridData.Rows[i].Cells[6].Text += del;
                    //gridData.Rows[i].Cells[5].Text = del;
                    gridData.Rows[i].Attributes["data-id"] = id;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        void cargaCombo()
        {

            //selState.Items.Clear();
            //selTown.Items.Clear();

            impTown = new TownImp();


            DataTable dt = impTown.selectState();


            foreach (DataRow dr in dt.Rows)
            {
                ListItem listItem = new ListItem(dr[1].ToString(), dr[0].ToString()); // El valor y el texto de cada opción son iguales en este ejemplo
                selState.Items.Add(listItem);
            }

            

            //selState



            //selTown


            impTown = new TownImp();


            DataTable dt2 = impTown.selectIDName();


            foreach (DataRow dr in dt2.Rows)
            {
               ListItem listItem = new ListItem(dr[1].ToString(), dr[0].ToString()); // El valor y el texto de cada opción son iguales en este ejemplo
              selTown.Items.Add(listItem);
            }


        }
        /*
        void cargaTows(int id)
        {
            impTown = new TownImp();


            DataTable dt2 = impTown.selectTownSegunDep(id);


            foreach (DataRow dr in dt2.Rows)
            {
                ListItem listItem = new ListItem(dr[1].ToString(), dr[0].ToString()); // El valor y el texto de cada opción son iguales en este ejemplo
                selTown.Items.Add(listItem);
            }
        }
        */

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


        void Delete()
        {
            id = int.Parse(Request.QueryString["id"]);
            if (id > 0)
            {
                try
                {
                    impAp = new AttentionPointImp();

                    // Obtener el objeto Customer antes de llamar al método Delete
                    ap = impAp.Get(id);



                    if (ap != null)
                    {
                        int n = impAp.Delete(ap);
                        Select();
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


        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                lblError.Text = "";

                cs = new ControlMio();

                bool banderaNombre = false;
                bool banderaTelefono = false;
                bool banderaDireccion = false;
                //bool banderaCorreo = false;
                bool banderaCoordenadas = false;

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


                if (selTown.SelectedIndex == -1)
                {
                    lblError.Text += "Seleccione una ciudad \n";
                }


                if (txtLatitude.Text=="" || txtLongitude.Text=="") {


                    lblError.Text += "Seleccione una un punto del mapa \n";


                }
                else
                {
                    banderaCoordenadas = true;
                }
               


                if (banderaNombre == true && banderaTelefono == true && banderaDireccion == true && selTown.SelectedIndex !=-1 && banderaCoordenadas==true
                            )
                {

                    //si pasa los controles

                    string nombreMio = limpia(txtName.Text);
                    string telefonoMio = limpia(txtPhone.Text);
                    string direccionMia = limpia(txtAddress.Text);


                    ap = new AttentionPoint(nombreMio, telefonoMio, direccionMia, txtLatitude.Text, txtLongitude.Text, int.Parse(selTown.SelectedValue));

                    impAp = new AttentionPointImp();

                    int n = impAp.Insert(ap);


                    if (n > 0)
                    {

                        Select();
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


        public static List<State> ConvertirDataTableAListaState(DataTable dataTable)
        {
            List<State> lista = new List<State>();

            foreach (DataRow row in dataTable.Rows)
            {
                State miState = new State();
                //id,ci,name,lastName,secondLastName
                miState.Id = row["id"].ToString();
                miState.Name = row["nombreMio"].ToString();
              


                // Asigna los valores de las demás propiedades según las columnas del DataTable

                lista.Add(miState);
            }

            return lista;
        }

        protected void selState_SelectedIndexChanged(object sender, EventArgs e)
        {

            indiceState = int.Parse(selState.SelectedValue);

            if (selState.SelectedIndex!=-1)
            {

                //cargaTows(indiceState);

            }


            int i = selTown.SelectedIndex;
        }

        protected void btnVerifica_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('" + selTown.SelectedIndex.ToString() + "')", true);



            ap = new AttentionPoint(txtName.Text, txtPhone.Text, txtAddress.Text, txtLatitude.Text, txtLongitude.Text, 4);

            impAp = new AttentionPointImp();

            int n = impAp.Insert(ap);


            if (n > 0)
            {

                Select();
                lblError.Text = "Inserto con exito;";
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Inserto Con exito')", true);




            }

        }

        public static List<Town> ConvertirDataTableAListaTown(DataTable dataTable)
        {
            List<Town> lista = new List<Town>();

            foreach (DataRow row in dataTable.Rows)
            {
                Town miTown = new Town();
                //id,ci,name,lastName,secondLastName
                miTown.Id = row["id"].ToString();
                miTown.Name = row["nombreMio"].ToString();



                // Asigna los valores de las demás propiedades según las columnas del DataTable

                lista.Add(miTown);
            }

            return lista;
        }

    }
}