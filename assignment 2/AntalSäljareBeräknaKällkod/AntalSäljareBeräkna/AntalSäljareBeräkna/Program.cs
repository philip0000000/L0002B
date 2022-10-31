/* Inlämningsuppgift 2 L0002B
 * Antal säljare ordna
 * Grafiskt användargränssnitt
 * 2022-10-24
 */


using System;
using System.Windows.Forms;

namespace AntalSäljareBeräkna
{
    /// <summary>
    /// Klass som har information om säljare.
    /// </summary>
    class Säljare
    {
        // Medlemsvariabler:
        public string Namn;
        public string Persnr;
        public string Distrikt;
        public int Antal;

        // Konstruktor:
        public Säljare(string Namn, string Persnr, string Distrikt, int Antal)
        {
            this.Namn = Namn;
            this.Persnr = Persnr;
            this.Distrikt = Distrikt;
            this.Antal = Antal;
        }
    }

    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
