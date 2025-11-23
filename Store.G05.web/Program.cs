
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Store.G05.Domain.Contracts;
using Store.G05.Presistence;
using Store.G05.Presistence.Data.Contexts;
using Store.G05.Services;
using Store.G05.Services.Abstractions;
using Store.G05.Services.Mapping;
using Store.G05.Shared.ErrorModels;
using Store.G05.web.Extensions;
using Store.G05.web.Middlewares;
using System.Threading.Tasks;

namespace Store.G05.web
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.RegisterAllServices(builder.Configuration);

            var app = builder.Build();

            await app.ConfigureMiddleWares();
            
            app.Run();
        }
    }
}
