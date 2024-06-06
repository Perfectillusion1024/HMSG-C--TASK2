using System.Collections.Generic;
using HolmesglenStudentManagementSystem.DAL;
using HolmesglenStudentManagementSystem.Models;

namespace HolmesglenStudentManagementSystem.BLL
{
    public class EnrollmentBLL
    {
        private readonly EnrollmentDAL _enrollmentDAL;

        public EnrollmentBLL()
        {
            _enrollmentDAL = new EnrollmentDAL();
        }

        public void CreateEnrollment(Enrollment enrollment)
        {
            _enrollmentDAL.CreateEnrollment(enrollment);
        }

        public Enrollment GetEnrollmentById(int id)
        {
            return _enrollmentDAL.ReadEnrollment(id);
        }

        public List<Enrollment> GetAllEnrollments()
        {
            return _enrollmentDAL.ReadAllEnrollments();
        }

        public void UpdateEnrollment(Enrollment enrollment)
        {
            _enrollmentDAL.UpdateEnrollment(enrollment);
        }

        public void DeleteEnrollment(int id)
        {
            _enrollmentDAL.DeleteEnrollment(id);
        }
    }
}