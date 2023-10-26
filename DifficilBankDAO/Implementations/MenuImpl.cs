using DifficilBankDAO.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VeterinarySmilesDAO.Implementations;

namespace DifficilBankDAO.Implementations
{
    public class MenuImpl : BaseImpl
    {


        public int Delete(MenuMio m)
        {
            query = @"UPDATE menu SET status=0
                      WHERE id=@id";
            SqlCommand command = CreateBasicCommand(query);
            command.Parameters.AddWithValue("@id", m.Id);
            try
            {
                return ExecuteBasicCommand(command);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public int Delete(int t)
        {
            query = @"UPDATE Menu SET status=0
                      WHERE id=@id";
            SqlCommand command = CreateBasicCommand(query);
            command.Parameters.AddWithValue("@id", t);
            try
            {
                return ExecuteBasicCommand(command);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public MenuMio Get(int id)
        {
            MenuMio m = null;
            query = @"SELECT id, nombre,descripcion,tipoMenu
                      FROM Menu
                      WHERE id=@id";
            SqlCommand command = CreateBasicCommand(query);
            command.Parameters.AddWithValue("@id", id);

            try
            {
                DataTable table = ExecuteDataTableCommand(command);
                if (table.Rows.Count > 0)
                {
                    m = new MenuMio(byte.Parse(table.Rows[0][0].ToString()), table.Rows[0][1].ToString(), table.Rows[0][2].ToString(), table.Rows[0][3].ToString());

                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return m;
        }

        public int Insert(MenuMio t)
        {
            query = @"INSERT INTO Menu(nombre,descripcion,tipoMenu)
                      VALUES(@nombre,@descripcion,@tipoMenu)";

            SqlCommand command = CreateBasicCommand(query);
            command.Parameters.AddWithValue("@nombre", t.Nombre);
            command.Parameters.AddWithValue("@descripcion", t.Descripcion);
            command.Parameters.AddWithValue("@tipoMenu", t.TipoMenu);

            //command.Parameters.AddWithValue("@size", t.Size);

            try
            {
                return ExecuteBasicCommand(command);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public DataTable Select()
        {
            query = @"SELECT id, nombre AS Nombre, descripcion AS Descripcion, tipoMenu as 'Tipo de Menu'
                        FROM Menu
                        where status=1";
            SqlCommand command = CreateBasicCommand(query);

            try
            {
                return ExecuteDataTableCommand(command);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }





        public DataTable MuestraMenusSegunIMC(string imc)
        {
            query = @"SELECT P.nombre, P.descripcion
                    FROM Menu M
                    INNER JOIN Plato P ON P.idMenu= M.id
                    WHERE M.tipoMenu = @tipoMenuIMC";
            SqlCommand command = CreateBasicCommand(query);

            command.Parameters.AddWithValue("@tipoMenuIMC", imc);

            try
            {
                return ExecuteDataTableCommand(command);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //SELECT id,imc from Person Where id = @id;

        
        public DataTable MuestraIMC(int id)
        {
            query = @"SELECT imc from Person Where id = @id";
            SqlCommand command = CreateBasicCommand(query);

            command.Parameters.AddWithValue("@id", id);

            try
            {
                return ExecuteDataTableCommand(command);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        


        /*
        public float MuestraIMC(int id)
        {
            float imc = 0.0f; // Valor predeterminado en caso de error.

            //using (SqlConnection connection = new SqlConnection(connectionString))

            {
                //connection.Open(); // Abre la conexión.


                
                string query = "SELECT imc FROM Person WHERE id = @id";

                SqlCommand command = CreateBasicCommand(query);

                command.Parameters.AddWithValue("@id", id);

                try
                {
                    // Ejecutar la consulta y obtener el valor IMC.
                    var result = command.ExecuteScalar();

                    

                    if (result != null && result != DBNull.Value)
                    {
                        imc = Convert.ToSingle(result);
                    }
                }
                catch (Exception ex)
                {
                    // Manejo de errores, como registro de excepciones.
                    // Puedes personalizar cómo manejas los errores aquí.
                }
            } // La conexión se cerrará automáticamente cuando salgas del bloque "using".

            return imc;
        }
        */





        public DataTable SelectLikeNameMenu(string name)
        {
            throw new NotImplementedException();
        }

        public int Update(MenuMio m)
        {
            query = @"UPDATE Menu SET descripcion=@descripcion, nombre=@nombre, tipoMenu=@tipoMenu
                      WHERE id=@id";
            SqlCommand command = CreateBasicCommand(query);
            command.Parameters.AddWithValue("@nombre", m.Nombre);
            command.Parameters.AddWithValue("@descripcion", m.Descripcion);
            command.Parameters.AddWithValue("@tipoMenu", m.TipoMenu);
            command.Parameters.AddWithValue("@id", m.Id);
            try
            {
                return ExecuteBasicCommand(command);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }



    }
}
