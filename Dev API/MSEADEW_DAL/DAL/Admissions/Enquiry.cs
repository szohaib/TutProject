using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using ApplicationUtility;
using Newtonsoft.Json;

namespace MSEADEW_DAL.DAL.Admissions
{
    public class Enquiry : DataAccess
    {
        public int? id { get; set; }
        public int? academicYear { get; set; }
        public string enquiryNumber { get; set; }
        public int? branchId { get; set; }
        public int? courseId { get; set; }
        public string studentName { get; set; }
        public string qualifyingExamName { get; set; }
        public string htNo { get; set; }
        public int? yearofPassing { get; set; }
        public string gradeMarks { get; set; }
        public decimal? cgpaPer { get; set; }
        public Nullable<Boolean> gender { get; set; }
        public string guardianName { get; set; }
        public string phone { get; set; }
        public string remarks { get; set; }
        public string preivousInstituteName { get; set; }
        private string _storedProcedure;
        private DataSet dataSet;
        private SqlParameter[] _parameters;

        public Enquiry()
            : base(ApplicationUtility.Utility.ConnectionString)
        {
            _storedProcedure = "";
        }


        public DataSet GetAllEnquiries(int? userid)
        {
            try
            {
                _storedProcedure = "GetAllEnquiries";
                _parameters = new SqlParameter[1];
                _parameters[0] = new SqlParameter("@UserId", SqlDbType.Int);
                _parameters[0].Value = userid;

                return RunProcedure(_storedProcedure, _parameters, true);
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
                _storedProcedure = "GetEnquiryDetailsById";
                _parameters = new SqlParameter[1];
                _parameters[0] = new SqlParameter("@EnquiryId", SqlDbType.Int);
                _parameters[0].Value = enquiryid;

                return RunProcedure(_storedProcedure, _parameters, true);
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
                DataSet dsResponse = null;
                string newEnquiryId = string.Empty;
                _storedProcedure = "UpdateEnquiry";
                _parameters = new SqlParameter[16];
                _parameters[0] = new SqlParameter("@EnquiryId", SqlDbType.Int);
                _parameters[0].Value = Convert.ToInt32(en.id);
                _parameters[1] = new SqlParameter("@AcademicYear", SqlDbType.Int);
                _parameters[1].Value = Convert.ToInt32(en.academicYear);
                _parameters[2] = new SqlParameter("@EnquiryNumber", SqlDbType.VarChar);
                _parameters[2].Value = en.enquiryNumber;
                _parameters[3] = new SqlParameter("@BranchId", SqlDbType.Int);
                _parameters[3].Value = Convert.ToInt32(en.branchId);
                _parameters[4] = new SqlParameter("@CourseId", SqlDbType.Int);
                _parameters[4].Value = Convert.ToInt32(en.courseId);
                _parameters[5] = new SqlParameter("@StudentName", SqlDbType.VarChar);
                _parameters[5].Value = en.studentName;
                _parameters[6] = new SqlParameter("@QualifyingExamName", SqlDbType.VarChar);
                _parameters[6].Value = en.qualifyingExamName;
                _parameters[7] = new SqlParameter("@HTNo", SqlDbType.VarChar);
                _parameters[7].Value = en.htNo;
                _parameters[8] = new SqlParameter("@YearofPassing", SqlDbType.Int);
                _parameters[8].Value = Convert.ToInt32(en.yearofPassing);
                _parameters[9] = new SqlParameter("@GradeMarks", SqlDbType.VarChar);
                _parameters[9].Value = en.gradeMarks;
                _parameters[10] = new SqlParameter("@CGPAPer", SqlDbType.Decimal);
                _parameters[10].Value = Convert.ToDecimal(en.cgpaPer);
                _parameters[11] = new SqlParameter("@Gender", SqlDbType.Bit);
                _parameters[11].Value = Convert.ToBoolean(en.gender);
                _parameters[12] = new SqlParameter("@GuardianName", SqlDbType.VarChar);
                _parameters[12].Value = en.guardianName;
                _parameters[13] = new SqlParameter("@Phone", SqlDbType.VarChar);
                _parameters[13].Value = en.phone;
                _parameters[14] = new SqlParameter("@Remarks", SqlDbType.VarChar);
                _parameters[14].Value = en.remarks;
                _parameters[15] = new SqlParameter("@PreivousInstituteName", SqlDbType.VarChar);
                _parameters[15].Value = en.preivousInstituteName;
                _parameters[15] = new SqlParameter("@UserId", SqlDbType.VarChar);
                _parameters[15].Value = null;

                dsResponse = RunProcedure(_storedProcedure, _parameters, true);

                if (dsResponse == null || dsResponse.Tables.Count == 0)
                {
                    throw new System.ArgumentException("No Enquiry Added/Updated.");
                }
                else
                {
                    if (dsResponse.Tables[0].Rows.Count > 0)
                        newEnquiryId = dsResponse.Tables[0].Rows[0][0].ToString();
                }
                return newEnquiryId;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

    }
}
