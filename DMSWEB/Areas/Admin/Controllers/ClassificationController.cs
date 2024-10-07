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
    public class ClassificationController : Controller
    {
        public ActionResult Index()
        {
            try
            {
                AdminOperationsBLL objBLL = new AdminOperationsBLL();
                ViewBag.Data = objBLL.GetAllClassifications();
            }
            catch (Exception ex)
            {
                LoggerBlock.WriteTraceLog(ex);
            }
            return View();
        }
        public ActionResult GetPlants()
        {
            try
            {
                AdminOperationsBLL objBLL = new AdminOperationsBLL();
                List<Plant> list1 = objBLL.GetPlants();
                return Json(new { success = true, message1 = list1 }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                LoggerBlock.WriteTraceLog(ex);
                return Json(new { success = true, message = "" }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult GetClassificationDetailsForID(string id)
        {
            try
            {
                AdminOperationsBLL objBLL = new AdminOperationsBLL();
                var data = objBLL.GetClassificationDetailsForID(new Guid(id));
                return Json(new { success = true, message = data }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                LoggerBlock.WriteTraceLog(ex);
                return Json(new { success = true, message = "error" }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult AddClassification()
        {
            string result = "";
            try
            {
                Classification objClsf = new Classification();
                if (Request.Form["txtCode"].ToString() != "")
                    objClsf.Code = Request.Form["txtCode"].ToString();
                if (Request.Form["txtName"].ToString() != "")
                    objClsf.Name = Request.Form["txtName"].ToString();
                if (Request.Form["level"].ToString() != "")
                    objClsf.Level = Request.Form["level"].ToString();
                if (Request.Form["plantID"].ToString() != "")
                    objClsf.PlantID = new Guid(Request.Form["plantID"].ToString());

                objClsf.CreatedID = new Guid(System.Web.HttpContext.Current.Session[QMSConstants.LoggedInUserID].ToString());
                objClsf.CreatedDate = DateTime.Now;
                AdminOperationsBLL objBLL = new AdminOperationsBLL();
                result = objBLL.AddClassification(objClsf);
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
        public ActionResult UpdateClassification()
        {
            string result = "";
            try
            {
                Classification objClsf = new Classification();
                if (Request.Form["ClassificationID"].ToString() != "")
                    objClsf.ID = new Guid(Request.Form["ClassificationID"].ToString());
                if (Request.Form["txtName"].ToString() != "")
                    objClsf.Name = Request.Form["txtName"].ToString();
                //if (Request.Form["Level"].ToString() != "")
                //    objClsf.Level = Request.Form["Level"].ToString();                
                if (Request.Form["flgActive"].ToString().ToLower() == "true")
                    objClsf.IsActive = true;
                else
                    objClsf.IsActive = false;
                objClsf.ModifiedID = new Guid(System.Web.HttpContext.Current.Session[QMSConstants.LoggedInUserID].ToString());
                objClsf.ModifiedDate = DateTime.Now;
                AdminOperationsBLL objBLL = new AdminOperationsBLL();
                result = objBLL.UpdateClassification(objClsf);
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

        public ActionResult DeleteClassification(Guid ID)
        {
            string result = "";

            try
            {
                AdminOperationsBLL objBLL = new AdminOperationsBLL();
                result = objBLL.DeleteClassification(ID);
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