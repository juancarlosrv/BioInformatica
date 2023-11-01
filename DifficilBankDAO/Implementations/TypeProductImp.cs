using DifficilBankDAO.Interfaces;
using DifficilBankDAO.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using VeterinarySmilesDAO.Implementations;

namespace DifficilBankDAO.Implementations
{
    public class TypeProductImp : BaseImpl, ITypeProduct
    {
        public int Delete(TypeProduct t)
        {
            query = @"UPDATE TypeProduct SET status=0,lastUpdate=CURRENT_TIMESTAMP
                    WHERE id=@id";

            SqlCommand command = CreateBasicCommand(query);

            command.Parameters.AddWithValue("@id", t.ID);

            try
            {
                return ExecuteBasicCommand(command);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public int Delete2(int t)
        {
            query = @"UPDATE TypeProduct SET status=0,lastUpdate=CURRENT_TIMESTAMP
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

        public TypeProduct Get(int id)
        {
            TypeProduct t = null; // Creamos el objeto como null

            query = @"SELECT id,name,description,status,registerDate,ISNULL(lastUpdate,CURRENT_TIMESTAMP)
                    from TypeProduct
					Where id = @id"; //hacemos un select con todos los atributos de la tabla

            SqlCommand command = CreateBasicCommand(query);
            command.Parameters.AddWithValue("@id", id);
            try
            {
                DataTable table = ExecuteDataTableCommand(command);

                if (table.Rows.Count > 0)
                {
                    t = new TypeProduct(int.Parse(table.Rows[0][0].ToString()),
                        table.Rows[0][1].ToString(),
                        table.Rows[0][2].ToString(),
                        byte.Parse(table.Rows[0][3].ToString()),
                        DateTime.Parse(table.Rows[0][4].ToString()),
                        DateTime.Parse(table.Rows[0][5].ToString())); //creamos el objeto previamente puesto en null y le hacemos el new para instanciar
                                                                      //y seguimos los parametros del constructor
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return t;
        }

        public int Insert(TypeProduct t)
        {
            query = @"INSERT INTO TypeProduct(name, description,userID)
                    VALUES(@name,ISNULL(@description,''),1)";

            SqlCommand command = CreateBasicCommand(query);

            command.Parameters.AddWithValue("@name", t.Name);
            command.Parameters.AddWithValue("@description", t.Description);



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
            query = @"SELECT id,name AS 'Nombre',description AS 'Descripcion'
                    FROM TypeProduct
                    WHERE status = 1
                    ORDER BY 2";

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

        public int Update(TypeProduct t)
        {
            query = @"UPDATE TypeProduct SET name = @name, description = @description,userID = 1,lastUpdate = CURRENT_TIMESTAMP
                        WHERE id = @id";

            SqlCommand command = CreateBasicCommand(query);

            command.Parameters.AddWithValue("@name", t.Name);
            command.Parameters.AddWithValue("@description", t.Description);

            command.Parameters.AddWithValue("@id", t.ID);

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
