using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BM.Core.Shared.ModelViews
{
    public class NovoJogo
    {
        public string Campeonato { get; set; }
        public string equipaCasa { get; set; }
        public string EquipaVisita { get; set; }
        public bool ProximoJogo { get; set; }

        public DateTime DataJogo { get; set; }
        public TimeSpan HoraJogo { get; set; }
    }
}
