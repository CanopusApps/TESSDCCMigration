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
    
    public class CategoryController : Controller
    {
        [CustomAuthorize(Roles = "QADM")]
        public ActionResult Index()
        {
            try
            {
                QMSAdmin objAdm = new QMSAdmin();
                ViewBag.Data = objAdm.GetDocumentCategories();
            }
            catch (Exception ex)
            {
                LoggerBlock.WriteTraceLog(ex);
                return Json(new { success = false, message = "error" }, JsonRequestBehavior.AllowGet);
            }
            return View();
        }

        [HttpPost]
        public ActionResult AddCategory()
        {
            string result = "";
            try
            {
                Classification objDocCat = new Classification();
                if (Request.Form["DocumentCategoryCode"].ToString() != "")
                    objDocCat.Code = Request.Form["DocumentCategoryCode"].ToString();
                if (Request.Form["DocumentCategoryName"].ToString() != "")
                    objDocCat.Name = Request.Form["DocumentCategoryName"].ToString();
                if (Request.Form["DocumentLevel"].ToString() != "")
                    objDocCat.Level = Request.Form["DocumentLevel"].ToString();
                if (Request.Form["FolderName"].ToString() != "")
                    objDocCat.FolderName = Request.Form["FolderName"].ToString();
                objDocCat.IsActive = true;
                QMSAdmin objAdmin = new QMSAdmin();
                result=objAdmin.AddDocumentCategory(objDocCat);
            }
            catch (Exception ex)
            {
                LoggerBlock.WriteTraceLog(ex);
                result = "failed";
                //throw ex;
            }
            return Json(new
            {
                success = true,
                message = result
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult UpdateCategory()
        {
            string result = "";
            try
            {
                Classification objDocCat = new Classification();
                if (Request.Form["DocumentCategoryID"].ToString() != "")
                    objDocCat.ID = new Guid(Request.Form["DocumentCategoryID"].ToString());
                if (Request.Form["DocumentCategoryName"].ToString() != "")
                    objDocCat.Name = Request.Form["DocumentCategoryName"].ToString();
                if (Request.Form["DocumentLevel"].ToString() != "")
                    objDocCat.Level = Request.Form["DocumentLevel"].ToString();
                if (Request.Form["FolderName"].ToString() != "")
                    objDocCat.FolderName = Request.Form["FolderName"].ToString();
                if (Request.Form["IsActive"].ToString().ToLower() == "true")
                    objDocCat.IsActive = true;
                else
                    objDocCat.IsActive = false;

                QMSAdmin objAdmin = new QMSAdmin();
                result = objAdmin.UpdateDocumentCategory(objDocCat);
            }
            catch (Exception ex)
            {
                LoggerBlock.WriteTraceLog(ex);
                result = "failed";
                //throw ex;
            }
            return Json(new
            {
                success = true,
                message = result
            }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult DeleteCategory(Guid ID)
        {
            string result = "";
           
            try
            {
                Classification objDocCat = new Classification();
                objDocCat.ID = ID;
                QMSAdmin objAdmin = new QMSAdmin();
                result = objAdmin.DeleteDocumentCategory(objDocCat);
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
                message = result
            }, JsonRequestBehavior.AllowGet);
        }
    }
}