using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageObjects
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
