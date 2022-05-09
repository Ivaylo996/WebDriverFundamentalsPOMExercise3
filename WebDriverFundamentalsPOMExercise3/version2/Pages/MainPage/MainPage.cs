using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace WebDriverFundamentalsPOMExercise3.version2.Pages.MainPage
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

            WebDriverWait.Until(ExpectedConditions.ElementToBeClickable(addToCompareByNameButton(firstDressTitle)));
            Thread.Sleep(1000);

            if (addToCompareByNameButton(firstDressTitle).Displayed)
            {
                addToCompareByNameButton(firstDressTitle).Click();
            }
            else
            {
                throw new Exception("missing button");
            }

            ScrollToElement(addToCompareByNameButton(firstDressTitle));

            HoverElement(GetDressImageByTitle(secondDressTitle));

            WebDriverWait.Until(ExpectedConditions.ElementToBeClickable(addToCompareByNameButton(secondDressTitle)));

            Thread.Sleep(2000);

            try
            {
                addToCompareByNameButton(secondDressTitle).Click();
            }
            catch
            {
                throw new Exception("Compare button 2 not clickable");
            }
            

            ScrollToElement(compareButton);
            WebDriverWait.Until(ExpectedConditions.ElementToBeClickable(compareButton));
            compareButton.Click();
            WaitForPageToLoad();
        }

        public void OpenQuickView(string dressTitle)
        {
            GoTo();

            ScrollToElement(inStockButton);

            HoverElement(GetDressImageByTitle(dressTitle));

            WaitAndFindElement(By.XPath("//*[@class='btn btn-default button button-medium bt_compare bt_compare']"));

            HoverElement(addToCompareByNameButton(dressTitle));

            WebDriverWait.Until(ExpectedConditions.ElementToBeClickable(addToCompareByNameButton(dressTitle)));
            Thread.Sleep(2000);

            QuickViewButton(dressTitle).Click();

            WaitForFrameToLoad();

            SwitchToFrame(quickVIewFrameId);
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
            ScrollToElement(quantityButtonPlus);

            quantityQuickVew = numberOfCLicks + 1;

            dressColorAndSize = $"{color}, {size}";

            for (int i = 0; i < numberOfCLicks; i++)
            {
                quantityButtonPlus.Click();
            }

            var selectElement = new SelectElement(selectedSize);
            selectElement.SelectByText(size);

            if (ColorOptionByNameButton(color).Displayed)
            {
                ColorOptionByNameButton(color).Click();
            }
            else
            {
                throw new Exception("No Such color exists!");
            }

            addToCartButton.Click();
        }
    }
}
