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

        [HttpPost]
        public ActionResult Adiciona(Veiculo veiculo, String [] fotos)
        {
            Veiculo novoVeiculo = new Veiculo()
            {
                Placa = veiculo.Placa,
                NomeTipo = veiculo.NomeTipo,
                Proprietario = veiculo.Proprietario
            };

            VeiculoDAO dao = new VeiculoDAO();
            dao.Adiciona(novoVeiculo);

            for (int i = 0; i < fotos.Length; i++) {
                Foto novaFoto = new Foto()
                {
                    Nome = fotos[i],
                    IdVeiculo = novoVeiculo.ID
                };

                FotoDAO daoFoto = new FotoDAO();
                daoFoto.Adiciona(novaFoto);
            }

            return RedirectToAction("Index","Home");
        }

        [HttpPost]
        public ActionResult Atualiza(Veiculo veiculo)
        {
            Veiculo atualizaVeiculo = new Veiculo()
            {
                ID = veiculo.ID,
                Placa = veiculo.Placa,
                NomeTipo = veiculo.NomeTipo,
                TipoVeiculo = veiculo.TipoVeiculo,
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

        public byte[] ImageToByteArray(Image imageIn)
        {
            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
            return ms.ToArray();
        }

        public Image ByteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }
    }
}