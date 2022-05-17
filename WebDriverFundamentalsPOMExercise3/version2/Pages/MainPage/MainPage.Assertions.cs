using NUnit.Framework;

namespace AutomationPractice.version2.Pages.MainPage
{
    public partial class MainPage
    {
        public void AssertQuickviewScreen(string expectedResultDressTitle, string actualDressTitle)
        {
            Assert.AreEqual(expectedResultDressTitle, GetActualLabelFromQuckViewByDressTitle(actualDressTitle).Text.Trim());
        }

        public void AssertItemOpenedFromQuickViewQuantity()
        {
            Assert.AreEqual(quantityQuickVew.ToString(), ActualQuantityLabel.Text);
        }

        public void AssertItemOpenedFromQuickViewColorAndSize()
        {
            Assert.AreEqual(dressColorAndSize, ActualColorAndSizeLabel.Text);
        }
    }
}
