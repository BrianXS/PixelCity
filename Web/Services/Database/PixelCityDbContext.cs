using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Web.Data.Entities;

namespace Web.Services.Database
{
    public class PixelCityDbContext : IdentityDbContext<User, IdentityRole<int>, int>
    {
        public PixelCityDbContext(DbContextOptions options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Community>()
                .HasMany(p => p.Members)
                .WithMany(p => p.MemberCommunity)
                .UsingEntity(e => e.ToTable("MembersOfCommunity"));

            modelBuilder.Entity<Community>()
                .HasMany(p => p.Moderators)
                .WithMany(p => p.ModeratorCommunity)
                .UsingEntity(e => e.ToTable("ModeratorsOfCommunity"));
            
            base.OnModelCreating(modelBuilder);
        }

        
        public DbSet<Rank> Ranks { get; set; }
        public DbSet<Badge> Badges { get; set; }
        public DbSet<Community> Communities { get; set; }

        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }
    }
}