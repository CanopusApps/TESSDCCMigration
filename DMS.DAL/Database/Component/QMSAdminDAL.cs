﻿using System;
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
    public class QMSAdminDAL
    {
        public DataTable GetDocumentNumbers(string DepartmentCode, string SectionCode, string ProjectCode, string DocumentCategoryCode)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection con = new SqlConnection(QMSConstants.DBCon))
                {
                    using (SqlCommand cmd = new SqlCommand(QMSConstants.spGetDocumentNumbers, con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@DepartmentCode", SqlDbType.NVarChar, 10).Value = DepartmentCode;
                        cmd.Parameters.Add("@SectionCode", SqlDbType.NVarChar, 10).Value = SectionCode;
                        cmd.Parameters.Add("@ProjectCode", SqlDbType.NVarChar, 10).Value = ProjectCode;
                        cmd.Parameters.Add("@DocumentCategoryCode", SqlDbType.NVarChar, 10).Value = DocumentCategoryCode;
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
        public DataTable SelectDocument(string selectQuery)
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(QMSConstants.DBCon))
            {
                using (SqlCommand cmd = new SqlCommand(selectQuery, con))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        sda.Fill(dt);
                    }
                }
            }
            return dt;
        }
        public DataSet DeleteDocument(Guid UserID, Guid DocumentNo)
        {
            DataSet ds = new DataSet();
            try
            {
                using (SqlConnection con = new SqlConnection(QMSConstants.DBCon))
                {
                    using (SqlCommand cmd = new SqlCommand(QMSConstants.spDeleteDocument, con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@UserID", SqlDbType.UniqueIdentifier).Value = UserID;
                        cmd.Parameters.Add("@DocumentID", SqlDbType.UniqueIdentifier).Value = DocumentNo;
                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                        {
                            sda.Fill(ds);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                LoggerBlock.WriteTraceLog(ex);
            }
            return ds;
        }
        public DataTable AddDepartment(Department objDept)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection con = new SqlConnection(QMSConstants.DBCon))
                {
                    using (SqlCommand cmd = new SqlCommand(QMSConstants.spAddDepartment, con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@DepartmentCode", SqlDbType.NVarChar, 10).Value = objDept.Code;
                        cmd.Parameters.Add("@DepartmentName", SqlDbType.NVarChar, 100).Value = objDept.Name;
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
        public DataTable UpdateDepartment(Department objDept)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection con = new SqlConnection(QMSConstants.DBCon))
                {
                    using (SqlCommand cmd = new SqlCommand(QMSConstants.spUpdateDepartment, con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@DepartmentID", SqlDbType.UniqueIdentifier).Value = objDept.ID;
                        cmd.Parameters.Add("@DepartmentCode", SqlDbType.NVarChar, 10).Value = objDept.Code;
                        cmd.Parameters.Add("@DepartmentName", SqlDbType.NVarChar, 100).Value = objDept.Name;
                        cmd.Parameters.Add("@Active", SqlDbType.Bit).Value = objDept.IsActive;
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
        public DataTable DeleteDepartment(Department objDept)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection con = new SqlConnection(QMSConstants.DBCon))
                {
                    using (SqlCommand cmd = new SqlCommand(QMSConstants.spDeleteDepartment, con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@DepartmentID", SqlDbType.UniqueIdentifier).Value = objDept.ID;
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
        public DataTable AddDocumentCategory(Classification objDocCat)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection con = new SqlConnection(QMSConstants.DBCon))
                {
                    using (SqlCommand cmd = new SqlCommand(QMSConstants.spAddDocumentCategory, con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@CategoryCode", SqlDbType.NVarChar, 10).Value = objDocCat.Code;
                        cmd.Parameters.Add("@CategoryName", SqlDbType.NVarChar, 100).Value = objDocCat.Name;
                        cmd.Parameters.Add("@Level", SqlDbType.NVarChar, 10).Value = objDocCat.Level;
                        cmd.Parameters.Add("@FolderName", SqlDbType.NVarChar, 100).Value = objDocCat.FolderName;
                        cmd.Parameters.Add("@flgActive", SqlDbType.NVarChar, 100).Value = objDocCat.IsActive;
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
        public DataTable UpdateDocumentCategory(Classification entObject)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection con = new SqlConnection(QMSConstants.DBCon))
                {
                    using (SqlCommand cmd = new SqlCommand(QMSConstants.spUpdateDocumentCategory, con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@CategoryID", SqlDbType.UniqueIdentifier).Value = entObject.ID;
                        cmd.Parameters.Add("@CategoryName", SqlDbType.NVarChar, 100).Value = entObject.Name;
                        cmd.Parameters.Add("@Level", SqlDbType.NVarChar, 10).Value = entObject.Level;
                        cmd.Parameters.Add("@FolderName", SqlDbType.NVarChar, 100).Value = entObject.FolderName;
                        cmd.Parameters.Add("@flgActive", SqlDbType.Bit).Value = entObject.IsActive;
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
        public DataTable DeleteDocumentCategory(Classification objDocCat)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection con = new SqlConnection(QMSConstants.DBCon))
                {
                    using (SqlCommand cmd = new SqlCommand(QMSConstants.spDeleteDocumentCategory, con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@CategoryID", SqlDbType.UniqueIdentifier).Value = objDocCat.ID;
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
        public DataTable GetDepartments()
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection con = new SqlConnection(QMSConstants.DBCon))
                {
                    using (SqlCommand cmd = new SqlCommand(QMSConstants.spGetDepartments, con))
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
        public DataTable GetActiveLocations()
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection con = new SqlConnection(QMSConstants.DBCon))
                {
                    using (SqlCommand cmd = new SqlCommand(QMSConstants.spGetActiveLocations, con))
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
        public DataTable GetSectionsForDept(Guid strDepartment)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection con = new SqlConnection(QMSConstants.DBCon))
                {
                    using (SqlCommand cmd = new SqlCommand(QMSConstants.spGetSectionsForDept, con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@DepartmentID", SqlDbType.UniqueIdentifier, 100).Value = strDepartment;
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
        public DataTable GetProjectTypes()
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection con = new SqlConnection(QMSConstants.DBCon))
                {
                    using (SqlCommand cmd = new SqlCommand(QMSConstants.spGetProjectTypes, con))
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
        public DataTable GetProjects()
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection con = new SqlConnection(QMSConstants.DBCon))
                {
                    using (SqlCommand cmd = new SqlCommand(QMSConstants.spGetProjects, con))
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
        public DataTable GetDocumentCategories()
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection con = new SqlConnection(QMSConstants.DBCon))
                {
                    using (SqlCommand cmd = new SqlCommand(QMSConstants.spGetDocumentCategories, con))
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
        public DataTable GetTemplateDocuments()
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection con = new SqlConnection(QMSConstants.DBCon))
                {
                    using (SqlCommand cmd = new SqlCommand(QMSConstants.spGetTemplateDocument, con))
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
        public DataTable GetAllExternalDocuments()
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection con = new SqlConnection(QMSConstants.DBCon))
                {
                    using (SqlCommand cmd = new SqlCommand(QMSConstants.spGetAllExternalDocuments, con))
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
        public DataTable AddExternalDocument(ExternalDocument obj)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection con = new SqlConnection(QMSConstants.DBCon))
                {
                    using (SqlCommand cmd = new SqlCommand(QMSConstants.spInsertExternalDocument, con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@Title", SqlDbType.NVarChar, 250).Value = obj.Title;
                        cmd.Parameters.Add("@DocumentNo", SqlDbType.NVarChar, 250).Value = obj.DocumentNo;
                        cmd.Parameters.Add("@Version", SqlDbType.Int).Value = obj.Version;
                        cmd.Parameters.Add("@VersionDate", SqlDbType.DateTime).Value = obj.VersionDate;
                        cmd.Parameters.Add("@Organization", SqlDbType.NVarChar, 250).Value = obj.Organization;
                        cmd.Parameters.Add("@ResponsibleUserID", SqlDbType.UniqueIdentifier).Value = obj.ResponsibleUserID;
                        cmd.Parameters.Add("@Department", SqlDbType.NVarChar, 100).Value = obj.Department;
                        cmd.Parameters.Add("@FileName", SqlDbType.NVarChar, 100).Value = obj.FileName;
                        cmd.Parameters.Add("@FileURL", SqlDbType.NVarChar, 1000).Value = obj.FileURL;
                        cmd.Parameters.Add("@IsActive", SqlDbType.Bit).Value = obj.Active;
                        cmd.Parameters.Add("@CreatedBy", SqlDbType.UniqueIdentifier).Value = obj.CreatedBy;
                        cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = DateTime.Now;
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
        public DataTable UpdateExternalDocument(ExternalDocument obj)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection con = new SqlConnection(QMSConstants.DBCon))
                {
                    using (SqlCommand cmd = new SqlCommand(QMSConstants.spUpdateExternalDocument, con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@ID", SqlDbType.UniqueIdentifier).Value = obj.ID;
                        cmd.Parameters.Add("@Title", SqlDbType.NVarChar, 250).Value = obj.Title;
                        cmd.Parameters.Add("@DocumentNo", SqlDbType.NVarChar, 250).Value = obj.DocumentNo;
                        cmd.Parameters.Add("@Version", SqlDbType.Int).Value = obj.Version;
                        cmd.Parameters.Add("@VersionDate", SqlDbType.DateTime).Value = obj.VersionDate;
                        cmd.Parameters.Add("@Organization", SqlDbType.NVarChar, 250).Value = obj.Organization;
                        cmd.Parameters.Add("@ResponsibleUserID", SqlDbType.UniqueIdentifier).Value = obj.ResponsibleUserID;
                        cmd.Parameters.Add("@Department", SqlDbType.NVarChar, 100).Value = obj.Department;
                        cmd.Parameters.Add("@FileName", SqlDbType.NVarChar, 100).Value = obj.FileName;
                        cmd.Parameters.Add("@FileURL", SqlDbType.NVarChar, 1000).Value = obj.FileURL;
                        cmd.Parameters.Add("@IsActive", SqlDbType.Bit).Value = obj.Active;
                        cmd.Parameters.Add("@ModifiedBy", SqlDbType.UniqueIdentifier).Value = obj.CreatedBy;
                        cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = DateTime.Now;
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
        public DataTable DeleteExternalDocument(Guid extDocID)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection con = new SqlConnection(QMSConstants.DBCon))
                {
                    using (SqlCommand cmd = new SqlCommand(QMSConstants.spDeleteExternalDocument, con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@ID", SqlDbType.UniqueIdentifier).Value = extDocID;
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
        public DataTable DeleteTemplate(Guid extDocID)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection con = new SqlConnection(QMSConstants.DBCon))
                {
                    using (SqlCommand cmd = new SqlCommand(QMSConstants.spDeleteTemplate, con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@ID", SqlDbType.UniqueIdentifier).Value = extDocID;
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
        public DataTable UpdateTemplate(Guid extDocID, string name, string fileName, string filePath,
            string level, string modifiedBy)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection con = new SqlConnection(QMSConstants.DBCon))
                {
                    using (SqlCommand cmd = new SqlCommand(QMSConstants.spUpdateTemplate, con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@ID", SqlDbType.UniqueIdentifier).Value = extDocID;
                        cmd.Parameters.Add("@txtName", SqlDbType.NVarChar, 100).Value = name;
                        cmd.Parameters.Add("@txtFileName", SqlDbType.NVarChar, 100).Value = fileName;
                        cmd.Parameters.Add("@txtFilePath", SqlDbType.NVarChar, 500).Value = filePath;
                        cmd.Parameters.Add("@txtLevel", SqlDbType.NVarChar, 50).Value = level;
                        cmd.Parameters.Add("@LastModifiedID", SqlDbType.UniqueIdentifier).Value = new Guid(modifiedBy);
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
        public DataTable GetExternalDocumentForID(Guid extDocID)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection con = new SqlConnection(QMSConstants.DBCon))
                {
                    using (SqlCommand cmd = new SqlCommand(QMSConstants.spGetExternalDocumentDetailsForID, con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@ID", SqlDbType.UniqueIdentifier).Value = extDocID;
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
        public DataTable GetPublishedDocuments(string DepartmentCode, string SectionCode, string ProjectCode, string DocumentCategoryCode, string DocumentDescription, Guid UserID)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection con = new SqlConnection(QMSConstants.DBCon))
                {
                    using (SqlCommand cmd = new SqlCommand(QMSConstants.spGetPublishedDocuments, con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@DepartmentCode", SqlDbType.NVarChar, 10).Value = DepartmentCode;
                        cmd.Parameters.Add("@SectionCode", SqlDbType.NVarChar, 10).Value = SectionCode;
                        cmd.Parameters.Add("@ProjectCode", SqlDbType.NVarChar, 10).Value = ProjectCode;
                        cmd.Parameters.Add("@DocumentCategoryCode", SqlDbType.NVarChar, 10).Value = DocumentCategoryCode;
                        cmd.Parameters.Add("@DocumentDescription", SqlDbType.NVarChar, 500).Value = DocumentDescription;
                        cmd.Parameters.Add("@UserID", SqlDbType.UniqueIdentifier).Value = UserID;
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
        public DataTable GetDraftDocuments(string DepartmentCode, string SectionCode, string ProjectCode, string DocumentCategoryCode, string DocumentDescription, Guid UserID)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection con = new SqlConnection(QMSConstants.DBCon))
                {
                    using (SqlCommand cmd = new SqlCommand(QMSConstants.spGetDraftDocuments, con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@DepartmentCode", SqlDbType.NVarChar, 10).Value = DepartmentCode;
                        cmd.Parameters.Add("@SectionCode", SqlDbType.NVarChar, 10).Value = SectionCode;
                        cmd.Parameters.Add("@ProjectCode", SqlDbType.NVarChar, 10).Value = ProjectCode;
                        cmd.Parameters.Add("@DocumentCategoryCode", SqlDbType.NVarChar, 10).Value = DocumentCategoryCode;
                        cmd.Parameters.Add("@DocumentDescription", SqlDbType.NVarChar, 500).Value = DocumentDescription;
                        cmd.Parameters.Add("@UserID", SqlDbType.UniqueIdentifier).Value = UserID;
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
        public DataTable GetUserDetails(string LoginId)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection con = new SqlConnection(QMSConstants.DBCon))
                {
                    using (SqlCommand cmd = new SqlCommand(QMSConstants.spGetUserDetails, con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@LoginID", SqlDbType.NVarChar, 100).Value = LoginId;
                   
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
        public LoginUser GetUserDetails(Guid UserID)
        {
            LoginUser objUser = new LoginUser();
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection con = new SqlConnection(QMSConstants.DBCon))
                {
                    using (SqlCommand cmd = new SqlCommand(QMSConstants.spGetUserDetailsByID, con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@UserID", SqlDbType.UniqueIdentifier).Value = UserID;

                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                        {
                            sda.Fill(dt);
                            string json = dt.Rows[0][0].ToString();
                            objUser = (LoginUser)CommonMethods.GetUserObject(json);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                LoggerBlock.WriteTraceLog(ex);
            }
            return objUser;
        }
        public List<User> GetProjectUsers(Guid ProjectTypeID, Guid ProjectID)
        {
            List<User> objUsers = null;
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection con = new SqlConnection(QMSConstants.DBCon))
                {
                    using (SqlCommand cmd = new SqlCommand(QMSConstants.spGetProjectUsers, con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@ProjectTypeID", SqlDbType.UniqueIdentifier).Value = ProjectTypeID;
                        cmd.Parameters.Add("@ProjectID", SqlDbType.UniqueIdentifier).Value = ProjectID;
                 
                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                        {
                            sda.Fill(dt);

                            objUsers = BindModels.ConvertDataTable<User>(dt);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                LoggerBlock.WriteTraceLog(ex);
            }
            return objUsers;
        }
        public string AddUserToProject(Guid ProjectTypeID, Guid ProjectID, string UserName, string AdminIDs)
        {
            string strReturn = string.Empty;
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection con = new SqlConnection(QMSConstants.DBCon))
                {
                    using (SqlCommand cmd = new SqlCommand(QMSConstants.spAddUserToProject, con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@ProjectTypeID", SqlDbType.UniqueIdentifier).Value = ProjectTypeID;
                        cmd.Parameters.Add("@ProjectID", SqlDbType.UniqueIdentifier).Value = ProjectID;
                        cmd.Parameters.Add("@Users", SqlDbType.NVarChar, int.MaxValue).Value = UserName;
                        cmd.Parameters.Add("@AdminIDs", SqlDbType.NVarChar, int.MaxValue).Value = AdminIDs;

                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                        {
                            sda.Fill(dt);
                            strReturn = dt.Rows[0][0].ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                LoggerBlock.WriteTraceLog(ex);
            }
            return strReturn;
        }
        public string DeleteUserFromProject(Guid ProjectTypeID, Guid ProjectID, Guid UserID)
        {
            DataTable dt = new DataTable();
            string strReturn = string.Empty;
            try
            {
                using (SqlConnection con = new SqlConnection(QMSConstants.DBCon))
                {
                    using (SqlCommand cmd = new SqlCommand(QMSConstants.spDeleteUserFromProject, con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@ProjectTypeID", SqlDbType.UniqueIdentifier).Value = ProjectTypeID;
                        cmd.Parameters.Add("@ProjectID", SqlDbType.UniqueIdentifier).Value = ProjectID;
                        cmd.Parameters.Add("@UserID", SqlDbType.UniqueIdentifier).Value = UserID;
               
                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                        {
                            sda.Fill(dt);
                            strReturn = dt.Rows[0][0].ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                LoggerBlock.WriteTraceLog(ex);
            }
            return strReturn; ;
        }
        public List<User> SearchProjectUsers(Guid ProjectTypeID, Guid ProjectID, string UserName, bool IsInclude)
        {
            List<User> objUsers = null;
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection con = new SqlConnection(QMSConstants.DBCon))
                {
                    using (SqlCommand cmd = new SqlCommand(QMSConstants.spSearchProjectUsers, con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@ProjectTypeID", SqlDbType.UniqueIdentifier).Value = ProjectTypeID;
                        cmd.Parameters.Add("@ProjectID", SqlDbType.UniqueIdentifier).Value = ProjectID;
                        cmd.Parameters.Add("@UserName", SqlDbType.NVarChar, 100).Value = UserName;
                        cmd.Parameters.Add("@IsInclude", SqlDbType.Bit).Value = IsInclude;

                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                        {
                            sda.Fill(dt);

                            objUsers = BindModels.ConvertDataTable<User>(dt);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                LoggerBlock.WriteTraceLog(ex);
            }
            return objUsers;
        }
        public List<User> SearchUser(string UserName)
        {
            List<User> objUsers = null;
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection con = new SqlConnection(QMSConstants.DBCon))
                {
                    using (SqlCommand cmd = new SqlCommand(QMSConstants.spSearchUsers, con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@UserName", SqlDbType.NVarChar, 100).Value = UserName;

                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                        {
                            sda.Fill(dt);

                            objUsers = BindModels.ConvertDataTable<User>(dt);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                LoggerBlock.WriteTraceLog(ex);
            }
            return objUsers;
        }
        public string GetConfigValue(string strParamKey)
        {
            string strValue = string.Empty;
            try
            {
                using (SqlConnection con = new SqlConnection(QMSConstants.DBCon))
                {
                    using (SqlCommand cmd = new SqlCommand(QMSConstants.spGetConfigValue, con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@ParamKey", SqlDbType.NVarChar, 100).Value = strParamKey;

                        var ParamValue = cmd.Parameters.Add("@ParamValue", SqlDbType.NVarChar, -1);
                        ParamValue.Direction = ParameterDirection.Output;
                        con.Open();
                        cmd.ExecuteNonQuery();
                        strValue = (string)ParamValue.Value;
                        con.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                LoggerBlock.WriteTraceLog(ex);
            }
            return strValue;
        }

        //For Users Master -- START
        public List<User> GetUsers()
        {
            List<User> objUsers = null;
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection con = new SqlConnection(QMSConstants.DBCon))
                {
                    using (SqlCommand cmd = new SqlCommand(QMSConstants.spGetUsers, con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                        {
                            sda.Fill(dt);

                            objUsers = BindModels.ConvertDataTable<User>(dt);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                LoggerBlock.WriteTraceLog(ex);
            }
            return objUsers;
        }
        public List<User> GetUserData(Guid UserID)
        {
            List<User> objUsers = null;
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection con = new SqlConnection(QMSConstants.DBCon))
                {
                    using (SqlCommand cmd = new SqlCommand(QMSConstants.spGetUsers, con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@UserID", SqlDbType.UniqueIdentifier).Value = UserID;

                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                        {
                            sda.Fill(dt);

                            objUsers = BindModels.ConvertDataTable<User>(dt);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                LoggerBlock.WriteTraceLog(ex);
            }
            return objUsers;
        }
        public string AddTemplateDocument(string LoginID, string DisplayName, string Email)
        {
            string strReturn = string.Empty;
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection con = new SqlConnection(QMSConstants.DBCon))
                {
                    using (SqlCommand cmd = new SqlCommand(QMSConstants.spAddTemplateDocument, con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@LoginID", SqlDbType.NVarChar, 100).Value = LoginID;
                        cmd.Parameters.Add("@DisplayName", SqlDbType.NVarChar, 100).Value = DisplayName;
                        cmd.Parameters.Add("@Email", SqlDbType.NVarChar, 100).Value = Email;

                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                        {
                            sda.Fill(dt);
                            strReturn = dt.Rows[0][0].ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                LoggerBlock.WriteTraceLog(ex);
            }
            return strReturn;
        }
        public string AddUser(string LoginID, string DisplayName, string Email, bool IsQMSAdmin,Guid CreatedID)
        {
            string strReturn = string.Empty;
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection con = new SqlConnection(QMSConstants.DBCon))
                {
                    using (SqlCommand cmd = new SqlCommand(QMSConstants.spAddUser, con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@LoginID", SqlDbType.NVarChar, 100).Value = LoginID;
                        cmd.Parameters.Add("@DisplayName", SqlDbType.NVarChar, 100).Value = DisplayName;
                        cmd.Parameters.Add("@Email", SqlDbType.NVarChar, 100).Value = Email;
                        cmd.Parameters.Add("@IsQMSAdmin", SqlDbType.Bit).Value = IsQMSAdmin;
                        cmd.Parameters.Add("@CreatedID", SqlDbType.UniqueIdentifier).Value = CreatedID;
                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                        {
                            sda.Fill(dt);
                            strReturn = dt.Rows[0][0].ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                LoggerBlock.WriteTraceLog(ex);
            }
            return strReturn;
        }
        public string DeleteUser(Guid UserID)
        {
            DataTable dt = new DataTable();
            string strReturn = string.Empty;
            try
            {
                using (SqlConnection con = new SqlConnection(QMSConstants.DBCon))
                {
                    using (SqlCommand cmd = new SqlCommand(QMSConstants.spDeleteUser, con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@UserID", SqlDbType.UniqueIdentifier).Value = UserID;

                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                        {
                            sda.Fill(dt);
                            strReturn = dt.Rows[0][0].ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                LoggerBlock.WriteTraceLog(ex);
            }
            return strReturn; ;
        }
        public string UpdateUser(Guid id, string LoginID, string DisplayName, string Email, bool IsQMSAdmin, bool IsActive, Guid CreatedID)
        {
            string strReturn = string.Empty;
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection con = new SqlConnection(QMSConstants.DBCon))
                {
                    using (SqlCommand cmd = new SqlCommand(QMSConstants.spUpdateUser, con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@ID", SqlDbType.UniqueIdentifier).Value = id;
                        cmd.Parameters.Add("@LoginID", SqlDbType.NVarChar, 100).Value = LoginID;
                        cmd.Parameters.Add("@DisplayName", SqlDbType.NVarChar, 100).Value = DisplayName;
                        cmd.Parameters.Add("@EmailID", SqlDbType.NVarChar, 100).Value = Email;
                        cmd.Parameters.Add("@IsQMSAdmin", SqlDbType.Bit).Value = IsQMSAdmin;
                        cmd.Parameters.Add("@Active", SqlDbType.Bit).Value = IsActive;
                        cmd.Parameters.Add("@CreatedID", SqlDbType.UniqueIdentifier).Value = CreatedID;
                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                        {
                            sda.Fill(dt);
                            strReturn = dt.Rows[0][0].ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                LoggerBlock.WriteTraceLog(ex);
            }
            return strReturn;
        }

        //For Users Master -- END

        public DataTable GetAllSections()
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection con = new SqlConnection(QMSConstants.DBCon))
                {
                    using (SqlCommand cmd = new SqlCommand(QMSConstants.spGetAllSections, con))
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
        public DataTable AddSection(Sections entObject)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection con = new SqlConnection(QMSConstants.DBCon))
                {
                    using (SqlCommand cmd = new SqlCommand(QMSConstants.spAddSection, con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@SectionCode", SqlDbType.NVarChar, 10).Value = entObject.Code;
                        cmd.Parameters.Add("@SectionName", SqlDbType.NVarChar, 100).Value = entObject.Title;
                        cmd.Parameters.Add("@DepartmentID", SqlDbType.UniqueIdentifier).Value = entObject.DepartmentID;
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
        public DataTable UpdateSection(Sections entObject)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection con = new SqlConnection(QMSConstants.DBCon))
                {
                    using (SqlCommand cmd = new SqlCommand(QMSConstants.spUpdateSection, con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@SectionID", SqlDbType.UniqueIdentifier).Value = entObject.ID;
                        cmd.Parameters.Add("@SectionName", SqlDbType.NVarChar, 100).Value = entObject.Title;
                        cmd.Parameters.Add("@Active", SqlDbType.Bit).Value = entObject.Active;
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
        public DataTable DeleteSection(Sections entObject)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection con = new SqlConnection(QMSConstants.DBCon))
                {
                    using (SqlCommand cmd = new SqlCommand(QMSConstants.spDeleteSection, con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@SectionID", SqlDbType.UniqueIdentifier).Value = entObject.ID;
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

        public DataTable AddProject(Project entObject)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection con = new SqlConnection(QMSConstants.DBCon))
                {
                    using (SqlCommand cmd = new SqlCommand(QMSConstants.spAddProject, con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@ProjectTypeID", SqlDbType.UniqueIdentifier).Value = entObject.ProjectTypeID;
                        cmd.Parameters.Add("@txtCode", SqlDbType.NVarChar, 10).Value = entObject.Code;
                        cmd.Parameters.Add("@txtName", SqlDbType.NVarChar, 100).Value = entObject.Title;
                        cmd.Parameters.Add("@WorkflowID", SqlDbType.UniqueIdentifier).Value = entObject.WorkflowID;
                        cmd.Parameters.Add("@flgActive", SqlDbType.Bit).Value = entObject.Active;
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
        public DataTable UpdateProject(Project entObject)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection con = new SqlConnection(QMSConstants.DBCon))
                {
                    using (SqlCommand cmd = new SqlCommand(QMSConstants.spUpdateProject, con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@ProjectID", SqlDbType.UniqueIdentifier).Value = entObject.ID;
                        cmd.Parameters.Add("@txtName", SqlDbType.NVarChar, 100).Value = entObject.Title;
                        cmd.Parameters.Add("@flgActive", SqlDbType.Bit).Value = entObject.Active;
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
    }
}
