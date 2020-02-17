using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using TestsBrowser;

namespace Tests
{
    public class TestsBase : Browser
    {
        public string AssertMSG;
        public string DefaultExceptionMSG { get; set; } = string.Empty;        

        public void AssertMultiple(params Action[] actions)
        {
            List<string> errorMSGs = new List<string>();

            foreach (var action in actions)
            {
                try
                {
                    AssertMSG = string.Empty;                    
                    action.Invoke();
                }
                catch (Exception e)
                {
                    if (String.IsNullOrEmpty(AssertMSG))
                    {
                        AssertMSG = e.Message.Insert(0, ">>>BLOKED: MULTIPLE ASSERT: ");
                    }
                    else
                    {
                        AssertMSG = AssertMSG.Replace(">>>FAILED", ">>>FAILED: MULTIPLE ASSERT");
                    }                    
                    Logger.Error(AssertMSG);
                    Logger.Information(AssertMSG);
                    errorMSGs.Add(AssertMSG + Environment.NewLine);
                }                
            }

            if (errorMSGs.Count > 0)
            {
                Close(CurrentBrowser);
                var separator = string.Format("{0}{0}", string.Empty);
                DefaultExceptionMSG = string.Join(separator, errorMSGs);
                Assert.Fail(string.Format($"The following conditions failed:{Environment.NewLine}{DefaultExceptionMSG}"));
            }  
        }

    }
}
