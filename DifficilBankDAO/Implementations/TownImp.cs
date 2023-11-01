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
    public class TownImp : BaseImpl, ITown
    {
        public DataTable selectIDName()
        {
            query = @" SELECT id,name
                      FROM Town
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

        public DataTable selectState()
        {
            query = @" SELECT id,name
                      FROM State
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





        public DataTable selectTownSegunDep(int idDep)
        {
            query = @"Select T.id,T.name
                      FROM Town T
                      LEFT JOIN State ST ON T.idState = ST.id
                      WHERE ST.id = @id
                      ORDER BY 2";

            SqlCommand command = CreateBasicCommand(query);

            command.Parameters.AddWithValue("@id", idDep);

            try
            {
                return ExecuteDataTableCommand(command);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }



        public DataTable SelectStateMio(int c)
        {
            //query = @"SELECT DISTINCT S.id,S.name AS 'nombreMio'
            //          FROM State S 
            //          INNER JOIN Town T ON S.id = T.idState
            //          INNER JOIN AttentionPoint AP ON AP.idTown = T.id
            //          WHERE S.id = @idDep";


            query = @"SELECT S.id,S.name AS 'nombreMio'
                      FROM AttentionPoint AP
                      LEFT JOIN Town T ON AP.idTown = T.id
                      LEFT JOIN State S ON S.id = T.idState
                      WHERE AP.id = @idDep";



            SqlCommand command = CreateBasicCommand(query);

            command.Parameters.AddWithValue("@idDep", c);

            try
            {
                return ExecuteDataTableCommand(command);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        public DataTable SelectTownMio(int c)
        {
            //query = @"SELECT DISTINCT T.id,T.name AS 'nombreMio'
            //          FROM State S 
            //          INNER JOIN Town T ON S.id = T.idState
            //          INNER JOIN AttentionPoint AP ON AP.idTown = T.id
            //          WHERE T.id = @idCiudad";




            query = @"SELECT T.id,T.name AS 'nombreMio'
                      FROM AttentionPoint AP
                      LEFT JOIN Town T ON AP.idTown = T.id
                      WHERE AP.id = @idCiudad";

            SqlCommand command = CreateBasicCommand(query);

            command.Parameters.AddWithValue("@idCiudad", c);

            try
            {
                return ExecuteDataTableCommand(command);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
