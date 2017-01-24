using FcmDemo.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FcmDemo
{
    public partial class ajax : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod]
        public static bool settoken(string token)
        {
            var raw_req = JsonConvert.SerializeObject(RawRequest.FromRequest(HttpContext.Current.Request));
            var _biz = new BizAccess();
            _biz.AddTokenToDb(token, raw_req);
            return true;
        }
    }

    public class RawRequest
    {
        public static RawRequest FromRequest(HttpRequest rq)
        {
            RawRequest obj = new RawRequest()
            {
                UserAgent = rq.UserAgent,
                UserHostAddress = rq.UserHostAddress,
                UserHostName = rq.UserHostName,
                UserLanguages = rq.UserLanguages,
            };
            return obj;
        }
        public string UserAgent { get; set; }
        public string UserHostAddress { get; set; }
        public string UserHostName { get; set; }
        public string[] UserLanguages { get; set; }
    }
}