using System;
using System.Collections.Generic;
using System.Text;

namespace OpenU.Api
{
    public class OpenuActivity
    {
        public int? Id { get; set; }
        public DateTime Date { get; set; }
        public string Name { get; set; }
        public string Semester { get; set; }
        public int? Course { get; set; }
        public string StudyCenter { get; set; }
    }
}
