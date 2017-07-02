using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Otimiza.Models;

namespace Otimiza.DAO
{
    public class VeiculoDAO
    {
        public void Adiciona(Veiculo veiculo)
        {
            using (var context = new EstoqueContext())
            {
                context.Veiculos.Add(veiculo);
                context.SaveChanges();
            }
        }

        public IList<Veiculo> Lista()
        {
            using (var contexto = new EstoqueContext())
            {
                return contexto.Veiculos.ToList();
            }
        }

        public Veiculo BuscaPorId(int id)
        {
            using (var contexto = new EstoqueContext())
            {
                return contexto.Veiculos
                    .Where(p => p.ID == id)
                    .FirstOrDefault();
            }
        }

        public void Atualiza(Veiculo veiculo)
        {
            using (var contexto = new EstoqueContext())
            {
                contexto.Entry(veiculo).State = System.Data.Entity.EntityState.Modified;
                contexto.SaveChanges();
            }
        }

        public void Remove(int id)
        {
            using (var contexto = new EstoqueContext())
            {
                Veiculo veiculo = contexto.Veiculos.Where(p => p.ID == id).FirstOrDefault();
                contexto.Veiculos.Remove(veiculo);
                contexto.SaveChanges();
            }
        }
    }
}