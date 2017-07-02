using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Otimiza.Models;

namespace Otimiza.DAO
{
    public class EstoqueContext : DbContext
    {
        public DbSet<Veiculo> Veiculos { get; set; }
        public DbSet<Foto> Fotos { get; set; }
    }
}