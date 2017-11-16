namespace Sledzto
{
    using Sledzto.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration.Conventions;
    using System.Linq;

    public class AppDbContext : DbContext
    {
        public AppDbContext()
            : base("name=AppDbContext")
        {
        }

        DbSet<Option> Option { get; set; }
        DbSet<User> User { get; set; }
        DbSet<Website> Website { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            modelBuilder.Entity<Website>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<Option>()
                .HasKey(x => x.Id)
                .HasRequired(x => x.Website)
                .WithMany()
                .HasForeignKey(x => x.WebsiteId);

            modelBuilder.Entity<User>()
                .HasKey(x => x.Id)
                .HasRequired(x => x.WebSite)
                .WithMany()
                .HasForeignKey(x => x.WebsiteId);
            

        }

        public System.Data.Entity.DbSet<Sledzto.Models.Website> Websites { get; set; }

        public System.Data.Entity.DbSet<Sledzto.Models.User> Users { get; set; }

        public System.Data.Entity.DbSet<Sledzto.Models.Option> Options { get; set; }
    }
}