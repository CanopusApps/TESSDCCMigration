using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS.Common.Models
{
    public class LoginUser
    {
        public Guid ID { get; set; }
        public string EmpID { get; set; }
        public string LoginID { get; set; }
        public string DisplayName { get; set; }
        public string EmailID { get; set; }
        public string DeptID { get; set; }
        public string DeptShortName { get; set; }
        public string DeptName { get; set; }
        public Guid ManagerID { get; set; }
        public Guid HODID { get; set; }
        public string Roles { get; set; }
        public string CreatedBy { get; set; }
        public List<Project> Projects { get; set; }


    }
}
