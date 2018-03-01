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
    public class pacsHTMLTextArea : HtmlTextArea
    {
        public pacsHTMLTextArea(UITestControl parent) : base(){}

        public pacsHTMLTextArea(UITestControl parent, string ID): base(parent)
        {
            this.SearchProperties[HtmlEdit.PropertyNames.Id] = ID;
                
        }

    }
}
