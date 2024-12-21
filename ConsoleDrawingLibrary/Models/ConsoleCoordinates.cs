namespace ConsoleDrawingLibrary.Models
{
    public class ConsoleCoordinates
    {
        private int _x;
        public int X
        {
            get
            {
                return _x;
            }
            set
            {
                ValidateCoordinate(X);
                _x = value;
            }
        }

        private int _y;
        public int Y
        {
            get
            {
                return _y;
            }
            set
            {
                ValidateCoordinate(Y);
                _y = value;
            }
        }



        public ConsoleCoordinates() { }

        public ConsoleCoordinates(int x, int y)
        {
            X = x;
            Y = y;
        }



        public void ValidateCoordinate(int newCoordinate)
        {
            if (newCoordinate < 0)
            {
                throw new ArgumentException("ConsoleDrawingCoordinates does not accept coordinates that are less than 0.");
            }
        }
    }
}
