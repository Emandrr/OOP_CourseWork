using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MedicineManage.DataAccess.Interfaces;
using MedicineManage.DataAccess.Repositories;
using MedicineManage.Domain.Models;
namespace MedicineManage.Aplication.Services
{
    public class DataBaseService
    {
        private readonly IRepository<Patient> _patientRepository;
        private readonly IRepository<Diagnosis> _diagnosisRepository;
        public DataBaseService(IRepository<Patient> patientsRepository,IRepository<Diagnosis> diagnosisRepository)
        {
            _patientRepository = patientsRepository;
            _diagnosisRepository = diagnosisRepository;
        }
        public async Task<List<Patient>> GetAllPatientsByNameAsync(string name)
        {
            var results = await _patientRepository.GetAllByNameAsync(name);

            return results;
        }
        public async Task AddPatientAsync(Patient patient)
        {
            await _patientRepository.AddAsync(patient);
            await _patientRepository.SaveAllAsync();
            return;
        }
        public async Task UpdatePatientAsync(Patient patient)
        {
            await _patientRepository.UpdateAsync(patient);
            await _patientRepository.SaveAllAsync();
            return;
        }
        public async Task<Patient> GetPatientByIdAsync(int id)
        {
            return await _patientRepository.GetByIdAsync(id);
        }

        public async Task DeletePatientAsync(Patient patient)
        {
            await _patientRepository.DeleteAsync(patient);
            await _patientRepository.SaveAllAsync();
            
        }
        public async Task<List<Diagnosis>> GetPatientDiagnosesAsync(int id)
        {
             var lst = await _diagnosisRepository.ListAllAsync();
             return lst.Where(p=>p.PatientId == id).ToList();
        }
        public async Task AddDiagnosisAsync(Diagnosis diagnosis)
        {
            await _diagnosisRepository.AddAsync(diagnosis);
            await _diagnosisRepository.SaveAllAsync();
            return;
        }
        public async Task UpdateDiagnosisAsync(Diagnosis diagnosis)
        {
            await _diagnosisRepository.UpdateAsync(diagnosis);
            await _diagnosisRepository.SaveAllAsync();
            return;
        }
        public async Task<Diagnosis> GetDiagnosisByIdAsync(int id)
        {
            return await _diagnosisRepository.GetByIdAsync(id);
        }

        public async Task DeleteDiagnosisAsync(Diagnosis diagnosis)
        {
            await _diagnosisRepository.DeleteAsync(diagnosis);
            await _diagnosisRepository.SaveAllAsync();

        }
    }
}
