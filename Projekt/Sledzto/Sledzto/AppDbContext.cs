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

        public DbSet<Option> Option { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Website> Website { get; set; }
        public DbSet<History> History { get; set; }

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
                .HasRequired(x => x.Option)
                .WithMany()
                .HasForeignKey(x => x.OptionId);

            modelBuilder.Entity<Option>()
                .HasMany(x => x.History)
                .WithRequired(x => x.Option)
                .HasForeignKey(x => x.OptionId);


            modelBuilder.Entity<History>()
                .HasKey(x => x.Id)
                .HasRequired(x => x.Option)
                .WithMany()
                .HasForeignKey(x => x.OptionId);
        }
    }
}