﻿using ASPN.Domain.Entities;
using ASPN.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ASPN.Domain
{
    public class AppDbContext : IdentityDbContext<User>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        /*
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
        */
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>(ent =>
            {
                ent.HasData(new User
                {
                    Id = "b97ed420-63cd-43cd-814f-2bee8c0f46d4",
                    UserName = "Plasmat1x",
                    NormalizedUserName = "PLASMAT1X",
                    Email = "plasmat1xdev@gmail.com",
                    NormalizedEmail = "PLASMAT1XDEV@GMAIL.COM",
                    EmailConfirmed = true,
                    PasswordHash = new PasswordHasher<User>().HashPassword(null, "hackOFF1"),
                    SecurityStamp = string.Empty
                });

                ent.HasData(new User
                {
                    Id = "5fe1d4fc-d6ea-43c7-a1f4-73d2f83032bd",
                    UserName = "Mikelele",
                    NormalizedUserName = "MIKELELE",
                    Email = "Mike@ma.il",
                    NormalizedEmail = "MIKE@MA.IL",
                    EmailConfirmed = true,
                    PasswordHash = new PasswordHasher<User>().HashPassword(null, "hackOFF1"),
                    SecurityStamp = string.Empty
                });
            });

            modelBuilder.Entity<Role>(ent =>
            {
                ent.HasData(new Role
                {
                    Id = "087bb1c2-109b-427d-be77-e0799bf27af0",
                    Name = "admin",
                    NormalizedName = "ADMIN"
                });

                ent.HasData(new Role
                {
                    Id = "a061da55-fea2-4bb9-b5b9-e5d358587138",
                    Name = "default",
                    NormalizedName = "DEFAULT"
                });
            });

            modelBuilder.Entity<IdentityUserRole<string>>(ent =>
            {
                ent.HasData(new IdentityUserRole<string>
                {
                    RoleId = "087bb1c2-109b-427d-be77-e0799bf27af0",
                    UserId = "b97ed420-63cd-43cd-814f-2bee8c0f46d4"
                });

                ent.HasData(new IdentityUserRole<string>
                {
                    RoleId = "a061da55-fea2-4bb9-b5b9-e5d358587138",
                    UserId = "5fe1d4fc-d6ea-43c7-a1f4-73d2f83032bd"
                });
            });
        }
        public DbSet<Article> Articles { get; set; }
    }
}
