using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using ApplicationUtility;
using MSEADEW_BAL;
using MSEADEW_DAL;
using System;
using MSEADEW_DAL.DAL.Admissions;

namespace MSEADEW_BAL.BAL.Admissions
{
   public  class BEnquiry : DataAccess
    {
        private string _storedProcedure;
        private DataSet _dataSet;
        private SqlParameter[] _parameters;

        public BEnquiry()
            : base(ApplicationUtility.Utility.ConnectionString)
        {
            _storedProcedure = "";
        }


        public DataSet GetAllEnquiries(int? userId)
        {
            try
            {
                _dataSet = new DataSet();
                return _dataSet = new MSEADEW_DAL.DAL.Admissions.Enquiry().GetAllEnquiries(userId);
            }
            catch
            {
                throw;
            }
        }
        public DataSet GetEnquiryByID(int enquiryid)
        {
            try
            {
                _dataSet = new DataSet();
                return _dataSet = new Enquiry().GetEnquiryByID(enquiryid);
            }
            catch
            {
                throw;
            }
        }

        public string UpdateEnquiry(Enquiry en)
        {
            try
            {
                string newEnquiryId = string.Empty;
                Enquiry enquiry = new Enquiry();
                newEnquiryId = enquiry.UpdateEnquiry(en);
                return newEnquiryId;
            }
            catch(SqlException ex)
            {
                throw ex;
            }
        }
    }
}
