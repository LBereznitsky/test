using OpenQA.Selenium.Chrome;
using SeleniumTests.SeleniumDriver.WebElements;

namespace WebPages
{
    public class Button
    {
        private readonly WebElement _button;
        public Button(ChromeDriver element, string xpath)
        {
            _button = new WebElement(element, xpath);
        }  
        
        public void ClickButton()
        {
            _button.Click();
        }
    }
}