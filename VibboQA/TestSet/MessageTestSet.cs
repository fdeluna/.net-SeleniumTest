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
            SearchBoxPO spo = new SearchBoxPO(driver);
            spo.InputSearchTerm("proyector");
            spo.InputSearchLocation("Esparreguera");
            spo.ClickSearchButton();            
        }
    }
}
