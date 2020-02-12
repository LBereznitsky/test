using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Configuration;
using System.Threading;

namespace Selenium_Test_1
{
    [TestClass]
    public class TestSuite_1 : TestBase
    {
        [TestMethod]
        public void TestMethod1()
        {            
            CurrentBrowser = Initialize();
            GoToUrl(CurrentBrowser, DefaultUrl);
            Thread.Sleep(30000);
            Close(CurrentBrowser);
        }

        [TestMethod]
        public void TestMethod2()
        {
            DefaultUrl = "https://www.google.com/";
            CurrentBrowser = Initialize();
            GoToUrl(CurrentBrowser, DefaultUrl);
            Thread.Sleep(30000);
            Close(CurrentBrowser);
        }       
    }
}
