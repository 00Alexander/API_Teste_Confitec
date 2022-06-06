using ApiUsuario.Application.Contracts;
using ApiUsuario.Application.Services;
using ApiUsuario.Domain.Contracts.Repositories;
using ApiUsuario.Domain.Contracts.Services;
using ApiUsuario.Domain.Services;
using ApiUsuario.Infra.Data.Contexts;
using ApiUsuario.Infra.Data.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiUsuario.Presentation.Api
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

            services.AddSwaggerGen(s =>
            {
                s.SwaggerDoc("v1",
                    new OpenApiInfo
                    {
                        Title = "API de Usuários",
                        Version = "v1",
                        Description = "Projeto desenvolvido para avaliação",
                        Contact = new OpenApiContact
                        {
                            Name = "Alexander Oliveira C# WebDeveloper",
                            Email = "oliveira.alexander96@gmail.com.br"
                        }
                    });
            });

         
            services.AddDbContext<DataContext>
                (options => options.UseSqlServer
                (Configuration.GetConnectionString("ApiUsuarios")));

            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IUserDomainService, UserDomainService>();
            services.AddTransient<IUserApplicationService, UserApplicationService>();

            services.AddCors(s => s.AddPolicy("DefaultPolicy",
                 builder => {
                     builder.AllowAnyOrigin()  
                            .AllowAnyMethod()  
                            .AllowAnyHeader(); 
                 }));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors("DefaultPolicy");

            app.UseAuthorization();

            app.UseSwagger();
            app.UseSwaggerUI(s => { s.SwaggerEndpoint("/swagger/v1/swagger.json", "ApiUsuarios"); });


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
