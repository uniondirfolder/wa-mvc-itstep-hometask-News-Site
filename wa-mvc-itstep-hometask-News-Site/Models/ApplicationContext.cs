
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using wa_mvc_itstep_hometask_News_Site.Models.Entities;

namespace wa_mvc_itstep_hometask_News_Site.Models
{
    public class ApplicationContext:DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<SavedNews> SavedNews { get; set; }
        public DbSet<Role> Roles { get; set; }
        public ApplicationContext(DbContextOptions<ApplicationContext> options):base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder) 
        {
            #region User
            builder.Entity<User>()
                .Property(e => e.IsLocked)
                .HasDefaultValue(false);
            builder.Entity<User>()
                .Property(e => e.Email)
                .IsRequired();
            builder.Entity<User>()
                .Property(e => e.Password)
                .IsRequired();
            #endregion

            #region SavedNews

            builder.Entity<SavedNews>()
                .Property(e => e.Title)
                .IsRequired();

            builder.Entity<SavedNews>()
                .Property(e => e.Link)
                .IsRequired();

            builder.Entity<SavedNews>()
                .Property(e => e.Category)
                .IsRequired();

            builder.Entity<SavedNews>()
                .Property(e => e.PublicationDate)
                .IsRequired();

            #endregion

            builder.Entity<User>()
                .HasMany(e => e.SavedNews)
                .WithOne(e => e.User)
                .HasForeignKey(e => e.UserId)
                .HasConstraintName("FK_User_SavedNews")
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
