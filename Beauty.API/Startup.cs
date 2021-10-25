using System.Text;
using Beauty.EFDataAccessLibrary.Contexts;
using Beauty.EFDataAccessLibrary.Models;
using Beauty.API.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Beauty.API.Interfaces;

namespace Beauty.API {
    public class Startup {
        private readonly IConfiguration _config;
        public Startup(IConfiguration config) =>
            _config = config;
        public void ConfigureServices(IServiceCollection services) {
            services.AddRazorPages();
            services.AddControllers();
            services.AddDbContext<ApplicationDbContext>(options
                => options.UseSqlServer("Data Source=37.140.192.100;Initial Catalog=u1304518_beauty;User ID=u1304518_dimanrusdev;Password=NetDevMicrosoft33@;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False", e=>e.MigrationsAssembly("Beauty.EFDataAccessLibrary")));
            //services.AddDbContext<ApplicationDbContext>(options
            //      => options.UseSqlServer(@"Data Source=DIMANRUS\SQLEXPRESS;Initial Catalog=Beauty;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"));
            services.AddIdentity<User, IdentityRole>(options => {
                options.User.AllowedUserNameCharacters = "йцукенгшщзхъфывапролджэячсмитьбюЙЦУКЕНГШЩЗХЪФЫВАПРОЛДЖЭЯЧСМИТЬБЮ";
            }).AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();
            services.AddAuthentication(options => {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options => {
                options.TokenValidationParameters = new TokenValidationParameters() {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidAudience = _config["AuthSettings:Audience"],
                    ValidIssuer = _config["AuthSettings:Issuer"],
                    RequireExpirationTime = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["AuthSettings:Key"])),
                    ValidateIssuerSigningKey = true
                };
            });
            services.AddScoped<IUserService, UserService>();
            services.AddSingleton<IMailService, MailService>();
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints => {
                endpoints.MapRazorPages();
                endpoints.MapControllers();
            });
        }
    }
}