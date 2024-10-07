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
    public class NewDocumentUploadDAL
    {
        public DataTable GetActivePlants()
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection con = new SqlConnection(QMSConstants.DBCon))
                {
                    using (SqlCommand cmd = new SqlCommand(QMSConstants.spGetActivePlants, con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                        {
                            sda.Fill(dt);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {

            }
            return dt;
        }
        public DataSet GetDropdownsForNewUpload()
        {
            DataSet datasets = new DataSet();
            try
            {
                using(SqlConnection conn = new SqlConnection(QMSConstants.DBCon))
                {
                    using(SqlCommand command = new SqlCommand(QMSConstants.spGetDropDownsForNewUpload, conn))
                    {
                        command.CommandTimeout = 30;
                        SqlDataAdapter dataAdapater = new SqlDataAdapter();
                        dataAdapater.SelectCommand = command;
                        conn.Open();
                        dataAdapater.Fill(datasets, "ResultSets");
                        conn.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                
            }
            return datasets;
        }
        public DataTable GetClassificationForPlant(Guid parentID)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection con = new SqlConnection(QMSConstants.DBCon))
                {
                    using (SqlCommand cmd = new SqlCommand(QMSConstants.spGetClassificationForPlant, con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@ParentID", SqlDbType.UniqueIdentifier, 100).Value = parentID;
                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                        {
                            sda.Fill(dt);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }
        public DataTable GetActiveSmallCategories(Guid parentID)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection con = new SqlConnection(QMSConstants.DBCon))
                {
                    using (SqlCommand cmd = new SqlCommand(QMSConstants.spGetActiveSmallCategories, con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@ParentID", SqlDbType.UniqueIdentifier, 100).Value = parentID;
                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                        {
                            sda.Fill(dt);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }
        public DataSet GetModelPartsForSmallCat(Guid parentID)
        {
            DataSet datasets = new DataSet();
            try
            {
                using (SqlConnection conn = new SqlConnection(QMSConstants.DBCon))
                {
                    using (SqlCommand command = new SqlCommand(QMSConstants.spGetModelPartsForSmallCat, conn))
                    {
                        command.CommandTimeout = 30;
                        command.Parameters.Add(new SqlParameter("@ParentID", parentID));
                        command.CommandType = CommandType.StoredProcedure;
                        SqlDataAdapter dataAdapater = new SqlDataAdapter();
                        dataAdapater.SelectCommand = command;
                        conn.Open();
                        dataAdapater.Fill(datasets, "ResultSets");
                        conn.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {

            }
            return datasets;
        }
        public string AddNewDocument(DraftDocument objDoc)
        {
            string result = string.Empty;
            try
            {
                using (SqlConnection con = new SqlConnection(QMSConstants.DBCon))
                {
                    using (SqlCommand cmd = new SqlCommand(QMSConstants.spAddNewDocument, con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@WorkflowID", SqlDbType.UniqueIdentifier).Value = objDoc.WorkflowID;
                        cmd.Parameters.Add("@WorkflowStageID", SqlDbType.UniqueIdentifier).Value = objDoc.CurrentStageID;
                        cmd.Parameters.Add("@PlantCode", SqlDbType.NVarChar, 10).Value = objDoc.PlantCode;
                        cmd.Parameters.Add("@SmallCategoryCode", SqlDbType.NVarChar, 10).Value = objDoc.SmallCategoryCode;
                        cmd.Parameters.Add("@ClassificationCode", SqlDbType.NVarChar, 10).Value = objDoc.ClassificationCode;
                        cmd.Parameters.Add("@ApplicantID", SqlDbType.UniqueIdentifier).Value = objDoc.ApplicantID;
                        cmd.Parameters.Add("@DocumentNumber", SqlDbType.NVarChar, 50).Value = objDoc.DocumentNumber;
                        cmd.Parameters.Add("@DocumentName", SqlDbType.NVarChar, 50).Value = objDoc.DocumentName;
                        cmd.Parameters.Add("@DocumentDescription", SqlDbType.NVarChar, 500).Value = objDoc.DocumentDescription;
                        cmd.Parameters.Add("@DocumentSubject", SqlDbType.NVarChar, 50).Value = objDoc.DocumentSubject;
                        cmd.Parameters.Add("@DocumentAuthor", SqlDbType.NVarChar, 50).Value = objDoc.DocumentAuthor;
                        cmd.Parameters.Add("@DocumentPath", SqlDbType.NVarChar, 500).Value = objDoc.DocumentPath;
                        cmd.Parameters.Add("@PlantID", SqlDbType.UniqueIdentifier).Value = objDoc.PlantID;
                        cmd.Parameters.Add("@ClassificationID", SqlDbType.UniqueIdentifier).Value = objDoc.ClassificationID;
                        cmd.Parameters.Add("@BigCategory", SqlDbType.NVarChar, 10).Value = objDoc.BigCategory;
                        cmd.Parameters.Add("@SmallCategoryID", SqlDbType.UniqueIdentifier).Value = objDoc.SmallCategoryID;
                        cmd.Parameters.Add("@ModelID", SqlDbType.UniqueIdentifier).Value = objDoc.ModelID;
                        cmd.Parameters.Add("@PartID", SqlDbType.UniqueIdentifier).Value = objDoc.PartID;
                        cmd.Parameters.Add("@ConfidenceLevelID", SqlDbType.UniqueIdentifier).Value = objDoc.ConfidenceLevelID;
                        cmd.Parameters.Add("@CustomerID", SqlDbType.UniqueIdentifier).Value = objDoc.CustomerID;
                        cmd.Parameters.Add("@CertificationID", SqlDbType.UniqueIdentifier).Value = objDoc.CertificationID;
                        cmd.Parameters.Add("@FunctionID", SqlDbType.UniqueIdentifier).Value = objDoc.FunctionID;
                        cmd.Parameters.Add("@Stage", SqlDbType.NVarChar, 50).Value = objDoc.Stage;
                        cmd.Parameters.Add("@Version", SqlDbType.NVarChar, 10).Value = objDoc.Version;
                        cmd.Parameters.Add("@Comments", SqlDbType.NVarChar, -1).Value = objDoc.Comments;
                        cmd.Parameters.Add("@CreatedID", SqlDbType.UniqueIdentifier).Value = objDoc.UploadedUserID;
                        cmd.Parameters.Add("@LastModifiedID", SqlDbType.UniqueIdentifier).Value = objDoc.UploadedUserID;
                        con.Open();
                        result = cmd.ExecuteScalar().ToString();                        
                        con.Close();
                        if (result.Contains("inexception"))
                        {
                            throw new Exception(result);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }
    }
}
