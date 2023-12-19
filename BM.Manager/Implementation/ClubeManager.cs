using AutoMapper;
using BM.Core.Shared.ModelViews;
using BM.Manager.Interfaces;
using BravosMaquis.Models.Domain;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BM.Manager.Implementation
{
    public class ClubeManager:IClubeManager
    {
        private readonly IClubeRepository repository;
        private readonly IMapper _mapper;

        public ClubeManager(IClubeRepository repository, IMapper mapper)
        {
            this.repository = repository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<ModelClubes>> GetClubesAsync()
        {
              return await repository.GetAllClubesAsync();
        }
        public async Task<ModelClubes> GetClubeByIdAsync(int id)
        {
            return await repository.GetClubeByIdAsync(id);
        }

        public async Task DeleteClube(int id)
        {
            await repository.DeleteClube(id);
        }

        public async Task<ModelClubes> InsertClube(NovoClube novoclube)
        {
            var clube = _mapper.Map<ModelClubes>(novoclube);
            return await repository.InsertClube(clube);
        }

        public async Task<ModelClubes> UpdateClube(UpdateClube novoClube)
        {
            var clube = _mapper.Map<ModelClubes>(novoClube);
            return await repository.UpdateClube(clube);
        }
    }
}
