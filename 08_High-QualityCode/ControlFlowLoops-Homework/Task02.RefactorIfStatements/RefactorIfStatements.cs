namespace Task02.RefactorIfStatements
{
    using System;
    using Task01.ClassChef.Vegetables;

    public class RefactorIfStatements
    {
        private const int MinXPosition = 0;
        private const int MinYPosition = 0;
        private const int MaxXPosition = 10;
        private const int MaxYPosition = 10;

        public static void Main()
        {
            /*  Potato potato;
                //... 
                if (potato != null)
                   if(!potato.HasNotBeenPeeled && !potato.IsRotten)
                    Cook(potato);
             */
            var potato = new Potato();

            if (potato != null)
            {
                Potato.Peel(potato);

                if (potato.IsPeeled && !potato.IsRotten)
                {
                    Cook(potato);
                }
            }

            /*
             * if (x >= MIN_X && (x =< MAX_X && ((MAX_Y >= y && MIN_Y <= y) && !shouldNotVisitCell)))
                {
                   VisitCell();
                }
            */
            int positionX = 5;
            int positionY = 5;
            if (IsInRange(positionX, positionY) && CellIsNotVisited(positionX, positionY))
            {
                VisitCell();
            }
        }

        private static void Cook(Vegetable someVegatable)
        {
            if (someVegatable == null)
            {
                throw new ArgumentNullException("You can not pass an empty object");
            }

            Console.WriteLine(someVegatable.GetType().Name + " is cooking !!!");
        }

        private static bool IsInRange(int positionX, int positionY)
        {
            if (MinXPosition > positionX || positionX > MaxXPosition)
            {
                return false;
            }
            else if (MinYPosition > positionY || positionY > MaxYPosition)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private static bool CellIsNotVisited(int positionX, int positionY)
        {
            // Some logic ...
            return true;
        }

        private static void VisitCell()
        {
            Console.WriteLine("You have visited the cell !!!");
        }
    }
}
