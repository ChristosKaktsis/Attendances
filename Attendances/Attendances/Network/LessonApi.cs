using Attendances.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Attendances.Network
{
    public class LessonApi
    {
        readonly static string query = "Select event.Oid,FORMAT(event.StartOn,'dd-MM-yyyy') as Today, FORMAT(event.StartOn,'hh:mm') as StartOn, FORMAT(Event.EndOn,'hh:mm') as EndOn ,Τάξεις.Περιγραφή as Description , Εργαζόμενος.ΚάρταΠαρουσίας as TeacherCard\r\n,\r\n(Select  Παρουσιολόγιο.Oid as ParousiaOid, Person.FirstName + ' ' + person.LastName as StundentName,   Παρουσιολόγιο.Απουσία  as Absence\r\nfrom Παρουσιολόγιο \r\n   inner join Μαθητές on Μαθητές.Oid = Παρουσιολόγιο.Μαθητής \r\n  inner join Person on Person.Oid = Μαθητές.Oid where GCRecord is null and ΔιδακτικέςΏρες.Oid = Παρουσιολόγιο.ΔιδακτικήΏρα\r\n   FOR JSON path ) as  Attendance \r\nfrom ΔιδακτικέςΏρες\r\ninner join [Event] on [Event].oid=ΔιδακτικέςΏρες.oid \r\n inner join Τάξεις On ΔιδακτικέςΏρες.Τάξη = Τάξεις.Oid\r\nleft join Εργαζόμενος On Εργαζόμενος.Oid = ΔιδακτικέςΏρες.Διδάσκων\r\n  where event.gcrecord is null and event.StartOn >= getdate() and event.StartOn<=getdate()+1 ORDER BY event.StartOn FOR JSON path ";
        readonly static string ConnectionString = "user=sa;password=1;Data Source=SUPPORT-SERVER\\SQLEXPRESS;Initial Catalog=DemoXanth";
        readonly static string updateQuery = "update Παρουσιολόγιο set Απουσία = {0} where Oid ='{1}'";
        public LessonApi()
        {
           
        }
       

        public async static Task<List<Classes>> GetLessons()
        {
            using(SqlConnection connection = new SqlConnection(ConnectionString))
            {
                var cmd = new SqlCommand(query, connection);
                var jsonResult = new StringBuilder();
                await connection.OpenAsync();
                var reader = await cmd.ExecuteReaderAsync();
                if (!reader.HasRows) return null;
                while(await reader.ReadAsync())
                {
                    jsonResult.Append(reader.GetValue(0).ToString());
                }
                var result = jsonResult.ToString();

                return JsonSerializer.Deserialize<IEnumerable<Classes>>(result).ToList();
            }
        }
        public async static Task<bool> UpdateStudent(Student student)
        {
            int result = 0;
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                await connection.OpenAsync();
                SqlCommand command = new SqlCommand(
                    string.Format(updateQuery,student.Absence ?'1':'0',student.ID), connection);
                result = await command.ExecuteNonQueryAsync();
            }
            return result != 0;
        }
    }
}
