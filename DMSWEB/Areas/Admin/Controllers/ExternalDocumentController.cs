using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DMS.BLL.Component;
using DMS.Common;
using DMS.Common.Constants;
using DMS.Common.Models;
using DMSWEB.Common;
using DMSWEB.Controllers;

namespace DMSWEB.Areas.Admin.Controllers
{
    public class ExternalDocumentController : Controller
    {
        // GET: Admin/ExternalDocument
        [CustomAuthorize(Roles = "QPADM")]
        public ActionResult Index()
        {
            QMSAdmin objAdm = new QMSAdmin();
            ViewBag.Data = objAdm.GetAllExternalDocuments();
            return View();
        }
        [CustomAuthorize(Roles = "ADMIN,QPADM,QMSADMIN")]
        public ActionResult Create()
        {
            return View();
        }

        [CustomAuthorize(Roles = "ADMIN,QPADM,QMSADMIN")]
        public ActionResult Edit()
        {            
            ViewBag.ExternalDocumentID = new Guid(Request.QueryString["ID"].ToString());
            return View();
        }
        //public ActionResult GetExternalDocument(int ExternalDocumentID)
        //{
        //    try
        //    {
        //        var list1 = GetExternalDocumentForID(ExternalDocumentID);
        //        return Json(new { success = true, message1 = list1 });
        //    }
        //    catch (Exception ex)
        //    {
        //        return Json(new { success = false, message1 = "Error" });
        //    }
        //}

        [CustomAuthorize(Roles = "ADMIN,QPADM,QMSADMIN")]
        public ActionResult Details()
        {
            try
            {
                ViewBag.ExternalDocumentID = new Guid(Request.QueryString["ID"].ToString());
                return View();
            }
            catch (Exception ex)
            {

            }
            return View();
        }
        [CustomAuthorize(Roles = "ADMIN,QPADM,QMSADMIN")]
        public ActionResult GetExternalDocumentForID(string ExternalDocumentID)
        {
            try
            {
                QMSAdmin objAdm = new QMSAdmin();
                var data = objAdm.GetExternalDocumentForID(new Guid(ExternalDocumentID));
                return Json(new { success = true, message = data }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "error while getting data" }, JsonRequestBehavior.AllowGet);
            }            
        }

        [HttpPost]
        public JsonResult SearchUser(string UserName)
        {
            try
            {
                QMSAdmin objAdm = new QMSAdmin();
                List<User> listUsers = objAdm.SearchUser(UserName);
                return Json(new { success = true, message = listUsers }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                LoggerBlock.WriteTraceLog(ex);
                return Json(new { success = true, message = "" }, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult SaveExternalDocument()
        {
            string response = "";
            ExternalDocument obj = new ExternalDocument();
            byte[] byteArray = null;
            bool docUploaded = false;
            try
            {                
                obj.Title = Request.Form["Title"].ToString();
                obj.DocumentNo = Request.Form["DocumentNo"].ToString();
                if (Request.Form["Version"].ToString() != "")
                    obj.Version = Convert.ToInt32(Request.Form["Version"].ToString());
                if (Request.Form["VersionDate"].ToString() != "")
                    obj.VersionDate = DateTime.Parse(Request.Form["VersionDate"].ToString());                
                obj.Organization = Request.Form["Organization"].ToString();
                if (Request.Form["ResponsibleUser"].ToString() != "")
                    obj.ResponsibleUserID = new Guid(Request.Form["ResponsibleUser"].ToString());
                obj.Department = Request.Form["Department"].ToString();
                obj.FileURL = Request.Form["FileURL"].ToString();
                obj.CreatedBy = new Guid(System.Web.HttpContext.Current.Session[QMSConstants.LoggedInUserID].ToString());
                obj.FileName = "";
                obj.Active = true;

                //save file to  folder
                HttpFileCollectionBase files = Request.Files;
                for (int i = 0; i < files.Count; i++)
                {
                    HttpPostedFileBase file = files[i];

                    string flname = "";
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
                        byteArray = fileByteArray;
                        obj.FileName = file.FileName;
                        docUploaded = true;
                        //FileName = file.FileName;
                    }
                    // Get the complete folder path and store the file inside it.  
                    //if (flname != "")
                    //{
                    //    //flname = Path.Combine(Server.MapPath("~/assets/img/avatars/"), flname);
                    //    flname = Path.Combine(Server.MapPath("~/Files/"), flname);
                    //    file.SaveAs(flname);
                    //}
                }
                QMSAdmin objAdmin = new QMSAdmin();
                response = objAdmin.AddExternalDocument(obj, byteArray, docUploaded);
            }
            catch (Exception ex)
            {
                response = "Error while saving the External Document";
            }

            return Json(new { success = true, message = response }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult UpdateExternalDocument()
        {
            string response = "";
            ExternalDocument obj = new ExternalDocument();
            byte[] byteArray = null;
            bool docUploaded = false;
            try
            {
                obj.ID = new Guid(Request.Form["ExternalDocumentID"].ToString());
                obj.Title = Request.Form["Title"].ToString();
                obj.DocumentNo = Request.Form["DocumentNo"].ToString();
                if (Request.Form["Version"].ToString() != "")
                    obj.Version = Convert.ToInt32(Request.Form["Version"].ToString());
                if (Request.Form["VersionDate"].ToString() != "")
                    obj.VersionDate = DateTime.Parse(Request.Form["VersionDate"].ToString());
                obj.Organization = Request.Form["Organization"].ToString();
                if (Request.Form["ResponsibleUserID"].ToString() != "")
                    obj.ResponsibleUserID = new Guid(Request.Form["ResponsibleUserID"].ToString());
                obj.Department = Request.Form["Department"].ToString();
                obj.FileURL = Request.Form["FileURL"].ToString();
                obj.ModifiedBy = new Guid(System.Web.HttpContext.Current.Session[QMSConstants.LoggedInUserID].ToString());
                obj.FileName = Request.Form["OLDFileName"].ToString();
                //save file to  folder
                HttpFileCollectionBase files = Request.Files;
                for (int i = 0; i < files.Count; i++)
                {
                    HttpPostedFileBase file = files[i];

                    string flname = "";
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
                        byteArray = fileByteArray;
                        obj.FileName = file.FileName;
                        docUploaded = true;
                        //FileName = file.FileName;
                    }
                }
                obj.Active = true;
                QMSAdmin objAdmin = new QMSAdmin();
                response = objAdmin.UpdateExternalDocument(obj, byteArray, docUploaded);
            }
            catch (Exception ex)
            {
                response = "Error while saving the External Document";
            }

            return Json(new { success = true, message = response }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult DeleteExternalDocument()
        {
            string result = "";

            try
            {
                Guid ID = new Guid(Request.Form["ID"].ToString());
                QMSAdmin objAdmin = new QMSAdmin();
                result = objAdmin.DeleteExternalDocument(ID);
                // result = "sucess";

            }
            catch (Exception ex)
            {
                LoggerBlock.WriteTraceLog(ex);
                result = "failed";
                throw ex;
            }
            return Json(new
            {
                success = true,
                message = "Document Deleted Successfully."
            }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult DownloadDocument(string filePath, string fileName)
        {
            try
            {
                string URL = CommonMethods.CombineUrl(QMSConstants.StoragePath, QMSConstants.ExtDocumentFolder, filePath, fileName);
                DocumentUpload bllOBJ = new DocumentUpload();
                byte[] fileContent = bllOBJ.DownloadDocument(URL);

                return File(fileContent, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
            }
            catch (Exception ex)
            {
                LoggerBlock.WriteTraceLog(ex);
                return Json(new { success = true, message = "failed" }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}