using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WpfProject.Model;
using WpfProject.ViewModel;

namespace WpfProject.View
{
    /// <summary>
    /// Логика взаимодействия для EditEmployee.xaml
    /// </summary>
    public partial class EditEmployeeWindow : Window
    {
        public EditEmployeeWindow(Employee employee)
        {
            InitializeComponent();
            DataContext = new DataManageVM();
            DataManageVM.SelectedEmployee = employee;
            DataManageVM.FirstName = employee.FirstName;
            DataManageVM.LastName = employee.LastName;  
            DataManageVM.Patronymic = employee.Patronymic;
            DataManageVM.Birthday = employee.Birthday;
            DataManageVM.DateOfEmployment = employee.DateOfEmployment;
            DataManageVM.JobTitle = employee.JobTitle;
            DataManageVM.Salary = employee.Salary;
        }
    }
}
