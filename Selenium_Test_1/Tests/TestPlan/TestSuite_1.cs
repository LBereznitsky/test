using FluentAssertions;
using FluentAssertions.Execution;
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
            
            var mainPage = new MainPage(Logger, CurrentBrowser);
            mainPage.fldRegisterName.SetText("Hello Serilogs");
            mainPage.btnSubmit.ClickButton();            
            //Thread.Sleep(30000);            
            Close(CurrentBrowser); 
            
        }

        [TestMethod]
        public void TestMethod2()
        {
            CurrentBrowser = Initialize();            
            GoToUrl(CurrentBrowser, DefaultUrl);
            
            var mainPage = new MainPage(Logger, CurrentBrowser);
            
            AssertMultiple(
            () =>
            {
                mainPage.IsDisplayed().Should().BeTrue();
                Logger.Information($" >>>PASSED: 'mainPage.IsDisplayed().Should().BeTrue()'");
            },
            () =>
            {
                mainPage.fldRegisterName.SetText("Some string");
                mainPage.btnSubmit.ClickButton();
                mainPage.IsDisplayed().Should().BeFalse();
                Logger.Information($" >>>PASSED: 'mainPage.IsDisplayed().Should().BeTrue()'");
            });
            mainPage.fldRegisterName.SetText("Some string");
            mainPage.btnSubmit.ClickButton(); 
            //Thread.Sleep(30000);  
            

            Close(CurrentBrowser);
        }
    }

   
}
