using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageObjects
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
