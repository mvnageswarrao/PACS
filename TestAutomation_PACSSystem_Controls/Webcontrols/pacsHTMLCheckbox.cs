using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;
using Microsoft.VisualStudio.TestTools.UITesting;

namespace TestAutomation_PACSSystem_Controls.Webcontrols
{
    class pacsHTMLCheckbox : HtmlCheckBox
    {
        public pacsHTMLCheckbox(UITestControl parent) : base(parent){}

        public pacsHTMLCheckbox (UITestControl parent, string id) : base(parent)
	    {
            //this.mUIYPane.FilterProperties[HtmlDiv.PropertyNames.InnerText] = "Y";
	    }              
        
       
    }
}
