using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
namespace DMS.Common.Constants
{
    public static class QMSConstants
    {
        public static string DBCon = Convert.ToString(ConfigurationManager.ConnectionStrings["DBCon"]);
        public static string ServiceAccountName = Convert.ToString(ConfigurationManager.AppSettings["ServiceAccountName"]);
        public static string ServiceAccountPassword = Convert.ToString(ConfigurationManager.AppSettings["ServiceAccountPassword"]);
        public static string CompanyCode = Convert.ToString(ConfigurationManager.AppSettings["CompanyCode"]);
        public static string LoginRegEx = Convert.ToString(ConfigurationManager.AppSettings["LoginRegEx"]);
        public static string LogPath = Convert.ToString(ConfigurationManager.AppSettings["LogPath"]);
        public static string TempFolder = Convert.ToString(ConfigurationManager.AppSettings["TempFolder"]);
        public static string StoragePath = Convert.ToString(ConfigurationManager.AppSettings["StoragePath"]);
        public static string BackUpPath = Convert.ToString(ConfigurationManager.AppSettings["BackUpPath"]);
        public static string DraftFolder = Convert.ToString(ConfigurationManager.AppSettings["DraftFolder"]);
        public static string PublishedFolder = Convert.ToString(ConfigurationManager.AppSettings["PublishedFolder"]);
        public static string EditableFolder = Convert.ToString(ConfigurationManager.AppSettings["EditableFolder"]);
        public static string ReadableFolder = Convert.ToString(ConfigurationManager.AppSettings["ReadableFolder"]);
        public static string TemplateFolder = Convert.ToString(ConfigurationManager.AppSettings["TemplateFolder"]);
        public static string ExtDocumentFolder = Convert.ToString(ConfigurationManager.AppSettings["ExtDocumentFolder"]);
        public static string EncryptionKey = Convert.ToString(ConfigurationManager.AppSettings["EncryptionKey"]);
        public static Guid WorkflowID = Guid.Parse(ConfigurationManager.AppSettings["WorkflowID"]);

        public const string LoggedInUserID = "LoggedInUserID";
        public const string LoggedInUserDisplayName = "LoggedInUserDisplayName";
        public const string LoggedInUserDeptID = "LoggedInUserDeptID";
        public const string LoggedInUserDeptName = "LoggedInUserDeptName";
        public const string LoggedInUserDeptShortName = "LoggedInUserDeptShortName";        
        public const string LoggedInUserProjects = "LoggedInUserProjects";
        public const string LoggedInUserRoles = "LoggedInUserRoles";
        public const string AuthCookieName = "wistrondms";
        public static string DomainName = Convert.ToString(ConfigurationManager.AppSettings["DomainName"]);

        //StoredProcedures
        public static string spGenerateDocumentNo = "spGenerateDocumentNo";
        public static string spGetDocumentNumbers = "spGetDocumentNumbers";
        public static string spGetDocumentLevel = "spGetDocumentLevel";
        public static string spAddNewDocument = "spAddNewDocument"; 
        public static string spDocumentUpdate = "spDocumentUpdate";
        public static string spDocumentUpdatePublished = "spDocumentUpdatePublished";
        public static string spDocumentDescriptionUpdate = "spDocumentDescriptionUpdate";
        public static string spDocumentVersionUpdate = "spDocumentVersionUpdate";
        public static string spGetRequestedDocuments = "spGetRequestedDocuments";
        public static string spGetDocumentDetailsByID = "spGetDocumentDetailsByID";
        public static string spGetPublishedDocuments = "spGetPublishedDocuments";
        public static string spGetPublishedDocumentDetailsByID = "spGetPublishedDocumentDetailsByID";
        public static string spGetPublishedDocumentHistoryByID = "spGetPublishedDocumentHistoryByID";
        public static string spGetPublishedDocumentHistoryDetailsByID = "spGetPublishedDocumentHistoryDetailsByID";
        public static string spGetDocumentDetailsByNo = "spGetDocumentDetailsByNo";
        public static string spGetApprovalPendingDocuments = "spGetApprovalPendingDocuments";
        public static string spGetDraftDocuments = "spGetDraftDocuments";
        public static string spDocumentPublish = "spDocumentPublish";
        public static string spGetDepartments = "spGetDepartments";
        public static string spGetSectionsForDept = "spGetSectionsForDept";
        public static string spGetProjectTypes = "spGetProjectTypes";
        public static string spGetProjects = "spGetProjects";
        public static string spGetDocumentCategories = "spGetDocumentCategories";
        public static string spGetTemplateDocument = "spGetTemplateDocument";
        public static string spAddTemplateDocument = "spAddTemplateDocument";
        public static string spUpdateTemplateDocument = "spUpdateTemplateDocument";
        public static string spGetLoggedInUserRoles = "spGetLoggedInUserRoles";
        public static string spGetConfigValue = "spGetConfigValue";
        public static string spGetTaskSchedules = "spGetTaskSchedules";
        public static string spGetUserDetails = "spGetUserDetails";
        public static string spGetUserDetailsByID = "spGetUserDetailsByID";
        public static string spSearchUsers = "spSearchUsers";
        public static string spSearchProjectUsers = "spSearchProjectUsers";
        public static string spGetProjectUsers = "spGetProjectUsers";
        public static string spAddUserToProject = "spAddUserToProject";
        public static string spDeleteUserFromProject = "spDeleteUserFromProject";
        public static string spAddDepartment = "spAddDepartment";
        public static string spUpdateDepartment = "spUpdateDepartment";
        public static string spDeleteDepartment = "spDeleteDepartment";
        //public static string spAddSection = "spAddSection";
        public static string spAddDocumentCategory = "spAddDocumentCategory";
        public static string spUpdateDocumentCategory = "spUpdateDocumentCategory";
        public static string spDeleteDocumentCategory = "spDeleteDocumentCategory";
        public static string spGetDocumentApprovers = "spGetDocumentApprovers";
        public static string spGetUsers = "spGetUsers";
        public static string spAddUser = "spAddUser";
        public static string spDeleteUser = "spDeleteUser";
        public static string spUpdateUser = "spUpdateUser";
        public static string spGetAllSections = "spGetAllSections";
        public static string spAddSection = "spAddSection";
        public static string spUpdateSection = "spUpdateSection";
        public static string spDeleteSection = "spDeleteSection";
        public static string spAddProject = "spAddProject";
        public static string spUpdateProject = "spUpdateProject";
        public static string spUpdateMultipleApprovers = "spUpdateMultipleApprovers";
        public static string spDeleteDocument = "spDeleteDocument";
        public static string spGetAllExternalDocuments = "spGetAllExternalDocuments";
        public static string spGetExternalDocumentDetailsForID = "spGetExternalDocumentDetailsForID";
        public static string spInsertExternalDocument = "spInsertExternalDocument";
        public static string spUpdateExternalDocument = "spUpdateExternalDocument";
        public static string spDeleteExternalDocument = "spDeleteExternalDocument";
        public static string spDeleteTemplate = "spDeleteTemplate";
        public static string spUpdateTemplate = "spUpdateTemplate";

        //Wistron 
        public static string spGetActivePlants = "spGetActivePlants";
        public static string spGetDropDownsForNewUpload = "spGetDropDownsForNewUpload";
        public static string spGetClassificationForPlant = "spGetClassificationForPlant";
        public static string spGetActiveSmallCategories = "spGetActiveSmallCategories";
        public static string spGetModelPartsForSmallCat = "spGetModelPartsForSmallCat";
    }
}
