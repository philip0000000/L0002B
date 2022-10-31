/* Inlämningsuppgift 2 L0002B
 * Antal säljare ordna
 * Grafiskt användargränssnitt
 * 2022-10-24
 */


using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;


namespace AntalSäljareBeräkna
{
    public partial class Form1
    {
        /// <summary>
        /// Kontrollerar användarens inmatning, och återlämnar true om fel uppstod eller false om inget fel påträffades.
        /// </summary>
        /// <returns>true om fel hittades, false om inget fel hittades.</returns>
        private bool KontrolleraAnvändarensInmatning()
        {
            Säljare hittade = Säljkår.Find(s => s.Namn == "" ||     // Hitta fel.
                                           s.Persnr.Length != 10 ||
                                           s.Distrikt == "" ||
                                           s.Antal < 0);

            if (hittade == null)
                return true; // Inget fel hittades.

            // Fel hittades, skriv ut fel.
            if (hittade.Namn == "")
                UtmatningTillTextLåda($"Nummer {Säljkår.FindIndex(m => hittade.Namn == m.Namn) + 1} i list lådan saknar information.", true); // Lägger +1, börjar inte från 0 när vi talar om fel för användaren.
            else if (hittade.Persnr.Length != 10)
                UtmatningTillTextLåda($"{hittade.Namn} person nummer är för litet, måste vara 10 siffror.", true);
            else if (hittade.Distrikt == "")
                UtmatningTillTextLåda($"{hittade.Namn} distrikt är tomt.", true);
            else //if (hittade.Antal < 0)
                UtmatningTillTextLåda($"{hittade.Namn} antal sålda, är mindre är 0.", true);
            return false;
        }

        /// <summary>
        /// Ordnar säljkåren som är sparad i klassen, enligt bubble sort algorithm på antal sålda artiklar.
        /// </summary>
        /// <returns>Återlämnar en list med Säljare ordnade, från lägst till högst sålda antal artiklar.</returns>
        private List<Säljare> OrdnaSäljkåren()
        {
            /* Exempel:
                    --börjar-->
    (lägst värde)   6 4 5 1 3 5   (högst värde)
                    4 6 5 1 3 5
                    4 5 6 1 3 5
                    4 5 1 6 3 5
                    4 5 1 3 6 5
                    4 5 1 3 5 6

                    4 5 1 3 5 6

                    4 5 1 3 5 6
                    4 1 5 3 5 6
                    4 1 3 5 5 6
                    4 1 3 5 5 6
                    4 1 3 5 5 6
             */
            // Bubble Sort algorithm
            //InputProperty[] ip = new InputProperty[nvPairs.Length];

            // Förberedd variabler för att byta, genom att dela upp egenskaperna.
            string[] Namn = new string[Säljkår.Count];
            string[] Persnr = new string[Säljkår.Count];
            string[] Distrikt = new string[Säljkår.Count];
            int[] Antal = new int[Säljkår.Count];

            for (var i = 0; i < Säljkår.Count; i++)
            {
                Namn[i] = Säljkår[i].Namn;
                Persnr[i] = Säljkår[i].Persnr;
                Distrikt[i] = Säljkår[i].Distrikt;
                Antal[i] = Säljkår[i].Antal;
            }

            // 2a: Bubble sort, med två variabels (bortse när man byter värderna)
            bool repeat;
            do
            {
                repeat = false;
                for (int b = 0; b < Antal.Length - 1; b++) // Gå igenom varje nummer i tur och ordning.
                    if (Antal[b] > Antal[b + 1]) // Om nummret till vänster är högre än numret till höger, byt nummer.
                    {
                        // Byt värdern.
                        var tempAntal = Antal[b + 1];
                        Antal[b + 1] = Antal[b];
                        Antal[b] = tempAntal;

                        // Byt plats på andra värderna.
                        var tempNamn = Namn[b + 1]; Namn[b + 1] = Namn[b]; Namn[b] = tempNamn;
                        var tempPersnr = Persnr[b + 1]; Persnr[b + 1] = Persnr[b]; Persnr[b] = tempPersnr;
                        var tempDistrikt = Distrikt[b + 1]; Distrikt[b + 1] = Distrikt[b]; Distrikt[b] = tempDistrikt;

                        repeat = true; // Om vi byter enbart en gång, måste vi testa hella array(alla tal) igen.
                    }
            } while (repeat); // Upprepa om det behövs.

            // 1:a bubble sort, med bara "en variabel" (bortse när man byter värderna)
            /*int n = 0;
            while (n < Antal.Length - 1)
            {
                if (Antal[n] > Antal[n + 1])
                {
                    do
                    {
                        // byt plats
                        var tempAntal = Antal[n + 1];
                        Antal[n + 1] = Antal[n];
                        Antal[n] = tempAntal;

                        // byt plats på andra värderna2
                        var tempNamn = Namn[n + 1]; Namn[n + 1] = Namn[n]; Namn[n] = tempNamn;
                        var tempPersnr = Persnr[n + 1]; Persnr[n + 1] = Persnr[n]; Persnr[n] = tempPersnr;
                        var tempDistrikt = Distrikt[n + 1]; Distrikt[n + 1] = Distrikt[n]; Distrikt[n] = tempDistrikt;

                        n++;
                    } while (n < Antal.Length - 1 && Antal[n] > Antal[n + 1]);
                    n = 0;
                }
                else
                    n++;
            }/**/

            // Skapar list List<Säljare> med värde antal sålda artiklar från låg till hög för att återlämna.
            List<Säljare> SäljareSorterade = new List<Säljare>();

            for (var i = 0; i < Säljkår.Count; i++)
            {
                SäljareSorterade.Add(new Säljare(Namn[i], Persnr[i], Distrikt[i], Antal[i]));
            }

            return SäljareSorterade;
        }

        /// <summary>
        /// Formatera säljare info till en string som återlämnas.
        /// </summary>
        /// <param Säljare="säljare">Information om säljare.</param>
        /// <returns>String som har formaterat resultat av säljare.</returns>
        private string FormateraSäljare(Säljare säljare)
        {
            StringBuilder strBuild = new StringBuilder();

            // Lägger till namn.
            strBuild.Append(säljare.Namn);
            // Lägger till mellanrum till nästa värde.
            int RepeatPadding = 14 - säljare.Namn.Length;
            if (RepeatPadding > 0)
                strBuild.Append(' ', RepeatPadding);

            // Lägger till person nummer.
            strBuild.Append(säljare.Persnr);
            // Lägger till mellanrum till nästa värde.
            RepeatPadding = 16 - säljare.Persnr.Length;
            if (RepeatPadding > 0)
                strBuild.Append(' ', RepeatPadding);

            // Lägger till distrikt.
            strBuild.Append(säljare.Distrikt);
            // Lägger till mellanrum till nästa värde.
            RepeatPadding = 18 - säljare.Distrikt.Length;
            if (RepeatPadding > 0)
                strBuild.Append(' ', RepeatPadding);

            // Lägger till antal sålda artiklar.
            strBuild.Append(säljare.Antal);

            return strBuild.ToString();
        }

        /// <summary>
        /// Återlämnar en string som har formaterat resultat av säljkåren.
        /// </summary>
        /// <returns>String som har formaterat resultat av säljkåren.</returns>
        private string SkapaStringAvSäljkåren(List<Säljare> FormateraSäljkår)
        {
            int AntalSäljareNivå = 0, IndexIList = 0;
            StringBuilder strBuild = new StringBuilder();

            strBuild.AppendLine("Namn          Persnr          Distrikt          Antal");

            // 1:a nivåen, under 50
            while (IndexIList < FormateraSäljkår.Count && FormateraSäljkår[IndexIList].Antal < 50)
            {
                strBuild.AppendLine(FormateraSäljare(FormateraSäljkår[IndexIList]));
                AntalSäljareNivå++;
                IndexIList++;
            }
            if (AntalSäljareNivå > 0)
            {
                strBuild.AppendLine($"{AntalSäljareNivå} säljare har nått nivå 1: under 50 artiklar");
                strBuild.AppendLine();
                AntalSäljareNivå = 0;
            }

            // 2:a nivåen, mellan 50-99
            while (IndexIList < FormateraSäljkår.Count && FormateraSäljkår[IndexIList].Antal < 100)
            {
                strBuild.AppendLine(FormateraSäljare(FormateraSäljkår[IndexIList]));
                AntalSäljareNivå++;
                IndexIList++;
            }
            if (AntalSäljareNivå > 0)
            {
                strBuild.AppendLine($"{AntalSäljareNivå} säljare har nått nivå 2: mellan 50-99 artiklar");
                strBuild.AppendLine();
                AntalSäljareNivå = 0;
            }

            // 3:e nivåen, mellan 100-199
            while (IndexIList < FormateraSäljkår.Count && FormateraSäljkår[IndexIList].Antal < 200)
            {
                strBuild.AppendLine(FormateraSäljare(FormateraSäljkår[IndexIList]));
                AntalSäljareNivå++;
                IndexIList++;
            }
            if (AntalSäljareNivå > 0)
            {
                strBuild.AppendLine($"{AntalSäljareNivå} säljare har nått nivå 3: mellan 100-199 artiklar");
                strBuild.AppendLine();
                AntalSäljareNivå = 0;
            }

            // 4:e nivåen, över 199
            while (IndexIList < FormateraSäljkår.Count && FormateraSäljkår[IndexIList].Antal > 199)
            {
                strBuild.AppendLine(FormateraSäljare(FormateraSäljkår[IndexIList]));
                AntalSäljareNivå++;
                IndexIList++;
            }
            if (AntalSäljareNivå > 0)
            {
                strBuild.AppendLine($"{AntalSäljareNivå} säljare har nått nivå 4: över 199 artiklar");
            }

            return strBuild.ToString();
        }

        /// <summary>
        /// Styr flödet när beräkning sker.
        /// </summary>
        private void button1_Click(object sender, EventArgs e)
        {
            // Kontrollera för fel.
            if (Säljkår.Count < 1)
            {
                UtmatningTillTextLåda("FEL! Finns inga säljare.", true);
                return;
            }

            // 0. Gör att "Antal sålda artiklar" har standard värde.
            if (Säljkår[listBox1.SelectedIndex].Antal == 0)
                textBoxAntalSåldaArtiklar.Text = "0";

            // 1. Kontrollera att all information finns och är korrekt.
            if (KontrolleraAnvändarensInmatning() == false)
                return;

            // 2. Sätt utmatnings fil namn, om inget namn, ge den stanard namn "resultat.txt".
            if (textBoxResultat.Text == "")
                textBoxResultat.Text = "resultat.txt";
            string UtskriftFil = textBoxResultat.Text;

            // 3. Beräkna ordningen på antal sålda artiklar.
            List<Säljare> FormateradSäljkår = OrdnaSäljkåren();

            // 4. Utmatning till textBox, programmet.
            string UtmatningText = SkapaStringAvSäljkåren(FormateradSäljkår);

            UtmatningTillTextLåda(UtmatningText); // Utmatning till GUI programmet.
            System.IO.File.WriteAllText(UtskriftFil, UtmatningText); // Utmatning till en fil.
        }

        /// <summary>
        /// Utmatning av text till textlåda i programmet.
        /// </summary>
        /// <param name="meddelande">Meddelandet som ska utmatas.</param>
        /// <param name="fel">Om meddelandet ska behandlas som fel(är true då), om uteblivande är false</param>
        private void UtmatningTillTextLåda(string meddelande, bool fel = false)
        {
            // Sätt text färg.
            if (fel == true)
                textBox6.ForeColor = Color.Red;               // Röd text för fel.
            else
                textBox6.ForeColor = SystemColors.WindowText; // Svart text om inget fel.
            textBox6.BackColor = textBox6.BackColor;          // Måste göra det här, för att updatera färg på text.

            textBox6.Text = meddelande; // Utmata meddelandet.
        }
    }
}
