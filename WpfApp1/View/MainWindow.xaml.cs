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
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfProject.ViewModel;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static ListView AllCompanysView;
        public static ListView AllDepartmentsView;
        public static ListView AllEmployeesView;
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new DataManageVM();
            AllCompanysView = ViewAllCompanys;
            AllDepartmentsView = ViewAllDepartments;
            AllEmployeesView = ViewAllEmployees; 
        }
    }
}
