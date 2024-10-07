using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DMS.BLL.Component;
using DMS.Common;
using DMS.Common.Constants;
using DMS.Common.Models;

namespace DMSWEB.Controllers
{
    public class DashboardController : Controller
    {
        // GET: Dashboard
        [CustomAuthorize(Roles = "USER")]
        public ActionResult Index()
        {
            Guid LoggedInUserID = (Guid)System.Web.HttpContext.Current.Session[QMSConstants.LoggedInUserID];
            QMSAdmin objQMSAdmin = new QMSAdmin();
            string strRoles = System.Web.HttpContext.Current.Session[QMSConstants.LoggedInUserRoles].ToString();
            if (strRoles.Contains("QADM"))
                ViewBag.isQMSAdmin = true;
            else ViewBag.isQMSAdmin = false;

            DocumentUpload obj = new DocumentUpload();
            ViewBag.Data = obj.GetPublishedDocuments("", "", "", "", "", LoggedInUserID);
            ViewBag.ViewerURL = ConfigurationManager.AppSettings["ViewerURL"].ToString();
            return View();
        }

        public ActionResult Index2()
        {
            
            return View("Index-Bkp");
        }
        public ActionResult GetExportPublishedDocuments(string department, string section, string project, string category, string DocumentDescription)
        {
            Guid LoggedInUserID = (Guid)System.Web.HttpContext.Current.Session[QMSConstants.LoggedInUserID];
            DocumentUpload obj = new DocumentUpload();
            byte[] fileContent = obj.GetExportPublishedDocuments(department, section, project, category, DocumentDescription, LoggedInUserID);
            //return File(fileContent, System.Net.Mime.MediaTypeNames.Application.Octet, LoggedInUserID + ".xlsx");
            string base64 = Convert.ToBase64String(fileContent, 0, fileContent.Length);
            return Content(base64);
        }
        public ActionResult GetPublishedDocuments(string department, string section, string project, string category, string DocumentDescription)
        {
            try
            {
                Guid LoggedInUserID = (Guid)System.Web.HttpContext.Current.Session[QMSConstants.LoggedInUserID];
                DocumentUpload obj = new DocumentUpload();
                var objDocs = obj.GetPublishedDocuments(department, section, project, category, DocumentDescription, LoggedInUserID);
                return Json(new { success = true, message = objDocs }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                LoggerBlock.WriteTraceLog(ex);
                return Json(new { success = false, message = "error" }, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult DownloadDocument(string folderPath, string folder, double versionNo, string fileName)
        {
            try
            {
                string URL = CommonMethods.CombineUrl(QMSConstants.StoragePath, folder, folderPath, fileName);
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

        //public ActionResult DownloadDraftHistoryDocument(string folderPath, double versionNo, string fileName)
        //{
        //    try
        //    {
        //        int VNo = Convert.ToInt32(versionNo);// - 1;
        //        string URL = CommonMethods.CombineUrl(QMSConstants.BackUpPath, QMSConstants.DraftFolder, folderPath, fileName.Split('.')[0].ToString() + "_V" + VNo + "." + fileName.Split('.')[1].ToString());
        //        DocumentUpload bllOBJ = new DocumentUpload();
        //        byte[] fileContent = bllOBJ.DownloadDocument(URL);

        //        return File(fileContent, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
        //    }
        //    catch (Exception ex)
        //    {
        //        LoggerBlock.WriteTraceLog(ex);
        //        return Json(new { success = true, message = "failed" }, JsonRequestBehavior.AllowGet);
        //    }
        //}

        //public ActionResult DownloadPublishedHistoryDocument(string folderPath, double versionNo, string fileName)
        //{
        //    try
        //    {
        //        int VNo = Convert.ToInt32(versionNo);// - 1;
        //        string URL = CommonMethods.CombineUrl(QMSConstants.BackUpPath, QMSConstants.ReadableFolder, folderPath, fileName.Split('.')[0].ToString() + "_V" + VNo + "." + fileName.Split('.')[1].ToString());
        //        DocumentUpload bllOBJ = new DocumentUpload();
        //        byte[] fileContent = bllOBJ.DownloadDocument(URL);

        //        return File(fileContent, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
        //    }
        //    catch (Exception ex)
        //    {
        //        LoggerBlock.WriteTraceLog(ex);
        //        return Json(new { success = true, message = "failed" }, JsonRequestBehavior.AllowGet);
        //    }
        //}

        public ActionResult DownloadHistoryDocument(string folderPath,string folder, double versionNo, string fileName)
        {
            try
            {
                int VNo = Convert.ToInt32(versionNo);// - 1;
                string URL = CommonMethods.CombineUrl(QMSConstants.BackUpPath, folder, folderPath, fileName.Split('.')[0].ToString() + "_V" + VNo + "." + fileName.Split('.')[1].ToString());
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