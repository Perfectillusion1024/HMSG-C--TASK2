using HolmesglenStudentManagementSystem.DataAccessLayer;
using HolmesglenStudentManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolmesglenStudentManagementSystem.BusinessLogicLayer
{
    public class StudentBLL
    {
        AppDAL appDAL;
        public StudentBLL()
        {
            appDAL = new AppDAL();
        }
        public List<Student> GetAll()
        {
            return appDAL.StudentDALInstance.ReadAll();
        }

        public Student GetOne(string id)
        {
            return appDAL.StudentDALInstance.Read(id);
        }

        public bool Create(Student student)
        {
            if(GetOne(student.Id) != null)
            {
                // if student id exists, return false
                return false;
            }
            else
            {
                // if student id does not exist, create it
                appDAL.StudentDALInstance.Create(student);
            }

            return true;
        }

        public bool Update(Student student)
        {
            if (GetOne(student.Id) == null)
            {
                // if student id does not exist, return false
                return false;
            }
            else
            {
                // if student id exists, update it
                appDAL.StudentDALInstance.Update(student);
            }

            return true;
        }

        public bool Delete(string id)
        {
            if (GetOne(id) == null)
            {
                // if student id does not exist, return false
                return false;
            }
            else
            {
                // if student id exists, delete it
                appDAL.StudentDALInstance.Delete(id);
            }

            return true;
        }
    }
}
