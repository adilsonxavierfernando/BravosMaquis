using BravosMaquis.Models.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BM.Data.Context
{
    public class BMContext:DbContext
    {
        public BMContext(DbContextOptions<BMContext> options) : base(options)
        {

        }
       public DbSet<ModelClubes> Clubes { get; set; }
       public DbSet<ModelJogo> Jogos { get; set;}
    }
}
