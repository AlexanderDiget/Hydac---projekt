using Hydac.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hydac.ViewModels
{
    public class DepartmentViewModel
    {
        private DepartmentRepository departmentRepo = new DepartmentRepository();
        public ObservableCollection<Department> DepartmentsVM { get; set; } = new ObservableCollection<Department>();

        public DepartmentViewModel()
        {
            foreach (var item in departmentRepo._departments)
            {
                DepartmentsVM.Add(item);
            }
        }
    }
}
