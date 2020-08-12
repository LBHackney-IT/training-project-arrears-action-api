using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArrearsActionAPI.V1.Gateways;
using ArrearsActionAPI.V1.Usecases;
using ArrearsActionAPI.V1.Validators;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using FluentValidation.AspNetCore;
using ArrearsActionAPI.V1.Boundary;
using ArrearsActionAPI.V1.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace ArrearsActionAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public static IConfiguration Configuration { get; private set; }

        // This method gets called by the runtime. Use this method to add services to the container
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().AddFluentValidation().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            ConfigureDbContext(services);
            RegisterGateways(services);
            RegisterUseCases(services);
            RegisterValidators(services);
        }

        private static void ConfigureDbContext(IServiceCollection services)
        {
            var connectionString = Environment.GetEnvironmentVariable("CONNECTION_STRING") ?? throw new ArgumentNullException("connectionString");

            services.AddDbContext<CoreHousingContext>(o => o.UseNpgsql(connectionString));
        }

        private static void RegisterGateways(IServiceCollection services)
        {
            services.AddScoped<IArrearsActionGateway, ArrearsActionGateway>();
        }

        private static void RegisterUseCases(IServiceCollection services)
        {
            services.AddScoped<IArrearsActionUsecase, ArrearsActionUsecase>();
        }

        private static void RegisterValidators(IServiceCollection services)
        {
            services.AddTransient<IFValidator<GetAractionsByPropRefRequest>, GetAractionsByPropRefRequestValidator>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
