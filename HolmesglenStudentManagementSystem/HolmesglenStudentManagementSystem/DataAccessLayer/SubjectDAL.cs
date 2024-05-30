using Microsoft.Data.Sqlite;
using HolmesglenStudentManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolmesglenStudentManagementSystem.DataAccessLayer
{
    public class SubjectDAL
    {        
        private SqliteConnection Connection;

        public SubjectDAL(SqliteConnection connection)
        {
            // connect to the target database
            Connection = connection;
        }
        // create
        public void Create(Subject subject)
        {

        }

        public Subject Read(string id)
        {
            Subject subject = null;
            
            return subject;
        }

        // read all
        public List<Subject> ReadAll()
        {
            var subjects = new List<Subject>();

            return subjects;
        }

        public void Update(Subject subject)
        {
            
        }

        public void Delete(string id)
        {
            
        }
    }
}
