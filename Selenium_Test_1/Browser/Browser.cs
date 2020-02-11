using System.Configuration;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support;

namespace Selenium_Test_1
{
    public class Browser
    {
        public Browser Start()
        {
            var options = new ChromeOptions();
            options.AddUserProfilePreference("disable-popup-blocking", "true");
            options.AddUserProfilePreference("download.prompt_for_download", false);
            options.AddUserProfilePreference("download.directory_upgrade", true);
            options.AddUserProfilePreference("safebrowsing.enabled", true);
            options.AddArgument("--disable-notifications");


            //MaximizeWindow();
            //driver.Manage().Window.Maximize();

            //return Browser(options);
        }

        //public Browser()
        //{
        //    var driver = Initialize();
        //    driver.Manage().Window.Maximize();
        //}

    }
    
}
