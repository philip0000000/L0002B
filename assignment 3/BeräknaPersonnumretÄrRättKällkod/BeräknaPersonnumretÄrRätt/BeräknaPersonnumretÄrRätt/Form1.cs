/* Inlämningsuppgift 3 L0002B
 * Beräkna om personnumret är godkänt.
 * Grafiskt användargränssnitt
 * 2022-10-24
 */


using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;


namespace BeräknaPersonnumretÄrRätt
{
    public partial class Form1 : Form
    {
        private personklass Personklass = new personklass();

        /// <summary>
        /// Återställ textBox värderna.
        /// </summary>
        public void ÅterställTextBoxVärderna()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
        }

        /// <summary>
        /// Visar menu.
        /// </summary>
        public void VisaMenu()
        {
            this.Text = "Menu";
            ÅterställTextBoxVärderna();

            // Göm registrera personnumret.
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            label6.Visible = false;

            textBox1.Visible = false;
            textBox2.Visible = false;
            textBox3.Visible = false;
            textBox4.Visible = false;

            button3.Visible = false;
            button4.Visible = false;

            panel1.Visible = false;

            panel2.Visible = false;
            panel3.Visible = false;
            panel4.Visible = false;
            panel5.Visible = false;
            panel6.Visible = false;

            // Visa menu.
            label1.Visible = true;
            button1.Visible = true;
            button2.Visible = true;
        }

        /// <summary>
        /// Visa beräkna om personnumret är godkänt.
        /// </summary>
        public void VisaRegistreraPersonen()
        {
            this.Text = "Registrera personen";
            ÅterställTextBoxVärderna();

            // Visa registrera personnumret.
            label2.Visible = true;
            label3.Visible = true;
            label4.Visible = true;
            label5.Visible = true;
            label6.Visible = true;

            textBox1.Visible = true;
            textBox2.Visible = true;
            textBox3.Visible = true;
            textBox4.Visible = true;

            button3.Visible = true;
            button4.Visible = true;

            panel1.Visible = true;

            panel2.Visible = true;
            panel3.Visible = true;
            panel4.Visible = true;
            panel5.Visible = true;
            panel6.Visible = true;

            panel3.BringToFront();
            panel2.BringToFront();

            // Göm menu.
            label1.Visible = false;
            button1.Visible = false;
            button2.Visible = false;
        }

        public Form1()
        {
            InitializeComponent();
            VisaMenu();
        }

        /// <summary>
        /// Vissa att beräkna om personnumret är godkänt.
        /// </summary>
        private void button1_Click(object sender, EventArgs e)
        {
            VisaRegistreraPersonen();
        }

        /// <summary>
        /// Avsluta programmet.
        /// </summary>
        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// Avsluta beräkna om personnumret är godkänt.
        /// </summary>
        private void button4_Click(object sender, EventArgs e)
        {
            VisaMenu();
        }

        /// <summary>
        /// Gör så att bara siffror är tillåtna i textBox och en "-",
        /// som skapas automatiskt om det finns tillräckligt med nummer(mera än 6 nummer).
        /// </summary>
        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            // 1:a - Ta bort allto som är icke-numerisk.
            int Selection = textBox3.SelectionStart; // Spara selection.
            string nyText = new string(textBox3.Text.Where(c => char.IsDigit(c)).ToArray()); // Ta bort allt som är icke-numeriska.

            if (nyText.Length > 10) // Om mera än tio nummer, ta bort allt som kommer efter 10.
                nyText = nyText.Substring(0, 10);

            // Ta bort alla ledande nollor och lägg till en nolla om det är tomt efter.
            if (nyText.Length > 1)
            {
                nyText = nyText.TrimStart('0'); // Ta bort ledande nollor.
                if (nyText.Length == 0) // Om tom, lägg till en 0.
                    nyText = "0";
            }

            Selection = Selection + (nyText.Length - textBox3.Text.Length); // Beräkna ny "selection".

            // 2:a - Lägg till "-", om det finns tillräckligt med nummer.
            if (nyText.Length > 6) // Lägg till "-" vid 6:e numret.
            {
                nyText = nyText.Insert(6, "-");
                Selection++;
            }

            if (Selection < 0) // Om select värdet är mindre än 0, sätt värdet till 0.
                Selection = 0;

            // 3:e - Sätt nya textBox texten och nya "select" värdet.
            textBox3.Text = nyText;
            textBox3.Select(Selection, 0);
        }

        /// <summary>
        /// Kontrollera fel, om fel återlämna true. Om inget fel återlämna false.
        /// </summary>
        /// <returns>true för fel, false för inget fel.</returns>
        private bool KontrolleraFel()
        {
            // Testa för fel. Om fel, berätta vad och återvänd true.
            if (textBox1.Text == "")
            {
                UtmatningTillTextLåda("  FEL! Finns inget för namn.", true);
                return true;
            }
            if (textBox2.Text == "")
            {
                UtmatningTillTextLåda("  FEL! Finns inget efternamn.", true);
                return true;
            }
            if (textBox3.Text.Length < 11)
            {
                UtmatningTillTextLåda("  FEL! För lite nummer för personnumret.", true);
                return true;
            }

            return false; // Inget fel.
        }

        /// <summary>
        /// Styr förloppet när personnumret ska godkännas.
        /// </summary>
        private void button3_Click(object sender, EventArgs e)
        {
            if (KontrolleraFel() == true) // Kontrollera fel, om fel återvänd.
                return;

            // Hämtar personnumret från textBox i Form och ta bort "-", om det finns.
            string StrPersonnumer;
            StrPersonnumer = textBox3.Text.Replace("-", ""); // ta bort "-" från personnumret

            // Extra kontroll för fel
            if (StrPersonnumer.Length < 10)
            {
                UtmatningTillTextLåda("  FEL! För lite nummer för personnumret.", true);
                return;
            }

            // Placera informationen om personnumret till klassen Personklass egenskaper.
            Personklass.SättEgenskaper(textBox1.Text, textBox2.Text, StrPersonnumer);

            // 2. Beräkna om personnumret är godkänt.
            if (Personklass.PersonnumretGiltigt() == true) // true om personnumret är giltigt.
            {
                UtmatningTillTextLåda(Personklass.strHämtaUtmatning()); // Utmatning av godkänt personnummer information.
            }
            else
                UtmatningTillTextLåda("  Personnummer felaktigt, försök igen!", true); // Utmatning, som informerar att det är fel med personnumret.
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
                textBox4.ForeColor = SystemColors.WindowText; // Svart text för fel.
            else
                textBox4.ForeColor = Color.Red;               // Röd text om inget fel.
            textBox4.BackColor = textBox4.BackColor;          // Måste göra det här, för att updatera färg på text.

            textBox4.Text = meddelande; // Utmata meddelandet.
        }
    }
}
