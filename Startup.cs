using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CryptaEcillas.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using CryptaEcillas.Models;

namespace CryptaEcillas
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

            services.AddScoped<IUserRepo, MockUserRepo>();

            services.AddDbContext<UserDbContext>( opt => {
                opt.UseInMemoryDatabase("useDB");
            });
            services.AddScoped<UserDbContext>();

            services.AddDbContext<HeroDBContext>( opt => {
                opt.UseInMemoryDatabase("heroDB");
            });
            services.AddScoped<HeroDBContext>();

            services.AddScoped<MockUnitType>();
            services.AddScoped<MockStructureEnum>();

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(options =>
            options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            
        }
        
    }

}
