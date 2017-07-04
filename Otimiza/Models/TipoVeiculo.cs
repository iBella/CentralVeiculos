using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Otimiza.Models
{
    public class TipoVeiculo
    {
        public int ID { get; set; }

        [MaxLength(50, ErrorMessage = "Nome deve ter 50 caracteres ou menos")]
        public String Nome { get; set; }

        public virtual IList<Veiculo> Veiculo { get; set; }
    }
}