using OpenQA.Selenium;

namespace VibboQA.PageObject
{
    /// <summary>
    /// Page Object To interact with Element Detail page 
    /// </summary>
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

        /// <summary>
        ///  Opens Contact Form
        /// </summary>
        public void OpenContactForm()
        {
            IWebElement button = GetElementById(_openContactBoxId, defaultTimeOut);
            button.Click();
        }

        /// <summary>
        ///  Fills Message Box
        /// </summary>
        public void FillMessageBox(string message)
        {
            IWebElement messageBox = GetElementById(_messageContactBoxId, defaultTimeOut);
            messageBox.SendKeys(message);
        }

        /// <summary>
        ///  Fills Name Box
        /// </summary>
        public void FillNameBox(string name)
        {
            IWebElement nameBox = GetElementById(_nameContactBoxId, defaultTimeOut);
            nameBox.SendKeys(name);
        }

        /// <summary>
        ///  Fills Email Box
        /// </summary>
        public void FillEmailBox(string email)
        {
            IWebElement emailBox = GetElementById(_emailContactBoxId, defaultTimeOut);
            emailBox.SendKeys(email);

        }

        /// <summary>
        ///  Fills Message Box
        /// </summary>
        public void FillPhoneBox(string phone)
        {
            IWebElement phoneBox = GetElementById(_phoneContactBoxId, defaultTimeOut);
            phoneBox.SendKeys(phone);
        }

        /// <summary>
        ///  Fills Contact info
        /// </summary>
        public void FillMessageInfo(string name, string email, string phone = "")
        {
            FillNameBox(name);
            FillEmailBox(email);
            FillPhoneBox(phone);
        }

        /// <summary>
        /// Submit the contact form
        /// </summary>
        public void ClickSubmitMessage()
        {
            IWebElement button = GetElementById(_submitContactBoxId, defaultTimeOut);
            button.Click();
        }

        /// <summary>
        /// JS injection to accept Conditions check box
        /// </summary>
        public void ClickAcceptConditions()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            if (js != null)
            {
                js.ExecuteScript("document.getElementById('acepto_condiciones').click();");
            }
        }

        /// <summary>
        /// Check message has been sent correctly
        /// </summary>
        /// <returns></returns>
        public bool CheckMessageSent()
        {
            IWebElement messageSent = GetElementById(_messageSentId, defaultTimeOut);
            return messageSent != null ? messageSent.Text.Contains(_messageSentSuccesfully) : false;
        }
    }
}