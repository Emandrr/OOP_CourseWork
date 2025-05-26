using MedicineManage.UI.ViewModels;
namespace MedicineManage.UI.Pages;

public partial class PatientFullInfoPage : ContentPage
{
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        this.Opacity = 0;
        await this.FadeTo(1, 500, Easing.SpringIn);
    }
    public PatientFullInfoPage(PatientFullInfoViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}