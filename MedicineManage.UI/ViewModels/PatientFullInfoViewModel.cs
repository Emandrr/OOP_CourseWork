using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MedicineManage.Aplication.Services;
using MedicineManage.Domain.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicineManage.UI.ViewModels
{
    [QueryProperty(nameof(PatientId), "PatientId")]
    public partial class PatientFullInfoViewModel : ObservableObject
    {
        private readonly DataBaseService _db;
        [ObservableProperty]
        private Patient _patient;
        [ObservableProperty]
        int _patientId;
        public PatientFullInfoViewModel(DataBaseService db)
        {
            _db = db;
        }
        partial void OnPatientIdChanged(int value)
        {
            LoadData(value);
        }
        [RelayCommand]
        public async Task LoadData(int patientId)
        {
            Patient = await _db.GetPatientByIdAsync(patientId);
            OnPropertyChanged(nameof(Patient));
        }
    }
}
