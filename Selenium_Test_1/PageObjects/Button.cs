using OpenQA.Selenium.Chrome;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageObjects
{
    public class Button : WebElement
    {
        private readonly WebElement _button;        

        public Button(ILogger logger, ChromeDriver element, string xpath) : base(logger, element, xpath)
        {
            _button = new WebElement(logger, element, xpath);           
        }       
    }
}
