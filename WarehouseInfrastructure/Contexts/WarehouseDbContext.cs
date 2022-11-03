using Microsoft.EntityFrameworkCore;
using WarehouseCore.Entities.Product;
using WarehouseCore.Entities.Storage;
using WarehouseCore.Entities.Unities;

namespace WarehouseInfrastructure.Contexts;

public class WarehouseDbContext : DbContext
{
    public DbSet<Article> Articles { get; set; }
    public DbSet<Container> Containers { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(
            @"Server=localhost,1433;Database=Warehouse;Integrated Security=false;User ID=sa;Password=Test1234@;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Article>().HasKey(a => a.Guid);
        modelBuilder.Entity<Container>().HasKey(c => c.ContainerId);
        modelBuilder.Entity<Address>().HasKey(ad => ad.CodeId);
        modelBuilder.Entity<Dimension>().HasKey(d => d.CodeId);
        modelBuilder.Entity<Heaviness>().HasKey(h => h.CodeId);

        //modelBuilder.Entity<Address>().IsConnectedWithContainer(c => c.Address);
        //List<int> ints= Enumerable.Range(1, 9).ToList();
        //Enumerable.Where(ints, i => i % 2 == 0);
        //ints.Where(i => i % 2 == 0).ForEach(Console.WriteLine);
        //s.ForEach();

        modelBuilder.Entity<Container>().HasOne(c => c.Address).WithMany(ad => ad.Containers);
        modelBuilder.Entity<Container>().HasOne(c => c.Article).WithMany(ar => ar.Containers);
    }

    protected override void ConfigureConventions(ModelConfigurationBuilder modelConfigurationBuilder)
    {
        modelConfigurationBuilder.Properties<decimal>().HavePrecision(9, 4);
    }
}