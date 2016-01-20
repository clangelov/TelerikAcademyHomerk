namespace Task01.SimpleASPXPage
{
    using System;

    public partial class Hello : System.Web.UI.Page
    {
        protected void Btn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(this.Name.Text) || this.Name.Text.Length < 3)
            {
                this.Result.Text = "Ninja !";
            }
            else
            {
                this.Result.Text = this.Name.Text + " !";
            }            
        }
    }
}