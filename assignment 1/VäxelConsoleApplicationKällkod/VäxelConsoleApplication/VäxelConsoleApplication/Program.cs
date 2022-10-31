/* Inlämningsuppgift 1 L0002B
 * Beräkna växel
 * Datorterminal
 * 2022-10-24
 */


using System;


/*  Så här kan det se ut på skärmen:
    Ange pris: 152 (här skriver du in priset)
    Betalt: 500 (hur mycket kunden betalt)
    (Här ska det visas hur mycket och i vilka valörer kunden får sin växel)
    Växel tillbaka:
    1 tvåhundralapp
    2 hundralappar
    2 tjugor
    1 femkrona
    3 enkronor
    eller

    Ange pris: 44 (här skriver du in priset)
    Betalt: 764 (hur mycket kunden betalt)
    (Här ska det visas hur mycket och i vilka valörer kunden får sin växel)
    Växel tillbaka:
    1 femhundralapp
    1 tvåhundralapp
    1 tjuga
 * */


namespace VäxelConsoleApplication
{
    class Program
    {
        /// <summary>
        /// Huvudstartpunkten för programmet.
        /// </summary>
        /// <param name="args">Kommandotolk argument</param>
        static public void Main(string[] args)
        {
            try
            {
                long Pris, Betalt; // Variabler för att spara information om pris och den summa som har blivit betalt.

                Console.Write("Ange pris: "); // Inmatning av pris.
                if (longInmatningKonsolen(out Pris))
                {
                    if (Pris >= 0) // Priset måste vara mera eller noll kr.
                    {
                        InmatningBetalt(Pris, out Betalt); // Inmatning av den betalda summan.
                        Växel växel = VäxelBeräkna.BeräknaVäxel(Pris, Betalt); // Beräkna växel och spara resultatet.
                        UtmatningTillKonsolenVäxel(växel); // Utmatning av beräkningen.
                    }
                    else
                        Console.WriteLine("FEL!, Negativt pris"); // Något gick fel, priset var negativt värde.
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Något gick fel1: {ex.Message}"); // Ett fel har uppstått.
            }
        }

        /// <summary>
        /// Inmatning från konsolen av ett nummer, i long format.
        /// </summary>
        /// <param name="Pris">Referens av en long, som sätter värde från inmatningen från konsolen.</param>
        /// <returns>Återlämnar true om inga problem hände, om fel uppstog återlämnas false.</returns>
        static private bool longInmatningKonsolen(out long Pris)
        {
            try
            {
                Pris = Convert.ToInt64(Console.ReadLine()); // Inmatning från konsolen och konverterar värdet till long.
                return true; // Funktionen lyckades.
            }
            catch (FormatException)
            {
                Console.WriteLine("FEL!, Numret är inte ett heltal."); // Fel har inträffat.
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Något gick fel1: {ex.Message}"); // Fel har inträffat.
            }

            Pris = 0; // Lämna tillbaka 0 kr om fel har uppstått.
            return false; // Funktionen lyckades inte.
        }

        /// <summary>
        /// Inmatning från konsolen av ett nummer, i long format.
        /// Frågar tills störe summa än "Pris" har blivit angiven.
        /// Frågar specefikt av summan som har blivit betalt.
        /// </summary>
        /// <param name="Pris">Värde som jämförs med "Betalt" värdet, funktion återvänder enbart när Betalt är högre är Pris.</param>
        /// <param name="Betalt">Referens av en long, som sätter värde från inmatningen från konsolen. Är värdet som återlämnas.</param>
        static private void InmatningBetalt(long Pris, out long Betalt)
        {
            do // Inmatning av summan som har blivit betalt. Om fel uppstod, försök igen.
            {
                Console.Write("Betalt: ");
            } while (longInmatningKonsolen(out Betalt) == false);
            if (Betalt < Pris) // Om betalt är mindre är "Pris", försök igen, genom att kalla methoden igen.
            {
                Console.WriteLine($"För lite betalat, behövs ytterligaren: {Pris - Betalt} kr att betalas.");
                InmatningBetalt(Pris, out Betalt);
            }
        }

        /// <summary>
        /// Utmatar beräknad vöxel till konsolen.
        /// </summary>
        /// <param name="växel">Struktur som inerhåller beräknad växel värden, som ska utmatas till konsolen.</param>
        static private void UtmatningTillKonsolenVäxel(in Växel växel)
        {
            // Utmatar beräknad vöxel till konsolen.
            Console.WriteLine("Växel tillbaka:");
            if (växel.femhundralappar > 0)
                Console.WriteLine($"{växel.femhundralappar} femhundralapp{(växel.femhundralappar == 1 ? "" : /* femhundralappar > 1*/ "ar")}");
            if (växel.tvåhundralappar > 0)
                Console.WriteLine($"{växel.tvåhundralappar} tvåhundralapp{(växel.tvåhundralappar == 1 ? "" : /* tvåhundralappar > 1*/ "ar")}");
            if (växel.hundralappar > 0)
                Console.WriteLine($"{växel.hundralappar} hundralapp{(växel.hundralappar == 1 ? "" : /* hundralappar > 1*/ "ar")}");
            if (växel.tjugo > 0)
                Console.WriteLine($"{växel.tjugo} tjug{(växel.tjugo == 1 ? "a" : /* tjugo > 1*/ "or")}");
            if (växel.tiokronor > 0)
                Console.WriteLine($"{växel.tiokronor} tiokron{(växel.tiokronor == 1 ? "a" : /* tiokronor > 1*/ "or")}");
            if (växel.femkronor > 0)
                Console.WriteLine($"{växel.femkronor} femkron{(växel.femkronor == 1 ? "a" : /* femkronor > 1*/ "or")}");
            if (växel.enkronor > 0)
                Console.WriteLine($"{växel.enkronor} enkron{(växel.enkronor == 1 ? "a" : /* enkronor > 1*/ "or")}");
            if (växel.femhundralappar <= 0 && växel.tvåhundralappar <= 0 && växel.hundralappar <= 0 &&
                växel.tjugo <= 0 && växel.tiokronor <= 0 && växel.femkronor <= 0 &&
                växel.enkronor <= 0)
                Console.WriteLine("Ingen växel tillbaka.");
        }
    }
}
