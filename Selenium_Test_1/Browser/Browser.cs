using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Serilog;
using System.Diagnostics.Contracts;
using TestsCommon;

namespace TestsBrowser
{
    public class Browser
    {
        protected string DefaultUrl { get; set; } = "https://reverent-aryabhata-11cf33.netlify.com/";

        public ChromeDriver CurrentBrowser { get; set; }
        public ILogger Logger { get; set; }        

        protected ChromeDriver Initialize()
        {
            Logger = Logs.InitializeLogs();
            ChromeOptions options = new ChromeOptions();
            options.AddUserProfilePreference("disable-popup-blocking", "true");
            options.AddUserProfilePreference("download.prompt_for_download", false);
            options.AddUserProfilePreference("download.directory_upgrade", true);
            options.AddUserProfilePreference("safebrowsing.enabled", true);
            options.AddArgument("--disable-notifications");
            ChromeDriver browser = new ChromeDriver(options);            
            browser.Manage().Window.Maximize();
            Logger.Information("Browser Initialize");
            return browser;
        }

        public void GoToUrl(ChromeDriver browser, string url)
        {
            browser?.Navigate().GoToUrl(url);
            Logger.Information($"Naviagate to URL: {url}");

        }

        public void Close(ChromeDriver browser)
        {                
            browser?.Quit();
            browser?.Dispose();
            Logger.Information("Browser Quit");
        }        
    }


}
