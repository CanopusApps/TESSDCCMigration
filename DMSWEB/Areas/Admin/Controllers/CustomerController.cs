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
    public class CustomerController : Controller
    {
        public ActionResult Index()
        {
            try
            {
                AdminOperationsBLL objBLL = new AdminOperationsBLL();
                ViewBag.Data = objBLL.GetAllCustomers();
            }
            catch (Exception ex)
            {
                LoggerBlock.WriteTraceLog(ex);
            }
            return View();
        }
        [HttpPost]
        public ActionResult GetCustomerDetailsForID(string id)
        {
            try
            {
                AdminOperationsBLL objBLL = new AdminOperationsBLL();
                var data = objBLL.GetCustomerDetailsForID(new Guid(id));
                return Json(new { success = true, message = data }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                LoggerBlock.WriteTraceLog(ex);
                return Json(new { success = true, message = "error" }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult AddCustomer(string customerCode, string customerName, string active)
        {
            string result = "";
            try
            {
                Customer objCustmr = new Customer();
                if (customerCode != "")
                    objCustmr.Code = customerCode;
                if (customerName != "")
                    objCustmr.Name = customerName;
                if (active != "")
                {
                    if (active.ToString().ToLower() == "true")
                        objCustmr.IsActive = true;
                    else
                        objCustmr.IsActive = false;
                }
                objCustmr.CreatedID = new Guid(System.Web.HttpContext.Current.Session[QMSConstants.LoggedInUserID].ToString());
                objCustmr.CreatedDate = DateTime.Now;

                AdminOperationsBLL objBLL = new AdminOperationsBLL();
                result = objBLL.AddCustomer(objCustmr);
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
        public ActionResult UpdateCustomer()
        {
            string result = "";
            try
            {
                Customer objCustmr = new Customer();
                if (Request.Form["CustomerID"].ToString() != "")
                    objCustmr.ID = new Guid(Request.Form["CustomerID"].ToString());
                if (Request.Form["txtCode"].ToString() != "")
                    objCustmr.Code = Request.Form["txtCode"].ToString();
                if (Request.Form["txtName"].ToString() != "")
                    objCustmr.Name = Request.Form["txtName"].ToString();
                if (Request.Form["flgActive"].ToString().ToLower() == "true")
                    objCustmr.IsActive = true;
                else
                    objCustmr.IsActive = false;
                objCustmr.ModifiedID = new Guid(System.Web.HttpContext.Current.Session[QMSConstants.LoggedInUserID].ToString());
                objCustmr.ModifiedDate = DateTime.Now;
                AdminOperationsBLL objBLL = new AdminOperationsBLL();
                result = objBLL.UpdateCustomer(objCustmr);
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

        public ActionResult DeleteCustomer(Guid ID)
        {
            string result = "";

            try
            {
                AdminOperationsBLL objBLL = new AdminOperationsBLL();
                result = objBLL.DeleteCustomer(ID);
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