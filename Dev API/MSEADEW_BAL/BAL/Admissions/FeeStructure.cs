using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MSEADEW_DAL;
using ApplicationUtility;
using System.Data;

namespace MSEADEW_BAL.BAL.Admissions
{
    public class FeeStructure:MSEADEW_DAL.DAL.Admissions.FeeStructure
    {
        DataSet _dataSet = null;


        public new DataSet GetAllFeesStructure(int educationLevelId, int branchId, int userId)
        {
            _dataSet = new DataSet();
            return _dataSet = new MSEADEW_DAL.DAL.Admissions.FeeStructure().GetAllFeesStructure(educationLevelId, branchId, userId);
        }
    }
}
