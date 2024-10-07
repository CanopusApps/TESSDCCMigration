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
    public class ModelController : Controller
    {
        public ActionResult Index()
        {
            try
            {
                AdminOperationsBLL objBLL = new AdminOperationsBLL();
                ViewBag.Data = objBLL.GetAllModels();
            }
            catch (Exception ex)
            {
                LoggerBlock.WriteTraceLog(ex);
            }
            return View();
        }
        public ActionResult GetSmallCategorys()
        {
            try
            {
                AdminOperationsBLL objBLL = new AdminOperationsBLL();
                List<SmallCategory> list1 = objBLL.GetSmallCategories();
                return Json(new { success = true, message1 = list1 }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                LoggerBlock.WriteTraceLog(ex);
                return Json(new { success = true, message = "" }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult GetModelDetailsForID(string id)
        {
            try
            {
                AdminOperationsBLL objBLL = new AdminOperationsBLL();
                var data = objBLL.GetModelDetailsForID(new Guid(id));
                return Json(new { success = true, message = data }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                LoggerBlock.WriteTraceLog(ex);
                return Json(new { success = true, message = "error" }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult AddModel(string modelCode, string modelName, string active, string SmallCategoryID)
        {
            string result = "";
            try
            {
                Model objMdl = new Model();
                if (modelCode != "")
                    objMdl.Code = modelCode;
                if (modelName != "")
                    objMdl.Name = modelName;
                if (SmallCategoryID != "")
                    objMdl.SmallCategoryID = new Guid(SmallCategoryID);
                if (active != "")
                {
                    if (active.ToString().ToLower() == "true")
                        objMdl.IsActive = true;
                    else
                        objMdl.IsActive = false;
                }
                objMdl.CreatedID = new Guid(System.Web.HttpContext.Current.Session[QMSConstants.LoggedInUserID].ToString());
                objMdl.CreatedDate = DateTime.Now;

                AdminOperationsBLL objBLL = new AdminOperationsBLL();
                result = objBLL.AddModel(objMdl);
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
        public ActionResult UpdateModel()
        {
            string result = "";
            try
            {
                Model objMdl = new Model();
                if (Request.Form["ModelID"].ToString() != "")
                    objMdl.ID = new Guid(Request.Form["ModelID"].ToString());
                //if (Request.Form["txtCode"].ToString() != "")
                //    objMdl.Code = Request.Form["txtCode"].ToString();
                if (Request.Form["txtName"].ToString() != "")
                    objMdl.Name = Request.Form["txtName"].ToString();
                if (Request.Form["flgActive"].ToString().ToLower() == "true")
                    objMdl.IsActive = true;
                else
                    objMdl.IsActive = false;
                objMdl.ModifiedID = new Guid(System.Web.HttpContext.Current.Session[QMSConstants.LoggedInUserID].ToString());
                objMdl.ModifiedDate = DateTime.Now;
                AdminOperationsBLL objBLL = new AdminOperationsBLL();
                result = objBLL.UpdateModel(objMdl);
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

        public ActionResult DeleteModel(Guid ID)
        {
            string result = "";

            try
            {
                AdminOperationsBLL objBLL = new AdminOperationsBLL();
                result = objBLL.DeleteModel(ID);
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