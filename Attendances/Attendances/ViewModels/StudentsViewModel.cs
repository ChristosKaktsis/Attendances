using Attendances.Data;
using Attendances.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Attendances.ViewModels
{
    internal class StudentsViewModel : BaseViewModel
    {
        public StudentsViewModel(string lessonId)
        {
            this.lessonId = lessonId;
            CompleteCommand = new Command(CompleteAction);
        }
        private string lessonId;
        public ObservableCollection<Student> Students { get; set; }
            = new ObservableCollection<Student>();
        public Command CompleteCommand { get;}
        private ClassData lessonData = new ClassData();
        public async void OnAppearing()
        {
            await LoadStudents();
        }
        private async Task LoadStudents()
        {
            try
            {
                Students.Clear();
                var lesson = await lessonData.GetItemAsync(lessonId);
                if (lesson == null) return;
                //set title 
                Title = lesson.Description;
                foreach(var student in lesson.Attendance) 
                    Students.Add(student);

            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        private async void CompleteAction()
        {
            //save changes
            await UpdateStudents();

            await Shell.Current.Navigation.PopToRootAsync();
        }

        private async Task UpdateStudents()
        {
            foreach (var student in Students)
                await lessonData.UpdateStudent(student);
        }
    }
}
