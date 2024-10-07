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
    public class AdminOperationsDAL
    {
        #region PlantMaster
        public string AddPlant(Plant objPlant)
        {
            DataTable dt = new DataTable();
            string response = string.Empty;
            try
            {
                using (SqlConnection con = new SqlConnection(QMSConstants.DBCon))
                {
                    using (SqlCommand cmd = new SqlCommand("spInsertPlant_Master", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@txtCode", SqlDbType.NVarChar, 10).Value = objPlant.Code;
                        cmd.Parameters.Add("@txtName", SqlDbType.NVarChar, 100).Value = objPlant.Name;
                        cmd.Parameters.Add("@flgActive", SqlDbType.Bit).Value = true;
                        cmd.Parameters.Add("@CreatedID", SqlDbType.UniqueIdentifier).Value = objPlant.CreatedID;
                        cmd.Parameters.Add("@dtCreatedDate", SqlDbType.DateTime).Value = objPlant.CreatedDate;
                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                        {
                            sda.Fill(dt);
                        }
                        if (dt.Rows.Count > 0)
                            response = dt.Rows[0][0].ToString();
                        if (response.Contains("inexception"))
                        {
                            throw new Exception(response);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return response;
        }
        public string UpdatePlant(Plant objPlant)
        {
            DataTable dt = new DataTable();
            string response = string.Empty;
            try
            {
                using (SqlConnection con = new SqlConnection(QMSConstants.DBCon))
                {
                    using (SqlCommand cmd = new SqlCommand("spUpdatePlant_Master", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@ID", SqlDbType.UniqueIdentifier).Value = objPlant.ID;
                        cmd.Parameters.Add("@txtCode", SqlDbType.NVarChar, 10).Value = objPlant.Code;
                        cmd.Parameters.Add("@txtName", SqlDbType.NVarChar, 100).Value = objPlant.Name;
                        cmd.Parameters.Add("@flgActive", SqlDbType.Bit).Value = objPlant.IsActive;
                        cmd.Parameters.Add("@LastModifiedID", SqlDbType.UniqueIdentifier).Value = objPlant.ModifiedID;
                        cmd.Parameters.Add("@dtLastModifiedDate", SqlDbType.DateTime).Value = DateTime.Now;
                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                        {
                            sda.Fill(dt);
                        }
                        if (dt.Rows.Count > 0)
                            response = dt.Rows[0][0].ToString();
                        if (response.Contains("inexception"))
                        {
                            throw new Exception(response);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return response;
        }
        public DataTable DeletePlant(Guid ID)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection con = new SqlConnection(QMSConstants.DBCon))
                {
                    using (SqlCommand cmd = new SqlCommand("spDeletePlant_Master", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@ID", SqlDbType.UniqueIdentifier).Value = ID;
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
        public DataTable GetPlantDetailsForID(Guid plantID)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection con = new SqlConnection(QMSConstants.DBCon))
                {
                    using (SqlCommand cmd = new SqlCommand("spGetPlantDetailsForID_Master", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@ID", SqlDbType.UniqueIdentifier).Value = plantID;
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
        public DataTable GetAllPlants()
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection con = new SqlConnection(QMSConstants.DBCon))
                {
                    using (SqlCommand cmd = new SqlCommand("spGetAllPlants_Master", con))
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
            return dt;
        }

        #endregion

        #region PartMaster
        public string AddPart(Part objPart)
        {
            DataTable dt = new DataTable();
            string response = string.Empty;
            try
            {
                using (SqlConnection con = new SqlConnection(QMSConstants.DBCon))
                {
                    using (SqlCommand cmd = new SqlCommand("spInsertPart_Master", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@txtCode", SqlDbType.NVarChar, 10).Value = objPart.Code;
                        cmd.Parameters.Add("@txtName", SqlDbType.NVarChar, 100).Value = objPart.Name;
                        cmd.Parameters.Add("@SmallCategoryID", SqlDbType.UniqueIdentifier).Value = objPart.SmallCategoryID;
                        cmd.Parameters.Add("@flgActive", SqlDbType.Bit).Value = true;
                        cmd.Parameters.Add("@CreatedID", SqlDbType.UniqueIdentifier).Value = objPart.CreatedID;
                        cmd.Parameters.Add("@dtCreatedDate", SqlDbType.DateTime).Value = objPart.CreatedDate;
                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                        {
                            sda.Fill(dt);
                        }
                        if (dt.Rows.Count > 0)
                            response = dt.Rows[0][0].ToString();
                        if (response.Contains("inexception"))
                        {
                            throw new Exception(response);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return response;
        }
        public string UpdatePart(Part objPart)
        {
            DataTable dt = new DataTable();
            string response = string.Empty;
            try
            {
                using (SqlConnection con = new SqlConnection(QMSConstants.DBCon))
                {
                    using (SqlCommand cmd = new SqlCommand("spUpdatePart_Master", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@ID", SqlDbType.UniqueIdentifier).Value = objPart.ID;
                        //cmd.Parameters.Add("@txtCode", SqlDbType.NVarChar, 10).Value = objPart.Code;
                        cmd.Parameters.Add("@txtName", SqlDbType.NVarChar, 100).Value = objPart.Name;
                        cmd.Parameters.Add("@flgActive", SqlDbType.Bit).Value = objPart.IsActive;
                        cmd.Parameters.Add("@LastModifiedID", SqlDbType.UniqueIdentifier).Value = objPart.ModifiedID;
                        cmd.Parameters.Add("@dtLastModifiedDate", SqlDbType.DateTime).Value = DateTime.Now;
                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                        {
                            sda.Fill(dt);
                        }
                        if (dt.Rows.Count > 0)
                            response = dt.Rows[0][0].ToString();
                        if (response.Contains("inexception"))
                        {
                            throw new Exception(response);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return response;
        }
        public DataTable DeletePart(Guid ID)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection con = new SqlConnection(QMSConstants.DBCon))
                {
                    using (SqlCommand cmd = new SqlCommand("spDeletePart_Master", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@ID", SqlDbType.UniqueIdentifier).Value = ID;
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
        public DataTable GetPartDetailsForID(Guid partID)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection con = new SqlConnection(QMSConstants.DBCon))
                {
                    using (SqlCommand cmd = new SqlCommand("spGetPartDetailsForID_Master", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@ID", SqlDbType.UniqueIdentifier).Value = partID;
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
        public DataTable GetAllParts()
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection con = new SqlConnection(QMSConstants.DBCon))
                {
                    using (SqlCommand cmd = new SqlCommand("spGetAllParts_Master", con))
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
            return dt;
        }
        public DataTable GetSmallCategorys()
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection con = new SqlConnection(QMSConstants.DBCon))
                {
                    using (SqlCommand cmd = new SqlCommand("spGetSmallCategorys", con))
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
                LoggerBlock.WriteTraceLog(ex);
            }
            return dt;
        }


        #endregion

        #region CertificationMaster
        public string AddCertification(Certification objCertification)
        {
            DataTable dt = new DataTable();
            string response = string.Empty;
            try
            {
                using (SqlConnection con = new SqlConnection(QMSConstants.DBCon))
                {
                    using (SqlCommand cmd = new SqlCommand("spInsertCertification_Master", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@txtCode", SqlDbType.NVarChar, 10).Value = objCertification.Code;
                        cmd.Parameters.Add("@txtName", SqlDbType.NVarChar, 100).Value = objCertification.Name;
                        cmd.Parameters.Add("@flgActive", SqlDbType.Bit).Value = objCertification.IsActive;
                        cmd.Parameters.Add("@CreatedID", SqlDbType.UniqueIdentifier).Value = objCertification.CreatedID;
                        cmd.Parameters.Add("@dtCreatedDate", SqlDbType.DateTime).Value = objCertification.CreatedDate;
                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                        {
                            sda.Fill(dt);
                        }
                        if (dt.Rows.Count > 0)
                            response = dt.Rows[0][0].ToString();
                        if (response.Contains("inexception"))
                        {
                            throw new Exception(response);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return response;
        }
        public string UpdateCertification(Certification objCertification)
        {
            DataTable dt = new DataTable();
            string response = string.Empty;
            try
            {
                using (SqlConnection con = new SqlConnection(QMSConstants.DBCon))
                {
                    using (SqlCommand cmd = new SqlCommand("spUpdateCertification_Master", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@ID", SqlDbType.UniqueIdentifier).Value = objCertification.ID;
                        cmd.Parameters.Add("@txtCode", SqlDbType.NVarChar, 10).Value = objCertification.Code;
                        cmd.Parameters.Add("@txtName", SqlDbType.NVarChar, 100).Value = objCertification.Name;
                        cmd.Parameters.Add("@flgActive", SqlDbType.Bit).Value = objCertification.IsActive;
                        cmd.Parameters.Add("@LastModifiedID", SqlDbType.UniqueIdentifier).Value = objCertification.ModifiedID;
                        cmd.Parameters.Add("@dtLastModifiedDate", SqlDbType.DateTime).Value = DateTime.Now;
                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                        {
                            sda.Fill(dt);
                        }
                        if (dt.Rows.Count > 0)
                            response = dt.Rows[0][0].ToString();
                        if (response.Contains("inexception"))
                        {
                            throw new Exception(response);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return response;
        }
        public DataTable DeleteCertification(Guid ID)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection con = new SqlConnection(QMSConstants.DBCon))
                {
                    using (SqlCommand cmd = new SqlCommand("spDeleteCertification_Master", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@ID", SqlDbType.UniqueIdentifier).Value = ID;
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
        public DataTable GetCertificationDetailsForID(Guid certificationID)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection con = new SqlConnection(QMSConstants.DBCon))
                {
                    using (SqlCommand cmd = new SqlCommand("spGetCertificationDetailsForID_Master", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@ID", SqlDbType.UniqueIdentifier).Value = certificationID;
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
        public DataTable GetAllCertifications()
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection con = new SqlConnection(QMSConstants.DBCon))
                {
                    using (SqlCommand cmd = new SqlCommand("spGetAllCertifications_Master", con))
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
            return dt;
        }

        #endregion

        #region ConfidenceMaster
        public string AddConfidence(Confidence objConfidence)
        {
            DataTable dt = new DataTable();
            string response = string.Empty;
            try
            {
                using (SqlConnection con = new SqlConnection(QMSConstants.DBCon))
                {
                    using (SqlCommand cmd = new SqlCommand("spInsertConfidence_Master", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@txtCode", SqlDbType.NVarChar, 10).Value = objConfidence.Code;
                        cmd.Parameters.Add("@txtName", SqlDbType.NVarChar, 100).Value = objConfidence.Name;
                        cmd.Parameters.Add("@flgActive", SqlDbType.Bit).Value = true;
                        cmd.Parameters.Add("@CreatedID", SqlDbType.UniqueIdentifier).Value = objConfidence.CreatedID;
                        cmd.Parameters.Add("@dtCreatedDate", SqlDbType.DateTime).Value = objConfidence.CreatedDate;
                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                        {
                            sda.Fill(dt);
                        }
                        if (dt.Rows.Count > 0)
                            response = dt.Rows[0][0].ToString();
                        if (response.Contains("inexception"))
                        {
                            throw new Exception(response);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return response;
        }
        public string UpdateConfidence(Confidence objConfidence)
        {
            DataTable dt = new DataTable();
            string response = string.Empty;
            try
            {
                using (SqlConnection con = new SqlConnection(QMSConstants.DBCon))
                {
                    using (SqlCommand cmd = new SqlCommand("spUpdateConfidence_Master", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@ID", SqlDbType.UniqueIdentifier).Value = objConfidence.ID;
                        cmd.Parameters.Add("@txtCode", SqlDbType.NVarChar, 10).Value = objConfidence.Code;
                        cmd.Parameters.Add("@txtName", SqlDbType.NVarChar, 100).Value = objConfidence.Name;
                        cmd.Parameters.Add("@flgActive", SqlDbType.Bit).Value = objConfidence.IsActive;
                        cmd.Parameters.Add("@LastModifiedID", SqlDbType.UniqueIdentifier).Value = objConfidence.ModifiedID;
                        cmd.Parameters.Add("@dtLastModifiedDate", SqlDbType.DateTime).Value = DateTime.Now;
                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                        {
                            sda.Fill(dt);
                        }
                        if (dt.Rows.Count > 0)
                            response = dt.Rows[0][0].ToString();
                        if (response.Contains("inexception"))
                        {
                            throw new Exception(response);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return response;
        }
        public DataTable DeleteConfidence(Guid ID)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection con = new SqlConnection(QMSConstants.DBCon))
                {
                    using (SqlCommand cmd = new SqlCommand("[spDeleteConfidence_Master]", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@ID", SqlDbType.UniqueIdentifier).Value = ID;
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
        public DataTable GetConfidenceDetailsForID(Guid confidenceID)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection con = new SqlConnection(QMSConstants.DBCon))
                {
                    using (SqlCommand cmd = new SqlCommand("[spGetConfidenceDetailsForID_Master]", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@ID", SqlDbType.UniqueIdentifier).Value = confidenceID;
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
        public DataTable GetAllConfidences()
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection con = new SqlConnection(QMSConstants.DBCon))
                {
                    using (SqlCommand cmd = new SqlCommand("spGetAllConfidences_Master", con))
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
            return dt;
        }

        #endregion

        #region FunctionMaster
        public string AddFunction(Function objFunction)
        {
            DataTable dt = new DataTable();
            string response = string.Empty;
            try
            {
                using (SqlConnection con = new SqlConnection(QMSConstants.DBCon))
                {
                    using (SqlCommand cmd = new SqlCommand("spInsertFunction_Master", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@txtCode", SqlDbType.NVarChar, 10).Value = objFunction.Code;
                        cmd.Parameters.Add("@txtName", SqlDbType.NVarChar, 100).Value = objFunction.Name;
                        cmd.Parameters.Add("@flgActive", SqlDbType.Bit).Value = true;
                        cmd.Parameters.Add("@CreatedID", SqlDbType.UniqueIdentifier).Value = objFunction.CreatedID;
                        cmd.Parameters.Add("@dtCreatedDate", SqlDbType.DateTime).Value = objFunction.CreatedDate;
                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                        {
                            sda.Fill(dt);
                        }
                        if (dt.Rows.Count > 0)
                            response = dt.Rows[0][0].ToString();
                        if (response.Contains("inexception"))
                        {
                            throw new Exception(response);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return response;
        }
        public string UpdateFunction(Function objFunction)
        {
            DataTable dt = new DataTable();
            string response = string.Empty;
            try
            {
                using (SqlConnection con = new SqlConnection(QMSConstants.DBCon))
                {
                    using (SqlCommand cmd = new SqlCommand("spUpdateFunction_Master", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@ID", SqlDbType.UniqueIdentifier).Value = objFunction.ID;
                        cmd.Parameters.Add("@txtCode", SqlDbType.NVarChar, 10).Value = objFunction.Code;
                        cmd.Parameters.Add("@txtName", SqlDbType.NVarChar, 100).Value = objFunction.Name;
                        cmd.Parameters.Add("@flgActive", SqlDbType.Bit).Value = objFunction.IsActive;
                        cmd.Parameters.Add("@LastModifiedID", SqlDbType.UniqueIdentifier).Value = objFunction.ModifiedID;
                        cmd.Parameters.Add("@dtLastModifiedDate", SqlDbType.DateTime).Value = DateTime.Now;
                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                        {
                            sda.Fill(dt);
                        }
                        if (dt.Rows.Count > 0)
                            response = dt.Rows[0][0].ToString();
                        if (response.Contains("inexception"))
                        {
                            throw new Exception(response);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return response;
        }
        public DataTable DeleteFunction(Guid ID)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection con = new SqlConnection(QMSConstants.DBCon))
                {
                    using (SqlCommand cmd = new SqlCommand("spDeleteFunction_Master", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@ID", SqlDbType.UniqueIdentifier).Value = ID;
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
        public DataTable GetFunctionDetailsForID(Guid functionID)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection con = new SqlConnection(QMSConstants.DBCon))
                {
                    using (SqlCommand cmd = new SqlCommand("spGetFunctionDetailsForID_Master", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@ID", SqlDbType.UniqueIdentifier).Value = functionID;
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
        public DataTable GetAllFunctions()
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection con = new SqlConnection(QMSConstants.DBCon))
                {
                    using (SqlCommand cmd = new SqlCommand("spGetAllFunctions_Master", con))
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
            return dt;
        }

        #endregion

        #region CustomerMaster
        public string AddCustomer(Customer objCustomer)
        {
            DataTable dt = new DataTable();
            string response = string.Empty;
            try
            {
                using (SqlConnection con = new SqlConnection(QMSConstants.DBCon))
                {
                    using (SqlCommand cmd = new SqlCommand("spInsertCustomer_Master", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@txtCode", SqlDbType.NVarChar, 10).Value = objCustomer.Code;
                        cmd.Parameters.Add("@txtName", SqlDbType.NVarChar, 100).Value = objCustomer.Name;
                        cmd.Parameters.Add("@flgActive", SqlDbType.Bit).Value = true;
                        cmd.Parameters.Add("@CreatedID", SqlDbType.UniqueIdentifier).Value = objCustomer.CreatedID;
                        cmd.Parameters.Add("@dtCreatedDate", SqlDbType.DateTime).Value = objCustomer.CreatedDate;
                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                        {
                            sda.Fill(dt);
                        }
                        if (dt.Rows.Count > 0)
                            response = dt.Rows[0][0].ToString();
                        if (response.Contains("inexception"))
                        {
                            throw new Exception(response);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return response;
        }
        public string UpdateCustomer(Customer objCustomer)
        {
            DataTable dt = new DataTable();
            string response = string.Empty;
            try
            {
                using (SqlConnection con = new SqlConnection(QMSConstants.DBCon))
                {
                    using (SqlCommand cmd = new SqlCommand("spUpdateCustomer_Master", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@ID", SqlDbType.UniqueIdentifier).Value = objCustomer.ID;
                        cmd.Parameters.Add("@txtCode", SqlDbType.NVarChar, 10).Value = objCustomer.Code;
                        cmd.Parameters.Add("@txtName", SqlDbType.NVarChar, 100).Value = objCustomer.Name;
                        cmd.Parameters.Add("@flgActive", SqlDbType.Bit).Value = objCustomer.IsActive;
                        cmd.Parameters.Add("@LastModifiedID", SqlDbType.UniqueIdentifier).Value = objCustomer.ModifiedID;
                        cmd.Parameters.Add("@dtLastModifiedDate", SqlDbType.DateTime).Value = DateTime.Now;
                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                        {
                            sda.Fill(dt);
                        }
                        if (dt.Rows.Count > 0)
                            response = dt.Rows[0][0].ToString();
                        if (response.Contains("inexception"))
                        {
                            throw new Exception(response);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return response;
        }
        public DataTable DeleteCustomer(Guid ID)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection con = new SqlConnection(QMSConstants.DBCon))
                {
                    using (SqlCommand cmd = new SqlCommand("spDeleteCustmor_Master", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@ID", SqlDbType.UniqueIdentifier).Value = ID;
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
        public DataTable GetCustomerDetailsForID(Guid customerID)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection con = new SqlConnection(QMSConstants.DBCon))
                {
                    using (SqlCommand cmd = new SqlCommand("spGetCustomerDetailsForID_Master", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@ID", SqlDbType.UniqueIdentifier).Value = customerID;
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
        public DataTable GetAllCustomers()
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection con = new SqlConnection(QMSConstants.DBCon))
                {
                    using (SqlCommand cmd = new SqlCommand("spGetAllCustomers_Master", con))
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
            return dt;
        }

        #endregion

        #region ModelMaster
        public string AddModel(Model objModel)
        {
            DataTable dt = new DataTable();
            string response = string.Empty;
            try
            {
                using (SqlConnection con = new SqlConnection(QMSConstants.DBCon))
                {
                    using (SqlCommand cmd = new SqlCommand("spInsertModel_Master", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@txtCode", SqlDbType.NVarChar, 10).Value = objModel.Code;
                        cmd.Parameters.Add("@txtName", SqlDbType.NVarChar, 100).Value = objModel.Name;
                        cmd.Parameters.Add("@flgActive", SqlDbType.Bit).Value = true;
                        cmd.Parameters.Add("@SmallCategoryID", SqlDbType.UniqueIdentifier).Value = objModel.SmallCategoryID;
                        cmd.Parameters.Add("@CreatedID", SqlDbType.UniqueIdentifier).Value = objModel.CreatedID;
                        cmd.Parameters.Add("@dtCreatedDate", SqlDbType.DateTime).Value = objModel.CreatedDate;
                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                        {
                            sda.Fill(dt);
                        }
                        if (dt.Rows.Count > 0)
                            response = dt.Rows[0][0].ToString();
                        if (response.Contains("inexception"))
                        {
                            throw new Exception(response);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return response;
        }
        public string UpdateModel(Model objModel)
        {
            DataTable dt = new DataTable();
            string response = string.Empty;
            try
            {
                using (SqlConnection con = new SqlConnection(QMSConstants.DBCon))
                {
                    using (SqlCommand cmd = new SqlCommand("[spUpdateModel_Master]", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@ID", SqlDbType.UniqueIdentifier).Value = objModel.ID;
                        //cmd.Parameters.Add("@txtCode", SqlDbType.NVarChar, 10).Value = objModel.Code;
                        cmd.Parameters.Add("@txtName", SqlDbType.NVarChar, 100).Value = objModel.Name;
                        cmd.Parameters.Add("@flgActive", SqlDbType.Bit).Value = objModel.IsActive;
                        cmd.Parameters.Add("@LastModifiedID", SqlDbType.UniqueIdentifier).Value = objModel.ModifiedID;
                        cmd.Parameters.Add("@dtLastModifiedDate", SqlDbType.DateTime).Value = DateTime.Now;
                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                        {
                            sda.Fill(dt);
                        }
                        if (dt.Rows.Count > 0)
                            response = dt.Rows[0][0].ToString();
                        if (response.Contains("inexception"))
                        {
                            throw new Exception(response);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return response;
        }
        public DataTable DeleteModel(Guid ID)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection con = new SqlConnection(QMSConstants.DBCon))
                {
                    using (SqlCommand cmd = new SqlCommand("spDeleteModel_Master", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@ID", SqlDbType.UniqueIdentifier).Value = ID;
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
        public DataTable GetModelDetailsForID(Guid modelID)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection con = new SqlConnection(QMSConstants.DBCon))
                {
                    using (SqlCommand cmd = new SqlCommand("spGetModelDetailsForID_Master", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@ID", SqlDbType.UniqueIdentifier).Value = modelID;
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
        public DataTable GetAllModels()
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection con = new SqlConnection(QMSConstants.DBCon))
                {
                    using (SqlCommand cmd = new SqlCommand("spGetAllModels_Master", con))
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
            return dt;
        }
        public DataTable GetSmallCategories()
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection con = new SqlConnection(QMSConstants.DBCon))
                {
                    using (SqlCommand cmd = new SqlCommand("spGetSmallCategorys", con))
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
                LoggerBlock.WriteTraceLog(ex);
            }
            return dt;
        }


        #endregion

        #region SmallCategoryMaster
        public string AddSmallCategory(SmallCategory objSmallCategory)
        {
            DataTable dt = new DataTable();
            string response = string.Empty;
            try
            {
                using (SqlConnection con = new SqlConnection(QMSConstants.DBCon))
                {
                    using (SqlCommand cmd = new SqlCommand("spInsertSmallCategory_Master", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@txtCode", SqlDbType.NVarChar, 10).Value = objSmallCategory.Code;
                        cmd.Parameters.Add("@txtName", SqlDbType.NVarChar, 100).Value = objSmallCategory.Name;
                        cmd.Parameters.Add("@flgActive", SqlDbType.Bit).Value = true;
                        cmd.Parameters.Add("@ClassificationID", SqlDbType.UniqueIdentifier).Value = objSmallCategory.ClassificationID;
                        cmd.Parameters.Add("@CreatedID", SqlDbType.UniqueIdentifier).Value = objSmallCategory.CreatedID;
                        cmd.Parameters.Add("@dtCreatedDate", SqlDbType.DateTime).Value = objSmallCategory.CreatedDate;
                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                        {
                            sda.Fill(dt);
                        }
                        if (dt.Rows.Count > 0)
                            response = dt.Rows[0][0].ToString();
                        if (response.Contains("inexception"))
                        {
                            throw new Exception(response);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return response;
        }
        public string UpdateSmallCategory(SmallCategory objSmallCategory)
        {
            DataTable dt = new DataTable();
            string response = string.Empty;
            try
            {
                using (SqlConnection con = new SqlConnection(QMSConstants.DBCon))
                {
                    using (SqlCommand cmd = new SqlCommand("spUpdateSmallCategory_Master", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@ID", SqlDbType.UniqueIdentifier).Value = objSmallCategory.ID;
                        cmd.Parameters.Add("@txtName", SqlDbType.NVarChar, 100).Value = objSmallCategory.Name;
                        cmd.Parameters.Add("@flgActive", SqlDbType.Bit).Value = objSmallCategory.IsActive;
                        cmd.Parameters.Add("@LastModifiedID", SqlDbType.UniqueIdentifier).Value = objSmallCategory.ModifiedID;
                        cmd.Parameters.Add("@dtLastModifiedDate", SqlDbType.DateTime).Value = DateTime.Now;
                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                        {
                            sda.Fill(dt);
                        }
                        if (dt.Rows.Count > 0)
                            response = dt.Rows[0][0].ToString();
                        if (response.Contains("inexception"))
                        {
                            throw new Exception(response);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return response;
        }
        public DataTable DeleteSmallCategory(Guid ID)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection con = new SqlConnection(QMSConstants.DBCon))
                {
                    using (SqlCommand cmd = new SqlCommand("spDeleteSmallCategory_Master", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@ID", SqlDbType.UniqueIdentifier).Value = ID;
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
        public DataTable GetAllSmallCategoryDetailsForID(Guid smallCategoryID)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection con = new SqlConnection(QMSConstants.DBCon))
                {
                    using (SqlCommand cmd = new SqlCommand("spGetSmallCategoryDetailsForID_Master", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@ID", SqlDbType.UniqueIdentifier).Value = smallCategoryID;
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
        public DataTable GetAllSmallCategorys()
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection con = new SqlConnection(QMSConstants.DBCon))
                {
                    using (SqlCommand cmd = new SqlCommand("spGetAllSmallCategorys_Master", con))
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
            return dt;
        }

        public DataTable GetClassifications()
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection con = new SqlConnection(QMSConstants.DBCon))
                {
                    using (SqlCommand cmd = new SqlCommand("[spGetClassifications]", con))
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
                LoggerBlock.WriteTraceLog(ex);
            }
            return dt;
        }


        #endregion

        #region ClassificationMaster
        public string AddClassification(Classification objClassification)
        {
            DataTable dt = new DataTable();
            string response = string.Empty;
            try
            {
                using (SqlConnection con = new SqlConnection(QMSConstants.DBCon))
                {
                    using (SqlCommand cmd = new SqlCommand("[spInsertClassification_Master]", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@txtCode", SqlDbType.NVarChar, 10).Value = objClassification.Code;
                        cmd.Parameters.Add("@txtName", SqlDbType.NVarChar, 100).Value = objClassification.Name;
                        cmd.Parameters.Add("@Level", SqlDbType.NVarChar, 10).Value = objClassification.Level;
                        cmd.Parameters.Add("@PlantID", SqlDbType.UniqueIdentifier).Value = objClassification.PlantID;
                        cmd.Parameters.Add("@flgActive", SqlDbType.Bit).Value = true;
                        cmd.Parameters.Add("@CreatedID", SqlDbType.UniqueIdentifier).Value = objClassification.CreatedID;
                        cmd.Parameters.Add("@dtCreatedDate", SqlDbType.DateTime).Value = objClassification.CreatedDate;
                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                        {
                            sda.Fill(dt);
                        }
                        if (dt.Rows.Count > 0)
                            response = dt.Rows[0][0].ToString();
                        if (response.Contains("inexception"))
                        {
                            throw new Exception(response);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return response;
        }
        public string UpdateClassification(Classification objClassification)
        {
            DataTable dt = new DataTable();
            string response = string.Empty;
            try
            {
                using (SqlConnection con = new SqlConnection(QMSConstants.DBCon))
                {
                    using (SqlCommand cmd = new SqlCommand("[spUpdateClassification_Master]", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@ID", SqlDbType.UniqueIdentifier).Value = objClassification.ID;
                        cmd.Parameters.Add("@txtName", SqlDbType.NVarChar, 100).Value = objClassification.Name;
                        //cmd.Parameters.Add("@Level", SqlDbType.NVarChar, 10).Value = objClassification.Level;                        
                        cmd.Parameters.Add("@flgActive", SqlDbType.Bit).Value = objClassification.IsActive;
                        cmd.Parameters.Add("@LastModifiedID", SqlDbType.UniqueIdentifier).Value = objClassification.ModifiedID;
                        cmd.Parameters.Add("@dtLastModifiedDate", SqlDbType.DateTime).Value = DateTime.Now;
                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                        {
                            sda.Fill(dt);
                        }
                        if (dt.Rows.Count > 0)
                            response = dt.Rows[0][0].ToString();
                        if (response.Contains("inexception"))
                        {
                            throw new Exception(response);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return response;
        }
        public DataTable DeleteClassification(Guid ID)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection con = new SqlConnection(QMSConstants.DBCon))
                {
                    using (SqlCommand cmd = new SqlCommand("spDeleteClassification_Master", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@ID", SqlDbType.UniqueIdentifier).Value = ID;
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
        public DataTable GetClassificationDetailsForID(Guid plantID)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection con = new SqlConnection(QMSConstants.DBCon))
                {
                    using (SqlCommand cmd = new SqlCommand("spGetClassificationDetailsForID_Master", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@ID", SqlDbType.UniqueIdentifier).Value = plantID;
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
        public DataTable GetAllClassifications()
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection con = new SqlConnection(QMSConstants.DBCon))
                {
                    using (SqlCommand cmd = new SqlCommand("[spGetAllClassifications_Master]", con))
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
            return dt;
        }
        public DataTable GetPlants()
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection con = new SqlConnection(QMSConstants.DBCon))
                {
                    using (SqlCommand cmd = new SqlCommand("[spGetPlants]", con))
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
            return dt;
        }

        #endregion

        #region DepartmentMaster
        public string AddDepartment(Department objDepart)
        {
            DataTable dt = new DataTable();
            string response = string.Empty;
            try
            {
                using (SqlConnection con = new SqlConnection(QMSConstants.DBCon))
                {
                    using (SqlCommand cmd = new SqlCommand("[spInsertDepartment_Master]", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@Code", SqlDbType.NVarChar, 10).Value = objDepart.Code;
                        cmd.Parameters.Add("@ShortName", SqlDbType.NVarChar, 20).Value = objDepart.ShortName;
                        cmd.Parameters.Add("@Name", SqlDbType.NVarChar, 100).Value = objDepart.Name;
                        cmd.Parameters.Add("@IsActive", SqlDbType.Bit).Value = true;
                        cmd.Parameters.Add("@CreatedID", SqlDbType.UniqueIdentifier).Value = objDepart.CreatedID;
                        cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = objDepart.CreatedDate;
                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                        {
                            sda.Fill(dt);
                        }
                        if (dt.Rows.Count > 0)
                            response = dt.Rows[0][0].ToString();
                        if (response.Contains("inexception"))
                        {
                            throw new Exception(response);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return response;
        }
        public string UpdateDepartment(Department objDepart)
        {
            DataTable dt = new DataTable();
            string response = string.Empty;
            try
            {
                using (SqlConnection con = new SqlConnection(QMSConstants.DBCon))
                {
                    using (SqlCommand cmd = new SqlCommand("[spUpdateDepartment_Master]", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@ID", SqlDbType.UniqueIdentifier).Value = objDepart.ID;
                        //cmd.Parameters.Add("@ShortName", SqlDbType.NVarChar, 20).Value = objDepart.ShortName;
                        cmd.Parameters.Add("@txtName", SqlDbType.NVarChar, 100).Value = objDepart.Name;
                        cmd.Parameters.Add("@flgActive", SqlDbType.Bit).Value = objDepart.IsActive;
                        cmd.Parameters.Add("@LastModifiedID", SqlDbType.UniqueIdentifier).Value = objDepart.ModifiedID;
                        cmd.Parameters.Add("@dtLastModifiedDate", SqlDbType.DateTime).Value = DateTime.Now;
                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                        {
                            sda.Fill(dt);
                        }
                        if (dt.Rows.Count > 0)
                            response = dt.Rows[0][0].ToString();
                        if (response.Contains("inexception"))
                        {
                            throw new Exception(response);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return response;
        }
        public DataTable DeleteDepartment(Guid ID)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection con = new SqlConnection(QMSConstants.DBCon))
                {
                    using (SqlCommand cmd = new SqlCommand("[spDeleteDepartment_Master]", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@ID", SqlDbType.UniqueIdentifier).Value = ID;
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

        public DataTable GetAllDepartments()
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection con = new SqlConnection(QMSConstants.DBCon))
                {
                    using (SqlCommand cmd = new SqlCommand("[spGetAllDepartments_Master]", con))
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
            return dt;
        }

        #endregion

    }
}
