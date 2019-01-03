using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MSEADEW.Helper
{
    public class LoggedInUser
    {
        public static int GetUserId(dynamic req)
        {
            try
            {
                string[] tokens = req[0].ToString().Split(' ');
                int userId = Convert.ToInt32(tokens[1]);
                return userId;
            }
            catch (Exception e)
            {
                return 0;

            }


        }
    }
}