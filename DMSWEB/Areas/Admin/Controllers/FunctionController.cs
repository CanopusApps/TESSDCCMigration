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
    public class FunctionController : Controller
    {
        public ActionResult Index()
        {
            try
            {
                AdminOperationsBLL objBLL = new AdminOperationsBLL();
                ViewBag.Data = objBLL.GetAllFunctions();
            }
            catch (Exception ex)
            {
                LoggerBlock.WriteTraceLog(ex);
            }
            return View();
        }
        [HttpPost]
        public ActionResult GetFunctionDetailsForID(string id)
        {
            try
            {
                AdminOperationsBLL objBLL = new AdminOperationsBLL();
                var data = objBLL.GetFunctionDetailsForID(new Guid(id));
                return Json(new { success = true, message = data }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                LoggerBlock.WriteTraceLog(ex);
                return Json(new { success = true, message = "error" }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult AddFunction(string functionCode, string functionName, string active)
        {
            string result = "";
            try
            {
                Function objFuncn = new Function();
                if (functionCode != "")
                    objFuncn.Code = functionCode;
                if (functionName != "")
                    objFuncn.Name = functionName;
                if (active != "")
                {
                    if (active.ToString().ToLower() == "true")
                        objFuncn.IsActive = true;
                    else
                        objFuncn.IsActive = false;
                }
                objFuncn.CreatedID = new Guid(System.Web.HttpContext.Current.Session[QMSConstants.LoggedInUserID].ToString());
                objFuncn.CreatedDate = DateTime.Now;

                AdminOperationsBLL objBLL = new AdminOperationsBLL();
                result = objBLL.AddFunction(objFuncn);
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
        public ActionResult UpdateFunction()
        {
            string result = "";
            try
            {
                Function objFuncn = new Function();
                if (Request.Form["FunctionID"].ToString() != "")
                    objFuncn.ID = new Guid(Request.Form["FunctionID"].ToString());
                if (Request.Form["txtCode"].ToString() != "")
                    objFuncn.Code = Request.Form["txtCode"].ToString();
                if (Request.Form["txtName"].ToString() != "")
                    objFuncn.Name = Request.Form["txtName"].ToString();
                if (Request.Form["flgActive"].ToString().ToLower() == "true")
                    objFuncn.IsActive = true;
                else
                    objFuncn.IsActive = false;
                objFuncn.ModifiedID = new Guid(System.Web.HttpContext.Current.Session[QMSConstants.LoggedInUserID].ToString());
                objFuncn.ModifiedDate = DateTime.Now;
                AdminOperationsBLL objBLL = new AdminOperationsBLL();
                result = objBLL.UpdateFunction(objFuncn);
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

        public ActionResult DeleteFunction(Guid ID)
        {
            string result = "";

            try
            {
                AdminOperationsBLL objBLL = new AdminOperationsBLL();
                result = objBLL.DeleteFunction(ID);
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