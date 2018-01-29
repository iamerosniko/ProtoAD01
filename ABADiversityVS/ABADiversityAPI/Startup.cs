using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ABADiversityAPI.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Serialization;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace ABADiversityAPI
{
  public class Startup
  {
    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    public static IConfiguration Configuration { get; private set; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
      services.AddMvc();
      services.AddDbContext<ABAContext>(cfg =>
      {
        cfg.UseSqlServer(Configuration["DBConnectionString"]);
      });

    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }

      //AutoMapper.Mapper.Initialize(
      //              cfg =>
      //              {
      //                cfg.CreateMap<Entities.SetUser, Models.SetUserDTO>();
      //                cfg.CreateMap<Entities.SetGroup, Models.SetGroupDTO>();
      //                cfg.CreateMap<Models.AssociateForCreateDTO, Entities.Associate>()
      //                        .ForMember(dest => dest.UpdatedOn, opt => opt.MapFrom(o => DateTime.Now))
      //                        .ForMember(dest => dest.IsActive, opt => opt.MapFrom(o => true));
      //                cfg.CreateMap<Models.AssociateForUpdateDTO, Entities.Associate>()
      //                        .ForMember(dest => dest.UpdatedOn, opt => opt.MapFrom(o => DateTime.Now));
      //                cfg.CreateMap<Models.DepartmentForCreateDTO, Entities.Department>()
      //                        .ForMember(dest => dest.IsActive, opt => opt.MapFrom(o => true));
      //                cfg.CreateMap<Models.DepartmentForUpdateDTO, Entities.Department>();
      //                cfg.CreateMap<Models.LocationForCreateDTO, Entities.Location>()
      //                        .ForMember(dest => dest.IsActive, opt => opt.MapFrom(o => true));
      //                cfg.CreateMap<Models.LocationForUpdateDTO, Entities.Location>();
      //                cfg.CreateMap<Models.SkillsetForCreateDTO, Entities.Skillset>()
      //                        .ForMember(dest => dest.IsActive, opt => opt.MapFrom(o => true));
      //                cfg.CreateMap<Models.SkillsetForUpdateDTO, Entities.Skillset>();
      //                cfg.CreateMap<Models.DepartmentSkillsetForCreateDTO, Entities.DepartmentSkillset>();
      //                cfg.CreateMap<Models.AssociateDepartmentSkillsetForCreateDTO, Entities.AssociateDepartmentSkillset>();
      //              });

      app.UseMvc();
    }
  }
}
