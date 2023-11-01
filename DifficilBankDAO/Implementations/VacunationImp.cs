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
    public class VacunationImp : BaseImpl,IVacunation
    {
        public int Delete(Vacunation v)
        {
            query = @"UPDATE Vacunation SET status=0,lastUpdate=CURRENT_TIMESTAMP
                    WHERE id=@id";

            SqlCommand command = CreateBasicCommand(query);

            command.Parameters.AddWithValue("@id", v.ID);

            try
            {
                return ExecuteBasicCommand(command);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        public DataTable listPets()
        {
            query = @"SELECT id,name
                    FROM Pet
                    WHERE status = 1";

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

        public DataTable listVacs()
        {
            query = @"SELECT id,name
                    FROM vaccine
                    WHERE status = 1";

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


        public Vacunation Get(int id)
        {
            Vacunation v = null;

            query = @"SELECT id,idPet,idVaccine,date,ISNULL(description,'') As Descripcion,status,registerDate,ISNULL(lastUpdate,CURRENT_TIMESTAMP)
                    FROM Vacunation
                    where id = @id";

            SqlCommand command = CreateBasicCommand(query);
            command.Parameters.AddWithValue("@id", id);
            try
            {
                DataTable table = ExecuteDataTableCommand(command);

                if (table.Rows.Count > 0)
                {
                    v = new Vacunation(int.Parse(table.Rows[0][0].ToString()),
                                       int.Parse(table.Rows[0][1].ToString()),
                                       int.Parse(table.Rows[0][2].ToString()),
                                       DateTime.Parse(table.Rows[0][3].ToString()),
                                       table.Rows[0][4].ToString(),
                                       byte.Parse(table.Rows[0][5].ToString()),
                                       DateTime.Parse(table.Rows[0][6].ToString()),
                                       DateTime.Parse(table.Rows[0][7].ToString()));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return v;
        }

        public int Insert(Vacunation v)
        {

            query = @"INSERT INTO Vacunation(idPet,idVaccine, date, description, userID)
                    VALUES(@idPet, @idVaccine, @date,ISNULL(@description,''),1018)";



            SqlCommand command = CreateBasicCommand(query);


            command.Parameters.AddWithValue("@idPet", v.IdPet);
            command.Parameters.AddWithValue("@idVaccine", v.IdVaccine);
            command.Parameters.AddWithValue("@date", v.Date);
            command.Parameters.AddWithValue("@description", v.Description);


           
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
            query = @"SELECT Va.id,P.name AS 'Nombre Mascota',V.name AS 'Nombre Vacuna', date AS Fecha
                    FROM Vacunation Va 
                    LEFT JOIN Pet P ON  P.id = Va.idPet
                    LEFT JOIN Vaccine V ON V.id = Va.idVaccine
                    WHERE Va.status = 1
                    ORDER BY 1";

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

        public int Update(Vacunation v)
        {
            query = @"UPDATE Vacunation SET idPet = @idPet, idVaccine = @idVaccine, date = @date, description = ISNULL(@description,''),lastUpdate = CURRENT_TIMESTAMP,userID=1018
                        WHERE id = @id";
            

            SqlCommand command = CreateBasicCommand(query);


            command.Parameters.AddWithValue("@idPet", v.IdPet);
            command.Parameters.AddWithValue("@idVaccine", v.IdVaccine);
            command.Parameters.AddWithValue("@date", v.Date);
            command.Parameters.AddWithValue("@description", v.Description);

            command.Parameters.AddWithValue("@id", v.ID);

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
