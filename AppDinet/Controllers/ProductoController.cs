
using AppDinet.Datos.Producto;
using AppDinet.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization;

namespace AppDinet.Controllers
{
    public class ProductoController : Controller
    {

        public IActionResult Listado()
        {
            return View();
        }

        public JsonResult ListarProductos()
        {
            DA_Producto dao = new DA_Producto();
            List<EN_Producto> lista = new List<EN_Producto>();
            lista = dao.Listado();
            return Json(lista);
        }




    }
}
