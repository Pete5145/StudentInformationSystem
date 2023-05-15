namespace StudentInformationSystem.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Schedule { get; set; } 

       // public ICollection<Enrollment> Enrollments { get; set; }
    }
}