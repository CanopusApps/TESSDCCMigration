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
    public class InboxBLL
    {
        InboxDAL objDAL = new InboxDAL();
        DocumentOperations docOperObj = new DocumentOperations();

        public List<DraftDocument> GetRequestedDocuments(Guid CreatedID)
        {
            List<DraftDocument> objDocuments = null;
            try
            {
                objDocuments = new List<DraftDocument>();
                DataTable dt = objDAL.GetRequestedDocuments(CreatedID);

                for (int z = 0; z < dt.Rows.Count; z++)
                {
                    DraftDocument obj = new DraftDocument();
                    obj.SeqNo = z;
                    obj.ID = new Guid(dt.Rows[z]["DocumentID"].ToString());
                    obj.DocumentNumber = dt.Rows[z]["DocumentNo"].ToString();
                    obj.DocumentName = dt.Rows[z]["DocumentName"].ToString();
                    obj.PlantName = dt.Rows[z]["PlantName"].ToString();
                    obj.SmallCategoryName = dt.Rows[z]["SmallCategory"].ToString();
                    obj.ClassificationName = dt.Rows[z]["ClassificationName"].ToString();
                    //obj.ProjectName = dt.Rows[z]["ProjectName"].ToString();
                    obj.CreatedDate = DateTime.Parse(dt.Rows[z]["CreatedDate"].ToString());
                    obj.CurrentStage = dt.Rows[z]["CurrentStage"].ToString();

                    objDocuments.Add(obj);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objDocuments;
        }
    }
}
