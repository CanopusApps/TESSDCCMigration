using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS.Workflow.Models
{
    public class DocumentApprover
    {
        public Guid ID { get; set; }
        public string StageName { get; set; }
        public string ApprovalUser { get; set; }
        public string ApprovalUserEmail { get; set; }

    }
}
