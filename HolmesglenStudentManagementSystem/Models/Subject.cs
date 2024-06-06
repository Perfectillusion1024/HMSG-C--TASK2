namespace HolmesglenStudentManagementSystem.Models
{
    public class Subject
    {
        public int SubjectID { get; set; }
        public string Title { get; set; }
        public int NumberOfSessions { get; set; }
        public double HourPerSession { get; set; }
    }
}