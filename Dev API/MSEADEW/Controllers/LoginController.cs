using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Net.Http.Headers;
using MSEADEW.Providers;
using System.Data;
using ApplicationUtility;
using System.Data.SqlClient;
using MSEADEW_BAL.BAL;
using MSEADEW_BAL.BAL.Admin;
using MSEADEW_DAL.DAL;
using System.Net.Http.Formatting;

namespace MSEADEW.Controllers
{
    public class LoginController : ApiController
    {

        private static Providers.Token _myToken;
        public static string ApiUri = ConfigurationManager.AppSettings["RedirectUrl"].ToString();


        private static async Task<HttpResponseMessage> CallApiTask(string apiEndPoint,
       Dictionary<string, string> model = null)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(ApiUri);
                client.DefaultRequestHeaders.Accept.Clear();
                if (_myToken != null)
                {
                    client.DefaultRequestHeaders.Authorization = new
                   AuthenticationHeaderValue("Bearer",
                    _myToken.AccessToken);
                }
                else
                {
                    client.DefaultRequestHeaders.Accept.Add(new
                   MediaTypeWithQualityHeaderValue("application/json"));
                }
                return await client.PostAsync(apiEndPoint, model != null ? new
               FormUrlEncodedContent(model) : null);
            }
        }

        //[HttpGet]

        //public IHttpActionResult logout1()
        //{
        //    string lancode = checkLanguage();

        //    return Ok();
        //}

        //public string checkLanguage()
        //{

        //    var lan = Request.Headers.GetValues("SelectedLanguage");
        //    var lantoken = lan.FirstOrDefault();
        //    string[] tokens = lantoken.Split(':');
        //    string lancode = tokens[1];
        //    return lancode;
        //}
        [HttpGet]
        [Authorize]
        public IHttpActionResult logout()
        {

            var lan = Request.Headers.GetValues("SelectedLanguage");

            var lanwer = Request.Headers.GetValues("Authorization");
           // string lancode = checkLanguage();
            return Ok();
        }

        [HttpGet]
        public IHttpActionResult RecoverPassword(string UserName)
        {
            try
            {
                BLogin login = new BLogin();
                var found = login.RecoverPassword(UserName);
                // SendEmail.SendpasswordthroughEmail(UserName, found.First_Name, EncryptAndDecryptPassword.Decrypt(found.Password));
                return Ok();

            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }


        [HttpPost]
        public async Task<IHttpActionResult> ValidateUser(MSEADEW_BAL.BAL.Admin.Login iuc)
        {

            var result = new Dictionary<string, object>();
            try
            {
                if ((iuc.userName != null || iuc.userName != string.Empty) && (iuc.password != null || iuc.password == string.Empty))
                {
                    if (String.IsNullOrEmpty(iuc.userName) || String.IsNullOrEmpty(iuc.password))
                    {
                        throw new ArgumentNullException();
                    }
                    var tokenModel = new Dictionary<string, string>
                 {
                 {"grant_type", "password"},
                 {"username", iuc.userName},
                 {"password", iuc.password},
                 };
                    var response = await CallApiTask("api/authtoken", tokenModel);
                    if (!response.IsSuccessStatusCode)
                    {
                        var errors = await response.Content.ReadAsStringAsync();
                        throw new Exception(errors);
                    }

                    _myToken = response.Content.ReadAsAsync<Token>(new[] { new JsonMediaTypeFormatter() }).Result;
                    result.Add("Success", true);
                    result.Add("Data", _myToken);
                }
                else
                {
                    result.Add("Success", false);
                    result.Add("Data", "Username or Password cannot be Empty");
                }
                return Ok(result);
            }
            catch (Exception E)
            {
                result.Add("Success", false);
                result.Add("Data", "Username or Password is Incorrect");
                return Ok(result);
            }
        }


        [HttpGet]
        public IHttpActionResult GetInvalidCount(string UserName)
        {
            try
            {
                //using (entityobj = new IFIIEntities())
                //{
                //    var userInvalidAttempts = entityobj.TIDB_User.ToList().Where(x => x.Username == UserName).FirstOrDefault();
                //    return Ok(userInvalidAttempts.Invalid_Attempts_Count);
                //}
                return Ok();
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }
    }
}
