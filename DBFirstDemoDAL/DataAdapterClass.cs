using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBFirstDemoDAL
{
    public class DataAdapterClass
    {
        SqlConnection sqlConn = new SqlConnection(ConfigurationManager.ConnectionStrings["ProjectXDB"].ToString());
        SqlDataAdapter dataAdapter = new SqlDataAdapter();
        public void insertFaculty(string facultyName, string email, int psno)
        {
            try
            {
                sqlConn.Open();
                string sqlQuery = @"INSERT INTO Faculty values ('" + @facultyName + "','" + @email + "','" + @psno + "')";
                dataAdapter.InsertCommand = new SqlCommand(sqlQuery, sqlConn);

                int rows = dataAdapter.InsertCommand.ExecuteNonQuery();
                if (rows > 0)
                {
                    Console.WriteLine("Query executed successfully");
                }
                else
                {
                    Console.WriteLine("Query Unsuccessful");
                }
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
                dataAdapter.UpdateCommand = new SqlCommand(sqlQuery, sqlConn);

                int rows = dataAdapter.UpdateCommand.ExecuteNonQuery();
                if (rows > 0)
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

        public void deleteGrader(int ParticipantId)
        {
            try
            {
                sqlConn.Open();
                string sqlQuery = @"DELETE FROM Grader WHERE ParticipantID = '" + @ParticipantId + "'";

                dataAdapter.DeleteCommand = new SqlCommand(sqlQuery, sqlConn);

                int rows = dataAdapter.DeleteCommand.ExecuteNonQuery();
                if (rows > 0)
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
