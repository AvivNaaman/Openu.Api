using System;
using System.Collections.Generic;
using System.Text;

namespace OpenU.Api
{
    public class OpenuCourseDetails
    {
        public OpenuCourseInformation CourseInformation { get; set; }
        public OpenuGroupDetails GroupDetails { get; set; }
        public List<OpenuTask> Tasks { get; set; }
    }
    public class OpenuCourseInformation
    {
        public OpenuCourseTutor Tutor { get; set; }
        public OpenuCourseCoordinator Coordinator { get; set; }
        public string DepartmentName { get; set; }
        public OpenuCourseStateInfo State { get; set; }
    }

    public class OpenuTask {
        public int Number { get; set; }
        public string Description { get; set; }
        public DateTime ExamDate { get; set; }
        public int Weight { get; set; }
        public string Mark { get; set; }
        public string ValidityDescription { get; set; }
        public string Validity { get; set; }
        public DateTime UpdateDate { get; set; }
    }

    public class OpenuGroupDetails
    {
        public int StudyGroupID { get; set; }
        public string InstructionType { get; set; }
        public string MeetingDaysAndHours { get; set; }
        public List<OpenuMeeting> Meetings { get; set; }
        public OpenuStudyCenter StudyCenter { get; set; }
    }

    public class OpenuStudyCenter
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string ActivityDays { get; set; }

    }

    public class OpenuCourseTutor
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Times { get; set; }
        public string Address { get; set; }
    }

    public class OpenuCourseCoordinator
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public string GuidanceTimes { get; set; }
        public string SecretaryName { get; set; }
        public string SecretaryPhone { get; set; }

    }

    public class OpenuCourseStateInfo
    {
        public string StateDescription { get; set; }
        public int? Score { get; set; }
        public int? FinalScore { get; set; }
        public int? WeightedScore { get; set; }
    }

    public class OpenuMeeting
    {
        public int Id { get; set; }
        public char Day { get; set; }
        public DateTime? Date { get; set; }
        public string Hours { get; set; }
        public string Type { get; set; }
        public string Location { get; set; }
        public string Comment { get; set; }
    }
    public class OpenuPayment
    {
        public int Seq { get; set; }
        public int Description { get; set; }
        public string Type { get; set; }
        public int Amount { get; set; }
        public DateTime RecordDate { get; set; }
        public int PaymentNumber { get; set; }
        public DateTime PaymentBegins { get; set; }
        public int? CreditNumber { get; set; }
        public string Pays { get; set; }
    }
}
