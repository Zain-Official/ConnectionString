using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
namespace ConnectionString
{
    class Insert_Details
    {
        static void Main(string[] args)
        {
            int emp_ID, emp_Age, emp_Salary;
            string emp_Name, emp_Nationality, emp_Gender;

            Console.WriteLine("Enter Employe Name");
            emp_Name = Console.ReadLine();

            // Console.WriteLine("Enter Employe ID");
            // emp_ID = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter Employe Age");
            emp_Age = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter Employe Country");
            emp_Nationality = Console.ReadLine();


            Console.WriteLine("Enter Employe Gender");
            emp_Gender = Console.ReadLine();

            Console.WriteLine("Enter Employe Salary");
            emp_Salary = Convert.ToInt32(Console.ReadLine());

 

            SqlConnection conn = new SqlConnection(@"Integrated security = true; initial catalog = Practice; data source =DESKTOP-N43NUMQ\ZAIN_SINDHI");
            SqlDataAdapter adapter = new SqlDataAdapter("Select * from employe",conn);
            SqlCommandBuilder sqlCommandBuilder = new SqlCommandBuilder(adapter);
            DataSet dataSet = new DataSet();
            adapter.Fill(dataSet,"employe");

            DataRow dataRow = dataSet.Tables["employe"].NewRow();

        //    dataRow["emp_ID"] = emp_ID;
            dataRow["emp_Name"] = emp_Name;
            dataRow["emp_Age"] = emp_Age;
            dataRow["emp_Gender"] = emp_Gender;
            dataRow["emp_Nationality"] = emp_Nationality;
            dataRow["emp_Salary"] = emp_Salary;

            dataSet.Tables["employe"].Rows.Add(dataRow);

            adapter.Update(dataSet,"employe");

            Console.WriteLine("Record Inserted Successfully");





        }
    }

}
