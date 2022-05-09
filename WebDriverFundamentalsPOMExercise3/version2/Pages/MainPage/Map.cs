using OpenQA.Selenium;

namespace WebDriverFundamentalsPOMExercise3.version2.Pages.MainPage
{
    public partial class MainPage
    {
        public IWebElement compareButton => WaitAndFindElement(By.XPath("//*[@class='btn btn-default button button-medium bt_compare bt_compare']"));
        public IWebElement quickViewFrame => WaitAndFindElement(By.XPath("//iframe[contains(@id, 'fancybox-frame')]"));
        public IWebElement inStockButton => WaitAndFindElement(By.XPath("//link[@itemprop='availability']"));
        public IWebElement quantityButtonPlus => WaitAndFindElement(By.XPath("//a[@class='btn btn-default button-plus product_quantity_up']"));
        public IWebElement selectedSize => WaitAndFindElement(By.XPath("//select[@id='group_1']"));
        public IWebElement addToCartButton => WaitAndFindElement(By.XPath("//p[@id='add_to_cart']/button"));
        public IWebElement proceedToCheckoutButton => WaitAndFindElement(By.XPath("//*[@class='btn btn-default button button-medium']"));
        public IWebElement actualQuantityLabel => WaitAndFindElement(By.XPath("//span[@id='layer_cart_product_quantity']"));
        public IWebElement actualColorAndSizeLabel => WaitAndFindElement(By.XPath("//span[@id='layer_cart_product_attributes']"));
        public IWebElement addedItemToCartLabel => WaitAndFindElement(By.XPath("//i[@class='icon-ok']"));
        public IWebElement actualAddToCartLabel(string dressTitle)
        {
            return WaitAndFindElement(By.XPath($"//span[contains(text(),'{dressTitle}')]"));
        }

        public IWebElement QuickViewButton(string dressTitle)
        {
            return WaitAndFindElement(By.XPath($"//a[@class='product_img_link' and @title='{dressTitle}']//following-sibling::a[@class='quick-view']"));
        }

        public IWebElement addToCompareByNameButton(string dressTitle)
        {
            return WaitAndFindElement(RelativeBy.WithLocator(By.XPath("//a[@class='add_to_compare']")).Below(By.XPath($"//img[@title='{dressTitle}']")));
        }

        public IWebElement GetDressImageByTitle(string dressTitle)
        {
            return WaitAndFindElement(By.XPath($"//img[@title='{dressTitle}']"));
        }

        public IWebElement ActualLabelCompare(string dressTitle)
        {
            return WaitAndFindElement(By.XPath($"//a[@class='product-name' and @title='{dressTitle}']"));
        }
  
        public IWebElement ActualLabelQuckView(string dressTitle)
        {
            return WaitAndFindElement(By.XPath($"//h1[contains(text(),'{dressTitle}')]"));
        }



        public IWebElement ColorOptionByNameButton(string colorName)
        {
            return WaitAndFindElement(By.XPath($"//a[@name='{colorName}']"));
        }
    }
}
