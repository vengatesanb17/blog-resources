using StudentManagement.FunctionalTests.Pages;
using Xunit;

namespace StudentManagement.FunctionalTests.Students
{
    public class StudentsIndexPageTests : IClassFixture<TestsFixture>
    {
        private readonly TestsFixture _fixture;

        public StudentsIndexPageTests(TestsFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public void LoadsStudents()
        {
            _fixture.Driver.Navigate().GoToUrl(_fixture.AppUrl + "/Students");

            var indexPage = new StudentsIndexPage(_fixture.Driver, _fixture.ScreenShotLocation);
            var studentCount = indexPage.GetStudentCount();
            indexPage.TakeScreenshot();
            Assert.True(studentCount > 0);
        }
    }
}