using Backend.Domain.IRepositories;
using Backend.Domain.IServices;
using Backend.Persistence.Context;
using Backend.Persistence.Repositories;
using Backend.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AplicationDbContext>(options =>
            options.UseSqlServer("Server=(local)\\sqlexpress;Database=DocApp;Trusted_Connection=True;"));
            services.AddHttpClient();


            // Services
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserProfilePictureService, UserProfilePictureService>();
            services.AddScoped<ILoginService, LoginService>();
            services.AddScoped<IPatientService, PatientService>();
            services.AddScoped<IMedicalHistoryService, MedicalHistoryService>();
            // Repositories
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserProfilePictureRepository, UserProfilePictureRepository>();
            services.AddScoped<ILoginRepository, LoginRepository>();
            services.AddScoped<IPatientRepository, PatientRepository>();
            services.AddScoped<IMedicalHistoryRepository, MedicalHistoryRepository>();

            // Cors
            services.AddCors(options => options.AddPolicy("AllowWebapp",
                             builder => builder.AllowAnyOrigin().
                                                AllowAnyHeader().
                                                AllowAnyMethod()));

            // Add Authentication
            services.AddControllers();
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = Configuration["Jwt:Issuer"],
                        ValidAudience = Configuration["Jwt:Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:SecretKey"])),
                        ClockSkew = TimeSpan.Zero
                };
            });
        }
            
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseHttpsRedirection();

            app.UseCors("AllowWebapp");

            app.UseAuthentication();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
