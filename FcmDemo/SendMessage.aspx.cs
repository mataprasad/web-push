using FcmDemo.Model;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FcmDemo
{
    public partial class SendMessage : System.Web.UI.Page
    {
        private BizAccess _biz = new BizAccess();

        protected void Page_Load(object sender, EventArgs e)
        {
            txtTitle.Text = "PushMessage from FCM for WebSite";
            txtBody.Text = "Hey...";
            txtIcon.Text = BizAccess.BaseSiteUrl + "/images/icon.png";
            txtClickAction.Text = "";

        }

        protected void btnUpdateConfig_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(txtBody.Text))
            {
                return;
            }
            var selected_ids = new List<string>();
            var config = _biz.GetGcmConfig();
            if (config != null)
            {
                foreach (GridViewRow gvRow in gvClientTokens.Rows)
                {
                    if (gvRow.RowType == DataControlRowType.DataRow)
                    {
                        var chk = (CheckBox)gvRow.FindControl("chkSelected");
                        if (chk != null && chk.Checked)
                        {
                            selected_ids.Add(Convert.ToString(gvRow.Cells[2].Text));
                        }
                    }
                }
            }

            if (selected_ids.Count > 0)
            {
                System.Threading.ThreadPool.QueueUserWorkItem((o) =>
                {
                    foreach (var id in selected_ids)
                    {
                        BizAccess.SendPushMessage(config.Item4, id, txtTitle.Text.Trim(), txtBody.Text.Trim(), txtIcon.Text.Trim(), txtClickAction.Text.Trim());
                    }
                });
            }
        }
    }
}