using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;

namespace MvcApplication.Controllers
{
    // this class call the messenger program
    public class ExecuteController : Controller
    {
        [HttpPost]
        public void Index(string requestUrl, string groupname)
        {
            //setting variables
            string messengerPath = System.Web.Hosting.HostingEnvironment.ApplicationPhysicalPath
            + "..\\Messenger\\bin\\Debug\\";
            string messengerName = "Messenger.exe";
            string consoleAppPath = System.Net.WebUtility.UrlEncode(System.Web.Hosting.HostingEnvironment.ApplicationPhysicalPath
            + "..\\ConsoleApplication\\bin\\Debug\\");
            string consoleAppName = "ConsoleApplication.exe";

            // create new process
            Process p = new Process();

            // the messenger program location here
            string FileName = messengerPath + messengerName;
            p.StartInfo.FileName = FileName;
            p.StartInfo.Arguments = requestUrl + " " + groupname + " " + consoleAppPath + " " + consoleAppName;

            // we dont want to show the console of course
            p.StartInfo.UseShellExecute = false;

            // start the process
            p.Start();

            // wait for its exit
            p.WaitForExit();
        }
    }
}
