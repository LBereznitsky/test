using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PageObjects;
using TestsBrowser;

namespace Tests
{
    [TestClass]
    public class TestSuite_1 : TestsBase
    {
        [TestMethod]
        public void TestMethod1()
        {
            CurrentBrowser = Initialize();
            GoToUrl(CurrentBrowser, DefaultUrl);
            var mainPage = new MainPage(CurrentBrowser);
            mainPage.fldRegisterName.SetText("Leonid krasava");
            mainPage.btnSubmit.ClickButton();
            //
            Thread.Sleep(30000);
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
