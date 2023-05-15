namespace StudentInformationSystem.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string EmailAddress { get; set; }
        public string ContactInformation { get; set; } 
        public ICollection<Enrollment> Enrollments { get; set; } 
    }  
}