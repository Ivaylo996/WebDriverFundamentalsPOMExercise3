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
    public class Tests : IDisposable
    {
        private static IWebDriver _driver;
        private static MainPage _mainPage;

        public Tests()
        {
            new DriverManager().SetUpDriver(new ChromeConfig(), VersionResolveStrategy.MatchingBrowser);
            _driver = new ChromeDriver();
            _mainPage = new MainPage(_driver);
        }

        [SetUp]
        public void Setup()
        {
            _driver.Manage().Window.Maximize();
        }

        [Test]
        public void InformationDisplayedOnComparisonScreen_When_ItemsAreAddedToCompare(
            [Values("Printed Dress")] string firstDressTitle,
            [Values("Printed Dress")] string firstDressActualText,
            [Values("Printed Summer Dress")] string secondDressTitle,
            [Values("Printed Summer Dress")] string secondDressActualText)
        {
            _mainPage.AddItemsToCompare(firstDressTitle, secondDressTitle);
            _mainPage.AssertionAddTwoItemsToCompare_With_FirstDressActualTitleAndText_And_SecondDressActualTitleAndText(firstDressTitle, firstDressActualText, secondDressTitle, secondDressActualText);
        }

        [Test]
        public void InformationDisplayedQuickView_When_ClickOnQuickView(
            [Values("Printed Summer Dress")] string expectedResultDressTitle,
            [Values("Printed Summer Dress")] string actualDressTitle)
        {
            _mainPage.OpenQuickView(actualDressTitle);
            _mainPage.AssertionQuickviewScreen_When_ClickOnButton(expectedResultDressTitle, actualDressTitle);
        }

        [Test]
        public void ItemAddedToCartFromQuickView_When_InitializesCorrectQuantitySizeColor(
            [Values("Printed Chiffon Dress")] string expectedResultDressTitle,
            [Values("Printed Chiffon Dress")] string actualDressTitle,
            [Values(2)] int numberOfClicksQuantity,
            [Values("M")] string size,
            [Values("Yellow")] string color)
        {
            _mainPage.OpenQuickView(actualDressTitle);
            _mainPage.AddItemToCartWithQuantityColorAndSize(numberOfClicksQuantity, size, color);
            _mainPage.AssetionItemOpenedFromQuickView_With_InitializesColorSize_And_Quantity();
        }

        public void Dispose()
        {
            _driver.Quit();
        }
    }
}