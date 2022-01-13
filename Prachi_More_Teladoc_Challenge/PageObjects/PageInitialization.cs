using SeleniumExtras.PageObjects;

namespace Prachi_More_Teladoc_Challenge.PageObjects
{
    public static class PageInitialization
    {
        public static LandingPage LandingPage
        {
            get
            {
                var LandingPage = new LandingPage();
                PageFactory.InitElements(Setup.driver, LandingPage);
                return LandingPage;
            }            
        }
    }
}
