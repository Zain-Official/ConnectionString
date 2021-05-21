using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
namespace ConnectionString.DeleteSQL
{
    class Main_Method
    {
        static void Main(string[] args)
        {
            int emp_ID;

            Console.WriteLine("Enter Employe ID");
            emp_ID = Convert.ToInt32(Console.ReadLine());

            SqlConnection conn = new SqlConnection(@"Integrated security = true; initial catalog = Practice; data source =DESKTOP-N43NUMQ\ZAIN_SINDHI");
            SqlDataAdapter adapter = new SqlDataAdapter("Select * from employe where emp_ID=@empno", conn);
            adapter.SelectCommand.Parameters.AddWithValue("@empno", emp_ID);
            SqlCommandBuilder sqlCommandBuilder = new SqlCommandBuilder(adapter);
            DataSet dataSet = new DataSet();
            adapter.Fill(dataSet, "employe");

            DataRow dataRow = dataSet.Tables["employe"].Rows[0];
            dataRow.Delete();
            adapter.Update(dataSet,"employe");

            Console.WriteLine("Recorded Deleted Successfully .......");

        }
    }
}
