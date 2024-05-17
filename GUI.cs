namespace Left_Center_Right
{
    internal class GUI
    {
        public List<Spieler> FrageSpielerEingabe()
        {
            List<Spieler> spielerListe = new List<Spieler>();
            bool spielerHinzufügen = true;

            Console.WriteLine("Willkommen in Left Center Right, viel Glück!");

            while (spielerHinzufügen)
            {
                Console.Write("Name des Spielers: ");
                string spielerName = Console.ReadLine();

                Spieler neuerSpieler = new Spieler(spielerName);
                spielerListe.Add(neuerSpieler);

                spielerHinzufügen = FrageNochEinSpieler();
            }

            return spielerListe;
        }

        public bool FrageNochEinSpieler()
        {
            Console.Write("Möchten Sie einen weiteren Spieler hinzufügen? (j/n): ");
            string antwort = Console.ReadLine();
            Console.WriteLine("-----------------------------------------------");
            return antwort.ToLower() == "j"; // Chat GPT
        }

        public void PrintRanglisteSpieler(List<Spieler> spieler)
        {
            Console.WriteLine("Rangliste: ");
            foreach (Spieler s in spieler)
            {
                Console.WriteLine(s.PrintNameUndChips());
            }
            Console.WriteLine("-----------------------------------------------");
        }

        public void PrintGewinner(List<Spieler> spieler)
        {
            Console.WriteLine("Gewonnen hat: ");
            foreach (Spieler s in spieler)
            {
                if (s.HatNochChips)
                {
                    Console.ForegroundColor = ConsoleColor.Green; 
                    Console.WriteLine(s.Name);
                    Console.ResetColor();
                }
            }
        }
    }
}