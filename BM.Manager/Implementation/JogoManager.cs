using AutoMapper;
using BM.Core.Shared.ModelViews;
using BM.Manager.Interfaces;
using BravosMaquis.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BM.Manager.Implementation
{
    public class JogoManager:IJogoManager
    {
        private readonly IJogoRepository repository;
        private readonly IMapper mapper;

        public JogoManager(IJogoRepository _repository, IMapper _mapper)
        {
            repository = _repository;
            mapper = _mapper;
        }

        public async Task DeletarJogoAsync(int id)
        {
            await repository.DeletarJogoAsync(id);
        }

        public async Task<ICollection<ModelJogo>> GetAllJogosAsync()
        {
            return await repository.GetAllJogosAsync();
        }

        public async Task<ModelJogo> GetJogoAsync(int id)
        {
            return await repository.GetJogoAsync(id);
        }

        public async Task<ModelJogo> InsertJogoAsync(NovoJogo jogo)
        {
            var j=mapper.Map<ModelJogo>(jogo);
            return await  repository.InsertJogoAsync(j);
        }

        public async Task<ModelJogo> UpdateJogoAsync(AtualizarJogo jogo)
        {
            var j = mapper.Map<ModelJogo>(jogo);
            return await repository.UpdateJogoAsync(j);
        }
    }
}
