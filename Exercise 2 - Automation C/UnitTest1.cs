using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;

namespace Exercise_2___Automation_C
{
    //Web Page interaction and Validation Class
    //Use an independent class for execution (test cases) and use of interaction methods.
    [TestClass]
    public class UnitTest1
    {
        private IWebDriver driver;

        [TestInitialize]
        public void BrowserFactory()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
        }

        [TestMethod]
        public void Signup()
        {
            //Text to be validated
            String Text1 = "Facebook - Log In or Sign Up";
            String Text2 = "Connect with friends and the world around you on Facebook.";

            HomePage home = new HomePage(driver);
            home.goToPage();
            Thread.Sleep(1000);

            //Use Asserts and should be on the Web Page Interaction class
            //Use a Get that return a string to obtain driver title
            home.TitleValidation();
            String Title = home.Title;
            Assert.AreEqual(Text1, Title, "The Title is incorrect");

            //Validate following text is present: Connect with friends and the world around you on Facebook.
            Assert.AreEqual(Text2, home.TextValidation(), "Text is incorrect");
            if (Text2 == home.TextValidation())
                Console.WriteLine("The Text validation was succesful");
            Thread.Sleep(1000);
            home.Newact();
            Thread.Sleep(1000);

            //Fill all Sign Up section.
            home.FillForm("Norberto", "Cabrera", "4771390913", "password");
            Console.WriteLine("FirstName: Norberto, LastName: Cabrera, Mobile; 4771390913, Password: password");
            Thread.Sleep(1000);

            //Choose a different Birthday not the default one.
            home.SelectBirthday("Sep", "29", "1982");
            Thread.Sleep(1000);

            //Click on Female.
            home.SelectGender("f");
            Thread.Sleep(1000);
        }

        [TestCleanup()]
        public void testcleanp()
        {
            driver.Quit();
        }
    }
}
