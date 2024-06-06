using System.Collections.Generic;
using HolmesglenStudentManagementSystem.DAL;
using HolmesglenStudentManagementSystem.Models;

namespace HolmesglenStudentManagementSystem.BLL
{
    public class StudentBLL
    {
        private readonly StudentDAL _studentDAL;

        public StudentBLL()
        {
            _studentDAL = new StudentDAL();
        }

        public void CreateStudent(Student student)
        {
            _studentDAL.CreateStudent(student);
        }

        public Student GetStudentById(int studentId)
        {
            return _studentDAL.ReadStudent(studentId);
        }

        public List<Student> GetAllStudents()
        {
            return _studentDAL.ReadAllStudents();
        }

        public void UpdateStudent(Student student)
        {
            _studentDAL.UpdateStudent(student);
        }

        public void DeleteStudent(int studentId)
        {
            _studentDAL.DeleteStudent(studentId);
        }
    }
}