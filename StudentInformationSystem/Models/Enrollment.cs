using System.ComponentModel.DataAnnotations.Schema;

namespace StudentInformationSystem.Models
{
    public class Enrollment
    {
        public int Id { get; set; }  
        public int StudentID { get; set; }
        public Student Student { get; set; }
        public int CourseID { get; set; }
        public Course Course { get; set; }
        public string Grade { get; set; }
    }
}
