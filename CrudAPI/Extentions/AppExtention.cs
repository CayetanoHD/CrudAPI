namespace CrudAPI.Extentions
{
    public static class AppExtention
    {
        public static void UseSwaggerExtention(this  IApplicationBuilder application)
        {
            application.UseSwagger();
            application.UseSwaggerUI(opt =>
            {
                opt.SwaggerEndpoint("/swagger/v1/swagger.json", "CrudAPI");
                

            });

        }
    }
}
