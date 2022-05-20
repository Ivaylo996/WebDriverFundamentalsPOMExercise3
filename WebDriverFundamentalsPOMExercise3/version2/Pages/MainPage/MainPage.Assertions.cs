using NUnit.Framework;

namespace AutomationPractice.version2.Pages.MainPage
{
    public partial class MainPage
    {
        public void AssertQuickviewScreen(string expectedResultDressTitle, string actualDressTitle)
        {
            Assert.AreEqual(expectedResultDressTitle, GetActualQuckViewLabelByDressTitle(actualDressTitle).Text.Trim());
        }

        public void AssertQuantityOfProductFromQuickView()
        {
            Assert.AreEqual(quantityQuickVew.ToString(), ActualQuantityLabel.Text);
        }

        public void AssertColorAndSizeOfProductFromQuickView()
        {
            Assert.AreEqual(dressColorAndSize, ActualColorAndSizeLabel.Text);
        }
    }
}
