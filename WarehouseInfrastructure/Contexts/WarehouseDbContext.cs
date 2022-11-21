using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using WarehouseCore.Entities.AbstractEntities;
using WarehouseCore.Entities.Organisation;
using WarehouseCore.Entities.Product;
using WarehouseCore.Entities.Storage;
using WarehouseCore.Entities.Unities;
using WarehouseCore.Entities.User;
using WarehouseInfrastructure.Extensions;

namespace WarehouseInfrastructure.Contexts;

public class WarehouseDbContext : DbContext
{
    public WarehouseDbContext(DbContextOptions<WarehouseDbContext> dbOptions) : base(dbOptions)
    {
    }

    public DbSet<Article> Articles { get; set; }
    public DbSet<Container> Containers { get; set; }
    public DbSet<Address> Addresses { get; set; }
    public DbSet<Heaviness> Heavinesses { get; set; }
    public DbSet<Dimension> Dimensions { get; set; }
    public DbSet<Department> Departments { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<UserInfo> UserInfos { get; set; }
    public DbSet<Permission> Permissions { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Storage
        modelBuilder.Entity<Article>().HasKey(a => a.Id);
        modelBuilder.Entity<Article>().Property(a => a.Id).ValueGeneratedNever();
        modelBuilder.Entity<Article>().OwnsOne(a => a.Dimension);
        modelBuilder.Entity<Article>().OwnsOne(a => a.Heaviness);
        modelBuilder.Entity<Container>().HasKey(c => c.Id);
        modelBuilder.Entity<Address>().HasKey(ad => ad.CodeId);
        //modelBuilder.Entity<Dimension>().HasKey(d => d.ArticleId);
        //modelBuilder.Entity<Heaviness>().HasKey(h => h.ArticleId);
        // --Users -- Permissions -- Departments
        modelBuilder.Entity<User>().HasKey(u => u.Id);
        modelBuilder.Entity<UserInfo>().HasKey(ui => ui.Id);
        modelBuilder.Entity<Department>().HasKey(d => d.Id);
        modelBuilder.Entity<Permission>().HasKey(p => p.Id);
        
        // modelBuilder.Entity<Container>().HasOne(c => c.Address).WithMany(ad => ad.Containers)
        //     .OnDelete(DeleteBehavior.Cascade);
        // modelBuilder.Entity<Container>().HasOne(c => c.Article).WithMany(ar => ar.Containers)
        //     .OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<Address>().IsConnectedWithContainer(c => c.Address);
        modelBuilder.Entity<Article>().IsConnectedWithContainer(a => a.Article);
        // modelBuilder.Entity<Article>().HasOne(a => a.Dimension).WithOne(d => d.Article)
        //     .HasForeignKey<Dimension>(d => d.ArticleId);
        // modelBuilder.Entity<Article>().HasOne(a => a.Heaviness).WithOne(h => h.Article)
        //     .HasForeignKey<Heaviness>(d => d.ArticleId);

        modelBuilder.Entity<User>().HasOne(e => e.UserInfo).WithOne(ui => ui.User).HasForeignKey<User>(ui => ui.Id);
        modelBuilder.Entity<User>().HasOne(u => u.Permission).WithMany(p => p.Users);
        modelBuilder.Entity<Department>().HasMany(d => d.Users).WithMany(u => u.Departments);
    }

    protected override void ConfigureConventions(ModelConfigurationBuilder modelConfigurationBuilder)
    {
        modelConfigurationBuilder.Properties<decimal>().HavePrecision(9, 4);
    }

    public override int SaveChanges(bool acceptAllChangesOnSuccess)
    {
        SetDateTimeUpdatedForModifiedEntities();
        CheckForExistingAddress();
        CheckForExistingArticle();
        //CheckGeneralForAllId<BaseEntity>();
        return base.SaveChanges(acceptAllChangesOnSuccess);
    }

    private void SetDateTimeUpdatedForModifiedEntities()
    {
        IEnumerable<EntityEntry<BaseEntity>> entries =
            ChangeTracker.Entries<BaseEntity>().Where(e => e.State == EntityState.Modified);
        foreach (EntityEntry<BaseEntity> entry in entries)
        {
            entry.Entity.DateTimeUpdated = DateTime.Now;
        }
    }

    private void CheckForExistingAddress()
    {
        List<Address> existingAddresses = Addresses.ToList();
        IEnumerable<EntityEntry<Address>> addresses =
            ChangeTracker.Entries<Address>().Where(e => e.State == EntityState.Added);
        foreach (EntityEntry<Address> address in addresses)
        {
            if (existingAddresses.Exists(a => a.CodeId == address.Entity.CodeId))
            {
                address.State = EntityState.Unchanged;
            }
        }
    }

    private void CheckForExistingArticle()
    {
        List<Article> existingArticles = Articles.ToList();
        IEnumerable<EntityEntry<Article>> articles =
            ChangeTracker.Entries<Article>().Where(e => e.State == EntityState.Added);
        foreach (EntityEntry<Article> article in articles)
        {
            if (existingArticles.Exists(a => a.Id == article.Entity.Id))
            {
                article.State = EntityState.Unchanged;
            }
        }
    }

    private void CheckGeneralForAllId<T>() where T : BaseEntity
    {
        IEnumerable<EntityEntry<T>> addedEntries = 
            ChangeTracker.Entries<T>().Where(e => e.State == EntityState.Added);
        foreach (EntityEntry<T> addedEntry in addedEntries)
        {
            if (addedEntry.Entity is Address)
            {
                List<Address> addresses = Addresses.ToList();
                // if (addresses.Exists(a => a.CodeId == addedEntry.Entity.CodeId))
                // {
                //     addedEntry.State = EntityState.Unchanged;
                // }
            }

            if (addedEntry.Entity is Article)
            {
                List<Article> articles = Articles.ToList();
                // if (articles.Exists(a => a.Id == addedEntry.Entity.Id))
                // {
                //     
                // }
            }
        }
    }
}