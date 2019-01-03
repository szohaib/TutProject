using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MSEADEW_DAL;
using MSEADEW_DAL.DAL.Admissions;
using ApplicationUtility;
using System.Data.SqlClient;
using MSEADEW_DAL.DAL;

namespace MSEADEW_BAL.BAL.Admissions
{
    public class BAdmission
    {
        private DataSet _dataSet=null;


        public Nullable<int> id { get; set; }
        public string applicationNo { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public int educationLevelId { get; set; }
        public int courseId { get; set; }
        public Nullable<int> qualifyingExamId { get; set; }
        public string otherQualifyingExamName { get; set; }
        public string htRollNo { get; set; }
        public Nullable<Boolean> gender { get; set; }
        public DateTime dob { get; set; }
        public Nullable<int> categoryId { get; set; }
        public Nullable<int> guardianId { get; set; }
        public string adhaarNo { get; set; }
        public Nullable<int> academicYear { get; set; }
        public Nullable<Boolean> tCEnclosed { get; set; }
        public Nullable<int> statusId { get; set; }
        public string remarks { get; set; }
        public int? assignedTo { get; set; }
        public int branchId { get; set; }
        public Nullable<int> modifiedBy { get; set; }
        public DateTime modifiedDate { get; set; }
        public Nullable<decimal> Discount { get; set; }
        public string Discount_Reason { get; set; }
        public Nullable<decimal> Term1 { get; set; }
        public Nullable<decimal> Term2 { get; set; }
        public Nullable<decimal> Term3 { get; set; }
        public Nullable<decimal> Term4 { get; set; }
        public DateTime Term1Date { get; set; }
        public DateTime Term2Date { get; set; }
        public DateTime Term3Date { get; set; }
        public DateTime Term4Date { get; set; }
        public Nullable<decimal> TotalFeePayable { get; set; }
         public bool ACCategory { get; set; }
        public string ReceiptNo1 { get; set; }
        public string ReceiptNo2 { get; set; }
        public string ReceiptNo3 { get; set; }
        public string ReceiptNo4 { get; set; }
        public Nullable<int> StudentFeeStructureId { get; set; }

        public DataSet GetAllAdmissionDetails(int? userId)
        {
            try
            {
                _dataSet = new DataSet();
                return _dataSet = new Admission().GetAllAdmissionDetails(userId);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
        public DataSet GetAdmissionDetailsById(int educationLevelId,int admissionId,int userId)
        {
            try
            {
                _dataSet = new DataSet();
                return _dataSet = new Admission().GetAdmissionDetailsById(educationLevelId, admissionId,userId);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
        public int UpdateAdmission(BAdmission adm)
        {
            try
            {
                int newAdmissionId = 0;
                _dataSet = new DataSet();
               newAdmissionId = new Admission().UpdateAdmission(adm);
                return newAdmissionId;
            }
            catch(SqlException ex)
            {
                throw ex;
            }
        }

    }

}
