using System.Data;
using System.Data.SqlClient;
using Asp.Connection;
using Asp.Model;

namespace Asp.Datos
{
    public class Dproducts
    {
        ConnectionDB db = new ConnectionDB();
        public async Task <List<Mproduct>> ShowProducts()
        {
            var list = new List<Mproduct>();
            using (var sql = new SqlConnection(db.cadSQL()))
            {
                using (var cmd = new SqlCommand("mostrarProductos", sql))
                {
                    await sql.OpenAsync();
                    cmd.CommandType = CommandType.StoredProcedure;
                    using(var item = await cmd.ExecuteReaderAsync())
                    {
                        while(await item.ReadAsync())
                        {
                            var mproducts = new Mproduct();
                            mproducts.descripcion = (string)item["descripcion"];
                            mproducts.id = (int)item["id"];
                            mproducts.money = (decimal)item["precio"];
                            list.Add(mproducts);

                        }
                    }
                }
            }
            return list;

        }

        public async Task IntertProducts(Mproduct parameters)
        {
            using(var sql = new SqlConnection(db.cadSQL()))
            {
                using (var cmd = new SqlCommand("insertarProductos", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("precio", parameters.money);
                    cmd.Parameters.AddWithValue("descripcion", parameters.descripcion);
                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task updateProducts(Mproduct parameters)
        {
            using(var sql = new SqlConnection(db.cadSQL()))
            {
                using(var cmd = new SqlCommand("editarProductos", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("precio", parameters.money);
                    cmd.Parameters.AddWithValue("id", parameters.id);
                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task deleteProducts(int id)
        {
            using(var sql = new SqlConnection(db.cadSQL()))
            {
                using(var cmd = new SqlCommand("eliminarProductos", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("id", id);
                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }
        
    }
}
 