using ApiProject.BusinessLayer.Abstract;
using ApiProject.BusinessLayer.Concrete;
using ApiProject.DataAccessLayer.Abstract;
using ApiProject.DataAccessLayer.Concrete;
using ApiProject.DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiProject.WebApi
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
            services.AddDbContext<Context>();

            services.AddScoped<ICharacterDal, EfCharacterDal>();
            services.AddScoped<ICharacterService, CharacterManager>();

            services.AddScoped<IEpisodeDal, EfEpisodeDal>();
            services.AddScoped<IEpisodeService, EpisodeManager>();

            services.AddScoped<ILocationDal, EfLocationDal>();
            services.AddScoped<ILocationService, LocationManager>();

          

            services.AddCors(opt =>
            {
                opt.AddPolicy("RickAndMortyAPI", opts =>
                {
                    opts.AllowAnyOrigin().AllowAnyHeader().AllowAnyHeader();
                });
            });





            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ApiProject.WebApi", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ApiProject.WebApi v1"));
            }

            app.UseRouting();
            app.UseCors("RickAndMortyAPI");
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
