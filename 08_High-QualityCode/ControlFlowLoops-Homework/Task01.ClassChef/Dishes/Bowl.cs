namespace Task01.ClassChef.Dishes
{
    using System;
    using System.Collections.Generic;
    using Task01.ClassChef.Vegetables;

    public class Bowl
    {
        private IList<Vegetable> container;

        public Bowl()
        {
            this.container = new List<Vegetable>();
        }

        public void Add(Vegetable someVegatable)
        {
            if (someVegatable == null)
            {
                throw new ArgumentNullException("You must pass an Vegetable object");
            }

            this.container.Add(someVegatable);
        }
    }
}
