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
    public class AdminOperationsBLL
    {
        AdminOperationsDAL objDAL = new AdminOperationsDAL();

        #region PlantMaster
        public string AddPlant(Plant objPlant)
        {
            string strReturn = string.Empty;
            try
            {
                strReturn = objDAL.AddPlant(objPlant);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return strReturn;
        }
        public string UpdatePlant(Plant objPlant)
        {
            string strReturn = string.Empty;
            try
            {
                strReturn = objDAL.UpdatePlant(objPlant);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return strReturn;
        }
        public string DeletePlant(Guid ID)
        {
            string strReturn = string.Empty;
            try
            {
                DataTable dt = objDAL.DeletePlant(ID);
                if (dt.Rows.Count > 0)
                    strReturn = dt.Rows[0][0].ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return strReturn;
        }


        public List<Plant> GetAllPlants()
        {
            List<Plant> list = new List<Plant>();
            try
            {
                DataTable dt = objDAL.GetAllPlants();
                for (int z = 0; z < dt.Rows.Count; z++)
                {
                    Plant itm = new Plant();
                    itm.ID = new Guid(dt.Rows[z]["ID"].ToString());
                    itm.Code = dt.Rows[z]["Code"].ToString();
                    itm.Name = dt.Rows[z]["Name"].ToString();
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
        public Plant GetPlantDetailsForID(Guid id)
        {
            Plant itm = new Plant();
            try
            {
                DataTable dt = objDAL.GetPlantDetailsForID(id);
                for (int z = 0; z < dt.Rows.Count; z++)
                {
                    itm.ID = new Guid(dt.Rows[z]["ID"].ToString());
                    itm.Code = dt.Rows[z]["Code"].ToString();
                    itm.Name = dt.Rows[z]["Name"].ToString();
                    if (dt.Rows[z]["IsActive"].ToString().ToLower() == "true")
                        itm.IsActive = true;
                    else
                        itm.IsActive = false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return itm;
        }
        #endregion

        #region PartMaster
        public string AddPart(Part objPart)
        {
            string strReturn = string.Empty;
            try
            {
                strReturn = objDAL.AddPart(objPart);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return strReturn;
        }
        public string UpdatePart(Part objPart)
        {
            string strReturn = string.Empty;
            try
            {
                strReturn = objDAL.UpdatePart(objPart);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return strReturn;
        }
        public string DeletePart(Guid ID)
        {
            string strReturn = string.Empty;
            try
            {
                DataTable dt = objDAL.DeletePart(ID);
                if (dt.Rows.Count > 0)
                    strReturn = dt.Rows[0][0].ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return strReturn;
        }
        public List<Part> GetAllParts()
        {
            List<Part> list = new List<Part>();
            try
            {
                DataTable dt = objDAL.GetAllParts();
                for (int z = 0; z < dt.Rows.Count; z++)
                {
                    Part itm = new Part();
                    itm.ID = new Guid(dt.Rows[z]["ID"].ToString());
                    itm.Code = dt.Rows[z]["Code"].ToString();
                    itm.Name = dt.Rows[z]["Name"].ToString();
                    itm.SmallCategoryName = dt.Rows[z]["SmallCategoryName"].ToString();
                    itm.SmallCategoryID = new Guid(dt.Rows[z]["SmallCategoryID"].ToString());
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
        public Part GetPartDetailsForID(Guid id)
        {
            Part itm = new Part();
            try
            {
                DataTable dt = objDAL.GetPartDetailsForID(id);
                for (int z = 0; z < dt.Rows.Count; z++)
                {
                    itm.ID = new Guid(dt.Rows[z]["ID"].ToString());
                    itm.Code = dt.Rows[z]["Code"].ToString();
                    itm.Name = dt.Rows[z]["Name"].ToString();
                    if (dt.Rows[z]["IsActive"].ToString().ToLower() == "true")
                        itm.IsActive = true;
                    else
                        itm.IsActive = false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return itm;
        }


        public List<SmallCategory> GetSmallCategorys()
        {
            List<SmallCategory> list = new List<SmallCategory>();
            try
            {
                DataTable dt = objDAL.GetSmallCategorys();
                for (int z = 0; z < dt.Rows.Count; z++)
                {
                    SmallCategory itm = new SmallCategory();
                    itm.ID = new Guid(dt.Rows[z]["ID"].ToString());
                    itm.Code = dt.Rows[z]["Code"].ToString();
                    itm.Name = dt.Rows[z]["Name"].ToString();
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



        #endregion

        #region CertificationMaster
        public string AddCertification(Certification objCertification)
        {
            string strReturn = string.Empty;
            try
            {
                strReturn = objDAL.AddCertification(objCertification);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return strReturn;
        }
        public string UpdateCertification(Certification objCertification)
        {
            string strReturn = string.Empty;
            try
            {
                strReturn = objDAL.UpdateCertification(objCertification);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return strReturn;
        }
        public string DeleteCertification(Guid ID)
        {
            string strReturn = string.Empty;
            try
            {
                DataTable dt = objDAL.DeleteCertification(ID);
                if (dt.Rows.Count > 0)
                    strReturn = dt.Rows[0][0].ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return strReturn;
        }
        public Certification GetCertificationDetailsForID(Guid id)
        {
            Certification itm = new Certification();
            try
            {
                DataTable dt = objDAL.GetCertificationDetailsForID(id);
                for (int z = 0; z < dt.Rows.Count; z++)
                {
                    itm.ID = new Guid(dt.Rows[z]["ID"].ToString());
                    itm.Code = dt.Rows[z]["Code"].ToString();
                    itm.Name = dt.Rows[z]["Name"].ToString();
                    if (dt.Rows[z]["IsActive"].ToString().ToLower() == "true")
                        itm.IsActive = true;
                    else
                        itm.IsActive = false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return itm;
        }
        public List<Certification> GetAllCertifications()
        {
            List<Certification> list = new List<Certification>();
            try
            {
                DataTable dt = objDAL.GetAllCertifications();
                for (int z = 0; z < dt.Rows.Count; z++)
                {
                    Certification itm = new Certification();
                    itm.ID = new Guid(dt.Rows[z]["ID"].ToString());
                    itm.Code = dt.Rows[z]["Code"].ToString();
                    itm.Name = dt.Rows[z]["Name"].ToString();
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
        #endregion

        #region ConfidenceMaster
        public string AddConfidence(Confidence objConfidence)
        {
            string strReturn = string.Empty;
            try
            {
                strReturn = objDAL.AddConfidence(objConfidence);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return strReturn;
        }
        public string UpdateConfidence(Confidence objConfidence)
        {
            string strReturn = string.Empty;
            try
            {
                strReturn = objDAL.UpdateConfidence(objConfidence);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return strReturn;
        }
        public string DeleteConfidence(Guid ID)
        {
            string strReturn = string.Empty;
            try
            {
                DataTable dt = objDAL.DeleteConfidence(ID);
                if (dt.Rows.Count > 0)
                    strReturn = dt.Rows[0][0].ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return strReturn;
        }


        public List<Confidence> GetAllConfidences()
        {
            List<Confidence> list = new List<Confidence>();
            try
            {
                DataTable dt = objDAL.GetAllConfidences();
                for (int z = 0; z < dt.Rows.Count; z++)
                {
                    Confidence itm = new Confidence();
                    itm.ID = new Guid(dt.Rows[z]["ID"].ToString());
                    itm.Code = dt.Rows[z]["Code"].ToString();
                    itm.Name = dt.Rows[z]["Name"].ToString();
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
        public Confidence GetConfidenceDetailsForID(Guid id)
        {
            Confidence itm = new Confidence();
            try
            {
                DataTable dt = objDAL.GetConfidenceDetailsForID(id);
                for (int z = 0; z < dt.Rows.Count; z++)
                {
                    itm.ID = new Guid(dt.Rows[z]["ID"].ToString());
                    itm.Code = dt.Rows[z]["Code"].ToString();
                    itm.Name = dt.Rows[z]["Name"].ToString();
                    if (dt.Rows[z]["IsActive"].ToString().ToLower() == "true")
                        itm.IsActive = true;
                    else
                        itm.IsActive = false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return itm;
        }
        #endregion

        #region FunctionMaster
        public string AddFunction(Function objFunction)
        {
            string strReturn = string.Empty;
            try
            {
                strReturn = objDAL.AddFunction(objFunction);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return strReturn;
        }
        public string UpdateFunction(Function objFunction)
        {
            string strReturn = string.Empty;
            try
            {
                strReturn = objDAL.UpdateFunction(objFunction);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return strReturn;
        }
        public string DeleteFunction(Guid ID)
        {
            string strReturn = string.Empty;
            try
            {
                DataTable dt = objDAL.DeleteFunction(ID);
                if (dt.Rows.Count > 0)
                    strReturn = dt.Rows[0][0].ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return strReturn;
        }


        public List<Function> GetAllFunctions()
        {
            List<Function> list = new List<Function>();
            try
            {
                DataTable dt = objDAL.GetAllFunctions();
                for (int z = 0; z < dt.Rows.Count; z++)
                {
                    Function itm = new Function();
                    itm.ID = new Guid(dt.Rows[z]["ID"].ToString());
                    itm.Code = dt.Rows[z]["Code"].ToString();
                    itm.Name = dt.Rows[z]["Name"].ToString();
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
        public Function GetFunctionDetailsForID(Guid id)
        {
            Function itm = new Function();
            try
            {
                DataTable dt = objDAL.GetFunctionDetailsForID(id);
                for (int z = 0; z < dt.Rows.Count; z++)
                {
                    itm.ID = new Guid(dt.Rows[z]["ID"].ToString());
                    itm.Code = dt.Rows[z]["Code"].ToString();
                    itm.Name = dt.Rows[z]["Name"].ToString();
                    if (dt.Rows[z]["IsActive"].ToString().ToLower() == "true")
                        itm.IsActive = true;
                    else
                        itm.IsActive = false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return itm;
        }
        #endregion

        #region CustomerMaster
        public string AddCustomer(Customer objCustomer)
        {
            string strReturn = string.Empty;
            try
            {
                strReturn = objDAL.AddCustomer(objCustomer);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return strReturn;
        }
        public string UpdateCustomer(Customer objCustomer)
        {
            string strReturn = string.Empty;
            try
            {
                strReturn = objDAL.UpdateCustomer(objCustomer);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return strReturn;
        }
        public string DeleteCustomer(Guid ID)
        {
            string strReturn = string.Empty;
            try
            {
                DataTable dt = objDAL.DeleteCustomer(ID);
                if (dt.Rows.Count > 0)
                    strReturn = dt.Rows[0][0].ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return strReturn;
        }


        public List<Customer> GetAllCustomers()
        {
            List<Customer> list = new List<Customer>();
            try
            {
                DataTable dt = objDAL.GetAllCustomers();
                for (int z = 0; z < dt.Rows.Count; z++)
                {
                    Customer itm = new Customer();
                    itm.ID = new Guid(dt.Rows[z]["ID"].ToString());
                    itm.Code = dt.Rows[z]["Code"].ToString();
                    itm.Name = dt.Rows[z]["Name"].ToString();
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
        public Customer GetCustomerDetailsForID(Guid id)
        {
            Customer itm = new Customer();
            try
            {
                DataTable dt = objDAL.GetCustomerDetailsForID(id);
                for (int z = 0; z < dt.Rows.Count; z++)
                {
                    itm.ID = new Guid(dt.Rows[z]["ID"].ToString());
                    itm.Code = dt.Rows[z]["Code"].ToString();
                    itm.Name = dt.Rows[z]["Name"].ToString();
                    if (dt.Rows[z]["IsActive"].ToString().ToLower() == "true")
                        itm.IsActive = true;
                    else
                        itm.IsActive = false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return itm;
        }
        #endregion

        #region ModelMaster
        public string AddModel(Model objModel)
        {
            string strReturn = string.Empty;
            try
            {
                strReturn = objDAL.AddModel(objModel);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return strReturn;
        }
        public string UpdateModel(Model objModel)
        {
            string strReturn = string.Empty;
            try
            {
                strReturn = objDAL.UpdateModel(objModel);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return strReturn;
        }
        public string DeleteModel(Guid ID)
        {
            string strReturn = string.Empty;
            try
            {
                DataTable dt = objDAL.DeleteModel(ID);
                if (dt.Rows.Count > 0)
                    strReturn = dt.Rows[0][0].ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return strReturn;
        }


        public List<Model> GetAllModels()
        {
            List<Model> list = new List<Model>();
            try
            {
                DataTable dt = objDAL.GetAllModels();
                for (int z = 0; z < dt.Rows.Count; z++)
                {
                    Model itm = new Model();
                    itm.ID = new Guid(dt.Rows[z]["ID"].ToString());
                    itm.Code = dt.Rows[z]["Code"].ToString();
                    itm.Name = dt.Rows[z]["Name"].ToString();
                    itm.SmallcategoryName = dt.Rows[z]["SmallCategoryName"].ToString();
                    itm.SmallCategoryID = new Guid(dt.Rows[z]["SmallCategoryID"].ToString());
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
        public Model GetModelDetailsForID(Guid id)
        {
            Model itm = new Model();
            try
            {
                DataTable dt = objDAL.GetModelDetailsForID(id);
                for (int z = 0; z < dt.Rows.Count; z++)
                {
                    itm.ID = new Guid(dt.Rows[z]["ID"].ToString());
                    itm.Code = dt.Rows[z]["Code"].ToString();
                    itm.Name = dt.Rows[z]["Name"].ToString();
                    if (dt.Rows[z]["IsActive"].ToString().ToLower() == "true")
                        itm.IsActive = true;
                    else
                        itm.IsActive = false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return itm;
        }
        public List<SmallCategory> GetSmallCategories()
        {
            List<SmallCategory> list = new List<SmallCategory>();
            try
            {
                DataTable dt = objDAL.GetSmallCategories();
                for (int z = 0; z < dt.Rows.Count; z++)
                {
                    SmallCategory itm = new SmallCategory();
                    itm.ID = new Guid(dt.Rows[z]["ID"].ToString());
                    itm.Code = dt.Rows[z]["Code"].ToString();
                    itm.Name = dt.Rows[z]["Name"].ToString();
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

        #endregion

        #region SmallCategoryMaster
        public string AddSmallCategory(SmallCategory objSmallCategory)
        {
            string strReturn = string.Empty;
            try
            {
                strReturn = objDAL.AddSmallCategory(objSmallCategory);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return strReturn;
        }
        public string UpdateSmallCategory(SmallCategory objSmallCategory)
        {
            string strReturn = string.Empty;
            try
            {
                strReturn = objDAL.UpdateSmallCategory(objSmallCategory);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return strReturn;
        }
        public string DeleteSmallCategory(Guid ID)
        {
            string strReturn = string.Empty;
            try
            {
                DataTable dt = objDAL.DeleteSmallCategory(ID);
                if (dt.Rows.Count > 0)
                    strReturn = dt.Rows[0][0].ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return strReturn;
        }


        public List<SmallCategory> GetAllSmallCategorys()
        {
            List<SmallCategory> list = new List<SmallCategory>();
            try
            {
                DataTable dt = objDAL.GetAllSmallCategorys();
                for (int z = 0; z < dt.Rows.Count; z++)
                {
                    SmallCategory itm = new SmallCategory();
                    itm.ID = new Guid(dt.Rows[z]["ID"].ToString());
                    itm.Code = dt.Rows[z]["Code"].ToString();
                    itm.Name = dt.Rows[z]["Name"].ToString();
                    itm.ClassificationName = dt.Rows[z]["ClassificationName"].ToString();
                    itm.ClassificationID = new Guid(dt.Rows[z]["ClassificationID"].ToString());
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
        public SmallCategory GetAllSmallCategoryDetailsForID(Guid id)
        {
            SmallCategory itm = new SmallCategory();
            try
            {
                DataTable dt = objDAL.GetAllSmallCategoryDetailsForID(id);
                for (int z = 0; z < dt.Rows.Count; z++)
                {
                    itm.ID = new Guid(dt.Rows[z]["ID"].ToString());
                    itm.Code = dt.Rows[z]["Code"].ToString();
                    itm.Name = dt.Rows[z]["Name"].ToString();
                    if (dt.Rows[z]["IsActive"].ToString().ToLower() == "true")
                        itm.IsActive = true;
                    else
                        itm.IsActive = false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return itm;
        }
        public List<Classification> GetClassifications()
        {
            List<Classification> list = new List<Classification>();
            try
            {
                DataTable dt = objDAL.GetClassifications();
                for (int z = 0; z < dt.Rows.Count; z++)
                {
                    Classification itm = new Classification();
                    itm.ID = new Guid(dt.Rows[z]["ID"].ToString());
                    itm.Code = dt.Rows[z]["Code"].ToString();
                    itm.Name = dt.Rows[z]["Name"].ToString();
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

        #endregion

        #region ClassificationMaster
        public string AddClassification(Classification objClassification)
        {
            string strReturn = string.Empty;
            try
            {
                strReturn = objDAL.AddClassification(objClassification);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return strReturn;
        }
        public string UpdateClassification(Classification objClassification)
        {
            string strReturn = string.Empty;
            try
            {
                strReturn = objDAL.UpdateClassification(objClassification);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return strReturn;
        }
        public string DeleteClassification(Guid ID)
        {
            string strReturn = string.Empty;
            try
            {
                DataTable dt = objDAL.DeleteClassification(ID);
                if (dt.Rows.Count > 0)
                    strReturn = dt.Rows[0][0].ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return strReturn;
        }


        public List<Classification> GetAllClassifications()
        {
            List<Classification> list = new List<Classification>();
            try
            {
                DataTable dt = objDAL.GetAllClassifications();
                for (int z = 0; z < dt.Rows.Count; z++)
                {
                    Classification itm = new Classification();
                    itm.ID = new Guid(dt.Rows[z]["ID"].ToString());
                    itm.Code = dt.Rows[z]["Code"].ToString();
                    itm.Name = dt.Rows[z]["Name"].ToString();
                    itm.Level = dt.Rows[z]["Level"].ToString();
                    itm.PlantID = new Guid(dt.Rows[z]["PlantID"].ToString());
                    itm.PlantName = dt.Rows[z]["PlantName"].ToString();
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
        public Classification GetClassificationDetailsForID(Guid id)
        {
            Classification itm = new Classification();
            try
            {
                DataTable dt = objDAL.GetClassificationDetailsForID(id);
                for (int z = 0; z < dt.Rows.Count; z++)
                {
                    itm.ID = new Guid(dt.Rows[z]["ID"].ToString());
                    itm.Code = dt.Rows[z]["Code"].ToString();
                    itm.Name = dt.Rows[z]["Name"].ToString();
                    if (dt.Rows[z]["IsActive"].ToString().ToLower() == "true")
                        itm.IsActive = true;
                    else
                        itm.IsActive = false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return itm;
        }
        public List<Plant> GetPlants()
        {
            List<Plant> list = new List<Plant>();
            try
            {
                DataTable dt = objDAL.GetPlants();
                for (int z = 0; z < dt.Rows.Count; z++)
                {
                    Plant itm = new Plant();
                    itm.ID = new Guid(dt.Rows[z]["ID"].ToString());
                    itm.Code = dt.Rows[z]["Code"].ToString();
                    itm.Name = dt.Rows[z]["Name"].ToString();
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

        #endregion

        #region DepartmentMaster
        public string AddDepartment(Department objDepart)
        {
            string strReturn = string.Empty;
            try
            {
                strReturn = objDAL.AddDepartment(objDepart);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return strReturn;
        }
        public string UpdateDepartment(Department objDepart)
        {
            string strReturn = string.Empty;
            try
            {
                strReturn = objDAL.UpdateDepartment(objDepart);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return strReturn;
        }
        public string DeleteDepartment(Guid ID)
        {
            string strReturn = string.Empty;
            try
            {
                DataTable dt = objDAL.DeleteDepartment(ID);
                if (dt.Rows.Count > 0)
                    strReturn = dt.Rows[0][0].ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return strReturn;
        }


        public List<Department> GetAllDepartments()
        {
            List<Department> list = new List<Department>();
            try
            {
                DataTable dt = objDAL.GetAllDepartments();
                for (int z = 0; z < dt.Rows.Count; z++)
                {
                    Department itm = new Department();
                    itm.ID = new Guid(dt.Rows[z]["ID"].ToString());
                    itm.Code = dt.Rows[z]["Code"].ToString();
                    itm.Name = dt.Rows[z]["Name"].ToString();
                    itm.ShortName = dt.Rows[z]["ShortName"].ToString();
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
        #endregion
    }
}
