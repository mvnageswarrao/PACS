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
    public  class pacsHTMLImage : HtmlImage
    {

        public pacsHTMLImage(UITestControl parent) : base(){}

        public pacsHTMLImage (UITestControl parent, string ID, string windowtitle) : base(parent)
	    {
            this.SearchProperties[HtmlImage.PropertyNames.Id] = ID;            
            this.WindowTitles.Add(windowtitle);           

	    }
       

    }
}
