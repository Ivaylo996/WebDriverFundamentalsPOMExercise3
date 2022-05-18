using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace AutomationPractice.version2.Pages.MainPage
{
    public partial class MainPage : WebPage
    {
        private string currentSubUrl = "index.php?id_category=8&controller=category";

        public MainPage(IWebDriver _driver) : base(_driver)
        {
        }

        protected string quickVIewFrameId = "//iframe[contains(@id,'fancybox-frame')]";
        protected string dressColorAndSize;
        protected int quantityQuickVew;
        protected override string Url
        {
            get
            {
                return base.Url + currentSubUrl;
            }
        }

        public void AddItemsToCompareByDressTitles(string firstDressTitle, string secondDressTitle)
        {
            GoTo();

            ScrollToElement(GetDressImageByDressTitle(firstDressTitle));
            HoverElement(GetDressImageByDressTitle(firstDressTitle));

            WaitUntilElementIsClickable(GetAddToCompareButtonByDressTitle(firstDressTitle));
            WaitForAjax();

            GetAddToCompareButtonByDressTitle(firstDressTitle).Click();
            WaitForAjax();

            HoverElement(GetDressImageByDressTitle(secondDressTitle));

            GetAddToCompareButtonByDressTitle(secondDressTitle).Click();
            WaitForAjax();

            MainPageCompareButton.Click();
            WaitForPageToLoad();
        }

        public void OpenQuickViewByDressTitle(string dressTitle)
        {
            GoTo();
            WaitForAjax();

            HoverElement(GetDressImageByDressTitle(dressTitle));
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

        public void AddItemToCartWithDressQuantityDressColorAndDressSize(int numberOfCLicks, string size, string color)
        {
            ScrollToElement(MainPageQuantityButtonPlus);

            quantityQuickVew = numberOfCLicks + 1;

            dressColorAndSize = $"{color}, {size}";

            for (int i = 0; i < numberOfCLicks; i++)
            {
                MainPageQuantityButtonPlus.Click();
            }

            var selectElement = new SelectElement(MainPageSelectedProductSize);
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

            MainPageAddToCartButton.Click();
            Driver.SwitchTo().DefaultContent();
            WaitUntilPageLoadsCompletely();
        }
    }
}
