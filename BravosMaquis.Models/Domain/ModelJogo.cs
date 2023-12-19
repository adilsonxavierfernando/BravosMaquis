using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BravosMaquis.Models.Domain
{
    public class ModelJogo
    {
        public int Id { get; set; }
        public string Campeonato { get; set; }
        public string equipaCasa {  get; set; }
        public string EquipaVisita { get; set;}
        public bool ProximoJogo { get; set; }

        public DateTime DataJogo { get; set; }
        public TimeSpan HoraJogo { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataAtualizacao { get; set; }
    }
}
