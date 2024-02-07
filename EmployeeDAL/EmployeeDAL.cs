using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

using System.Xml.Serialization;


using EmployeeEntity;

namespace EmployeeDAL;

public class EmployeeDAL
{
 public static List<Employee> EmployeeList = new List<Employee>();
 public static string fileName = "EmployeeList";

 public static bool AddEmployeeDAL(Employee newEmployee)
 {
     bool patinetAdded = false;
     try
     {


         EmployeeList.Add(newEmployee);

         patinetAdded = true;
         SetSerialization();


     }
     catch (Exception ex)
     {
         throw new HMSException.HMSException(ex.Message);
     }
     return patinetAdded;

 }

 public static List<Employee> GetAllEmployeesDAL()
 {
     return EmployeeList;
 }

 public static bool DeleteEmployeeDAL(string deleteEmployeeID)
 {
     bool EmployeeDeleted = false;
     try
     {
         for (int i = 0; i < EmployeeList.Count; i++)
         {
             Employee Employee = EmployeeList[i];
             if (Employee.EmployeeID == deleteEmployeeID)
             {
                 EmployeeList.RemoveAt(i);
                 EmployeeDeleted = true;
                 SetSerialization();//Is being stored in a file
                 break;
             }
         }

     }
     catch (Exception ex)
     {
         throw new HMSException.HMSException(ex.Message);
     }
     return EmployeeDeleted;

 }


 public static Employee SearchEmployeeDAL(string searchEmployeeID)
 {
     Employee searchEmployee = null;
     try
     {


         for (int i = 0; i < EmployeeList.Count; i++)
         {
             Employee Employee = EmployeeList[i];
             if (Employee.EmployeeID == searchEmployeeID)
             {
                 searchEmployee = EmployeeList[i];
                 break;
             }
         }
     }
     catch (Exception ex)
     {
         throw new HMSException.HMSException(ex.Message);
     }
     return searchEmployee;
 }

 public static bool UpdateEmployeeDAL(Employee updateEmployee)
 {
     bool EmployeeUpdated = false;
     try
     {


         for (int i = 0; i < EmployeeList.Count; i++)
         {
             Employee Employee = EmployeeList[i];
             if (Employee.EmployeeID == updateEmployee.EmployeeID)
             {
                 EmployeeList[i] = updateEmployee;
                 SetSerialization();
                 break;
             }
         }

         EmployeeUpdated = true;
     }
     catch (Exception ex)
     {
         throw new HMSException.HMSException(ex.Message);
     }
     return EmployeeUpdated;

 }


 public static void SetSerialization()
 {
     try
     {
         using (Stream file = File.Open(fileName, FileMode.Create))
         {
             XmlSerializer bf = new XmlSerializer(typeof(Employee));
             //TextWriter writer = new StreamWriter(fileName);
             bf.Serialize(file, EmployeeList);
             file.Close();
         }
     }
     catch (FileNotFoundException ex)
     {
         Console.WriteLine("File not found.");
     }
     catch (Exception ex)
     {
         Console.WriteLine(ex.Message);
     }

 }

 //Setting List if the file already exists
 public static void SetList()
 {
     DeserializeFile();
 }
 public static void DeserializeFile()
 {
     try
     {

         using (Stream file = File.Open(Directory.GetCurrentDirectory() + "\\" + fileName, FileMode.Open))
         {
              XmlSerializer bf = new XmlSerializer(typeof(Employee));
             EmployeeList = bf.Deserialize(file) as List<Employee>;
             file.Close();
         }
     }
     catch (FileNotFoundException ex)
     {
         Console.WriteLine(ex.Message);
     }
     catch (Exception ex)
     {
         Console.WriteLine(ex.Message);
     }
     //foreach (var Employee in EmployeeList)
     //{
     //    Console.WriteLine(Employee.EmployeeID);
     //}
 }
}
