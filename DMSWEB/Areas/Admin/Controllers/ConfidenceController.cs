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
    public class ConfidenceController : Controller
    {
        public ActionResult Index()
        {
            try
            {
                AdminOperationsBLL objBLL = new AdminOperationsBLL();
                ViewBag.Data = objBLL.GetAllConfidences();
            }
            catch (Exception ex)
            {
                LoggerBlock.WriteTraceLog(ex);
            }
            return View();
        }
        [HttpPost]
        public ActionResult GetConfidenceDetailsForID(string id)
        {
            try
            {
                AdminOperationsBLL objBLL = new AdminOperationsBLL();
                var data = objBLL.GetConfidenceDetailsForID(new Guid(id));
                return Json(new { success = true, message = data }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                LoggerBlock.WriteTraceLog(ex);
                return Json(new { success = true, message = "error" }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult AddConfidence(string ConfidenceCode, string confidenceName, string active)
        {
            string result = "";
            try
            {
                Confidence objcnfidence = new Confidence();
                if (ConfidenceCode != "")
                    objcnfidence.Code = ConfidenceCode;
                if (confidenceName != "")
                    objcnfidence.Name = confidenceName;
                if (active != "")
                {
                    if (active.ToString().ToLower() == "true")
                        objcnfidence.IsActive = true;
                    else
                        objcnfidence.IsActive = false;
                }
                objcnfidence.CreatedID = new Guid(System.Web.HttpContext.Current.Session[QMSConstants.LoggedInUserID].ToString());
                objcnfidence.CreatedDate = DateTime.Now;

                AdminOperationsBLL objBLL = new AdminOperationsBLL();
                result = objBLL.AddConfidence(objcnfidence);
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

        [HttpPost]
        public ActionResult UpdateConfidence()
        {
            string result = "";
            try
            {
                Confidence objcnfidence = new Confidence();
                if (Request.Form["ConfidenceID"].ToString() != "")
                    objcnfidence.ID = new Guid(Request.Form["ConfidenceID"].ToString());
                if (Request.Form["txtCode"].ToString() != "")
                    objcnfidence.Code = Request.Form["txtCode"].ToString();
                if (Request.Form["txtName"].ToString() != "")
                    objcnfidence.Name = Request.Form["txtName"].ToString();
                if (Request.Form["flgActive"].ToString().ToLower() == "true")
                    objcnfidence.IsActive = true;
                else
                    objcnfidence.IsActive = false;
                objcnfidence.ModifiedID = new Guid(System.Web.HttpContext.Current.Session[QMSConstants.LoggedInUserID].ToString());
                objcnfidence.ModifiedDate = DateTime.Now;
                AdminOperationsBLL objBLL = new AdminOperationsBLL();
                result = objBLL.UpdateConfidence(objcnfidence);
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

        public ActionResult DeleteConfidence(Guid ID)
        {
            string result = "";

            try
            {
                AdminOperationsBLL objBLL = new AdminOperationsBLL();
                result = objBLL.DeleteConfidence(ID);
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