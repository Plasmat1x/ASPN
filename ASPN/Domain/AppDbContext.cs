using ASPN.Domain.Entities;
using ASPN.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ASPN.Domain
{
    public class AppDbContext : IdentityDbContext<User>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
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

            modelBuilder.Entity<Page>(ent =>
            {
                ent.HasKey(x => x.Id);
                ent.HasData(new Page
                {
                    Id = Guid.Parse("520661c1-0236-42e9-8d5d-c8d74700624c"),
                    Description = "Test page from db",
                    CodeWord = "TestPageFromDB",
                    Title = "Hellow page from DB",
                    Text = """"
                    <p>Lorem ipsum dolor sit amet consectetur, adipisicing elit. Alias eligendi ex voluptatum rem illo sint nisi harum consequatur, magnam itaque fugit nam deserunt nulla nobis veniam blanditiis beatae exercitationem, minus perspiciatis consectetur temporibus repellendus. Odio, mollitia, vel, accusantium officiis minus vero nobis est nisi repudiandae exercitationem ipsa distinctio dolorum. Iure!</p>

                    <p>@Model.CreatedAt</p>
                    """"

                });
            });
        }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Page> Pages { get; set; }
    }
}
