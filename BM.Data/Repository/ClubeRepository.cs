using BM.Data.Context;
using BM.Manager.Interfaces;
using BravosMaquis.Models.Domain;
using BravosMaquis.Models.Exceptions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BM.Data.Repository
{
    public class ClubeRepository:IClubeRepository
    {
        private readonly BMContext _bMContext;
        public ClubeRepository(BMContext context)
        {
            _bMContext = context;
        }
        public async Task<ICollection<ModelClubes>> GetAllClubesAsync() { return await _bMContext.Clubes.AsNoTracking().ToListAsync(); }
        public async Task<ModelClubes> GetClubeByIdAsync(int id) 
        { 
            var r=await _bMContext.Clubes.FindAsync(id); 
            if(r is not null) return r;
            throw new NotFoundException();
        }
        //insert
        public async Task<ModelClubes> InsertClube(ModelClubes clube)
        {
            await _bMContext.Clubes.AddAsync(clube);
            await _bMContext.SaveChangesAsync();
            return clube;
        }
        //update
        public async Task<ModelClubes> UpdateClube(ModelClubes clube)
        {
            var clubeConsultado=await _bMContext.Clubes.FindAsync(clube.Id);
            if(clubeConsultado is not null)
            {
                _bMContext.Entry(clubeConsultado).CurrentValues.SetValues(clube);
                await _bMContext.SaveChangesAsync();
                return clube;
            }
            else
            {
                return null;
            }
         
        }
        //delete
        public async Task DeleteClube(int id)
        {
            var clubeConsultado = await _bMContext.Clubes.FindAsync(id);
            if (clubeConsultado is not null)
            {
                _bMContext.Clubes.Remove(clubeConsultado);
                await _bMContext.SaveChangesAsync();
             
            }
            else
            {
                throw new NotFoundException();
            }

        }
    }
}
