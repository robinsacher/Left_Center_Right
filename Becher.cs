namespace Left_Center_Right
{
    internal class Becher
    {   
        private const int ANZ_WUERFEL = 3;
        private List<Wuerfel> _wuerfel;
        
        public Becher()
        {
            _wuerfel = new List<Wuerfel>();
            for (int i = 0; i < 3; i++)
            {
                _wuerfel.Add(new Wuerfel());
            }
        }

        public void Schuettle()
        {
            foreach (var wuerfel in _wuerfel)
            {
                wuerfel.Wuerfle();
            }
        }

        public List<int> GetZahlen(int anzahl)
        {
            List<int> gewuerfelteZahlen = new List<int>();
            for (int i = 0; i < anzahl; i++)
            {
                gewuerfelteZahlen.Add(_wuerfel[i].LetzteZahl);
            }
            return gewuerfelteZahlen;
        }
    }
}
