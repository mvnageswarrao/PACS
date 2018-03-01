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
    public class pacsHTMLDiv : HtmlDiv
    {
        public pacsHTMLDiv(UITestControl parent) : base(){}

        public pacsHTMLDiv(UITestControl parent, string ID)
        {
            this.SearchProperties[HtmlDiv.PropertyNames.Id] = ID;
        }
    }
}
