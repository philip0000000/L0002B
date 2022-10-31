/* Inlämningsuppgift 3 L0002B
 * Beräkna om personnumret är godkänt.
 * Grafiskt användargränssnitt
 * 2022-10-24
 */


using System;
using System.Linq;
using System.Text;

namespace BeräknaPersonnumretÄrRätt
{
    /// <summary>
    /// Värde för mänskligt kön, man eller kvinna.
    /// </summary>
    enum Kön
    {
        Man,
        Kvinna
    }

    class personklass
    {
        // Egenskaper:
        private string förnamn;
        private string efternamn;
        private string personnummer;

        /// <summary>
        /// Sätter nya egenskaper.
        /// </summary>
        /// <param name="förnamn">förnamn av person</param>
        /// <param name="efternamn">efternamn av person</param>
        /// <param name="personnummer">personnummer av person</param>
        public void SättEgenskaper(string förnamn, string efternamn, string personnummer)
        {
            this.förnamn = förnamn;
            this.efternamn = efternamn;
            this.personnummer = personnummer;
        }

        // Metoder:
        /// <summary>
        /// Beräknar om personnumret är giltigt, återlämnar bool om giltigt eller inte giltigt.
        /// </summary>
        /// <returns>True om personnumret är giltigt, false om inte.</returns>
        public bool PersonnumretGiltigt()
        {
            // Förbereder värdena inför beräkningarna.
            int summa = 0;
            var personr = personnummer.Select(n => Convert.ToInt32(n - '0')) // String to array av int, varje int representerar ett nummer i personnumret.
                .ToArray();

            // Kontroll av personnummer - 21Algoritm
            for (int n = 0; n < personr.Length; n++) // Gå igenom varje nummer i tur och ordning.
            {
                var temp = ((n % 2) == 0 ? personr[n] * 2 : personr[n]); // Udda multiplicera med 2, i annat fall inte.
                // Addera all nummer tillsamans.
                if (temp > 9) // Om nummret har två decimal tal, behandla båda två som enskilt nummer.
                {
                    summa += temp % 10; // Lägg till lägre del av decimal talet.
                    summa += temp / 10; // Lägg till övre del av decimal talet.
                }
                else
                    summa += temp;
            }

            return (summa % 10 == 0) ? // Om suman är delbart med 10, så är personnumret giltigt. I annat fall inte.
                true : false;
        }

        /// <summary>
        /// Beräknar kön från personnumret.
        /// </summary>
        /// <returns>Återlämnar värde på kön.</returns>
        public Kön KönUtifrånPersonnumret()
        {
            return (Convert.ToInt32(personnummer[8]) % 2 == 0) ? // Jämför 8:e nummret i personnumret är jämnt eller udda.
                Kön.Kvinna : // Jämnt nummer för kvinnor.
                Kön.Man;     // Udda nummer för män.
        }

        /// <summary>
        /// Bygger en string, för utmatning information.
        /// </summary>
        /// <returns>String med information utifrån personnumreet.</returns>
        public string strHämtaUtmatning()
        {
            StringBuilder strBuild = new StringBuilder(); // Bygg utmattnings string.

            strBuild.AppendLine($"  Förnamn: {förnamn}");
            strBuild.AppendLine($"  Efternamn: {efternamn}");
            strBuild.AppendLine($"  Personnr:: {personnummer.ToString().Insert(6, "-")}");

            if (KönUtifrånPersonnumret() == Kön.Man) // Lägg till utmatnings stringen kön.
                strBuild.AppendLine("  Man");
            else // == Kön.Kvinna
                strBuild.AppendLine("  Kvinna");

            return strBuild.ToString();
        }
    }
}
