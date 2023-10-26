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
using System.Xml.Linq;
using VeterinarySmilesDAO.Models;

namespace VeterinarySmiles_Web
{
    public partial class WebAdmVeterinaryDoctor : System.Web.UI.Page
    {

        Person p;
        Veterinarian v;

        PersonImp impPerson;
        VeterinarianImp impVet;

        ControlMio cs;

        int id;
        //Person

        protected void Page_Load(object sender, EventArgs e)
        {
            compruebaSesion();
            load();
            Select2();
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



        public string limpia(string cadena)
        {
            string cadena2 = "";
            cadena2 = cadena.Trim();
            cadena2 = Regex.Replace(cadena, @"\s+", " ");

            return cadena2;
        }


        protected void btnInsert_Click(object sender, EventArgs e)
        {



            
            /*
            if (n > 0)
            {
                Select2();

            }
            */
            try
            {
                /*
                p.Ci = txtCI.Text;
                p.Name = txtName.Text;
                p.FirsName = txtLastName.Text;
                p.SecondLastName = txtSecondLastName.Text;
                p.BirtDate = DateTime.Parse(txtBirthDate.Text);
                p.Gender = char.Parse(selGender.SelectedValue);
                //cbGenero.Text = cl.Gender.ite;
                p.Address = txtAddress.Text;
                p.Phone = txtPhone.Text;

                v.CodVet = txtCodigoVet.Text;
                v.Especialty = txtEspeciality.Text;
                */

                lblError.Text = "";

                cs = new ControlMio();

                bool banderaCi = false;
                bool banderaNombre = false;
                bool banderaApellidoPaterno = false;
                bool banderaTelefono = false;
                bool banderaDireccion = false;
                bool banderaFecha = false;

                bool banderaCodvet = false;
                bool banderaEspecialtys = false;
                

                if (txtCI.Text != "")
                {
                    string ciMio = limpia(txtCI.Text);
                    banderaCi = cs.ValidarNumeroCi7(ciMio);
                    if (banderaCi == false)
                    {
                        lblError.Text += "Tipo formato ci 9999999 ó 9999999-1K \n";
                    }
                }
                else
                {
                    lblError.Text += "El Campo CI esta vacio \n";
                }
                if (txtName.Text != "")
                {
                    string nombreMio = limpia(txtName.Text);
                    banderaNombre = cs.ValidarTextoConÑSinEspacios(nombreMio);
                    if (banderaNombre == false)
                    {
                        lblError.Text += "El nombre solo acepta letras sin espacios al principio ni \n al final ni mas de uno entre medias \n";
                    }
                }
                else
                {
                    lblError.Text += "El Campo Nombre esta vacio \n";
                }
                if (txtLastName.Text != "")
                {
                    string apellidoMio = limpia(txtLastName.Text);
                    banderaApellidoPaterno = cs.ValidarTextoConÑSinEspacios(apellidoMio);
                    if (banderaApellidoPaterno == false)
                    {
                        lblError.Text += "El Apellido paterno solo acepta letras sin espacios al \n principio ni al final ni mas de uno entre medias \n";
                    }
                }
                else
                {
                    lblError.Text += "El Campo Primer Apellido esta vacio \n";
                }

                if (txtBirthDate.Text != "")
                {
                    banderaFecha = cs.CompruebaFecha(DateTime.Parse(txtBirthDate.Text));
                    if (banderaFecha == false)
                    {
                        lblError.Text += "Ingrese fecha Valida de mas de 25 años\n";
                    }
                }
                else
                {
                    lblError.Text += "El Campo fecha nacimiento esta vacio \n";
                }
                if (selGender.SelectedIndex == -1)
                {
                    lblError.Text += "Seleccione un Genero \n";
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
                if (txtCodigoVet.Text != "")
                {

                    string codigoMio = limpia(txtAddress.Text);
                    banderaCodvet = cs.validarDireccionConNumeros(codigoMio);
                    if (banderaCodvet == false)
                    {
                        lblError.Text += "El codigo de veterinario solo acepta letras y numeros \n";
                    }
                }
                else
                {
                    lblError.Text += "El Campo Codigo Veterinario esta vacio \n";
                }
                if (txtEspeciality.Text != "")
                {

                    string especialidadMia = limpia(txtAddress.Text);
                    banderaEspecialtys = cs.validarDireccionConNumeros(especialidadMia);
                    if (banderaEspecialtys == false)
                    {
                        lblError.Text += "La especialidad solo acepta letras y numeros \n";
                    }
                }
                else
                {
                    lblError.Text += "El Campo especialidad esta vacio \n";
                }

                if (banderaCi == true && banderaNombre == true && banderaApellidoPaterno == true &&
                    banderaFecha == true && banderaTelefono == true && banderaDireccion == true &&
                    banderaCodvet==true && banderaEspecialtys==true)
                {

                    //si pasa los controles

                    string ciMio = limpia(txtCI.Text);
                    string nombreMio = limpia(txtName.Text);
                    string apellidoMio = limpia(txtLastName.Text);
                    string apellidoMat = limpia(txtSecondLastName.Text);
                    string telefonoMio = limpia(txtPhone.Text);
                    string direccionMia = limpia(txtAddress.Text);
                    string codigoMio = limpia(txtCodigoVet.Text);
                    string especialidadMia = limpia(txtEspeciality.Text);




                    Person p = new Person(ciMio, nombreMio, apellidoMio, apellidoMat, DateTime.Parse(txtBirthDate.Text), Char.Parse(selGender.SelectedValue), telefonoMio);

                    Veterinarian v = new Veterinarian(codigoMio, especialidadMia);


                    VeterinarianImp impuser = new VeterinarianImp();
                    impuser.Insert(p, v);


                    Select2();

                    lblError.Text = "Inserto con exito";
                }
            }
            catch (Exception ex)
            {

                //lblError.Text="";
            }

        }


        void Select2()
        {
            try
            {
                impVet = new VeterinarianImp();
                DataTable dt = impVet.Select();

                /*
                 SELECT P.ci AS 'CI',P.name AS 'Nombre',P.firstName AS 'Primer Apellido',
                P.secondLastName AS 'Segundo Apellido',VD.vetCode AS 'Codigo Veterinario', 
                VD.specialty AS 'Especialidad' */


                DataTable table = new DataTable("Veterian");
                //table.Columns.Add("ID", typeof(string));
                table.Columns.Add("CI", typeof(string));
                table.Columns.Add("Nombre", typeof(string));
                table.Columns.Add("Primer Apellido", typeof(string));
                table.Columns.Add("Segundo Apellido", typeof(string));
                table.Columns.Add("Codigo Veterinario", typeof(string));
                table.Columns.Add("Especialidad", typeof(string));


                table.Columns.Add("Acciones", typeof(string));
                //table.Columns.Add("Eliminar", typeof(string));

                foreach (DataRow dr in dt.Rows)
                {
                    table.Rows.Add(dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5].ToString(), dr[6].ToString());
                }
                //GridData.DataSource = implSize.Select();
                gridData.DataSource = table;
                gridData.DataBind();

                for (int i = 0; i < gridData.Rows.Count; i++)
                {
                    string id = dt.Rows[i][0].ToString();
                    string up = " <a class='btn btn-secondary' style='background-color:#2a3547' href='WebUpdateVeterinaryDoctor.aspx?id=" + id + "&type=U'> Actualizar  </a> ";
                    string del = " <a class='btn btn-secondary' style='background-color:#2a3547' href='WebAdmVeterinaryDoctor.aspx?id=" + id + "&type=De' onclick='return ConfirmDelete();'> Eliminar  </a>  ";

                    gridData.Rows[i].Cells[6].Text = up;
                    gridData.Rows[i].Cells[6].Text += del;
                    gridData.Rows[i].Attributes["data-id"] = id;
                }
            }
            catch (Exception ex)
            {
                throw ex;
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
                    //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Inserto Con exito')", true);
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

            //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('"+id.ToString()+"')", true);
            
            if (id > 0)
            {
                
                try
                {
                    impVet = new VeterinarianImp();

                    v = impVet.Get(id);
                    //lblError.Text = " no Nulooooooooooooo";
                    if (v != null)
                    {
                        impVet.Delete2(v);
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

        
    }
}