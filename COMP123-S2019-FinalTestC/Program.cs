using COMP123_S2019_FinalTestC.Views;
using COMP123_S2019_FinalTestC.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
/*
* Student Name: Ederson Cardoso
* Student ID: 301033332
* Description: This is the program class for the application
*/
namespace COMP123_S2019_FinalTestC
{
    public static class Program
    {
        public static CharacterGenerationForm characterForm;
        public static CharacterPortfolio characterPortfolio;
        public static AboutForm aboutForm;
        public static SplashForm splashForm;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            characterForm = new CharacterGenerationForm();
            characterPortfolio = new CharacterPortfolio();
            aboutForm = new AboutForm();
            splashForm = new SplashForm();

            Application.Run(splashForm);
        }
    }
}
