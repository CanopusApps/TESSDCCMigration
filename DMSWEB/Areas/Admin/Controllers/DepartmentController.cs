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
    
    public class DepartmentController : Controller
    {
        public ActionResult Index()
        {
            try
            {
                AdminOperationsBLL objBLL = new AdminOperationsBLL();
                ViewBag.Data = objBLL.GetAllDepartments();
            }
            catch (Exception ex)
            {
                LoggerBlock.WriteTraceLog(ex);
                return Json(new { success = false, message = "error" }, JsonRequestBehavior.AllowGet);
            }
            return View();
        }

        [HttpPost]
        public ActionResult AddDepartment()
        {
            string result = "";
            try
            {
                Department objDept = new Department();
                if (Request.Form["DepartmentCode"].ToString() != "")
                    objDept.Code = Request.Form["DepartmentCode"].ToString();
                if (Request.Form["DepartmentName"].ToString() != "")
                    objDept.Name = Request.Form["DepartmentName"].ToString();
                if (Request.Form["DepartmentShortName"].ToString() != "")
                    objDept.ShortName = Request.Form["DepartmentShortName"].ToString();
                objDept.CreatedID = new Guid(System.Web.HttpContext.Current.Session[QMSConstants.LoggedInUserID].ToString());
                objDept.CreatedDate = DateTime.Now;
                AdminOperationsBLL objBLL = new AdminOperationsBLL();
                result = objBLL.AddDepartment(objDept);
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

        [HttpPost]
        public ActionResult UpdateDepartment()
        {
            string result = "";
            try
            {
                Department objDept = new Department();
                if (Request.Form["DepartmentID"].ToString() != "")
                    objDept.ID = new Guid(Request.Form["DepartmentID"].ToString());
                //if (Request.Form["DepartmentCode"].ToString() != "")
                //    objDept.Code = Request.Form["DepartmentCode"].ToString();
                if (Request.Form["DepartmentName"].ToString() != "")
                    objDept.Name = Request.Form["DepartmentName"].ToString();
                if (Request.Form["Active"].ToString().ToLower() == "true")
                    objDept.IsActive = true;
                else
                    objDept.IsActive = false;
                AdminOperationsBLL objBLL = new AdminOperationsBLL();
                result = objBLL.UpdateDepartment(objDept);
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

        public ActionResult DeleteDepartment(Guid ID)
        {
            string result = "";

            try
            {              
                
                AdminOperationsBLL objBLL = new AdminOperationsBLL();
                result = objBLL.DeleteDepartment(ID);
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
    }
}