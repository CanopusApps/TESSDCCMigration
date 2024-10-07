using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DMS.BLL.Component;
using System.Configuration;
using Newtonsoft.Json;
using DMS.Common.Models;
using DMS.Common.Constants;
using System.IO;
using DMS.Common.Model;
using DMS.Common;
using System.Text;
using System.Net.Mail;
using System.Security.Cryptography;

namespace DMSWEB.Controllers
{
    public class DocumentInitiateController : Controller
    {
        // GET: DocumentInitiate
        public static Guid CurrentStageID = new Guid("f5d83a73-c4a3-48aa-b3d7-568301eea27b");

        [CustomAuthorize(Roles = "USER")]
        public ActionResult Index()
        {
            ViewBag.FileTypes = ConfigurationManager.AppSettings["FileTypes"].ToString();
            //ViewBag.FormsFileTypes = ConfigurationManager.AppSettings["FormsFileTypes"].ToString();
            //ViewBag.ReadableFileTypes = ConfigurationManager.AppSettings["ReadableFileTypes"].ToString();
            ViewBag.AllowedFileSize = ConfigurationManager.AppSettings["AllowedFileSize"].ToString();
            ViewBag.ApplicantID = System.Web.HttpContext.Current.Session[QMSConstants.LoggedInUserID];
            ViewBag.ApplicantName = System.Web.HttpContext.Current.Session[QMSConstants.LoggedInUserDisplayName];
            ViewBag.LoggedInUserDeptShortName = System.Web.HttpContext.Current.Session[QMSConstants.LoggedInUserDeptShortName];
            ViewBag.ApplicantDeptName = System.Web.HttpContext.Current.Session[QMSConstants.LoggedInUserDeptName];
            return View();
        }

        [HttpPost]
        public ActionResult GetDropdownsForNewUpload()
        {
            try
            {
                NewDocumentUploadBLL objBLL = new NewDocumentUploadBLL();                
                object[] listData = objBLL.GetDropdownsForNewUpload();
                var list1 = listData[0];
                var list2 = listData[1];
                var list3 = listData[2];
                var list4 = listData[3];
                var list5 = listData[4];
                return Json(new { success = true, message1 = list1, message2 = list2, message3 = list3, message4 = list4, message5 = list5 }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                LoggerBlock.WriteTraceLog(ex);
                return Json(new { success = false, message = "error" }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult GetDropDownBoxes()
        {
            try
            {
                QMSAdmin objAdm = new QMSAdmin();
                NewDocumentUploadBLL objBLL = new NewDocumentUploadBLL();
                List<Plant> list1 = objBLL.GetActivePlants();
                List<Classification> list2 = objAdm.GetDocumentCategories();

                object[] listData = objBLL.GetDropdownsForNewUpload();

                var list3 = objAdm.GetProjectsbyRole("DocumentInitiate", System.Web.HttpContext.Current.Session[QMSConstants.LoggedInUserRoles].ToString(),
                       (List<Project>)System.Web.HttpContext.Current.Session[QMSConstants.LoggedInUserProjects]);

                return Json(new { success = true, message1 = list1, message2 = list2, message3 = list3 }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                LoggerBlock.WriteTraceLog(ex);
                return Json(new { success = false, message = "error" }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult GetClassificationForPlant(string parentID)
        {
            try
            {
                NewDocumentUploadBLL objBLL = new NewDocumentUploadBLL();
                List<Classification> list1 = objBLL.GetClassificationForPlant(new Guid(parentID));
                return Json(new { success = true, message1 = list1 }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                LoggerBlock.WriteTraceLog(ex);
                return Json(new { success = false, message = "error" }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult GetActiveSmallCategories(string parentID)
        {
            try
            {
                NewDocumentUploadBLL objBLL = new NewDocumentUploadBLL();
                List<SmallCategory> list1 = objBLL.GetActiveSmallCategories(new Guid(parentID));
                return Json(new { success = true, message1 = list1 }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                LoggerBlock.WriteTraceLog(ex);
                return Json(new { success = false, message = "error" }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult GetModelPartsForSmallCat(string parentID)
        {
            try
            {
                NewDocumentUploadBLL objBLL = new NewDocumentUploadBLL();
                object[] listData = objBLL.GetModelPartsForSmallCat(new Guid(parentID));
                var list1 = listData[0];
                var list2 = listData[1];
                return Json(new { success = true, message1 = list1, message2 = list2 }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                LoggerBlock.WriteTraceLog(ex);
                return Json(new { success = false, message = "error" }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult GenerateDocumentNumber()
        {
            try
            {
                Object[] ArrayOfObjects = new Object[3];
                DraftDocument objDoc = CommonMethods.GetDocumentObject(Request.Form);
                //objDoc.CompanyCode = QMSConstants.CompanyCode;
                //objDoc.WorkflowID = QMSConstants.WorkflowID;
                //objDoc.CurrentStageID = CurrentStageID;
                //objDoc.UploadedUserID = (Guid)System.Web.HttpContext.Current.Session[QMSConstants.LoggedInUserID];
                DocumentUpload bllOBJ = new DocumentUpload();
                ArrayOfObjects = bllOBJ.GenerateDocumentNo(objDoc);
                return Json(new { success = true, message1 = ArrayOfObjects }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                LoggerBlock.WriteTraceLog(ex);
                return Json(new { success = true, message = "" }, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpPost]
        public ActionResult GenerateDocumentNumber1(string projCode, string deptCode, string secCode, string catCode)
        {
            try
            {
                Object[] ArrayOfObjects = new Object[3];
                //string compCode = QMSConstants.CompanyCode;
                //DraftDocument objDoc = new DraftDocument();

                //objDoc.CompanyCode = compCode;
                //objDoc.DepartmentCode = deptCode;
                //objDoc.SectionCode = secCode;
                //objDoc.ProjectCode = projCode;
                //objDoc.DocumentCategoryCode = catCode;
                //objDoc.WorkflowID = QMSConstants.WorkflowID;
                //objDoc.CurrentStageID = CurrentStageID;
                //objDoc.UploadedUserID = (Guid)System.Web.HttpContext.Current.Session[QMSConstants.LoggedInUserID];
                //DocumentUpload bllOBJ = new DocumentUpload();
                //ArrayOfObjects = bllOBJ.GenerateDocumentNo(objDoc);
                return Json(new { success = true, message1 = ArrayOfObjects }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                LoggerBlock.WriteTraceLog(ex);
                return Json(new { success = true, message = "" }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult SubmitDocument()
        {
            string result = "";
            try
            {
                StringBuilder strMessage = new StringBuilder();
                DraftDocument objDoc = CommonMethods.GetDocumentObject(Request.Form);
                objDoc.WorkflowID = QMSConstants.WorkflowID;
                objDoc.DocumentNumber = objDoc.PlantCode + "-" + objDoc.SmallCategoryCode + "-" + objDoc.ClassificationCode;
                objDoc.UploadedUserID = (Guid)System.Web.HttpContext.Current.Session[QMSConstants.LoggedInUserID];
                strMessage.AppendLine("UploadedUserID - " + objDoc.UploadedUserID.ToString() + ". ");
                objDoc.UploadedUserName = System.Web.HttpContext.Current.Session[QMSConstants.LoggedInUserDisplayName].ToString();
                //strMessage.AppendLine("DocumentID - " + objDoc.DocumentID.ToString() + ". ");
                //strMessage.AppendLine("WFExecutionID - " + objDoc.WFExecutionID.ToString() + ". ");
                objDoc.RevisionReason = "";
                objDoc.CurrentStageID = CurrentStageID;
                objDoc.Version = "A";
                objDoc.Action = "Submitted";
                //DraftDocument objDoc1 =(DraftDocument)BindModels.GetObject(Request.Form);
                //save image to images folder
                HttpFileCollectionBase files = Request.Files;
                for (int i = 0; i < files.Count; i++)
                {
                    HttpPostedFileBase file = files[i];
                    string flname;

                    // Checking for Internet Explorer  
                    if (Request.Browser.Browser.ToUpper() == "IE" || Request.Browser.Browser.ToUpper() == "INTERNETEXPLORER")
                    {
                        string[] testfiles = file.FileName.Split(new char[] { '\\' });
                        flname = testfiles[testfiles.Length - 1];
                    }
                    else
                    {
                        flname = file.FileName;
                        byte[] fileByteArray = new byte[file.ContentLength];
                        file.InputStream.Read(fileByteArray, 0, file.ContentLength);
                        if (i == 0)
                        {
                            objDoc.DocumentName = flname;
                            objDoc.ByteArray = fileByteArray;
                            objDoc.DocumentPath= CommonMethods.CombineUrl(objDoc.SmallCategoryFolder, objDoc.ClassificationFolder);
                        }
                    }
                }

                NewDocumentUploadBLL objBLL = new NewDocumentUploadBLL();
                string response = objBLL.AddNewDocument(objDoc);

                result = "success";
            }
            catch (Exception ex)
            {
                LoggerBlock.WriteTraceLog(ex);
                result = "failed";
                //throw ex;
            }
            return Json(new { success = true, message = result }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult DownloadTemplate(string folderPath, string fileName)
        {
            string result = "";
            //string filename = "TEPL-COMMON-CE-XX-PO-0006.docx";
            //URL = @"file//D://Storage/QMS/PublishDocuments/CEO OFFICE/CEO OFFICE/POLICY/TEPL-COMMON-CE-XX-PO-0006.docx";
            try
            {
                //string URL = siteURL + "/" + docLib + "/" + folderPath + "/" + fileName;
                string URL = CommonMethods.CombineUrl(QMSConstants.StoragePath, QMSConstants.ReadableFolder, folderPath, fileName);
                DocumentUpload bllOBJ = new DocumentUpload();
                byte[] fileContent = bllOBJ.DownloadDocument(URL);

                return File(fileContent, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);

                //return Json(new { success = true, message = "Test" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                LoggerBlock.WriteTraceLog(ex);
            }
            return Json(new { success = true, message = result }, JsonRequestBehavior.AllowGet);
        }
    }
}