using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Archemy.Api.Extensions;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Archemy.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            NLog.LogManager.LoadConfiguration(string.Concat(System.IO.Directory.GetCurrentDirectory(), "/NLog.config"));
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.ConfigureRepository(Configuration);
            services.ConfigureRedisCache(Configuration);
            services.ConfigureAuthenticationBll();
            services.ConfigureProductBll();
            services.ConfigureEmployeeBll();
            services.ConfigureMasterDataBll();
            services.ConfigureAccountBll();
            services.ConfigureComponent();
            services.ConfigureMvc();
            services.ConfigureCors();
            services.ConfigureSwagger();
            services.ConfigureCookieAuthen(Configuration);
            services.AddAutoMapper();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseAuthentication();
            app.ConfigureUseSwagger();
            app.ConfigureMiddleware();
            app.ConfigureHandlerStatusPages();
            app.UseCors("CorsPolicy");
            app.UseMvc();
        }
    }
}
