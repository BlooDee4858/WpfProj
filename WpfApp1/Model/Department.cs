using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfProject.Model;

namespace WpfProject.Model
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Head { get; set; }
        public int CompanyId { get; set; }
        public virtual Company Company { get; set; }
        public List<Employee> Employees { get; set; }
        [NotMapped]
        public Company CompanyName
        {
            get
            {
                return DataWorker.GetCompanyById(CompanyId);
            }
        }
    }
}
