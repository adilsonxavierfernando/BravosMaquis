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
    public class UpdateClubeMappingProfile:Profile
    {
        public UpdateClubeMappingProfile()
        {
             CreateMap<UpdateClube, ModelClubes>()
                .ForMember(d=>d.DataUltimaAtualizacao, o=>o.MapFrom(x=>DateTime.Now));
        }
    }
}
