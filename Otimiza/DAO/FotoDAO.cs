using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Otimiza.Models;

namespace Otimiza.DAO
{
    public class FotoDAO
    {
        public void Adiciona(Foto foto)
        {
            using (var context = new EstoqueContext())
            {
                context.Fotos.Add(foto);
                context.SaveChanges();
            }
        }

        public IList<Foto> Lista()
        {
            using (var contexto = new EstoqueContext())
            {
                return contexto.Fotos.ToList();
            }
        }

        public Foto BuscaPorId(int id)
        {
            using (var contexto = new EstoqueContext())
            {
                return contexto.Fotos
                    .Where(p => p.ID == id)
                    .FirstOrDefault();
            }
        }

        public void Atualiza(Foto foto)
        {
            using (var contexto = new EstoqueContext())
            {
                contexto.Entry(foto).State = System.Data.Entity.EntityState.Modified;
                contexto.SaveChanges();
            }
        }


        public IList<Foto> ListaFotoVeiculo(int idVeiculo)
        {
            using (var contexto = new EstoqueContext())
            {
                return contexto.Fotos.Where(p => p.IdVeiculo == idVeiculo).ToList();
            }
        }

        public void Remove(int id)
        {
            using (var contexto = new EstoqueContext())
            {
                Foto foto = contexto.Fotos.Where(p => p.ID == id).FirstOrDefault();
                contexto.Fotos.Remove(foto);
                contexto.SaveChanges();
            }
        }
    }
}