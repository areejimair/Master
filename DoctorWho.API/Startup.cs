using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DoctorWho.DB.Repositories;
using DoctorWho.DB;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using System;
namespace DoctorWho.API
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
            services.AddControllers();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddScoped<ITblAuthorRep, TblAuthorRep>();
            services.AddScoped<ITblCompanionRep, TblCompanionRep>();
            services.AddScoped<ITblDoctorRep, TblDoctorRep>();
            services.AddScoped<ITblEnemyRep, TblEnemyRep>();
            services.AddScoped<ITblEpisodeRep, TblEpisodeRep>();
            services.AddScoped<ITblEpsiodeCompanionRep, TblEpsiodeCompanionRep>();
            services.AddScoped<ITblEpsiodeEnemyRep, TblEpsiodeEnemyRep>();
            //services.AddDbContext < DoctorWhoCoreDbContext>(options=> { options.UseSqlServer("Server =.\\SQLExpress; Database = DoctorWho_Web; Trusted_Connection = True; ");});
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
