using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hydac.Models
{
    public class Department
    {
        public int DepartmentId { get; }
        public string DepartmentType { get; set; }

        public string DepartmentManager { get; set; }
        public string DepartmentPhone { get; set; }

        //Constructor fra vores DCD
        //public Department(string departmentType, string departmentManager, string departmentPhone)
        //{
        //    DepartmentType = departmentType;
        //    DepartmentManager = departmentManager;
        //    DepartmentPhone = departmentPhone;
        //}

        //Constructor taget ud fra PetParadise
        public Department(int departmentId)
        {
            DepartmentId = departmentId;
        }
    }
}
