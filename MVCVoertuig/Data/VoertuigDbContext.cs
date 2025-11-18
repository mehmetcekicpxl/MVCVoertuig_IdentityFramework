using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MVCVoertuig.Models;
using MVCVoertuig.Models.ViewModels;

namespace MVCVoertuig.Data
{
    public class VoertuigDbContext : IdentityDbContext
    {
        public VoertuigDbContext(DbContextOptions<VoertuigDbContext> options) : base(options)
        {
            
        }
        public DbSet<MVCVoertuig.Models.Voertuig>? Voertuigen { get; set; }
        public DbSet<MVCVoertuig.Models.ViewModels.LoginViewModel> LoginViewModel { get; set; } = default!;
        //Tabellen komen hier -> DBSet
    }
}
