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
            mainPage.fieldEmailAddress.SetText("Hello Serilogs");
            mainPage.btnSubmit.Click();            
            //Thread.Sleep(30000);            
            Close(CurrentBrowser); 
            
        }

        [TestMethod]
        public void MainPage_AllFields_Validation()
        {
            string expectedErrorMessage = "Field cannot be empty";
            CurrentBrowser = Initialize();            
            GoToUrl(CurrentBrowser, DefaultUrl);            
            var mainPage = new MainPage(Logger, CurrentBrowser);
            mainPage.IsDisplayed().Should().BeTrue();
            mainPage.btnSubmit.Click();

            AssertMultiple(
            () =>
            {
                (mainPage.errorFieldEmailAddress.IsDisplayed() && expectedErrorMessage ==
                 mainPage.errorFieldEmailAddress.GetText()).Should().BeTrue();
                Logger.Information($" >>>PASSED: 'errorFieldEmailAddress is displayed with correct text'");
            },
            () =>
            {
                (mainPage.errorFieldFirstName.IsDisplayed() && expectedErrorMessage ==
                  mainPage.errorFieldFirstName.GetText()).Should().BeTrue();
                Logger.Information($" >>>PASSED: 'errorFieldFirstName is displayed with correct text'");
            },
            () =>
            {
                (mainPage.errorFieldLastName.IsDisplayed() && expectedErrorMessage ==
                  mainPage.errorFieldLastName.GetText()).Should().BeTrue();
                Logger.Information($" >>>PASSED: 'errorFieldLastName is displayed with correct text'");
            },
            () =>
            {
                (mainPage.errorFieldPassword.IsDisplayed() && expectedErrorMessage ==
                  mainPage.errorFieldPassword.GetText()).Should().BeTrue();
                Logger.Information($" >>>PASSED: 'errorFieldPassword is displayed with correct text'");
            },
            () =>
            {
                (mainPage.errorFieldConfirmPassword.IsDisplayed() && expectedErrorMessage ==
                  mainPage.errorFieldConfirmPassword.GetText()).Should().BeTrue();
                Logger.Information($" >>>PASSED: 'errorFieldConfirmPassword is displayed with correct text'");
            },
            () =>
            {
                (mainPage.errorFieldPhone.IsDisplayed() && expectedErrorMessage ==
                  mainPage.errorFieldPhone.GetText()).Should().BeTrue();
                Logger.Information($" >>>PASSED: 'errorFieldPhone is displayed with correct text'");
            },           
            () =>
            {
                (mainPage.errorFieldOrganizationName.IsDisplayed() && expectedErrorMessage ==
                  mainPage.errorFieldFirstName.GetText()).Should().BeTrue();
                Logger.Information($" >>>PASSED: 'errorFieldFirstName is displayed with correct text'");
            });   
            
            Close(CurrentBrowser);
        }
    }

   
}
