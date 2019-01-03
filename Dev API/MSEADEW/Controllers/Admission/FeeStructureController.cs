using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MSEADEW_BAL;
using System.Data;

namespace MSEADEW.Controllers.Admission
{
    public class FeeStructureController : ApiController
    {

        private DataSet _dataSet = null;
        private MSEADEW_BAL.BAL.Admissions.FeeStructure _feeStructure = null;



        [HttpGet]
        public IHttpActionResult GetAllFeeStructure(int educationLevelId,int branchId,int userId)
        {
            //https://xitacademyapi.azurewebsites.net/api/FeeStructure/GetAllFeeStructure?educationLevelId=1&&branchId&&userId
            _feeStructure = new MSEADEW_BAL.BAL.Admissions.FeeStructure();
            _dataSet = new DataSet();
            _dataSet = _feeStructure.GetAllFeesStructure(educationLevelId, branchId, userId);
            _dataSet.Tables[0].TableName = "feeStructure";
            _dataSet.Tables[1].TableName = "feeDiscount";
            return Ok(_dataSet);
        }
    }
}
