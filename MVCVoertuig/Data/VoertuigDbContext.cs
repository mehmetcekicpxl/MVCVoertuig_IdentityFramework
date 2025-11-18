using Microsoft.EntityFrameworkCore;
using MVCVoertuig.Models;

namespace MVCVoertuig.Data
{
    public class VoertuigDbContext : DbContext
    {
        public VoertuigDbContext(DbContextOptions<VoertuigDbContext> options) : base(options)
        {
            
        }
        public DbSet<MVCVoertuig.Models.Voertuig>? Voertuigen { get; set; }
        //Tabellen komen hier -> DBSet
    }
}
