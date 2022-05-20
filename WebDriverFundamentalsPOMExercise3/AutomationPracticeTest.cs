using AutomationPractice.version2.Pages.MainPage;
using AutomationPractice.version2.Pages.ProductComparisonPage;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.Events;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager.Helpers;

namespace AutomationPractice
{
    public class AutomationPracticeTests
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
            _driver.FindingElement += WebDriverEventHandler.FiringDriver_FindingElement;

            _mainPage = new MainPage(_driver);
            _productComparisonPage = new ProductComparisonPage(_driver);
        }

        [SetUp]
        public void TestInit()
        {
            _driver.Manage().Window.Maximize();
        }

        [TearDown]
        public void TestCleanup()
        {
            WebDriverEventHandler.PerformanceTimingService.GenerateReport();
            _driver.Close();
        }

        [Test]
        public void InformationDisplayedOnComparisonScreen_When_ItemsAreAddedToCompare()
        {
            _mainPage.AddItemsToCompareByDressTitles("Printed Dress", "Printed Summer Dress");

            _productComparisonPage.AssertAddTwoItemsToCompare("Printed Dress", "Printed Dress", "Printed Summer Dress", "Printed Summer Dress");
        }

        [Test]
        public void InformationDisplayedQuickView_When_ClickOnQuickView()
        {
            _mainPage.OpenQuickViewByDressTitle("Printed Summer Dress");

            _mainPage.AssertQuickviewScreen("Printed Summer Dress", "Printed Summer Dress");
        }

        [Test]
        public void ItemAddedToCartFromQuickView_When_InitializesCorrectQuantitySizeColor()
        {
            _mainPage.OpenQuickViewByDressTitle("Printed Summer Dress");
            _mainPage.AddItemToCartWithDressQuantityDressColorAndDressSize(2, "M", "Yellow");

            _mainPage.AssertQuantityOfProductFromQuickView();
            _mainPage.AssertColorAndSizeOfProductFromQuickView();
        }
    }
}