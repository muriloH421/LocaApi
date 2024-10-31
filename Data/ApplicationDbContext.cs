using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using LocaApi.Models;

namespace LocaApi.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<LocaApi.Models.Patio> Patio { get; set; } = default!;
        public DbSet<LocaApi.Models.Veiculo> Veiculo { get; set; } = default!;
        public DbSet<LocaApi.Models.Locacao> Locacao { get; set; } = default!;
        public DbSet<LocaApi.Models.Cliente> Cliente { get; set; } = default!;
    }
}
