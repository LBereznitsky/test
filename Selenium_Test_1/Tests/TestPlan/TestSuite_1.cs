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
        public void TC10101_SignInPage_AllFields_ValidationErroroMessage()
        {
            string expectedErrorMessage = "Field cannot be empty";
            CurrentBrowser = Initialize();            
            GoToUrl(CurrentBrowser, DefaultUrl);            
            var mainPage = new SignInPage(Logger, CurrentBrowser);
            mainPage.Displayed.Should().BeTrue();
            mainPage.btnSubmit.Click();            

            AssertMultiple(
            () =>
            {
                (mainPage.errorFieldEmailAddress.Displayed && expectedErrorMessage ==
                 mainPage.errorFieldEmailAddress.GetText()).Should().BeTrue();
                Logger.Information($" >>>PASSED: 'errorFieldEmailAddress is displayed with correct text'");
            },
            () =>
            {
                (mainPage.errorFieldFirstName.Displayed && expectedErrorMessage ==
                  mainPage.errorFieldFirstName.GetText()).Should().BeTrue();
                Logger.Information($" >>>PASSED: 'errorFieldFirstName is displayed with correct text'");
            },
            () =>
            {
                (mainPage.errorFieldLastName.Displayed && expectedErrorMessage ==
                  mainPage.errorFieldLastName.GetText()).Should().BeTrue();
                Logger.Information($" >>>PASSED: 'errorFieldLastName is displayed with correct text'");
            },
            () =>
            {
                (mainPage.errorFieldPassword.Displayed && expectedErrorMessage ==
                  mainPage.errorFieldPassword.GetText()).Should().BeTrue();
                Logger.Information($" >>>PASSED: 'errorFieldPassword is displayed with correct text'");
            },
            () =>
            {
                (mainPage.errorFieldConfirmPassword.Displayed && expectedErrorMessage ==
                  mainPage.errorFieldConfirmPassword.GetText()).Should().BeTrue();
                Logger.Information($" >>>PASSED: 'errorFieldConfirmPassword is displayed with correct text'");
            },
            () =>
            {
                (mainPage.errorFieldPhone.Displayed && expectedErrorMessage ==
                  mainPage.errorFieldPhone.GetText()).Should().BeTrue();
                Logger.Information($" >>>PASSED: 'errorFieldPhone is displayed with correct text'");
            },           
            () =>
            {
                (mainPage.errorFieldOrganizationName.Displayed && expectedErrorMessage ==
                  mainPage.errorFieldFirstName.GetText()).Should().BeTrue();
                Logger.Information($" >>>PASSED: 'errorFieldFirstName is displayed with correct text'");
            });   
            
            Close(CurrentBrowser);
        }


        [TestMethod]
        public void TC10102_SignInPage_Registration_With_ValidData()
        {            
            CurrentBrowser = Initialize();
            GoToUrl(CurrentBrowser, DefaultUrl);
            var mainPage = new SignInPage(Logger, CurrentBrowser);
            mainPage.Displayed.Should().BeTrue();  
            
            AssertMultiple(
            () =>
            {
                mainPage.fieldEmailAddress.SetText("123@gmail.com");
                mainPage.errorFieldEmailAddress.Displayed.Should().BeFalse();
                Logger.Information($" >>>PASSED: 'errorFieldEmailAddress is NOT displayed'");  
            },
            () =>
            {
                mainPage.fieldFirstName.SetText("John");
                mainPage.errorFieldFirstName.Displayed.Should().BeFalse();
                Logger.Information($" >>>PASSED: 'errorFieldFirstName is NOT displayed'");                
            },
            () =>
            {
                mainPage.fieldLastName.SetText("Daemon");
                mainPage.errorFieldLastName.Displayed.Should().BeFalse();
                Logger.Information($" >>>PASSED: 'errorFieldLastName is NOT displayed'");                
            },
            () =>
            {
                mainPage.fieldPassword.SetText("P@ssw0rd_20");
                mainPage.errorFieldPassword.Displayed.Should().BeFalse();
                Logger.Information($" >>>PASSED: 'errorFieldPassword is NOT displayed'");                
            },
            () =>
            {
                mainPage.fieldConfirmPassword.SetText("P@ssw0rd_20");
                mainPage.errorFieldConfirmPassword.Displayed.Should().BeFalse();
                Logger.Information($" >>>PASSED: 'errorFieldConfirmPassword is NOT displayed'");                
            },
            () =>
            {
                mainPage.fieldPhone.SetText("+380991704044");
                mainPage.errorFieldLastName.Displayed.Should().BeFalse();
                Logger.Information($" >>>PASSED: 'errorFieldLastName is NOT displayed'");                
            },
            () =>
            {
                mainPage.fieldOrganizationName.SetText("Developex");
                mainPage.errorFieldOrganizationName.Displayed.Should().BeFalse();
                Logger.Information($" >>>PASSED: 'errorFieldLastName is NOT displayed'");                
            });

            mainPage.btnSubmit.Click();
            var welcomePage = new WelcomePage(Logger, CurrentBrowser);
            welcomePage.Displayed.Should().BeTrue();
            Close(CurrentBrowser);
        }
    }

   
}
