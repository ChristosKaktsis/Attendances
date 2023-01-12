using Attendances.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Attendances.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            BindingContext = new LoginViewModel();
        }
    }
}