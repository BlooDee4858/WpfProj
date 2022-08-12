
using System;

namespace WpfProject.Model
{
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Patronymic { get; set; }
        public DateTime Birthday { get; set; }
        public DateTime DateOfEmployment { get; set; }
        public string JobTitle { get; set; }
        public decimal Salary { get; set; }
        public int DepartmentID { get; set; }
        public virtual Department Department { get; set; }

    }
}
