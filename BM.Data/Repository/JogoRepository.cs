using BM.Data.Context;
using BM.Manager.Interfaces;
using BravosMaquis.Models.Domain;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BM.Data.Repository
{
    public class JogoRepository : IJogoRepository
    {
        private readonly BMContext context;

        public JogoRepository(BMContext _context)
        {
            context = _context;
        }
        public async Task DeletarJogoAsync(int id)
        {
            var resultado = await context.Jogos.FindAsync(id);
            context.Jogos.Remove(resultado);
            await context.SaveChangesAsync();
           
        }

        public async Task<ICollection<ModelJogo>> GetAllJogosAsync()
        {
            var resultado = await context.Jogos.AsNoTracking().ToListAsync(); 
            return resultado;
        }

        public async Task<ModelJogo> GetJogoAsync(int id)
        {
            var resultado = await context.Jogos.FindAsync(id);
            if (resultado == null)
                return null;
            return resultado;
        }

        public async Task<ModelJogo> InsertJogoAsync(ModelJogo jogo)
        {
            await context.Jogos.AddAsync(jogo);
            await context.SaveChangesAsync();
            return jogo;
        }

        public async Task<ModelJogo> UpdateJogoAsync(ModelJogo jogo)
        {
            var resultado = await context.Jogos.FindAsync(jogo.Id);
            if (resultado == null)
                return null;
            context.Entry(resultado).CurrentValues.SetValues(jogo); 
            return jogo;
        }
    }
}
