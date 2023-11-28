using ASPN.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ASPN.Domain
{
    public class AppDbContext : IdentityDbContext<IdentityUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<IdentityRole>().HasKey(x => x.Id);
            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = "7689a196-d728-4c1b-b156-9b9f95e6fd45",
                Name = "admin",
                NormalizedName = "ADMIN"
            });

            modelBuilder.Entity<IdentityUser>().HasData(new IdentityUser
            {
                Id = "3baf4b0b-220c-4318-b54d-8528e3825530",
                UserName = "Plasmat1x",
                NormalizedUserName = "PLASMAT1X",
                Email = "plasmat1xdev@gmail.com",
                NormalizedEmail = "PLASMAT1XDEV@GMAIL.COM",
                EmailConfirmed = true,
                PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, "hackOFF1"),
                SecurityStamp = string.Empty
            });

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = "7689a196-d728-4c1b-b156-9b9f95e6fd45",
                UserId = "3baf4b0b-220c-4318-b54d-8528e3825530"
            });

            modelBuilder.Entity<Article>().HasData(new Article
            {
                Id = new Guid("dc97bb6b-a776-4e89-a6e9-fefcae4997cc"),
                CodeWord = "PageIndex",
                Title = "Main",
                Description = "Main page",
                Text = "Main page",
                CreatedAt = DateTime.UtcNow
            });
        }

        public DbSet<Article> Articles { get; set; }
    }
}
