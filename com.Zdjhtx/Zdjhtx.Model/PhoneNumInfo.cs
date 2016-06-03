using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zdjhtx.Model
{
    public class PhoneNumInfo
    {
        /// <summary>
        /// 电话号码
        /// </summary>
        public string chgmobile { get; set; }

        /// <summary>
        /// 城市
        /// </summary>
        public string city { get; set; }

        /// <summary>
        /// 省份
        /// </summary>
        public string province { get; set; }

        /// <summary>
        /// 返回结果
        /// </summary>
        public string retmsg { get; set; }

        /// <summary>
        /// 运营商
        /// </summary>
        public string supplier { get; set; }
    }
}
