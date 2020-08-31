using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using HSCoreApp.Models;
using Microsoft.AspNetCore.HttpOverrides;

namespace HSCoreApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddMemoryCache();
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IMemoryCache cache)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }
            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
            });
           
            app.UseStaticFiles();
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });

           List<Movie> Movieobj = new List<Movie>()
            {
                new Movie() {Id=1,Name="How to install Docker and Nginx Web Server on Azure Linux VM",Link="https://www.youtube.com/watch?v=o7CJdYucKLY&t=15s"},
                new Movie() {Id=2,Name="How to use Selenium for Microsoft Dynamics CRM (C#, PhantomJS e Chrome)",Link="https://www.youtube.com/watch?v=krtGDSCQCqM&t=42s"},
                new Movie() {Id=3,Name="How to Build a Bot for Coinbase Pro",Link="https://www.youtube.com/watch?v=caBGyU2HufU&t=1091s"},
                new Movie() {Id=4,Name="Is it a good time to buy bitcoin? Doing analysis with Power BI",Link="https://www.youtube.com/watch?v=BzNyKcotric&t=272s"},
            };
            int count = 3;
            cache.Set("dtset", Movieobj);
            cache.Set("count", count);

        }
    }
}
