using System;

namespace DMS.Common.Models
{
    public class DocumentNumber
    {
        public Guid ID { get; set; }
        public string PlantCode { get; set; }
        public string PlantName { get; set; }
        public string SmallCategoryCode { get; set; }
        public string SmallCategoryName { get; set; }
        public string ClassificationCode { get; set; }
        public string ClassificationName { get; set; }
        public string SerialNo { get; set; }
        public bool IsActive { get; set; }
        public Guid CreatedID { get; set; }
        public DateTime CreatedDate { get; set; }
        public Guid ModifiedID { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
