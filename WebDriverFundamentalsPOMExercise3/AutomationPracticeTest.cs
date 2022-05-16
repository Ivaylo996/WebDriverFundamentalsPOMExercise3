using System;
using AutomationPracticeTests;
using AutomationPracticeTests.version2.Pages.ProductComparisonPage;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.Events;
using WebDriverFundamentalsPOMExercise3.version2.Pages.MainPage;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager.Helpers;

namespace WebDriverFundamentalsPOMExercise3
{
    public class AutomationPracticeTests : IDisposable
    {
        private static EventFiringWebDriver _driver;
        private static MainPage _mainPage;
        private static ProductComparisonPage _productComparisonPage;

        public AutomationPracticeTests()
        {
            new DriverManager().SetUpDriver(new ChromeConfig(), VersionResolveStrategy.MatchingBrowser);
            _driver = new EventFiringWebDriver(new ChromeDriver());

            _driver.Navigated += WebDriverEventHandler.FiringDriver_Navigated;
            _driver.Navigating += WebDriverEventHandler.FiringDriver_Navigating;
            _driver.ElementClicking += WebDriverEventHandler.FiringDriver_Clicking;
            _driver.ElementClicked += WebDriverEventHandler.FiringDriver_Clicked;

            _mainPage = new MainPage(_driver);
            _productComparisonPage = new ProductComparisonPage(_driver);
        }

        [SetUp]
        public void Setup()
        {
            _driver.Manage().Window.Maximize();
        }

        [TearDown]
        public void TestCleanup()
        {
            WebDriverEventHandler.PerformanceTimingService.GenerateReport();
        }

        [Test]
        [TestCase("Printed Dress", "Printed Dress", "Printed Summer Dress", "Printed Summer Dress")]
        public void InformationDisplayedOnComparisonScreen_When_ItemsAreAddedToCompare(string firstDressTitle, string firstDressActualText, string secondDressTitle, string secondDressActualText)
        {
            _mainPage.AddItemsToCompare(firstDressTitle, secondDressTitle);

            _productComparisonPage.AssertAddTwoItemsToCompare(firstDressTitle, firstDressActualText, secondDressTitle, secondDressActualText);
        }

        [Test]
        [TestCase("Printed Summer Dress", "Printed Summer Dress")]
        public void InformationDisplayedQuickView_When_ClickOnQuickView(string expectedResultDressTitle, string actualDressTitle)
        {
            _mainPage.OpenQuickView(actualDressTitle);

            _mainPage.AssertQuickviewScreen(expectedResultDressTitle, actualDressTitle);
        }

        [Test]
        [TestCase("Printed Chiffon Dress", "Printed Chiffon Dress", 2, "M", "Yellow")]
        public void ItemAddedToCartFromQuickView_When_InitializesCorrectQuantitySizeColor(string expectedResultDressTitle, string actualDressTitle, int numberOfClicksQuantity, string size, string color)
        {
            _mainPage.OpenQuickView(actualDressTitle);
            _mainPage.AddItemToCartWithQuantityColorAndSize(numberOfClicksQuantity, size, color);

            _mainPage.AssertItemOpenedFromQuickViewQuantity();
            _mainPage.AssertItemOpenedFromQuickViewColorAndSize();
        }

        public void Dispose()
        {
            _driver.Quit();
        }
    }
}