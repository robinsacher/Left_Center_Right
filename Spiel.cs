using System.Xml.Linq;

namespace Left_Center_Right
{
    internal class Spiel
    {
        private Spieler _aktuellerSpieler;
        private List<Spieler> _spielerListe;
        private GUI _gui;
        private Becher _becher;

        public Spiel()
        {
            _gui = new GUI();
            _spielerListe = _gui.FrageSpielerEingabe();
            _becher = new Becher();
            SetzeStartSpieler();
        }

        public void Spielen()
        {
            while (MehrAlsEinSpielerHatChips())
            {
                Console.ReadKey();
                _becher.Schuettle();
                List<int> gewuerfelteZahlen = _aktuellerSpieler.SpieleZug(_becher);
                GewuefelteZahlenVerarbeiten(gewuerfelteZahlen);
                _aktuellerSpieler = SpielerRechtsVonAktuellemSpieler();
                _gui.PrintRanglisteSpieler(_spielerListe);
            }
            _gui.PrintGewinner(_spielerListe);
        }

        public void GewuefelteZahlenVerarbeiten(List<int> zahlen)
        {
            foreach (int zahl in zahlen)
            {
                if (zahl == 4)
                {
                    ChipNachLinksWeitergeben();
                }
                else if (zahl == 5)
                {
                    ChipNachRechtsWeitergeben();
                }
                else if (zahl == 6)
                {
                    ChipInDieMitteLegen();
                }
            }
        }

        public void SetzeStartSpieler()
        {
            Random random = new Random();
            int zufallsIndex = random.Next(0, _spielerListe.Count); // List.Count Eigenschaft von https://www.delftstack.com/de/howto/csharp/csharp-list-count/
            _aktuellerSpieler = _spielerListe[zufallsIndex];
        }

        public Spieler SpielerRechtsVonAktuellemSpieler()
        {
            //Chat GPT
            int aktuellerIndex = _spielerListe.IndexOf(_aktuellerSpieler);
            int rechterIndex = (aktuellerIndex + 1) % _spielerListe.Count;
            //

            return _spielerListe[rechterIndex];
        }

        public Spieler SpielerLinksVonAktuellemSpieler()
        {
            //Chat GPT
            int aktuellerIndex = _spielerListe.IndexOf(_aktuellerSpieler);
            int linkerIndex = (aktuellerIndex - 1 + _spielerListe.Count) % _spielerListe.Count;
            //

            return _spielerListe[linkerIndex];
        }

        public bool MehrAlsEinSpielerHatChips()
        {
            int spielerMitChips = 0;
            foreach (Spieler spieler in _spielerListe)
            {
                if (spieler.HatNochChips)
                {
                    spielerMitChips++;
                }
            }
            return spielerMitChips > 1;
        }

        public void ChipNachLinksWeitergeben()
        {
            Spieler linkerSpieler = SpielerLinksVonAktuellemSpieler();
            _aktuellerSpieler.GebeChipAb();
            linkerSpieler.ErhalteChip();
        }

        public void ChipNachRechtsWeitergeben()
        {
            Spieler rechterSpieler = SpielerRechtsVonAktuellemSpieler();
            _aktuellerSpieler.GebeChipAb();
            rechterSpieler.ErhalteChip();
        }

        public void ChipInDieMitteLegen()
        {
            _aktuellerSpieler.GebeChipAb();
        }
    }
}