using OpenQA.Selenium.Chrome;
using SeleniumTests.SeleniumDriver.WebElements;

namespace WebPages
{    
    public class MainPage : WebElement
    {
        private readonly ChromeDriver _webElement;        

        public MainPage(ChromeDriver element) : base(element, "//*[@class='metro login-fon register-metro']")
        {
            _webElement = element;            
        }


        public Button pageMain => new Button(_webElement, "//*[@class='metro login-fon register-metro']");

        public Button btnSubmit => new Button(_webElement, "//*[@id='signupbtn']");

        public InputField fldRegisterName => new InputField(_webElement, "//*[@id='registerName']");

        public InputField alertRegisterName => new InputField(_webElement, "//*[@id='registerName']//following::span[@for='UsernameOrEmail']");

        //xpath for alert message - fldRegisterName
        ////*[@id='registerName']//following::span[@for='UsernameOrEmail']

        //public bool IsPresentPageMain()
        //{
        //   return pageMain()
        //}
    }
}
