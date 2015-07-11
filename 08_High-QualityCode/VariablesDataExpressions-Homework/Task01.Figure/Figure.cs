/* Task 1. Class Size in C#
 * StyleCop settings: disabled: Documentation Rules
*/
namespace Task01.Figure
{
    using System;

    public class Figure
    {
        private double width;
        private double height;

        public Figure(double width, double heigth)
        {
            this.Width = width;
            this.Height = heigth;
        }

        public double Width
        {
            get
            {
                return this.width;
            }

            set
            {
                this.width = value;
            }
        }

        public double Height
        {
            get
            {
                return this.height;
            }

            set
            {
                this.height = value;
            }
        }

        public static Figure GetRotatedFigure(Figure figure, double angleOfTheFigureToBeRotaed)
        {
            double newRotatedWidth = (Math.Abs(Math.Cos(angleOfTheFigureToBeRotaed)) * figure.width) +
                    (Math.Abs(Math.Sin(angleOfTheFigureToBeRotaed)) * figure.height);

            double newRotaredHeigth = (Math.Abs(Math.Sin(angleOfTheFigureToBeRotaed)) * figure.width) +
                    (Math.Abs(Math.Cos(angleOfTheFigureToBeRotaed)) * figure.height);

            Figure rotatedFigure = new Figure(newRotatedWidth, newRotaredHeigth);

            return rotatedFigure;
        }
    }
}
