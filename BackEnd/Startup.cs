using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BackEnd.Contexts;
using BackEnd.DTOs;
using BackEnd.Models;
using BackEnd.Repositories;
using BackEnd.Repositories.Implements;
using BackEnd.Services;
using BackEnd.Services.Implements;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace BackEnd
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

            // Configuracion de los CORS
            services.AddCors();

            //Configurar ApplicationDbContext
            services.AddDbContext<ApplicationDbContext>(options => 
                options.UseSqlServer(Configuration.GetConnectionString("defaultConnection")));

            // Configuracion del identity
            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            services.Configure<IdentityOptions>(options =>
            {
                
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.AllowedForNewUsers = true;

                // Configuracion de password
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 0;

                // Configuracion de SignIn.
                options.SignIn.RequireConfirmedEmail = false;
                options.SignIn.RequireConfirmedPhoneNumber = false;


                // Configuraciones del Usuario
                //Caracteres permitidos en el username
                options.User.AllowedUserNameCharacters =
                        "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                options.User.RequireUniqueEmail = true;
            });

            // using Microsoft.AspNetCore.Identity;
            services.Configure<PasswordHasherOptions>(option =>
            {
                option.IterationCount = 12000;
            });

            // Configuracion del JWTs
            services.AddAuthentication(x =>
            {
                //  Configurar que el Authorize por defecto sea JwtBearer
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(Configuration["JWT:key"])), // llave en las configuraciones
                    ClockSkew = TimeSpan.Zero
                });


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);


            // AutoMapper , Transformacion de las entidades a DTOs
            services.AddAutoMapper(options =>
            {
                options.CreateMap<BranchDTO, Branch>();
                options.CreateMap<CategoryDTO, Category>();
                options.CreateMap<OrderDTO, Order>();
                options.CreateMap<PayTypeDTO, PayType>();
                options.CreateMap<ProductDTO, Product>();
                options.CreateMap<RestaurantDTO, Restaurant>();
                options.CreateMap<RestaurantCategoryDTO, RestaurantCategory>();
                options.CreateMap<SaleDTO, Sale>();
                options.CreateMap<StateDTO, State>();
            });

            // Repositories
            services.AddScoped<IBranchRepository, BranchRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IPayTypeRepository, PayTypeRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IRestaurantRepository, RestaurantRepository>();
            services.AddScoped<ISaleRepository, SaleRepository>();
            services.AddScoped<IStateRepository, StateRepository>();
            services.AddScoped<IRestaurantCategoryRepository, RestaurantCategoryRepository>();

            // Services
            services.AddSingleton<IBranchService, BranchService>();
            services.AddSingleton<ICategoryService, CategoryService>();
            services.AddSingleton<IOrderService, OrderService>();
            services.AddSingleton<IPayTypeService, PayTypeService>();
            services.AddSingleton<IProductService, ProductService>();
            services.AddSingleton<IRestaurantService, RestaurantService>();
            services.AddSingleton<ISaleService, SaleService>();
            services.AddSingleton<IStateService, StateService>();
            services.AddSingleton<IRestaurantCategoryService, RestaurantCategoryService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            // Configuracion de los CORS
            app.UseCors(builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

            app.UseHttpsRedirection();


            // Configuracion de data por defecto en la base de datos
            using (var scope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var context = scope.ServiceProvider.GetService<ApplicationDbContext>();
                context.Database.Migrate();
                context.EnsureDatabaseSeeded();
            }

            // Activar sistema de autenticacion
            app.UseAuthentication(); 
            app.UseMvc();
        }
    }
}
