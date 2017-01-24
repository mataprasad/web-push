using FcmDemo.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FcmDemo
{
    public partial class FcmConfig : System.Web.UI.Page
    {
        private BizAccess _biz = new BizAccess();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var config = _biz.GetGcmConfig();
                if (config != null)
                {
                    lblApiKey.Text = config.Item1;
                    lblAuthDomain.Text = config.Item2;
                    lblSenderId.Text = config.Item3;
                    lblServerKey.Text = config.Item4;
                }
            }
        }

        protected void btnUpdateConfig_Click(object sender, EventArgs e)
        {
            _biz.SetGcmConfig(lblApiKey.Text.Trim(), lblAuthDomain.Text.Trim(), lblSenderId.Text.Trim(), lblServerKey.Text.Trim());
            lblStatus.Text = "Updated Successfully.";
            lblStatus.ForeColor = System.Drawing.Color.Green;
        }
    }
}