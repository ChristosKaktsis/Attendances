using Attendances.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Attendances.Views.Templates
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Lesson_Template : ContentView
    {
        public Lesson_Template()
        {
            InitializeComponent();
        }
        private async void Button_Clicked(object sender, EventArgs e)
        {
            if (!(BindingContext is Classes lesson)) return;
            //navigate to class
            await Shell.Current.Navigation.PushAsync(new StudentsPage(lesson.ID));
        }
    }
}