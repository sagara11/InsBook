using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InsBook.Areas.Client.code
{
    [Serializable]
    public class UserSession
    {
        public string UserName { get; internal set; }
    }
}