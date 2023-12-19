namespace Personnummer 
{
    class Program
    {
        public static void Main()
        {
            Console.Write("Ange ditt personnummer: ");
            string personnummer = Console.ReadLine().Replace("-", "").Replace(" ", "");

            if (giltigtTecken(personnummer))
            {
                if (personnummer.Length == 12)
                {
                    personnummer = personnummer.Substring(2);
                }
                if (giltigtPersonnummer(personnummer))
                {
                    Console.WriteLine("Personnumret är giltigt.");
                }
                else
                {
                    Console.WriteLine("Personnumret är ogiltigt.");
                }
            }
            else
            {
                Console.WriteLine("Ogiltig inmatning. Ange endast siffror.");
            }
        }

        public static bool giltigtPersonnummer(string personnummer)
        {
            if (personnummer.Length != 10)
            {
                Console.WriteLine("Ogiltigt antal siffror angivet.");
                return false;
            }

            int summa = 0;

            for (int currentIndex = 0; currentIndex < 9; currentIndex++)
            {
                int siffra = int.Parse(personnummer[currentIndex].ToString());

                if (currentIndex % 2 == 0)
                {
                    siffra *= 2;

                    if (siffra >= 10)
                    {
                        siffra = siffra % 10 + siffra / 10;
                    }
                }
                summa += siffra;
            }
            int kontrollsiffra = int.Parse(personnummer[9].ToString());

            return (10 - (summa % 10)) % 10 == kontrollsiffra;
        }

        public static bool giltigtTecken(string input)
        {
            foreach (char tecken in input)
            {
                if (!char.IsDigit(tecken))
                {
                    return false;
                }
            }
            return true;
        }
    }
}