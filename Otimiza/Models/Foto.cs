using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Otimiza.Models
{
    public class Foto
    {
        public int ID { get; set; }
        public String Nome { get; set; }
        public Byte[] Imagem { get; set; }
        public int IdVeiculo { get; set; }
        public virtual Veiculo Veiculo { get; set; }
    }
}