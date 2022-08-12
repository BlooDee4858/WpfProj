using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfProject.Model.Data;

namespace WpfProject.Model
{
    public static class DataWorker
    {
        //получить все компании
        public static List<Company> GetAllCompanys()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var result = db.Companys.ToList();
                return result;
            }
        }
        //получить все подразделения
        public static List<Department> GetAllDepartments()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var result = db.Departments.ToList();
                return result;
            }
        }
        //получить всех рабочих
        public static List<Employee> GetAllEmployees()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var result = db.Employees.ToList();
                return result;
            }
        }
        //создать компанию
        public static string CreateCompany(string name, DateTime found, string address)
        {
            bool checkIsExist;
            using (ApplicationContext db = new ApplicationContext())
            {
                //Проверяем, существует ли компания
                checkIsExist = db.Companys.Any(el =>  el.Name == name);
                if(!checkIsExist)
                {
                    Company company = new Company
                    { 
                        Name = name
                        ,Foundation = found
                        ,Address = address
                    };
                    db.Companys.Add(company);
                    db.SaveChanges();
                    
                }
            }
            if(!checkIsExist)
                return "Company added successfully";
            else
                return "Company alredy exist";
        }
        //создать подразделение
        public static string CreateDepartment(string name, string head, Company company)
        {
            bool checkIsExist;
            using (ApplicationContext db = new ApplicationContext())
            {
                //Проверяем, существует ли подразделение
                checkIsExist = db.Departments.Any(el => el.Name == name);
                if (!checkIsExist)
                {
                    Department department = new Department
                    { 
                        Name = name
                        ,Head = head
                        ,CompanyId = company.Id 
                    };
                    db.Companys.Add(company);
                    db.SaveChanges();
                }
            }
            if (!checkIsExist)
                return "Department added successfully";
            else
                return "Department alredy exist";
        }

        //Создать рабочего :)
        public static string CreateEmployee(string firstName, string lastName, string patronymic, DateTime birthday,
            DateTime dateOfEmployment, String jobTitle, decimal salary, Department department)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
    
                    Employee employee = new Employee 
                    { 
                        FirstName = firstName
                        ,LastName = lastName
                        ,Patronymic = patronymic
                        ,Birthday = birthday
                        ,DateOfEmployment = dateOfEmployment
                        ,JobTitle = jobTitle
                        ,Salary = salary
                        ,DepartmentID = department.Id
                    };
                    db.Employees.Add(employee);
                    db.SaveChanges();
            }
            return "Employee added successfully";
        }
        //Удаление компании
        public static string DeleteCompany(Company company)
        {
            using (ApplicationContext db = new ApplicationContext())
            { 
                db.Companys.Remove(company);
                db.SaveChanges();
            }
            return "Company deleted successfully";
        }

        public static string DeleteDepartment(Department department)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                db.Departments.Remove(department);
                db.SaveChanges();
            }
            return "Подразделение удалено";
        }

        public static string DeleteEmployee(Employee employee)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                db.Employees.Remove(employee);
                db.SaveChanges();
            }
            return "Рабочий удалён";
        }
        //редактирование компании
        public static void EditCompany(Company oldCompany, string name, DateTime found, string address)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                Company company = db.Companys.FirstOrDefault(x => x.Id == oldCompany.Id);
                company.Name = name;
                company.Foundation = found;
                company.Address = address;
                db.SaveChanges(); 
            }           
        }
        //редактирование подразделения
        public static void EditDepartment(Department oldDepartment, string name, string head, Company company)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                Department department = db.Departments.FirstOrDefault(x => x.Id == oldDepartment.Id);
                department.Name = name;
                department.Head = head; 
                department.CompanyId = company.Id;
                db.SaveChanges();
            }

        }
        //редактирование рабочего
        public static string EditEmployee(Employee oldEmployee, string firstName, string lastName, string patronymic, DateTime birthday,
            DateTime dateOfEmployment, String jobTitle, decimal salary, Department department)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                Employee employee = db.Employees.FirstOrDefault(x => x.Id == oldEmployee.Id);
                employee.FirstName = firstName;
                employee.LastName = lastName;
                employee.Patronymic = patronymic;
                employee.Birthday = birthday;
                employee.DateOfEmployment = dateOfEmployment;
                employee.JobTitle = jobTitle;
                employee.Salary = salary;
                employee.DepartmentID = department.Id;
                db.SaveChanges();
            }
            return "Employee added successfully";
        }
    }
}
