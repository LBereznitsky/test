using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;

namespace Selenium_Test_1
{
    public class Browser
    {
        public Browser()
        {
            var options = new ChromeOptions();
            options.AddUserProfilePreference("disable-popup-blocking", "true");
            options.AddUserProfilePreference("download.prompt_for_download", false);
            options.AddUserProfilePreference("download.directory_upgrade", true);
            options.AddUserProfilePreference("safebrowsing.enabled", true);
            options.AddArgument("--disable-notifications");

            ChromeDriver driver = new ChromeDriver(options);

            //MaximizeWindow();
            driver.Manage().Window.Maximize();
        }
    }
    
}
