using NUnit.Framework;

namespace AutomationPractice.version2.Pages.ProductComparisonPage
{
    public partial class ProductComparisonPage
    {
        public void AssertAddTwoItemsToCompare(string firstDressTitle, string firstExpectedDressText, string secondDressTitle, string secondExpectedDressText)
        {
            Assert.AreEqual(firstExpectedDressText, GetActualCompareLabelByDressTitle(firstDressTitle).Text.Trim());
            Assert.AreEqual(secondExpectedDressText, GetActualCompareLabelByDressTitle(secondDressTitle).Text.Trim());
        }
    }
}
