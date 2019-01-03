using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MSEADEW_BAL.BAL.Admissions;

namespace MSEADEW.Controllers
{
    public class AdmissionController : ApiController
    {

        DataSet _dataSet = null;
        BAdmission _admission = null;
        [HttpGet]
        public IHttpActionResult GetAllAdmissionDetails(int userId)
        {
            try
            {
                _admission = new MSEADEW_BAL.BAL.Admissions.BAdmission();
                if (userId > 0)
                {
                    _dataSet = _admission.GetAllAdmissionDetails(userId);
                }
                else
                {
                    _dataSet = _admission.GetAllAdmissionDetails(null);
                }
                return Ok(_dataSet);
            }
            catch (Exception exception)
            {
                return InternalServerError(exception);
            }
        }
        public IHttpActionResult GetAdmissionDetailsById(int educationLevelId,int admissionId, int userId)
        {
            try
            {
               
                _admission = new MSEADEW_BAL.BAL.Admissions.BAdmission();

                if (admissionId > 0)
                {
                    _dataSet = _admission.GetAdmissionDetailsById(educationLevelId,admissionId, userId);
                }
                else
                {
                    throw new ArgumentException("Invalid Parameters Provided.");
                }
                return Ok(_dataSet);
            }
            catch (Exception exception)
            {


                return InternalServerError(exception);
            }
        }

        [HttpPost]
        public IHttpActionResult UpdateAdmission(MSEADEW_BAL.BAL.Admissions.BAdmission en)
        {
            try
            {
                var result = new Dictionary<string, object>();
                int newAdmissionId;

                _admission = new MSEADEW_BAL.BAL.Admissions.BAdmission();
                if (en != null)
                {
                    newAdmissionId = _admission.UpdateAdmission(en);
                    result.Add("Success", true);
                    result.Add("AdmissionId", newAdmissionId.ToString());
                }
                else
                {
                    result.Add("Success", false);
                }

                return Ok(result);
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }

        }

    }
}
