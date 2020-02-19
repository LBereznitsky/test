using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Serilog;
using System;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Threading;

namespace PageObjects
{
    public class WebElement : IWebElement
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
                return null;
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
                //element.SendKeys(Keys.Enter);
                Thread.Sleep(500);
            }
        }

        public string TagName => throw new NotImplementedException();

        string IWebElement.Text => throw new NotImplementedException();

        public bool Enabled => throw new NotImplementedException();

        public bool Selected => throw new NotImplementedException();

        public Point Location => throw new NotImplementedException();

        public Size Size => throw new NotImplementedException();

        public bool Displayed
        {
            get
            {
                var element = TryFindSingleIWebElement(); 
                
                if (element != null)
                {
                    _logger.Debug($"Element is displayed - {_xpath}");
                    return element.Displayed;
                }
                else
                {                    
                    _logger.Error($"Element is NOT displayed - {_xpath}");
                    return false;
                }
            }
        }


        public void Clear()
        {
            var element = TryFindSingleIWebElement();
            element.Clear();
        }

        public void SendKeys(string text)
        {
            var element = TryFindSingleIWebElement();
            element.SendKeys(text);
        }

        public void Submit()
        {
            var element = TryFindSingleIWebElement();
            element.Submit();
        }

        public string GetAttribute(string attributeName)
        {
            var element = TryFindSingleIWebElement();
            return element.GetAttribute(attributeName);
        }

        public string GetProperty(string propertyName)
        {
            var element = TryFindSingleIWebElement();
            return element.GetProperty(propertyName);
        }

        public string GetCssValue(string propertyName)
        {
            var element = TryFindSingleIWebElement();
            return element.GetCssValue(propertyName);
        }

        public IWebElement FindElement(By by)
        {
            throw new NotImplementedException();
        }

        public ReadOnlyCollection<IWebElement> FindElements(By by)
        {
            throw new NotImplementedException();
        }
    }
}
