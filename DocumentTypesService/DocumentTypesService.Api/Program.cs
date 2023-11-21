using DocumentTypesService.Core.Entities;
using DocumentTypesService.Core.Interfaces;
using DocumentTypesService.Core.Services;
using DocumentTypesService.Infraestructure.Mappings;
using DocumentTypesService.Infraestructure.Repositories;
using DocumentTypesService.Infraestructure.Validators;
using FluentValidation;
using FluentValidation.AspNetCore;

namespace DocumentTypesService.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.Configure<DocumentTypesDatabaseSettings>(
                builder.Configuration.GetSection("DocumentTypesDatabase"));

            builder.Services.AddAutoMapper(typeof(AutoMapperProfile));
            builder.Services.AddFluentValidationAutoValidation();
            builder.Services.AddValidatorsFromAssemblyContaining<DocumentTypeValidator>();

            //builder.Services.AddValidatorsFromAssembly(Assembly.Load("DocumentTypesService.Infraestructure"));

            builder.Services.AddSingleton<IDocumentTypeRepository, DocumentTypeRepository>();
            builder.Services.AddScoped<IDocumentTypeService, DocumentTypeService>();

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
