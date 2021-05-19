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
using UrskiyPeriodBusinessLogic.Interfaces;
using UrskiyPeriodBusinessLogic.BusinessLogics;
using UrskiyPeriodDatabaseImplement.Implements;

namespace UrskiyPeriodRestApi
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
            services.AddTransient<IUserStorage, UserStorage>();
            services.AddTransient<ICostItemStorage, CostItemStorage>();
            services.AddTransient<IReserveStorage, ReserveStorage>();
            services.AddTransient<IRouteStorage, RouteStorage>();
            services.AddTransient<IPaymentStorage, PaymentStorage>();
            services.AddTransient<UserLogic>();
            services.AddTransient<CostItemLogic>();
            services.AddTransient<ReserveLogic>();
            services.AddTransient<RouteLogic>();
            services.AddTransient<PaymentLogic>();
            services.AddTransient<ReportLogic>();
            services.AddControllers().AddNewtonsoftJson();
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

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
