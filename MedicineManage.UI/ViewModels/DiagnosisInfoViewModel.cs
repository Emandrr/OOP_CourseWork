using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MedicineManage.Aplication.Services;
using MedicineManage.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicineManage.UI.ViewModels
{
    [QueryProperty(nameof(DiagnosisId), "DiagnosisId")]
    [QueryProperty(nameof(PatientId), "PatientId")]
    [QueryProperty(nameof(Diagnosis), "Diagnosis")]
    public partial class DiagnosisInfoViewModel : ObservableObject
    {
        private readonly DataBaseService _db;
        [ObservableProperty]
        Diagnosis diagnosis = new();

        [ObservableProperty]
        int _diagnosisId = 0;

        [ObservableProperty]
        int _patientId = 0;
        public DiagnosisInfoViewModel(DataBaseService db)
        {
            _db = db;

        }
        partial void OnDiagnosisIdChanged(int value)
        {
            LoadData(value);
        }
        [RelayCommand]
        private async Task LoadData(int diagnosisId)
        {
            Diagnosis = await _db.GetDiagnosisByIdAsync(diagnosisId);
        }
        [RelayCommand]
        private async Task SaveDiagnosis()
        {
            try
            {
                if (string.IsNullOrWhiteSpace(Diagnosis.Name))
                {
                    await Shell.Current.DisplayAlert("Ошибка", "Название обязательно для заполнения", "OK");
                    return;
                }

                if (Diagnosis.Id > 0)
                {
                    await _db.UpdateDiagnosisAsync(Diagnosis);
                    var pt = await _db.GetDiagnosisByIdAsync(DiagnosisId);
                    Diagnosis = new Diagnosis();
                    await Task.Delay(10);
                    Diagnosis = pt;
                    //OnPropertyChanged(nameof(diagnosis));
                    await Shell.Current.DisplayAlert("Успех", "Данные пациента обновлены", "OK");
                }
                else
                {
                    Diagnosis.PatientId = PatientId;
                    await _db.AddDiagnosisAsync(Diagnosis);
                    await Shell.Current.DisplayAlert("Успех", "Пациент добавлен", "OK");
                }

                await Shell.Current.GoToAsync("..");
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Ошибка", ex.Message, "OK");
            }
        }
        [RelayCommand]
        private async Task Analyze()
        {
            int k = 0;
        }
    }
}
