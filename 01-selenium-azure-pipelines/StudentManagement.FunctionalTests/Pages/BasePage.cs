using System;
using System.IO;
using System.Runtime.CompilerServices;
using OpenQA.Selenium;

namespace StudentManagement.FunctionalTests.Pages
{
    public abstract class BasePage
    {
        protected readonly IWebDriver Driver;
        protected readonly string ScreenShotLocation;

        protected BasePage(IWebDriver driver, string screenShotLocation = "")
        {
            Driver = driver;
            ScreenShotLocation = screenShotLocation;
        }

        public virtual bool IsPageLoaded()
        {
            return false;
        }

        public void TakeScreenshot([CallerMemberName] string callingMember = "sc")
        {
            var screenshotDriver = Driver as ITakesScreenshot;
            var screenshot = screenshotDriver?.GetScreenshot();
            if (!Directory.Exists(ScreenShotLocation))
            {
                Directory.CreateDirectory(ScreenShotLocation);
            }

            screenshot?.SaveAsFile(Path.Join(ScreenShotLocation, $"{callingMember}_{DateTime.Now.ToFileTime()}.png"),
                ScreenshotImageFormat.Png);
        }
    }
}