using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestAutomation_PACSSystem_Controls.Webcontrols;
using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;
using Microsoft.VisualStudio.TestTools.UITesting;
using TestAutomation_PACSSystem.Utilities;
using System.Configuration;

namespace TestAutomation_PACSSystem.UIMaps.LoginPage
{
    class mainMenuPage : logWriter
    {

        pacsHTMLWindow _mainPageWindow;
        pacsHTMLDocument _mainPageDoc;
        pacsHTMLImage _createNewPACsIcon;

        string strURL = ConfigurationManager.AppSettings["URL"].ToString();

        public mainMenuPage()
        {
            _mainPageWindow = new pacsHTMLWindow(strURL, strURL, "PACS | Villa Plus");
            _mainPageDoc = new pacsHTMLDocument(_mainPageWindow, "http://192.168.1.7/ - PACS | Villa Plus");
            _createNewPACsIcon = new pacsHTMLImage(_mainPageDoc, "imgCreateNewPacs", "PACS | Villa Plus");
        }

        public void clickcreateNewPackIcon()
        {
            try
            {
                Mouse.Click(_createNewPACsIcon);
                WriteLogs("PASS : Clicked on Create PACS Icon : VERIFICATION");
            }
            catch (Exception ex)
            {
                WriteLogs("FAIL : Not Clicked on the Create PACS Icon : VERIFICATION");
                WriteLogs("------------" + ex.Message.ToString());
            }
        }

        public void selectExistingBookRefPACS(HtmlCustom clickExistingSavedPACS)
        {
            try
            {
                Mouse.Click(clickExistingSavedPACS);
                WriteLogs("PASS : Clicked on the Existing Saved PACS Icon from Main Menu Page - " + clickExistingSavedPACS.InnerText + " : VERIFICATION");
            }
            catch (Exception ex)
            {
                WriteLogs("FAIL : Not able to Click on the Existing Saved PACS Icon from Main Menu Page : VERIFICATION");
                WriteLogs("----------" + ex.Message.ToString());
            }
        }
    }
}

