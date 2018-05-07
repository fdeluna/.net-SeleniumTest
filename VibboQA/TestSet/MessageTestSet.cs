using NUnit.Framework;
using VibboQA.PageObject;

namespace VibboQA.TestSet
{
    [TestFixture]
    class MessageTestSet : DefaultTestSet
    {

        [Test]
        public void ContactItemOwner()
        {
            SearchPO spo = new SearchPO(driver);
            spo.InputSearchTerm("proyector");
            spo.InputSearchLocation("Esparreguera");
            spo.ClickSearchButton();
            FilterPO filterPO = new FilterPO(driver);
            filterPO.PriceTo(60);
            filterPO.ClickApplyFilters();
            SearchResultGridPO searchResultPO = new SearchResultGridPO(driver);
            searchResultPO.ClickElement("proyector");

            ElementDetailPO elementDetailPO = new ElementDetailPO(driver);
            elementDetailPO.ClickSendMessage();
            elementDetailPO.FillMessageBox("VibboSeleniumTest");
            elementDetailPO.FillMessageInfo("fernando", "fernando.deluna.romero@gmail.com");
            elementDetailPO.ClickAcceptConditions();
            elementDetailPO.ClickSubmitMessage();
            Assert.True(elementDetailPO.CheckMessageSent());
        }
    }
}
