using OpenQA.Selenium.Chrome;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageObjects
{
    public class AlertLabel : WebElement
    {
        private readonly WebElement _alertLabel;

        private readonly ILogger _logger;

        public AlertLabel(ILogger logger, ChromeDriver element, string xpath) : base(logger, element, xpath)
        {
            _alertLabel = new WebElement(logger, element, xpath);
            _logger = logger;
        }        

        public string GetText()
        {
            string text = _alertLabel.Text;
            _logger.Information($"GetText: '{text}'");
            return text;
        }
    }
}
