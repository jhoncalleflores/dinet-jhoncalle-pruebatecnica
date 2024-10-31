using DAO;
using Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio
{
    public class ProductoLN
    {
        
        public List<Producto_EN> ListadoProductos()
        {
            ProductoDAO dao = new ProductoDAO();
            List<Producto_EN> lista = new List<Producto_EN>();

            lista = dao.ListadoProductos();

            return lista;
        }

    }
}
