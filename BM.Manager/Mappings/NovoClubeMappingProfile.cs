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
    public  class NovoClubeMappingProfile:Profile
    {
        public NovoClubeMappingProfile()
        {
            CreateMap<NovoClube, ModelClubes>()
                .ForMember(d => d.DataCriacao, o => o.MapFrom(x => DateTime.Now));
              
        }
    }
}
