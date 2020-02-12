using OpenQA.Selenium.Chrome;
using SeleniumTests.SeleniumDriver.WebElements;

namespace WebPages
{
    public class InputField
    {
        private readonly WebElement _inputField;
        public InputField(ChromeDriver element, string xpath)
        {
            _inputField = new WebElement(element, xpath);
        }  
        
        public void SetText(string text)
        {
            _inputField.Text = text;
        }

        public string GetText()
        {
            return _inputField.Text;
        }
    }
}