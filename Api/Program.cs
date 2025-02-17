
using Api.Features.QRCodeToken.Common.TokensProvider;
using Api.Infrastructure.DbContext;
using Api.Infrastructure.Storage;
using Azure.Storage.Blobs;
using Carter;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Reflection;
using System.Text;
using System.Text.Json.Serialization;

namespace Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddCors(options =>
            {
                options.AddDefaultPolicy(policy =>
                {
                    policy.AllowAnyMethod()
                          .AllowAnyHeader()
                          .WithMethods("GET")
                          .WithOrigins("http://localhost:8804")
                          .AllowCredentials();
                });
            });
            builder.Services.AddAuthentication();
            builder.Services.AddCarter();
            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.RequireHttpsMetadata = false;
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
           // IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
        };
    });



            builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            builder.Services.AddSingleton<QRCodeTokenProvider>();
            builder.Services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly());
            });
            builder.Services.AddControllers().AddJsonOptions(option =>
            {

                option.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
                option.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
            }
                );
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(option =>
            {
                option.SupportNonNullableReferenceTypes();
                option.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = $"Api do Ministrant Go 1.0 {char.ConvertFromUtf32(0x1F4F1)}", 
                });

                option.EnableAnnotations();

            });
            builder.Services.AddDbContext<ApplicationContext>(options =>
            {
                options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
            });
            builder.Services.AddScoped<IApplicationContext, ApplicationContext>();

            builder.Services.AddSingleton<IBlobService, BlobService>();
            builder.Services.AddSingleton(x =>
                     new BlobServiceClient(builder.Configuration.GetConnectionString("BlobStorage")));


            var app = builder.Build();
            app.UseCors();
         
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();
            app.MapCarter();

            app.UseAuthentication();

            app.MapControllers();

            app.Run();
        }
    }
}
