using System;
using System.IO;
using Newtonsoft.Json;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace StudentManagement.FunctionalTests
{
    public class TestsFixture : IDisposable
    {
        public IWebDriver Driver;
        public readonly string AppUrl;
        public readonly string ScreenShotLocation;
        public readonly bool RunHeadless = false;

        public TestsFixture()
        {
            var config = JsonConvert.DeserializeObject<TestConfiguration>(File.ReadAllText("appsettings.test.json"));
            AppUrl = config.AppUrl;
            RunHeadless = config.Headless;
            ScreenShotLocation = config.ScreenShotLocation;
            RefreshDriver();
        }

        public void RefreshDriver()
        {
            Driver?.Quit();

            var options = new FirefoxOptions();

            if (RunHeadless)
            {
                options.AddArguments("-headless");
            }

            Driver = new FirefoxDriver(options);
        }

        public void Dispose()
        {
            Driver.Quit();
        }
    }
}