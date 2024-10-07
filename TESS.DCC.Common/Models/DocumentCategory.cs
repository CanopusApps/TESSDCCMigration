﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEPL.QMS.Common.Models
{
    public class DocumentCategory
    {
        public Guid ID { get; set; }
        public string Code { get; set; }
        public string Title { get; set; }
        public string DocumentLevel { get; set; }
        public string FolderName { get; set; }
        public bool Active { get; set; }
        public string CreatedBy { get; set; }
        public DateTime Created { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime Modified { get; set; }
    }
}
