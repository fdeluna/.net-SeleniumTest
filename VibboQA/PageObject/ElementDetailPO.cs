using OpenQA.Selenium;
using System;

namespace VibboQA.PageObject
{
    public class ElementDetailPO : BasePageObject
    {
        public ElementDetailPO(IWebDriver driver) : base(driver) { }

        private string _messageSentSuccesfully = " Tu mensaje ha sido enviado. ";

        public void ClickSendMessage()
        {
            IWebElement button = GetElementById("sellerBox-show-chatForm", new TimeSpan(0, 0, 20));
            button.Click();
        }

        public void FillMessageBox(string message)
        {
            IWebElement messageBox = GetElementById("cmt_contact_box", new TimeSpan(0, 0, 20));
            messageBox.SendKeys(message);
        }

        public void FillMessageInfo(string name, string email, string phone = "")
        {
            IWebElement nameBox = GetElementById("name_contact_box", new TimeSpan(0, 0, 20));
            IWebElement emailBox = GetElementById("email_contact_box", new TimeSpan(0, 0, 20));

            nameBox.SendKeys(name);
            emailBox.SendKeys(email);
        }

        public void ClickSubmitMessage()
        {
            IWebElement button = GetElementById("BContactar", new TimeSpan(0, 0, 20));
            button.Click();
        }

        public void ClickAcceptConditions()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            if (js != null)
            {
                js.ExecuteScript("document.getElementById('acepto_condiciones').click();");
            }
        }

        public bool CheckMessageSent()
        {
            IWebElement messageSent = GetElementById("ResponseEnviado", new TimeSpan(0, 0, 20));
            return messageSent != null ? _messageSentSuccesfully.Contains(messageSent.Text) : false;
        }

    }
}