using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DMS.BLL.Component;
using DMS.Common;
using DMS.Common.Constants;

namespace DMSWEB.Controllers
{
    public class DownloadTemplateController : Controller
    {
        // GET: DownloadTemplate
        [CustomAuthorize(Roles = "USER")]
        public ActionResult Index()
        {
            QMSAdmin objAdm = new QMSAdmin();
            ViewBag.Data = objAdm.GetDocumentTemplates();

            return View();
        }

        public ActionResult DownloadDocument(string filePath, string fileName)
        {
            try
            {
                string URL = CommonMethods.CombineUrl(QMSConstants.StoragePath, QMSConstants.TemplateFolder, filePath, fileName);
                DocumentUpload bllOBJ = new DocumentUpload();
                byte[] fileContent = bllOBJ.DownloadDocument(URL);

                return File(fileContent, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
            }
            catch (Exception ex)
            {
                LoggerBlock.WriteTraceLog(ex);
                return Json(new { success = true, message = "failed" }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}