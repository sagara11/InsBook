using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using Model.Dao;

namespace InsBook.Hubs
{
    public class ChatHub : Hub
    {
        // chat.server.tenham
        public void Send(string name, string message)
        {
            // chat.client.tenham
            string haha = name + ' ' + message;
            int id = new LocationDao().GetByName("Thanh Hóa");
            Clients.All.addNewMessageToPage(name, message);
            Clients.All.sannnn(haha, id);
        }

        public void San(string name, string message)
        {
            var haha = "haa";
        }
    }
}