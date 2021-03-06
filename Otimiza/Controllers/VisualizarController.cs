﻿using System;
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

            FotoDAO daoFoto = new FotoDAO();
            IList<Foto> fotos = daoFoto.ListaFotoVeiculo(id);
            ViewBag.Foto = fotos;
            IList<String> stringFotos = new List<String>();
            if (fotos.Count > 0)
            {
                for (int i = 0; i < fotos.Count; i++)
                {
                    stringFotos.Add(Convert.ToBase64String(fotos[i].Imagem));
                }
                ViewBag.StringFoto = stringFotos;
            }

            ViewBag.Tam = fotos.Count;

            return View();
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