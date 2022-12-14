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
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class EditCompanyWindow : Window
    {
        public EditCompanyWindow(Company company)
        {
            InitializeComponent();
            DataContext = new DataManageVM();
            DataManageVM.SelectCompany = company;
            DataManageVM.CompanyName = company.Name;
            DataManageVM.FoundationDate = company.Foundation;
            DataManageVM.CompanyAddress = company.Address;
        }
    }
}
