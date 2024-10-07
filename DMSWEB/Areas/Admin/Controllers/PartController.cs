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
    public class PartController : Controller
    {
        public ActionResult Index()
        {
            try
            {
                AdminOperationsBLL objBLL = new AdminOperationsBLL();
                ViewBag.Data = objBLL.GetAllParts();
            }
            catch (Exception ex)
            {
                LoggerBlock.WriteTraceLog(ex);
            }

            return View();
        }
        [HttpPost]
        public ActionResult GetPartDetailsForID(string id)
        {
            try
            {
                AdminOperationsBLL objBLL = new AdminOperationsBLL();
                var data = objBLL.GetPartDetailsForID(new Guid(id));
                return Json(new { success = true, message = data }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                LoggerBlock.WriteTraceLog(ex);
                return Json(new { success = true, message = "error" }, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult GetSmallCategorys()
        {
            try
            {
                AdminOperationsBLL objBLL = new AdminOperationsBLL();
                List<SmallCategory> list1 = objBLL.GetSmallCategorys();
                return Json(new { success = true, message1 = list1 }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                LoggerBlock.WriteTraceLog(ex);
                return Json(new { success = true, message = "" }, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpPost]
        public ActionResult AddPart(string partCode, string partName, string SmallCategoryID)
        {
            string result = "";
            try
            {
                Part objprt = new Part();
                if (partCode != "")
                    objprt.Code = partCode;
                if (partName != "")
                    objprt.Name = partName;
                if (SmallCategoryID != "")
                    objprt.SmallCategoryID = new Guid (SmallCategoryID);
                objprt.CreatedID = new Guid(System.Web.HttpContext.Current.Session[QMSConstants.LoggedInUserID].ToString());
                objprt.CreatedDate = DateTime.Now;

                AdminOperationsBLL objBLL = new AdminOperationsBLL();
                result = objBLL.AddPart(objprt);
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
        public ActionResult UpdatePart()
        {
            string result = "";
            try
            {
                Part objprt = new Part();
                if (Request.Form["PartID"].ToString() != "")
                    objprt.ID = new Guid(Request.Form["PartID"].ToString());
                //if (Request.Form["PartCode"].ToString() != "")
                //    objprt.Code = Request.Form["PartCode"].ToString();
                if (Request.Form["PartName"].ToString() != "")
                    objprt.Name = Request.Form["PartName"].ToString();
                if (Request.Form["Active"].ToString().ToLower() == "true")
                    objprt.IsActive = true;
                else
                    objprt.IsActive = false;
                objprt.ModifiedID = new Guid(System.Web.HttpContext.Current.Session[QMSConstants.LoggedInUserID].ToString());
                objprt.ModifiedDate = DateTime.Now;
                AdminOperationsBLL objBLL = new AdminOperationsBLL();
                result = objBLL.UpdatePart(objprt);
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

        public ActionResult DeletePart(Guid ID)
        {
            string result = "";

            try
            {
                AdminOperationsBLL objBLL = new AdminOperationsBLL();
                result = objBLL.DeletePart(ID);
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