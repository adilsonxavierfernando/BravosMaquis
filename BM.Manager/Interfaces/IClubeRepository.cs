using BravosMaquis.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BM.Manager.Interfaces
{
    public interface IClubeRepository
    {
        Task DeleteClube(int id);
        Task<ICollection<ModelClubes>> GetAllClubesAsync();
        Task<ModelClubes> GetClubeByIdAsync(int id);
        Task<ModelClubes> InsertClube(ModelClubes clube);
        Task<ModelClubes> UpdateClube(ModelClubes clube);
    }
}
