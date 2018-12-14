using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;

namespace UserAcceptanceTests
{
    [TestClass]
    public class TestBMICategory
    {

        private TestContext testContextInstance;

        public TestContext TestContext
        {
            get { return testContextInstance; }
            set { testContextInstance = value; }
        }

        private String webAppUri;
        

        [TestInitialize]                
        public void Setup()
        {
            this.webAppUri = testContextInstance.Properties["webAppUri"].ToString();
            
        }

        [TestMethod]
        public void TestBMICat()
        {
            //using (IWebDriver driver = new ChromeDriver(Environment.GetEnvironmentVariable("ChromeWebDriver")))
            using (IWebDriver driver = new ChromeDriver())
            {

                driver.Navigate().GoToUrl(webAppUri);

                IWebElement weightInStoneElement = driver.FindElement(By.Id("BMI_WeightStones"));
                // enter 10 in element
                weightInStoneElement.SendKeys("10");

                // get weight in stone element
                IWebElement weightInPoundsElement = driver.FindElement(By.Id("BMI_WeightPounds"));
                // enter 10 in element
                weightInPoundsElement.SendKeys("10");

                // get weight in stone element
                IWebElement heightFeetElement = driver.FindElement(By.Id("BMI_HeightFeet"));
                // enter 10 in element
                heightFeetElement.SendKeys("5");

                // get weight in stone element
                IWebElement heightInchesElement = driver.FindElement(By.Id("BMI_HeightInches"));
                // enter 10 in element
                heightInchesElement.SendKeys("5");

                // submit the form
                driver.FindElement(By.Id("convertForm")).Submit();

                // explictly wait for result with "BMIValue" item
                IWebElement BMIValueElement = new WebDriverWait(driver, TimeSpan.FromSeconds(10))
                    .Until(c => c.FindElement(By.Id("bmiCat")));


                // item comes back like "BMIValue: 24.96"
                String bmi = BMIValueElement.Text.ToString();

                // 10 Celsius = 50 Fahrenheit, assert it
                StringAssert.Contains(bmi, "Your BMI Category is Overweight");

                driver.Quit();
            }
        }
    }
}