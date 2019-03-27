using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace MtgCubeManagerServer.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
            // Turns off code first migrations
            Database.SetInitializer<ApplicationDbContext>(null);
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public DbSet<Card> Cards { get; set; }

        public DbSet<Cube> Cubes { get; set; }

        public DbSet<CubeCard> CubeCards { get; set; }
    }
}