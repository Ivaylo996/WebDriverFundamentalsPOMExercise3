using NUnit.Framework;

namespace AutomationPracticeTests.version2.Pages.ProductComparisonPage
{
    public partial class ProductComparisonPage
    {
        public void AssertAddTwoItemsToCompare(string firstDressTitle, string firstDressText, string secondDressTitle, string secondDressText)
        {
            Assert.AreEqual(firstDressText, ActualLabelCompare(firstDressTitle).Text.Trim());
            Assert.AreEqual(secondDressText, ActualLabelCompare(secondDressTitle).Text.Trim());
        }
    }
}
