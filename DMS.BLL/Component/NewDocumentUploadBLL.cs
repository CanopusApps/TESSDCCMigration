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
    public class NewDocumentUploadBLL
    {
        NewDocumentUploadDAL objDAL = new NewDocumentUploadDAL();
        DocumentOperations docOperObj = new DocumentOperations();
        public List<Plant> GetActivePlants()
        {
            List<Plant> list = new List<Plant>();
            try
            {
                DataTable dt = objDAL.GetActivePlants();
                for (int z = 0; z < dt.Rows.Count; z++)
                {
                    Plant itm = new Plant();
                    itm.ID = new Guid(dt.Rows[z]["ID"].ToString());
                    itm.Code = dt.Rows[z]["Code"].ToString();
                    itm.Name = dt.Rows[z]["Title"].ToString();
                    if (Convert.ToBoolean(dt.Rows[z]["IsActive"].ToString()) == true)
                        itm.IsActive = true;
                    else
                        itm.IsActive = false;
                    list.Add(itm);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return list;
        }
        public object[] GetDropdownsForNewUpload()
        {            
            object[] arryofLists = new object[5];
            try
            {
                DataSet ds = objDAL.GetDropdownsForNewUpload();
                List<Plant> list1 = new List<Plant>();
                List<Function> list2 = new List<Function>();
                List<Certification> list3 = new List<Certification>();
                List<Customer> list4 = new List<Customer>();
                List<Confidence> list5 = new List<Confidence>();

                for (int z = 0; z < ds.Tables.Count; z++)
                {
                    if (z == 0)
                    {
                        foreach(DataRow dr in ds.Tables[z].Rows)
                        {
                            Plant p = new Plant();
                            p.ID = new Guid(dr["ID"].ToString());
                            p.Code = dr["Code"].ToString();
                            p.Name = dr["Name"].ToString();
                            if (dr["IsActive"].ToString().ToLower() == "true")
                                p.IsActive = true;
                            else
                                p.IsActive = false;
                            p.SeqNo = Convert.ToInt32(dr["SeqNo"].ToString());
                            list1.Add(p);
                        }                 
                    }
                    else if (z == 1)
                    {
                        foreach (DataRow dr in ds.Tables[z].Rows)
                        {
                            Function entity = new Function();
                            entity.ID = new Guid(dr["ID"].ToString());
                            entity.Code = dr["Code"].ToString();
                            entity.Name = dr["Name"].ToString();
                            if (dr["IsActive"].ToString().ToLower() == "true")
                                entity.IsActive = true;
                            else
                                entity.IsActive = false;
                            entity.SeqNo = Convert.ToInt32(dr["SeqNo"].ToString());
                            list2.Add(entity);
                        }
                    }
                    else if (z == 2)
                    {
                        foreach (DataRow dr in ds.Tables[z].Rows)
                        {
                            Certification entity = new Certification();
                            entity.ID = new Guid(dr["ID"].ToString());
                            entity.Code = dr["Code"].ToString();
                            entity.Name = dr["Name"].ToString();
                            if (dr["IsActive"].ToString().ToLower() == "true")
                                entity.IsActive = true;
                            else
                                entity.IsActive = false;
                            entity.SeqNo = Convert.ToInt32(dr["SeqNo"].ToString());
                            list3.Add(entity);
                        }
                    }
                    else if (z == 3)
                    {
                        foreach (DataRow dr in ds.Tables[z].Rows)
                        {
                            Customer entity = new Customer();
                            entity.ID = new Guid(dr["ID"].ToString());
                            entity.Code = dr["Code"].ToString();
                            entity.Name = dr["Name"].ToString();
                            if (dr["IsActive"].ToString().ToLower() == "true")
                                entity.IsActive = true;
                            else
                                entity.IsActive = false;
                            entity.SeqNo = Convert.ToInt32(dr["SeqNo"].ToString());
                            list4.Add(entity);
                        }
                    }
                    else if (z == 4)
                    {
                        foreach (DataRow dr in ds.Tables[z].Rows)
                        {
                            Confidence entity = new Confidence();
                            entity.ID = new Guid(dr["ID"].ToString());
                            entity.Code = dr["Code"].ToString();
                            entity.Name = dr["Name"].ToString();
                            if (dr["IsActive"].ToString().ToLower() == "true")
                                entity.IsActive = true;
                            else
                                entity.IsActive = false;
                            entity.SeqNo = Convert.ToInt32(dr["SeqNo"].ToString());
                            list5.Add(entity);
                        }
                    }
                }

                arryofLists[0] = list1;
                arryofLists[1] = list2;
                arryofLists[2] = list3;
                arryofLists[3] = list4;
                arryofLists[4] = list5;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return arryofLists;
        }
        public List<Classification> GetClassificationForPlant(Guid parentID)
        {
            List<Classification> list = new List<Classification>();
            try
            {
                DataTable dt = objDAL.GetClassificationForPlant(parentID);
                for (int z = 0; z < dt.Rows.Count; z++)
                {
                    Classification itm = new Classification();
                    itm.ID = new Guid(dt.Rows[z]["ID"].ToString());
                    itm.Code = dt.Rows[z]["Code"].ToString();
                    itm.Name = dt.Rows[z]["Name"].ToString();
                    itm.Level = dt.Rows[z]["Level"].ToString();
                    itm.FolderName = dt.Rows[z]["FolderName"].ToString();
                    if (Convert.ToBoolean(dt.Rows[z]["IsActive"].ToString()) == true)
                        itm.IsActive = true;
                    else
                        itm.IsActive = false;
                    list.Add(itm);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return list;
        }
        public List<SmallCategory> GetActiveSmallCategories(Guid parentID)
        {
            List<SmallCategory> list = new List<SmallCategory>();
            try
            {
                DataTable dt = objDAL.GetActiveSmallCategories(parentID);
                for (int z = 0; z < dt.Rows.Count; z++)
                {
                    SmallCategory itm = new SmallCategory();
                    itm.ID = new Guid(dt.Rows[z]["ID"].ToString());
                    itm.Code = dt.Rows[z]["Code"].ToString();
                    itm.Name = dt.Rows[z]["Name"].ToString();
                    itm.ClassificationID = new Guid(dt.Rows[z]["ClassificationID"].ToString());
                    itm.FolderName = dt.Rows[z]["FolderName"].ToString();
                    if (Convert.ToBoolean(dt.Rows[z]["IsActive"].ToString()) == true)
                        itm.IsActive = true;
                    else
                        itm.IsActive = false;
                    list.Add(itm);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return list;
        }
        public object[] GetModelPartsForSmallCat(Guid parentID)
        {
            object[] arryofLists = new object[2];
            try
            {
                DataSet ds = objDAL.GetModelPartsForSmallCat(parentID);
                List<Model> list1 = new List<Model>();
                List<Part> list2 = new List<Part>();

                for (int z = 0; z < ds.Tables.Count; z++)
                {
                    if (z == 0)
                    {
                        foreach (DataRow dr in ds.Tables[z].Rows)
                        {
                            Model p = new Model();
                            p.ID = new Guid(dr["ID"].ToString());
                            p.Code = dr["Code"].ToString();
                            p.Name = dr["Name"].ToString();
                            if (dr["IsActive"].ToString().ToLower() == "true")
                                p.IsActive = true;
                            else
                                p.IsActive = false;
                            p.SeqNo = Convert.ToInt32(dr["SeqNo"].ToString());
                            list1.Add(p);
                        }
                    }
                    else if (z == 1)
                    {
                        foreach (DataRow dr in ds.Tables[z].Rows)
                        {
                            Part entity = new Part();
                            entity.ID = new Guid(dr["ID"].ToString());
                            entity.Code = dr["Code"].ToString();
                            entity.Name = dr["Name"].ToString();
                            if (dr["IsActive"].ToString().ToLower() == "true")
                                entity.IsActive = true;
                            else
                                entity.IsActive = false;
                            entity.SeqNo = Convert.ToInt32(dr["SeqNo"].ToString());
                            list2.Add(entity);
                        }
                    }
                }

                arryofLists[0] = list1;
                arryofLists[1] = list2;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return arryofLists;
        }

        public string AddNewDocument(DraftDocument objDoc)
        {
            string result = string.Empty;
            try
            {
                WorkflowActions objWF = new WorkflowActions();
                DocumentResponse objRes = new DocumentResponse();
                docOperObj.UploadDocument(QMSConstants.StoragePath, objDoc.DocumentPath, objDoc.DocumentName, objDoc.Version, objDoc.ByteArray);
                //docOperObj.UploadDocument(QMSConstants.StoragePath, QMSConstants.DraftFolder, objDoc.ReadableFilePath, objDoc.ReadableDocumentName, objDoc.DraftVersion, objDoc.ReadableByteArray);
                result = objDAL.AddNewDocument(objDoc);
                //Stage objSt = objWF.GetWorkflowStage(QMSConstants.WorkflowID, objDoc.CurrentStageID);
                //if (objSt.IsDocumentLevelRequired)
                //    objDoc.DocumentLevel = GetDocumentLevel(objDoc.DocumentCategoryCode);
                //else
                //    objDoc.DocumentLevel = "";
                //DocumentApprover objApprover = GetDocumentApprover(objDoc.ProjectTypeID, objDoc.ProjectID, objSt.NextStageID, objDoc.DocumentLevel, objDoc.SectionID);
                //objWF.ExecuteAction(objDoc.WFExecutionID, objDoc.CurrentStageID, objDoc.UploadedUserID, objDoc.Action, objDoc.Comments, objDoc.UploadedUserID);
                //objWF.CreateAction(objDoc.WFExecutionID, objSt.NextStageID, objApprover.ApprovalUser, "", objDoc.UploadedUserID);
                //bool blAppLink = objDoc.ProjectTypeCode == "MP" ? true : false;
                ////Send email - Doc Name, Doc Num, DOc ID, receipt email, stage, uploaded by ,
                //string message = objDoc.UploadedUserName + " has uploaded a document having Document Number - <b>" + objDoc.DocumentNo + "</b>, and it is waiting for your review. Please check and take an appropriate action as applicable.";
                //PrepareandSendMail(objApprover.ApprovalUserEmail, objDoc, objDoc.DocumentNo + " - QMS Reviewer - Document ready for Review", message, "ApproveRequest", blAppLink);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }
    }
}
