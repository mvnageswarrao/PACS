using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UITesting;
using System.Diagnostics;
using TestAutomation_PACSSystem_Controls.Webcontrols;
using System.Configuration.Assemblies;



namespace TestAutomation_PACSSystem.Utilities
{
    public class logWriter
    {
        public logWriter()
        {

        }

        public void WriteLogs(string Status)
        {
            string logfileName = "";
            StackTrace stackTrace = new StackTrace();           // get call stack
            StackFrame[] stackFrames = stackTrace.GetFrames();  // get method calls (frames)

            // write call stack method names
            foreach (StackFrame stackFrame in stackFrames)
            {
                if (stackFrame.GetMethod().Name == "InvokeMethod")
                {
                    break;
                }
                else
                {
                    logfileName = stackFrame.GetMethod().Name;
                }
            }
            logfileName = logfileName + "_" + DateTime.Now.ToString("dd-MM-yyyy");

            string strAppPath = ConfigurationManager.AppSettings["resultPath"].ToString();

            if (Status.Contains("PASS"))
            {
                FileInfo f = new FileInfo(strAppPath + logfileName + "_PASS.txt");
                StreamWriter w = f.AppendText();
                w.WriteLine(Status);
                w.Close();
            }
            else if (Status.Contains("FAIL"))
            {
                FileInfo f = new FileInfo(strAppPath + logfileName + "_FAIL.txt");
                StreamWriter w = f.AppendText();
                w.WriteLine(Status);
                w.Close();
            }
            else
            {
                FileInfo f1 = new FileInfo(strAppPath + logfileName + "_PASS.txt");
                StreamWriter w1 = f1.AppendText();
                FileInfo f2 = new FileInfo(strAppPath + logfileName + "_FAIL.txt");
                StreamWriter w2 = f2.AppendText();
                w1.WriteLine(Status);
                w1.Close();
                w2.WriteLine(Status);
                w2.Close();
            }
            
        }

        
        }

       
    }








