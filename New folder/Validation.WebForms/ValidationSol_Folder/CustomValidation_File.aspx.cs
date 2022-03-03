using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace ValidationNmsp
{
    public partial class CustomValidationClass : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Unnamed_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (args.Value.Equals("GOLD"))
            {
                args.IsValid = true;

            }
            else
            {
                args.IsValid = false;
            }
        }
    }

    public class abcControl:CustomValidator
    {

    }
}