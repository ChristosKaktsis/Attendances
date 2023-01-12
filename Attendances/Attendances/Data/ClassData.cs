using Attendances.Models;
using Attendances.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Attendances.Data
{
    public class ClassData
    {
        private static List<Classes> Classes;

        private async Task GetClasses()
        {
            try
            {
                if (Classes != null) return;
                Classes = await LessonApi.GetLessons();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        public async Task<IEnumerable<Classes>> GetItemsAsync(bool forceRefresh = false)
        {
            await GetClasses();
            return await Task.FromResult(Classes);
        }
        public async Task<Classes> GetItemAsync(string id)
        {
            await GetClasses();
            return await Task.FromResult(Classes.FirstOrDefault(l => l.ID == id));
        }
        public async Task<bool> UpdateStudent(Student student)
        {
            try
            {
                var result = await LessonApi.UpdateStudent(student);
                Console.WriteLine($"Student {student?.ID} updated {result}");
                return result;
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Student {student?.ID} updated {false}");
                Console.WriteLine(ex);
                return false;
            }
        }
    }
}
