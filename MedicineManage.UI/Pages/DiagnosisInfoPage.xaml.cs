using MedicineManage.UI.ViewModels;

namespace MedicineManage.UI.Pages;

public partial class DiagnosisInfoPage : ContentPage
{
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        this.Opacity = 0;
        await this.FadeTo(1, 500, Easing.SpringIn);
    }
    public DiagnosisInfoPage(DiagnosisInfoViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}