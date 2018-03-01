using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestAutomation_PACSSystem_Controls.Webcontrols;
using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;
using Microsoft.VisualStudio.TestTools.UITesting;

namespace TestAutomation_PACSSystem_Controls.Webcontrols
{
    public class pacsHTMLDocument : HtmlDocument
    {

        public pacsHTMLDocument(UITestControl parent) : base(parent){}

        public pacsHTMLDocument(UITestControl parent, string WindowTitle) : base(parent)
        {

            this.SearchProperties[HtmlDocument.PropertyNames.Id] = null;
            //this.SearchProperties[HtmlDocument.PropertyNames.RedirectingPage] = "False";
            //this.SearchProperties[HtmlDocument.PropertyNames.FrameDocument] = "False";
            //this.FilterProperties[HtmlDocument.PropertyNames.Title] = "PACS | Villa Plus";
            //this.FilterProperties[HtmlDocument.PropertyNames.Title] = Id;
            //this.FilterProperties[HtmlDocument.PropertyNames.AbsolutePath] = "/pacssystem.html";
           // this.FilterProperties[HtmlDocument.PropertyNames.PageUrl] = PageURL;
            //this.FilterProperties[HtmlDocument.PropertyNames.PageUrl] = "http://192.168.1.7/pacssystem.html";
            this.WindowTitles.Add(WindowTitle);
            //this.WindowTitles.Add("http://192.168.1.7/ - PACS | Villa Plus");
        }

    }
}
