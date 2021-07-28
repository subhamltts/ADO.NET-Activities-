using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBFirstDemoDAL
{
    public class TableValuedFuncClass
    {
        public void tableValuedFunction(string title)
        {
            SqlConnection sqlConn = new SqlConnection(ConfigurationManager.ConnectionStrings["ProjectXDB"].ToString());
            SqlCommand sqlCommand;
            try
            {
                sqlConn.Open();
                string query = @"select * from dbo.ufn_AlbumsByGenre_ITVF('" + @title + "')";
                sqlCommand = new SqlCommand(query, sqlConn);

                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine(reader["Courseid"] + " " + reader["CourseOwner"] + " " + reader["CourseTitle"] + " " + reader["AssessmentId"] + " " + reader["HoursAssigned"] + " " + reader["CourseSyllabus"]);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
