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
using MSEADEW_DAL.DAL;
using System.Collections.Generic;

namespace MSEADEW_BAL.BAL
{
    public class BLookup:DataAccess
    {
        private string _storedProcedure;
        private DataSet dataSet;
        private SqlParameter[] _parameters;

        public BLookup()
            : base(ApplicationUtility.Utility.ConnectionString)
        {
            _storedProcedure = "";
        }
        public DataSet GetAllLookup(int userId)
        {

            try
            { 
                _storedProcedure = "GetLookUpDataByUserId";
                _parameters = new SqlParameter[1];
                _parameters[0] = new SqlParameter("@UserId", SqlDbType.Int);
                _parameters[0].Value = userId;
                return RunProcedure(_storedProcedure, _parameters, true);
              
            }
            catch
            {
                throw;
            }
        }

    }
}
