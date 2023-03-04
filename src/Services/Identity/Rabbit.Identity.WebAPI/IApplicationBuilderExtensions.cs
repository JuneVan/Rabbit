namespace Rabbit.Identity.WebAPI
{
    public static class IApplicationBuilderExtensions
    {
        public static void UseIdentity(this IApplicationBuilder app, IConfiguration configuration, IWebHostEnvironment env, string routePrefix)
        {
            if (!env.IsProduction() && !routePrefix.IsNullOrEmpty())
            {
                UseSwaggerWithPrefix(app, routePrefix);
            }
            app.UseCors(WebAPIDefaults.CorsName);
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

        }
        private static void UseSwaggerWithPrefix(IApplicationBuilder app, string routePrefix)
        {
            app.UseSwagger(c =>
            {
                c.RouteTemplate = routePrefix + "/swagger/{documentName}/swagger.json";
            });
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint($"/{routePrefix}/swagger/v1/swagger.json", "Rabbit.Identity");
                c.RoutePrefix = routePrefix + "/swagger";
            });
        }
    }
}
