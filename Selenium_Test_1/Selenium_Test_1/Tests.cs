using Microsoft.VisualStudio.TestTools.UnitTesting;
using SeleniumTests.SeleniumDriver.WebElements;
using System.Threading;
using WebPages;

namespace Selenium_Test_1
{
    [TestClass]
    public class TestSuite_1 : TestBase
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
            mainPage.btnSubmit.ClickButton();
            var message = mainPage.alertRegisterName.GetText();

            mainPage.fldRegisterName.SetText("Leonid 7777");
            mainPage.btnSubmit.ClickButton();
            //
            Thread.Sleep(30000);
            Close(CurrentBrowser);
        }
    }
}
