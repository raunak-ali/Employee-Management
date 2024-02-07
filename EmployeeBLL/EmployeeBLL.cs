using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using EmployeeDAL;
using EmployeeEntity;
using System.IO;
namespace EmployeeBLL;

public class EmployeeBLL
    {

        private static bool ValidateEmployee(Employee Employee)
        {
            StringBuilder sb = new StringBuilder();
            bool validEmployee = true;
            if (Employee.EmployeeID == string.Empty)
            {
                validEmployee = false;
                sb.Append(Environment.NewLine + "Employee Id is Required can be blank");

            }
            if (!Regex.IsMatch(Employee.EmployeeID, @"[0-9]{4}-[0-9]{4}-[0-9]{4}"))
            {
                validEmployee = false;
                sb.Append(Environment.NewLine + "Employee Id Is Invalid..");
            }
            
            if (Employee.EmployeeName == string.Empty)
            {
                validEmployee = false;
                sb.Append(Environment.NewLine + "Employee Name Required");

            }
            else if (!Regex.IsMatch(Employee.EmployeeName, "^[A-Z][a-z]+"))
            {
                sb.Append("Employee name should start with Capital letter and it should have alphabets only\n");
                validEmployee = false;
            }
            if (Employee.Phone.Length < 10)
            {
                validEmployee = false;
                sb.Append(Environment.NewLine + "Required 10 Digit Contact Number");
            }
            else if (!Regex.IsMatch(Employee.Phone, "[7-9][0-9]{9}"))
            {
                sb.Append("Phone number should start with 7 or 8 or 9 and it should have exactly 10 digits\n");
                validEmployee = false;
            }
            if (validEmployee == false)
                throw new HMSException.HMSException(sb.ToString());
            return validEmployee;
        }

        public static bool AddEmployeeBL(Employee newEmployee)
        {
            bool EmployeeAdded = false;
            try
            {
                if (ValidateEmployee(newEmployee))
                {
                    EmployeeAdded = EmployeeDAL.EmployeeDAL.AddEmployeeDAL(newEmployee);
                }
            }
            catch (HMSException.HMSException e)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return EmployeeAdded;
        }

        public static List<Employee> GetAllEmployeesBL()
        {
            List<Employee> EmployeeList = null;
            try
            {
                EmployeeList = EmployeeDAL.EmployeeDAL.GetAllEmployeesDAL();
            }
            catch (HMSException.HMSException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return EmployeeList;
        }




        public static bool DeleteEmployeeBL(string deleteEmployeeID)
        {
            bool EmployeeDeleted = false;
            try
            {

               
                if (deleteEmployeeID!=string.Empty)
                {
                    EmployeeDeleted = EmployeeDAL.EmployeeDAL.DeleteEmployeeDAL(deleteEmployeeID);
                }
                else
                {
                    throw new HMSException.HMSException("Invalid Employee ID");
                }
            }
            catch (HMSException.HMSException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return EmployeeDeleted;
        }

        public static Employee SearchEmployeeBL(string searchEmployeeID)
        {
            Employee searchEmployee = null;
            try
            {
                searchEmployee = EmployeeDAL.EmployeeDAL.SearchEmployeeDAL(searchEmployeeID);
            }
            catch (HMSException.HMSException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return searchEmployee;

        }

        public static bool UpdateEmployeeBL(Employee updateEmployee)
        {
            bool EmployeeUpdated = false;
            try
            {
                if (ValidateEmployee(updateEmployee))
                {
                    EmployeeDAL.EmployeeDAL Employeedal = new EmployeeDAL.EmployeeDAL();
                    EmployeeUpdated = EmployeeDAL.EmployeeDAL.UpdateEmployeeDAL(updateEmployee);
                }
            }
            catch (HMSException.HMSException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return EmployeeUpdated;
        }

        public static void SetSerialization()
        {

            if (EmployeeDAL.EmployeeDAL.EmployeeList != null)
            {
                EmployeeDAL.EmployeeDAL.SetSerialization();
            }
        }
        public static void setlist()
        {
            try
            {
                if (File.Exists(Directory.GetCurrentDirectory() + "\\" + EmployeeDAL.EmployeeDAL.fileName))
                    EmployeeDAL.EmployeeDAL.SetList();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

    }

