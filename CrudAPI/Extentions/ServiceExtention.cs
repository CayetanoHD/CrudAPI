using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;



namespace CrudAPI.Extentions
{
    public static class ServiceExtention
    {
        public static void AddSwaggerGenExtension(this IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                List<string> xmlFiles = Directory
                    .GetFiles(AppContext.BaseDirectory, "*.xml", SearchOption.TopDirectoryOnly)
                    .ToList();

                xmlFiles.ForEach(xmlFiles => options.IncludeXmlComments(xmlFiles));

                options.SwaggerDoc(
                    "v1",
                    new OpenApiInfo
                    {
                        Version = "v1",
                        Title = "Crud API",
                        Description = "This Api is a tecnic test",
                        Contact = new OpenApiContact { 
                            Name = "Jose Miguel Cayetano",
                            Email= "josemiguelcayetano01@gmail.com"
                        
                        }
                    }
                );

                
                options.DescribeAllParametersInCamelCase();

                
            });
        }

        public static void AddApiVersioningExtension(this IServiceCollection services)
        {
            services.AddApiVersioning(config =>
            {
                config.DefaultApiVersion = new ApiVersion(1, 0);
                config.AssumeDefaultVersionWhenUnspecified = true;
                config.ReportApiVersions = true;
            });
        }
    }
}
