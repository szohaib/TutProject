using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationUtility;
using System.Data;
using System.Data.SqlClient;

namespace MSEADEW_DAL.DAL
{
    public class Login : DataAccess
    {

        private string _storedProcedure;
        private DataSet dataSet;
        private SqlParameter[] _parameters;

        public Login()
            : base(ApplicationUtility.Utility.ConnectionString)
        {
            _storedProcedure = "";
        }

        public DataSet GetLoginDetails(string userName)
        {
            try
            {
                _storedProcedure = "GetLoginDetails";
                _parameters = new SqlParameter[1];
                _parameters[0] = new SqlParameter("@userName", SqlDbType.NVarChar);
                _parameters[0].Value = userName;
                return RunProcedure(_storedProcedure, _parameters, true);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

    }
}
