using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Otimiza.DAO;
using Otimiza.Models;
using System.IO;
using System.Drawing;

namespace Otimiza.Controllers
{
    public class VisualizarController : Controller
    {
        public ActionResult Visualizar(int id)
        {
            VeiculoDAO daoVeiculo = new VeiculoDAO();
            ViewBag.Veiculo = daoVeiculo.BuscaPorId(id);

            TipoVeiculoDAO daoTipo = new TipoVeiculoDAO();
            IList<TipoVeiculo> tipos = daoTipo.Lista();
            ViewBag.TiposVeiculo = tipos;

            return View();
        }

        public ActionResult Fotos(int id)
        {
            VeiculoDAO dao = new VeiculoDAO();
            ViewBag.Veiculo = dao.BuscaPorId(id);

            return View();
        }

        public byte[] imageToByteArray(Image imageIn)
        {
            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
            return ms.ToArray();
        }

        public Image byteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }


    }
}