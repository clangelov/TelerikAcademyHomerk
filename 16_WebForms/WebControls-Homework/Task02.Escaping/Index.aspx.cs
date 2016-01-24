using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Task02.Escaping
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonDisplayText(object sender, EventArgs e)
        {
            string enteredText = UnEscapedText.Text;
            ResultEscaped.Text = Server.HtmlEncode(enteredText);
            ResultEscaped.Visible = true;
        }
    }
}