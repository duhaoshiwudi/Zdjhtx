using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Xml;
using Zdjhtx.Model;
using Zdjhtx.Utility;

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
            string resultType = string.Empty;
            string msg = string.Empty;

            System.Text.StringBuilder param = new System.Text.StringBuilder();
            param.AppendFormat("chgmobile={0}", Phone);

            string url = ConfigurationManager.AppSettings["numberInfoUrl"];

            PhoneNumInfo info = GetXMLAPI.PostData(url, param.ToString());

            if (info != null)
            {
                if (info.retmsg.Trim() == "OK")
                {
                    if (info.city.Trim() == "北京" && info.supplier.Trim() == "移动")
                    {
                        msg = "OK";
                        resultType = "符合活动电话号";
                    }
                    else
                    {
                        resultType = info.city + info.supplier;
                    }
                }
                else
                {
                    resultType = "获取归属地失败";
                }
            }
            return Json(new { Message = msg, ResultType = resultType }, JsonRequestBehavior.AllowGet);
        }
    }
}
