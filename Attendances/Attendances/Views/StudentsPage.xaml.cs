using Attendances.Models;
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
    public partial class StudentsPage : ContentPage
    {
        private StudentsViewModel _viewModel;

        public StudentsPage(string lessonid)
        {
            InitializeComponent();
            BindingContext = _viewModel = new StudentsViewModel(lessonid);

        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();

        }
    }
}