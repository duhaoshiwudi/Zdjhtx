using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Xml;
using Zdjhtx.UI.Models;

namespace com.Zdjhtx.Controllers.WAP
{
    public class PhoneFeesController : Controller
    {
        //
        // GET: /PhoneFees/

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GetPhoneLocation(string Phone)
        {
            string result = "无此号码！";

            System.Text.StringBuilder param = new System.Text.StringBuilder();
            param.AppendFormat("chgmobile={0}", Phone);

            string url = "http://life.tenpay.com/cgi-bin/mobile/MobileQueryAttribution.cgi";

            DataTable dtResult = PostData(url, param.ToString(), "PhoneNumInfo");

            if (dtResult != null && dtResult.Rows.Count > 0)
            {
                if (dtResult.Rows[0]["retmsg"].ToString().Trim() == "OK")
                {
                    if (dtResult.Rows[0]["city"].ToString().Trim() == "北京" && dtResult.Rows[0]["supplier"].ToString().Trim() == "移动")
                    {
                        result = "OK";
                    }
                    else
                    {
                        result = "不是北京移动号码！";
                    }    
                }
            }
            return Content(result); ;
        }

        public static DataTable PostData(string url, string param, String tableName)
        {
            #region post数据
            DataSet ds = new DataSet(); DataTable dt = new DataTable();
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
            req.Timeout = 120000;
            byte[] requestbytes = System.Text.Encoding.ASCII.GetBytes(param);
            req.Method = "post";
            req.ContentType = "application/x-www-form-urlencoded";
            req.ContentLength = requestbytes.Length;
            System.IO.Stream requeststream = req.GetRequestStream();
            requeststream.Write(requestbytes, 0, requestbytes.Length);
            requeststream.Close();
            HttpWebResponse res = (HttpWebResponse)req.GetResponse();
            System.IO.StreamReader sr = new System.IO.StreamReader(res.GetResponseStream(), System.Text.Encoding.Default);

            String backstr = sr.ReadToEnd();
            StringReader txtReader = new StringReader(backstr);
            XmlTextReader xmlReader = new XmlTextReader(txtReader);
            try
            {
                ds.ReadXml(xmlReader);
            }
            catch
            {
                return null;
            }
            sr.Close();
            res.Close();
            sr.Dispose();

            //条件判断
            if (ds != null && ds.Tables.Count > 0)
            {
                dt = ds.Tables[0].Copy();
            }
            return dt;
            #endregion
        }

    }
}
