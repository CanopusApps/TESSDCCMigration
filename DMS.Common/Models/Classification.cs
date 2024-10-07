using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS.Common.Models
{
    public class Classification
    {
        public Guid ID { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Level { get; set; }
        public string FolderName { get; set; }
        public Guid PlantID { get; set; }
        public string PlantName { get; set; }
        public bool IsActive { get; set; }
        public Guid CreatedID { get; set; }
        public DateTime CreatedDate { get; set; }
        public Guid ModifiedID { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
