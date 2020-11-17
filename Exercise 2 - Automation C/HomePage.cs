using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise_2___Automation_C
{
    //Browser Creation and element interaction Class
    //Use an independent class for browser creation and element interaction for example clicks, sendkeys, etc
    class HomePage
    {
        private IWebDriver Webdriver;
        //D. Use A property to obtain Web title and assert to validate it.
        public String Title { get; set; }

        public HomePage(IWebDriver Webdriver)
        {
            this.Webdriver = Webdriver;
            PageFactory.InitElements(Webdriver, this);
        }

        [FindsBy(How = How.CssSelector, Using = "body.fbIndex.UIPage_LoggedOut._-kb._605a.b_c3pyn-ahh.chrome.webkit.win.x1.Locale_en_US.cores-gte4.hasAXNavMenubar._19_u:nth-child(2) div._li:nth-child(2) div.uiContextualLayerParent:nth-child(2) div.fb_content.clearfix:nth-child(1) div:nth-child(1) div._8esj._95k9._8esf._8opv._8f3m._8ilg._8icx._8op_._95ka div._8esk div._8esl > h2._8eso")]
        private IWebElement label;

        [FindsBy(How = How.CssSelector, Using = "#u_0_2")]
        private IWebElement newaccount;

        [FindsBy(How = How.Name, Using = "firstname")]
        private IWebElement firstname;

        [FindsBy(How = How.Name, Using = "lastname")]
        private IWebElement lastname;

        [FindsBy(How = How.Name, Using = "reg_email__")]
        private IWebElement mobile;

        [FindsBy(How = How.Name, Using = "reg_passwd__")]
        private IWebElement password;

        [FindsBy(How = How.CssSelector, Using = "#month")]
        private IWebElement month;

        [FindsBy(How = How.CssSelector, Using = "#day")]
        private IWebElement day;

        [FindsBy(How = How.CssSelector, Using = "#year")]
        private IWebElement year;

        [FindsBy(How = How.Name, Using = "sex")]
        private IWebElement female;

        //B. Implement explicit waits for all the elements.
        public void waitelement(IWebElement locator)
        {
            WebDriverWait wait = new WebDriverWait(Webdriver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementToBeClickable(locator));
        }

        //Go to facebook.com.
        //Use of goToUrl
        //Method is in BrowserCreation Class
        public void goToPage()
        {
            Webdriver.Navigate().GoToUrl("http://www.facebook.com");
        }

        //Validate the Title of the page, should be : Facebook - Log In or Sign Up.
        public void TitleValidation()
        {
            Title = Webdriver.Title;
        }

        public String TextValidation()
        {
            waitelement(label);
            return label.Text;
        }

        public void Newact()
        {
            waitelement(newaccount);
            newaccount.Click();
        }

        //Use waits before using sendkeys
        public void FillForm(String fname, String lname, String mob, String pass)
        {
            waitelement(firstname);
            firstname.SendKeys(fname);
            waitelement(lastname);
            lastname.SendKeys(lname);
            waitelement(mobile);
            mobile.SendKeys(mob);
            waitelement(password);
            password.SendKeys(pass);
        }

        //Create a method to perform this logic, for example: "FillBDay()"

        public void SelectBirthday(String m, String d, String y)
        {
            waitelement(month);
            SelectElement selectmonth = new SelectElement(month);
            selectmonth.SelectByText(m);
            waitelement(day);
            SelectElement selectday = new SelectElement(day);
            selectday.SelectByText(d);
            waitelement(year);
            SelectElement selectyear = new SelectElement(year);
            selectyear.SelectByText(y);

        }

        //Use a Wait before interacting with the element
        public void SelectGender(String g)
        {
            if (g == "f")
            {
                waitelement(female);
                female.Click();
                Console.WriteLine("Female option was selected");
            }
            else
                Console.WriteLine("Not specified");

        }

    }
}
