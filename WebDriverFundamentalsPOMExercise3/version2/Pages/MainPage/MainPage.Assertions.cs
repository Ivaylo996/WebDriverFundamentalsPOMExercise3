using NUnit.Framework;

namespace AutomationPractice.version2.Pages.MainPage
{
    public partial class MainPage
    {
        public void AssertQuickviewScreen(string expectedResultDressTitle, string actualDressTitle)
        {
            Assert.AreEqual(expectedResultDressTitle, GetActualLabelFromQuckViewByDressTitle(actualDressTitle).Text.Trim());
        }

        public void AssertQuantityOfProductFromQuickView()
        {
            Assert.AreEqual(quantityQuickVew.ToString(), MainPageActualQuantityLabel.Text);
        }

        public void AssertColorAndSizeOfProductFromQuickView()
        {
            Assert.AreEqual(dressColorAndSize, MainPageActualColorAndSizeLabel.Text);
        }
    }
}
