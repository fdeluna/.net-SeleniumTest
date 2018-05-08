using NUnit.Framework;
using System;
using System.Threading;
using VibboQA.PageObject;

namespace VibboQA.TestSet
{
    [TestFixture]
    class MessageTestSet : DefaultTestSet
    {
        /// <summary>
        /// Check contact form of Element detail
        /// </summary>                
        /// <preconditios>
        /// - Home page is fully loaded        
        /// </preconditios>
        /// <testSteps>        
        /// - Check search box is present and visible
        /// - Search element "proyector" at "Esparreguera" location
        /// - Filter by price to 60€
        /// - Click "Aplicar Filtros" button
        /// - Check element "Proyector" exist
        /// - Check element "Proyector" price is 60€ and location is "Esparreguera"
        /// - Click element "Proyector"
        /// - Click "Enviar mensaje" button to open the contact form
        /// - Fill contact form
        /// - Click "Enviar mensaje" button        
        /// </testSteps>
        /// <postcondition>
        /// - Check "Tu mensaje ha sido enviado." message is displayed after submit the contact form
        /// </postcondition>
        [Test]
        public void ContactItemOwnerSuccessfull()
        {
            HomePO homePO = new HomePO(driver);
            //Check search box is present and visible
            Assert.True(homePO.SearchPO.SearchBoxIsReady(), "Search box is not ready");
            // Search element "proyector" at "Esparreguera" location
            SearchResultPO searchResultPO = homePO.SearchPO.SearchItemLocation("proyector", "Esparreguera");
            // Filter by price to 60€            
            searchResultPO.FilterBoxPO.PriceTo(60);
            // Click "Aplicar Filtros" button
            searchResultPO.FilterBoxPO.ClickApplyFilters();

            GridElementPO gridElementPO = searchResultPO.SearchResultGridPO.ElementWithName("Proyector");
            // Check element "Proyector" exist
            Assert.NotNull(gridElementPO, "There is no Element with name \"Proyector\"");

            // Check element "Proyector" price is 60€ and location is "Esparreguera"
            Assert.True(gridElementPO.GetElementPrice().Equals("60€", StringComparison.InvariantCultureIgnoreCase), "The element does not have the expected price ");
            Assert.True(gridElementPO.GetElementLocation().Equals("Esparreguera", StringComparison.InvariantCultureIgnoreCase), "The element does not have the expected location ");

            // Click element "Proyector" 
            ElementDetailPO elementDetailPO = gridElementPO.ClickElementSubjectName();
            //Click "Enviar mensaje" button to open the contact form
            elementDetailPO.OpenContactForm();
            // Fill contact form
            elementDetailPO.FillMessageBox("VibboSeleniumTest");
            elementDetailPO.FillMessageInfo("fernando", "anarkonejo@gmail.com");
            elementDetailPO.ClickAcceptConditions();
            // Click "Enviar mensaje" button
            elementDetailPO.ClickSubmitMessage();
            Wait(TimeSpan.FromSeconds(1));
            // Check "Tu mensaje ha sido enviado." message is displayed after submit the contact form
            Assert.True(elementDetailPO.CheckMessageSent(), "The message has not been sent correctly");
        }
    }
}
