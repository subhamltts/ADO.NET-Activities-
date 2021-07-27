using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace strproDAL
{
    public class CS1
    {
        SqlConnection sqlConObj = null;
        SqlCommand sqlCmdObj = null;
        public int GetAllCoursesDetails(string cid, string ctitle, int duration, string owner, string mode, out int rows)
        {
            sqlConObj = new SqlConnection(ConfigurationManager.ConnectionStrings["Crs"].ToString());
            sqlCmdObj = new SqlCommand("dbo.uspInsertCourseDetails", sqlConObj);
            sqlCmdObj.CommandType = CommandType.StoredProcedure;
            sqlCmdObj.Parameters.AddWithValue("@CourseId", cid);
            sqlCmdObj.Parameters.AddWithValue("@CourseTitle", ctitle);
            sqlCmdObj.Parameters.AddWithValue("@Duration", duration);
            sqlCmdObj.Parameters.AddWithValue("@Owner", owner);
            sqlCmdObj.Parameters.AddWithValue("@AssessmentMode", mode);
            try
            {
                sqlConObj.Open();
                SqlParameter param = sqlCmdObj.Parameters.Add("ReturnValue", SqlDbType.Int);
                param.Direction = ParameterDirection.ReturnValue;
                rows = sqlCmdObj.ExecuteNonQuery();
                int results = (int)param.Value;
                return results;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Something Went Wrong!");
                rows = 0;
                return -99;
            }
            finally
            {
                sqlConObj.Close();
            }
        }
        /*  public int DeleteCourse(string cid, out int rows2)
          {
              sqlConObj = new SqlConnection(ConfigurationManager.ConnectionStrings["Crs"].ToString());
              sqlCmdObj = new SqlCommand("dbo.uspDeleteCourse", sqlConObj);
              sqlCmdObj.CommandType = CommandType.StoredProcedure;
              sqlCmdObj.Parameters.AddWithValue("@CourseId", cid);
              try
              {
                  sqlConObj.Open();
                  SqlParameter param = sqlCmdObj.Parameters.Add("ReturnValue", SqlDbType.Int);
                  param.Direction = ParameterDirection.ReturnValue;
                  rows2 = sqlCmdObj.ExecuteNonQuery();
                  int results2 = (int)param.Value;
                  return results2;
              }
              catch (Exception ex)
              {
                  Console.WriteLine("Oops!!Something Happened!");
                  rows2 = 0;
                  return -99;
              }
              finally
              {
                  sqlConObj.Close();
              }
          }
        */
        public int ModifyCourseDuration(string cid, int dur, out int rows1)
        {
            sqlConObj = new SqlConnection(ConfigurationManager.ConnectionStrings["Crs"].ToString());
            sqlCmdObj = new SqlCommand("dbo.uspModifyCourseDuration", sqlConObj);
            sqlCmdObj.CommandType = CommandType.StoredProcedure;
            sqlCmdObj.Parameters.AddWithValue("@CourseId", cid);
            sqlCmdObj.Parameters.AddWithValue("@Duration", dur);
            try
            {
                sqlConObj.Open();
                SqlParameter param = sqlCmdObj.Parameters.Add("ReturnValue", SqlDbType.Int);
                param.Direction = ParameterDirection.ReturnValue;
                rows1 = sqlCmdObj.ExecuteNonQuery();
                int results1 = (int)param.Value;
                return results1;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Oops!!Something Happened!");
                rows1 = 0;
                return -99;
            }
            finally
            {
                sqlConObj.Close();
            }

        }
    }
}
