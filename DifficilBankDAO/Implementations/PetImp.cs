
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VeterinarySmilesDAO.Interfaces;
using VeterinarySmilesDAO.Models;

namespace VeterinarySmilesDAO.Implementations
{
    public class PetImpl : BaseImpl, IPet
    {
        public int Delete(Pet t)
        {
            query = @"UPDATE Pet SET status=0,lastUpdate=CURRENT_TIMESTAMP
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

        public Pet Get(int id)
        {
            Pet t = null;

            query = @"SELECT id,name,birthDate,weight,breed,colour,status,registerDate,ISNULL(lastUpdate,CURRENT_TIMESTAMP)
                    from Pet
                    where id = @id";

            SqlCommand command = CreateBasicCommand(query);
            command.Parameters.AddWithValue("@id", id);
            try
            {
                DataTable table = ExecuteDataTableCommand(command);

                if (table.Rows.Count > 0)
                {
                    t = new Pet(int.Parse(table.Rows[0][0].ToString()), table.Rows[0][1].ToString(), DateTime.Parse(table.Rows[0][2].ToString()), double.Parse(table.Rows[0][3].ToString()), table.Rows[0][4].ToString(), table.Rows[0][5].ToString(), byte.Parse(table.Rows[0][6].ToString()), DateTime.Parse(table.Rows[0][7].ToString()), DateTime.Parse(table.Rows[0][8].ToString()));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return t;
        }
        public int Insert(Pet t)
        {
            query = @"INSERT INTO Pet (name,birthDate,weight,breed,colour)
                    VALUES(@name,@birtDate,@weigth,@breed,@color)";

            SqlCommand command = CreateBasicCommand(query);

            command.Parameters.AddWithValue("@name", t.Name);
            command.Parameters.AddWithValue("@birtDate", t.BirtDate);
            command.Parameters.AddWithValue("@weigth", t.Weigth);
            command.Parameters.AddWithValue("@breed", t.Breed);
            command.Parameters.AddWithValue("@color", t.Color);

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
            query = @"SELECT id,name 'Nombre',birthDate AS 'Cumpleaños',weight AS 'Peso',breed AS 'Raza',colour AS 'Color'
                    FROM Pet
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

        public int Update(Pet t)
        {
            query = @"UPDATE Pet SET name=@name,birthDate=@birtDate,weight=@weigth,breed=@breed,colour=@color,lastUpdate=CURRENT_TIMESTAMP
                    WHERE id=@id";

            SqlCommand command = CreateBasicCommand(query);

            command.Parameters.AddWithValue("@name", t.Name);
            command.Parameters.AddWithValue("@birtDate", t.BirtDate);
            command.Parameters.AddWithValue("@weigth", t.Weigth);
            command.Parameters.AddWithValue("@breed", t.Breed);
            command.Parameters.AddWithValue("@color", t.Color);

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

        public int Update(string name,DateTime bt,double w,string b,string color,int id)
        {
            query = @"UPDATE Pet SET name=@name,birthDate=@birtDate,weight=@weigth,breed=@breed,colour=@color,lastUpdate=CURRENT_TIMESTAMP
                    WHERE id=@id";

            SqlCommand command = CreateBasicCommand(query);

            command.Parameters.AddWithValue("@name", name);
            command.Parameters.AddWithValue("@birtDate", bt);
            command.Parameters.AddWithValue("@weigth", w);
            command.Parameters.AddWithValue("@breed", b);
            command.Parameters.AddWithValue("@color", color);

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
