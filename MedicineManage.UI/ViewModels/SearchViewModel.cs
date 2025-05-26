using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MedicineManage.Domain.Models;
using System.Collections.ObjectModel;
using MedicineManage.Aplication.Services;
using MedicineManage.UI.Pages;
namespace MedicineManage.UI.ViewModels
{
    public partial class SearchViewModel : ObservableObject
    {
        private readonly DataBaseService _db;
        private readonly IServiceProvider _serviceProvider;
        [ObservableProperty]
        private string _searchText = string.Empty;

        [ObservableProperty]
        private ObservableCollection<Patient> _patients = new();

        [ObservableProperty]
        private Patient _editingPatient;

        [ObservableProperty]
        private bool _isBusy;

        [ObservableProperty]
        private bool _showEditFor;

        public SearchViewModel(DataBaseService dbService, IServiceProvider serviceProvider)
        {
            _db = dbService;
            _serviceProvider = serviceProvider;
        }

        [RelayCommand]
        public async Task Search()
        {
            if (IsBusy) return;

            try
            {
                IsBusy = true;
                Patients.Clear();
                var results = await _db.GetAllPatientsByNameAsync(SearchText);

                foreach (var patient in results)
                {
                    Patients.Add(patient);
                }
            }
            finally
            {
                IsBusy = false;
            }
        }

        [RelayCommand]
        public async Task ShowPatientDetails(Patient patient)
        {
            Dictionary<string, object> parameters = new()
            {
                { "PatientId", patient.Id }
            };
            await Shell.Current.GoToAsync(nameof(PatientsDetailsPage),parameters);
        }
        [RelayCommand]
        private async Task AddPatient()
        {
            Dictionary<string, object> parameters = new()
            {
                { "PatientId", 0 }
            };
            await Shell.Current.GoToAsync(nameof(EditPatientPage), parameters);
        }

    }
}