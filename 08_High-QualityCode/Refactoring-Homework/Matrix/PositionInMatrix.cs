namespace Matrix
{
    public class PositionInMatrix
    {
        private static PositionInMatrix instance;

        private PositionInMatrix()
        {
        }

        public static PositionInMatrix Instace
        {
            get
            {
                if (instance == null)
                {
                    instance = new PositionInMatrix();
                }

                return instance;
            }
        }

        public int CurrenRow { get; set; }

        public int CurrentCol { get; set; }
    }
}
