using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace AutomationPractice.version2.Pages.MainPage
{
    public partial class MainPage : WebPage
    {
        public MainPage(IWebDriver _driver) : base(_driver)
        {
        }

        protected override string Url => "http://automationpractice.com/index.php?id_category=8&controller=category";

        protected string quickVIewFrameId = "//iframe[contains(@id,'fancybox-frame')]";
        protected string successfullyAddedFrameId = "";
        protected string dressColorAndSize;
        protected int quantityQuickVew;

        public void AddItemsToCompare(string firstDressTitle, string secondDressTitle)
        {
            GoTo();

            ScrollToElement(GetDressImageByTitle(firstDressTitle));
            HoverElement(GetDressImageByTitle(firstDressTitle));

            WaitUntilElementIsClickable(GetAddToCompareButtonByTitle(firstDressTitle));
            WaitForAjax();

            GetAddToCompareButtonByTitle(firstDressTitle).Click();
            WaitForAjax();

            HoverElement(GetDressImageByTitle(secondDressTitle));

            GetAddToCompareButtonByTitle(secondDressTitle).Click();
            WaitForAjax();

            CompareButton.Click();
            WaitForPageToLoad();
        }

        public void OpenQuickView(string dressTitle)
        {
            GoTo();
            WaitForAjax();

            HoverElement(GetDressImageByTitle(dressTitle));
            HoverElement(GetQuickViewButtonByDressTitle(dressTitle));
            WaitForAjax();

            GetQuickViewButtonByDressTitle(dressTitle).Click();

            WaitForFrameToLoad();
            SwitchToFrame(quickVIewFrameId);
            WaitForAjax();
        }

        protected override void WaitForPageToLoad()
        {
            WaitAndFindElement(By.XPath("//i[@class='icon-home']"));
        }

        protected void WaitForFrameToLoad()
        {
            WaitAndFindElement(By.XPath("//iframe[contains(@id, 'fancybox-frame')]"));
        }

        public void AddItemToCartWithQuantityColorAndSize(int numberOfCLicks, string size, string color)
        {
            ScrollToElement(QuantityButtonPlus);

            quantityQuickVew = numberOfCLicks + 1;

            dressColorAndSize = $"{color}, {size}";

            for (int i = 0; i < numberOfCLicks; i++)
            {
                QuantityButtonPlus.Click();
            }

            var selectElement = new SelectElement(SelectedSize);
            selectElement.SelectByText(size);
            WaitForAjax();

            if (GetColorOptionButtonByColorName(color).Displayed)
            {
                GetColorOptionButtonByColorName(color).Click();
            }
            else
            {
                throw new Exception("No Such color exists!");
            }

            AddToCartButton.Click();
            Driver.SwitchTo().DefaultContent();
            WaitUntilPageLoadsCompletely();
        }
    }
}
