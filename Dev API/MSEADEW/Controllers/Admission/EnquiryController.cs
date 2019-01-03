using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Web.Http;
using System.Runtime.InteropServices;
using Newtonsoft.Json;
using System.Web;
using System.Net;
using MSEADEW_DAL.DAL.Admissions;
using MSEADEW_BAL;
using MSEADEW.Helper;
using MSEADEW_BAL.BAL.Admissions;
using System.Collections.Generic;

namespace MSEADEW.Controllers
{
    public class EnquiryController : ApiController
    {
        private string _resultJson = string.Empty;
        private DataSet _dataSet=null;
        BEnquiry _enquiry = null;
        [HttpGet]
        public IHttpActionResult GetAllEnquiryDetails(int userId)
        {
            try
            {
                //ADO.NET
               // int? userId = null;
                 _enquiry = new BEnquiry();
          
                if (userId == 0)
                {
                    var req = HttpContext.Current.Request.Headers.GetValues("userId");
                    userId = LoggedInUser.GetUserId(req);
                    _dataSet = _enquiry.GetAllEnquiries(userId);
                }
                else
                {
                    _dataSet = _enquiry.GetAllEnquiries(userId);
                }
                return Ok(_dataSet);
            }
            catch (Exception exception)
            {


                return InternalServerError(exception);
            }
        }
        [HttpGet]
        public IHttpActionResult GetEnquiryDetailsById(int enquiryId)
        {
            try
            {
               _enquiry = new BEnquiry();
                _dataSet = _enquiry.GetEnquiryByID(enquiryId);

                return Ok(_dataSet);
            }
            catch (Exception exception)
            {
                return InternalServerError(exception);
            }
        }
        [HttpPost]
        public IHttpActionResult UpdateEnquiry(Enquiry en)
        {
            var result = new Dictionary<string, object>();
            try
            {
                string newEnquiryId=string.Empty;
                _enquiry = new BEnquiry();
                if (en != null)
                {                  

                    newEnquiryId = _enquiry.UpdateEnquiry(en);
                    result.Add("Success", true);
                    result.Add("EnquiryId", newEnquiryId);
                }
                else
                {
                    result.Add("Success", false);
                    result.Add("Data", "Could not add Enquiry Details,Please try again");
                }

                return Ok(result);
            }
            catch (Exception e)
            {
                result.Add("Success", false);
                result.Add("Data", "Could not add Enquiry Details,Please try again");
                return Ok(result);
            }
            
        }


    }

}
