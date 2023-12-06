using ASPN.Domain;
using ASPN.Services;

using Domain;
using Domain.Entities.Identity;
using Domain.Repositories.Abstract;
using Domain.Repositories.Abstract.Store;
using Domain.Repositories.EF;
using Domain.Repositories.EF.Store;

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ASPN {
    public class Program {
        public static AboutInfo About_info { get; set; } = new AboutInfo();

        public static void Main(string[] args) {
            var builder = WebApplication.CreateBuilder(args);

            var aboutSetcion = builder.Configuration.GetSection("About");
            aboutSetcion.Bind(About_info);

            builder.Services.AddTransient<IArticleR, ArticleEFR>();
            builder.Services.AddTransient<IPageR, PageEFR>();
            builder.Services.AddTransient<ICommentR, CommentEFR>();
            builder.Services.AddTransient<IItemR, ItemEFR>();
            builder.Services.AddTransient<IItemImageR, ItemImageEFR>();
            builder.Services.AddTransient<DataManager>();

            builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly("ASPN")));

            builder.Services.AddIdentity<User, Role>(options => {
                options.User.RequireUniqueEmail = true;
                options.Password.RequiredLength = 8;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireUppercase = true;
            })
                .AddEntityFrameworkStores<AppDbContext>()
                .AddDefaultTokenProviders();

            builder.Services.ConfigureApplicationCookie(options => {
                options.Cookie.Name = "pl1x_auth";
                options.Cookie.HttpOnly = true;
                options.LoginPath = "/account/signin";
                options.AccessDeniedPath = "/account/accessdenied";
                options.SlidingExpiration = true;
            });

            builder.Services.AddAuthorization(options => {
                options.AddPolicy("AdminArea", policy => { policy.RequireRole("admin"); });
            });

            builder.Services.AddControllersWithViews(options => {
                options.Conventions.Add(new AdminAreaAuthorization("Admin", "AdminArea"));
            }).AddRazorRuntimeCompilation();

            var app = builder.Build();

            if(!app.Environment.IsDevelopment()) {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();
            app.UseRouting();

            app.UseCookiePolicy();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints => {
                endpoints.MapControllerRoute("admin", "{area:exists}/{controller=Home}/{action=Index}/{id?}");
                endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
            });

            app.Run();
        }
    }
}