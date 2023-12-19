using BM.Core.Shared.ModelViews;
using BravosMaquis.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BM.Manager.Interfaces
{
    public interface IClubeManager
    {
        Task<ModelClubes> GetClubeByIdAsync(int id);
        Task<IEnumerable<ModelClubes>> GetClubesAsync();
        Task DeleteClube(int id);
        Task<ModelClubes> InsertClube(NovoClube clube);
        Task<ModelClubes> UpdateClube(UpdateClube clube);
    }
}
