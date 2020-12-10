using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Votador.Compartilhado;
using Votador.Dominio.Comandos.Manipulador;
using Votador.Dominio.Entidades;
using Votador.Dominio.Repositorios;
using Votador.Infra.DataContext;
using Votador.Infra.Repositorio;

namespace Votador.Api
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
            services.AddCors();

            services.AddControllers();

            var key = Encoding.ASCII.GetBytes(Configuracoes.Secret);
            services.AddAuthentication(x =>
                {
                    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(x =>
                {
                    x.RequireHttpsMetadata = false;
                    x.SaveToken = true;
                    x.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                });

            services.AddScoped<VotadorDataContext, VotadorDataContext>();
            services.AddTransient<IFuncionarioRepositorio, FuncionarioRepositorio>();
            services.AddTransient<FuncionarioComandoManipulador, FuncionarioComandoManipulador>();
            services.AddTransient<AutenticarComandoManipulador, AutenticarComandoManipulador>();
            services.AddTransient<IRecursoRepositorio, RecursoRepositorio>();
            services.AddTransient<CriarRecursoManipulador, CriarRecursoManipulador>();
            services.AddTransient<IVotoRepositorio, VotoRepositorio>();
            services.AddTransient<CriarVotoManipulador, CriarVotoManipulador>();
            services.AddTransient<IComentarioRepositorio, ComentarioRepositorio>();
            services.AddTransient<IRecuperarRecursosRepository, RecuperarRecursosRepositorio>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Votador.Api", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Votador.Api v1"));
            }

            app.UseRouting();

            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader()
            );

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
