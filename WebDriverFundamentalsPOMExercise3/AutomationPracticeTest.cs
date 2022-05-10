using AutomationPracticeTests.version2.Pages.ProductComparisonPage;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using WebDriverFundamentalsPOMExercise3.version2.Pages.MainPage;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager.Helpers;

namespace WebDriverFundamentalsPOMExercise3
{
    public class AutomationPracticeTests : IDisposable
    {
        private static IWebDriver _driver;
        private static MainPage _mainPage;
        private static ProductComparisonPage _productComparisonPage;

        public AutomationPracticeTests()
        {
            new DriverManager().SetUpDriver(new ChromeConfig(), VersionResolveStrategy.MatchingBrowser);
            _driver = new ChromeDriver();
            _mainPage = new MainPage(_driver);
            _productComparisonPage = new ProductComparisonPage(_driver);
        }

        [SetUp]
        public void Setup()
        {
            _driver.Manage().Window.Maximize();
        }

        [Test]
        [TestCase("Printed Dress", "Printed Dress", "Printed Summer Dress", "Printed Summer Dress")]
        public void InformationDisplayedOnComparisonScreen_When_ItemsAreAddedToCompare(string firstDressTitle, string firstDressActualText, string secondDressTitle, string secondDressActualText)
        {
            _mainPage.AddItemsToCompare(firstDressTitle, secondDressTitle);

            _productComparisonPage.AssertionAddTwoItemsToCompare(firstDressTitle, firstDressActualText, secondDressTitle, secondDressActualText);
        }

        [Test]
        [TestCase("Printed Summer Dress", "Printed Summer Dress")]
        public void InformationDisplayedQuickView_When_ClickOnQuickView(string expectedResultDressTitle, string actualDressTitle)
        {
            _mainPage.OpenQuickView(actualDressTitle);

            _mainPage.AssertionQuickviewScreen(expectedResultDressTitle, actualDressTitle);
        }

        [Test]
        [TestCase("Printed Chiffon Dress", "Printed Chiffon Dress", 2, "M", "Yellow")]
        public void ItemAddedToCartFromQuickView_When_InitializesCorrectQuantitySizeColor(string expectedResultDressTitle, string actualDressTitle, int numberOfClicksQuantity, string size, string color)
        {
            _mainPage.OpenQuickView(actualDressTitle);
            _mainPage.AddItemToCartWithQuantityColorAndSize(numberOfClicksQuantity, size, color);

            _mainPage.AssetionItemOpenedFromQuickView();
        }

        public void Dispose()
        {
            _driver.Quit();
        }
    }
}