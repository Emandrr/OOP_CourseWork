using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MedicineManage.Domain.Models;
using MedicineManage.DataAccess.Interfaces;
using MedicineManage.UI.Pages;
using System.Collections.ObjectModel;
using MedicineManage.Aplication.Services;

namespace MedicineManage.UI.ViewModels
{
    [QueryProperty(nameof(PatientId), "PatientId")]
    public partial class PatientsDetailsViewModel : ObservableObject
    {
        private readonly DataBaseService _db;

        [ObservableProperty]
        Patient patient;



        [ObservableProperty]
        private ObservableCollection<Diagnosis> _diagnoses = new();
        [ObservableProperty]
        int _patientId;
        public PatientsDetailsViewModel(DataBaseService db)
        {
            _db = db;
        }
        partial void OnPatientIdChanged(int value)
        {
            LoadData(value);
        }
        [RelayCommand]
        public async Task DeletePatient()
        {
            await _db.DeletePatientAsync(Patient);
            await Shell.Current.GoToAsync("..");
            return;
        }
        [RelayCommand]
        public async Task EditPatient(Patient patient)
        {
            Dictionary<string, object> parameters = new()
            {
                { "PatientId", PatientId },
                { "Patient", Patient }
            };
            await Shell.Current.GoToAsync(nameof(EditPatientPage), parameters);
            return;
        }
        [RelayCommand]
        public async Task LoadData(int patientId)
        {
            Patient = await _db.GetPatientByIdAsync(patientId);
            var diagnosisList = await _db.GetPatientDiagnosesAsync(patientId);
            Diagnoses = new ObservableCollection<Diagnosis>(diagnosisList); 
            OnPropertyChanged(nameof(Patient));

            OnPropertyChanged(nameof(Diagnoses));
        }
        public async Task OnReturnFromEdit()
        {
         
            await LoadData(PatientId);
        }
        [RelayCommand]
        public async Task NavigateToFullInfo()
        {
            Dictionary<string, object> parameters = new()
            {
                { "PatientId", PatientId }
            };
            await Shell.Current.GoToAsync(nameof(PatientFullInfoPage), parameters);
            return;
        }
        [RelayCommand]
        public async Task AddDiagnosis()
        {
            Dictionary<string, object> parameters = new()
            {
                { "DiagnosisId", 0},
                { "PatientId", PatientId }
            };
            await Shell.Current.GoToAsync(nameof(DiagnosisInfoPage), parameters);
        }
        [RelayCommand]
        public async Task ShowDiagnosisDetails(Diagnosis diagnosis)
        {
            Dictionary<string, object> parameters = new()
            {
                { "DiagnosisId", diagnosis.Id},
                { "PatientId", PatientId},
                { "Diagnosis", diagnosis}
            };
            await Shell.Current.GoToAsync(nameof(DiagnosisInfoPage), parameters);
        }
    }
}