using AutoMapper;
using BM.Core.Shared.ModelViews;
using BravosMaquis.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BM.Manager.Mappings
{
    public class UpdateJogoMappingProfile:Profile
    {
        public UpdateJogoMappingProfile()
        {
            CreateMap<AtualizarJogo, ModelJogo>()
                .ForMember(d => d.DataAtualizacao, o => o.MapFrom(x => DateTime.Now));
               
        }
    }
}
