using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
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
                AllDepartment = value;
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

        public string CompanyName { get; set; }
        public DateTime FoundationDate { get; set; }
        public string CompanyAddress { get; set; }

        #region COMMANDS TO ADD
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
                        SetRedBlockControll(wnd, "NameBlock");
                    }
                    else
                    {
                        result = DataWorker.CreateCompany(CompanyName, FoundationDate, CompanyAddress);
                    }
                    
                });
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
        private void OpenEditCompanyWindowMethod()
        {
            EditCompanyWindow newCompanyWindow = new EditCompanyWindow();
            SetCenterPositionAndOpen(newCompanyWindow);
        }

        private void OpenEditDepartmentWindowMethod()
        {
            EditDepartmentWindow newDepartmentWindow = new EditDepartmentWindow();
            SetCenterPositionAndOpen(newDepartmentWindow);
        }

        private void OpenEditEmployeeWindowMethod()
        {
            EditEmployeeWindow newEmployeeWindow = new EditEmployeeWindow();
            SetCenterPositionAndOpen(newEmployeeWindow);
        }


        private void SetCenterPositionAndOpen(Window window)
        {
            window.Owner = Application.Current.MainWindow;
            window.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            window.ShowDialog();
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
