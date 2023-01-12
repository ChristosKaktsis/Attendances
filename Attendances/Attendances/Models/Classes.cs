using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Attendances.Models
{
    public class Classes
    {
        [JsonPropertyName("Oid")]
        public string ID { get; set; }
        public string Today { get; set; }
        public string StartOn { get; set; }
        public string EndOn { get; set; }
        public string Description { get; set; }
        public string TeacherCard { get; set; }
        public List<Student> Attendance { get; set; }
    }
}
