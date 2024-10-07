using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DMS.BLL.Component;
using DMS.Common;
using DMS.Common.Constants;
using DMSWEB.Controllers;

namespace DMSWEB.Areas.Admin.Controllers
{
    public class DocumentNoController : Controller
    {
        [CustomAuthorize(Roles = "QADM")]
        public ActionResult Index()
        {
            try
            {
                QMSAdmin objAdm = new QMSAdmin();
                ViewBag.Data = objAdm.GetDocumentNumbers("", "", "", "");
                //int i =  0,j=1,k=j/i;
            }
            catch (Exception ex)
            {
                LoggerBlock.WriteTraceLog(ex);
                return Json(new { success = false, message = "error" }, JsonRequestBehavior.AllowGet);
            }
            return View();
        }
        public ActionResult GetDocumentNumbers(string department, string section, string project, string category)
        {
            try
            {
                QMSAdmin objAdm = new QMSAdmin();
                var objDocs = objAdm.GetDocumentNumbers(department, section, project, category);
                return Json(new { success = true, message = objDocs }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                LoggerBlock.WriteTraceLog(ex);
                return Json(new { success = false, message = "error" }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult UpdateSerialNo(string DocumentID, string SerialNo)
        {
            try
            {

                return Json(new { success = true, message = "Success" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                LoggerBlock.WriteTraceLog(ex);
                return Json(new { success = false, message = "exception" }, JsonRequestBehavior.AllowGet);
            }
        }

    }
}