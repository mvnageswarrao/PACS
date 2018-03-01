using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;
using Microsoft.VisualStudio.TestTools.UITesting;

namespace TestAutomation_PACSSystem_Controls.Webcontrols
{
   public class pacsHTMLWindow : BrowserWindow
    {
       public pacsHTMLWindow(UITestControl parent) : base() { }

        public pacsHTMLWindow(string name, string windowTitle1, string windowtitle2)
        {
            // TODO: Complete member initialization
            //this.SearchProperties[UITestControl.PropertyNames.Name] = "http://192.168.1.7/pacssystem.html";
            //this.SearchProperties[UITestControl.PropertyNames.ClassName] = "IEFrame";
            //this.WindowTitles.Add("http://192.168.1.7/pacssystem.html");
            //this.WindowTitles.Add("PACS | Villa Plus");

            this.SearchProperties[UITestControl.PropertyNames.Name] = name;
            this.SearchProperties[UITestControl.PropertyNames.ClassName] = "IEFrame";
            this.WindowTitles.Add(windowTitle1);
            this.WindowTitles.Add(windowtitle2);
        }
        
       public pacsHTMLWindow(string name, string windowTitle1)
        {
            // TODO: Complete member initialization
            //this.SearchProperties[UITestControl.PropertyNames.Name] = "http://192.168.1.7/pacssystem.html";
            //this.SearchProperties[UITestControl.PropertyNames.ClassName] = "IEFrame";
            //this.WindowTitles.Add("http://192.168.1.7/pacssystem.html");
            //this.WindowTitles.Add("PACS | Villa Plus");

            this.SearchProperties[UITestControl.PropertyNames.Name] = name;
            this.SearchProperties[UITestControl.PropertyNames.ClassName] = "IEFrame";
            this.WindowTitles.Add(windowTitle1);
           
            
        }

        public void LaunchUrl(string url)
        {
            this.CopyFrom(BrowserWindow.Launch(url));
        }

        

    }
}
