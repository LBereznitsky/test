using OpenQA.Selenium.Chrome;


namespace Selenium_Test_1
{
    public class Browser
    {
        protected string DefaultUrl { get; set; } = "https://reverent-aryabhata-11cf33.netlify.com/";

        public ChromeDriver CurrentBrowser { get; set; }

        protected ChromeDriver Initialize()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddUserProfilePreference("disable-popup-blocking", "true");
            options.AddUserProfilePreference("download.prompt_for_download", false);
            options.AddUserProfilePreference("download.directory_upgrade", true);
            options.AddUserProfilePreference("safebrowsing.enabled", true);
            options.AddArgument("--disable-notifications");
            ChromeDriver browser = new ChromeDriver(options);
            browser.Manage().Window.Maximize();
            return browser;
        }

        public void GoToUrl(ChromeDriver browser, string url)
        {
            browser?.Navigate().GoToUrl(url);
        }

        public void Close(ChromeDriver browser)
        {
            browser?.Quit();
            browser?.Dispose();            
        }
        
    }
}
