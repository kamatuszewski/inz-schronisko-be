using AnimalShelter.Models;
using AnimalShelter.Services;
using AnimalShelter_WebAPI;
using AnimalShelter_WebAPI.DTOs.Requests;
using AnimalShelter_WebAPI.Middleware;
using AnimalShelter_WebAPI.Models.Validators;
using AnimalShelter_WebAPI.Seeders;
using AnimalShelter_WebAPI.Services.Animals;
using AnimalShelter_WebAPI.Services.VetVisitsDetails;
using AnimalShelter_WebAPI.Services.Roles;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnimalShelter_WebAPI.Services;
using AnimalShelter_WebAPI.Services.Persons.Volunteers;
using AnimalShelter_WebAPI.Services.Persons.Employees;
using AnimalShelter_WebAPI.Services.Adoptions;

namespace AnimalShelter
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

            var authenticationSettings = new AuthenticationSettings();
            Configuration.GetSection("Authentication").Bind(authenticationSettings);

            services.AddSingleton(authenticationSettings);

            services.AddAuthentication(option =>
            {
                option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                option.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(cfg =>
            {
                cfg.RequireHttpsMetadata = false;
                cfg.SaveToken = true;
                cfg.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidIssuer = authenticationSettings.JwtIssuer,
                    ValidAudience = authenticationSettings.JwtIssuer,
                    ValidateLifetime = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(authenticationSettings.JwtKey)),
                };
            });



            services.AddControllers().AddFluentValidation();

            services.AddDbContext<ShelterDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("DbContext"));

            });

            services.AddScoped<ShelterSeeder>();
            services.AddScoped<TestDataSeeder>(); //test data only

            services.AddScoped<IAnimalsService, AnimalsService>();
            services.AddScoped<IPersonsService, PersonsService>();
            services.AddScoped<IMedicinesService, MedicinesService>();
            services.AddScoped<ITreatmentsService, TreatmentsService>();
            services.AddScoped<IVetVisitsService, VetVisitsService>();
            services.AddScoped<IRolesService, RolesService>();
            services.AddScoped<IVetsService, VetsService>();
            services.AddScoped<IVolunteersService, VolunteersService>();
            services.AddScoped<IEmployeesService, EmployeesService>();
            services.AddScoped<IAdoptionsService, AdoptionsService>();
            services.AddScoped<ErrorHandlingMiddleware>();
            services.AddAutoMapper(this.GetType().Assembly);
            services.AddScoped<IPasswordHasher<Person>, PasswordHasher<Person>>();
            services.AddScoped<IValidator<RegisterPersonRequest>, RegisterPersonRequestValidator>();

            
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "AnimalShelter", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ShelterSeeder seeder, TestDataSeeder testDataSeeder)
        {
            seeder.Seed();  //pernament system data - roles, species, statuses
           

            if (env.IsDevelopment())
            {

            }

            testDataSeeder.SeedTestData();  //data added for testing purposes
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "AnimalShelter v1"));

            app.UseMiddleware<ErrorHandlingMiddleware>();
            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
