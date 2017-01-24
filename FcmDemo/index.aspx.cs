using FcmDemo.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FcmDemo
{
    public partial class index : System.Web.UI.Page
    {
        private BizAccess _biz = new BizAccess();
        public string baseUrl = "";
        public string configApiKey = "";
        public string configAuthDomain = "";
        public string configSenderId = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            baseUrl = BizAccess.BaseSiteUrl;
            var config = _biz.GetGcmConfig();
            if (config != null)
            {
                configApiKey = config.Item1;
                configAuthDomain = config.Item2;
                configSenderId = config.Item3;
            }
        }
    }
}