﻿using CsvJoin.Abstractions;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace CsvJoin
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var services = new ServiceCollection();

            ConfigureServices(services);

            var serviceProvider = services.BuildServiceProvider();

            await serviceProvider.GetService<Application>().RunAsync(args);
        }

        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<ISqlPreparator, SqlPreparator>();

            services.AddTransient<ISqlFormatter, SqlFormatter>();

            services.AddTransient<ISqlExecutor, SqlExecutor>();

            services.AddTransient<ISqlSaver, SqlSaver>();

            services.AddTransient<Application>();
        }
    }
}
