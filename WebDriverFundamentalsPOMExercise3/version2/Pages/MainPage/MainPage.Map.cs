using OpenQA.Selenium;

namespace AutomationPractice.version2.Pages.MainPage
{
    public partial class MainPage
    {
        public IWebElement CompareButton => WaitAndFindElement(By.XPath("//*[@class='btn btn-default button button-medium bt_compare bt_compare']"));
        public IWebElement QuickViewFrame => WaitAndFindElement(By.XPath("//iframe[contains(@id, 'fancybox-frame')]"));
        public IWebElement InStockButton => WaitAndFindElement(By.XPath("//link[@itemprop='availability']"));
        public IWebElement QuantityButtonPlus => WaitAndFindElement(By.XPath("//a[@class='btn btn-default button-plus product_quantity_up']"));
        public IWebElement SelectedSize => WaitAndFindElement(By.XPath("//select[@id='group_1']"));
        public IWebElement AddToCartButton => WaitAndFindElement(By.XPath("//p[@id='add_to_cart']/button"));
        public IWebElement ProceedToCheckoutButton => WaitAndFindElement(By.XPath("//*[@class='btn btn-default button button-medium']"));
        public IWebElement ActualQuantityLabel => WaitAndFindElement(By.XPath("//span[@id='layer_cart_product_quantity']"));
        public IWebElement ActualColorAndSizeLabel => WaitAndFindElement(By.XPath("//span[@id='layer_cart_product_attributes']"));
        public IWebElement AddedItemToCartLabel => WaitAndFindElement(By.XPath("//i[@class='icon-ok']"));

        public IWebElement GetActualAddToCartLabelByText(string dressTitle)
        {
            return WaitAndFindElement(By.XPath($"//span[contains(text(),'{dressTitle}')]"));
        }

        public IWebElement GetQuickViewButtonByDressTitle(string dressTitle)
        {
            return WaitAndFindElement(By.XPath($"//a[@class='product_img_link' and @title='{dressTitle}']//following-sibling::a[@class='quick-view']"));
        }

        public IWebElement GetAddToCompareButtonByDressTitle(string dressTitle)
        {
            return WaitAndFindElement(RelativeBy.WithLocator(By.XPath("//a[@class='add_to_compare']")).Below(By.XPath($"//img[@title='{dressTitle}']")));
        }

        public IWebElement GetDressImageByDressTitle(string dressTitle)
        {
            return WaitAndFindElement(By.XPath($"//img[@title='{dressTitle}']"));
        }
  
        public IWebElement GetActualLabelFromQuckViewByDressTitle(string dressTitle)
        {
            return WaitAndFindElement(By.XPath($"//h1[contains(text(),'{dressTitle}')]"));
        }

        public IWebElement GetColorOptionButtonByColorName(string colorName)
        {
            return WaitAndFindElement(By.XPath($"//a[@name='{colorName}']"));
        }
    }
}
