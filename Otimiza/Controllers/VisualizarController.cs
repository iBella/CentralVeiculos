using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Otimiza.DAO;
using Otimiza.Models;

namespace Otimiza.Controllers
{
    public class VisualizarController : Controller
    {
        public ActionResult Visualizar(int id)
        {
            VeiculoDAO dao = new VeiculoDAO();
            ViewBag.Veiculo = dao.BuscaPorId(id);
            
            return View();
        }
    }
}