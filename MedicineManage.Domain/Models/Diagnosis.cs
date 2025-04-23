using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicineManage.Domain.Models
{
    class Diagnosis
    {
        public int Id { get; set; }
        public string? Code { get; set; }
        public string? Description { get; set; }
        public DateTime DiagnosisDateCreation { get; set; }
        public DateTime? DiagnosisDateLastUpdate { get; set; }
        public string? Notes { get; set; }
        public string? MediacalAddress { get; set; }
        public string? PatientId { get; set; }
    }
}
