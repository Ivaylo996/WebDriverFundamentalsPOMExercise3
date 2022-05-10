using NUnit.Framework;

namespace WebDriverFundamentalsPOMExercise3.version2.Pages.MainPage
{
    public partial class MainPage
    {
        public void AssertionQuickviewScreen(string expectedResultDressTitle, string actualDressTitle)
        {
            Assert.AreEqual(expectedResultDressTitle, ActualLabelQuckView(actualDressTitle).Text.Trim());
        }

        public void AssetionItemOpenedFromQuickView()
        {
            Assert.AreEqual(dressColorAndSize, ActualColorAndSizeLabel.Text);
            Assert.AreEqual(quantityQuickVew, ActualQuantityLabel.Text);
        }
    }
}
