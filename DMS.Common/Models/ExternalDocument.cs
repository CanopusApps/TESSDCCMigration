﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS.Common.Models
{
    public class ExternalDocument
    {
        public Guid ID { get; set; }
        public string Title { get; set; }
        public string DocumentNo { get; set; }
        public int Version { get; set; }
        public DateTime VersionDate { get; set; }
        public string Organization { get; set; }
        public Guid ResponsibleUserID { get; set; }
        public string ResponsibleUser { get; set; }
        public string Department { get; set; }
        public string FileName { get; set; }
        public string FileURL { get; set; }
        public bool Active { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime Created { get; set; }
        public Guid ModifiedBy { get; set; }
        public DateTime Modified { get; set; }
    }
}
