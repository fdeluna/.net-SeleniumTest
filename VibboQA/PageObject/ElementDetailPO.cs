using OpenQA.Selenium;

namespace VibboQA.PageObject
{
    public class ElementDetailPO : BasePageObject
    {
        public ElementDetailPO(IWebDriver driver) : base(driver) { }

        private string _openContactBoxId = "sellerBox-show-chatForm";
        private string _messageContactBoxId = "cmt_contact_box";
        private string _nameContactBoxId = "name_contact_box";
        private string _emailContactBoxId = "email_contact_box";
        private string _phoneContactBoxId = "phone_contact_box";
        private string _submitContactBoxId = "BContactar";
        private string _messageSentId = "ResponseEnviado";

        private string _messageSentSuccesfully = "Tu mensaje ha sido enviado.";

        public void OpenContactForm()
        {
            IWebElement button = GetElementById(_openContactBoxId, defaultTimeOut);
            button.Click();
        }

        public void FillMessageBox(string message)
        {
            IWebElement messageBox = GetElementById(_messageContactBoxId, defaultTimeOut);
            messageBox.SendKeys(message);
        }

        public void FillNameBox(string name)
        {
            IWebElement nameBox = GetElementById(_nameContactBoxId, defaultTimeOut);
            nameBox.SendKeys(name);
        }

        public void FillEmailBox(string email)
        {
            IWebElement emailBox = GetElementById(_emailContactBoxId, defaultTimeOut);
            emailBox.SendKeys(email);

        }

        public void FillPhoneBox(string phone)
        {
            IWebElement phoneBox = GetElementById(_phoneContactBoxId, defaultTimeOut);
            phoneBox.SendKeys(phone);
        }

        public void FillMessageInfo(string name, string email, string phone = "")
        {
            FillNameBox(name);
            FillEmailBox(email);
            FillPhoneBox(phone);
        }

        public void ClickSubmitMessage()
        {
            IWebElement button = GetElementById(_submitContactBoxId, defaultTimeOut);
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
            IWebElement messageSent = GetElementById(_messageSentId, defaultTimeOut);
            return messageSent != null ? _messageSentSuccesfully.Contains(messageSent.Text) : false;
        }
    }
}