using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Task01.RandomNumbers
{
    public partial class Index : System.Web.UI.Page
    {
        private const string ResultMessage = "Result is ";
        private const string InvalidInputMessage = "Invalid input!";
        private Random rand = new Random();

        protected void ButtonRandom_Click(object sender, EventArgs e)
        {
            try
            {
                var randNumber = rand.Next(int.Parse(this.From.Value), int.Parse(this.To.Value) + 1);
                this.resultHTML.InnerText = ResultMessage + randNumber.ToString();
                this.resultHTML.Visible = true;
            }
            catch (Exception)
            {
                this.resultHTML.InnerText = InvalidInputMessage;
                this.resultHTML.Visible = true;
            }
        }

        protected void ButtonRandomWeb_Click(object sender, EventArgs e)
        {
            try
            {
                var randNumber = rand.Next(int.Parse(this.FromWeb.Text), int.Parse(this.ToWeb.Text) + 1);
                this.resultWeb.Text = ResultMessage + randNumber.ToString();
                this.resultWeb.Visible = true;
            }
            catch (Exception)
            {
                this.resultWeb.Text = InvalidInputMessage;
                this.resultWeb.Visible = true;
            }
        }
    }
}