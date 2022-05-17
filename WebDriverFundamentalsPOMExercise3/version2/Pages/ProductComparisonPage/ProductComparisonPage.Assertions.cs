using NUnit.Framework;

namespace AutomationPractice.version2.Pages.ProductComparisonPage
{
    public partial class ProductComparisonPage
    {
        public void AssertAddTwoItemsToCompare(string firstDressTitle, string firstDressText, string secondDressTitle, string secondDressText)
        {
            Assert.AreEqual(firstDressText, GetActualLabelCompareByTitle(firstDressTitle).Text.Trim());
            Assert.AreEqual(secondDressText, GetActualLabelCompareByTitle(secondDressTitle).Text.Trim());
        }
    }
}
