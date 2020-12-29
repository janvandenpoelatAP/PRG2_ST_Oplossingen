using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace SeleniumTestBrowsers.Tests
{
    public class BrowserOperations
    {
        private IWebDriver _webDriver;
        public BrowserOperations(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }
        public void InitBrowser()
        {
            _webDriver.Manage().Window.Maximize();
        }
        public string Title
        {
            get { return _webDriver.Title; }
        }
        public void Goto(string url)
        {
            _webDriver.Url = url;
        }
        public void Close()
        {
            _webDriver.Quit();
        }
        public IWebDriver WebDriver
        {
            get { return _webDriver; }
        }
    }


    [TestFixture(Description = "Test Case 01: Chrome")]
    public class TestCase01
    {
        BrowserOperations brow;

        [SetUp]
        public void StartBrowser()
        {
            brow = new BrowserOperations(new ChromeDriver());
            brow.InitBrowser();
        }


        [Test(Description = "Test Search")]
        public void TestSearch()
        {
            brow.Goto("https://www.duckduckgo.com");
            System.Threading.Thread.Sleep(1500);

            IWebElement element = brow.WebDriver.FindElement(By.XPath("//*[@id='search_form_input_homepage']"));

            element.SendKeys("LambdaTest");

            element.Submit();

            System.Threading.Thread.Sleep(1500);
        }

        [TearDown]
        public void CloseBrowser()
        {
            brow.Close();
        }
    }
    [TestFixture(Description = "Test Case 02: Firefox")]
    public class TestCase02
    {
        BrowserOperations brow;

        [SetUp]
        public void StartBrowser()
        {
            brow = new BrowserOperations(new FirefoxDriver());
            brow.InitBrowser();
        }
        [Test(Description = "Test Search")]
        public void TestSearch()
        {
            brow.Goto("https://www.duckduckgo.com");
            System.Threading.Thread.Sleep(1500);

            IWebElement element = brow.WebDriver.FindElement(By.XPath("//*[@id='search_form_input_homepage']"));

            element.SendKeys("LambdaTest");

            element.Submit();

            System.Threading.Thread.Sleep(1500);

        }

        [TearDown]
        public void CloseBrowser()
        {
            brow.Close();
        }
    }

    [TestFixture(Description = "Test Case 03: Bavigation AP Webstek")]
    public class TestCase03
    {
        [Test(Description = "Chrome: Test Navigation")]
        public void ChromeTestSearch()
        {
            BrowserOperations  brow = new BrowserOperations(new ChromeDriver());
            brow.InitBrowser();

            brow.Goto("http://ap.be");

            System.Threading.Thread.Sleep(1500);

            IWebElement element = brow.WebDriver.FindElement(By.XPath("//a[contains(text(), 'Professionele Bachelor')]"));

            element.Click();

            System.Threading.Thread.Sleep(1500);

            element = brow.WebDriver.FindElement(By.XPath("//a[contains(text(), 'Accountancy')]"));

            element.Click();

            System.Threading.Thread.Sleep(1500);

            brow.Close();
        }

        [Test(Description = "Chrome: Test Navigation")]
        public void FirefoxTestSearch()
        {
            BrowserOperations brow = new BrowserOperations(new FirefoxDriver());
            brow.InitBrowser();

            brow.Goto("http://ap.be");

            System.Threading.Thread.Sleep(1500);

            IWebElement element = brow.WebDriver.FindElement(By.XPath("//a[contains(text(), 'Professionele Bachelor')]"));

            element.Click();

            System.Threading.Thread.Sleep(1500);

            element = brow.WebDriver.FindElement(By.XPath("//a[contains(text(), 'Accountancy')]"));

            element.Click();

            System.Threading.Thread.Sleep(1500);
            brow.Close();
        }
    }
}