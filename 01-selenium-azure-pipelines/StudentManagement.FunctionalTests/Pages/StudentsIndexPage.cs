using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace StudentManagement.FunctionalTests.Pages
{
    public class StudentsIndexPage : BasePage
    {
        private const string HeaderPath = "/html/body/div/main/h1";
        public const string TableRowPath = "/html/body/div/main/table/tbody/tr";

        public StudentsIndexPage(IWebDriver driver, string screenShotLocation) : base(driver, screenShotLocation)
        {
        }

        public string GetTitle()
        {
            var element = Driver.FindElement(By.XPath(HeaderPath));
            return element.Text;
        }

        public int GetStudentCount()
        {
            var element = Driver.FindElements(By.XPath(TableRowPath));
            return element.Count;
        }

        public override bool IsPageLoaded()
        {
            try
            {
                var element = Driver.FindElement(By.XPath(HeaderPath));
                return element.Text.Contains("e");
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
    }
}