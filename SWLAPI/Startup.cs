using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SWLAPI.Authentication.AuthScheme;
using SWLAPI.DB;
using SWLAPI.DB.Context;
using SWLAPI.Services;
using SWLAPI.DataProvider;

namespace SWLAPI
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
            services.AddMvc();

            var connection = Configuration.GetConnectionString("DefaultConnection");
            services.AddSingleton(x => new ApplicationDataProvider(connection));

            services.AddAuthentication(o => { o.DefaultScheme = SchemesNamesConst.SecretAuthenticationHandler; })
                .AddScheme<SecretAuthenticationHandler.SecretAuthenticationSchemeOptions, SecretAuthenticationHandler>
                    (SchemesNamesConst.SecretAuthenticationHandler, o => { });
            services.AddSingleton(typeof(MainEventBus));
            services.AddSingleton(typeof(MainEventBusListener));
            services.AddSingleton(typeof(MailSender));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            CheckVersionDB(app);
            app.ApplicationServices.GetService<MainEventBusListener>().InitListeners();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // app.ApplicationServices.GetRequiredService<MainEventBusListener>().InitListeners();
            app.UseMvc();
        }

        private void CheckVersionDB(IApplicationBuilder app)
        {
            // using (var scope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            // {
            //     scope.ServiceProvider.GetRequiredService<Context>().Database.Migrate();
            // }
        }
    }
}