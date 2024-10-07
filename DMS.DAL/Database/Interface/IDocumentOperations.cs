using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DMS.Common.Models;

namespace DMS.DAL.Database.Interface
{
    public interface IDocumentOperations
    {
        DraftDocument GenerateDocumentNo(DraftDocument objDoc);
        string GetDocumentDetailsByID(string role, Guid loggedInUserID, Guid DocumentID);
        string GetDocumentDetailsByNo(string DocumentNo);
    }
}
