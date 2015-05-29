﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KusumgarBusinessEntities;
using KusumgarBusinessEntities.Common;
using KusumgarDatabaseEntities;
using System.Data;
using System.Net;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;
namespace KusumgarDataAccess
{
    public class CustomerRepo
    {
        SQLHelperRepo _sqlRepo;

        public CustomerRepo()
        {
            _sqlRepo = new SQLHelperRepo();
        }   

         public List<CustomerInfo> Get_Customers( ref PaginationInfo pager)
        {
            List<CustomerInfo> CustomerList = new List<CustomerInfo>();

            DataTable dt = _sqlRepo.ExecuteDataTable(null, StoredProcedures.Get_Customer_Sp.ToString(), CommandType.StoredProcedure);

              foreach (DataRow dr in CommonMethods.GetRows(dt, ref pager))
              {
                  CustomerList.Add(Get_Customer_Values(dr));
              }

            return CustomerList;
        }

         public List<CustomerInfo> Get_Customers_By_Name(string customer_Name, ref PaginationInfo pager)
         {
             List<CustomerInfo> CustomerList = new List<CustomerInfo>();

             List<SqlParameter> sqlParams = new List<SqlParameter>();

             sqlParams.Add(new SqlParameter("@Customer_Name", customer_Name));

             DataTable dt = _sqlRepo.ExecuteDataTable(sqlParams, StoredProcedures.Get_Customer_By_Name_Sp.ToString(), CommandType.StoredProcedure);

             foreach (DataRow dr in CommonMethods.GetRows(dt, ref pager))
              {
                  CustomerList.Add(Get_Customer_Values(dr));
              }

             return CustomerList;
         }

         public CustomerInfo Get_Customer_By_Id(int customer_Id)
         {
             CustomerInfo customer = new CustomerInfo();

             List<SqlParameter> sqlParams = new List<SqlParameter>();

             sqlParams.Add(new SqlParameter("@Customer_Id", customer_Id));

             DataSet ds = _sqlRepo.ExecuteDataSet(sqlParams, StoredProcedures.Get_Customer_By_Id_Sp.ToString(), CommandType.StoredProcedure);

             DataTable dt = ds.Tables[0];

             DataTable dt1 = ds.Tables[1];

             DataTable dt2 = ds.Tables[2];

             if (dt != null && dt.Rows.Count > 0)
             {
                 List<DataRow> drList = new List<DataRow>();

                 drList = dt.AsEnumerable().ToList();

                 foreach (DataRow dr in drList)
                 {
                     customer = Get_Customer_Values(dr); // To bind customer data 
                 }
             }

             if (dt1 != null && dt1.Rows.Count > 0)
             {
                 List<DataRow> drList = new List<DataRow>();

                 drList = dt1.AsEnumerable().ToList();

                 foreach (DataRow dr in drList)
                 {
                     customer.Bank_Details = Get_Bank_Details_Values(dr); // To bind bank details
                 }
             }

             if (dt2 != null && dt2.Rows.Count > 0)
             {
                 customer.Customer_Address_List = Get_Customer_Addresses(dt2);// to bind customer addresses
             }

             return customer;
         }

         private CustomerInfo Get_Customer_Values(DataRow dr)
         {
             CustomerInfo customer = new CustomerInfo();

             customer.Customer_Entity.Customer_Id = Convert.ToInt32(dr["Customer_Id"]);

             customer.Customer_Entity.Customer_Name = Convert.ToString(dr["Customer_Name"]);

             customer.Customer_Entity.Company_Email = Convert.ToString(dr["Company_Email"]);

             customer.Customer_Entity.Head_Office_Address = Convert.ToString(dr["Head_Office_Address"]);

             if (dr["Head_Office_State"] != DBNull.Value)
             {
                 customer.Customer_Entity.Head_Office_State = Convert.ToInt32(dr["Head_Office_State"]);
             }

             customer.Customer_Entity.Head_Office_ZipCode = Convert.ToString(dr["Head_Office_ZipCode"]);

             if (dr["Head_Office_Nation"] != DBNull.Value)
             {
                 customer.Customer_Entity.Head_Office_Nation = Convert.ToInt32(dr["Head_Office_Nation"]);
             }

             customer.Customer_Entity.Head_Office_Landline1 = Convert.ToString(dr["Head_Office_Landline1"]);

             customer.Customer_Entity.Head_Office_Landline2 = Convert.ToString(dr["Head_Office_Landline2"]);

             customer.Customer_Entity.Head_Office_FaxNo = Convert.ToString(dr["Head_Office_FaxNo"]);

             customer.Customer_Entity.Company_Turnover = Convert.ToString(dr["Company_Turnover"]);

             if (dr["Public_Private_Sector"] != DBNull.Value)
             {
                 customer.Customer_Entity.Public_Private_Sector = Convert.ToBoolean(dr["Public_Private_Sector"]);
             }

             if (dr["Organised_UnOrganised_Sector"] != DBNull.Value)
             {
                 customer.Customer_Entity.Organised_UnOrganised_Sector = Convert.ToBoolean(dr["Organised_UnOrganised_Sector"]);
             }

             if (dr["Proprietary_Private_Limited"] != DBNull.Value)
             {
                 customer.Customer_Entity.Proprietary_Private_Limited = Convert.ToInt32(dr["Proprietary_Private_Limited"]);
             }

             if (dr["Progressive_Stable_Turmoil"] != DBNull.Value)
             {
                 customer.Customer_Entity.Progressive_Stable_Turmoil = Convert.ToInt32(dr["Progressive_Stable_Turmoil"]);
             }

             if (dr["Expiration_Date_Of_Contract"] != DBNull.Value)
             {
                 customer.Customer_Entity.Expiration_Date_Of_Contract = Convert.ToDateTime(dr["Expiration_Date_Of_Contract"]);
             }

             if (dr["Credit_limit"] != DBNull.Value)
             {
                 customer.Customer_Entity.Credit_limit = Convert.ToInt32(dr["Credit_limit"]);
             }

             if (dr["Auto_Mail_Delivery"] != DBNull.Value)
             {
                 customer.Customer_Entity.Auto_Mail_Delivery = Convert.ToBoolean(dr["Auto_Mail_Delivery"]);
             }

             if (dr["Order_Minimum_Value"] != DBNull.Value)
             {
                 customer.Customer_Entity.Order_Minimum_Value = Convert.ToInt32(dr["Order_Minimum_Value"]);
             }

             if (dr["Order_Maximum_Value"] != DBNull.Value)
             {
                 customer.Customer_Entity.Order_Maximum_Value = Convert.ToInt32(dr["Order_Maximum_Value"]);
             }

             if (dr["Is_Approved_By_Director"] != DBNull.Value)
             {
                 customer.Customer_Entity.Is_Approved_By_Director = Convert.ToBoolean(dr["Is_Approved_By_Director"]);
             }

             if (dr["Block_Order"] != DBNull.Value)
             {
                 customer.Customer_Entity.Block_Order = Convert.ToBoolean(dr["Block_Order"]);
             }

             if (dr["Is_Active"] != DBNull.Value)
             {
                 customer.Customer_Entity.Is_Active = Convert.ToBoolean(dr["Is_Active"]);
             }

             return customer;
         }

         private BankDetailsInfo Get_Bank_Details_Values(DataRow dr)
        {
            BankDetailsInfo bank_details = new BankDetailsInfo();

            bank_details.Bank_Details_Entity.Bank_Details_Id = Convert.ToInt32(dr["Bank_Details_Id"]);

            if (dr["Supplier_Id"] != DBNull.Value)
            {
                bank_details.Bank_Details_Entity.Supplier_Id = Convert.ToInt32(dr["Supplier_Id"]);
            }

            if (dr["Customer_Id"] != DBNull.Value)
            {
                bank_details.Bank_Details_Entity.Customer_Id = Convert.ToInt32(dr["Customer_Id"]);
            }

            bank_details.Bank_Details_Entity.Bank_Name = Convert.ToString(dr["Bank_Name"]);
            bank_details.Bank_Details_Entity.Bank_Account_No = Convert.ToString(dr["Bank_Account_No"]);
            bank_details.Bank_Details_Entity.Branch_Name = Convert.ToString(dr["Branch_Name"]);
            bank_details.Bank_Details_Entity.Ifsc_Code = Convert.ToString(dr["Ifsc_Code"]);
            bank_details.Bank_Details_Entity.Swift_Code = Convert.ToString(dr["Swift_Code"]);
            bank_details.Bank_Details_Entity.Rtgs_No = Convert.ToString(dr["Rtgs_No"]);
            bank_details.Bank_Details_Entity.Bank_Address = Convert.ToString(dr["Bank_Address"]);
            bank_details.Bank_Details_Entity.Bank_Code = Convert.ToString(dr["Bank_Code"]);
            bank_details.Bank_Details_Entity.Account_Code = Convert.ToString(dr["Account_Code"]);
            bank_details.Bank_Details_Entity.Is_Active = Convert.ToBoolean(dr["Is_Active"]);
            bank_details.Bank_Details_Entity.CreatedOn = Convert.ToDateTime(dr["CreatedOn"]);
            bank_details.Bank_Details_Entity.CreatedBy = Convert.ToInt32(dr["CreatedBy"]);
            bank_details.Bank_Details_Entity.UpdatedOn = Convert.ToDateTime(dr["UpdatedOn"]);
            bank_details.Bank_Details_Entity.UpdatedBy = Convert.ToInt32(dr["UpdatedBy"]);

            bank_details.Bank_Details_Entity.Vat = Convert.ToString(dr["Vat"]);
            if (dr["Currency_Id"] != DBNull.Value)
            {
                bank_details.Bank_Details_Entity.Currency_Id = Convert.ToInt32(dr["Currency_Id"]);
            }
            if (dr["Payment_Term_Id"] != DBNull.Value)
            {
                bank_details.Bank_Details_Entity.Payment_Term_Id = Convert.ToInt32(dr["Payment_Term_Id"]);
            }

            bank_details.Bank_Details_Entity.Tax_Excemption_Code = Convert.ToString(dr["Tax_Excemption_Code"]);

            return bank_details;
        }

         private List<CustomerAddressInfo> Get_Customer_Addresses(DataTable dt2)
        {
            List<CustomerAddressInfo> customer_Address_List = new List<CustomerAddressInfo>();

             List<DataRow> drList = new List<DataRow>();

            drList = dt2.AsEnumerable().ToList();

            foreach (DataRow dr in drList)
            {
                CustomerAddressInfo customerAddress = new CustomerAddressInfo();

                customerAddress.Customer_Address_Entity.Customer_Address_Id = Convert.ToInt32(dr["Customer_Address_Id"]);
                customerAddress.Customer_Address_Entity.Customer_Id = Convert.ToInt32(dr["Customer_Id"]);
                customerAddress.Customer_Address_Entity.Address_Type = Convert.ToInt32(dr["Address_Type"]);
                customerAddress.Customer_Address_Entity.Addresss = Convert.ToString(dr["Addresss"]);
                customerAddress.Customer_Address_Entity.Landline1 = Convert.ToString(dr["Landline1"]);
                customerAddress.Customer_Address_Entity.landline2 = Convert.ToString(dr["landline2"]);
                customerAddress.Customer_Address_Entity.FaxNo = Convert.ToString(dr["FaxNo"]);
                customerAddress.Customer_Address_Entity.Is_Active = Convert.ToBoolean(dr["Is_Active"]);
                customerAddress.Customer_Address_Entity.CreatedOn = Convert.ToDateTime(dr["CreatedOn"]);
                customerAddress.Customer_Address_Entity.CreatedBy = Convert.ToInt32(dr["CreatedBy"]);
                customerAddress.Customer_Address_Entity.UpdatedOn = Convert.ToDateTime(dr["UpdatedOn"]);
                customerAddress.Customer_Address_Entity.UpdatedBy = Convert.ToInt32(dr["UpdatedBy"]);

                customer_Address_List.Add(customerAddress);
            }

            return customer_Address_List;
        }

        public int Insert_Customer(CustomerInfo customer)
        {
            int Customer_Id = 0;

            Customer_Id = Convert.ToInt32(_sqlRepo.ExecuteScalerObj(Set_Values_In_Customer(customer), StoredProcedures.Insert_Customer_sp.ToString(), CommandType.StoredProcedure));

            return Customer_Id;
        }

        public void Update_Customer(CustomerInfo customer)
        {
            _sqlRepo.ExecuteNonQuery(Set_Values_In_Customer(customer), StoredProcedures.Update_Customer_Sp.ToString(), CommandType.StoredProcedure);
        }

        public void Insert_Customer_Address(CustomerAddressInfo customer_Address)
        {

            _sqlRepo.ExecuteNonQuery(Set_Values_In_Customer_Address(customer_Address), StoredProcedures.Insert_Customer_Address.ToString(), CommandType.StoredProcedure);
          
        }

        public void Update_Customer_Address(CustomerAddressInfo customer_Address)
        {
            _sqlRepo.ExecuteNonQuery(Set_Values_In_Customer_Address(customer_Address), StoredProcedures.Update_Customer_Address.ToString(), CommandType.StoredProcedure);
        }

        public void Insert_Bank_Details(BankDetailsInfo bank_Details)
        {
            _sqlRepo.ExecuteNonQuery(Set_Values_In_Customer_Bank_Details(bank_Details), StoredProcedures.Insert_Bank_Details_Sp.ToString(), CommandType.StoredProcedure);
        }

        public void Update_Bank_Details(BankDetailsInfo bank_Details)
        {
            _sqlRepo.ExecuteNonQuery(Set_Values_In_Customer_Bank_Details(bank_Details), StoredProcedures.Update_Bank_Details_Sp.ToString(), CommandType.StoredProcedure);
        }

        private List<SqlParameter> Set_Values_In_Customer(CustomerInfo customer)
        {
            List<SqlParameter> sqlparam = new List<SqlParameter>();

            if (customer.Customer_Entity.Customer_Id != 0)
            {
                sqlparam.Add(new SqlParameter("@Customer_Id", customer.Customer_Entity.Customer_Id));
            }
           sqlparam.Add(new SqlParameter("@Customer_Name", customer.Customer_Entity.Customer_Name ));
            sqlparam.Add(new SqlParameter("@Company_Email", customer.Customer_Entity.Company_Email ));
            sqlparam.Add(new SqlParameter("@Head_Office_Address", customer.Customer_Entity.Head_Office_Address ));
            sqlparam.Add(new SqlParameter("@Head_Office_State", customer.Customer_Entity.Head_Office_State));
            sqlparam.Add(new SqlParameter("@Head_Office_ZipCode", customer.Customer_Entity.Head_Office_ZipCode));
            sqlparam.Add(new SqlParameter("@Head_Office_Nation", customer.Customer_Entity.Head_Office_Nation));
            sqlparam.Add(new SqlParameter("@Head_Office_Landline1", customer.Customer_Entity.Head_Office_Landline1));
            sqlparam.Add(new SqlParameter("@Head_Office_Landline2", customer.Customer_Entity.Head_Office_Landline2));
            sqlparam.Add(new SqlParameter("@Head_Office_FaxNo", customer.Customer_Entity.Head_Office_FaxNo));
            sqlparam.Add(new SqlParameter("@Company_Turnover", customer.Customer_Entity.Company_Turnover));
            sqlparam.Add(new SqlParameter("@Public_Private_Sector", customer.Customer_Entity.Public_Private_Sector));
            sqlparam.Add(new SqlParameter("@Organised_UnOrganised_Sector", customer.Customer_Entity.Organised_UnOrganised_Sector));
            sqlparam.Add(new SqlParameter("@Proprietary_Private_Limited", customer.Customer_Entity.Proprietary_Private_Limited));
            sqlparam.Add(new SqlParameter("@Progressive_Stable_Turmoil", customer.Customer_Entity.Progressive_Stable_Turmoil));
            sqlparam.Add(new SqlParameter("@Expiration_Date_Of_Contract", customer.Customer_Entity.Expiration_Date_Of_Contract));
            sqlparam.Add(new SqlParameter("@Credit_limit", customer.Customer_Entity.Credit_limit));
            sqlparam.Add(new SqlParameter("@Auto_Mail_Delivery", customer.Customer_Entity.Auto_Mail_Delivery));
            sqlparam.Add(new SqlParameter("@Order_Minimum_Value", customer.Customer_Entity.Order_Minimum_Value));
            sqlparam.Add(new SqlParameter("@Order_Maximum_Value", customer.Customer_Entity.Order_Maximum_Value));
            sqlparam.Add(new SqlParameter("@Is_Approved_By_Director", customer.Customer_Entity.Is_Approved_By_Director));
            sqlparam.Add(new SqlParameter("@Block_Order", customer.Customer_Entity.Block_Order));
            sqlparam.Add(new SqlParameter("@Is_Active", customer.Customer_Entity.Is_Active));
            if (customer.Customer_Entity.Customer_Id == 0)
            {
                sqlparam.Add(new SqlParameter("@CreatedBy", customer.Customer_Entity.CreatedBy));
                sqlparam.Add(new SqlParameter("@CreatedOn", customer.Customer_Entity.CreatedOn));
            }
            sqlparam.Add(new SqlParameter("@UpdatedBy", customer.Customer_Entity.UpdatedBy));
            sqlparam.Add(new SqlParameter("@UpdatedOn", customer.Customer_Entity.UpdatedOn));

            return sqlparam;
        }

        private List<SqlParameter> Set_Values_In_Customer_Bank_Details(BankDetailsInfo bank_Details)
        {
            List<SqlParameter> sqlparam = new List<SqlParameter>();

            if (bank_Details.Bank_Details_Entity.Bank_Details_Id != 0)
            {
                sqlparam.Add(new SqlParameter("@Bank_Details_Id", bank_Details.Bank_Details_Entity.Bank_Details_Id));
            }
            sqlparam.Add(new SqlParameter("@Supplier_Id", bank_Details.Bank_Details_Entity.Supplier_Id));
            sqlparam.Add(new SqlParameter("@Customer_Id", bank_Details.Bank_Details_Entity.Customer_Id));
            sqlparam.Add(new SqlParameter("@Bank_Name", bank_Details.Bank_Details_Entity.Bank_Name));
            sqlparam.Add(new SqlParameter("@Bank_Account_No", bank_Details.Bank_Details_Entity.Bank_Account_No));
            sqlparam.Add(new SqlParameter("@Branch_Name", bank_Details.Bank_Details_Entity.Branch_Name));
            sqlparam.Add(new SqlParameter("@Ifsc_Code", bank_Details.Bank_Details_Entity.Ifsc_Code));
            sqlparam.Add(new SqlParameter("@Swift_Code", bank_Details.Bank_Details_Entity.Swift_Code));
            sqlparam.Add(new SqlParameter("@Rtgs_No", bank_Details.Bank_Details_Entity.Rtgs_No));
            sqlparam.Add(new SqlParameter("@Bank_Address", bank_Details.Bank_Details_Entity.Bank_Address));
            sqlparam.Add(new SqlParameter("@Bank_Code", bank_Details.Bank_Details_Entity.Bank_Code));
            sqlparam.Add(new SqlParameter("@Account_Code", bank_Details.Bank_Details_Entity.Account_Code));
            sqlparam.Add(new SqlParameter("@Is_Active", bank_Details.Bank_Details_Entity.Is_Active));
            if (bank_Details.Bank_Details_Entity.Bank_Details_Id == 0)
            {
                sqlparam.Add(new SqlParameter("@CreatedBy", bank_Details.Bank_Details_Entity.CreatedBy));
                sqlparam.Add(new SqlParameter("@CreatedOn", bank_Details.Bank_Details_Entity.CreatedOn));
            }
            sqlparam.Add(new SqlParameter("@UpdatedOn", bank_Details.Bank_Details_Entity.UpdatedOn));

            sqlparam.Add(new SqlParameter("@Vat", bank_Details.Bank_Details_Entity.Vat));
            sqlparam.Add(new SqlParameter("@Currency_Id", bank_Details.Bank_Details_Entity.Currency_Id));
            sqlparam.Add(new SqlParameter("@Payment_Term_Id", bank_Details.Bank_Details_Entity.Payment_Term_Id));
            sqlparam.Add(new SqlParameter("@Tax_Excemption_Code", bank_Details.Bank_Details_Entity.Tax_Excemption_Code));
            sqlparam.Add(new SqlParameter("@UpdatedBy", bank_Details.Bank_Details_Entity.UpdatedBy));

            return sqlparam;
        }

        private List<SqlParameter> Set_Values_In_Customer_Address(CustomerAddressInfo customerAddress)
        {
            List<SqlParameter> sqlparam = new List<SqlParameter>();

            if (customerAddress.Customer_Address_Entity.Customer_Address_Id != 0)
            {
                sqlparam.Add(new SqlParameter("@Customer_Address_Id", customerAddress.Customer_Address_Entity.Customer_Address_Id));
            }
            sqlparam.Add(new SqlParameter("@Customer_Id", customerAddress.Customer_Address_Entity.Customer_Id));
            sqlparam.Add(new SqlParameter("@Address_Type", customerAddress.Customer_Address_Entity.Address_Type));
            sqlparam.Add(new SqlParameter("@Addresss", customerAddress.Customer_Address_Entity.Addresss));
            sqlparam.Add(new SqlParameter("@Landline1", customerAddress.Customer_Address_Entity.Landline1));
            sqlparam.Add(new SqlParameter("@landline2", customerAddress.Customer_Address_Entity.landline2));
            sqlparam.Add(new SqlParameter("@FaxNo", customerAddress.Customer_Address_Entity.FaxNo));
            sqlparam.Add(new SqlParameter("@Is_Active", customerAddress.Customer_Address_Entity.Is_Active));
            if (customerAddress.Customer_Address_Entity.Customer_Address_Id == 0)
            {
                sqlparam.Add(new SqlParameter("@CreatedBy", customerAddress.Customer_Address_Entity.CreatedBy));
                sqlparam.Add(new SqlParameter("@CreatedOn", customerAddress.Customer_Address_Entity.CreatedOn));
            }
            sqlparam.Add(new SqlParameter("@UpdatedBy", customerAddress.Customer_Address_Entity.UpdatedBy));
            sqlparam.Add(new SqlParameter("@UpdatedOn", customerAddress.Customer_Address_Entity.UpdatedOn));

            return sqlparam;
        }

        public void Delete_Customer_Address_By_Id(int customer_Address_Id)
        {
            List<SqlParameter> sqlparam = new List<SqlParameter>();

             sqlparam.Add(new SqlParameter("@Customer_Address_Id", customer_Address_Id));

            _sqlRepo.ExecuteNonQuery(sqlparam, StoredProcedures.Delete_Customer_Address_By_Id.ToString(), CommandType.StoredProcedure);
        }

        public bool Check_Existing_Customer(string customer_Name)
        {
            bool check = false;

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            sqlParams.Add(new SqlParameter("@Customer_Name", customer_Name));

            DataTable dt = _sqlRepo.ExecuteDataTable(sqlParams, StoredProcedures.Check_Existing_Customer_Sp.ToString(), CommandType.StoredProcedure);

            if (dt != null && dt.Rows.Count > 0)
            {
                int count = dt.Rows.Count;

                List<DataRow> drList = new List<DataRow>();

                drList = dt.AsEnumerable().ToList();

                foreach (DataRow dr in drList)
                {
                    check = Convert.ToBoolean(dr["check_Customer"]);
                }
            }

            return check;
        }

        public List<CustomerInfo> Get_Customers_By_Email(string email, ref PaginationInfo pager)
        {
            List<CustomerInfo> CustomerList = new List<CustomerInfo>();

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            sqlParams.Add(new SqlParameter("@Email", email));

            DataTable dt = _sqlRepo.ExecuteDataTable(sqlParams, StoredProcedures.Get_Customer_By_Email_Sp.ToString(), CommandType.StoredProcedure);

            foreach (DataRow dr in CommonMethods.GetRows(dt, ref pager))
            {
                CustomerList.Add(Get_Customer_Values(dr));
            }

            return CustomerList;
        }

        public List<CustomerInfo> Get_Customers_By_Turnover(string turnover, ref PaginationInfo pager)
        {
            List<CustomerInfo> CustomerList = new List<CustomerInfo>();

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            sqlParams.Add(new SqlParameter("@Turnover", turnover));

            DataTable dt = _sqlRepo.ExecuteDataTable(sqlParams, StoredProcedures.Get_Customer_By_Turnover_Sp.ToString(), CommandType.StoredProcedure);

            foreach (DataRow dr in CommonMethods.GetRows(dt, ref pager))
            {
                CustomerList.Add(Get_Customer_Values(dr));
            }

            return CustomerList;
        }

        public List<CustomerInfo> Get_Customers_By_Turnover_Email(string turnover,string email, ref PaginationInfo pager)
        {
            List<CustomerInfo> CustomerList = new List<CustomerInfo>();

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            sqlParams.Add(new SqlParameter("@Turnover", turnover));

            sqlParams.Add(new SqlParameter("@Email", email));

            DataTable dt = _sqlRepo.ExecuteDataTable(sqlParams, StoredProcedures.Get_Customer_By_Turnover_Email_Sp.ToString(), CommandType.StoredProcedure);

            foreach (DataRow dr in CommonMethods.GetRows(dt, ref pager))
            {
                CustomerList.Add(Get_Customer_Values(dr));
            }

            return CustomerList;
        }

        public List<CustomerInfo> Get_Customers_By_Turnover_Name(string turnover, string customer_Name, ref PaginationInfo pager)
        {
            List<CustomerInfo> CustomerList = new List<CustomerInfo>();

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            sqlParams.Add(new SqlParameter("@Turnover", turnover));

            sqlParams.Add(new SqlParameter("@Customer_Name", customer_Name));

            DataTable dt = _sqlRepo.ExecuteDataTable(sqlParams, StoredProcedures.Get_Customer_By_Turnover_Name_Sp.ToString(), CommandType.StoredProcedure);

            foreach (DataRow dr in CommonMethods.GetRows(dt, ref pager))
            {
                CustomerList.Add(Get_Customer_Values(dr));
            }

            return CustomerList;
        }

        public List<CustomerInfo> Get_Customers_By_Email_Name(string email, string customer_Name, ref PaginationInfo pager)
        {
            List<CustomerInfo> CustomerList = new List<CustomerInfo>();

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            sqlParams.Add(new SqlParameter("@Email", email));

            sqlParams.Add(new SqlParameter("@Customer_Name", customer_Name));

            DataTable dt = _sqlRepo.ExecuteDataTable(sqlParams, StoredProcedures.Get_Customer_By_Email_Name_Sp.ToString(), CommandType.StoredProcedure);

            foreach (DataRow dr in CommonMethods.GetRows(dt, ref pager))
            {
                CustomerList.Add(Get_Customer_Values(dr));
            }

            return CustomerList;
        }

        public List<CustomerInfo> Get_Customers_By_Email_Name_Turnover(string email, string customer_Name,string turnover, ref PaginationInfo pager)
        {
            List<CustomerInfo> CustomerList = new List<CustomerInfo>();

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            sqlParams.Add(new SqlParameter("@Email", email));

            sqlParams.Add(new SqlParameter("@Customer_Name", customer_Name));

            sqlParams.Add(new SqlParameter("@Turnover", turnover));

            DataTable dt = _sqlRepo.ExecuteDataTable(sqlParams, StoredProcedures.Get_Customer_By_Email_Name_Turnover_Sp.ToString(), CommandType.StoredProcedure);

            foreach (DataRow dr in CommonMethods.GetRows(dt, ref pager))
            {
                CustomerList.Add(Get_Customer_Values(dr));
            }

            return CustomerList;
        }

        public List<CustomerInfo> Get_Customers_by_Nation_Id_Turnover(string turnover, int nation_Id, ref PaginationInfo pager)
        {
            List<CustomerInfo> CustomerList = new List<CustomerInfo>();

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            sqlParams.Add(new SqlParameter("@Nation_Id", nation_Id));

            sqlParams.Add(new SqlParameter("@Turnover", turnover));

            DataTable dt = _sqlRepo.ExecuteDataTable(sqlParams, StoredProcedures.Get_Customer_by_Nation_Id_Turnover_Sp.ToString(), CommandType.StoredProcedure);

            foreach (DataRow dr in CommonMethods.GetRows(dt, ref pager))
            {
                CustomerList.Add(Get_Customer_Values(dr));
            }

            return CustomerList;
        }

        public List<CustomerInfo> Get_Customers_by_Nation_Id(int nation_Id, ref PaginationInfo pager)
        {
            List<CustomerInfo> CustomerList = new List<CustomerInfo>();

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            sqlParams.Add(new SqlParameter("@Nation_Id", nation_Id));

            DataTable dt = _sqlRepo.ExecuteDataTable(sqlParams, StoredProcedures.Get_Customer_by_Nation_Id_Sp.ToString(), CommandType.StoredProcedure);

            foreach (DataRow dr in CommonMethods.GetRows(dt, ref pager))
            {
                CustomerList.Add(Get_Customer_Values(dr));
            }

            return CustomerList;
        }

        public List<CustomerInfo> Get_Customers_By_Turnover_Customer_Id_Nation_Id(string turnover, int nation_Id, int customer_Id,ref PaginationInfo pager)
        {
            List<CustomerInfo> CustomerList = new List<CustomerInfo>();

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            sqlParams.Add(new SqlParameter("@Nation_Id", nation_Id));

            sqlParams.Add(new SqlParameter("@Turnover", turnover));

            sqlParams.Add(new SqlParameter("@Customer_Id", customer_Id));

            DataTable dt = _sqlRepo.ExecuteDataTable(sqlParams, StoredProcedures.Get_Customer_By_Turnover_Customer_Id_Nation_Id_Sp.ToString(), CommandType.StoredProcedure);

            foreach (DataRow dr in CommonMethods.GetRows(dt, ref pager))
            {
                CustomerList.Add(Get_Customer_Values(dr));
            }

            return CustomerList;
        }

        public List<CustomerInfo> Get_Customers_By_Turnover_Customer_Id(string turnover, int customer_Id,ref PaginationInfo pager)
        {
            List<CustomerInfo> CustomerList = new List<CustomerInfo>();

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            sqlParams.Add(new SqlParameter("@Turnover", turnover));

            sqlParams.Add(new SqlParameter("@Customer_Id", customer_Id));

            DataTable dt = _sqlRepo.ExecuteDataTable(sqlParams, StoredProcedures.Get_Customer_By_Turnover_Customer_Id_Sp.ToString(), CommandType.StoredProcedure);

            foreach (DataRow dr in CommonMethods.GetRows(dt, ref pager))
            {
                CustomerList.Add(Get_Customer_Values(dr));
            }

            return CustomerList;
        }

        public List<CustomerInfo> Get_Customers_By_Customer_Id_Nation_Id(int nation_Id, int customer_Id, ref PaginationInfo pager)
        {
            List<CustomerInfo> CustomerList = new List<CustomerInfo>();

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            sqlParams.Add(new SqlParameter("@Nation_Id", nation_Id));

            sqlParams.Add(new SqlParameter("@Customer_Id", customer_Id));

            DataTable dt = _sqlRepo.ExecuteDataTable(sqlParams, StoredProcedures.Get_Customer_By_Customer_Id_Nation_Id_Sp.ToString(), CommandType.StoredProcedure);

            foreach (DataRow dr in CommonMethods.GetRows(dt, ref pager))
            {
                CustomerList.Add(Get_Customer_Values(dr));
            }

            return CustomerList;
        }

        public List<CustomerInfo> Get_Customers_By_Id(int Customer_Id, ref PaginationInfo pager)
        {
            List<CustomerInfo> CustomerList = new List<CustomerInfo>();

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            sqlParams.Add(new SqlParameter("@Customer_Id", Customer_Id)); ;

            DataTable dt = _sqlRepo.ExecuteDataTable(sqlParams, StoredProcedures.Get_Customer_By_Id_Sp.ToString(), CommandType.StoredProcedure);

            foreach (DataRow dr in CommonMethods.GetRows(dt, ref pager))
            {
                CustomerList.Add(Get_Customer_Values(dr));
            }

            return CustomerList;
        }
    }
}
