using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolmesglenStudentManagementSystem.DataAccessLayer
{
    public class AppDAL
    {
        public SqliteConnection Connection;
        public StudentDAL StudentDALInstance;
        public SubjectDAL SubjectDALInstance;
        public EnrollmentDAL EnrollmentDALInstance;

        // private constructor
        public AppDAL() {
            // create the ADO.net sqlite connection
            Connection = new SqliteConnection(HolmesglenDB.ConnectionString);

            // create all DAL instances
            StudentDALInstance = new StudentDAL(Connection);
            SubjectDALInstance = new SubjectDAL(Connection);
            // student todo:
            // implement the EnrollmentDAL class and create a instance here 
        }
    }
    /* sigular pattern
    sealed public class AppDAL
    {
        private static AppDAL DALInstance = null;

        public SqliteConnection Connection;
        public StudentDAL StudentDALInstance;
        public SubjectDAL SubjectDALInstance;
        public EnrollmentDAL EnrollmentDALInstance;

        // private constructor
        private AppDAL() { }
        public static AppDAL Instance()
        {
            if(DALInstance == null)
            {
                DALInstance = new AppDAL();
                DALInstance.Init();
            }
            return DALInstance;
        }

        private void Init()
        {
            // create the ADO.net sqlite connection
            Connection = new SqliteConnection(HolmesglenDB.ConnectionString);

            // create all DAL instances
            StudentDALInstance = new StudentDAL(Connection);
            SubjectDALInstance = new SubjectDAL(Connection);
        }
    }
    */
}
