using MedicineManage.DataAccess.Data;
using MedicineManage.DataAccess.Interfaces;
using MedicineManage.DataAccess.Repositories;
using MedicineManage.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MedicineManage.DataAccess
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistance(this IServiceCollection services)
        {
            services.AddScoped<IRepository<Diagnosis>,EfRepository<Diagnosis>>();
            services.AddScoped<IRepository<Patient>, EfRepository<Patient>>();
            return services;
        }

        public static IServiceCollection AddPersistance(this IServiceCollection services, DbContextOptions options)
        {
            services.AddPersistance()
            .AddSingleton<AppDbContext>(
            new AppDbContext((DbContextOptions<AppDbContext>)options));
            return services;
        }
    }
}
