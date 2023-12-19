using BM.Core.Shared.ModelViews;
using BravosMaquis.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BM.Manager.Interfaces
{
    public interface IJogoRepository
    {
        Task<ICollection<ModelJogo>> GetAllJogosAsync();
        Task<ModelJogo> GetJogoAsync(int id);
        Task<ModelJogo> InsertJogoAsync(ModelJogo jogo);
        Task<ModelJogo> UpdateJogoAsync(ModelJogo jogo);
        Task DeletarJogoAsync(int id);
    }
}
