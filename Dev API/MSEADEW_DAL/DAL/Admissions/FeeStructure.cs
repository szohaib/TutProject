using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationUtility;
using System.Data;
using System.Data.SqlClient;

namespace MSEADEW_DAL.DAL.Admissions
{
    public class FeeStructure:DataAccess
    {
        private string _storedProcedure;
        private DataSet dataSet;
        private SqlParameter[] _parameters;

        public FeeStructure()
            : base(ApplicationUtility.Utility.ConnectionString)
        {
            _storedProcedure = "";
        }
        public DataSet GetAllFeesStructure(int educationLevelId,int branchId,int userId)
        {

            try
            {
                _storedProcedure = "GetAllFeesStructure";
                _parameters = new SqlParameter[3];
                _parameters[0] = new SqlParameter("@EducationLevelId", SqlDbType.Int);
                _parameters[0].Value = educationLevelId;
                _parameters[1] = new SqlParameter("@BranchId", SqlDbType.Int);
                _parameters[1].Value = branchId;
                _parameters[2] = new SqlParameter("@UserId", SqlDbType.Int);
                _parameters[2].Value = userId;
                return RunProcedure(_storedProcedure, _parameters, true);
            }
            catch
            {
                throw;
            }
        }

    }
}
