
using Domain.Contracts;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Persistence;
using Persistence.Data;
using Services;
using Services.Abstractions;
using Shared.ErrorModels;
using Store.API.Extensions;
using Store.API.MiddleWares;

namespace Store.API
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.RegisterAllServices(builder.Configuration);

            var app = builder.Build();

            // Configure the HTTP request pipeline.

            await app.ConfigureMiddlewares();

            app.Run();
        }
    }
}
