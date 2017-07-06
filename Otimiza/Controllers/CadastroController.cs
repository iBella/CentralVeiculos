using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Otimiza.DAO;
using Otimiza.Models;
using System.Drawing;
using System.IO;

namespace Otimiza.Controllers
{
    public class CadastroController : Controller
    {
        public ActionResult Cadastro()
        {
            TipoVeiculoDAO dao = new TipoVeiculoDAO();
            IList<TipoVeiculo> tipos = dao.Lista();
            ViewBag.TiposVeiculo = tipos;

            return View();
        }
        
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Adiciona(FormCollection f, Veiculo veiculo) {

            Veiculo novoVeiculo = new Veiculo()
            {
                Placa = veiculo.Placa,
                NomeTipo = veiculo.NomeTipo,
                Proprietario = veiculo.Proprietario
            };

            VeiculoDAO dao = new VeiculoDAO();
            dao.Adiciona(novoVeiculo);

            for (int i = 0; i < Request.Files.Count; i++)
            {
                Foto novaFoto = new Foto()
                {
                    Nome = Request.Files[i].FileName,
                    IdVeiculo = novoVeiculo.ID
                };

                if (Request.Files.Count > 0 && Request.Files[i].FileName != "")
                {
                    int tamanho = (int)Request.Files[i].InputStream.Length;
                    byte[] arq = new byte[tamanho];
                    Request.Files[i].InputStream.Read(arq, 0, tamanho);
                    novaFoto.Imagem = arq;
                }

                FotoDAO daoFoto = new FotoDAO();
                daoFoto.Adiciona(novaFoto);
            }

            return RedirectToAction("Index","Home");
        }

        [HttpPost]
        public ActionResult Atualiza(Veiculo veiculo)
        {
            VeiculoDAO dao = new VeiculoDAO();
            dao.Atualiza(veiculo);

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
 