using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS.Common.Models
{
    public class Department
    {
        public Guid ID { get; set; }
        public string Code { get; set; }
        public string ShortName { get; set; }
        public string Name { get; set; }
        public Guid HODID { get; set; }
        public bool IsActive { get; set; }
        public Guid CreatedID { get; set; }
        public DateTime CreatedDate { get; set; }
        public Guid ModifiedID { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
