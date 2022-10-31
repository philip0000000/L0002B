/* Inlämningsuppgift 1 L0002B
 * Beräkna växel
 * Grafiskt användargränssnitt
 * 2022-10-24
 */


using System;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


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


namespace VäxelWindowsForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Gör så att bara siffror är tillåtna i textBox.
        /// </summary>
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            int SelectionBörjar = textBox1.SelectionStart; // Spara där "selection" är.
            textBox1.Text = new string(textBox1.Text.Where(c => char.IsDigit(c)).ToArray()) // Ta bort allt som är icke-numeriska.
                                       .TrimStart('0'); // Ta bort ledande nollor.
            textBox1.Select(SelectionBörjar, 0); // Sätt "selection" är.
        }

        /// <summary>
        /// När man trycker på "Enter", beräkna växel.
        /// </summary>
        private void textBox1_TextChangedKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                this.Beräkna();
        }

        /// <summary>
        /// Gör så att bara siffror är tillåtna i textBox.
        /// </summary>
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            int Selection = textBox2.SelectionStart; // Spara där "selection" är.
            textBox2.Text = new string(textBox2.Text.Where(c => char.IsDigit(c)).ToArray()) // Ta bort allt som är icke-numeriska.
                           .TrimStart('0'); // Ta bort ledande nollor.
            textBox2.Select(Selection, 0); // Sätt "selection" är.
        }

        /// <summary>
        /// När man trycker på "Enter", beräkna växel.
        /// </summary>
        private void textBox2_TextChangedKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                this.Beräkna();
        }

        /// <summary>
        /// När man klickar på "Beräkna växel" knappen.
        /// </summary>
        private void button1_Click(object sender, EventArgs e)
        {
            Beräkna();
        }

        /// <summary>
        /// Styr hur beräkning av växel ska gå till.
        /// </summary>
        private void Beräkna()
        {
            try
            {
                long Pris = Convert.ToInt64(textBox1.Text); // Inmatning av värdet från textBox och konverterar värdet till long.
                long Betalt = Convert.ToInt64(textBox2.Text); // Inmatning av värdet från textBox och konverterar värdet till long.

                Växel växel = VäxelBeräkna.BeräknaVäxel(Pris, Betalt); // Beräkna växel och spara resultatet.
                LägtillUtmatningInfoTillTextLåda(växel); // Utmatning av beräkningen till textbox i formen.
            }
            catch (FormatException)
            {
                UtmatningTillTextLåda("Inmatnings värderna är inte korrekta.", true); // Fel med inmatnings värderna.
            }
            catch (Exception ex)
            {
                UtmatningTillTextLåda($"Något gick fel: {ex.Message}", true); // Ett fel har uppstått.
            }
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
                textBox.ForeColor = Color.Red;               // Röd text för fel.
            else
                textBox.ForeColor = SystemColors.WindowText; // Svart text om inget fel.
            textBox.BackColor = textBox.BackColor;           // Måste göra det här, för att updatera färg på text.

            textBox.Text = meddelande; // Utmata meddelandet.
        }

        /// <summary>
        /// Utmatning av växel värderna till programmet.
        /// </summary>
        /// <param name="växel">Struktur som inerhåller beräknad växel värden, som ska utmatas till konsolen.</param>
        private void LägtillUtmatningInfoTillTextLåda(Växel växel)
        {
            // Skapa stringbuilder som bygger en string som sen utmatas till textlåda på programmet.
            StringBuilder strBuild = new StringBuilder();

            strBuild.AppendLine("Växel tillbaka:");
            if (växel.femhundralappar > 0)
                strBuild.AppendLine($"{växel.femhundralappar} femhundralapp{(växel.femhundralappar == 1 ? "" : /* femhundralappar > 1*/ "ar")}");
            if (växel.tvåhundralappar > 0)
                strBuild.AppendLine($"{växel.tvåhundralappar} tvåhundralapp{(växel.tvåhundralappar == 1 ? "" : /* tvåhundralappar > 1*/ "ar")}");
            if (växel.hundralappar > 0)
                strBuild.AppendLine($"{växel.hundralappar} hundralapp{(växel.hundralappar == 1 ? "" : /* hundralappar > 1*/ "ar")}");
            if (växel.tjugo > 0)
                strBuild.AppendLine($"{växel.tjugo} tjug{(växel.tjugo == 1 ? "a" : /* tjugo > 1*/ "or")}");
            if (växel.tiokronor > 0)
                strBuild.AppendLine($"{växel.tiokronor} tiokron{(växel.tiokronor == 1 ? "a" : /* tiokronor > 1*/ "or")}");
            if (växel.femkronor > 0)
                strBuild.AppendLine($"{växel.femkronor} femkron{(växel.femkronor == 1 ? "a" : /* femkronor > 1*/ "or")}");
            if (växel.enkronor > 0)
                strBuild.AppendLine($"{växel.enkronor} enkron{(växel.enkronor == 1 ? "a" : /* enkronor > 1*/ "or")}");
            if (växel.femhundralappar <= 0 && växel.tvåhundralappar <= 0 && växel.hundralappar <= 0 &&
                växel.tjugo <= 0 && växel.tiokronor <= 0 && växel.femkronor <= 0 &&
                växel.enkronor <= 0)
                strBuild.AppendLine("Ingen växel tillbaka.");

            UtmatningTillTextLåda(strBuild.ToString());
        }

        /// <summary>
        /// Avslutar programmet
        /// </summary>
        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
