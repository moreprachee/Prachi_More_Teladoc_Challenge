using TechTalk.SpecFlow;
using NUnit.Framework;
using Prachi_More_Teladoc_Challenge.PageObjects;

namespace Prachi_More_Teladoc_Challenge.StepDefinitions
{
    [Binding]
    public class AddDeleteUserStepDefinitions
    {

        [Given(@"I am on the site")]
        public void GivenIAmOnTheSite()
        {
            Assert.IsTrue(PageInitialization.LandingPage.VerifyOnTheSitePage(), "Site not launched");
        }

        [Then(@"I Add User")]
        public void ThenIAddAUser(Table userTable)
        {
            PageInitialization.LandingPage.AddUser(userTable);
        }

        [Then(@"I verify username (.*) has been added")]
        public void ThenIVerifyUserHasBeenAdded(string userName)
        {
            Assert.IsTrue(PageInitialization.LandingPage.VerifyUserIsAdded(userName), "Added user couldn't be found on the page");
        }

        [Then(@"I delete the user with username (.*)")]
        public void ThenIdeleteTheUser(string userName)
        {
            Assert.IsTrue(PageInitialization.LandingPage.DeleteUser(userName), "User couldn't be deleted");
        }

        [Then(@"I verify user with username (.*) has been deleted")]
        public void ThenIVerifyUserHasBeenDeleted(string userName)
        {
            Assert.IsTrue(PageInitialization.LandingPage.VerifyUserIsDeleted(userName), "User couldn't be deleted");
        }
    }
}
