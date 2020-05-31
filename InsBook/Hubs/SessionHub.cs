using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using InsBook.Common;
using Microsoft.AspNet.SignalR;

namespace InsBook.Hubs
{
    public class SessionHub : Hub
    {
        public void CheckOnline(int userID)
        {
            CommonConstants.USER_ONLINE.Remove(userID);
            Clients.All.Online(userID);
        }
        public void CheckLogin(int userID)
        {
            CommonConstants.USER_ONLINE.Add(userID);
            Clients.All.Login(userID);
        }
    }
}