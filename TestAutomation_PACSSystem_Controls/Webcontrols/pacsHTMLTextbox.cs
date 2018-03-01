using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;
using Microsoft.VisualStudio.TestTools.UITesting;

namespace TestAutomation_PACSSystem_Controls.Webcontrols
{
    public class pacsHTMLTextbox : HtmlEdit
    {
        public pacsHTMLTextbox(UITestControl parent) : base(parent) { }

        public pacsHTMLTextbox(UITestControl parent, string Id, string Type) : base(parent)
	    {                    
            this.SearchProperties[HtmlEdit.PropertyNames.Id] = Id;
            this.SearchProperties[HtmlEdit.PropertyNames.Type] = Type;            
            //this.SearchProperties[HtmlEdit.PropertyNames.Name] = null;
            //this.SearchProperties[HtmlEdit.PropertyNames.LabeledBy] = null;
            
                    
	    }         
       

    }
}
