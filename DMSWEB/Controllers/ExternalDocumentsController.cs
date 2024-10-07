using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DMS.BLL.Component;

namespace DMSWEB.Controllers
{
    public class ExternalDocumentsController : Controller
    {
        // GET: ExternalDocuments
        [CustomAuthorize(Roles = "USER,ADMIN,QPADM,QMSADMIN")]
        public ActionResult Index()
        {
            QMSAdmin objAdm = new QMSAdmin();
            ViewBag.Data = objAdm.GetAllExternalDocuments();
            return View();
        }
    }
}