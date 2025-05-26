using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MedicineManage.Domain.Models;
namespace MedicineManage.DataAccess.Data
{
    public class AppDbContext : DbContext
    {
        DbSet<Patient> Patients { get; }
        DbSet<Diagnosis> Diagnoses { get; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
