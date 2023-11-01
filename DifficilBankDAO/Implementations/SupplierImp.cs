using DifficilBankDAO.Interfaces;
using DifficilBankDAO.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VeterinarySmilesDAO.Implementations;

namespace DifficilBankDAO.Implementations
{
    public class SupplierImp : BaseImpl, ISupplier
    {
        public int Delete(Supplier t)
        {
            query = @"UPDATE Supplier SET status=0,lastUpdate=CURRENT_TIMESTAMP
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
            query = @"UPDATE Supplier SET status=0,lastUpdate=CURRENT_TIMESTAMP
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





        public Supplier Get(int id)
        {
            Supplier t = null; // Creamos el objeto como null

            query = @"SELECT id,name,phone,address,email,status,registerDate,ISNULL(lastUpdate,CURRENT_TIMESTAMP)
                    from Supplier
					Where id = @id"; //hacemos un select con todos los atributos de la tabla

            SqlCommand command = CreateBasicCommand(query);
            command.Parameters.AddWithValue("@id", id);
            try
            {
                DataTable table = ExecuteDataTableCommand(command);

                if (table.Rows.Count > 0)
                {
                    t = new Supplier(int.Parse(table.Rows[0][0].ToString()), 
                        table.Rows[0][1].ToString(),
                        table.Rows[0][2].ToString(),
                        table.Rows[0][3].ToString(), 
                        table.Rows[0][4].ToString(), 
                        byte.Parse(table.Rows[0][5].ToString()), 
                        DateTime.Parse(table.Rows[0][6].ToString()),
                        DateTime.Parse(table.Rows[0][7].ToString())); //creamos el objeto previamente puesto en null y le hacemos el new para instanciar
                                                                       //y seguimos los parametros del constructor
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return t;
        }

        public int Insert(Supplier t)
        {
            query = @"INSERT INTO Supplier(name, phone, address,email,userID)
                    VALUES(@name, @phone, @address, ISNULL(@email,''),1)";

            SqlCommand command = CreateBasicCommand(query);

            command.Parameters.AddWithValue("@name", t.Name);
            command.Parameters.AddWithValue("@phone", t.Phone);
            command.Parameters.AddWithValue("@address", t.Address);
            command.Parameters.AddWithValue("@email", t.Email);


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
            query = @"SELECT id,name AS 'Nombre',phone AS 'Telefono',address AS 'Direccion',email AS 'Email'
                    FROM Supplier
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

        public int Update(Supplier t)
        {
            query = @"UPDATE Supplier SET name = @name, phone = @phone, address = @address, email = @email, userID = 1,lastUpdate = CURRENT_TIMESTAMP
                        WHERE id = @id";

            SqlCommand command = CreateBasicCommand(query);

            command.Parameters.AddWithValue("@name", t.Name);
            command.Parameters.AddWithValue("@phone", t.Phone);
            command.Parameters.AddWithValue("@address", t.Address);
            command.Parameters.AddWithValue("@email", t.Email);

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

        public int Update2(Supplier t, int id)
        {
            query = @"UPDATE Supplier SET name = @name, phone = @phone, address = @address, email = @email, userID = 1,lastUpdate = CURRENT_TIMESTAMP
                        WHERE id = @id";

            SqlCommand command = CreateBasicCommand(query);

            command.Parameters.AddWithValue("@name", t.Name);
            command.Parameters.AddWithValue("@phone", t.Phone);
            command.Parameters.AddWithValue("@address", t.Address);
            command.Parameters.AddWithValue("@email", t.Email);

            command.Parameters.AddWithValue("@id", id);

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
