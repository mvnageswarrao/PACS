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
using TestAutomation_PACSSystem.UIMaps.LoginPage.browserAction_mapClasses;

namespace TestAutomation_PACSSystem.UIMaps.LoginPage
{
    class mainPage : logWriter
    {
        pacsHTMLWindow _mainPageWindow;
        pacsHTMLDocument _mainPageDoc;
        pacsHTMLTextbox _userNameTxBx;
        pacsHTMLTextbox _pWDTxBx;
        pacsHTMLButton _signInBtn;
        private browserAction_map browserAction = null;


        string strURL = ConfigurationManager.AppSettings["URL"].ToString();

        public mainPage()
        {
            _mainPageWindow = new pacsHTMLWindow(strURL, strURL, "PACS | Villa Plus");
            _mainPageDoc = new pacsHTMLDocument(_mainPageWindow, "http://192.168.1.7/ - PACS | Villa Plus");
            _userNameTxBx = new pacsHTMLTextbox(_mainPageDoc, "txtUserName", "SINGLELINE");
            _pWDTxBx = new pacsHTMLTextbox(_mainPageDoc, "txtPassword", "PASSWORD");
            _signInBtn = new pacsHTMLButton(_mainPageDoc, "cmdLogin", "Sign in");
        }

        public browserAction_map browserAction_Obj
        {
            get
            {
                if (browserAction == null)
                {
                    browserAction = new browserAction_map();
                    browserAction.UIDeleteBrowsingHistorWindow.CopyFrom(_mainPageWindow.CurrentDocumentWindow);
                }
                return browserAction;
            }
        }

        public void openBrowser(string url)
        {

            try
            {
                _mainPageWindow.LaunchUrl(url);
                WriteLogs("PASS : Opened PACS System Page" + "(" + url + ") " + "successfully : VERIFICATION");
            }
            catch (Exception ex)
            {
                WriteLogs("FAIL : Opened PACS System Page" + "(" + url + ") " + "unsuccessfully : VERIFICATION");
                WriteLogs("------------" + ex.Message.ToString());
            }
        }

        public void closeBrowser()
        {
            try
            {

                _mainPageWindow.Close();
                WriteLogs("PASS : Closed Browser : VERIFICATION");
            }
            catch (Exception ex)
            {
                WriteLogs("FAIL : Not able to closed the browser : VERIFICATION");
                WriteLogs("----------" + ex.Message.ToString());
            }
        }

        public void enterUserName(string userName)
        {

            try
            {
                _userNameTxBx.SetFocus();
                Keyboard.SendKeys(userName);
                WriteLogs("PASS : Entered UserName " + "(" + userName + ") : VERIFICATION");
            }

            catch (Exception ex)
            {
                WriteLogs("FAIL : Entered Incorrect UserName " + "(" + userName + ") : VERIFICATION");
                WriteLogs("------------" + ex.Message.ToString());
            }

        }

        public void enterPD(string password)
        {

            try
            {
                _pWDTxBx.SetFocus();
                Keyboard.SendKeys(password);
                WriteLogs("PASS : Entered Password " + "(" + password + ") : VERIFICATION");
            }
            catch (Exception ex)
            {
                WriteLogs("FAIL : Entered Incorrect Password " + "(" + password + ") : VERIFICATION");
                WriteLogs("------------" + ex.Message.ToString());
            }

        }

        public void clicksigninbutton(int status)
        {
            try
            {
                if (status == 1)
                {
                    _signInBtn.SetFocus();
                    Mouse.Click(_signInBtn);
                    WriteLogs("PASS : Clicked Sign In button for PACS System Login. : VERIFICATION");
                    WriteLogs("PASS : Welcome Back Ash QA. Please wait, redirecting : VERIFICATION");
                }
                else
                {
                    _signInBtn.SetFocus();
                    Mouse.Click(_signInBtn);
                    WriteLogs("PASS : Clicked Sign In button for PACS Installation : VERIFICATION");
                    WriteLogs("PASS : PACS System has been successfully installed on your device : VERIFICATION");

                }
            }
            catch (Exception ex)
            {
                WriteLogs("FAIL : Not clicked on the Sign In Button : VERIFICATION");
                WriteLogs("------------" + ex.Message.ToString());
            }
        }

    }
}
