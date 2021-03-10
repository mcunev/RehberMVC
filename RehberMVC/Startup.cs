using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using RehberDataAcces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RehberDataAcces.Concrete.MsSqlServer;
using RehberDataAcces.Abstract;
using RehberDataAcces.Concrete;
using Rehber.Business.Concrete;
using Rehber.Business.Abstract;
using RehberMVC.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;

namespace RehberMVC
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
            services.AddScoped<IKisiListesiService, KisiListesiManager>();
            services.AddControllersWithViews();
            services.AddScoped <IKisiListesiDal, KisiListesiDal>();
            services.AddDbContext<ApplicationDbContext>(option=> option.UseSqlServer
            (Configuration.GetConnectionString("IdentityMssqlConnection")));
            services.AddIdentity<AppUser, IdentityRole>() //Angi user class'i ile calisacagini bildiriyoruz
                .AddEntityFrameworkStores<ApplicationDbContext>() // Hangi Context ile calisacak
                .AddDefaultTokenProviders();

            
                services.Configure<IdentityOptions>(options =>
                {
                    options.Password.RequireDigit = true; // Girilen sifre icerisinde sayisal alan istiyorsak true yapilir
                    options.Password.RequireLowercase = true; // Kucuk harf olsun mu ?
                    options.Password.RequiredLength = 6; //En az kac karakter oldugunu belirliyoruz
                    options.Password.RequireUppercase = true; // Buyuk Harf bulunma zorunlulugu


                    options.Lockout.MaxFailedAccessAttempts = 5; //Kac kere yanlis giris hakkini belirler
                    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5); // Yanlis giris hakki bitince ne kadar bekleyecegini belriler
                    options.Lockout.AllowedForNewUsers = true; //Yeni Kullanici icin de gecerli olacak mi 

                    //Default izin verilen karakterler :abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+
                    options.User.AllowedUserNameCharacters = "";//Izin verilen karakterleri burada tanimliyoruz
                    options.User.RequireUniqueEmail = false; // Bu mail ile bir kere kayit yapilabilir
                    options.SignIn.RequireConfirmedEmail = false; // Gonderilen mail confirm edilmez ise uyelik aktif olmaz
                    options.SignIn.RequireConfirmedPhoneNumber = false;
                });

            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/Account/Login"; //Default Login Ekrani
                options.LogoutPath = "/Account/Logout";
                options.AccessDeniedPath = "/Account/Accessdenied";
                options.SlidingExpiration = true;// 20 dakialik default cookie omru vardir. Eger 15. dakika da islem yaparsa extra bir 20 dakika daha uzatiyor

                options.Cookie = new CookieBuilder
                {
                    HttpOnly = true, // Tarayicida calisan diger scriptler bizim cookie'mize ulasamasin.Guvenlik icin gerekli
                    Name = "RehberMVC.Cookie",//Varsayilan ismin disinda bir isim vermek icin kullanilir
                    SameSite = SameSiteMode.Strict //Cross site ataklari engeller. Yani bizim tarayicimiz disinda kullanilmasini engeller

                };
                options.ExpireTimeSpan = TimeSpan.FromMinutes(60); // Cookie'nin yasam suresi
            });
        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }

       
    
}
