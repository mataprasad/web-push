using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using Dapper;
using System.Net;
using Newtonsoft.Json.Linq;

namespace FcmDemo.Model
{
    public class BizAccess
    {
        private SqlConnection _con = null;

        public BizAccess()
        {
            _con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnectionString"].ConnectionString);
        }

        public void AddTokenToDb(string token, string raw_req)
        {
            var sql = @"
                        IF NOT EXISTS (SELECT 1 FROM DtClient WHERE Token='{0}')
                        BEGIN
	                        INSERT INTO DtClient SELECT '{0}','{1}';
                        END";
            _con.Execute(String.Format(sql, token, raw_req));
        }

        public Tuple<string, string, string, string> GetGcmConfig()
        {
            Tuple<string, string, string, string> result = null;
            var sql = @"SELECT TOP 1 ApiKey,AuthDomain,SenderId,ServerKey FROM DTFcmConfig";
            using (var rd = _con.ExecuteReader(sql))
            {
                if (rd.Read())
                {
                    result = new Tuple<string, string, string, string>
                    (rd.GetString(0), rd.GetString(1), rd.GetString(2), rd.GetString(3));
                }
            }

            return result;
        }

        public bool SetGcmConfig(string key, string auth_domain, string sender_id, string server_key)
        {
            var sql = @"Update DTFcmConfig SET ApiKey='{0}',AuthDomain='{1}',SenderId='{2}',ServerKey='{3}';";
            _con.Execute(String.Format(sql, key, auth_domain, sender_id, server_key));
            return true;
        }

        public List<dynamic> GetAddedClients()
        {
            return _con.Query("SELECT * FROM DTClient").ToList();
        }

        public static string BaseSiteUrl
        {
            get
            {
                HttpContext context = HttpContext.Current;
                string baseUrl = context.Request.Url.Scheme + "://" + context.Request.Url.Authority + context.Request.ApplicationPath.TrimEnd('/');
                return "http://web-push.apphb.com";
            }
        }

        public static string SendPushMessage(string serverKey, string to, string title, string body, string icon, string click_action)
        {
            WebClient client = new WebClient();
            client.Headers.Add("Authorization", "key=" + serverKey);
            client.Headers.Add("Content-Type", "application/json");

            var fcm_message = new FcmMessage();
            fcm_message.to = to;
            fcm_message.data = new FcmMessage_Data();
            fcm_message.data.body = body;
            fcm_message.data.click_action = click_action;
            fcm_message.data.icon = icon;
            fcm_message.data.title = title;

            var payload = Newtonsoft.Json.JsonConvert.SerializeObject(fcm_message);
            return client.UploadString("https://fcm.googleapis.com/fcm/send", "POST", payload);
        }
    }
    public class FcmMessage
    {
        public FcmMessage_Data data { get; set; }
        public string to { get; set; }

    }
    public class FcmMessage_Data
    {
        public string title { get; set; }
        public string body { get; set; }
        public string icon { get; set; }
        public string click_action { get; set; }
    }
}
