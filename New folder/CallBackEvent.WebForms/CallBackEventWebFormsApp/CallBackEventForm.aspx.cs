using System;
using System.Web.UI;


namespace CallBackEventWebFormsApp
{
    public partial class CallBackEventForm : System.Web.UI.Page, ICallbackEventHandler
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // This gets us the 'WebForm_DoCallback' method
            string js = Page.ClientScript.GetCallbackEventReference(this, "arg", "ClientCallbackFunction", "ctx", "ClientErrorCallBack", true);

            // Wrap it up in a nice function
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("function DoTheCallback(arg, ctx) {");
            sb.Append(js);
            sb.Append("}");
            // ...and register it.
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "callbackkey", sb.ToString(), true);

        }
        protected void ddlPostback_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtDesc.Text = UpdateTextField(ddlPostback.SelectedValue);

        }

        /// <summary>
        /// Simple Server side code to execute when an index is changed on the dropdown lists.
        /// </summary>
        /// <param name="listValue"></param>
        /// <returns></returns>
        private string UpdateTextField(string listValue)
        {
            System.Threading.Thread.Sleep(2000);   // cause a delay
            string desc = null;
            switch (listValue)
            {
                case "1":
                    desc = "I am number 1!";
                    break;
                case "2":
                    desc = "Number 2 is cool";
                    break;
                case "3":
                    desc = "Item 3 feels free...";
                    break;
                case "4":
                    desc = "4 on the floor.";
                    break;
                default:
                    desc = "";
                    break;
            }
            return desc;
        }

        #region ICallbackEventHandler Members

        /// <summary>
        /// The Server side method called when the async client script is called.
        /// </summary>
        /// <param name="eventArgument"></param>
        /// <returns></returns>
        public void RaiseCallbackEvent(string eventArgument)
        {
            //throw new Exception("woohoo!");
            UpdateTextField(eventArgument);
        }


        public string GetCallbackResult()
        {
            // throw new NotImplementedException();
            return "up";
        }

        #endregion

    }
}