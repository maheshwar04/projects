namespace DatabaseProject
{
    internal class Program
    {
        static void Main()
        {
            try
            {
                
                Employee.StoreDepartmentDetails(1, "Accounts", "Ramesh", "Accounts Dept");
                Employee.StoreDepartmentDetails(2, "Admin", "Vijay", "Admin Dept");
                Employee.StoreDepartmentDetails(3, "Sales", "Vinod", "Sales Dept");
                Employee.StoreDepartmentDetails(4, "HR", "Mahesh", "HR Dept");

               
                Employee.StoreEmployeeDetails(87, "Vikram", "Address 1", 12000, 9878761212, 2);
                Employee.StoreEmployeeDetails(110, "Ajay", "Address 2", 18000, 9956743143, 2);
                Employee.StoreEmployeeDetails(98, "Rajesh", "Address 3", 19000, 9995322741, 3);
                Employee.StoreEmployeeDetails(45, "Vimal", "Address 4", 27000, 9978133432, 3);
                Employee.StoreEmployeeDetails(987, "Kiran", "Address 6", 210000, 7076337238, 4);

                
                //Console.WriteLine("\nTrying to insert duplicate employee...");
                //Employee.StoreEmployeeDetails(87, "Jack", "Address 1", 12000, 9942346551, 2); 

               
                //Console.WriteLine("\nTrying to insert employee with invalid Department ID...");
                //Employee.StoreEmployeeDetails(123, "Ron", "Address 1", 12000, 9942346551, 10); 

                
                //Console.WriteLine("\nTrying to insert employee with salary below 1000...");
                //Employee.StoreEmployeeDetails(124, "Jim", "Address 1", 500, 9232346551, 2); 

               
                Console.WriteLine("\nRetrieving Employee Data:");
                Employee.RetrieveEmployeeDetails(87);
                Employee.RetrieveEmployeeDetails(110);
                Employee.RetrieveEmployeeDetails(98);
                Employee.RetrieveEmployeeDetails(45);
                Employee.RetrieveEmployeeDetails(987);

                
                Console.WriteLine("\nCalculating PF:");
                Employee.CalculatePF(87);
                Employee.CalculatePF(110);
                Employee.CalculatePF(98);
                Employee.CalculatePF(45);
                Employee.CalculatePF(987);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
        }
}
