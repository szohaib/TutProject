using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using ApplicationUtility;
using MSEADEW_BAL;
using MSEADEW_DAL;

namespace MSEADEW_BAL.BAL
{
    public class BLogin:DataAccess 
    {
        private string _storedProcedure;
        private DataSet dataSet;
        private SqlParameter[] _parameters;

        public BLogin()
            : base(ApplicationUtility.Utility.ConnectionString)
        {
            _storedProcedure = "";
        }


        public DataSet RecoverPassword(string Username)
        {
            try
            {
                _storedProcedure = "RecoverLogin";
                _parameters = new SqlParameter[1];
                _parameters[0] = new SqlParameter("@Username", SqlDbType.Int);
                _parameters[0].Value = Username;

                return RunProcedure(_storedProcedure, _parameters, true);
            }
            catch
            {
                throw;
            }
        }
    }
}
