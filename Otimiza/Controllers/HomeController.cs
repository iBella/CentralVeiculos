using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Otimiza.DAO;
using Otimiza.Models;

namespace Otimiza.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            VeiculoDAO dao = new VeiculoDAO();
            IList<Veiculo> veiculos = dao.Lista();
            ViewBag.Veiculos = veiculos;

            return View();
        }

        public ActionResult Curriculo()
        {
            return View();
        }

        public ActionResult CadastrarTipoVeiculo()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AdicionaTipoVeiculo(TipoVeiculo tipo)
        {
            TipoVeiculo novoTipo = new TipoVeiculo()
            {
                Nome = tipo.Nome
            };

            TipoVeiculoDAO dao = new TipoVeiculoDAO();
            dao.Adiciona(novoTipo);

            return RedirectToAction("Index", "Home");
        }
    }
}