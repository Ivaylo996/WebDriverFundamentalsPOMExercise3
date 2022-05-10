using OpenQA.Selenium;

namespace AutomationPracticeTests.version2.Pages.ProductComparisonPage
{
    public partial class ProductComparisonPage
    {
        public IWebElement ActualLabelCompare(string dressTitle)
        {
            return WaitAndFindElement(By.XPath($"//a[@class='product-name' and @title='{dressTitle}']"));
        }
    }
}
