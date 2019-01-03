using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationUtility;
using System.Data;
using System.Data.SqlClient;
using MSEADEW_BAL.BAL.Admissions;

namespace MSEADEW_DAL.DAL.Admissions
{
    public class Admission :DataAccess
    {
        
        private string _storedProcedure;
        private SqlParameter[] _parameters;
        private DataSet dsResponse = null;

        public Admission()
            : base(ApplicationUtility.Utility.ConnectionString)
        {
            _storedProcedure = "";
        }

        public DataSet GetAllAdmissionDetails(int? userId)
        {
            try
            {
                _storedProcedure = "GetAllAdmissions";
                _parameters = new SqlParameter[1];
                _parameters[0] = new SqlParameter("@UserId", SqlDbType.Int);
                _parameters[0].Value = userId;
                return RunProcedure(_storedProcedure, _parameters, true);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
        public DataSet GetAdmissionDetailsById(int educationLevelId, int AdmissionId, int userId)
        {
            try
            {
                _storedProcedure = "GetAdmissionDetailsByID";
                _parameters = new SqlParameter[3];
                _parameters[0] = new SqlParameter("@EducationLevelId", SqlDbType.Int);
                _parameters[0].Value = educationLevelId;
                _parameters[1] = new SqlParameter("@AdmissionId", SqlDbType.Int);
                _parameters[1].Value = AdmissionId;
                _parameters[2] = new SqlParameter("@UserId", SqlDbType.Int);
                _parameters[2].Value = userId;
                return RunProcedure(_storedProcedure, _parameters, true);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
        public int UpdateAdmission(MSEADEW_BAL.BAL.Admissions.BAdmission adm)
        {
            try
            {
                int newAdmissionId = 0;
                _storedProcedure = "UpdateAdmission";
                _parameters = new SqlParameter[38];
                _parameters[0] = new SqlParameter("@AdmissionId", SqlDbType.Int);
                _parameters[0].Value = adm.id;
                _parameters[1] = new SqlParameter("@ApplicationNo", SqlDbType.Int);
                _parameters[1].Value = Convert.ToInt32(adm.applicationNo);
                _parameters[2] = new SqlParameter("@FirstName", SqlDbType.VarChar);
                _parameters[2].Value = adm.firstName;
                _parameters[3] = new SqlParameter("@LastName", SqlDbType.VarChar);
                _parameters[3].Value = adm.lastName;
                _parameters[4] = new SqlParameter("@EducationLevelId", SqlDbType.Int);
                _parameters[4].Value = Convert.ToInt32(adm.educationLevelId);
                _parameters[5] = new SqlParameter("@CourseId", SqlDbType.Int);
                _parameters[5].Value = Convert.ToInt32(adm.courseId);
                _parameters[6] = new SqlParameter("@QualifyingExamId", SqlDbType.Int);
                _parameters[6].Value = Convert.ToInt32(adm.qualifyingExamId);
                _parameters[7] = new SqlParameter("@OtherQualifyingExamName", SqlDbType.VarChar);
                _parameters[7].Value = adm.otherQualifyingExamName;
                _parameters[8] = new SqlParameter("@HTRollNo", SqlDbType.VarChar);
                _parameters[8].Value = adm.htRollNo;
                _parameters[9] = new SqlParameter("@Gender", SqlDbType.Bit);
                _parameters[9].Value = Convert.ToBoolean(adm.gender);
                _parameters[10] = new SqlParameter("@DOB", SqlDbType.DateTime);
                _parameters[10].Value = Convert.ToDateTime(adm.dob);
                _parameters[11] = new SqlParameter("@CategoryId", SqlDbType.Int);
                _parameters[11].Value = adm.categoryId;
                _parameters[12] = new SqlParameter("@GuardianId", SqlDbType.Int);
                _parameters[12].Value = Convert.ToInt32(adm.guardianId);
                _parameters[13] = new SqlParameter("@AdhaarNo", SqlDbType.VarChar);
                _parameters[13].Value = adm.adhaarNo;
                _parameters[14] = new SqlParameter("@AcademicYear", SqlDbType.Int);
                _parameters[14].Value = Convert.ToInt32(adm.academicYear);
                _parameters[15] = new SqlParameter("@TCEnclosed", SqlDbType.Bit);
                _parameters[15].Value = Convert.ToBoolean(adm.tCEnclosed);
                _parameters[16] = new SqlParameter("@StatusId", SqlDbType.Int);
                _parameters[16].Value = Convert.ToInt32(adm.statusId);
                _parameters[17] = new SqlParameter("@Remarks", SqlDbType.VarChar);
                _parameters[17].Value = adm.remarks;
                _parameters[18] = new SqlParameter("@AssignedTo", SqlDbType.Int);
                _parameters[18].Value = Convert.ToInt32(adm.assignedTo);
                _parameters[19] = new SqlParameter("@BranchId", SqlDbType.Int);
                _parameters[19].Value = Convert.ToInt32(adm.branchId);
                _parameters[20] = new SqlParameter("@ModifiedBy", SqlDbType.Int);
                _parameters[20].Value = Convert.ToInt32(adm.modifiedBy);
                _parameters[21] = new SqlParameter("@Discount", SqlDbType.Decimal);
                _parameters[21].Value = adm.Discount;
                _parameters[22] = new SqlParameter("@Discount_Reason", SqlDbType.VarChar);
                _parameters[22].Value = adm.Discount_Reason;
                _parameters[23] = new SqlParameter("@Term1", SqlDbType.Decimal);
                _parameters[23].Value = adm.Term1;
                _parameters[24] = new SqlParameter("@Term2", SqlDbType.Decimal);
                _parameters[24].Value = adm.Term2;
                _parameters[25] = new SqlParameter("@Term3", SqlDbType.Decimal);
                _parameters[25].Value = adm.Term3;
                _parameters[26] = new SqlParameter("@Term4", SqlDbType.Decimal);
                _parameters[26].Value = adm.Term4;
                _parameters[27] = new SqlParameter("@Term1Date", SqlDbType.DateTime);
                _parameters[27].Value = adm.Term1Date;
                _parameters[28] = new SqlParameter("@Term2Date", SqlDbType.DateTime);
                _parameters[28].Value = adm.Term2Date;
                _parameters[29] = new SqlParameter("@Term3Date", SqlDbType.DateTime);
                _parameters[29].Value = adm.Term3Date;
                _parameters[30] = new SqlParameter("@Term4Date", SqlDbType.DateTime);
                _parameters[30].Value = adm.Term4Date;
                _parameters[31] = new SqlParameter("@TotalFee_Payable", SqlDbType.Decimal);
                _parameters[31].Value = adm.TotalFeePayable;
                _parameters[32] = new SqlParameter("@ACCategory", SqlDbType.Bit);
                _parameters[32].Value = adm.ACCategory;
                _parameters[33] = new SqlParameter("@ReceiptNo1", SqlDbType.VarChar);
                _parameters[33].Value = adm.ReceiptNo1;
                _parameters[34] = new SqlParameter("@ReceiptNo2", SqlDbType.VarChar);
                _parameters[34].Value = adm.ReceiptNo2;
                _parameters[35] = new SqlParameter("@ReceiptNo3", SqlDbType.VarChar);
                _parameters[35].Value = adm.ReceiptNo3;
                _parameters[36] = new SqlParameter("@ReceiptNo4", SqlDbType.VarChar);
                _parameters[36].Value = adm.ReceiptNo4;
                _parameters[37] = new SqlParameter("@StudentFeeStructureId", SqlDbType.Int);
                _parameters[37].Value = adm.StudentFeeStructureId;



                dsResponse = RunProcedure(_storedProcedure, _parameters, true);

                if (dsResponse == null || dsResponse.Tables.Count == 0)
                {
                    throw new System.ArgumentException("No Admission Added/Updated.");
                }
                else
                {
                    if (dsResponse.Tables[0].Rows.Count > 0)
                        newAdmissionId = Convert.ToInt32(dsResponse.Tables[0].Rows[0]["AdmissionId"]);

                }

                return newAdmissionId;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

    }
}
