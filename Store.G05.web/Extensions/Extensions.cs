using Microsoft.AspNetCore.Mvc;
using Store.G05.Domain.Contracts;
using Store.G05.Presistence;
using Store.G05.Services;
using Store.G05.Shared.ErrorModels;
using Store.G05.web.Middlewares;

namespace Store.G05.web.Extensions
{
    public static class Extensions
    {
        public static IServiceCollection RegisterAllServices(this IServiceCollection services, IConfiguration configuration)
        {
           services.AddControllers();

            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            services.AddInfrastructureServices(configuration);
            services.AddApplicationServices(configuration);

            services.Configure<ApiBehaviorOptions>(config =>
            {
                config.InvalidModelStateResponseFactory = (actionContext) =>
                {
                    var errors = actionContext.ModelState.Where(m => m.Value.Errors.Any())
                    .Select(m => new ValidationError()
                    {
                        Field = m.Key,
                        Errors = m.Value.Errors.Select(e => e.ErrorMessage)
                    });
                    var responce = new ValidationErrorResponce()
                    {
                        Errors = errors
                    };

                    return new BadRequestObjectResult(responce);
                };
            }
            );

            return services ;
        }


        public static async Task<WebApplication> ConfigureMiddleWares(this WebApplication app) {
            //Ask CLR to Create Object from IDbInializer
            using var scope = app.Services.CreateScope();
            var dbInializer = scope.ServiceProvider.GetRequiredService<IDbInitializer>();
            await dbInializer.InitializeAsync();
            //
            app.UseStaticFiles();
            app.UseMiddleware<GlobleErrorHandlingMiddleware>();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            return app;
        }
    }
}
