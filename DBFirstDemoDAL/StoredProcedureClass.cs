using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBFirstDemoDAL
{
    public class StoredProcedureClass
    {
        SqlConnection sqlConn;
        SqlCommand sqlCommand;
        public void insertfacultyStoredProcedure(string name, string email, int psno)
        {
            try
            {
                sqlConn = new SqlConnection(ConfigurationManager.ConnectionStrings["ProjectXDB"].ToString());
                sqlCommand = new SqlCommand("[dbo].[uspInsertFacultyDetails]", sqlConn);
                // 1.  create a command object identifying the stored procedure
                // 2. set the command object so it knows to execute a stored procedure
                // 3. add parameter to command, which will be passed to the stored procedure
                sqlConn.Open();
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@Name", name);
                sqlCommand.Parameters.AddWithValue("@email", email);
                sqlCommand.Parameters.AddWithValue("@psno", psno);

                SqlParameter value = new SqlParameter("@RequestStatus", SqlDbType.Int);
                value.Direction = ParameterDirection.ReturnValue;
                sqlCommand.Parameters.Add(value);
                int noOfAffectedRow = sqlCommand.ExecuteNonQuery();
                if (noOfAffectedRow > 0)
                {
                    Console.WriteLine("No.of Affected Rows: " + noOfAffectedRow);
                    Console.WriteLine("Request status: " + sqlCommand.Parameters["@RequestStatus"].Value);
                }
                else
                {
                    Console.WriteLine("Requested Status: " + sqlCommand.Parameters["@RequestStatus"].Value);
                }

            }
            catch (SqlException sqlException)
            {
                Console.WriteLine(sqlException.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Something went wrong:(");
                Console.WriteLine(ex);                
            }
            finally
            {
                sqlConn.Close();
            }
        }
    }
}
