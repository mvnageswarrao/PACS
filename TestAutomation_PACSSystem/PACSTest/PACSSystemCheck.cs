using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestAutomation_PACSSystem.UIMaps.LoginPage;
using TestAutomation_PACSSystem.Utilities;
using System.Configuration;
using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;
using TestAutomation_PACSSystem_Controls.Webcontrols;
using System.Drawing;

namespace TestAutomation_PACSSystem.PACSTest
{
    [CodedUITest]
    public class PACSSystemCheck : logWriter
    {
        mainPage pacsLoginPage;
        mainMenuPage pacsMainMenuPage;
        mainQuestionsPage pacsQuestionPage;
        pacsHTMLWindow _mainPageWindow;
        pacsHTMLDocument _mainPageDoc;
        HtmlCustom _existingBookRefPACSIcon;

        string strURL = ConfigurationManager.AppSettings["URL"].ToString();
        string userName = ConfigurationManager.AppSettings["Username"].ToString();
        string passWord = ConfigurationManager.AppSettings["Password"].ToString();
        string bookRefChar = ConfigurationManager.AppSettings["bookRefChar"].ToString();

        public PACSSystemCheck()
        {
            pacsLoginPage = new mainPage();
            pacsMainMenuPage = new mainMenuPage();
            pacsQuestionPage = new mainQuestionsPage();
            _mainPageWindow = new pacsHTMLWindow(strURL, strURL, "PACS | Villa Plus");
            _mainPageDoc = new pacsHTMLDocument(_mainPageWindow, "http://192.168.1.7/ - PACS | Villa Plus");
        }

        [TestMethod]
        public void PACSSystem()
        {

            WriteLogs("########## START ########## PAC System " + DateTime.Now.ToString() + "##########");
            //Open Browser, Clear Local Storage Data and again Open Browser
            pacsLoginPage.openBrowser(strURL);
            Playback.Wait(5);
            pacsLoginPage.browserAction_Obj.browserAction_method();
            Playback.Wait(10000);
            pacsLoginPage.closeBrowser();
            pacsLoginPage.openBrowser(strURL);
            Playback.Wait(3000);

            //Enter Valid Username
            pacsLoginPage.enterUserName(userName);

            //Enter Valid PAssword
            pacsLoginPage.enterPD(passWord);
            pacsLoginPage.clicksigninbutton(0);
            Playback.Wait(6000);
            pacsLoginPage.clicksigninbutton(1);

            //Click on the New PACS Icon
            pacsMainMenuPage.clickcreateNewPackIcon();

            //Enter Book Ref Character                       
            pacsQuestionPage.enterBookRef(bookRefChar);

            //Select Booking Reference Number from the Booking referene List
            HtmlDiv bookRefListDiv = new HtmlDiv(_mainPageDoc);
            bookRefListDiv.SearchProperties[HtmlDiv.PropertyNames.Id] = "bookingNamesContainer";
            HtmlControl bookRefList = new HtmlControl(bookRefListDiv);
            bookRefList.SearchProperties.Add(HtmlControl.PropertyNames.Class, "aBooking");
            UITestControlCollection collectionBookRef = bookRefList.FindMatchingControls();
            Random rad = new Random();
            int bookRefCount = rad.Next(collectionBookRef.Count);
            UITestControl bookingRef = collectionBookRef[bookRefCount];
            HtmlDiv selectBookingRef = (HtmlDiv)bookingRef;
            pacsQuestionPage.selectBookRef(selectBookingRef);

            //Select Questions Answer
            HtmlDiv questionColl = new HtmlDiv(_mainPageDoc);
            questionColl.SearchProperties[HtmlDiv.PropertyNames.Id] = "dvQuestionContainer";

            HtmlCustom allQuestionList = new HtmlCustom(questionColl);
            allQuestionList.SearchProperties.Add(HtmlCustom.PropertyNames.TagName, "LI");
            UITestControlCollection QuestionsList = allQuestionList.FindMatchingControls();

            int i = 1;

            foreach (UITestControl ques in QuestionsList)
            {

                if (ques.GetProperty("FriendlyName").ToString() != "")
                {
                    if (ques.GetProperty("innertext").ToString().Replace(" ", "").Trim() != "7.1PoolReadings")
                    {

                        HtmlDiv divfindAns = new HtmlDiv(ques);
                        divfindAns.SearchProperties[HtmlDiv.PropertyNames.Class] = "responseOption";
                        UITestControlCollection answers1 = divfindAns.FindMatchingControls();

                        int ansCount = answers1.Count();
                        Random radAns = new Random();
                        int ranAnsCount = radAns.Next(ansCount);

                        HtmlDiv ans = (HtmlDiv)answers1[ranAnsCount];

                        bool isClickable = false;
                        while (!isClickable)
                        {
                            try
                            {
                                Mouse.MoveScrollWheel(-1);
                                ans.EnsureClickable();
                                isClickable = true;
                            }
                            catch (Exception)
                            {

                            }
                        }

                        string ansValue = ans.DisplayText;
                        pacsQuestionPage.selectQuestionAns(ans, ques);
                    }

                    else
                    {
                        HtmlEdit enterPoolAns = new HtmlEdit(ques);
                        enterPoolAns.SearchProperties[HtmlEdit.PropertyNames.Type] = "SINGLELINE";
                        UITestControlCollection ansPool = enterPoolAns.FindMatchingControls();

                        int ansPoOlCount = ansPool.Count();
                        Random radPoolAns = new Random();
                        int ranPoolAnsCount = radPoolAns.Next(ansPoOlCount);

                        HtmlEdit ansPoolReadings = (HtmlEdit)ansPool[ranPoolAnsCount];

                        string poolValue = ansPoolReadings.DefaultText;

                        pacsQuestionPage.selectPoolHeatQuesAns(ansPoolReadings, ques);
                    }
                }
                else
                {
                    pacsQuestionPage.enterMainComment();
                }
                i++;
            }
            WriteLogs("PASS : Total number of Question's answered is - " + i + " : VERIFICATION");

            //Select Save button from Questions Page
             pacsQuestionPage.clickSaveButtons(0);

            //Select on Continue button for some missing Questions.
            HtmlDiv continuePresent = new HtmlDiv(_mainPageDoc);
            continuePresent.SearchProperties[HtmlDiv.PropertyNames.Id] = "cmdCustomMsgBoxContinue";
            var Mouseposition = continuePresent.BoundingRectangle;
            Point x = new Point(Mouseposition.X, Mouseposition.Y);
            Point y = new Point(Mouseposition.X - 10, Mouseposition.Y - 10);
            string srchContinoue = continuePresent.InnerText;
            if (x.X != 0)
            {
                pacsQuestionPage.clickContinueButton(continuePresent);

                HtmlDiv allQuestions = new HtmlDiv(_mainPageDoc);
                allQuestions.SearchProperties[HtmlDiv.PropertyNames.Id] = "dvQuestionContainer";

                HtmlDiv errorControl = new HtmlDiv(_mainPageDoc);
                errorControl.SearchProperties.Add(HtmlDiv.PropertyNames.Class, "errorResponse");
                errorControl.SearchProperties.Add(new PropertyExpression(HtmlDiv.PropertyNames.ControlDefinition, "red", PropertyExpressionOperator.Contains));
                UITestControlCollection missingQuestionscoll = errorControl.FindMatchingControls();

                foreach (HtmlDiv missedQuestion in missingQuestionscoll)
                {
                    UITestControl questionsOption = missedQuestion.GetParent();
                    UITestControl questionTitle = questionsOption.GetParent();

                    HtmlDiv divfindAns = new HtmlDiv(questionsOption);
                    divfindAns.SearchProperties[HtmlDiv.PropertyNames.Class] = "errorResponse";
                    UITestControlCollection answers1 = divfindAns.GetChildren();
                    bool isClickable = false;
                    while (!isClickable)
                    {
                        try
                        {
                            Mouse.MoveScrollWheel(1);
                            questionTitle.EnsureClickable();
                            isClickable = true;
                            Mouse.MoveScrollWheel(-1);
                            questionTitle.EnsureClickable();
                            isClickable = true;
                        }
                        catch (Exception)
                        {

                        }
                    }

                    string[] ansC = questionsOption.FriendlyName.Split(' ');

                    int ansCount = ansC.Count();
                    Random radAns = new Random();
                    int ranAnsCount = radAns.Next(1, ansCount);

                    HtmlDiv ansValue = (HtmlDiv)answers1[ranAnsCount];

                    pacsQuestionPage.selectedQuestionAnsOption(ansValue, questionTitle);
                }

                //Again click on the Save button for verification of all questions
                pacsQuestionPage.clickSaveButtons(1);

            }

            //Close Browser            
            pacsQuestionPage.closeBrowser();

            //Open Browser and click on the Sign In button 
            pacsLoginPage.openBrowser(strURL);
            Playback.Wait(1000);
            pacsLoginPage.clicksigninbutton(1);
            Playback.Wait(2000);

            //Searching for any existing PACS Sheet
            HtmlDiv divExistingPACS = new HtmlDiv(_mainPageDoc);
            divExistingPACS.SearchProperties[HtmlDiv.PropertyNames.Id] = "savedPacsList";
            HtmlCustom searchExistingPACS = new HtmlCustom(divExistingPACS);
            searchExistingPACS.SearchProperties.Add(HtmlCustom.PropertyNames.TagName, "A");
            if (searchExistingPACS.Exists)
            {
                UITestControlCollection collection = searchExistingPACS.FindMatchingControls();
                Random radNumSelect = new Random();
                int book = radNumSelect.Next(1, collection.Count);
                UITestControl bookRef = collection[book];
                _existingBookRefPACSIcon = (HtmlCustom)bookRef;
            }
            pacsMainMenuPage.selectExistingBookRefPACS(_existingBookRefPACSIcon);


            HtmlDiv nameOfBtn = new HtmlDiv(_mainPageDoc);
            nameOfBtn.SearchProperties.Add(HtmlDiv.PropertyNames.Id, "bottomRow");

           // HtmlDiv name = new HtmlDiv(HtmlDiv.PropertyNames.Id, "bottomRow");


            //nameOfBtn.SearchProperties[HtmlDiv.PropertyNames.DisplayText] = "Complete & Upload";
            //nameOfBtn.SearchProperties[HtmlDiv.PropertyNames.DisplayText] = "Save";

           // nameOfBtn.SearchProperties.Add(HtmlDiv.PropertyNames.DisplayText, "Complete & Upload", PropertyExpressionOperator.Contains);
            UITestControlCollection nameBtnAll = nameOfBtn.FindMatchingControls();

            

            Playback.Wait(1000);
            //Click on Complete And Upload Button.
            HtmlDiv completeUploadBtnControl = new HtmlDiv(_mainPageDoc);            
            completeUploadBtnControl.SearchProperties.Add(HtmlDiv.PropertyNames.Id, "cmdCompleteUpload");
            pacsQuestionPage.clickCompleteAndUploadButton(completeUploadBtnControl);
            
            Playback.Wait(1000);
            //Click on the OK button
            HtmlDiv okBtnControl = new HtmlDiv(_mainPageDoc);            
            okBtnControl.SearchProperties.Add(HtmlDiv.PropertyNames.Id, "cmdCustomMsgBoxOk");
            pacsQuestionPage.clickOKButton(okBtnControl);
            WriteLogs("########## END ########## PAC System " + DateTime.Now.ToString() + "##########");
        }
    }
}
