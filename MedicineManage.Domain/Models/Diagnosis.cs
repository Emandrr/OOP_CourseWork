using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicineManage.Domain.Models
{
    public class Diagnosis : Entity
    {
        public string? Code { get; set; }
        public string? Description { get; set; }
        public DateTime DiagnosisDateCreation { get; set; }
        public DateTime? DiagnosisDateLastUpdate { get; set; }
        public string? Notes { get; set; }
        public string? MedicalAddress { get; set; }
        public int? PatientId { get; set; }
    }
}
