using Microsoft.EntityFrameworkCore;
using DataLayer.Entities;
using Microsoft.EntityFrameworkCore.Design;

namespace DataLayer;

public class EFDBContext : DbContext
{
    public DbSet<Material> Materials { get; set; }
    public DbSet<Entities.Directory> Directories { get; set; }
    public EFDBContext(DbContextOptions<EFDBContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Entities.Directory>().HasData(
            new Entities.Directory[]
            {
                new Entities.Directory { Id=1, Title = "First Directory", Html = "<b>First Directory's content</b>"},
                new Entities.Directory { Id=2, Title = "Second Directory", Html = "<i>Second Directory's content</i>"},
            });

        modelBuilder.Entity<Material>().HasData(
            new Material[]
            {
                new Material { Id=1, Title = "First Material", Html = "<b>First Material's content</b>", DirectoryId = 1},
                new Material { Id=2, Title = "Second Material", Html = "<b>Second Material's content</b>", DirectoryId = 2},
            });
    }
}

public class EFDBContextFactory : IDesignTimeDbContextFactory<EFDBContext>
{
    public EFDBContext CreateDbContext(string[] args)
    {
        var optionBuilder = new DbContextOptionsBuilder<EFDBContext>();
        optionBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=NLayerDB;Trusted_Connection=True;MultipleActiveResultSets=true", b => b.MigrationsAssembly("DataLayer"));

        return new EFDBContext(optionBuilder.Options);
    }

}

