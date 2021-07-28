using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBFirstDemoDAL
{
    public class ScalarFunctionClass
    {
        public void scalarFunction(string title)
        {
            SqlConnection sqlConn = new SqlConnection(ConfigurationManager.ConnectionStrings["ProjectXDB"].ToString());
            SqlCommand sqlCommand;
            try
            {
                sqlConn.Open();
                string query = @"select [dbo].[f_GetRecordCount]('" + @title + "')";
                sqlCommand = new SqlCommand(query, sqlConn);

                int noOfRowsAffected = (int)sqlCommand.ExecuteScalar();
                if (noOfRowsAffected > 0)
                {
                    Console.WriteLine("Executed : " + noOfRowsAffected);
                }
                else
                {
                    Console.WriteLine("Error");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
