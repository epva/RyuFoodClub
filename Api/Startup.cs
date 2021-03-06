using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using RyuFoodClub.Model;
using RyuFoodClub.Model.CouchDB;
using RyuFoodClub.Model.MongoDB;

namespace RyuFoodClub
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
            services.AddSwaggerGen(c => {
                c.SwaggerDoc("v1",
                    new OpenApiInfo { Title = "RyuFoodClub", Version = "v1" });
            });
            string databaseType = Configuration["DatabaseType"];
            if (databaseType == "couchdb")
            {
                services.Configure<CouchDatabaseSettings>(
                    Configuration.GetSection(nameof(CouchDatabaseSettings)));
                services.AddSingleton<ICouchDatabaseSettings>(sp =>
                    sp.GetRequiredService<IOptions<CouchDatabaseSettings>>().Value);
        
                services.AddSingleton<ICouchDbContext, CouchDbContext>();
                services.AddSingleton<IDogService, RyuFoodClub.Model.CouchDB.DogService>();
                services.AddSingleton<IDogEventService, RyuFoodClub.Model.CouchDB.DogEventService>();
            }
            else if (databaseType == "mongodb")
            {  
                services.Configure<MongoDatabaseSettings>(
                    Configuration.GetSection(nameof(MongoDatabaseSettings)));
                services.AddSingleton<IMongoDatabaseSettings>(sp =>
                    sp.GetRequiredService<IOptions<MongoDatabaseSettings>>().Value);
        
                services.AddSingleton<IMongoDbContext, MongoDbContext>();
                services.AddSingleton<IDogService,
                    RyuFoodClub.Model.MongoDB.DogService>();
                services.AddSingleton<IDogEventService,
                    RyuFoodClub.Model.MongoDB.DogEventService>();
            }
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage()
                    .UseSwagger()
                    .UseSwaggerUI(c => {
                         c.SwaggerEndpoint("/swagger/v1/swagger.json", "RyuFoodClub v1");
                    });
            }

            app.UseHttpsRedirection()
                .UseRouting()
                .UseAuthorization()
                .UseEndpoints(endpoints =>
                 {
                    endpoints.MapControllers();
                });
        }
    }
}
