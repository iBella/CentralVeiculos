using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Otimiza.DAO;
using Otimiza.Models;

namespace Otimiza.Controllers
{
    public class CadastroController : Controller
    {
        public ActionResult Cadastro()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Adiciona(Veiculo veiculo)
        {
            Veiculo novoVeiculo = new Veiculo()
            {
                Placa = veiculo.Placa,
                Tipo = veiculo.Tipo,
                Proprietario = veiculo.Proprietario,
                Fotos = veiculo.Fotos
            };

            VeiculoDAO dao = new VeiculoDAO();
            dao.Adiciona(novoVeiculo);

            return RedirectToAction("Index","Home");
        }

        [HttpPost]
        public ActionResult Atualiza(Veiculo veiculo)
        {
            Veiculo atualizaVeiculo = new Veiculo()
            {
                ID = veiculo.ID,
                Placa = veiculo.Placa,
                Tipo = veiculo.Tipo,
                Proprietario = veiculo.Proprietario,
                Fotos = veiculo.Fotos
            };

            VeiculoDAO dao = new VeiculoDAO();
            dao.Atualiza(atualizaVeiculo);

            return RedirectToAction("Index", "Home");
        }

        public ActionResult Remove(int id)
        {
            VeiculoDAO dao = new VeiculoDAO();
            dao.Remove(id);

            return RedirectToAction("Index", "Home");
        }
    }
}