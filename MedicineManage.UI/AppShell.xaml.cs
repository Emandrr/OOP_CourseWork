using MedicineManage.DataAccess.Data;
using MedicineManage.UI.Pages;
namespace MedicineManage.UI
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            
            InitializeComponent();
            Routing.RegisterRoute(nameof(SearchPage), typeof(SearchPage));
            Routing.RegisterRoute(nameof(PatientsDetailsPage), typeof(PatientsDetailsPage));
            Routing.RegisterRoute(nameof(EditPatientPage), typeof(EditPatientPage));
            Routing.RegisterRoute(nameof(PatientFullInfoPage), typeof(EditPatientPage));
            Routing.RegisterRoute(nameof(DiagnosisInfoPage), typeof(DiagnosisInfoPage));
        }
    }
}
