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
using VeterinarySmilesDAO.Models;

namespace DifficilBankDAO.Implementations
{
    public class VeterinarianImp : BaseImpl, IVeterinarian
    {
        public void Delete2(Veterinarian t)
        {
            

            
            query = @"UPDATE VetDoctor SET status=0,lastUpdate=CURRENT_TIMESTAMP
                WHERE id=@id";

            string query2 = @"UPDATE Person SET status=0,lastUpdate=CURRENT_TIMESTAMP
                WHERE id=@id";

            List<SqlCommand> commands = Create2BasicCommand(query, query2);

            commands[0].Parameters.AddWithValue("@id", t.ID);
            commands[1].Parameters.AddWithValue("@id", t.ID);

            try
            {
                ExecuteNBasicCommand(commands);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public int Delete(Veterinarian t)
        {
            throw new NotImplementedException();
        }





            public Veterinarian Get(int id)
        {
            Veterinarian t = null;

            query = @"SELECT VD.id,P.ci,P.name,P.firstName,P.secondLastName,P.birthDate,P.gender,P.phone,P.address,VD.status,VD.registerDate,ISNULL(VD.lastUpdate,CURRENT_TIMESTAMP) AS lastUpdate,VD.VetCode,VD.specialty,VD.userID
                    FROM Person P
					INNER Join VetDoctor VD ON P.id = VD.id
                    where VD.id = @id";

            SqlCommand command = CreateBasicCommand(query);
            command.Parameters.AddWithValue("@id", id);
            try
            {
                DataTable table = ExecuteDataTableCommand(command);

                if (table.Rows.Count > 0)
                {
                    t = new Veterinarian(int.Parse(table.Rows[0][0].ToString()),
                        table.Rows[0][1].ToString(),
                        table.Rows[0][2].ToString(),
                        table.Rows[0][3].ToString(),
                        table.Rows[0][4].ToString(),
                        DateTime.Parse(table.Rows[0][5].ToString()),
                        char.Parse(table.Rows[0][6].ToString()),
                        table.Rows[0][7].ToString(),
                        table.Rows[0][8].ToString(),
                        //table.Rows[0][9].ToString(),
                        byte.Parse(table.Rows[0][9].ToString()),
                        DateTime.Parse(table.Rows[0][10].ToString()),
                        DateTime.Parse(table.Rows[0][11].ToString()), 
                        table.Rows[0][12].ToString(),
                        table.Rows[0][13].ToString(),
                        int.Parse(table.Rows[0][14].ToString()));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return t;
        }

        public void Insert(Person p, Veterinarian v)
        {


            query = @"INSERT INTO Person (ci,name,firstName,secondLastName,birthDate,gender,phone,address,userID)
                       VALUES (@ci,@name,@firstName,@secondLastName,@birthDate,@gender,@phone,@address,1)";

            string query2 = @"INSERT INTO vetDoctor(id,vetCode,specialty,userID)
                            VALUES (@id,@vetCode,@specialty,1)";


            List<SqlCommand> commands = Create2BasicCommand(query, query2);

            commands[0].Parameters.AddWithValue("@ci", p.Ci);
            commands[0].Parameters.AddWithValue("@name", p.Name);
            commands[0].Parameters.AddWithValue("@firstName", p.FirsName);
            commands[0].Parameters.AddWithValue("@secondLastName", p.SecondLastName);
            commands[0].Parameters.AddWithValue("@birthDate", p.BirtDate);
            commands[0].Parameters.AddWithValue("@gender", p.Gender);
            

            int n = int.Parse(GetGenerateIdTable("Person"));
            /*
            commands[1].Parameters.AddWithValue("@id", n);
            commands[1].Parameters.AddWithValue("@name", u.UserName);
            commands[1].Parameters.AddWithValue("@password", u.Password);
            commands[1].Parameters.AddWithValue("@role", u.Rol);
            */

            commands[1].Parameters.AddWithValue("@id", n);
            commands[1].Parameters.AddWithValue("@vetCode", v.CodVet);
            commands[1].Parameters.AddWithValue("@specialty", v.Especialty);

            try
            {
                ExecuteNBasicCommand(commands);
            }
            catch (Exception ex)
            {

                throw ex;
            }


        }

        public int Insert(Veterinarian t)
        {
            throw new NotImplementedException();
        }

        public DataTable Select()
        {
            query = @"SELECT VD.id AS 'idVet',P.ci AS 'CI',P.name AS 'Nombre',P.firstName AS 'Primer Apellido',P.secondLastName AS 'Segundo Apellido',VD.vetCode AS 'Codigo Veterinario', VD.specialty AS 'Especialidad' 
                    FROM Person P
                    INNER Join VetDoctor VD ON P.id = VD.id
                    WHERE VD.status = 1
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

        public int Update(Veterinarian t)
        {
            throw new NotImplementedException();
        }


        public void Update(Person p,Veterinarian v,int id)
        {
            query = @"UPDATE Person SET ci = @ci, name = @name, firstName = @firstName, secondLastName = @secondLastName, 
                    birthDate = @birthDate, gender = @gender, phone = @phone, address = @address,
                    lastUpdate = CURRENT_TIMESTAMP,userID=1
                    WHERE id = @idP";

            string query2 = @"UPDATE vetDoctor SET vetCode=@vetCode,specialty=@specialty,lastUpdate = CURRENT_TIMESTAMP,userID=1
                            where id = @idV";


            List<SqlCommand> commands = Create2BasicCommand(query, query2);

            commands[0].Parameters.AddWithValue("@ci", p.Ci);
            commands[0].Parameters.AddWithValue("@name", p.Name);
            commands[0].Parameters.AddWithValue("@firstName", p.FirsName);
            commands[0].Parameters.AddWithValue("@secondLastName", p.SecondLastName);
            commands[0].Parameters.AddWithValue("@birthDate", p.BirtDate);
            commands[0].Parameters.AddWithValue("@gender", p.Gender);
            

            //int n = int.Parse(GetGenerateIdTable("Person"));
            /*
            commands[1].Parameters.AddWithValue("@id", n);
            commands[1].Parameters.AddWithValue("@name", u.UserName);
            commands[1].Parameters.AddWithValue("@password", u.Password);
            commands[1].Parameters.AddWithValue("@role", u.Rol);
            */

           

            commands[1].Parameters.AddWithValue("@vetCode", v.CodVet);
            commands[1].Parameters.AddWithValue("@specialty", v.Especialty);

            commands[0].Parameters.AddWithValue("@idP", id);
            commands[1].Parameters.AddWithValue("@idV", id);

            try
            {
                ExecuteNBasicCommand(commands);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
