using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicineManage.Domain.Models
{
    public class Patient : Entity
    {
        public DateTime BirthDate { get; set; } = DateTime.Now;
        public string? Gender { get; set; }
        public string? Address { get; set; }
        public string? PhoneNumber { get; set; }
        public string? AdditionalInfo { get; set; }

    }
}
