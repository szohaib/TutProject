using MSEADEW_BAL.BAL;
using MSEADEW_DAL.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MSEADEW.Controllers
{
    public class LookupController : ApiController
    {
        private string _resultJson = string.Empty;
        private DataSet _dataSet;
        private BLookup lookup = null;
        [HttpGet]
        public IHttpActionResult GetAllLookup(int userId)
        {
            try
            {
                //ADO.NET
                 lookup = new BLookup();
                _dataSet = new DataSet();
                _dataSet = lookup.GetAllLookup(userId);
                if (_dataSet != null)
                {
                    _dataSet.Tables[0].TableName = "Zones";
                    _dataSet.Tables[1].TableName = "Branches";
                    _dataSet.Tables[2].TableName = "EducationLevels";
                    _dataSet.Tables[3].TableName = "InstitutionTypes";
                    _dataSet.Tables[4].TableName = "EducationGroups";
                    _dataSet.Tables[5].TableName = "EducationCourse";
                    _dataSet.Tables[6].TableName = "SecondLanguage";
                    _dataSet.Tables[7].TableName = "QualifyingExams";
                    _dataSet.Tables[8].TableName = "UsersList";
                    _dataSet.Tables[9].TableName = "PendingCount";
                    _dataSet.Tables[10].TableName = "Status";
                    _dataSet.Tables[11].TableName = "Categories";
                   
                }

                return Ok(_dataSet);
            }
            catch (Exception exception)
            {
                return InternalServerError(exception);
            }
        }
    }
}
