using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
 * Student Name: Ederson Cardoso
 * Student ID: 301033332
 * Description: This is the main container class for the application
 */
namespace COMP123_S2019_FinalTestC.Objects
{
    public class CharacterPortfolio
    {
        // Identity
        public Identity Identity { get; set; }

        // Characteristicis
        public string Strength { get; set; }
        public string Dexterity { get; set; }
        public string Endurance { get; set; }
        public string Intellect { get; set; }
        public string Education { get; set; }
        public string SocialStanding { get; set; }

        // Skill List
        List<Skill> Skills;

        // Constructor
        CharacterPortfolio()
        {
            Skills = new List<Skill>();
            this.Identity = new Identity();
        }

    }
}
