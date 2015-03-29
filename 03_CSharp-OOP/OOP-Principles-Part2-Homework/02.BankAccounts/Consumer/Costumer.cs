namespace _02.BankAccounts
{
    using System;
    class Costumer
    {
        private string name;
        private AccountHolder type;

        public Costumer(string name, AccountHolder type)
        {
            this.Name = name;
            this.Type = type;
        }
        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("You can not assign empty value");
                }
                if (value.Length < 3 || value.Length > 25)
                {
                    throw new ArgumentOutOfRangeException("Your name is too short or too long");
                }
                this.name = value;
            }
        }

        public AccountHolder Type
        {
            get
            {
                return this.type;
            }
            private set
            {
                this.type = value;
            }
        }

        public override string ToString()
        {
            return string.Format("{0}'s {1} account", this.name, this.type);
        }
    }   
}
