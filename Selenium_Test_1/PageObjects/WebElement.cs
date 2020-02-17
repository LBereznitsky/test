using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Serilog;

namespace PageObjects
{
    public class WebElement : ICloneable
    {
        private readonly string _xpath;

        private readonly ILogger _logger;

        private readonly ChromeDriver _webElement;

        public WebElement(ILogger logger, ChromeDriver element, string xpath)
        {
            _webElement = element;
            _xpath = xpath;
            _logger = logger;
        }

        private IWebElement TryFindSingleIWebElement()
        {
            try
            {
                var element = _webElement.FindElementByXPath(_xpath);                
                _logger.Information($"TryFindSingleIWebElement - {_xpath}");
                return element;
            }
            catch (StaleElementReferenceException)
            {
                _logger.Debug($"Handle StaleElementReferenceExeption for single element - {_xpath}");
                return TryFindSingleIWebElement();
            }
            catch (ElementNotVisibleException)
            {
                throw;
            }           
            catch (InvalidSelectorException e)
            {
                _logger.Error(e.ToString());                
                throw;
            }
            catch (WebDriverException e)
            {
                _logger.Error(e.ToString());                
                throw;
            }           
        }
        

        public void Click()
        {
            var element = TryFindSingleIWebElement();
            element.Click();
        }

        protected internal string Text
        {
            get
            {
                var element = TryFindSingleIWebElement();
                return element.Text;
            }
            set
            {
                var element = TryFindSingleIWebElement();
                element.Click();
                element.SendKeys(Keys.Control + "a");
                element.SendKeys(Keys.Backspace);
                element.SendKeys(value);
            }
        }

        public bool IsDisplayed()
        {
            var element = TryFindSingleIWebElement();
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
