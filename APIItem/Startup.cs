﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.Application;
using Swashbuckle.AspNetCore.Swagger;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using BPersistance;
using BPersistance.bdd;
using BiblioJdr.outils;

namespace APIItem
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
            services.AddAuthentication("Bearer").AddIdentityServerAuthentication(options =>
            {
                options.Authority = "http://localhost:5000";
                options.RequireHttpsMetadata = false;

                options.ApiName = "APIItem";
            });
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddSingleton<IDataManager,JdrDBManager>();
            services.AddScoped<IDataManager,JdrDBManager>((ServiceProvider) => new JdrDBManager(false));
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "APIItem", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
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
 app.UseAuthentication();
app.UseSwagger();app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "APIItem V1");
            });            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
