using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Zdjhtx.UI.Models
{
    public class PhoneNumInfo
    {
        /// <summary>
        /// 省
        /// </summary>
        public string province { get; set; }
        /// <summary>
        /// 移动联通电信
        /// </summary>
        public string catName { get; set; }

        /// <summary>
        /// 归属地
        /// </summary>
        public string carrier { get; set; }

        /// <summary>
        /// 电话号码
        /// </summary>
        public string telString { get; set; }
    }
}