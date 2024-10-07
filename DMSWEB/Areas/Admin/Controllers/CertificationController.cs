using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DMS.BLL.Component;
using DMS.Common;
using DMS.Common.Constants;
using DMS.Common.Models;
using DMSWEB.Controllers;

namespace DMSWEB.Areas.Admin.Controllers
{    
    public class CertificationController : Controller
    {
        public ActionResult Index()
        {
            try
            {
                AdminOperationsBLL objBLL = new AdminOperationsBLL();
                ViewBag.Data = objBLL.GetAllCertifications();
            }
            catch (Exception ex)
            {
                LoggerBlock.WriteTraceLog(ex);
            }
            return View();
        }
        [HttpPost]
        public ActionResult GetCertificationDetailsForID(string id)
        {
            try
            {
                AdminOperationsBLL objBLL = new AdminOperationsBLL();
                var data = objBLL.GetCertificationDetailsForID(new Guid(id));
                return Json(new { success = true, message = data }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                LoggerBlock.WriteTraceLog(ex);
                return Json(new { success = true, message = "error" }, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult AddCertification()
        {
            string result = "";
            try
            {
                Certification objCrtification = new Certification();
                if (Request.Form["certificationCode"].ToString() != "")
                    objCrtification.Code = Request.Form["certificationCode"].ToString();                
                if (Request.Form["certificationName"].ToString() != "")
                    objCrtification.Name = Request.Form["certificationName"].ToString();
                objCrtification.IsActive = true;
                objCrtification.CreatedID = new Guid(System.Web.HttpContext.Current.Session[QMSConstants.LoggedInUserID].ToString());
                objCrtification.CreatedDate = DateTime.Now;

                AdminOperationsBLL objBLL = new AdminOperationsBLL();
                result = objBLL.AddCertification(objCrtification);
            }
            catch (Exception ex)
            {
                LoggerBlock.WriteTraceLog(ex);
                result = "exception";
                //throw ex;
            }
            return Json(new
            {
                success = true,
                message = result
            }, JsonRequestBehavior.AllowGet);
        }


        //[HttpPost]
        //public ActionResult AddCertification(string certificationCode, string certificationName, string active)
        //{
        //    string result = "";
        //    try
        //    {
        //        Certification objCrtification = new Certification();
        //        if (certificationCode != "")
        //            objCrtification.Code = certificationCode;
        //        if (certificationName != "")
        //            objCrtification.Name = certificationName;
        //        if (active != "")
        //        {
        //            if (active.ToString().ToLower() == "true")
        //                objCrtification.IsActive = true;
        //            else
        //                objCrtification.IsActive = false;
        //        }

        //        objCrtification.CreatedID = new Guid(System.Web.HttpContext.Current.Session[QMSConstants.LoggedInUserID].ToString());
        //        objCrtification.CreatedDate = DateTime.Now;

        //        AdminOperationsBLL objBLL = new AdminOperationsBLL();
        //        result = objBLL.AddCertification(objCrtification);
        //    }
        //    catch (Exception ex)
        //    {
        //        LoggerBlock.WriteTraceLog(ex);
        //        result = "exception";
        //    }
        //    return Json(new
        //    {
        //        success = true,
        //        message = result
        //    }, JsonRequestBehavior.AllowGet);
        //}


        public ActionResult UpdateCertification()
        {
            string result = "";
            try
            {
                Certification objCrtification = new Certification();
                if (Request.Form["CertificationID"].ToString() != "")
                    objCrtification.ID = new Guid(Request.Form["CertificationID"].ToString());
                if (Request.Form["certificationCode"].ToString() != "")
                    objCrtification.Code = Request.Form["certificationCode"].ToString();
                if (Request.Form["certificationName"].ToString() != "")
                    objCrtification.Name = Request.Form["certificationName"].ToString();
                if (Request.Form["flgActive"].ToString().ToLower() == "true")
                    objCrtification.IsActive = true;
                else
                    objCrtification.IsActive = false;
                objCrtification.ModifiedID = new Guid(System.Web.HttpContext.Current.Session[QMSConstants.LoggedInUserID].ToString());
                objCrtification.ModifiedDate = DateTime.Now;
                AdminOperationsBLL objBLL = new AdminOperationsBLL();
                result = objBLL.UpdateCertification(objCrtification);
            }
            catch (Exception ex)
            {
                LoggerBlock.WriteTraceLog(ex);
                result = "exception";
            }
            return Json(new
            {
                success = true,
                message = result
            }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult DeleteCertification(Guid ID)
        {
            string result = "";

            try
            {
                AdminOperationsBLL objBLL = new AdminOperationsBLL();
                result = objBLL.DeleteCertification(ID);
            }
            catch (Exception ex)
            {
                LoggerBlock.WriteTraceLog(ex);
                result = "exception";
            }
            return Json(new
            {
                success = true,
                message = result
            }, JsonRequestBehavior.AllowGet);
        }


    }
}