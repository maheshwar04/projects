using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace DatabaseProject
{
    public class Employee
    {
        static string connectionString = "Server=6B54BEE44E375E5\\SQLEXPRESS;Database=master;Trusted_Connection=True;" +
            "Initial Catalog=MarketingCompany;Pooling=False;" + "Encrypt=False;Trust Server Certificate=False";
        public static void StoreDepartmentDetails(int id, string name, string head, string description)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Department VALUES (@id, @name, @head, @description)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@head", head);
                cmd.Parameters.AddWithValue("@description", description);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();

                Console.WriteLine("Department inserted successfully.");
            }
        }

        public static void StoreEmployeeDetails(int id, string name, string address, decimal salary, long contact, int deptId)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Employee VALUES (@id, @name, @address, @salary, @contact, @deptId)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@address", address);
                cmd.Parameters.AddWithValue("@salary", salary);
                cmd.Parameters.AddWithValue("@contact", contact);
                cmd.Parameters.AddWithValue("@deptId", deptId);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();

                Console.WriteLine("Employee inserted successfully.");
            }
        }

        public static void RetrieveEmployeeDetails(int empId)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"SELECT e.Employee_Name, e.Employee_Contact_No, e.Employee_Address, 
                         d.Department_Name, d.Department_Head 
                         FROM Employee e 
                         JOIN Department d ON e.Department_ID = d.Department_ID 
                         WHERE e.Employee_ID = @empId";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@empId", empId);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    Console.WriteLine($"Name: {reader["Employee_Name"]}");
                    Console.WriteLine($"Contact: {reader["Employee_Contact_No"]}");
                    Console.WriteLine($"Address: {reader["Employee_Address"]}");
                    Console.WriteLine($"Department: {reader["Department_Name"]}");
                    Console.WriteLine($"Department Head: {reader["Department_Head"]}");
                }
                else
                {
                    Console.WriteLine("Employee Not Present");
                }

                conn.Close();
            }
        }

        public static void CalculatePF(int empId)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("CalculatePF", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@EmployeeID", empId);
                SqlParameter outputParam = new SqlParameter("@PFAmount", System.Data.SqlDbType.Decimal)
                {
                    Direction = System.Data.ParameterDirection.Output
                };
                cmd.Parameters.Add(outputParam);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();

                Console.WriteLine($"Employee PF amount is: {outputParam.Value}");
            }
        }

        public static void StoreEmployeeDetailsWithExceptionHandling(int id, string name, string address, decimal salary, long contact, int deptId)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    string query = "INSERT INTO Employee VALUES (@id, @name, @address, @salary, @contact, @deptId)";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@address", address);
                    cmd.Parameters.AddWithValue("@salary", salary);
                    cmd.Parameters.AddWithValue("@contact", contact);
                    cmd.Parameters.AddWithValue("@deptId", deptId);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();

                    Console.WriteLine("Employee inserted successfully.");
                }
                catch (SqlException ex)
                {
                    Console.WriteLine($"SQL Error: {ex.Message}");
                }
            }
        }
    }
}
