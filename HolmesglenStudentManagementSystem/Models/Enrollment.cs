namespace HolmesglenStudentManagementSystem.Models
{
    public class Enrollment
    {
        public int ID { get; set; }
        public int StudentID_FK { get; set; }
        public int SubjectID_FK { get; set; }
    }
}