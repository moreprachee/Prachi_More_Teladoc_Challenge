using System;
using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using TechTalk.SpecFlow;


namespace Prachi_More_Teladoc_Challenge.PageObjects
{
    public class LandingPage
    {
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


            IWebElement addUserBtn = Setup.driver.FindElement(By.ClassName("btn-link"));
            addUserBtn.Click();

            IWebElement firstName = Setup.driver.FindElement(By.Name("FirstName"));
            firstName.SendKeys(fName);

            IWebElement lastName = Setup.driver.FindElement(By.Name("LastName"));
            lastName.SendKeys(lName);

            IWebElement userName = Setup.driver.FindElement(By.Name("UserName"));
            userName.SendKeys(uName);

            IWebElement password = Setup.driver.FindElement(By.Name("Password"));
            password.SendKeys(pwd);

            IList<IWebElement> radioBtns = Setup.driver.FindElements(By.Name("optionsRadios"));
            IList<IWebElement> values = Setup.driver.FindElements(By.XPath("//td/label"));

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

            IWebElement email = Setup.driver.FindElement(By.Name("Email"));
            email.SendKeys(emailField);

            IWebElement cellPhone = Setup.driver.FindElement(By.Name("Mobilephone"));
            cellPhone.SendKeys(cPhone);

            IWebElement saveBtn = Setup.driver.FindElement(By.ClassName("btn-success"));
            saveBtn.Click();
        }

        public bool VerifyUserIsAdded(string userName)
        {
            var flag = false;
            IList<IWebElement> rows = Setup.driver.FindElements(By.XPath("//tbody/tr"));

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
            IList<IWebElement> rows = Setup.driver.FindElements(By.XPath("//tbody/tr"));

            for (int i = 0; i <= rows.Count; i++)
            {
                if (rows[i].Text.Contains(deleteUserName))
                {
                    var rowValue = i + 1;
                    IWebElement delete = Setup.driver.FindElement(By.XPath("//tbody/tr[" + rowValue + "]/td[11]/button"));

                    delete.Click();

                    IWebElement okBtn = Setup.driver.FindElement(By.XPath("//button[contains(text(),'OK')]"));
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
            IList<IWebElement> rows = Setup.driver.FindElements(By.XPath("//tbody/tr"));

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
