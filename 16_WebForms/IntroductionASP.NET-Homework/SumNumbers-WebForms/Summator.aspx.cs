namespace SumNumbers_WebForms
{
    using System;
    using System.Globalization;

    public partial class Summator : System.Web.UI.Page
    {
        protected void Sum_Numbers(object sender, EventArgs e)
        {
            try
            {
                var firstNum = int.Parse(this.firstNumber.Value);
                var secondNum = int.Parse(this.secondNumber.Value);
                var sum = firstNum + secondNum;
                this.SumResult.Text = "Result is " + sum.ToString(CultureInfo.InvariantCulture);
                this.SumResult.Visible = true;
            }
            catch (Exception)
            {
                this.SumResult.Text = "Invalid input";
                this.SumResult.Visible = true;
            }
        }
    }
}