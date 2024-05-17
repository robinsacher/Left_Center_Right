namespace Left_Center_Right
{
    internal class Wuerfel
    {
        private const int MAX_NUMBER = 6;
        private Random _random;
        private int _letzteZahl;
        public int LetzteZahl { get; set; }

        public void Wuerfle()
        {
            _random = new Random();
            LetzteZahl = 1;
            LetzteZahl = _random.Next(1, MAX_NUMBER + 1);
        }
    }
}