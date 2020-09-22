using OpenQA.Selenium;

namespace StudentManagement.FunctionalTests.Pages
{
    public class StudentCreatePage : BasePage
    {
        private const string HeaderPath = "/html/body/div/main/h1";
        public const string LastNamePath = "//*[@id=\"LastName\"]";
        public const string FirstNamePath = "//*[@id=\"FirstName\"]";
        public const string EnrollmentDatePath = "//*[@id=\"EnrollmentDate\"]";
        public const string SubmitButtonPath = "/html/body/div/main/div[1]/div/form/div[4]/input";

        public StudentCreatePage(IWebDriver driver, string screenShotLocation) : base(driver, screenShotLocation)
        {
        }

        public string GetTitle()
        {
            var element = Driver.FindElement(By.XPath(HeaderPath));
            return element.Text;
        }

        public void FillField(string field, string value)
        {
            var element = Driver.FindElement(By.XPath(field));
            element.SendKeys(value);
        }

        public void Submit()
        {
            var submitButton = Driver.FindElement(By.XPath(SubmitButtonPath));
            submitButton.Click();
        }

        public override bool IsPageLoaded()
        {
            try
            {
                return GetTitle() == "Create";
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
    }
}