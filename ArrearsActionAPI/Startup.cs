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

namespace ArrearsActionAPI
{
    public class Startup
    {
        public const string AppS3BucketKey = "AppS3Bucket";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public static IConfiguration Configuration { get; private set; }

        // This method gets called by the runtime. Use this method to add services to the container
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().AddFluentValidation().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddScoped<IArrearsActionUsecase, ArrearsActionUsecase>();
            services.AddScoped<IArrearsActionGateway, ArrearsActionGateway>();
            services.AddTransient<IGetAractionsByPropRefRequestValidator, GetAractionsByPropRefRequestValidator>();
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
