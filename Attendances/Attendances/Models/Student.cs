using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Attendances.Models
{
    public  class Student
    {
        [JsonPropertyName("ParousiaOid")]
        public string ID { get; set; }
        [JsonPropertyName("StundentName")]
        public string Name { get; set; }
        public bool Absence { get; set; }
    }
}
