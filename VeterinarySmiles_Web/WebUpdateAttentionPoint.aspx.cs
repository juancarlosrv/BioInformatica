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

namespace VeterinarySmiles_Web
{
    public partial class WebUpdateAttentionPoint : System.Web.UI.Page
    {

        AttentionPointImp impAp;
        AttentionPoint ap;


        TownImp impTown;

        ControlMio cs;

        int id;

        string valor;

        int indiceState,indiceTown;

        int indice;

        public static int indiceCiudad;

        public static int idUpdate;

        List<State> states = new List<State>();
        List<Town> towns = new List<Town>();


        protected void Page_Load(object sender, EventArgs e)
        {
            compruebaSesion();
            LoadType();
            cargaCombo();
            capturaDatosCombo();









                //selState.SelectedIndex = 5;
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

        void capturaDatosCombo()
        {
            if (!IsPostBack)
            {
                //id = int.Parse(Request.QueryString["id"]);

               

                

                try
                {
                    indiceState = int.Parse(Request.QueryString["iState"]);
                }
                catch (ArgumentNullException n)
                {

                    //indiceState = 0;
                    lblError.Text += "No llego referencia del departamento \n";

                }



                if (indiceState == 1)
                {
                    selState.SelectedIndex = 2;



                }
                if (indiceState == 6)
                {
                    selState.SelectedIndex = 7;



                }


                try
                {
                    indiceTown = int.Parse(Request.QueryString["iTown"]);

                    switch (indiceTown)
                    {
                        case 1:
                            selTown.SelectedIndex = 1;
                            break;
                       
                        case 3:
                            selTown.SelectedIndex = 3;
                            break;
                        case 4:
                            selTown.SelectedIndex = 1;
                            break;
                        case 5:
                            selTown.SelectedIndex = 2;
                            break;
                       
                    }
                }
                catch (ArgumentNullException n)
                {

                    //indiceState = 0;
                    lblError.Text += "No llego referencia de la ciudad \n";

                }


                


                








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

                

                //indiceState = int.Parse(Request.QueryString["iState"]); ;


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        void valoresCombo()
        {
            try
            {
                





            }
            catch (Exception)
            {

                throw;
            }
        }


        void Get()
        {
            try
            {
                if (!IsPostBack)
                {
                    id = int.Parse(Request.QueryString["id"]);

                    /*
                    indiceState = int.Parse(Request.QueryString["iState"]);


                    if (indiceState == 1)
                    {
                        selState.SelectedIndex = 2;



                    }
                    if (indiceState == 6)
                    {
                        selState.SelectedIndex = 7;



                    }

                    */




                    if (id > 0)
                    {
                        impAp = new AttentionPointImp();
                        ap = impAp.Get(id);
                        txtName.Text = ap.Name.ToString().Trim().Replace(@"\s+", " ");
                        txtAddress.Text = ap.Address.ToString().Trim().Replace(@"\s+", " ");
                        txtPhone.Text = ap.Phone.ToString().Trim().Replace(@"\s+", " ");
                        txtLatitude.Text = ap.Latitude.ToString().Trim().Replace(@"\s+", " ");
                        txtLongitude.Text = ap.Longitude.ToString().Trim().Replace(@"\s+", " ");
                        valoresCombo();

                        selTown.SelectedValue = ap.IdTown.ToString();

                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        void cargaCombo()
        {
            //impTown = new TownImp();
            //DataTable dt = impTown.selectState();

            //foreach (DataRow dr in dt.Rows)
            //{
            //    ListItem listItem = new ListItem(dr[1].ToString(), dr[1].ToString()); // El valor y el texto de cada opción son iguales en este ejemplo
            //    selState.Items.Add(listItem);

            //}
            //impTown = new TownImp();


            //DataTable dt2 = impTown.selectIDName();

            //foreach (DataRow dr in dt2.Rows)
            //{
            //    ListItem listItem = new ListItem(dr[1].ToString(), dr[1].ToString()); // El valor y el texto de cada opción son iguales en este ejemplo
            //    selTown.Items.Add(listItem);
            //}

            //selState.SelectedIndex = 5;

            //indice = indiceState;
            //lblError.Text = indice.ToString();

            //selState.SelectedIndex = indice;ç
            //selState.Items.Clear();
            //selTown.Items.Clear();

            impTown = new TownImp();


            DataTable dt = impTown.selectState();


            foreach (DataRow dr in dt.Rows)
            {
                ListItem listItem = new ListItem(dr[1].ToString(), dr[0].ToString()); // El valor y el texto de cada opción son iguales en este ejemplo
                selState.Items.Add(listItem);
            }


            impTown = new TownImp();


            DataTable dt2 = impTown.selectIDName();


            foreach (DataRow dr in dt2.Rows)
            {
                ListItem listItem = new ListItem(dr[1].ToString(), dr[0].ToString()); // El valor y el texto de cada opción son iguales en este ejemplo
                selTown.Items.Add(listItem);
            }


        }

        void agarraCombos(){


            DataTable dt3 = impTown.SelectStateMio(indiceState);

            DataTable dt4 = impTown.SelectTownMio(id);


            states = ConvertirDataTableAListaState(dt3);

            towns = ConvertirDataTableAListaTown(dt4);


            //int inidiceState = impTown.SelectStateMio(indiceState);

            if (states[0].Id == "Cochabamba") { 
            
                selState.SelectedIndex = 5;
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

        protected void btnSave_Click(object sender, EventArgs e)
        {



            //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert(" + selState.SelectedValue.ToString() + ")", true);

            try
            {
                lblError.Text = "";

                cs = new ControlMio();

                bool banderaNombre = false;
                bool banderaTelefono = false;
                bool banderaDireccion = false;
                bool banderaCoordenadas = false;


                if (txtName.Text != "")
                {
                    banderaNombre = cs.validarDireccionConNumeros(txtName.Text.Trim());
                    if (banderaNombre == false)
                    {
                        lblError.Text += "El nombre solo acepta letras y numeros\n";
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



                if (txtLatitude.Text == "" || txtLongitude.Text == "")
                {


                    lblError.Text += "Seleccione una un punto del mapa \n";


                }
                else
                {
                    banderaCoordenadas = true;
                }


                if (banderaNombre == true && banderaTelefono == true && banderaDireccion == true && selTown.SelectedIndex != -1
                    && banderaCoordenadas == true)
                {

                    

                    //si pasa los controles

                    impAp = new AttentionPointImp();
                    indiceCiudad = int.Parse(selTown.SelectedValue);
                    idUpdate = int.Parse(Request.QueryString["id"]);
                    ap = new AttentionPoint(idUpdate, txtName.Text, txtPhone.Text, txtAddress.Text, txtLatitude.Text, txtLongitude.Text, indiceCiudad);

                    int num = impAp.Update(ap);

                    if (num > 0)
                    {
                        string mensaje = "Se actualizo con exito";
                        lblMensaje.Text = mensaje;


                        string url = "WebAdmAttentionPoint.aspx";
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
    }
}