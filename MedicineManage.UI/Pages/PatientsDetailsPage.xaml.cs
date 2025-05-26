using MedicineManage.Domain.Models;
using MedicineManage.UI.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
namespace MedicineManage.UI.Pages
{
    public partial class PatientsDetailsPage : ContentPage
    {
        private readonly PatientsDetailsViewModel _viewModel;
        public PatientsDetailsPage(PatientsDetailsViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
            _viewModel = viewModel;
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            this.Opacity = 0;
            await this.FadeTo(1, 500, Easing.SpringIn);
            await _viewModel.LoadData(_viewModel.PatientId);
        }
    }
}