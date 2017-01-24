using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

namespace FcmDemo.Model
{
    public class SwHandler : IHttpHandler
    {
        public bool IsReusable
        {
            get
            {
                return true;
            }
        }

        public void ProcessRequest(HttpContext context)
        {
            var biz = new BizAccess();
            var config = biz.GetGcmConfig();
            context.Response.Clear();
            context.Response.ContentType = "application/javascript";
            var sw_file = context.Server.MapPath("~/firebase-messaging-sw.js.temp");
            var data = File.ReadAllText(sw_file);
            if (config != null)
            {
                data = data.Replace("###API_KEY###", config.Item1);
                data = data.Replace("###AUTH_DOMAIN###", config.Item2);
                data = data.Replace("###MESSAGING_SENDER_ID###", config.Item3);
            }
            context.Response.Write(data);
        }
    }
}