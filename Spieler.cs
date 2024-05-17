namespace Left_Center_Right
{
    internal class Spieler
    {
        private int _chips;
        private string _name;
        public string Name { get; set; }
        public bool HatNochChips { get; set; }
        public int AnzahlWuerfel { get; set; }

        public Spieler(string name)
        {
            Name = name;
            _chips = 3;
            HatNochChips = true;
            AnzahlWuerfel = Math.Min(_chips, 3);
        }

        public void ErhalteChip()
        {
            _chips++;
            if (_chips > 0)
            {
                HatNochChips = true; 
            }
        }

        public void GebeChipAb()
        {
            if (_chips > 0)
            {
                _chips--;
                if (_chips <= 0)
                {
                    HatNochChips = false; 
                }
            }
        }

        public List<int> SpieleZug(Becher becher)
        {
            //Zeile 45, 47 und 52 von Chat GPT 
            if (!HatNochChips)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(Name + " hat keine Chips mehr und kann daher nicht würfeln.");
                Console.ResetColor();
                return new List<int>();
            }

            List<int> gewuerfelteZahlen;
            gewuerfelteZahlen = _chips < 3 ? becher.GetZahlen(_chips) : becher.GetZahlen(AnzahlWuerfel);
            Console.WriteLine();
            Console.WriteLine("Punktestand: " + PrintNameUndChips());
            Console.WriteLine();
            Console.ReadKey();
            Console.Write("Spieler " + Name + " hat gewürfelt:  ");
            Console.WriteLine(PrintWuerfel(gewuerfelteZahlen));
            Console.WriteLine();    
            if (_chips == 0)
            {
                HatNochChips = false;
            }
            return gewuerfelteZahlen;
        }

        public string PrintNameUndChips()
        {
            return Name + " hat " + _chips + " Chips.";
        }

        public string PrintWuerfel(List<int> wuerfe)
        {
            string wuerfelString = string.Join(", ", wuerfe);
            return wuerfelString;
        }
    }
}