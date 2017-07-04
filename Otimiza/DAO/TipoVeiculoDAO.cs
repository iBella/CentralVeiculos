using Otimiza.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Otimiza.DAO
{
    public class TipoVeiculoDAO
    {
        public void Adiciona(TipoVeiculo tipo)
        {
            using (var context = new EstoqueContext())
            {
                context.TiposVeiculo.Add(tipo);
                context.SaveChanges();
            }
        }

        public IList<TipoVeiculo> Lista()
        {
            using (var contexto = new EstoqueContext())
            {
                return contexto.TiposVeiculo.ToList();
            }
        }

        public TipoVeiculo BuscaPorId(int id)
        {
            using (var contexto = new EstoqueContext())
            {
                return contexto.TiposVeiculo
                    .Where(p => p.ID == id)
                    .FirstOrDefault();
            }
        }

        public void Atualiza(TipoVeiculo tipo)
        {
            using (var contexto = new EstoqueContext())
            {
                contexto.Entry(tipo).State = System.Data.Entity.EntityState.Modified;
                contexto.SaveChanges();
            }
        }

        public void Remove(int id)
        {
            using (var contexto = new EstoqueContext())
            {
                TipoVeiculo tipo = contexto.TiposVeiculo.Where(p => p.ID == id).FirstOrDefault();
                contexto.TiposVeiculo.Remove(tipo);
                contexto.SaveChanges();
            }
        }
    }
}