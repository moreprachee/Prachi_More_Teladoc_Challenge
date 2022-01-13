using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using TechTalk.SpecFlow;

namespace Prachi_More_Teladoc_Challenge.PageObjects
{
    public class LandingPage
    {
        //Web Elements 
        #region WebElements
        [FindsBy(How=How.ClassName, Using ="btn-link")]
        public IWebElement addUserBtn = null;

        [FindsBy(How = How.Name, Using = "FirstName")]
        public IWebElement firstName = null;

        [FindsBy(How = How.Name, Using = "LastName")]
        public IWebElement lastName = null;

        [FindsBy(How = How.Name, Using = "UserName")]
        public IWebElement userName = null;

        [FindsBy(How = How.Name, Using = "Password")]
        public IWebElement password = null;

        [FindsBy(How = How.Name, Using = "optionsRadios")]
        public IList<IWebElement> radioBtns = null;

        [FindsBy(How = How.XPath, Using = "//td/label")]
        public IList<IWebElement> values = null;

        [FindsBy(How = How.Name, Using = "RoleId")]
        public IWebElement dropdown = null;

        [FindsBy(How = How.Name, Using = "Email")]
        public IWebElement email = null;
        
        [FindsBy(How = How.Name, Using = "Mobilephone")]
        public IWebElement cellPhone = null;       

        [FindsBy(How = How.ClassName, Using = "btn-success")]
        public IWebElement saveBtn = null;
        
        [FindsBy(How = How.XPath, Using = "//tbody/tr")]
        public IList<IWebElement> rows = null;
        
        [FindsBy(How = How.XPath, Using = "//button[contains(text(),'OK')]")]
        public IWebElement okBtn = null;

        #endregion

        //Actions
        public bool VerifyOnTheSitePage()
        {
            var flag = false;

            if (Setup.driver.Url.Contains("way2automation"))
            {
                flag = true;
            }
            return flag;
        }
        public void AddUser(Table userTable)
        {
            var fName = userTable.Rows[0][0].ToString();
            var lName = userTable.Rows[0][1].ToString();
            var uName = userTable.Rows[0][2].ToString();
            var pwd = userTable.Rows[0][3].ToString();
            var customer = userTable.Rows[0][4].ToString();
            var role = userTable.Rows[0][5].ToString();
            var emailField = userTable.Rows[0][6].ToString();
            var cPhone = userTable.Rows[0][7].ToString();
           
            //Click on Add User button
            addUserBtn.Click();
            
            //Add user details
            firstName.SendKeys(fName);            
            lastName.SendKeys(lName);            
            userName.SendKeys(uName);            
            password.SendKeys(pwd);            

            for (int i=0;i<radioBtns.Count;i++)
            {
                if(values[i].Text == customer )
                {
                    radioBtns[i].Click();
                    break;
                }
            }

            SelectElement selectEle = new SelectElement(Setup.driver.FindElement(By.Name("RoleId")));
            selectEle.SelectByText(role);

            email.SendKeys(emailField);            
            cellPhone.SendKeys(cPhone);
            
            //Click on Save button
            saveBtn.Click();
        }

        public bool VerifyUserIsAdded(string userName)
        {
            var flag = false;            

            for (int i = 0; i < rows.Count; i++)
            {
                if (rows[i].Text.Contains(userName))
                {
                    flag = true;
                    break;
                }
            }
            return flag;
        }
        public bool DeleteUser(string deleteUserName)
        {
            var flag = false;            

            for (int i = 0; i <= rows.Count; i++)
            {
                if (rows[i].Text.Contains(deleteUserName))
                {
                    var rowValue = i + 1;
                    IWebElement deleteBtn = Setup.driver.FindElement(By.XPath("//tbody/tr[" + rowValue + "]/td[11]/button"));

                    //Click on 'x' button
                    deleteBtn.Click();

                    //Click on Ok button                    
                    okBtn.Click();

                    flag = true;
                    break;
                }
            }
            return flag;
        }
        public bool VerifyUserIsDeleted(string deletedUserName)
        {
            var flag = true;            

            foreach (var row in rows)
            {
                var value = row.Text;

                if (row.Text.Contains(deletedUserName))
                {
                    flag = false;
                }
            }
            return flag;
        }
    }
}
