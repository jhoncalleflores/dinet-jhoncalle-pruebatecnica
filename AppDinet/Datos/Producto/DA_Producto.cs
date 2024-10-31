using AppDinet.Models;
using System.Data;
using System.Data.SqlClient;

namespace AppDinet.Datos.Producto
{
    public class DA_Producto
    {

        public List<EN_Producto> Listado()
        {
            List<EN_Producto> lista = new List<EN_Producto>();
            Conexion conexion = new Conexion();

            try
            {
                using (SqlConnection cn = new SqlConnection(conexion.getCadenaSQL()))
                {
                    cn.Open();

                    SqlCommand cmd = new SqlCommand("sp_ListarProductos", cn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        EN_Producto model = new EN_Producto();
                        model.IdProducto = Convert.ToInt32(dr["IdProducto"]);
                        model.NombreProducto = dr["NombreProducto"].ToString();
                        model.Stock = Convert.ToInt32(dr["Stock"]);
                        model.Precio = Convert.ToDecimal(dr["Precio"]);

                        lista.Add(model);
                    }

                }

            }
            catch (Exception ex)
            {
                lista = new List<EN_Producto>();
            }


            return lista;
        }

        public bool AgregarProducto(EN_Producto producto)
        {
            bool rpta;

            try
            {
                var conexion = new Conexion();

                using (SqlConnection cn = new SqlConnection(conexion.getCadenaSQL()))
                {
                    cn.Open();
                    SqlCommand cmd = new SqlCommand("sp_AgregarrProducto", cn);
                    cmd.Parameters.AddWithValue("@NombreProducto", producto.NombreProducto);
                    cmd.Parameters.AddWithValue("@Stock", producto.Stock);
                    cmd.Parameters.AddWithValue("@Precio", producto.Precio);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();

                }

                rpta = true;
            }
            catch (Exception ex)
            {
                rpta = false;
            }

            return rpta;
        }

    }
}
