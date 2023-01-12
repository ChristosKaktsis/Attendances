using Attendances.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Attendances.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LessonsPage : ContentPage
    {
        private LessonsViewModel _viewModel;

        public LessonsPage()
        {
            InitializeComponent();
            BindingContext = _viewModel = new LessonsViewModel();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }
    }
}