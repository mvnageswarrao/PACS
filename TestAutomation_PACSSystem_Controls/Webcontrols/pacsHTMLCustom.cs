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
    public  class pacsHTMLCustom : HtmlCustom
    {
        public pacsHTMLCustom(UITestControl parent) : base(parent){}

        public pacsHTMLCustom(UITestControl parent, string tag) : base(parent)
        {
            this.SearchProperties[HtmlCustom.PropertyNames.TagName] = tag;

        }
    }
}
