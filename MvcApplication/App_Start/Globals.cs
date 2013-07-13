using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcApplication.App_Start
{
    // this class is where we put some hardcoded data
    public class Globals
    {
        // the messenger program path
        public static string messengerPath = System.Web.HttpUtility.UrlEncode(System.Web.Hosting.HostingEnvironment.ApplicationPhysicalPath  
            + "..\\Messenger\\bin\\Debug\\");

        // the messenger program name
        public static string messengerName = "Messenger.exe";

        // the external consol app path
        public static string consoleAppPath = System.Web.HttpUtility.UrlEncode(System.Web.Hosting.HostingEnvironment.ApplicationPhysicalPath 
            + "..\\ConsoleApplication\\bin\\Debug\\");
    
        // the external consol app name
        public static string consoleAppName = "ConsoleApplication.exe";
    }
}