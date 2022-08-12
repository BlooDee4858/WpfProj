using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfProject.Model;

namespace WpfProject.Model
{
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Foundation { get; set; }
        public string Address { get; set; }
        public List<Department> Departments { get; set; }
    }
}
