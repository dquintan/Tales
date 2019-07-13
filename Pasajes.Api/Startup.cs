using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;
using Pasajes.Api.Entities;
using Pasajes.Api.Profiles;
using Pasajes.Api.Repositories;
using Pasajes.Api.Services;

namespace Pasajes.Api
{
    public class Startup
    {
        //public static IConfigurationRoot Configuration; 2.1 core flavour

        public Startup(IConfiguration configuration, IHostingEnvironment env)
        {
            //Configuration = configuration;

            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appSettings.json", false, reloadOnChange: true)
                .AddJsonFile($"appSettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true)
                // Remove from launchSettings and do not check in connection string. Once live, edit environment variables on live machine
                .AddEnvironmentVariables();

            Configuration = builder.Build(); //2.1 core flavour
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc()
                .AddMvcOptions(o => o.OutputFormatters.Add(new XmlDataContractSerializerOutputFormatter()));

            services.AddTransient<IStreamingService, StreamingService>();

            services.AddDbContext<TalesContext>(o => o.UseSqlServer(Configuration.GetConnectionString("pasajesDbConnectionString")));
            services.AddScoped<ITalesRepository, TalesRepository>();

            // Auto Mapper Configurations
            var config = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new TaleProfile());
                mc.AddProfile(new TaleSourceProfile());
            });

            IMapper mapper = config.CreateMapper();
            services.AddSingleton(mapper);

            services.AddSwaggerGen(setupAction =>
            {
                setupAction.SwaggerDoc("LibraryOpenAPISpecification", new Microsoft.OpenApi.Models.OpenApiInfo()
                {
                    Title = "Library API",
                    Version = "1"
                });
            }
            );

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, TalesContext talesContext)
        {
            loggerFactory.AddConsole();
            loggerFactory.AddDebug();

            loggerFactory.AddNLog();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            talesContext.EnsureSeedDataForContext();

            app.UseStatusCodePages();
            app.UseHttpsRedirection();

            app.UseSwagger();
            app.UseSwaggerUI(setupAction => 
            {
                setupAction.SwaggerEndpoint("/swagger/LibraryOpenAPISpecification/swagger.json", "Library API");
            });

            app.UseMvc();
        }
    }
}
