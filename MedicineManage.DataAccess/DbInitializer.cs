using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MedicineManage.DataAccess.Interfaces;
using MedicineManage.Domain.Models;
namespace MedicineManage.DataAccess
{
    public class DbInitializer
    {
        public static async Task Initialize(IServiceProvider services)
        {
            var srv = services.GetRequiredService<IRepository<Patient>>();
            await srv.CreateDataBaseAsync();
        }
    }
}
