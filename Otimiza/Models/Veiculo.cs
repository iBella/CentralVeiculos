using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Otimiza.Models
{
    public class Veiculo
    {
        public int ID { get; set; }
        public String Placa { get; set; }
        public String NomeTipo { get; set; }
        public virtual TipoVeiculo TipoVeiculo { get; set; }
        public String Proprietario { get; set; }
        public virtual IList<Foto> Fotos { get; set; }
    }
}