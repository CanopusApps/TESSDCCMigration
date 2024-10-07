using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS.Common.Models
{
    public class User
    {
        public Guid ID { get; set; }
        public string EMPID { get; set; }
        public string LoginID { get; set; }
        public string DisplayName { get; set; }
        public string EmailID { get; set; }
        public Guid DepartmentID { get; set; }
        public string DepartmentCode { get; set; }
        public string DepartmentShortName { get; set; }
        public string DepartmentName { get; set; }
        public Guid ManagerID { get; set; }
        public string ManagerName { get; set; }
        public Guid HODID { get; set; }
        public string HODName { get; set; }
        public bool IsDCCAdmin { get; set; }
        public bool IsSuperAdmin { get; set; }
        public bool IsActive { get; set; }
    }
}
