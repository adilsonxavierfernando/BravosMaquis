using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BravosMaquis.Models.Domain
{
    public class ModelClubes
    {
        [Key]
        public int Id { get; set; }

        public string Clube { get; set; } = string.Empty;

        public string Emblema { get; set; } = string.Empty;

        public string Sigla { get; set; } = string.Empty;
        public string Historia { get; set; } = string.Empty;
        public DateTime DataCriacao { get; set; }
        public DateTime? DataUltimaAtualizacao { get; set; }
        //public virtual List<ModelJogadores> Jogadores { get; set; }
        //public virtual List<ModelEquipeTecnica> EquipeTecnica { get; set; }
    }
}
