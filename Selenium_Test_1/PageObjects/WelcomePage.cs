using OpenQA.Selenium.Chrome;
using Serilog;

namespace PageObjects
{
    public class WelcomePage : WebElement
    {
        private readonly ChromeDriver _webElement;

        private readonly ILogger _logger;

        public WelcomePage(ILogger logger, ChromeDriver element) : base(logger, element, "//*[@class='metro login-fon']")
        {
            _webElement = element;
            _logger = logger;
        }       
    }
}
