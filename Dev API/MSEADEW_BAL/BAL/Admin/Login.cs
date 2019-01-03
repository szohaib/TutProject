using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MSEADEW_DAL;
using System.Data;

namespace MSEADEW_BAL.BAL.Admin
{
    public class Login
    {
        DataSet _dataSet = null;
        MSEADEW_DAL.DAL.Login _login = null;
        public string userName { get; set; }
        public string password { get; set; }



        public DataSet GetLoginDetails(string userName)
        {
            _dataSet = new DataSet();
            _login = new MSEADEW_DAL.DAL.Login();
            _dataSet = _login.GetLoginDetails(userName);
            return _dataSet;
        }
    }
}
