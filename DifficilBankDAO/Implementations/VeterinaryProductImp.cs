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
    public class VeterinaryProductImp : BaseImpl
    {

        public int Delete(VeterinaryProduct vp)
        {
            query = @"UPDATE VeterinaryProduct SET status=0,lastUpdate=CURRENT_TIMESTAMP
                    WHERE id=@id";

            SqlCommand command = CreateBasicCommand(query);

            command.Parameters.AddWithValue("@id", vp.ID);

            try
            {
                return ExecuteBasicCommand(command);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public VeterinaryProduct Get(int id)
        {
            VeterinaryProduct t = null;

            query = @"SELECT id,name,stock,price,idTypeProduct,idSupplier,status,registerDate,ISNULL(lastUpdate,CURRENT_TIMESTAMP)
                    from VeterinaryProduct
                    where id = @id";

            SqlCommand command = CreateBasicCommand(query);
            command.Parameters.AddWithValue("@id", id);
            try
            {
                DataTable table = ExecuteDataTableCommand(command);

                if (table.Rows.Count > 0)
                {
                    t = new VeterinaryProduct(int.Parse(table.Rows[0][0].ToString()),
                                       table.Rows[0][1].ToString(),
                                       int.Parse(table.Rows[0][2].ToString()),
                                       double.Parse(table.Rows[0][3].ToString()),
                                       int.Parse(table.Rows[0][4].ToString()),
                                       int.Parse(table.Rows[0][5].ToString()),
                                       byte.Parse(table.Rows[0][6].ToString()),
                                       DateTime.Parse(table.Rows[0][7].ToString()),
                                       DateTime.Parse(table.Rows[0][8].ToString()));
                }
            }
            
            catch (Exception ex)
            {
                throw ex;
            }
            return t;
        }

        public int Insert(VeterinaryProduct t)
        {

            query = @"INSERT INTO VeterinaryProduct(name, stock, price, idTypeProduct,idSupplier, userID)
                    VALUES(@name, @stock, @price, @idTypeProduct, @idSupplier, 1018)";




            SqlCommand command = CreateBasicCommand(query);

            command.Parameters.AddWithValue("@name", t.Name);
            command.Parameters.AddWithValue("@stock", t.Stock);
            command.Parameters.AddWithValue("@price", t.Price);
            command.Parameters.AddWithValue("@idTypeProduct", t.IdTypeProduct);
            command.Parameters.AddWithValue("@idSupplier", t.IdSupplier);


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
            query = @"SELECT vp.id,vp.name AS 'Nombre',vp.price AS 'Precio', vp.stock AS 'Stock' , tp.name AS 'Tipo de Producto',s.name AS 'Proveedor'
		              FROM VeterinaryProduct vp
		              LEFT JOIN TypeProduct tp ON vp.idTypeProduct = tp.id
		              LEFT JOIN Supplier s ON vp.idSupplier = s.id
                      WHERE vp.status = 1
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

        public int Update(VeterinaryProduct t)
        {
            query = @"UPDATE VeterinaryProduct SET name = @name, stock = @stock, price = @price, idTypeProduct = @idTypeProduct, idSupplier= @idSupplier, lastUpdate = CURRENT_TIMESTAMP
                        WHERE id = @id";

            SqlCommand command = CreateBasicCommand(query);


            command.Parameters.AddWithValue("@name", t.Name);
            command.Parameters.AddWithValue("@stock", t.Stock);
            command.Parameters.AddWithValue("@price", t.Price);
            command.Parameters.AddWithValue("@idTypeProduct", t.IdTypeProduct);
            command.Parameters.AddWithValue("@idSupplier", t.IdSupplier);

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

        public DataTable listTypeProduct()
        {
            query = @"SELECT id,name
                    FROM TypeProduct
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

        public DataTable listSupplier()
        {
            query = @"SELECT id,name
                    FROM Supplier
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



    }
}
