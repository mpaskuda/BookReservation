using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookReservationAPI.DatabaseContext;
using BookReservationAPI.Models;
using BookReservationAPI.Repository;
using Microsoft.EntityFrameworkCore;

namespace BookReservationAPI
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

            services.AddDbContext<BookContext>(options => options.UseSqlServer(Configuration["ConnectionString:CarDB"]));
            services.AddDbContext<ReservationContext>(options => options.UseSqlServer(Configuration["ConnectionString:CarDB"]));
            services.AddDbContext<UserContext>(options => options.UseSqlServer(Configuration["ConnectionString:CarDB"]));

            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
            });
            services.AddScoped<IBookRepository<BookModel>, BookRepository>();
            services.AddScoped<IReservationRepository<ReservationModel>, ReservationRepository>();
            services.AddScoped<IUserRepository<UserModel>, UserRepository>();

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            // Nazwa u¿ywanej polityki zosta³a zdefiniowana w metodzie ConfigureServices(...)
            app.UseCors("CorsPolicy");

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
