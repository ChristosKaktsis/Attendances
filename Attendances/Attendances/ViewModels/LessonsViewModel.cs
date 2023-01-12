using Attendances.Data;
using Attendances.Models;
using Attendances.Network;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Attendances.ViewModels
{
    internal class LessonsViewModel : BaseViewModel
    {
        public LessonsViewModel()
        {
            //navigation to classroom is performed in the UI Template of lesson
            RefreshCommand = new Command(async () => await LoadLessons());
        }
        private ClassData lessonData = new ClassData();
        public ObservableCollection<Classes> LessonCollection 
        { get; set; } = new ObservableCollection<Classes>();
        public Command RefreshCommand { get; } 
        public  void OnAppearing()
        {
            IsBusy= true;
        }
        private async Task LoadLessons()
        {
            IsBusy= true;
            try
            {
                LessonCollection.Clear();
                //load lessons from data base
                var items = await lessonData.GetItemsAsync();
                //put them into collection
                foreach(var lesson in items) 
                    LessonCollection.Add(lesson);

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                IsBusy = false;
            }
            
        }
    }
}
