/* Inlämningsuppgift 1 L0002B
 * Beräkna växel
 * Datorterminal
 * 2022-10-24
 */


namespace VäxelConsoleApplication
{
    /// <summary>
    /// Structure som inerhåller beräknad växel värde.
    /// </summary>
    public readonly struct Växel
    {
        // Konstruktor:
        public Växel(int femhundralappar, int tvåhundralappar, int hundralappar,
                     int tjugo, int tiokronor, int femkronor, int enkronor)
        {
            this.femhundralappar = femhundralappar;
            this.tvåhundralappar = tvåhundralappar;
            this.hundralappar = hundralappar;
            this.tjugo = tjugo;
            this.tiokronor = tiokronor;
            this.femkronor = femkronor;
            this.enkronor = enkronor;
        }

        // Medlemsvariabler:
        public readonly int femhundralappar;
        public readonly int tvåhundralappar;
        public readonly int hundralappar;
        public readonly int tjugo;
        public readonly int tiokronor;
        public readonly int femkronor;
        public readonly int enkronor;
    }

    /// <summary>
    /// Beräknar växel
    /// </summary>
    class VäxelBeräkna
    {
        /// <summary>
        /// Beräknar växel och återvänder växel struct som innehåller beräknad växel värden.
        /// </summary>
        /// <returns>Växel struct som inerhåller värderna för vardera sedlar och mynt</returns>
        [System.Diagnostics.DebuggerStepThrough]
        public static Växel BeräknaVäxel(long Pris, long Betalt)
        {
            // kontrollera värderna. Om fel, throw new exception.
            if (Pris < 0)
                throw new System.ArgumentOutOfRangeException($"Pris är mindre än 0.");
            if (Pris > Betalt)
                throw new System.ArgumentOutOfRangeException($"För lite betalt, behövs ytterligaren {Pris - Betalt} kr.");

            long VäxelSomKvarstår = Betalt;
            int AntalFemhundralappar = 0,
                AntalTvåhundralappar = 0,
                AntalHundralappar = 0,
                AntalTjugo = 0,
                AntalTiokronor = 0,
                AntalFemkronor = 0,
                AntalEnkronor = 0;

            // Beräkna växel, börja från hög växel till lägst växel.
            while (VäxelSomKvarstår - 500 >= Pris)
            {
                AntalFemhundralappar++;
                VäxelSomKvarstår -= 500;
            }

            while (VäxelSomKvarstår - 200 >= Pris)
            {
                AntalTvåhundralappar++;
                VäxelSomKvarstår -= 200;
            }

            while (VäxelSomKvarstår - 100 >= Pris)
            {
                AntalHundralappar++;
                VäxelSomKvarstår -= 100;
            }

            while (VäxelSomKvarstår - 20 >= Pris)
            {
                AntalTjugo++;
                VäxelSomKvarstår -= 20;
            }

            while (VäxelSomKvarstår - 10 >= Pris)
            {
                AntalTiokronor++;
                VäxelSomKvarstår -= 10;
            }

            while (VäxelSomKvarstår - 5 >= Pris)
            {
                AntalFemkronor++;
                VäxelSomKvarstår -= 5;
            }

            while (VäxelSomKvarstår - 1 >= Pris)
            {
                AntalEnkronor++;
                VäxelSomKvarstår -= 1;
            }

            return new Växel(AntalFemhundralappar, AntalTvåhundralappar, AntalHundralappar, // Återlämnar struct med beräknad växel värde
                             AntalTjugo, AntalTiokronor, AntalFemkronor, AntalEnkronor);
        }
    }
}
