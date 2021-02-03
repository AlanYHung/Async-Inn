using Asyn_Inn.Data;
using Asyn_Inn.Interfaces;
using Asyn_Inn.Interfaces.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asyn_Inn
{
  public class Startup
  {
    public IConfiguration Configuration { get; }

    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    // This method gets called by the runtime. Use this method to add services to the container.
    // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
    public void ConfigureServices(IServiceCollection services)
    {
      services.AddMvc();
      services.AddControllers();
      services.AddControllers().AddNewtonsoftJson(options =>
                                                  options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
      services.AddDbContext<AsyncInnDbContext>(options => {
        // Our DATABASE_URL from js days
        string connectionString = Configuration.GetConnectionString("DefaultConnection");
        options.UseSqlServer(connectionString);
      });

      services.AddSwaggerGen(options =>
      {
        options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo()
        {
          Title = "Async Inn",
          Version = "v1"
        });
      });

      services.AddTransient<IRoom, RoomRepository>();
      services.AddTransient<IHotel, HotelRepository>();
      services.AddTransient<IAmenities, AmenityRepository>();
      services.AddTransient<IHotelRoom, HotelRoomRepository>();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }

      app.UseRouting();

      app.UseSwagger(option =>
      {
        option.RouteTemplate = "/api/{documentName}/swagger.json";
      });
      app.UseSwaggerUI(options =>
      {
        options.SwaggerEndpoint("api/v1/swagger.json", "School Demo");
        options.RoutePrefix = "";
      });
    }
  }
}
