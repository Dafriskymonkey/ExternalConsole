using Microsoft.AspNet.SignalR.Client.Hubs;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messenger
{
    // this program will be the link between our mvc app and the console program
    // it will launch the console program and send its outputs to the mvc app using SignalR
    class Program
    {
        public static void Main(string[] args)
        {
            if (args.Length > 3)
            {
                // retrieve the request.url from the list of args
                string requestUrl = args[0];

                // Connect to the service
                var hubConnection = new HubConnection(requestUrl);

                // Create a proxy to the chat service
                var comm = hubConnection.CreateHubProxy("communicationHub");

                // Start the connection
                hubConnection.Start().Wait();

                // join the group sent by the client
                string groupname = args[1];
                comm.Invoke("JoinGroup", groupname);

                // create a new procees
                Process p = new Process();

                // here we get the app physical path trough the arguments list, then we decode it
                string workingDirectory = System.Net.WebUtility.UrlDecode(args[2]);

                // define process working directory
                p.StartInfo.WorkingDirectory = workingDirectory;

                // define process filename based on process working directory
                p.StartInfo.FileName = workingDirectory + args[3];

                // we force to not execute in a shell
                p.StartInfo.UseShellExecute = false;
                // we redirect outputs in order so we can send them to the mvc app
                p.StartInfo.RedirectStandardOutput = true;

                // starting the procss
                p.Start();

                // outputs will be redirected in this streamreader
                StreamReader myStreamReader = p.StandardOutput;

                // this loop will execute till there is no output
                while (true)
                {
                    // capture the output from the external program
                    string line = myStreamReader.ReadLine();

                    // if null then there is no more outputs, leave the loop
                    if (line == null) break;

                    // send the output to the mvc app
                    comm.Invoke("SendToGroup", groupname, line).Wait();
                }

                // wait for the process to exit
                p.WaitForExit();
            }
        }
    }
}
