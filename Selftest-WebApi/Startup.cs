using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Selftest_WebApi.Data;
using Selftest_WebApi.Services.AnimalServices;
using Selftest_WebApi.Services.BookServices;
using Selftest_WebApi.Services.CharacterServices;
using Selftest_WebApi.Services.ClientServices;
using Selftest_WebApi.Services.CostumerServices;
using Selftest_WebApi.Services.EmployeeServices;
using Selftest_WebApi.Services.PGCServices;
using Selftest_WebApi.Services.PlantsServices;
using Selftest_WebApi.Services.SchoolServices;
using Selftest_WebApi.Services.StudentServices;
using Selftest_WebApi.Services.TeacherServices;
using Selftest_WebApi.Services.UserServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Selftest_WebApi
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



            services.AddAutoMapper(typeof(Startup));
            services.AddDbContext<DataContext>(x => x.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IUserServices, User>();
           
            services.AddScoped<IEmployeeService, EmployeeService>();
            
            services.AddScoped<IClientServices, ClientServices>();

            services.AddScoped<ICharacterServices,CharacterService >();

            services.AddScoped<IBookService,BookService>();
            
            services.AddScoped<IAnimalService,AnimalService>();

            services.AddScoped<IStudentService,StudentService>();

            services.AddScoped<ITeacherServicecs, Teacher>();

            services.AddScoped<IPlantsService, PlantsService>();

            services.AddScoped<ISchoolService,SchoolService>(); 

            services.AddScoped<ICostumerService,CostumerService>();

            services.AddScoped<IPGCServices, PgcService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
