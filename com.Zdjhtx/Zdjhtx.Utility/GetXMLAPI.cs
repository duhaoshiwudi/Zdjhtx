using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Zdjhtx.Model;

namespace Zdjhtx.Utility
{
    public static partial class GetXMLAPI
    {
        public static PhoneNumInfo PostData(string url, string param, String tableName)
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

            if (ds != null && ds.Tables.Count > 0)
            {
                dt = ds.Tables[0].Copy();
                var row = dt.Rows[0];
                return new PhoneNumInfo()
                {
                    chgmobile = Converter.TryToString(row["chgmobile"], string.Empty),
                    city = Converter.TryToString(row["city"], string.Empty),
                    province = Converter.TryToString(row["province"], string.Empty),
                    retmsg = Converter.TryToString(row["retmsg"], string.Empty),
                    supplier = Converter.TryToString(row["supplier"], string.Empty)
                };
            }
            else
            {
                return null;
            }
            #endregion
        }
    }
}
