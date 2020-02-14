using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PageObjects;
using Serilog;
using TestsBrowser;


namespace Tests
{    
    [TestClass]
    public class TestSuite_1 : Browser
    {
        

        [TestMethod]
        public void TestMethod1()
        {            
            CurrentBrowser = Initialize();

            string currentDate = String.Join("-", DateTime.Today.ToString("yyyy-MM-dd"));

            var logs = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.File($@"C:\Logs\Info-{currentDate}.txt")
                .CreateLogger();



            GoToUrl(CurrentBrowser, DefaultUrl);
            logs.Information(nameof(GoToUrl));
            logs.Information("Yeeeppp");
            var mainPage = new MainPage(CurrentBrowser);
            mainPage.fldRegisterName.SetText("Leonid krasava");
            mainPage.btnSubmit.ClickButton();
            //
            //Thread.Sleep(30000);
            logs.Dispose();
            Close(CurrentBrowser); 
            
        }

        [TestMethod]
        public void TestMethod2()
        {
            CurrentBrowser = Initialize();
            GoToUrl(CurrentBrowser, DefaultUrl);
            var mainPage = new MainPage(CurrentBrowser);
            mainPage.fldRegisterName.SetText("1125544");
            mainPage.btnSubmit.ClickButton();
            //
            Thread.Sleep(30000);
            Close(CurrentBrowser);
        }
    }

   
}
