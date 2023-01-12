using Attendances.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Attendances.ViewModels
{
    internal class LoginViewModel
    {
        public LoginViewModel()
        {
            LoginCommand = new Command(OnLogin);
        }

        private async void OnLogin()
        {
            //login and go to lessons
            await Shell.Current.GoToAsync($"//{nameof(LessonsPage)}");
        }

        public Command LoginCommand { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

    }
}
