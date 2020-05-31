using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace InsBook.Hubs
{
    public class SessionHub : Hub
    {
        public void CheckOnline(int userID)
        {
            Clients.All.Online(userID);
        }
    }
}