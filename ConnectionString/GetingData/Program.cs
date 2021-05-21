using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace ConnectionString
{
    class Program
    {
        static void Main(string[] args)
        {
           // string strcon = ConfigurationManager.ConnectionStrings["sqlpracticeconn"].ConnectionString;
            SqlConnection conn = new SqlConnection(@"Integrated security = true; initial catalog = Practice; data source =DESKTOP-N43NUMQ\ZAIN_SINDHI");
            int empno;
            Console.WriteLine("Enter Employ Name");
            empno = Convert.ToInt32(Console.ReadLine());
            string query = "Select * from employe Where emp_ID =@empno";
            SqlDataAdapter adapter = new SqlDataAdapter(query,conn);
            adapter.SelectCommand.Parameters.AddWithValue("@empno",empno);
            DataSet dataSet = new DataSet();
            adapter.Fill(dataSet,"employe");
            int Count = dataSet.Tables["employe"].Rows.Count;
            if(Count == 1)
            {
                Console.WriteLine("Employe Name : "+dataSet.Tables["employe"].Rows[0]["emp_Name"]);
                Console.WriteLine("Employe Age : "+dataSet.Tables["employe"].Rows[0]["emp_Age"]);
                Console.WriteLine("Employe Country : " + dataSet.Tables["employe"].Rows[0]["emp_Nationality"]);
                Console.WriteLine("Employe Gender : " + dataSet.Tables["employe"].Rows[0]["emp_Gender"]);
                Console.WriteLine("Employe Salary : " + dataSet.Tables["employe"].Rows[0]["emp_Salary"]);

            }
            else
            {
                Console.WriteLine("Records Not Found");
            }
        }
    }
}
