namespace Task01.ClassChef
{
    using System;
    using Task01.ClassChef.Dishes;
    using Task01.ClassChef.Vegetables;    

    public class Chef
    {
        public Chef()
        {
        }

        public void Cook()
        {
            Potato potato = new Potato();
            Carrot carrot = new Carrot();
            Bowl bowl = new Bowl();

            Potato.Peel(potato);
            Carrot.Peel(carrot);
            
            this.Cut(potato);
            this.Cut(carrot);

            bowl.Add(carrot);
            bowl.Add(potato);
        }

        private void Cut(Vegetable someVegetable)
        {
            if (someVegetable == null)
            {
                throw new ArgumentNullException("You must pass an Vegetable object");
            }

            someVegetable.isCutted = true;
        }
    }
}
