using Entidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace DAO
{
    public class ProductoDAO
    {
        private readonly IConfiguration configuration;
        public List<Producto_EN> ListadoProductos()
        {
            List<Producto_EN> lista = new List<Producto_EN>();
            
            try
            {

                using (SqlConnection cn = new SqlConnection(configuration.GetConnectionString("CadenaSQL")))
                {
                    cn.Open();
                    SqlCommand cmd = new SqlCommand("sp_ListarProductos", cn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        Producto_EN pro = new Producto_EN();
                        pro.IdProducto = Convert.ToInt32(dr["IdProducto"]);
                        pro.NombreProducto = dr["NombreProducto"].ToString();
                        pro.Stock = Convert.ToInt32(dr["Stock"]);
                        pro.Precio = Convert.ToDecimal(dr["Precio"]);

                        lista.Add(pro);
                    }

                }

            }
            catch (Exception ex)
            {
                throw;
            }

            return lista;
        }

    }
}
