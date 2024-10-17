using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS.Common.Models
{
    public class DraftDocument
    {
        public int SeqNo { get; set; }
        public Guid ID { get; set; }
        public Guid ApplicantID { get; set; }
        public string ApplicantName { get; set; }
        public Guid ApplicantDepartmentID { get; set; }
        public string DepartmentShortName { get; set; }
        public string DepartmentName { get; set; }
        public Guid SectionID { get; set; }
        public string SectionCode { get; set; }
        public string SectionName { get; set; }
        public Guid ProjectID { get; set; }
        public string ProjectCode { get; set; }
        public string ProjectName { get; set; }
        public Guid ProjectTypeID { get; set; }
        public string ProjectTypeCode { get; set; }
        public string ProjectTypeName { get; set; }
        public Guid DocumentCategoryID { get; set; }
        public string DocumentCategoryCode { get; set; }
        public string DocumentCategoryName { get; set; }
        public Guid DocumentPublishID { get; set; }
        public string DocumentNumber { get; set; }
        public string DocumentName { get; set; }
        public string DocumentDescription { get; set; }
        public string DocumentSubject { get; set; }
        public string DocumentAuthor { get; set; }
        public string DocumentPath { get; set; }
        public string RevisionReason { get; set; }
        public Guid PlantID { get; set; }
        public string PlantCode { get; set; }
        public string PlantName { get; set; }
        public Guid ClassificationID { get; set; }
        public string ClassificationCode { get; set; }
        public string ClassificationName { get; set; }
        public string ClassificationFolder { get; set; }
        public string BigCategory { get; set; }
        public Guid SmallCategoryID { get; set; }
        public string SmallCategoryCode { get; set; }
        public string SmallCategoryName { get; set; }
        public string SmallCategoryFolder { get; set; }
        public Guid ModelID { get; set; }
        public string Model { get; set; }
        public Guid PartID { get; set; }
        public string Part { get; set; }
        public Guid WFExecutionID { get; set; }
        public Guid ConfidenceLevelID { get; set; }
        public string ConfidenceLevel { get; set; }
        public Guid CustomerID { get; set; }
        public string Customer { get; set; }
        public Guid CertificationID { get; set; }
        public string Certification { get; set; }
        public Guid FunctionID { get; set; }
        public string Function { get; set; }
        public string Stage { get; set; }
        public string Version { get; set; }
        public string Comments { get; set; }        
        public bool IsMultipleApprovers { get; set; }
        public MultipleApprovers MultipleApprovers { get; set; }
        public MultipleApproversDisplay MultipleApproversDisplay { get; set; }
        public Guid WorkflowID { get; set; }
        public Guid ExecutionID { get; set; }
        public Guid CurrentStageID { get; set; }
        public string CurrentStage { get; set; }
        public string WorkflowStatus { get; set; }
        public Guid ActionedID { get; set; }
        public string ActionByName { get; set; }
        public string Action { get; set; }
        public string ActionComments { get; set; }
        public Guid UploadedUserID { get; set; }
        public string UploadedUserName { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string PublishedOn { get; set; }
        public int PendingDays { get; set; }
        public byte[] ByteArray { get; set; }
        public bool IsActive { get; set; }

        public List<WorkflowStages> WorkflowStages;
    }

    public class WorkflowStages
    {
        public Guid ID { get; set; }
        public int RNo { get; set; }
        public string StageName { get; set; }
        public Guid WFActionedID { get; set; }
        public bool WFActionMandatory { get; set; }
        public string ActionUserName { get; set; }
        public string WFAction { get; set; }
        public DateTime? WFActionDate { get; set; }
        public string ActionComments { get; set; }
        public string Status { get; set; }
    }
}
