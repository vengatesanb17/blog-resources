using System;
using StudentManagement.FunctionalTests.Pages;
using Xunit;

namespace StudentManagement.FunctionalTests.Students
{
    public class StudentCreatePageTests : IClassFixture<TestsFixture>
    {
        private readonly TestsFixture _fixture;

        public StudentCreatePageTests(TestsFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public void LoadsCreatePage()
        {
            _fixture.Driver.Navigate().GoToUrl(_fixture.AppUrl + "/Students/Create");

            var indexPage = new StudentsIndexPage(_fixture.Driver, _fixture.ScreenShotLocation);

            Assert.True(indexPage.GetTitle() == "Create");
        }

        [Fact]
        public void CanCreateStudent()
        {
            _fixture.Driver.Navigate().GoToUrl(_fixture.AppUrl + "/Students");
            var indexPage = new StudentsIndexPage(_fixture.Driver, _fixture.ScreenShotLocation);
            var studentCount = indexPage.GetStudentCount();

            _fixture.Driver.Navigate().GoToUrl(_fixture.AppUrl + "/Students/Create");
            var studentCreatePage = new StudentCreatePage(_fixture.Driver, _fixture.ScreenShotLocation);
            var dtStr = DateTime.UtcNow.ToString("MM/dd/yyyy");

            studentCreatePage.FillField(StudentCreatePage.LastNamePath, "MyNewLastName");
            studentCreatePage.FillField(StudentCreatePage.FirstNamePath, "MyNewFirstName");
            studentCreatePage.FillField(StudentCreatePage.EnrollmentDatePath, dtStr);

            studentCreatePage.TakeScreenshot();
            studentCreatePage.Submit();

            Assert.True(indexPage.GetTitle() == "Index");
            
            Assert.Equal(studentCount + 1, indexPage.GetStudentCount());
        }
    }
}