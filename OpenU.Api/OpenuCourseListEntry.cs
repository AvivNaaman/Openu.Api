using System;
using System.Collections.Generic;
using System.Text;

namespace OpenU.Api
{
    public class OpenuCourseListEntry
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Semester { get; set; }
        public string StudyCenter { get; set; }
        public string Group { get; set; }
        public CourseType CourseType { get; set; }
    }

    public enum CourseType
    {

    }
}
