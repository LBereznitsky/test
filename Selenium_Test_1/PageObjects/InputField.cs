using OpenQA.Selenium.Chrome;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageObjects
{
    public class InputField : WebElement
    {
        private readonly WebElement _inputField;

        private readonly ILogger _logger;

        public InputField(ILogger logger, ChromeDriver element, string xpath) : base(logger, element, xpath)
        {
            _inputField = new WebElement(logger, element, xpath);
            _logger = logger;
        }

        public void SetText(string text)
        {
            _inputField.Text = text;
            _logger.Information($"SetText: '{text}'");
        }

        public string GetText()
        {
            return _inputField.Text;
        }
    }
}
