using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebClientService.Common
{
    [Serializable]
    public class ThiSinhLogin
    {
        public int ThiSinhID { set; get; }
        public string ThiSinhName { set; get; }
    }
}