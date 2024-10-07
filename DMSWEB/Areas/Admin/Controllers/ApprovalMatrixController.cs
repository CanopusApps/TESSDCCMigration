using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DMS.BLL.Component;
using DMS.Common;
using DMS.Common.Constants;
using DMS.Common.Models;
using DMS.Workflow.Business;
using DMS.Workflow.Models;
using DMSWEB.Controllers;

namespace DMSWEB.Areas.Admin.Controllers
{

    public class ApprovalMatrixController : Controller
    {
        // GET: ApprovalMatrix
        [CustomAuthorize(Roles = "USER,QADM,QPADM")]
        public ActionResult Index()
        {
            string strRoles = System.Web.HttpContext.Current.Session[QMSConstants.LoggedInUserRoles].ToString();
            if ((!strRoles.Contains("QADM")) && (!strRoles.Contains("QPADM")))
                ViewBag.ShowButtons = false;
            else ViewBag.ShowButtons = true;
            ViewBag.Data = null;
            return View();
        }
        [CustomAuthorize(Roles = "QADM,QPADM")]
        public ActionResult ReplaceUser()
        {
            return View();
        }

        [CustomAuthorize(Roles = "QADM,QPADM")]
        public ActionResult Copy()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GetDropDownValues(string isReadOnly)
        {
            try
            {
                QMSAdmin objAdm = new QMSAdmin();
                List<ProjectType> list = null;
                if (isReadOnly == "yes")
                {
                    list = objAdm.GetProjectTypes();
                }
                else
                {
                    list = objAdm.GetProjectTypesbyRole("ApprovalMatrix", System.Web.HttpContext.Current.Session[QMSConstants.LoggedInUserRoles].ToString(),
                      (List<Project>)System.Web.HttpContext.Current.Session[QMSConstants.LoggedInUserProjects]);
                }


                List<Project> list2 = objAdm.GetProjectsbyRole("ApprovalMatrix", System.Web.HttpContext.Current.Session[QMSConstants.LoggedInUserRoles].ToString(),
                       (List<Project>)System.Web.HttpContext.Current.Session[QMSConstants.LoggedInUserProjects]); //objAdm.GetNPIProjects();
                
                List<Department> list3 = objAdm.GetDepartments();
                return Json(new { success = true, message1 = list, message2 = list2, message3 = list3 }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                LoggerBlock.WriteTraceLog(ex);
                return Json(new { success = true, message = "" }, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult GetProjects(string projectTypeID)
        {
            try
            {
                QMSAdmin objAdm = new QMSAdmin();
                List<Project> list = objAdm.GetProjectsbyType((List<Project>)System.Web.HttpContext.Current.Session[QMSConstants.LoggedInUserProjects],new Guid(projectTypeID),true);
                return Json(new { success = true, message = list }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                LoggerBlock.WriteTraceLog(ex);
                return Json(new { success = true, message = "" }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult GetProjectsForCopy()
        {
            try
            {
                QMSAdmin objAdm = new QMSAdmin();
                List<Project> list = objAdm.GetProjectsbyRole("ApprovalMatrix", System.Web.HttpContext.Current.Session[QMSConstants.LoggedInUserRoles].ToString(),
                       (List<Project>)System.Web.HttpContext.Current.Session[QMSConstants.LoggedInUserProjects]); 
                return Json(new { success = true, message1 = list, message2 = list }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                LoggerBlock.WriteTraceLog(ex);
                return Json(new { success = true, message = "" }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult CopyApprovalMatrix(string ProjectID1, string ProjectID2)
        {
            try
            {
                QMSAdmin objAdm = new QMSAdmin();
                string message = objAdm.CopyApprovalMatrix(new Guid(ProjectID1), new Guid(ProjectID2), 1, 
                    new Guid(System.Web.HttpContext.Current.Session[QMSConstants.LoggedInUserID].ToString()));

                return Json(new { success = true, message = message }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                LoggerBlock.WriteTraceLog(ex);
                return Json(new { success = true, message = "error" }, JsonRequestBehavior.AllowGet);
            }
        }


        [HttpPost]
        public ActionResult GetWorkflowStage(string wfID)
        {
            try
            {
                WorkflowActions objWFAction = new WorkflowActions();
                List<WFStage> list1 = objWFAction.GetWFStages(new Guid(wfID));
                return Json(new { success = true, message1 = list1 }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                LoggerBlock.WriteTraceLog(ex);
                return Json(new { success = true, message = "" }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult GetProjectsandStages(string projTypeID, string wfID, string isReadOnly)
        {
            try
            {
                QMSAdmin objAdm = new QMSAdmin();
                //List<Project> list2 = objAdm.GetProjectsbyType((List<Project>)System.Web.HttpContext.Current.Session[QMSConstants.LoggedInUserProjects], new Guid(projTypeID), true);

                List<Project> projects = null;
                if(isReadOnly == "yes")
                {
                    List<Project> list2 = objAdm.GetProjects();
                    projects = list2.Where(d => d.ProjectTypeID == new Guid(projTypeID)).ToList();
                }
                else
                {
                    projects = objAdm.GetProjectsbyType((List<Project>)System.Web.HttpContext.Current.Session[QMSConstants.LoggedInUserProjects], new Guid(projTypeID), true);
                }
                WorkflowActions objWFAction = new WorkflowActions();
                List<WFStage> list1 = objWFAction.GetWFStages(new Guid(wfID));
                return Json(new { success = true, message1 = list1, message2 = projects }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                LoggerBlock.WriteTraceLog(ex);
                return Json(new { success = true, message = "" }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public JsonResult SearchProjectUsers(string ProjectTypeID, string ProjectID, string UserName)
        {
            try
            {
                QMSAdmin objAdm = new QMSAdmin();
                List<User> listUsers = objAdm.SearchProjectUsers(new Guid(ProjectTypeID), new Guid(ProjectID), UserName, true);
                return Json(new { success = true, message = listUsers }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                LoggerBlock.WriteTraceLog(ex);
                return Json(new { success = true, message = "" }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult GetApprovalMatrixData(string ProjectTypeID, string ProjectID, string StageID, string DocumentLevel, string DepartmentID, string SectionID)
        {
            try
            {
                QMSAdmin objAdm = new QMSAdmin();
                List<ApprovalMatrix> list = objAdm.GetApprovalMatrix(new Guid(ProjectTypeID), new Guid(ProjectID), new Guid(StageID), DocumentLevel, new Guid(DepartmentID), new Guid(SectionID));
                return Json(new { success = true, message = list }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                LoggerBlock.WriteTraceLog(ex);
                return Json(new { success = true, message = "" }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult InsertRecord(List<string> arr)
        {
            string result = "";
            try
            {
                if (arr[0].ToString() == "")
                    result = InsertEntity(arr);
                else
                    result = UpdateEntity(arr);

                return Json(new { success = true, message = result }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                LoggerBlock.WriteTraceLog(ex);
                result = "-1";
            }

            return Json(new { success = true, message = result }, JsonRequestBehavior.AllowGet);
        }

        private string InsertEntity(List<string> arr)
        {
            string strReturn = string.Empty;
            try
            {
                WFAdminBLL objBLL = new WFAdminBLL();
                ApprovalMatrix appMtrix = new ApprovalMatrix();
                appMtrix.ProjectTypeID = new Guid(arr[1].ToString());
                if (arr[2].ToString() != "")
                    appMtrix.ProjectID = new Guid(arr[2].ToString());
                if (arr[3].ToString() != "")
                    appMtrix.StageID = new Guid(arr[3].ToString());
                appMtrix.DocumentLevel = arr[4].ToString();
                if (arr[5].ToString() != "")
                    appMtrix.DepartmentID = new Guid(arr[5].ToString());
                if (arr[6].ToString() != "")
                    appMtrix.SectionID = new Guid(arr[6].ToString());
                appMtrix.ApprovalUserIDs = arr[7].ToString().Trim(',');
                appMtrix.CreatedID = new Guid(System.Web.HttpContext.Current.Session[QMSConstants.LoggedInUserID].ToString());
                strReturn = objBLL.InsertWFApprovalMatrix(appMtrix);
            }
            catch (Exception ex)
            {
                LoggerBlock.WriteTraceLog(ex);
                strReturn = "Error while saving approvers in approval matrix";
            }
            finally
            {

            }
            return strReturn;
        }

        private string UpdateEntity(List<string> arr)
        {
            try
            {

            }
            catch
            {
                throw;
            }
            return arr[0].ToString();
        }

        [HttpPost]
        public ActionResult GetApprovalMatrixForUser(string UserID, string projectTypeID, string projectID)
        {
            try
            {
                WFAdminBLL objWFAdm = new WFAdminBLL();
                //List<ApprovalMatrix> list = BindModels.ConvertDataTable<ApprovalMatrix>(objWFAdm.GetApprovalMatrixForUser(new Guid(UserID)));
                List<ApprovalMatrix> list = objWFAdm.GetApprovalMatrixForUser(new Guid(UserID), new Guid(projectTypeID), new Guid(projectID));
                return Json(new { success = true, message = list }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                LoggerBlock.WriteTraceLog(ex);
                return Json(new { success = true, message = "" }, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpPost]
        public ActionResult GetUserApprovalItemsForReplace(string strCondition, string UserID)
        {
            try
            {
                WFAdminBLL objWFAdm = new WFAdminBLL();
                //List<ApprovalMatrix> list = BindModels.ConvertDataTable<ApprovalMatrix>(objWFAdm.GetApprovalMatrixForUser(new Guid(UserID)));
                DataTable results = objWFAdm.GetUserApprovalItemsForReplace(strCondition, new Guid(UserID));
                List<DraftDocument> objDocuments = BindModels.ConvertDataTable<DraftDocument>(results);
                return Json(new { success = true, message = objDocuments }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                LoggerBlock.WriteTraceLog(ex);
                return Json(new { success = true, message = "" }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult UpdateUserApprovalItemsForReplace(string strCondition, string CurrentUserID, string NewUserID)
        {
            try
            {
                WFAdminBLL objWFAdm = new WFAdminBLL();
                //List<ApprovalMatrix> list = BindModels.ConvertDataTable<ApprovalMatrix>(objWFAdm.GetApprovalMatrixForUser(new Guid(UserID)));
                string message = objWFAdm.UpdateUserApprovalItemsForReplace(strCondition, new Guid(CurrentUserID), new Guid(NewUserID));
                return Json(new { success = true, message = message }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                LoggerBlock.WriteTraceLog(ex);
                return Json(new { success = true, message = "" }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult DeleteWFApprovalMatrix(string ID)
        {
            string result = "";
            try
            {
                WFAdminBLL objWFAdm = new WFAdminBLL();
                string strMessage = objWFAdm.DeleteWFApprovalMatrix(new Guid(ID));

                return Json(new { success = true, message = strMessage }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                LoggerBlock.WriteTraceLog(ex);
                result = "-1";
            }

            return Json(new { success = true, message = result }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult DownloadWFApprovalMatrix(string projectID, string tableName)
        {
            try
            {
                WFAdminBLL objWFAdm = new WFAdminBLL();
                byte[] fileContent = objWFAdm.DownloadWFApprovalMatrix(new Guid(projectID), tableName);
                string base64 = Convert.ToBase64String(fileContent, 0, fileContent.Length);
                return Content(base64);
            }
            catch (Exception ex)
            {
                LoggerBlock.WriteTraceLog(ex);

                return Json(new { success = true, message = "failed" }, JsonRequestBehavior.AllowGet);
            }

        }
    }
}