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
    class mainQuestionsPage : logWriter
    {
        pacsHTMLDocument _mainPageDoc;
        pacsHTMLWindow _mainPageWindow;
        pacsHTMLTextbox _bookRefTxBx;       
        pacsHTMLTextArea _commentsTxArNote;       
        pacsHTMLButton _saveNoteBtn;
        pacsHTMLTextArea _commentsTxAr;
        pacsHTMLButton _saveBtn;
             


        string strURL = ConfigurationManager.AppSettings["URL"].ToString();

        public mainQuestionsPage()
        {
            _mainPageWindow = new pacsHTMLWindow(strURL, strURL, "PACS | Villa Plus");
            _mainPageDoc = new pacsHTMLDocument(_mainPageWindow, strURL);
            _bookRefTxBx = new pacsHTMLTextbox(_mainPageDoc, "txtBookingRef", "SINGLELINE");
            _commentsTxArNote = new pacsHTMLTextArea(_mainPageDoc, "txtNote");
            _saveNoteBtn = new pacsHTMLButton(_mainPageDoc, "cmdSaveNote", "Save Note");
            _commentsTxAr = new pacsHTMLTextArea(_mainPageDoc, "txtComments");
            _saveBtn = new pacsHTMLButton(_mainPageDoc, "cmdSave", "Save");           
            
        }

        public void enterBookRef(string bookRef)
        {
            try
            {
                _bookRefTxBx.SetFocus();
                Mouse.Click(_bookRefTxBx);
                Keyboard.SendKeys(bookRef);
                WriteLogs("PASS : Entered valid Book Reference Char - " + bookRef + " : VERIFICATION");
                WriteLogs("PASS : Booking Reference List is displayed.");
            }
            catch (Exception ex)
            {
                WriteLogs("FAIL : Entered an Invalid Book Reference Char - " + bookRef + " : VERIFICATION");
                WriteLogs("------------" + ex.Message.ToString());
            }
        }

        public void selectBookRef(HtmlDiv selectedBookingRef)
        {
            try
            {                
                Mouse.Click(selectedBookingRef);
                WriteLogs("PASS : Selected Booking Reference Number : " + selectedBookingRef.DisplayText + " : VERIFICATION");
            }
            catch (Exception ex)
            {
                WriteLogs("FAIL : Not Selected Booking Ref from the Booking Reference List." + " : VERIFICATION");
                WriteLogs("------------" + ex.Message.ToString());
            }
        }

        public void closeBrowser()
        {
            try
            {

                _mainPageWindow.Close();
                WriteLogs("PASS : Closed Browser after filled the PACS Form : VERIFICATION");
            }
            catch (Exception ex)
            {
                WriteLogs("FAIL : Not able to closed the browser : VERIFICATION");
                WriteLogs("----------" + ex.Message.ToString());
            }
        }

        public void selectQuestionAns(HtmlDiv ans, UITestControl ques)
        {
                        string ansValue = ans.DisplayText;

                        switch (ansValue)
                        {
                            case "Y":
                                try
                                {
                                    Mouse.Click(ans);
                                    WriteLogs("PASS : " + ques.FriendlyName + " - " + ansValue);
                                }
                                catch (Exception ex)
                                {
                                    WriteLogs("FAIL - Not Clicked on " + ques.FriendlyName + " - " + ansValue);
                                    WriteLogs("----------" + ex.Message.ToString());
                                }
                                break;

                            case "NA":
                                try
                                {
                                    Mouse.Click(ans);
                                    WriteLogs("PASS : " + ques.FriendlyName + " - " + ansValue);
                                }
                                catch (Exception ex)
                                {
                                    WriteLogs("FAIL - Not Clicked on " + ques.FriendlyName + " - " + ansValue);
                                    WriteLogs("----------" + ex.Message.ToString());
                                }
                                break;

                            case "N":
                                try
                                {
                                    Mouse.Click(ans);
                                    Mouse.Click(_commentsTxArNote);
                                    Keyboard.SendKeys(_commentsTxArNote, "test");
                                    Mouse.Click(_saveNoteBtn);
                                    WriteLogs("PASS : " + ques.FriendlyName + " - " + ansValue + " - test");
                                }
                                catch (Exception ex)
                                {
                                    WriteLogs("FAIL - Not Clicked on " + ques.FriendlyName + " - " + ansValue);
                                    WriteLogs("----------" + ex.Message.ToString());
                                }
                                break;

                            case "NC":
                                try
                                {
                                    Mouse.Click(ans);
                                    Mouse.Click(_commentsTxArNote);
                                    _commentsTxArNote.SetFocus();
                                    Keyboard.SendKeys(_commentsTxArNote, "test");
                                    Mouse.Click(_saveNoteBtn);
                                    WriteLogs("PASS : " + ques.FriendlyName + " - " + ansValue + " - test");
                                }
                                catch (Exception ex)
                                {
                                    WriteLogs("FAIL - Not Clicked on " + ques.FriendlyName + " - " + ansValue);
                                    WriteLogs("----------" + ex.Message.ToString());
                                }
                                break;

                        }

                    }           

        public void selectPoolHeatQuesAns(HtmlEdit ansPoolReadings, UITestControl ques)

                    {                         

                        string poolValue = ansPoolReadings.DefaultText;

                        switch (poolValue)
                        {
                            case "PH":

                                try
                                {
                                    Mouse.Click(ansPoolReadings);
                                    Keyboard.SendKeys(ansPoolReadings, "12");
                                    WriteLogs("PASS : " + ques.FriendlyName + " Entered Pool Readings data " + poolValue + " - 12");
                                }
                                catch (Exception ex)
                                {
                                    WriteLogs("FAIL : " + ques.FriendlyName + " Not entered Pool Readings data - " + poolValue);
                                    WriteLogs("----------" + ex.Message.ToString());
                                }
                                break;


                            case "CL":
                                try
                                {
                                    Mouse.Click(ansPoolReadings);
                                    Keyboard.SendKeys(ansPoolReadings, "12");
                                    WriteLogs("PASS : " + ques.FriendlyName + " Entered Pool Readings data " + poolValue + " - 12");
                                }
                                catch (Exception ex)
                                {
                                    WriteLogs("FAIL : " + ques.FriendlyName + " Not entered Pool Readings data - " + poolValue);
                                    WriteLogs("----------" + ex.Message.ToString());
                                }
                                break;


                            case "TM":
                                try
                                {
                                    Mouse.Click(ansPoolReadings);
                                    Keyboard.SendKeys(ansPoolReadings, "12");
                                    WriteLogs("PASS : " + ques.FriendlyName + " Entered Pool Readings data " + poolValue + " - 12");
                                }
                                catch (Exception ex)
                                {
                                    WriteLogs("FAIL : " + ques.FriendlyName + " Not entered Pool Readings data - " + poolValue);
                                    WriteLogs("----------" + ex.Message.ToString());
                                }
                                break;

                        }
                    }

        public void enterMainComment()

                {
                    try
                    {
                        Mouse.Click(_commentsTxAr);
                        Keyboard.SendKeys(_commentsTxAr, "This is the test comments");
                        WriteLogs("PASS : " + "8.1 Comments" + " - This is the test comments");
                    }
                    catch (Exception ex)
                    {
                        WriteLogs("FAIL : - 8.1 Comments - Not entered any comments.");
                        WriteLogs("----------" + ex.Message.ToString());
                    }
                }

        public void clickSaveButtons(int status)
        {
            if (status == 0)
            {
                try
                {
                    Mouse.Click(_saveBtn);
                    WriteLogs("PASS : Clicked on the Save Button : VERIFICATION");
                }
                catch (Exception ex)
                {
                    WriteLogs("FAIL : Not able to click on the Save Button : VERIFICATION");
                    WriteLogs("------------" + ex.Message.ToString());
                }

            }
            else
            {
                try
                {
                    Mouse.Click(_saveBtn);
                    WriteLogs("PASS : Again Clicked on the Save Button for verification of All Questions are answered : VERIFICATION");
                }
                catch (Exception ex)
                {
                    WriteLogs("FAIL : Not able to click again on the Save Button : VERIFICATION");
                    WriteLogs("------------" + ex.Message.ToString());
                }                
            }


        }

        public void clickContinueButton(HtmlDiv continuePresent)
        {
            try
            {
                Mouse.Click(continuePresent);
                WriteLogs("PASS : Not selected all Questions hence clicked on the Continue Button from PACS Incomplete Popup : VERIFICATION");
            }
            catch (Exception ex)
            {
                WriteLogs("FAIL : Not able to click on the Continue BUtton");
                WriteLogs("-----------" + ex.Message.ToString());
            }
        }

        public void selectedQuestionAnsOption(HtmlDiv ansValue, UITestControl questionTitle)
        {
            switch (ansValue.DisplayText)
            {
                case "Y":
                    try
                    {
                        Mouse.Click(ansValue);
                        WriteLogs("PASS : " + questionTitle.FriendlyName + " - " + "Y");
                    }
                    catch (Exception ex)
                    {
                        WriteLogs("FAIL - Not Clicked on " + questionTitle.FriendlyName + " - " + "Y");
                        WriteLogs("----------" + ex.Message.ToString());
                    }
                    break;

                case "NA":
                    try
                    {
                        Mouse.Click(ansValue);
                        WriteLogs("PASS : " + questionTitle.FriendlyName + " - " + "NA");
                    }
                    catch (Exception ex)
                    {
                        WriteLogs("FAIL - Not Clicked on " + questionTitle.FriendlyName + " - " + "NA");
                        WriteLogs("----------" + ex.Message.ToString());
                    }
                    break;

                case "N":
                    try
                    {
                        Mouse.Click(ansValue);
                        Mouse.Click(_commentsTxArNote);
                        Keyboard.SendKeys(_commentsTxArNote, "test");
                        Mouse.Click(_saveNoteBtn);
                        WriteLogs("PASS : " + questionTitle.FriendlyName + " - " + "N" + " - test");
                    }
                    catch (Exception ex)
                    {
                        WriteLogs("FAIL - Not Clicked on " + questionTitle.FriendlyName + " - " + "N");
                        WriteLogs("----------" + ex.Message.ToString());
                    }
                    break;

                case "NC":
                    try
                    {
                        Mouse.Click(ansValue);
                        Mouse.Click(_commentsTxArNote);
                        _commentsTxArNote.SetFocus();
                        Keyboard.SendKeys(_commentsTxArNote, "test");
                        Mouse.Click(_saveNoteBtn);
                        WriteLogs("PASS : " + questionTitle.FriendlyName + " - " + "NC" + " - test");
                    }
                    catch (Exception ex)
                    {
                        WriteLogs("FAIL - Not Clicked on " + questionTitle.FriendlyName + " - " + "NC");
                        WriteLogs("----------" + ex.Message.ToString());
                    }
                    break;
            }
        }

        public void clickCompleteAndUploadButton(HtmlDiv completeUploadBtnControl)

        {
            try
            {                
                Mouse.Click(completeUploadBtnControl);
                WriteLogs("PASS : Clicked on the Complete & Upload Button : VERIFICATION");
            }
            catch (Exception ex)
            {
                WriteLogs("FAIL : Not able to click on the Complete & Upload Button : VERIFICATION");
                WriteLogs("------------" + ex.Message.ToString());
            }
        }

        public void clickOKButton(HtmlDiv okBtnControl)
        {
            try
            {               
                Mouse.Click(okBtnControl);
                WriteLogs("PASS : Clicked on the OK button : VERIFICATION");
            }
            catch (Exception ex)
            {
                WriteLogs("FAIL : Not able to clicked on the OK button : VERIFICATION");
                WriteLogs("------------" + ex.Message.ToString());
            }
        }

    }
}
