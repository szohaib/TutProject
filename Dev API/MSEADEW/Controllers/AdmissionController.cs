using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MSEADEW_DAL.DAL;
using MSEADEW_BAL.BAL;

namespace MSEADEW.Controllers
{
    public class AdmissionController : ApiController
    {

        DataSet _dataSet = null;
        MSEADEW_BAL.BAL.BAdmission _admission = null;
        [HttpGet]
        public IHttpActionResult GetAllAdmissionDetails(int userId)
        {
            try
            {
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
        public IHttpActionResult GetAdmissionDetailsById(int admissionId,int userId)
        {
            try
            {
                //ADO.NET
                // int? userId = null;

                if (admissionId >0)
                {
                    _dataSet = _admission.GetAdmissionDetailsById(admissionId, userId);
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
        public IHttpActionResult UpdateAdmission(Admission en)
        {
            try
            {
                var result = new Dictionary<string, object>();
                int newAdmissionId;
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
