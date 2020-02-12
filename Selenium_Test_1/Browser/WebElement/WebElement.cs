
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using OpenQA.Selenium;
using System.Threading;
using OpenQA.Selenium.Chrome;

namespace SeleniumTests.SeleniumDriver.WebElements
{
    public partial class WebElement : ICloneable
    {
        private By _firstSelector;
        private IList<IWebElement> _searchCache;
        private int _timeoutInSeconds = 10;
        private int _searchTries = 1;
        private bool IsSatisfied { get; set; }
        private int _index;

        private readonly ChromeDriver _browser;

        public WebElement (ChromeDriver browser)
        {
            _browser = browser;           
        }

        
        
        private IWebElement FindSingleIWebElement()
        {
            try
            {      
                IList<IWebElement> elements;     
                
                elements = FindIWebElements();

                int elementsCount = elements.Count();                

                var element = elements.Count() == 1
                    ? elements.Single()
                    : _index == -1
                        ? elements.Last()
                        : elements.ElementAt(_index);

                return element;
            }
            catch (StaleElementReferenceException)
            {
                return FindSingleIWebElement();
            }           
        }

        private IList<IWebElement> FindIWebElements()
        {
            try
            {
                var resultList = _browser.FindElements(_firstSelector).ToList(); 
                return resultList;
            }
            catch (StaleElementReferenceException)
            {
                //Logs.Logger.Debug($"Handle StaleElementReferenceExeption in FindIWebElements() method: {_firstSelector}");
                return FindIWebElements();
            }
            //catch (Exception e)
            //{
            //    //Logs.DefaultExceptionMSG = e.Message;
            //    if (Logs.DefaultExceptionMSG.Contains("unknown error"))
            //    {
            //        //throw new Exception(Logs.DefaultExceptionMSG = "UNKNOWN ERROR" + e.Message);
            //    }
            //    else if (String.IsNullOrEmpty(Logs.DefaultExceptionMSG))
            //    {
            //        //throw new Exception(Logs.DefaultExceptionMSG = $"ERROR: FindIWebElements() FAILED");
            //    }
            //    else
            //    {
            //        //throw new Exception(Logs.DefaultExceptionMSG);
            //    }
            //}
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
