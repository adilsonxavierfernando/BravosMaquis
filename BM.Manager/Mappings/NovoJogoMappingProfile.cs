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
    public class NovoJogoMappingProfile:Profile
    {
        public NovoJogoMappingProfile()
        {
            CreateMap<NovoJogo, ModelJogo>()
                .ForMember(d=>d.DataCriacao,o=>o.MapFrom(x=>DateTime.Now))
                .ForMember(d=>d.DataJogo,o=>o.MapFrom(x=>x.DataJogo.Date))
                .ForMember(d=>d.HoraJogo,o=>o.MapFrom(x=>x.HoraJogo));
        }
    }
}
