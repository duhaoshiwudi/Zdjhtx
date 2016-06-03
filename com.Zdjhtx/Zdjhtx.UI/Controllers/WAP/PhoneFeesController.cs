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
            string result = "无此号码！";

            System.Text.StringBuilder param = new System.Text.StringBuilder();
            param.AppendFormat("chgmobile={0}", Phone);

            string url = ConfigurationManager.AppSettings["numberInfoUrl"];

            PhoneNumInfo info = GetXMLAPI.PostData(url, param.ToString(), "PhoneNumInfo");

            if (info != null)
            {
                if (info.retmsg.Trim() == "OK")
                {
                    if (info.city.Trim() == "北京" && info.supplier.Trim() == "移动")
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
    }
}
