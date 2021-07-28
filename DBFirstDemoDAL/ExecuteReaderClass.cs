using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBFirstDemoDAL
{
    public class ExecuteReaderClass
    {
        SqlConnection sqlConn = new SqlConnection(ConfigurationManager.ConnectionStrings["ProjectXDB"].ToString());
        SqlCommand sqlCommand;
      
        public void insertFaculty(string facultyName, string email, int psno)
        {
            try
            {
                sqlConn.Open();
                string sqlQuery = @"INSERT INTO Faculty values ('" + @facultyName + "','" + @email + "','" + @psno + "')";
                sqlCommand = new SqlCommand(sqlQuery, sqlConn);

                SqlDataReader dataReader = sqlCommand.ExecuteReader();
                Console.WriteLine(dataReader.RecordsAffected);
            }
            catch (SqlException sqlException)
            {
                Console.WriteLine(sqlException.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                sqlConn.Close();
            }
        }
        public void updateBatchFaculty(string batchId, int psno)
        {
            try
            {
                sqlConn.Open();
                string sqlQuery = @"UPDATE Batch_FacultyMapping SET PSNo ='" + @psno + "' WHERE BatchID ='" + batchId + "'";
                sqlCommand = new SqlCommand(sqlQuery, sqlConn);

                SqlDataReader dataReader = sqlCommand.ExecuteReader();
                Console.WriteLine(dataReader.RecordsAffected);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                sqlConn.Close();
            }
        }

        public void deleteGrader(int ParticipantId)
        {
            try
            {
                sqlConn.Open();
                string sqlQuery = @"DELETE FROM Grader WHERE ParticipantID = '" + @ParticipantId + "'";
                sqlCommand = new SqlCommand(sqlQuery, sqlConn);

                SqlDataReader dataReader = sqlCommand.ExecuteReader();
                if (dataReader.RecordsAffected > 0)
                {
                    Console.WriteLine("Query executed successfully");
                }
                else
                {
                    Console.WriteLine("Query Unsuccessful");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                sqlConn.Close();
            }
        }
    }
}
