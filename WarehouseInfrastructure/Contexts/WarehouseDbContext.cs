using Microsoft.EntityFrameworkCore;
using WarehouseCore.Entities.Organisation;
using WarehouseCore.Entities.Product;
using WarehouseCore.Entities.Storage;
using WarehouseCore.Entities.Unities;
using WarehouseCore.Entities.User;

namespace WarehouseInfrastructure.Contexts;

public class WarehouseDbContext : DbContext
{
    public DbSet<Article> Articles { get; set; }
    public DbSet<Container> Containers { get; set; }
    public DbSet<Address> Addresses { get; set; }
    public DbSet<Heaviness> Heavinesses { get; set; }
    public DbSet<Dimension> Dimensions { get; set; }
    public DbSet<Department> Departments { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<UserInfo> UserInfos { get; set; }
    public DbSet<Permission> Permissions { get; set; }
    

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(
            @"Server=localhost,1433;Database=Warehouse;Integrated Security=false;User ID=sa;Password=Test1234@;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Storage
        modelBuilder.Entity<Article>().HasKey(a => a.Guid);
        modelBuilder.Entity<Container>().HasKey(c => c.ContainerId);
        modelBuilder.Entity<Address>().HasKey(ad => ad.CodeId);
        modelBuilder.Entity<Dimension>().HasKey(d => d.CodeId);
        modelBuilder.Entity<Heaviness>().HasKey(h => h.CodeId);
        // --Users -- Permissions -- Departments
        modelBuilder.Entity<User>().HasKey(u => u.Guid);
        modelBuilder.Entity<UserInfo>().HasKey(ui => ui.UserId);
        modelBuilder.Entity<Department>().HasKey(d => d.Guid);
        modelBuilder.Entity<Permission>().HasKey(p => p.Guid);
        //modelBuilder.Entity<Address>().IsConnectedWithContainer(c => c.Address);
        //List<int> ints= Enumerable.Range(1, 9).ToList();
        //Enumerable.Where(ints, i => i % 2 == 0);
        //ints.Where(i => i % 2 == 0).ForEach(Console.WriteLine);
        //s.ForEach();

        modelBuilder.Entity<Container>().HasOne(c => c.Address).WithMany(ad => ad.Containers);
        modelBuilder.Entity<Container>().HasOne(c => c.Article).WithMany(ar => ar.Containers);

        modelBuilder.Entity<User>().HasOne(e => e.UserInfo).WithOne(ui => ui.User).HasForeignKey<User>(ui => ui.Guid);
        modelBuilder.Entity<User>().HasOne(u => u.Permission).WithMany(p => p.Users);
        modelBuilder.Entity<Department>().HasMany(d => d.Users).WithMany(u => u.Departments);
    }

    protected override void ConfigureConventions(ModelConfigurationBuilder modelConfigurationBuilder)
    {
        modelConfigurationBuilder.Properties<decimal>().HavePrecision(9, 4);
    }
}