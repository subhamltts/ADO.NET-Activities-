using DBFirstDemoDAL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBFirstDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            ProjectXDBConnection obj = new ProjectXDBConnection();
            string result = obj.ConnectionToDB();
            //Console.WriteLine(result);
            
            List<string> ls = new List<string>();
            ls = obj.ReadFromDB();
            foreach (var item in ls)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("\n************** Faculty Table ******************");
            List<string> ls2 = new List<string>();
            ls2 = obj.GetDataFaculty();
            foreach (var item in ls2)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("\n************** Grader Table ******************");
            List<string> ls3 = new List<string>();
            ls3 = obj.GetDataGrader();
            foreach (var item in ls3)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("\n************** Get Batch of given Faculty ******************");
            List<string> ls4 = new List<string>();
            ls4 = obj.GetDataBatch_Faculty();
            foreach (var item in ls4)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("\n************** Get Courses for given batch ******************");
            List<string> ls5 = obj.GetDataCourse_Batch(); //new List<string>();
            //ls5 = obj.GetDataCourse_Batch();
            foreach (var item in ls5)
            {
                Console.WriteLine(item);
            }

            /*Console.WriteLine("\n************** Get ModelOwner for specified ID ******************");
            string owner = obj.GetModelData(2021);
            Console.WriteLine(owner);
            */

            Console.WriteLine("\n************** Stored Procedure ******************");
            //StoredProcedureClass obj2 = new StoredProcedureClass();
            //obj2.insertBatchStoredProcedure("02_ME", "ME_Track", 15);
            //obj2.insertBatchStoredProcedure("01_ICPC_C", "ICPC_C", 12);


            Console.WriteLine("******************* SQL DataAdapter *****************");
            DataAdapterClass obj3 = new DataAdapterClass();
            //obj3.insertFaculty("Prithvi", "prithvi.pagala@ltts.com", 99004990);
            //obj3.insertFaculty("Kartik", "kartik.mudaliar@ltts.com", 99004992);

            //obj3.updateBatchFaculty("02_07_DSP_C#", 99004992);
            //obj3.deleteGrader(99004955);
            Console.WriteLine("******************* SQL DataReader *****************");
            ExecuteReaderClass obj4 = new ExecuteReaderClass();
           // obj4.insertFaculty("Tejashri", "tejashri.wagh@ltts.com", 99004950);
           // obj4.updateBatchFaculty("02_07_DSP_Java", 99004990);
           // obj4.deleteGrader(99004957);

            Console.ReadKey();
        }
    }
}
