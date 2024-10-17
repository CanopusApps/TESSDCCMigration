using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DMS.Common;
using DMS.Common.Constants;
using DMS.Common.Models;
using DMS.DAL.Database.Component;
using DMS.Workflow.Business;
using DMS.Workflow.Models;

namespace DMS.BLL.Component
{
    public class QMSAdmin
    {
        QMSAdminDAL objAdmin = new QMSAdminDAL();
        DocumentOperations docOperObj = new DocumentOperations();
        public List<DocumentNumber> GetDocumentNumbers(string DepartmentCode, string SectionCode, string ProjectCode, string DocumentCategoryCode)
        {
            List<DocumentNumber> list = new List<DocumentNumber>();
            try
            {
                //DataTable dt = lstOp.GetListData(SharePointConstants.siteURL, listName, SharePointConstants.mstListViewFields, SharePointConstants.mstListCondition);
                DataTable dt = objAdmin.GetDocumentNumbers(DepartmentCode, SectionCode, ProjectCode, DocumentCategoryCode);
                //dt.DefaultView.Sort = "Title ASC";
                //dt = dt.DefaultView.ToTable();
                for (int z = 0; z < dt.Rows.Count; z++)
                {
                    DocumentNumber itm = new DocumentNumber();
                    itm.ID = new Guid(dt.Rows[z]["ID"].ToString());
                    //itm.DepartmentCode = dt.Rows[z]["DepartmentCode"].ToString();
                    //itm.DepartmentName = dt.Rows[z]["DepartmentName"].ToString();
                    //itm.SectionCode = dt.Rows[z]["SectionCode"].ToString();
                    //itm.SectionName = dt.Rows[z]["SectionName"].ToString();
                    //itm.ProjectCode = dt.Rows[z]["ProjectCode"].ToString();
                    //itm.ProjectName = dt.Rows[z]["ProjectName"].ToString();
                    //itm.DocumentCategoryCode = dt.Rows[z]["DocumentCategoryCode"].ToString();
                    //itm.DocumentCategoryName = dt.Rows[z]["DocumentCategoryName"].ToString();
                    itm.SerialNo = dt.Rows[z]["SerialNo"].ToString();
                    list.Add(itm);
                }
            }
            catch (Exception ex)
            {
                LoggerBlock.WriteTraceLog(ex);
            }
            return list;
        }

        public string AddDepartment(Department objDept)
        {
            string strReturn = string.Empty;
            try
            {
                DataTable dt = objAdmin.AddDepartment(objDept);
                if (dt.Rows.Count > 0)
                    strReturn = dt.Rows[0][0].ToString();
            }
            catch (Exception ex)
            {
                LoggerBlock.WriteTraceLog(ex);
                throw ex;
            }
            return strReturn;
        }
        public string UpdateDepartment(Department objDept)
        {
            string strReturn = string.Empty;
            try
            {
                DataTable dt = objAdmin.UpdateDepartment(objDept);
                if (dt.Rows.Count > 0)
                    strReturn = dt.Rows[0][0].ToString();
            }
            catch (Exception ex)
            {
                LoggerBlock.WriteTraceLog(ex);
                throw ex;
            }
            return strReturn;
        }
        public string DeleteDepartment(Department objDept)
        {
            string strReturn = string.Empty;
            try
            {
                DataTable dt = objAdmin.DeleteDepartment(objDept);
                if (dt.Rows.Count > 0)
                    strReturn = dt.Rows[0][0].ToString();
            }
            catch (Exception ex)
            {
                LoggerBlock.WriteTraceLog(ex);
                throw ex;
            }
            return strReturn;
        }
        public string AddDocumentCategory(Classification objDocCat)
        {
            string strReturn = string.Empty;
            try
            {
                DataTable dt = objAdmin.AddDocumentCategory(objDocCat);
                if (dt.Rows.Count > 0)
                    strReturn = dt.Rows[0][0].ToString();
            }
            catch (Exception ex)
            {
                LoggerBlock.WriteTraceLog(ex);
                throw ex;
            }
            return strReturn;
        }
        public string UpdateDocumentCategory(Classification entObject)
        {
            string strReturn = string.Empty;
            try
            {
                DataTable dt = objAdmin.UpdateDocumentCategory(entObject);
                if (dt.Rows.Count > 0)
                    strReturn = dt.Rows[0][0].ToString();
            }
            catch (Exception ex)
            {
                LoggerBlock.WriteTraceLog(ex);
                throw ex;
            }
            return strReturn;
        }
        public string DeleteDocumentCategory(Classification objDocCat)
        {
            string strReturn = string.Empty;
            try
            {
                DataTable dt = objAdmin.DeleteDocumentCategory(objDocCat);
                if (dt.Rows.Count > 0)
                    strReturn = dt.Rows[0][0].ToString();
            }
            catch (Exception ex)
            {
                LoggerBlock.WriteTraceLog(ex);
                throw ex;
            }
            return strReturn;
        }
        public List<Department> GetDepartments()
        {
            List<Department> list = new List<Department>();
            try
            {
                //DataTable dt = lstOp.GetListData(SharePointConstants.siteURL, listName, SharePointConstants.mstListViewFields, SharePointConstants.mstListCondition);
                DataTable dt = objAdmin.GetDepartments();
                //dt.DefaultView.Sort = "Title ASC";
                //dt = dt.DefaultView.ToTable();
                for (int z = 0; z < dt.Rows.Count; z++)
                {
                    Department itm = new Department();
                    itm.ID = new Guid(dt.Rows[z]["ID"].ToString());
                    itm.Code = dt.Rows[z]["Code"].ToString();
                    itm.Name = dt.Rows[z]["Title"].ToString();
                    if (Convert.ToBoolean(dt.Rows[z]["IsActive"].ToString()) == true)
                        itm.IsActive = true;
                    else
                        itm.IsActive = false;
                    list.Add(itm);
                }
            }
            catch (Exception ex)
            {
                LoggerBlock.WriteTraceLog(ex);
            }
            return list;
        }
        public string DeleteDocument(Guid UserID, Guid DocumentID)
        {
            try
            {
                string strReturn = string.Empty;
                DataSet ds = new DataSet();
                ds = objAdmin.DeleteDocument(UserID, DocumentID);
                if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0][0].ToString()))
                {
                    string json = ds.Tables[0].Rows[0][0].ToString();
                    List<DraftDocument> objDraftDoc = BindModels.ConvertJSON<DraftDocument>(json);
                    DocumentOperations docOper = new DocumentOperations();
                    string deletePath = CommonMethods.CombineUrl(QMSConstants.StoragePath, "DeleteFiles");
                    //docOper.BackUpFile(deletePath, QMSConstants.DraftFolder, objDraftDoc[0].EditableFilePath, objDraftDoc[0].EditableDocumentName, objDraftDoc[0].DraftVersion);
                    ////need to write logic to delete from backup folders.
                    //if (!string.IsNullOrEmpty(ds.Tables[1].Rows[0][0].ToString()))
                    //{
                    //    json = ds.Tables[1].Rows[0][0].ToString();
                    //    objDraftDoc = BindModels.ConvertJSON<DraftDocument>(json);
                    //    docOper.BackUpFile(deletePath, QMSConstants.ReadableFolder, objDraftDoc[0].ReadableFilePath, objDraftDoc[0].ReadableDocumentName, objDraftDoc[0].OriginalVersion);
                    //    docOper.BackUpFile(deletePath, QMSConstants.EditableFolder, objDraftDoc[0].EditableFilePath, objDraftDoc[0].EditableDocumentName, objDraftDoc[0].OriginalVersion);
                    //    //need to write logic to delete from backup folders.
                    //    strReturn = "Document deleted successfully";
                    //}
                    //else
                    //{
                    //    strReturn = "Document present in draft stage only and deleted successfully";
                    //}
                }
                else
                {
                    strReturn = "Document not found to delete";
                }
                return strReturn;
            }
            catch (Exception ex)
            {
                LoggerBlock.WriteTraceLog(ex);
                throw ex;
            }
        }
        public List<Sections> GetSections()
        {
            List<Sections> list = new List<Sections>();
            try
            {
                DataTable dt = objAdmin.GetSectionsForDept(Guid.Empty);
                if (dt != null)
                {
                    for (int z = 0; z < dt.Rows.Count; z++)
                    {
                        Sections itm = new Sections();
                        itm.ID = new Guid(dt.Rows[z]["ID"].ToString());
                        itm.Code = dt.Rows[z]["Code"].ToString();
                        itm.Title = dt.Rows[z]["Title"].ToString();
                        list.Add(itm);
                    }
                }
            }
            catch (Exception ex)
            {
                LoggerBlock.WriteTraceLog(ex);
            }
            return list;
        }
        public List<Sections> GetSectionsForDept(Guid deptID)
        {
            List<Sections> list = new List<Sections>();
            try
            {
                //string strCondition = @"<Where><And><Eq><FieldRef Name='Active' /><Value Type='Boolean'>1</Value></Eq><Eq><FieldRef Name='Department' LookupId='TRUE'/><Value Type='Lookup'>" + deptID + "</Value></Eq></And></Where>";
                //DataTable dt = lstOp.GetListData(SharePointConstants.siteURL, listName, SharePointConstants.mstListViewFields, strCondition);
                DataTable dt = objAdmin.GetSectionsForDept(deptID);
                if (dt != null)
                {
                    for (int z = 0; z < dt.Rows.Count; z++)
                    {
                        Sections itm = new Sections();
                        itm.ID = new Guid(dt.Rows[z]["ID"].ToString());
                        itm.Code = dt.Rows[z]["Code"].ToString();
                        itm.Title = dt.Rows[z]["Title"].ToString();
                        list.Add(itm);
                    }
                }
            }
            catch (Exception ex)
            {
                LoggerBlock.WriteTraceLog(ex);
            }
            return list;
        }
        public LoginUser GetUserDetails(string LoginId)
        {
            LoginUser objUser = new LoginUser();
            try
            {
                DataTable dt = objAdmin.GetUserDetails(LoginId);
                string json = dt.Rows[0][0].ToString();
                objUser = (LoginUser)CommonMethods.GetUserObject(json);

            }
            catch (Exception ex)
            {
                LoggerBlock.WriteTraceLog(ex);
            }
            return objUser;
        }

        public LoginUser GetUserDetails(Guid UploadedUserID)
        {
            LoginUser objUser = new LoginUser();
            try
            {
                objUser = objAdmin.GetUserDetails(UploadedUserID);
            }
            catch (Exception ex)
            {
                LoggerBlock.WriteTraceLog(ex);
            }
            return objUser;
        }
        public List<User> GetProjectUsers(Guid ProjectTypeID, Guid ProjectID)
        {
            List<User> objUsers = null;
            try
            {
                objUsers = objAdmin.GetProjectUsers(ProjectTypeID, ProjectID);
            }
            catch (Exception ex)
            {
                LoggerBlock.WriteTraceLog(ex);
            }
            return objUsers;
        }
        public string AddUserToProject(Guid ProjectTypeID, Guid ProjectID, string UserName, string AdminIDs)
        {
            string strReturn = string.Empty;
            strReturn = objAdmin.AddUserToProject(ProjectTypeID, ProjectID, UserName, AdminIDs);
            return strReturn;
        }
        public string DeleteUserFromProject(Guid ProjectTypeID, Guid ProjectID, Guid UserID)
        {
            return objAdmin.DeleteUserFromProject(ProjectTypeID, ProjectID, UserID);
        }
        public List<User> SearchProjectUsers(Guid ProjectTypeID, Guid ProjectID, string UserName, bool IsInclude)
        {
            List<User> objUsers = null;
            objUsers = objAdmin.SearchProjectUsers(ProjectTypeID, ProjectID, UserName, IsInclude);
            return objUsers;
        }
        public List<User> SearchUser(string UserName)
        {
            List<User> objUsers = null;
            objUsers = objAdmin.SearchUser(UserName);
            return objUsers;
        }
        public List<ProjectType> GetProjectTypes()
        {
            List<ProjectType> list = new List<ProjectType>();
            try
            {
                DataTable dt = objAdmin.GetProjectTypes();
                list = BindModels.ConvertDataTable<ProjectType>(dt);
            }
            catch (Exception ex)
            {
                LoggerBlock.WriteTraceLog(ex);
            }
            return list;
        }
        public List<Project> GetProjects()
        {
            List<Project> list = new List<Project>();
            try
            {
                DataTable dt = objAdmin.GetProjects();
                list = BindModels.ConvertDataTable<Project>(dt);
            }
            catch (Exception ex)
            {
                LoggerBlock.WriteTraceLog(ex);
            }
            return list;
        }

        public List<TemplateDocument> GetDocumentTemplates()
        {
            List<TemplateDocument> list = new List<TemplateDocument>();
            try
            {
                DataTable dt = objAdmin.GetTemplateDocuments();
                //list = BindModels.ConvertDataTable<TemplateDocument>(dt);

                dt.DefaultView.Sort = "Name ASC";
                dt = dt.DefaultView.ToTable();

                for (int z = 0; z < dt.Rows.Count; z++)
                {
                    TemplateDocument itm = new TemplateDocument();
                    itm.ID = new Guid(dt.Rows[z]["ID"].ToString());
                    itm.Code = dt.Rows[z]["Code"].ToString();
                    itm.Name = dt.Rows[z]["Name"].ToString();
                    itm.FileName = dt.Rows[z]["FileName"].ToString();
                    itm.FilePath = dt.Rows[z]["FilePath"].ToString();
                    itm.Level = dt.Rows[z]["Level"].ToString();
                    list.Add(itm);
                }
            }
            catch (Exception ex)
            {
                LoggerBlock.WriteTraceLog(ex);
            }
            return list;
        }
        public List<Classification> GetDocumentCategories()
        {
            List<Classification> list = new List<Classification>();
            try
            {
                //ListOperations lstOp = new ListOperations();
                //DataTable dt = lstOp.GetListData(SharePointConstants.siteURL, SharePointConstants.categoryListName, SharePointConstants.mstListViewFields, SharePointConstants.mstListCondition);
                DataTable dt = objAdmin.GetDocumentCategories();
                //list = BindModels.ConvertDataTable<DocumentCategory>(dt);
                dt.DefaultView.Sort = "Title ASC";
                dt = dt.DefaultView.ToTable();

                for (int z = 0; z < dt.Rows.Count; z++)
                {
                    Classification itm = new Classification();
                    itm.ID = new Guid(dt.Rows[z]["ID"].ToString());
                    itm.Code = dt.Rows[z]["Code"].ToString();
                    itm.Name = dt.Rows[z]["Title"].ToString();
                    itm.Level = dt.Rows[z]["DocumentLevel"].ToString();
                    itm.FolderName = dt.Rows[z]["FolderName"].ToString();
                    if (dt.Rows[z]["flgActive"].ToString().ToLower() == "true")
                        itm.IsActive = true;
                    else
                        itm.IsActive = false;
                    list.Add(itm);
                }
            }
            catch (Exception ex)
            {
                LoggerBlock.WriteTraceLog(ex);
            }
            return list;
        }

        public List<ExternalDocument> GetAllExternalDocuments()
        {
            List<ExternalDocument> list = new List<ExternalDocument>();
            try
            {
                DataTable dt = objAdmin.GetAllExternalDocuments();
                dt.DefaultView.Sort = "Title ASC";
                dt = dt.DefaultView.ToTable();

                for (int z = 0; z < dt.Rows.Count; z++)
                {
                    ExternalDocument itm = new ExternalDocument();
                    itm.ID = new Guid(dt.Rows[z]["ID"].ToString());
                    itm.Title = dt.Rows[z]["Title"].ToString();
                    itm.DocumentNo = dt.Rows[z]["DocumentNo"].ToString();
                    if (!string.IsNullOrEmpty(dt.Rows[z]["Version"].ToString()))
                        itm.Version = Convert.ToInt32(dt.Rows[z]["Version"].ToString());
                    if (!string.IsNullOrEmpty(dt.Rows[z]["VersionDate"].ToString()))
                        itm.VersionDate = DateTime.Parse(dt.Rows[z]["VersionDate"].ToString());
                    itm.Organization = dt.Rows[z]["Organization"].ToString();
                    if (!string.IsNullOrEmpty(dt.Rows[z]["ResponsibleUserID"].ToString()))
                        itm.ResponsibleUserID = new Guid(dt.Rows[z]["ResponsibleUserID"].ToString());
                    itm.Department = dt.Rows[z]["Department"].ToString();
                    itm.FileName = dt.Rows[z]["FileName"].ToString();
                    itm.FileURL = dt.Rows[z]["FileURL"].ToString();
                    if (dt.Rows[z]["txtDisplayName"] != null)
                        itm.ResponsibleUser = dt.Rows[z]["txtDisplayName"].ToString();
                    if (dt.Rows[z]["flgActive"].ToString().ToLower() == "true")
                        itm.Active = true;
                    else
                        itm.Active = false;
                    list.Add(itm);
                }
            }
            catch (Exception ex)
            {
                LoggerBlock.WriteTraceLog(ex);
            }
            return list;
        }

        public string AddExternalDocument(ExternalDocument obj, byte[] byteArray, bool docUploaded)
        {
            string strReturn = string.Empty;
            try
            {
                //if (docUploaded)
                //    docOperObj.UploadDocument(QMSConstants.StoragePath,QMSConstants.ExtDocumentFolder, "", obj.FileName, 1, byteArray);
                DataTable dt = objAdmin.AddExternalDocument(obj);
            }
            catch (Exception ex)
            {
                LoggerBlock.WriteTraceLog(ex);
                throw ex;
            }
            return strReturn;
        }
        public string UpdateExternalDocument(ExternalDocument obj, byte[] byteArray, bool docUploaded)
        {
            string strReturn = string.Empty;
            try
            {
                //if (docUploaded)
                //    docOperObj.UploadDocument(QMSConstants.StoragePath, QMSConstants.ExtDocumentFolder, "", obj.FileName, 1, byteArray);
                DataTable dt = objAdmin.UpdateExternalDocument(obj);
            }
            catch (Exception ex)
            {
                LoggerBlock.WriteTraceLog(ex);
                throw ex;
            }
            return strReturn;
        }

        public string DeleteExternalDocument(Guid id)
        {
            string strReturn = string.Empty;
            try
            {
                DataTable dt = objAdmin.DeleteExternalDocument(id);
                if (dt.Rows.Count > 0)
                    strReturn = dt.Rows[0][0].ToString();
            }
            catch (Exception ex)
            {
                LoggerBlock.WriteTraceLog(ex);
                throw ex;
            }
            return strReturn;
        }

        public string DeleteTemplate(Guid id)
        {
            string strReturn = string.Empty;
            try
            {
                DataTable dt = objAdmin.DeleteTemplate(id);
                if (dt.Rows.Count > 0)
                    strReturn = dt.Rows[0][0].ToString();
            }
            catch (Exception ex)
            {
                LoggerBlock.WriteTraceLog(ex);
                throw ex;
            }
            return strReturn;
        }

        public string UpdateTemplate(TemplateDocument obj)
        {
            string strReturn = string.Empty;
            try
            {
                DataTable dt = objAdmin.UpdateTemplate(obj.ID, obj.Name, obj.FileName, obj.FilePath, obj.Level, obj.ModifiedBy);
                if (dt.Rows.Count > 0)
                    strReturn = dt.Rows[0][0].ToString();
            }
            catch (Exception ex)
            {
                LoggerBlock.WriteTraceLog(ex);
                throw ex;
            }
            return strReturn;
        }

        public ExternalDocument GetExternalDocumentForID(Guid id)
        {
            ExternalDocument itm = new ExternalDocument();
            try
            {
                DataTable dt = objAdmin.GetExternalDocumentForID(id);
                for (int z = 0; z < dt.Rows.Count; z++)
                {
                    itm.ID = new Guid(dt.Rows[z]["ID"].ToString());
                    itm.Title = dt.Rows[z]["Title"].ToString();
                    itm.DocumentNo = dt.Rows[z]["DocumentNo"].ToString();
                    if (!string.IsNullOrEmpty(dt.Rows[z]["Version"].ToString()))
                        itm.Version = Convert.ToInt32(dt.Rows[z]["Version"].ToString());
                    if (!string.IsNullOrEmpty(dt.Rows[z]["VersionDate"].ToString()))
                        itm.VersionDate = DateTime.Parse(dt.Rows[z]["VersionDate"].ToString());
                    itm.Organization = dt.Rows[z]["Organization"].ToString();
                    if (!string.IsNullOrEmpty(dt.Rows[z]["ResponsibleUserID"].ToString()))
                        itm.ResponsibleUserID = new Guid(dt.Rows[z]["ResponsibleUserID"].ToString());
                    itm.Department = dt.Rows[z]["Department"].ToString();
                    itm.FileName = dt.Rows[z]["FileName"].ToString();
                    itm.FileURL = dt.Rows[z]["FileURL"].ToString();
                    if (dt.Rows[z]["txtDisplayName"] != null)
                        itm.ResponsibleUser = dt.Rows[z]["txtDisplayName"].ToString();
                    if (dt.Rows[z]["flgActive"].ToString().ToLower() == "true")
                        itm.Active = true;
                    else
                        itm.Active = false;

                }
            }
            catch (Exception ex)
            {
                LoggerBlock.WriteTraceLog(ex);
            }
            return itm;
        }

        public List<ProjectType> GetProjectTypesbyRole(string Page, string role, List<Project> allProjects)
        {
            List<ProjectType> projectTypes = new List<ProjectType>();
            try
            {
                projectTypes = allProjects.Where(d => d.IsAdmin == true).GroupBy(d => d.ProjectTypeID).Select(m => new ProjectType
                {
                    ID = m.First().ProjectTypeID,
                    Code = m.First().ProjectTypeCode,
                    Title = m.First().ProjectTypeName,
                    WorkflowID = m.First().WorkflowID

                }).Distinct().ToList();
            }
            catch (Exception ex)
            {
                LoggerBlock.WriteTraceLog(ex);
            }
            return projectTypes;
        }

        public List<Project> GetProjectsbyRole(string Page, string role, List<Project> allProjects)
        {
            List<Project> projects = new List<Project>();
            try
            {
                if (Page == "ProjectUsers")
                {
                    projects = allProjects.Where(d => d.ProjectTypeCode == "NPI" && d.IsAdmin == true).ToList();
                }
                else if (Page == "ApprovalMatrix" || Page == "PendingDocuments")
                {
                    if (role.Contains("QADM") || role.Contains("ADMIN"))
                    {
                        projects = allProjects;
                    }
                    else
                    {
                        projects = allProjects.Where(d => d.IsAdmin == true).ToList();
                    }
                }
                else
                {
                    projects = allProjects;
                }
            }
            catch (Exception ex)
            {
                LoggerBlock.WriteTraceLog(ex);
            }
            return projects;
        }
        public List<Project> GetProjectsbyType(List<Project> allProjects, Guid ProjectTypeID, bool isAdmin)
        {
            List<Project> projects = new List<Project>();
            try
            {
                if (isAdmin)
                    projects = allProjects.Where(d => d.ProjectTypeID == ProjectTypeID && d.IsAdmin == isAdmin).ToList();
                else
                    projects = allProjects.Where(d => d.ProjectTypeID == ProjectTypeID).ToList();
            }
            catch (Exception ex)
            {
                LoggerBlock.WriteTraceLog(ex);
            }
            return projects;
        }

        public List<ApprovalMatrix> GetApprovalMatrix(Guid ProjectTypeID, Guid ProjectID, Guid StageID, string DocumentLevel, Guid DepartmentID, Guid SectionID)
        {
            List<ApprovalMatrix> list = new List<ApprovalMatrix>();
            try
            {
                //ListOperations lstOp = new ListOperations();
                //DataTable dt = lstOp.GetListData(SharePointConstants.siteURL, SharePointConstants.categoryListName, SharePointConstants.mstListViewFields, SharePointConstants.mstListCondition);
                WFAdminBLL wfAction = new WFAdminBLL();
                DataTable dt = wfAction.GetWFApprovalMatrix(ProjectTypeID, ProjectID, StageID, DocumentLevel, DepartmentID, SectionID);
                //list = BindModels.ConvertDataTable<ApprovalMatrix>(dt);

                //dt.DefaultView.Sort = "Title ASC";
                //dt = dt.DefaultView.ToTable();

                for (int z = 0; z < dt.Rows.Count; z++)
                {
                    ApprovalMatrix itm = new ApprovalMatrix();
                    itm.ID = new Guid(dt.Rows[z]["ID"].ToString());
                    if (dt.Rows[z]["ProjectID"].ToString() != "") //00000000-0000-0000-0000-00000000000
                        itm.ProjectID = new Guid(dt.Rows[z]["ProjectID"].ToString());
                    itm.ProjectName = dt.Rows[z]["ProjectName"].ToString();
                    if (dt.Rows[z]["StageID"].ToString() != "")
                    {
                        itm.StageID = new Guid(dt.Rows[z]["StageID"].ToString());
                        itm.StageName = dt.Rows[z]["StageName"].ToString();
                    }
                    if (dt.Rows[z]["DocumentLevel"].ToString() != "")
                        itm.DocumentLevel = dt.Rows[z]["DocumentLevel"].ToString();
                    if (dt.Rows[z]["DepartmentID"].ToString() != "")
                    {
                        itm.DepartmentID = new Guid(dt.Rows[z]["DepartmentID"].ToString());
                        itm.DepartmentName = dt.Rows[z]["DepartmentName"].ToString();
                    }
                    if (dt.Rows[z]["SectionID"].ToString() != "")
                    {
                        itm.SectionID = new Guid(dt.Rows[z]["SectionID"].ToString());
                        itm.SectionName = dt.Rows[z]["SectionName"].ToString();
                    }
                    itm.ApprovalUserIDs = dt.Rows[z]["ApprovalUserIDs"].ToString();
                    itm.ApprovalUsers = dt.Rows[z]["ApprovalUsers"].ToString();
                    list.Add(itm);
                }
            }
            catch (Exception ex)
            {
                LoggerBlock.WriteTraceLog(ex);
            }
            return list;
        }

        public string CopyApprovalMatrix(Guid sProjectID, Guid dProjectID, int syncType, Guid createdBy)
        {
            string result = "";
            try
            {
                WFAdminBLL wfAction = new WFAdminBLL();
                result = wfAction.CopyWFApprovalMatrix(sProjectID, dProjectID, syncType, createdBy);

            }
            catch (Exception ex)
            {
                LoggerBlock.WriteTraceLog(ex);
            }
            return result;
        }

        public List<User> GetUsers()
        {
            List<User> objUsers = null;
            try
            {
                objUsers = objAdmin.GetUsers();
            }
            catch (Exception ex)
            {
                LoggerBlock.WriteTraceLog(ex);
            }
            return objUsers;
        }

        public List<User> GetUserData(Guid UserID)
        {
            List<User> objUsers = null;
            try
            {
                objUsers = objAdmin.GetUserData(UserID);
            }
            catch (Exception ex)
            {
                LoggerBlock.WriteTraceLog(ex);
            }
            return objUsers;
        }
        public string AddUser(string LoginID, string DisplayName, string Email, bool IsQMSAdmin, Guid CreatedID)
        {
            string strReturn = string.Empty;
            strReturn = objAdmin.AddUser(LoginID, DisplayName, Email, IsQMSAdmin, CreatedID);
            return strReturn;
        }

        public string UpdateUser(Guid ID, string LoginID, string DisplayName, string Email, bool IsQMSAdmin, bool IsActive, Guid CreatedID)
        {
            string strReturn = string.Empty;
            strReturn = objAdmin.UpdateUser(ID, LoginID, DisplayName, Email, IsQMSAdmin, IsActive, CreatedID);
            return strReturn;
        }
        public string DeleteUser(Guid UserID)
        {
            return objAdmin.DeleteUser(UserID);
        }


        public List<Sections> GetAllSections()
        {
            List<Sections> list = new List<Sections>();
            try
            {
                DataTable dt = objAdmin.GetAllSections();
                if (dt != null)
                {
                    for (int z = 0; z < dt.Rows.Count; z++)
                    {
                        Sections itm = new Sections();
                        itm.ID = new Guid(dt.Rows[z]["ID"].ToString());
                        itm.Code = dt.Rows[z]["Code"].ToString();
                        itm.Title = dt.Rows[z]["Title"].ToString();
                        itm.DepartmentID = new Guid(dt.Rows[z]["DepartmentID"].ToString());
                        itm.DepartmentName = dt.Rows[z]["DepartmentName"].ToString();
                        itm.Active = Convert.ToBoolean(dt.Rows[z]["Active"].ToString());
                        list.Add(itm);
                    }
                }
            }
            catch (Exception ex)
            {
                LoggerBlock.WriteTraceLog(ex);
            }
            return list;
        }

        public string AddSection(Sections entObject)
        {
            string strReturn = string.Empty;
            try
            {
                DataTable dt = objAdmin.AddSection(entObject);
                if (dt.Rows.Count > 0)
                    strReturn = dt.Rows[0][0].ToString();
            }
            catch (Exception ex)
            {
                LoggerBlock.WriteTraceLog(ex);
                throw ex;
            }
            return strReturn;
        }
        public string UpdateSection(Sections entObject)
        {
            string strReturn = string.Empty;
            try
            {
                DataTable dt = objAdmin.UpdateSection(entObject);
                if (dt.Rows.Count > 0)
                    strReturn = dt.Rows[0][0].ToString();
            }
            catch (Exception ex)
            {
                LoggerBlock.WriteTraceLog(ex);
                throw ex;
            }
            return strReturn;
        }
        public string DeleteSection(Sections entObject)
        {
            string strReturn = string.Empty;
            try
            {
                DataTable dt = objAdmin.DeleteSection(entObject);
                if (dt.Rows.Count > 0)
                    strReturn = dt.Rows[0][0].ToString();
            }
            catch (Exception ex)
            {
                LoggerBlock.WriteTraceLog(ex);
                throw ex;
            }
            return strReturn;
        }

        public string AddProject(Project entObject)
        {
            string strReturn = string.Empty;
            try
            {
                DataTable dt = objAdmin.AddProject(entObject);
                if (dt.Rows.Count > 0)
                    strReturn = dt.Rows[0][0].ToString();
            }
            catch (Exception ex)
            {
                LoggerBlock.WriteTraceLog(ex);
                throw ex;
            }
            return strReturn;
        }
        public string UpdateProject(Project entObject)
        {
            string strReturn = string.Empty;
            try
            {
                DataTable dt = objAdmin.UpdateProject(entObject);
                if (dt.Rows.Count > 0)
                    strReturn = dt.Rows[0][0].ToString();
            }
            catch (Exception ex)
            {
                LoggerBlock.WriteTraceLog(ex);
                throw ex;
            }
            return strReturn;
        }
        public List<Location> GetActiveLocations()
        {
            List<Location> list = new List<Location>();
            try
            {
                DataTable dt = objAdmin.GetActiveLocations();
                for (int z = 0; z < dt.Rows.Count; z++)
                {
                    Location itm = new Location();
                    itm.ID = new Guid(dt.Rows[z]["ID"].ToString());
                    itm.Code = dt.Rows[z]["Code"].ToString();
                    itm.Title = dt.Rows[z]["Name"].ToString();
                    if (Convert.ToBoolean(dt.Rows[z]["IsActive"].ToString()) == true)
                        itm.Active = true;
                    else
                        itm.Active = false;
                    list.Add(itm);
                }
            }
            catch (Exception ex)
            {
                LoggerBlock.WriteTraceLog(ex);
            }
            return list;
        }


    }
}
