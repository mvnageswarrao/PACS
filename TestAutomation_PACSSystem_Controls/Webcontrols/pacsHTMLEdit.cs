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
    public  class pacsHTMLEdit : HtmlEdit
    {
        public pacsHTMLEdit(UITestControl parent) : base(){}

        public pacsHTMLEdit(UITestControl parent, String Type) : base(parent)
        {
            this.SearchProperties[HtmlEdit.PropertyNames.Type] = Type;
        }
        
    }
}
