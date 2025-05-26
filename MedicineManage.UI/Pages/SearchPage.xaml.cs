using MedicineManage.DataAccess.Data;
using MedicineManage.DataAccess.Repositories;
using MedicineManage.UI.ViewModels;
using MedicineManage.Domain.Models;
using MedicineManage.DataAccess.Interfaces;
using MedicineManage.Aplication.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace MedicineManage.UI.Pages;


public partial class SearchPage : ContentPage
{
    private readonly SearchViewModel _viewModel;
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        this.Opacity = 0;
        await this.FadeTo(1, 500, Easing.CubicIn);
        
        await _viewModel.Search();
    }
    
    public SearchPage(SearchViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
        _viewModel = viewModel;
    }
}

