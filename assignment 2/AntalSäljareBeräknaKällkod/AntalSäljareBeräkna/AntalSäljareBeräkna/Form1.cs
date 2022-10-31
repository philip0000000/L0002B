/* Inlämningsuppgift 2 L0002B
 * Antal säljare ordna
 * Grafiskt användargränssnitt
 * 2022-10-24
 */


using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;


namespace AntalSäljareBeräkna
{
    public partial class Form1 : Form
    {
        private int ListBoxNuvarandeVärde = 0;
        private List<Säljare> Säljkår = new List<Säljare>();
        private int ValdListBox = -1;

        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Lägg till eller ta bort från Säljkår, enligt värdet i numericUpDown.
        /// </summary>
        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            int NyttVärde = Convert.ToInt32(Math.Round(numericUpDown1.Value, 0, MidpointRounding.AwayFromZero));

            // Ta bort eller lägg till, i listBox värden.
            if (ListBoxNuvarandeVärde < NyttVärde)
            {
                // Lägg till, längst bak.
                for (int diff = NyttVärde - ListBoxNuvarandeVärde; diff > 0; diff--)
                {
                    ListBoxNuvarandeVärde++;
                    listBox1.Items.Add("[Tom]");
                    Säljkår.Add(new Säljare("", "", "", 0));
                }
            }
            else if (ListBoxNuvarandeVärde > NyttVärde)
            {
                // Ta bort sista.
                for (int diff = ListBoxNuvarandeVärde - NyttVärde; diff > 0; diff--)
                {
                    ListBoxNuvarandeVärde--;
                    listBox1.Items.RemoveAt(listBox1.Items.Count - 1);
                    Säljkår.RemoveAt(Säljkår.Count - 1);
                }
            }
        }

        /// <summary>
        /// Välj vilken Säljare i Säljkår som ska vissas, enligt vilken som har varit vald i listBoxen.
        /// </summary>
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ValdListBox == listBox1.SelectedIndex) // Om sama listBox värde, återvänd.
                return;
            ValdListBox = listBox1.SelectedIndex; // Spara vald listBox värde.

            if (listBox1.SelectedIndex >= 0)
            {
                // Aktivera inmatning.
                textBoxNamn.Enabled = true;
                textBoxPersonnummer.Enabled = true;
                textBoxDistrikt.Enabled = true;
                textBoxAntalSåldaArtiklar.Enabled = true;

                // Sätt värderna som är sparade i List<Säljare> Säljkår.
                textBoxNamn.Text = Säljkår[listBox1.SelectedIndex].Namn;
                textBoxPersonnummer.Text = Säljkår[listBox1.SelectedIndex].Persnr;
                textBoxDistrikt.Text = Säljkår[listBox1.SelectedIndex].Distrikt;
                textBoxAntalSåldaArtiklar.Text = Säljkår[listBox1.SelectedIndex].Antal == 0 ?
                                                 "" :
                                                 Säljkår[listBox1.SelectedIndex].Antal.ToString();

                // Sätt namn på listBox1 Itemet.
                listBox1.Items[listBox1.SelectedIndex] = Säljkår[listBox1.SelectedIndex].Namn == "" ?
                                                         "[Tom]" : Säljkår[listBox1.SelectedIndex].Namn; // Om inget namn finns, är namnet "[Tom]".
            }
            else
            {
                // Avaktivera inmatning.
                textBoxNamn.Enabled = false;
                textBoxPersonnummer.Enabled = false;
                textBoxDistrikt.Enabled = false;
                textBoxAntalSåldaArtiklar.Enabled = false;

                textBoxNamn.Text = "";
                textBoxPersonnummer.Text = "";
                textBoxDistrikt.Text = "";
                textBoxAntalSåldaArtiklar.Text = "";
            }
        }

        /// <summary>
        /// Sätter namn på listBox items, villket är värdet i textboxen som den hämtar från.
        /// Spara textBox värde för namn.
        /// </summary>
        private void textBoxNamn_TextChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex < 0) // Om listBox värdet är inte selectad(mindre än noll), återvänd och gör inte methoden.
                return;

            if (Säljkår[listBox1.SelectedIndex].Namn != textBoxNamn.Text)
            {
                int Selection = textBoxNamn.SelectionStart; // Spara fokus position.

                Säljkår[listBox1.SelectedIndex].Namn = textBoxNamn.Text;
                listBox1.Items[listBox1.SelectedIndex] = Säljkår[listBox1.SelectedIndex].Namn == "" ?
                                                         "[Tom]" : Säljkår[listBox1.SelectedIndex].Namn;

                textBoxNamn.Focus(); // Måste återigen fokusera på textBox, förlorar fokus när man ändrar på namn i listBoxen.
                textBoxNamn.Select(Selection, 0); // Sätt "selection" position.
            }
        }

        /// <summary>
        /// Gör så att bara siffror är tillåtna i textBox och en "-",
        /// som skapas automatiskt om det finns tillräckligt med nummer(mera än 6 nummer).
        /// Spara textBox värde för personnummer.
        /// </summary>
        private void textBoxPersonnummer_TextChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex < 0) // Om listBox värdet är inte selectad(mindre än noll), återvänd och gör inte methoden.
                return;

            // 1:a - Ta bort allto som är icke-numerisk.
            int Selection = textBoxPersonnummer.SelectionStart; // Spara selection.
            string nyText = new string(textBoxPersonnummer.Text.Where(c => char.IsDigit(c)).ToArray()); // Ta bort allt som är icke-numeriska.

            if (nyText.Length > 10) // Om mera än tio nummer, ta bort allt som kommer efter 10.
                nyText = nyText.Substring(0, 10);

            // Ta bort alla ledande nollor och lägg till en nolla om det är tomt efter.
            if (nyText.Length > 1)
            {
                nyText = nyText.TrimStart('0'); // Ta bort ledande nollor.
                if (nyText.Length == 0) // Om tom, lägg till en 0.
                    nyText = "0";
            }

            Selection = Selection + (nyText.Length - textBoxPersonnummer.Text.Length); // Beräkna ny "selection".

            // 2:a - Spara det nya värdet.
            if (Säljkår[listBox1.SelectedIndex].Persnr != nyText)
                Säljkår[listBox1.SelectedIndex].Persnr = nyText;

            // 3:e - Lägg till "-", om det finns tillräckligt med nummer.
            if (nyText.Length > 6) // Lägg till "-" vid 6:e numret.
            {
                nyText = nyText.Insert(6, "-");
                Selection++;
            }

            if (Selection < 0) // Om select värdet är mindre än 0, sätt värdet till 0.
                Selection = 0;

            // 4:e - Sätt nya textBox texten och nya "select" värdet.
            textBoxPersonnummer.Text = nyText;
            textBoxPersonnummer.Select(Selection, 0);
        }

        /// <summary>
        /// Spara textBox värdet för distrikt.
        /// </summary>
        private void textBoxDistrikt_TextChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex < 0) // Om listBox värdet är inte selectad(mindre än noll), återvänd och gör inte methoden.
                return;

            // Sätt nya text, om den inte är satt.
            if (Säljkår[listBox1.SelectedIndex].Distrikt != textBoxDistrikt.Text)
                Säljkår[listBox1.SelectedIndex].Distrikt = textBoxDistrikt.Text;
        }

        /// <summary>
        /// Gör så att bara siffror är tillåtna i textBox.
        /// Spara textBox värde för antal sålda artiklar.
        /// </summary>
        private void textBoxAntalSåldaArtiklar_TextChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex < 0) // Om listBox värdet är inte selectad(mindre än noll), återvänd och gör inte methoden.
                return;
            if (Säljkår[listBox1.SelectedIndex].Antal == 0 && textBoxAntalSåldaArtiklar.Text == "0") // Tillåt en nolla.
                return;

            textBoxAntalSåldaArtiklar.Text = new string(textBoxAntalSåldaArtiklar.Text.Where(c => char.IsDigit(c)).ToArray()) // Ta bort allt som är icke-numeriska.
                                                        .TrimStart('0'); // Ta bort ledande nollor

            if (textBoxAntalSåldaArtiklar.Text == "")
                Säljkår[listBox1.SelectedIndex].Antal = 0;
            else
                Säljkår[listBox1.SelectedIndex].Antal = Convert.ToInt32(textBoxAntalSåldaArtiklar.Text);
        }
    }
}
