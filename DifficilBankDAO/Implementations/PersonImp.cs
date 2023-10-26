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
    public class PersonImp : BaseImpl, IPerson
    {
        public int Delete(Person t)
        {
            query = @"UPDATE Person SET status=0,lastUpdate=CURRENT_TIMESTAMP
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

        public Person Get(int id)
        {
            Person t = null;

            query = @"SELECT id,ci,name,firstName,secondLastName,birthDate,gender,status,registerDate,ISNULL(lastUpdate,CURRENT_TIMESTAMP)
                    from Person
                    where id = @id";

            SqlCommand command = CreateBasicCommand(query);
            command.Parameters.AddWithValue("@id", id);
            try
            {
                DataTable table = ExecuteDataTableCommand(command);

                if (table.Rows.Count > 0)
                {
                    t = new Person(int.Parse(table.Rows[0][0].ToString()),
                        table.Rows[0][1].ToString(),
                        table.Rows[0][2].ToString(),
                        table.Rows[0][3].ToString(),
                        table.Rows[0][4].ToString(),
                        DateTime.Parse(table.Rows[0][5].ToString()),
                        char.Parse(table.Rows[0][6].ToString()),
                       
                        byte.Parse(table.Rows[0][7].ToString()),
                        DateTime.Parse(table.Rows[0][8].ToString()),
                        DateTime.Parse(table.Rows[0][9].ToString()));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return t;
        }

        public int Insert(Person t)
        {

            query = @"INSERT INTO Person(ci, name, firstName, secondLastName, birthDate, gender, phone, address)
                    VALUES(@ci, @name, @firstName, ISNULL(@secondLastName,''), @birthDate, @gender, @phone, @address)";

            SqlCommand command = CreateBasicCommand(query);

            command.Parameters.AddWithValue("@ci", t.Ci);
            command.Parameters.AddWithValue("@name", t.Name);
            command.Parameters.AddWithValue("@firstName", t.FirsName);
            command.Parameters.AddWithValue("@secondLastName", t.SecondLastName);
            command.Parameters.AddWithValue("@birthDate", t.BirtDate);
            command.Parameters.AddWithValue("@gender", t.Gender);
      

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
            query = @"SELECT id,name AS 'Nombre',firstName AS 'Primer Apellido',secondLastName AS 'Segundo Apellido',birthDate AS 'Fecha de Nacimiento',gender AS 'Genero',phone AS 'Telefono',address AS 'Direccion'
                    FROM person
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

        public int Update(Person t)
        {
            /*
            query = @"UPDATE Person SET ci = @ci, name = @name, firstName = @firstName, secondLastName = @secondLastName, birthDate = @birthDate, gender = @gender, phone = @phone, address = @address, lastUpdate = CURRENT_TIMESTAMP
                        WHERE id = @id";
            */

            query = @"UPDATE Person SET ci = @ci, name = @name, firstName = @firstName,
                    secondLastName = @secondLastName,
                    peso = @peso ,altura = @altura, gradoDiabetes = @gradoDiabetes,
                    gender = @gender,lastUpdate = CURRENT_TIMESTAMP
                    WHERE id = @id";


            SqlCommand command = CreateBasicCommand(query);

            command.Parameters.AddWithValue("@ci", t.Ci);
            command.Parameters.AddWithValue("@name", t.Name);
            command.Parameters.AddWithValue("@firstName", t.FirsName);
            command.Parameters.AddWithValue("@secondLastName", t.SecondLastName);
            //command.Parameters.AddWithValue("@birthDate", t.BirtDate);
            command.Parameters.AddWithValue("@gender", t.Gender);
            command.Parameters.AddWithValue("@peso", t.Peso);
            command.Parameters.AddWithValue("@altura", t.Altura);
            command.Parameters.AddWithValue("@gradoDiabetes", t.GradoDiabetes);

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



        public int Update2(int id,char genero,float peso,float altura,string gradDiabetes,float imc)
        {
            /*
            query = @"UPDATE Person SET ci = @ci, name = @name, firstName = @firstName, secondLastName = @secondLastName, birthDate = @birthDate, gender = @gender, phone = @phone, address = @address, lastUpdate = CURRENT_TIMESTAMP
                        WHERE id = @id";
            */

            query = @"UPDATE Person SET peso = @peso ,altura = @altura, gradoDiabetes = @gradoDiabetes,
                    gender = @gender,imc=@imc,lastUpdate = CURRENT_TIMESTAMP
                    WHERE id = @id";


            SqlCommand command = CreateBasicCommand(query);

            
            //command.Parameters.AddWithValue("@birthDate", t.BirtDate);
            command.Parameters.AddWithValue("@gender", genero);
            command.Parameters.AddWithValue("@peso", peso);
            command.Parameters.AddWithValue("@altura", altura);
            command.Parameters.AddWithValue("@gradoDiabetes", gradDiabetes);
            command.Parameters.AddWithValue("@imc", imc);

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
