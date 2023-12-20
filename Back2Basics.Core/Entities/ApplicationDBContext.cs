using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Options;


namespace Back2Basics.Core.Entities
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {
                
        }
        public DbSet<Inventory> Inventories { get; set; }
    }

    //public class ApplicationDBContextFactory : IDesignTimeDbContextFactory<ApplicationDBContext>
    //{
    //    public ApplicationDBContext CreateDbContext(string[] args)
    //    {
    //        var optionsBuilder = new DbContextOptionsBuilder<ApplicationDBContext>();
    //        optionsBuilder.UseSqlServer("Server = DESKTOP-V0CK8TO; Database = Basics; Integrated Security = true; MultipleActiveResultSets = true; Trusted_Connection = True; TrustServerCertificate=True");

    //        return new ApplicationDBContext(optionsBuilder.Options);
    //    }
    //}
}
