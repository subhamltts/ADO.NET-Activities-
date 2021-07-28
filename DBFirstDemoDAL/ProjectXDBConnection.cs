using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBFirstDemoDAL
{
    public class ProjectXDBConnection
    {
        SqlConnection sqlConnObj;
        SqlCommand sqlCmdObj;
        public string ConnectionToDB()
        {
            try
            {
                sqlConnObj = new SqlConnection(ConfigurationManager.ConnectionStrings["ProjectXDB"].ToString());
                //string conStr = ConfigurationManager.ConnectionStrings["ProjectXDB"].ToString();
                sqlConnObj.Open();
                return sqlConnObj.State.ToString();
            }
            catch (Exception)
            {
                return sqlConnObj.State.ToString();
            }
        }

        public List<string> ReadFromDB()
        {
            List<string> lsProduct = new List<string>();
            try
            {
                sqlConnObj = new SqlConnection(ConfigurationManager.ConnectionStrings["ProjectXDB"].ToString());
                sqlCmdObj = new SqlCommand("SELECT BatchName, BatchStrength FROM Batch", sqlConnObj);
                sqlConnObj.Open();
                SqlDataReader drProduct = sqlCmdObj.ExecuteReader();
                while (drProduct.Read())
                {
                    string temp = drProduct["BatchName"].ToString() + " " +drProduct["BatchStrength"].ToString();
                    lsProduct.Add(temp);
                }

                return lsProduct;
            }
            catch (SqlException sqlException)
            {
                Console.WriteLine(sqlException.Message);
                return lsProduct;
            }
            catch (Exception)
            {
                lsProduct.Add("Something went wrong");
                return lsProduct; 
            }
 
            finally
            {
                sqlConnObj.Close();
            }
        }
        public List<string> GetDataFaculty()
        {
            List<string> lsProduct = new List<string>();
            try
            {
                sqlConnObj = new SqlConnection(ConfigurationManager.ConnectionStrings["ProjectXDB"].ToString());
                sqlCmdObj = new SqlCommand("SELECT FacultyName, PSNo FROM Faculty", sqlConnObj);
                sqlConnObj.Open();
                SqlDataReader drProduct = sqlCmdObj.ExecuteReader();
                while (drProduct.Read())
                {
                    string temp = drProduct["FacultyName"].ToString() + " " + drProduct["PSNo"].ToString();
                    lsProduct.Add(temp);
                }

                return lsProduct;
            }
            catch (SqlException sqlException)
            {
                Console.WriteLine(sqlException.Message);
                return lsProduct;
            }
            catch (Exception)
            {
                lsProduct.Add("Something went wrong");
                return lsProduct;
            }

            finally
            {
                sqlConnObj.Close();
            }
        }
        public List<string> GetDataGrader()
        {
            List<string> lsProduct = new List<string>();
            try
            {
                sqlConnObj = new SqlConnection(ConfigurationManager.ConnectionStrings["ProjectXDB"].ToString());
                sqlCmdObj = new SqlCommand("SELECT Marks_Obtained, BatchID, CourseID, ParticipantID FROM Grader", sqlConnObj);
                sqlConnObj.Open();
                SqlDataReader drProduct = sqlCmdObj.ExecuteReader();
                while (drProduct.Read())
                {
                    string temp = drProduct["Marks_Obtained"].ToString() + " " + drProduct["BatchID"].ToString() + " " + drProduct["CourseID"].ToString() + " " + drProduct["ParticipantID"].ToString();
                    lsProduct.Add(temp);
                }

                return lsProduct;
            }
            catch (SqlException sqlException)
            {
                Console.WriteLine(sqlException.Message);
                return lsProduct;
            }
            catch (Exception)
            {
                lsProduct.Add("Something went wrong");
                return lsProduct;
            }

            finally
            {
                sqlConnObj.Close();
            }
        }

        public List<string> GetDataBatch_Faculty()
        {
            List<string> lsProduct = new List<string>();
            try
            {
                sqlConnObj = new SqlConnection(ConfigurationManager.ConnectionStrings["ProjectXDB"].ToString());
                sqlCmdObj = new SqlCommand("SELECT BatchID FROM Batch_FacultyMapping WHERE PSNo=90904655", sqlConnObj);
                sqlConnObj.Open();
                SqlDataReader drProduct = sqlCmdObj.ExecuteReader();
                while (drProduct.Read())
                {
                    string temp = drProduct["BatchID"].ToString();
                    lsProduct.Add(temp);
                }

                return lsProduct;
            }
            catch (SqlException sqlException)
            {
                Console.WriteLine(sqlException.Message);
                return lsProduct;
            }
            catch (Exception)
            {
                lsProduct.Add("Something went wrong");
                return lsProduct;
            }

            finally
            {
                sqlConnObj.Close();
            }
        }

        public List<string> GetDataCourse_Batch()
        {
            List<string> lsProduct = new List<string>();
            try
            {
                sqlConnObj = new SqlConnection(ConfigurationManager.ConnectionStrings["ProjectXDB"].ToString());
                sqlCmdObj = new SqlCommand(@"SELECT CourseID FROM Course_BatchMapping WHERE BatchID = '02_07_DSP_Java'", sqlConnObj);
                sqlConnObj.Open();
                SqlDataReader drProduct = sqlCmdObj.ExecuteReader();
                while (drProduct.Read())
                {
                    string temp = drProduct["CourseID"].ToString();
                    lsProduct.Add(temp);
                }

                return lsProduct;
            }
            catch (SqlException sqlException)
            {
                Console.WriteLine(sqlException.Message);
                return lsProduct;
            }
            catch (Exception)
            {
                lsProduct.Add("Something went wrong");
                return lsProduct;
            }

            finally
            {
                sqlConnObj.Close();
            }
        }


        public string GetModelData(int modelId)
        {
            string modelOwner=null;
            try
            {
                sqlConnObj = new SqlConnection(ConfigurationManager.ConnectionStrings["ProjectXDB"].ToString());
                sqlCmdObj = new SqlCommand(@"SELECT ModelOwner FROM Model WHERE ModelID ="+modelId.ToString(), sqlConnObj);
                sqlConnObj.Open();
                SqlDataReader drProduct = sqlCmdObj.ExecuteReader();
                modelOwner = drProduct["ModelOwner"].ToString();
                return modelOwner; 
            }
            catch (SqlException sqlException)
            {
                Console.WriteLine(sqlException.Message);
                return modelOwner;
            }
            catch (Exception)
            {
                Console.WriteLine("Something went wrong");
                return modelOwner;
            }

            finally
            {
                sqlConnObj.Close();
            }
        }

    }
}
