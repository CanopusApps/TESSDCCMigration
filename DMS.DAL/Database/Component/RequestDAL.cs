using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DMS.Common;
using DMS.Common.Constants;
using DMS.Common.Models;

namespace DMS.DAL.Database.Component
{
    public class RequestDAL
    {
        public string GetDocumentDetailsByID(string role, Guid loggedInUserID, Guid DocumentID)
        {
            string strReturn = string.Empty;
            try
            {
                using (SqlConnection con = new SqlConnection(QMSConstants.DBCon))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand(QMSConstants.spGetDocumentDetailsByID, con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@DocumentID", SqlDbType.UniqueIdentifier).Value = DocumentID;
                        cmd.Parameters.Add("@Role", SqlDbType.NVarChar, 10).Value = role;
                        cmd.Parameters.Add("@LoginUserID", SqlDbType.UniqueIdentifier).Value = loggedInUserID;
                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            sda.Fill(dt);
                            strReturn = dt.Rows[0][0].ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return strReturn;
        }
    }
}
