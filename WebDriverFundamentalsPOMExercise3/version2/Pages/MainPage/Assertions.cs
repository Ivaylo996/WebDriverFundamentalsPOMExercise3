using NUnit.Framework;

namespace WebDriverFundamentalsPOMExercise3.version2.Pages.MainPage
{
    public partial class MainPage
    {
        public void AssertionAddTwoItemsToCompare_With_FirstDressActualTitleAndText_And_SecondDressActualTitleAndText(string firstDressTitle, string firstDressText, string secondDressTitle, string secondDressText)
        {
            Assert.AreEqual(firstDressText, ActualLabelCompare(firstDressTitle).Text.Trim());
            Assert.AreEqual(secondDressText, ActualLabelCompare(secondDressTitle).Text.Trim());
        }

        public void AssertionQuickviewScreen_When_ClickOnButton(string expectedResultDressTitle, string actualDressTitle)
        {
            Assert.AreEqual(expectedResultDressTitle, ActualLabelQuckView(actualDressTitle).Text.Trim());
        }

        public void AssertionItemAddedToCart_With_ChecksCheckoutLabel()
        {
            Assert.AreEqual("Product successfully added to your shopping cart", addedItemToCartLabel.Text.Trim());
        }

        public void AssertionIsAddedToCart_With_QuantityColorSize(string expectedLabel, string actualLabel)
        {
            Assert.AreEqual(expectedLabel, actualAddToCartLabel(actualLabel).Text.Trim());
        }

        public void AssetionItemOpenedFromQuickView_With_InitializesColorSize_And_Quantity()
        {
            Assert.AreEqual(dressColorAndSize, actualColorAndSizeLabel.Text);
            Assert.AreEqual(quantityQuickVew, actualQuantityLabel.Text);
        }
    }
}
