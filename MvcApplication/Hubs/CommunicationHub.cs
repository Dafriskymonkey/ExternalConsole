using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using System.Threading.Tasks;

namespace MvcApplication.Hubs
{
    // SignalR Hub Class that will contain server methods
    public class CommunicationHub : Hub
    {

        public void Send(string message)
        {
            // Call the addNewMessageToPage method to update clients.
            Clients.All.addNewMessageToPage(message);
        }

        public void SendToGroup(string groupname, string message)
        {
            // call the addMessage method for clients in the group named groupname 
            Clients.Group(groupname).addMessage(message);
        }

        public Task JoinGroup(string groupName)
        {
            // add the client (ConnectionId) to the group named groupname
            return Groups.Add(Context.ConnectionId, groupName);
        }

        public Task LeaveGroup(string groupName)
        {
            // remove the client (ConnectionId) from the group named groupname
            return Groups.Remove(Context.ConnectionId, groupName);
        }
    }
}