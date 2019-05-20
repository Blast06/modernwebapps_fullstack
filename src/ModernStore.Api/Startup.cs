using System;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using ModernStore.Api.Security;
using ModernStore.Domain.Commands.Handlers;
using ModernStore.Domain.Repositories;
using ModernStore.Domain.Services;
using ModernStore.Infra.Contexts;
using ModernStore.Infra.Repositories;
using ModernStore.Infra.Services;
using ModernStore.Infra.Transactions;
using ModernStore.Shared;
using Newtonsoft.Json.Serialization;
using Swashbuckle.AspNetCore.Swagger;

namespace ModernStore.Api
{
    public class Startup
    {
        public IConfiguration Configuration { get; set; }
        private const string ISSUER = "c1f18f15"; //here is the key to be used internaly with JWT. I can put
        private const string AUDIENCE = "c6bfeb185015"; //anything here, doesn't matter. I can put "pera and
        private const string SECRET_KEY = "c1f18f42-5727-4d15-b787-c6bbbb185015"; //"maça" instead of this.

        private readonly SymmetricSecurityKey _signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(SECRET_KEY));

        public Startup(IHostingEnvironment env)
        {
            var configurationBuilder = new ConfigurationBuilder()
               .SetBasePath(env.ContentRootPath)
               .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
               .AddEnvironmentVariables();
            Configuration = configurationBuilder.Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(config =>
            {
                //here i configure my policies: Blocking ALL API Access. If i want to allow some WebApi Method to be
                //called without Authentication, i can use the Decorator [AllowAnonimous] to do it.
                var policy = new AuthorizationPolicyBuilder()
                                 .RequireAuthenticatedUser()
                                 .Build();
                config.Filters.Add(new AuthorizeFilter(policy));
            });
            services.AddCors();

            services.AddAuthorization(options =>
            {
                //here i define that i'll have to policies, for Users and Admins (this is just
                //the NAMES, i'll define what they do/means after).
                //options.AddPolicy("User", policy => policy.RequireClaim("ModernStore", "User"));
                //options.AddPolicy("Admin", policy => policy.RequireClaim("ModernStore", "Admin"));
                //i can have more complex policies, for example, get on DataBase if that user belongs to Admin Rules or something:

                options.AddPolicy("User", policy => policy.RequireClaim("ModernStore", "User"));
                options.AddPolicy("Admin", policy => policy.RequireClaim("ModernStore", "Admin"));
            });



            services.Configure<TokenOptions>(options =>
            {
                options.Issuer = ISSUER;
                options.Audience = AUDIENCE;
                options.SigningCredentials = new SigningCredentials(_signingKey, SecurityAlgorithms.HmacSha256);
            });

            //difference between Scoped and Transient is that: when you start app (server), will be created just ONE instance
            //of "ModernStoreDataContext". The SAME instance will be passed always when someone asks for ModernStoreDataContext.
            //(so, because transations and UOW, this is the solution!). The transient will always create a new object. So i say
            //what's is the interface, and what's the implementation to it. So Scoped is SINGLETON and AddTransient is new object. 
            services.AddScoped<ModernStoreDataContext, ModernStoreDataContext>();
            services.AddTransient<IUow, Uow>();

            services.AddTransient<ICustomerRepository, CustomerRepository>();
            services.AddTransient<IOrderRepository, OrderRepository>();
            services.AddTransient<IProductRepository, ProductRepository>();

            services.AddTransient<IEmailService, EmailService>();

            services.AddTransient<CustomerCommandHandler, CustomerCommandHandler>();
            services.AddTransient<OrderCommandHandler, OrderCommandHandler>();

            //i had to ADD this Line because PostMan and AspNet Core are not in a mood...
            services.AddMvc().AddJsonOptions(x => x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            ////i had to add this line, because MVC is converting my DTOs to Lowercase, so instead of "UserName" it's taking "userName" (even if class is UserName).
            services.AddMvc().AddJsonOptions(options => options.SerializerSettings.ContractResolver = new DefaultContractResolver());

            services.AddDbContext<ModernStoreDataContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddSwaggerGen(x =>
            {
                //method to SWAGGER (OpenApi) works:
                x.SwaggerDoc("v1", new Info { Title = "ModernStore API", Version = "v1" });
            });
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidIssuer = ISSUER,

                ValidateAudience = true,
                ValidAudience = AUDIENCE,

                ValidateIssuerSigningKey = true,
                IssuerSigningKey = _signingKey,

                RequireExpirationTime = true,
                ValidateLifetime = true,

                ClockSkew = TimeSpan.Zero
            };

            //app.UseJwtBearerAuthentication(new JwtBearerOptions
            //{
            //    AutomaticAuthenticate = true,
            //    AutomaticChallenge = true,
            //    TokenValidationParameters = tokenValidationParameters
            //});

            app.UseCors(x =>
            {
                x.AllowAnyHeader();
                x.AllowAnyMethod();
                x.AllowAnyOrigin();
            });

            app.UseMvc();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "FutureOfMedia - V1");
            });
            //app.UseAuthentication();

            //WOW, when i do it here, my runtime connection string will be available everywhere
            //Including in Repo Project (in my Dapper Get Methods - that's brilliant!).
            Runtime.ConnectionString = Configuration.GetConnectionString("DefaultConnection");
        }
    }
}