using OpenQA.Selenium;

namespace AutomationPractice.version2.Pages.ProductComparisonPage
{
    public partial class ProductComparisonPage
    {
        public IWebElement GetActualCompareLabelByDressTitle(string dressTitle)
        {
            return WaitAndFindElement(By.XPath($"//a[@class='product-name' and @title='{dressTitle}']"));
        }
    }
}
