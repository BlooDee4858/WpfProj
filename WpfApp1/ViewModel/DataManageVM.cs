using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using WpfApp1;
using WpfProject.Model;
using WpfProject.View;

namespace WpfProject.ViewModel
{
    public class DataManageVM : INotifyPropertyChanged
    {
        //все компании
        private List<Company> allCompany = DataWorker.GetAllCompanys();
        
        public List<Company> AllCompany
        {
            get { return allCompany; }
            set 
            { 
                allCompany = value;
                NotifyPropertyChanged("AllCompany");
            }
        }
        //Все подразделения
        private List<Department> allDepartment = DataWorker.GetAllDepartments();
        public List<Department> AllDepartment
        {
            get { return allDepartment; }
            set
            {
                allDepartment = value;
                NotifyPropertyChanged("AllDepartment");
            }
        }
        private List<Employee> allEmployee = DataWorker.GetAllEmployees();
        public List<Employee> AllEmployee
        {
            get { return allEmployee; }
            set
            {
                allEmployee = value;
                NotifyPropertyChanged("AllEmployee");
            }
        }
        //свойства для выделенных элементов
        public TabItem SelectedTabItem { get; set; }
        public static Company SelectedCompany { get; set; }
        public static Department SelectedDepartment { get; set; }  
        public static Employee SelectedEmployee { get; set; }  


        #region COMMANDS TO ADD
        //Свойства для Компаний
        public static string CompanyName { get; set; }
        public static DateTime FoundationDate { get; set; }
        public static string CompanyAddress { get; set; }

        //Свойства для Отделов
        public static string DepartmentName { get; set; }
        public static string Head { get; set; }
        public static Company SelectCompany { get; set; }

        //Свойства для рабочих
        public static string FirstName { get; set; }
        public static string LastName { get; set; }
        public static string Patronymic { get; set; }
        public static DateTime Birthday { get; set; }
        public static DateTime DateOfEmployment { get; set; }
        public static string JobTitle { get; set; }    
        public static decimal Salary { get; set; }
        public static Department EmployeeDepartment { get; set; }

        //Функции добавления

        private RelayCommand addNewCompany;
        public RelayCommand AddNewCompany
        {
            get 
            {
                return addNewCompany ?? new RelayCommand(obj =>
                {
                    Window wnd = obj as Window;
                    string result = "";
                    if(CompanyName == null || CompanyName.Replace(" ","").Length == 0)
                    {
                        SetRedBlockControll(wnd, "CompanyName");
                    }
                    else
                    {
                        result = DataWorker.CreateCompany(CompanyName, FoundationDate, CompanyAddress);
                        UpdateAllDataView();
                        SetNullValuesToProperties();
                        wnd.Close();
                    }
                    
                });
            }
        }

        private RelayCommand addNewDepartment;
        public RelayCommand AddNewDepartment
        {
            get
            {
                return addNewDepartment ?? new RelayCommand(obj =>
                {
                    Window wnd = obj as Window;
                    string result = "";
                    if (DepartmentName == null || DepartmentName.Replace(" ", "").Length == 0)
                    {
                        SetRedBlockControll(wnd, "DepartmentName");
                    }
                    else
                    {
                        result = DataWorker.CreateDepartment(DepartmentName, Head, SelectCompany);
                        UpdateAllDataView();
                        SetNullValuesToProperties();
                        wnd.Close();
                    }

                });
            }
        }

        private RelayCommand addNewEmployee;
        public RelayCommand AddNewEmployee
        {
            get
            {
                return addNewEmployee ?? new RelayCommand(obj =>
                {
                    Window wnd = obj as Window;
                    string result = "";
                    if (FirstName == null || FirstName.Replace(" ", "").Length == 0)
                    {
                        SetRedBlockControll(wnd, "FirstName");
                    }
                    else
                    {
                        result = DataWorker.CreateEmployee(FirstName,LastName,Patronymic,Birthday,DateOfEmployment,JobTitle,Salary, EmployeeDepartment);
                        UpdateAllDataView();
                        SetNullValuesToProperties();
                        wnd.Close();
                    }

                });
            }
        }


        #endregion

        private RelayCommand deleteItem;
        public RelayCommand DeleteItem
        {
            get
            {
                return deleteItem ?? new RelayCommand(obj =>
                {
                    //Если компания
                    if (SelectedTabItem.Name == "CompanyTab" && SelectedCompany != null)
                    {
                        DataWorker.DeleteCompany(SelectedCompany);
                        UpdateAllDataView();
                    }
                    //Если отдел
                    if (SelectedTabItem.Name == "DepartmentTab" && SelectedDepartment != null)
                    {
                        DataWorker.DeleteDepartment(SelectedDepartment);
                        UpdateAllDataView();
                    }
                    //Если рабочий
                    if (SelectedTabItem.Name == "EmployeeTab" && SelectedEmployee != null)
                    {
                        DataWorker.DeleteEmployee(SelectedEmployee);
                        UpdateAllDataView();
                    }
                    //Обновление
                    SetNullValuesToProperties();

                }
                );
            }
        }
        private RelayCommand editItem;
        public RelayCommand EditItem
        {
            get
            {
                return editItem ?? new RelayCommand(obj =>
                {
                    //Если компания
                    if (SelectedTabItem.Name == "CompanyTab" && SelectedCompany != null)
                    {
                        OpenEditCompanyWindowMethod(SelectedCompany);
                    }
                    //Если отдел
                    if (SelectedTabItem.Name == "DepartmentTab" && SelectedDepartment != null)
                    {
                        OpenEditDepartmentWindowMethod(SelectedDepartment);
                    }
                    //Если рабочий
                    if (SelectedTabItem.Name == "EmployeeTab" && SelectedEmployee != null)
                    {
                        OpenEditEmployeeWindowMethod(SelectedEmployee);
                    }
                }
                );
            }
        }

        #region EDIT COMMANDS
        private RelayCommand editCompany;
        public RelayCommand EditCompany
        {
            get
            {
                return editCompany ?? new RelayCommand(obj =>
                {
                    Window window = obj as Window;
                    if(SelectCompany != null)
                    {
                        DataWorker.EditCompany(SelectedCompany, CompanyName, FoundationDate, CompanyAddress);
                        UpdateAllDataView();
                        SetNullValuesToProperties();
                        window.Close();
                    }
                }
                );
            }
        }
        private RelayCommand editDepartment;
        public RelayCommand EditDepartment
        {
            get
            {
                return editDepartment ?? new RelayCommand(obj =>
                {
                    Window window = obj as Window;
                    if (SelectedDepartment != null)
                    {
                        DataWorker.EditDepartment(SelectedDepartment, DepartmentName, Head, SelectCompany); 
                        UpdateAllDataView();
                        SetNullValuesToProperties();
                        window.Close();
                    }
                }
                );
            }
        }
        private RelayCommand editEmployee;
        public RelayCommand EditEmployee
        {
            get
            {
                return editDepartment ?? new RelayCommand(obj =>
                {
                    Window window = obj as Window;
                    if (SelectedEmployee != null)
                    {
                        DataWorker.EditEmployee(SelectedEmployee, FirstName, LastName, Patronymic, Birthday, DateOfEmployment, JobTitle, Salary, EmployeeDepartment);
                        UpdateAllDataView();
                        SetNullValuesToProperties();
                        window.Close();
                    }
                }
                );
            }
        }
        #endregion

        #region COMMANDS TO OPEN WINDOWS
        private RelayCommand openAddNewCompanyWindow;
        public RelayCommand OpenAddNewCompanyWindow
        {
            get
            {
                return openAddNewCompanyWindow ?? new RelayCommand(obj =>
                {
                    OpenAddCompanyWindowMethod();
                }
                );
            }
        }

        private RelayCommand openAddNewDepartmentWindow;
        public RelayCommand OpenAddNewDepartmentWindow
        {
            get
            {
                return openAddNewDepartmentWindow ?? new RelayCommand(obj =>
                {
                    OpenAddDepartmentWindowMethod();
                }
                );
            }
        }

        private RelayCommand openAddNewEmployeeWindow;
        public RelayCommand OpenAddNewEmployeeWindow
        {
            get
            {
                return openAddNewEmployeeWindow ?? new RelayCommand(obj =>
                {
                    OpenAddEmployeeWindowMethod();
                }
                );
            }
        }
        #endregion

        #region METHODS TO OPEN WINDOWS 
        private void OpenAddCompanyWindowMethod()
        {
            AddNewCompanyWindow newCompanyWindow = new AddNewCompanyWindow();
            SetCenterPositionAndOpen(newCompanyWindow);
        }

        private void OpenAddDepartmentWindowMethod()
        {
            AddNewDepartmentWindow newDepartmentWindow = new AddNewDepartmentWindow();
            SetCenterPositionAndOpen(newDepartmentWindow);
        }

        private void OpenAddEmployeeWindowMethod()
        {
            AddNewEmployeeWindow newEmployeeWindow = new AddNewEmployeeWindow();
            SetCenterPositionAndOpen(newEmployeeWindow);
        }
        private void OpenEditCompanyWindowMethod(Company company)
        {
            EditCompanyWindow newCompanyWindow = new EditCompanyWindow(company);
            SetCenterPositionAndOpen(newCompanyWindow);
        }

        private void OpenEditDepartmentWindowMethod(Department department)
        {
            EditDepartmentWindow newDepartmentWindow = new EditDepartmentWindow(department);
            SetCenterPositionAndOpen(newDepartmentWindow);
        }

        private void OpenEditEmployeeWindowMethod(Employee employee)
        {
            EditEmployeeWindow newEmployeeWindow = new EditEmployeeWindow(employee);
            SetCenterPositionAndOpen(newEmployeeWindow);
        }


        private void SetCenterPositionAndOpen(Window window)
        {
            window.Owner = Application.Current.MainWindow;
            window.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            window.ShowDialog();
        }
        #endregion

        #region UPDATE VIEWS
        private void SetNullValuesToProperties()
        {
            CompanyName = null;
            CompanyAddress = null;
            FirstName  = null;
            LastName   = null;
            Patronymic = null;
            JobTitle = null;
            Salary = 0;
    }
        private void UpdateAllDataView()
        {
            UpdateAllCompanysView();
            UpdateAllDepartmentsView();
            UpdateAllEmployeesView();
        }
        private void UpdateAllCompanysView()
        {
            AllCompany = DataWorker.GetAllCompanys();
            MainWindow.AllCompanysView.ItemsSource = null;
            MainWindow.AllCompanysView.Items.Clear();
            MainWindow.AllCompanysView.ItemsSource = AllCompany;
            MainWindow.AllCompanysView.Items.Refresh();
        }
        private void UpdateAllDepartmentsView()
        {
            AllDepartment = DataWorker.GetAllDepartments();
            MainWindow.AllDepartmentsView.ItemsSource = null;
            MainWindow.AllDepartmentsView.Items.Clear();
            MainWindow.AllDepartmentsView.ItemsSource = AllDepartment;
            MainWindow.AllDepartmentsView.Items.Refresh();
        }
        private void UpdateAllEmployeesView()
        {
            AllEmployee = DataWorker.GetAllEmployees();
            MainWindow.AllEmployeesView.ItemsSource = null;
            MainWindow.AllEmployeesView.Items.Clear();
            MainWindow.AllEmployeesView.ItemsSource = AllEmployee;
            MainWindow.AllEmployeesView.Items.Refresh();
        }
        #endregion
        private void SetRedBlockControll(Window window, string blockName)
        {
            Control block = window.FindName(blockName) as Control;
            block.BorderBrush = Brushes.Red;
        }
        public event PropertyChangedEventHandler? PropertyChanged;

        private void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
