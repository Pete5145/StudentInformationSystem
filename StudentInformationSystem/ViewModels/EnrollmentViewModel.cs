using StudentInformationSystem.Models;

namespace StudentInformationSystem.ViewModels
{
    public class EnrollmentViewModel
    {
        public int Id { get; set; }
        public int StudentID { get; set; } 
        public int CourseID { get; set; } 
        public string Grade { get; set; }
    }
}