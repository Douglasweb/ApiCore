using Microsoft.EntityFrameworkCore;
using Primeiro.Models;

namespace  Primeiro.Data
{

    public class PrimeiroContext : DbContext
    {
        public PrimeiroContext(DbContextOptions<PrimeiroContext> opt) : base(opt)
        {
            
        }

        public DbSet<Primary> Primarys { get; set; }
    }
}