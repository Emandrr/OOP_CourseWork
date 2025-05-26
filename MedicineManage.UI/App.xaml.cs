using Microsoft.Extensions.DependencyInjection;
using MedicineManage.UI.Pages;
namespace MedicineManage.UI
{
    public partial class App : Application
    {
        public App(IServiceProvider serviceProvider)
        {
            InitializeComponent();

            MainPage = serviceProvider.GetRequiredService<AppShell>();
        }
        
    }
}
