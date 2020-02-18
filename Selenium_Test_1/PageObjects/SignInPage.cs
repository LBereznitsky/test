using OpenQA.Selenium.Chrome;
using Serilog;

namespace PageObjects
{
    public class SignInPage : WebElement
    {
        private readonly ChromeDriver _webElement;

        private readonly ILogger _logger;

        public SignInPage(ILogger logger, ChromeDriver element) : base(logger, element, "//*[@class='metro login-fon register-metro']")
        {
            _webElement = element;
            _logger = logger;
        }

        public Button pageMain => new Button(_logger, _webElement, "//*[@class='metro login-fon register-metro']");

        public Button btnSubmit => new Button(_logger, _webElement, "//*[@id='signupbtn']");

        //input fields

        public InputField fieldEmailAddress => new InputField(_logger, _webElement, "//*[@id='registerName']");

        public InputField fieldFirstName => new InputField(_logger, _webElement, "//*[@id='FirstName']");

        public InputField fieldLastName => new InputField(_logger, _webElement, "//*[@id='LastName']");

        public InputField fieldPassword => new InputField(_logger, _webElement, "//*[text()='Password']//following::input[@id='UserPassword'][1]");

        public InputField fieldConfirmPassword => new InputField(_logger, _webElement, "//*[text()='Confirm password']//following::input[@id='UserPassword'][1]");

        public InputField fieldPhone => new InputField(_logger, _webElement, "//*[@id='Phone']");

        public InputField fieldOrganizationName => new InputField(_logger, _webElement, "//*[@id='OrgDisplayName']");


        // alert labels
        public AlertLabel errorFieldEmailAddress => new AlertLabel(_logger, _webElement, "//*[@id='registerName']//following::span[@for='UsernameOrEmail']");

        public AlertLabel errorFieldFirstName => new AlertLabel(_logger, _webElement, "//*[@id='FirstName']//following::span[@for='FirstName']");

        public AlertLabel errorFieldLastName => new AlertLabel(_logger, _webElement, "//*[@id='LastName']//following::span[@for='LastName']");

        public AlertLabel errorFieldPassword => new AlertLabel(_logger, _webElement, "//*[text()='Password']//following::span[@for='ConfirmUserPassword'][1]");

        public AlertLabel errorFieldConfirmPassword => new AlertLabel(_logger, _webElement, "//*[text()='Confirm password']//following::span[@for='ConfirmUserPassword'][1]");

        public AlertLabel errorFieldPhone => new AlertLabel(_logger, _webElement, "//*[@id='Phone']//following::span[@for='Phone']");

        public AlertLabel errorFieldOrganizationName => new AlertLabel(_logger, _webElement, "//*[@id='OrgDisplayName']//following::span[@for='ConfirmUserPassword']");

        public AlertLabel fieldPasswordStrenght => new AlertLabel(_logger, _webElement, "//*[text()='Password']//following::span[@data-bind='visible: showPasswordWeaknessError']");
    }
}
