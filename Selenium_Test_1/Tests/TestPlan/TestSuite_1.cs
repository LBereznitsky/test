using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PageObjects;

namespace Tests
{
    [TestClass]
    public class TestSuite_1 : TestsBase
    {

        [TestMethod]
        public void TC10101_SignInPage_EmptyFields_ValidationErroroMessage()
        {
            string expectedErrorMessage = "Field cannot be empty";
            CurrentBrowser = Initialize();
            GoToUrl(CurrentBrowser, DefaultUrl);
            var signInPage = new SignInPage(Logger, CurrentBrowser);
            signInPage.Displayed.Should().BeTrue();
            signInPage.btnSubmit.Click();

            AssertMultiple(
            () =>
            {
                (signInPage.errorFieldEmailAddress.Displayed && expectedErrorMessage ==
                 signInPage.errorFieldEmailAddress.GetText()).Should().BeTrue();
                Logger.Information($" >>>PASSED: 'errorFieldEmailAddress is displayed with correct text'");
            },
            () =>
            {
                (signInPage.errorFieldFirstName.Displayed && expectedErrorMessage ==
                  signInPage.errorFieldFirstName.GetText()).Should().BeTrue();
                Logger.Information($" >>>PASSED: 'errorFieldFirstName is displayed with correct text'");
            },
            () =>
            {
                (signInPage.errorFieldLastName.Displayed && expectedErrorMessage ==
                  signInPage.errorFieldLastName.GetText()).Should().BeTrue();
                Logger.Information($" >>>PASSED: 'errorFieldLastName is displayed with correct text'");
            },
            () =>
            {
                (signInPage.errorFieldPassword.Displayed && expectedErrorMessage ==
                  signInPage.errorFieldPassword.GetText()).Should().BeTrue();
                Logger.Information($" >>>PASSED: 'errorFieldPassword is displayed with correct text'");
            },
            () =>
            {
                (signInPage.errorFieldConfirmPassword.Displayed && expectedErrorMessage ==
                  signInPage.errorFieldConfirmPassword.GetText()).Should().BeTrue();
                Logger.Information($" >>>PASSED: 'errorFieldConfirmPassword is displayed with correct text'");
            },
            () =>
            {
                (signInPage.errorFieldPhone.Displayed && expectedErrorMessage ==
                  signInPage.errorFieldPhone.GetText()).Should().BeTrue();
                Logger.Information($" >>>PASSED: 'errorFieldPhone is displayed with correct text'");
            },
            () =>
            {
                (signInPage.errorFieldOrganizationName.Displayed && expectedErrorMessage ==
                  signInPage.errorFieldFirstName.GetText()).Should().BeTrue();
                Logger.Information($" >>>PASSED: 'errorFieldFirstName is displayed with correct text'");
            });

            Close(CurrentBrowser);
        }


        [TestMethod]
        public void TC10102_SignInPage_Registration_With_ValidData()
        {
            CurrentBrowser = Initialize();
            GoToUrl(CurrentBrowser, DefaultUrl);
            var signInPage = new SignInPage(Logger, CurrentBrowser);
            signInPage.Displayed.Should().BeTrue();

            AssertMultiple(
            () =>
            {
                signInPage.fieldEmailAddress.SetText("123@gmail.com");
                signInPage.errorFieldEmailAddress.Displayed.Should().BeFalse();
                Logger.Information($" >>>PASSED: 'errorFieldEmailAddress is NOT displayed'");
            },
            () =>
            {
                signInPage.fieldFirstName.SetText("John");
                signInPage.errorFieldFirstName.Displayed.Should().BeFalse();
                Logger.Information($" >>>PASSED: 'errorFieldFirstName is NOT displayed'");
            },
            () =>
            {
                signInPage.fieldLastName.SetText("Daemon");
                signInPage.errorFieldLastName.Displayed.Should().BeFalse();
                Logger.Information($" >>>PASSED: 'errorFieldLastName is NOT displayed'");
            },
            () =>
            {
                signInPage.fieldPassword.SetText("P@ssw0rd_20");
                signInPage.errorFieldPassword.Displayed.Should().BeFalse();
                Logger.Information($" >>>PASSED: 'errorFieldPassword is NOT displayed'");
            },
            () =>
            {
                signInPage.fieldConfirmPassword.SetText("P@ssw0rd_20");
                signInPage.errorFieldConfirmPassword.Displayed.Should().BeFalse();
                Logger.Information($" >>>PASSED: 'errorFieldConfirmPassword is NOT displayed'");
            },
            () =>
            {
                signInPage.fieldPhone.SetText("+380991704044");
                signInPage.errorFieldPhone.Displayed.Should().BeFalse();
                Logger.Information($" >>>PASSED: 'errorFieldLastName is NOT displayed'");
            },
            () =>
            {
                signInPage.fieldOrganizationName.SetText("Developex");
                signInPage.errorFieldOrganizationName.Displayed.Should().BeFalse();
                Logger.Information($" >>>PASSED: 'errorFieldLastName is NOT displayed'");
            });

            signInPage.btnSubmit.Click();
            var welcomePage = new WelcomePage(Logger, CurrentBrowser);
            welcomePage.Displayed.Should().BeTrue();
            Close(CurrentBrowser);
        }

        [TestMethod]
        public void TC10103_SignInPage_PasswordFields_Check()
        {
            string expectedErrorMessage = "The password and confirmation password do not match";
            CurrentBrowser = Initialize();
            GoToUrl(CurrentBrowser, DefaultUrl);
            var signInPage = new SignInPage(Logger, CurrentBrowser);
            signInPage.Displayed.Should().BeTrue();

            AssertMultiple(
            () => // step 1
            {
                signInPage.fieldPassword.SetText("P@ssw0rd_20");
                signInPage.errorFieldConfirmPassword.Displayed.Should().BeFalse();
                Logger.Information($" >>>PASSED: 'errorFieldConfirmPassword is NOT displayed': step 1");
            },
            () => // step 2
            {
                signInPage.fieldPassword.SetText("P@ssw0rd_20");
                signInPage.fieldConfirmPassword.SetText("P@ssw0rd_20");
                signInPage.errorFieldConfirmPassword.Displayed.Should().BeFalse();
                Logger.Information($" >>>PASSED: 'errorFieldConfirmPassword is NOT displayed': step 2");
            },
            () => // step 3
            {
                signInPage.fieldPassword.SetText("P@ssw0rd_2");
                signInPage.fieldConfirmPassword.SetText("P@ssw0rd_20");
                (signInPage.errorFieldConfirmPassword.Displayed && expectedErrorMessage ==
                 signInPage.errorFieldConfirmPassword.GetText()).Should().BeTrue();
                Logger.Information($" >>>PASSED: 'errorFieldConfirmPassword is displayed': step 3");
            },
            () => // step 4
            {
                signInPage.fieldPassword.SetText("");
                signInPage.fieldConfirmPassword.SetText("P@ssw0rd_20");
                (signInPage.errorFieldConfirmPassword.Displayed && expectedErrorMessage ==
                 signInPage.errorFieldConfirmPassword.GetText()).Should().BeTrue();
                Logger.Information($" >>>PASSED: 'errorFieldConfirmPassword is displayed': step 4");
            },
            () => // step 4.1
            {
                signInPage.errorFieldPassword.Displayed.Should().BeTrue();
                Logger.Information($" >>>PASSED: 'errorFieldConfirmPassword is displayed': step 4.1");
            },
            () => // step 5 
            {
                expectedErrorMessage = "Password strength: weak";
                signInPage.fieldPassword.SetText("12345");
                (signInPage.fieldPasswordStrenght.Displayed && expectedErrorMessage ==
                 signInPage.fieldPasswordStrenght.GetText()).Should().BeTrue();
                Logger.Information($" >>>PASSED: 'fieldPasswordStrenght is displayed with correct text': step 5");
            },
            () => // step 6
            {
                expectedErrorMessage = "Password strength: normal";
                signInPage.fieldPassword.SetText("123456K");
                (signInPage.fieldPasswordStrenght.Displayed && expectedErrorMessage ==
                 signInPage.fieldPasswordStrenght.GetText()).Should().BeTrue();
                Logger.Information($" >>>PASSED: 'fieldPasswordStrenght is displayed with correct text': step 6");
            },
            () => // step 7
            {
                expectedErrorMessage = "Password strength: normal";
                signInPage.fieldPassword.SetText("12345678K");
                (signInPage.fieldPasswordStrenght.Displayed && expectedErrorMessage ==
                 signInPage.fieldPasswordStrenght.GetText()).Should().BeTrue();
                Logger.Information($" >>>PASSED: 'fieldPasswordStrenght is displayed with correct text': step 7");
            },
            () => // step 8
            {
                expectedErrorMessage = "Password strength: strong";
                signInPage.fieldPassword.SetText("12345678910@#K");
                (signInPage.fieldPasswordStrenght.Displayed && expectedErrorMessage ==
                 signInPage.fieldPasswordStrenght.GetText()).Should().BeTrue();
                Logger.Information($" >>>PASSED: 'fieldPasswordStrenght is displayed with correct text': step 8");
            });

            Close(CurrentBrowser);
        }

        [TestMethod]
        public void TC10104_SignInPage_PhoneField_Check()
        {
            string expectedErrorMessage = "The password and confirmation password do not match";
            CurrentBrowser = Initialize();
            GoToUrl(CurrentBrowser, DefaultUrl);
            var signInPage = new SignInPage(Logger, CurrentBrowser);
            signInPage.Displayed.Should().BeTrue();

            signInPage.fieldEmailAddress.SetText("123@gmail.com");
            signInPage.fieldFirstName.SetText("John");
            signInPage.fieldLastName.SetText("Daemon");
            signInPage.fieldPassword.SetText("P@ssw0rd_20");
            signInPage.fieldConfirmPassword.SetText("P@ssw0rd_20");
            signInPage.fieldPhone.SetText("38(099)1704044");
            signInPage.fieldOrganizationName.SetText("Developex");

            signInPage.btnSubmit.Click();
            var welcomePage = new WelcomePage(Logger, CurrentBrowser);
            welcomePage.Displayed.Should().BeFalse();
            Close(CurrentBrowser);
        }
        
    }
}



