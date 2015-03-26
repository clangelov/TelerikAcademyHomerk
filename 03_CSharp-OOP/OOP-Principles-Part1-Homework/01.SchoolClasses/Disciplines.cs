namespace _01.SchoolClasses
{
    //  Disciplines have name, number of lectures and number of exercises

    using System;
    class Disciplines : BasicInfoPeopleAndObjects
    {
        private int lecturesNumber;
        private int exercisesNumber;

        public Disciplines(string name, int lecturesNumber, int exercisesNumber)
            :base(name)
        {
            this.LecturesNumber = lecturesNumber;
            this.ExercisesNumber = exercisesNumber;
        }
        public int LecturesNumber
        {
            get
            {
                return this.lecturesNumber;
            }
            private set
            {
                if (CheckForValidValue(value))
                {
                    this.lecturesNumber = value;
                }
            }
        }
        public int ExercisesNumber
        {
            get
            {
                return this.exercisesNumber;
            }
            private set
            {
                if (CheckForValidValue(value))
                {
                    this.exercisesNumber = value;
                }
            }
        }
        private static bool CheckForValidValue(int value)
        {
            if (value < 1 || value > 10)
            {
                throw new ArgumentOutOfRangeException("THe number of Lectures Or Exercises should be bewtween 1 and 10");
            }
            return true;
        }
    }
}
