using OpenQA.Selenium.Chrome;
using Serilog;

namespace PageObjects
{
    public class MainPage : WebElement
    {
        private readonly ChromeDriver _webElement;

        private readonly ILogger _logger;

        public MainPage(ILogger logger, ChromeDriver element) : base(logger, element, "//*[@class='metro login-fon register-metro']")
        {
            _webElement = element;
            _logger = logger;
        }

        public Button pageMain => new Button(_logger, _webElement, "//*[@class='metro login-fon register-metro']");

        public Button btnSubmit => new Button(_logger, _webElement, "//*[@id='signupbtn']");

        public InputField fldRegisterName => new InputField(_logger, _webElement, "//*[@id='registerName']");

        public InputField alertRegisterName => new InputField(_logger, _webElement, "//*[@id='registerName']//following::span[@for='UsernameOrEmail']");

        //xpath for alert message - fldRegisterName
        ////*[@id='registerName']//following::span[@for='UsernameOrEmail']

        //public bool IsPresentPageMain()
        //{
        //   return pageMain()
        //}
    }
}
