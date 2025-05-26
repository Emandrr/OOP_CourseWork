using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MedicineManage.Aplication.Services;
using MedicineManage.DataAccess.Interfaces;
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
    [QueryProperty(nameof(Patient), "Patient")]
    public partial class EditPatientViewModel : ObservableObject
    {
        private readonly DataBaseService _db;
        [ObservableProperty]
        Patient patient = new();

        [ObservableProperty]
        int _patientId=0;
        public EditPatientViewModel(DataBaseService db)
        {
            _db = db;
            
        }
        partial void OnPatientIdChanged(int value)
        {
            LoadData(value);
        }
        [RelayCommand]
        private async Task LoadData(int patientId)
        {
            Patient = await _db.GetPatientByIdAsync(patientId);
        }
        [RelayCommand]
        private async Task SavePatient()
        {
            try
            {
                if (string.IsNullOrWhiteSpace(Patient.Name))
                {
                    await Shell.Current.DisplayAlert("Ошибка", "ФИО обязательно для заполнения", "OK");
                    return;
                }

                if (Patient.Id > 0)
                {
                    await _db.UpdatePatientAsync(Patient);
                    var pt = await _db.GetPatientByIdAsync(PatientId);
                    Patient = new Patient();
                    await Task.Delay(10);
                    Patient = pt;
                    //OnPropertyChanged(nameof(Patient));
                    await Shell.Current.DisplayAlert("Успех", "Данные пациента обновлены", "OK");
                }
                else
                {
                    await _db.AddPatientAsync(Patient);
                    await Shell.Current.DisplayAlert("Успех", "Пациент добавлен", "OK");
                }

                await Shell.Current.GoToAsync("..");
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Ошибка", ex.Message, "OK");
            }
        }
    }
}

