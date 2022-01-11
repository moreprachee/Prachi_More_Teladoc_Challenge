using TechTalk.SpecFlow;
using NUnit.Framework;
using Prachi_More_Teladoc_Challenge.PageObjects;

namespace Prachi_More_Teladoc_Challenge.StepDefinitions
{
    [Binding]
    public class AddDeleteUserStepDefinitions
    {
        LandingPage landingPageObj = new LandingPage();

        [Given(@"I am on the site")]
        public void GivenIAmOnTheSite()
        {
            Assert.IsTrue(landingPageObj.VerifyOnTheSitePage(), "Site not launched");
        }

        [Then(@"I Add User")]
        public void ThenIAddAUser(Table userTable)
        {
            landingPageObj.AddUser(userTable);
        }

        [Then(@"I verify username (.*) has been added")]
        public void ThenIVerifyUserHasBeenAdded(string userName)
        {
            Assert.IsTrue(landingPageObj.VerifyUserIsAdded(userName), "Added user couldn't be found on the page");
        }

        [Then(@"I delete the user with username (.*)")]
        public void ThenIdeleteTheUser(string userName)
        {
            Assert.IsTrue(landingPageObj.DeleteUser(userName), "User couldn't be deleted");
        }

        [Then(@"I verify user with username (.*) has been deleted")]
        public void ThenIVerifyUserHasBeenDeleted(string userName)
        {
            Assert.IsTrue(landingPageObj.VerifyUserIsDeleted(userName), "User couldn't be deleted");
        }
    }
}
