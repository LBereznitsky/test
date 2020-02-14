using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace PageObjects
{
    public class WebElement : ICloneable
    {
        private string _xpath;

        private readonly ChromeDriver _webElement;

        public WebElement(ChromeDriver element, string xpath)
        {
            _webElement = element;
            _xpath = xpath;
        }

        private IWebElement FindSingleIWebElement()
        {
            var element = _webElement.FindElementByXPath(_xpath);
            return element;
        }

        public void Click()
        {
            var element = FindSingleIWebElement();
            element.Click();
        }

        public string Text
        {
            get
            {
                var element = FindSingleIWebElement();
                return element.Text;
            }
            set
            {
                var element = FindSingleIWebElement();
                element.Click();
                element.SendKeys(Keys.Control + "a");
                element.SendKeys(Keys.Backspace);
                element.SendKeys(value);
            }
        }

        public bool IsDisplayed()
        {
            var element = FindSingleIWebElement();
            return element.Displayed;
        }

        object ICloneable.Clone()
        {
            return Clone();
        }

        public WebElement Clone()
        {
            return (WebElement)MemberwiseClone();
        }

    }
}
