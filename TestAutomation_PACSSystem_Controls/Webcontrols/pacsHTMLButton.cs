using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;
using Microsoft.VisualStudio.TestTools.UITesting;

namespace TestAutomation_PACSSystem_Controls.Webcontrols
{
   public  class pacsHTMLButton : HtmlDiv
    {     

        public pacsHTMLButton(UITestControl parent) : base(parent){}

        public pacsHTMLButton(UITestControl parent, string Id, string Innertext) : base(parent)
	    {

            this.SearchProperties[HtmlDiv.PropertyNames.Id] = Id;
            this.FilterProperties[HtmlDiv.PropertyNames.InnerText] = Innertext;
        }     

          
    }
}
