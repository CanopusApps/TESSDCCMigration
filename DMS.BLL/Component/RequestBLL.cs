using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DMS.Common;
using DMS.Common.Constants;
using DMS.Common.Models;
using DMS.DAL.Database.Component;
using DMS.Workflow.Business;
using DMS.Workflow.Models;

namespace DMS.BLL.Component
{
    public class RequestBLL
    {
        RequestDAL objDAL = new RequestDAL();
        //DocumentOperations docOperObj = new DocumentOperations();

        public DraftDocument GetDocumentDetailsByID(string role, Guid loggedInUserID, Guid DocumentID)
        {
            DraftDocument objDocuments = null;
            try
            {
                string strReturn = objDAL.GetDocumentDetailsByID(role, loggedInUserID, DocumentID);
                List<DraftDocument> objDraft = BindModels.ConvertJSON<DraftDocument>(strReturn);
                objDocuments = objDraft[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objDocuments;
        }
    }
}
