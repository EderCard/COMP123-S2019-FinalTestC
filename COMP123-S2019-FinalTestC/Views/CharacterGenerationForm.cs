using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Linq;
/*
* Student Name: Ederson Cardoso
* Student ID: 301033332
* Description: This is the main Form for the application
*/
namespace COMP123_S2019_FinalTestC.Views
{
    public partial class CharacterGenerationForm : COMP123_S2019_FinalTestC.Views.MasterForm
    {
        Random randon = new Random();
        public CharacterGenerationForm()
        {
            InitializeComponent();
        }
        /// <summary>
        /// This is the event handler for the Back Button clik event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BackButton_Click(object sender, EventArgs e)
        {
            if (MainTabControl.SelectedIndex != 0)
            {
                MainTabControl.SelectedIndex--;
            }
        }
        /// <summary>
        /// This is the event handler for the Next Button clik event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NextButton_Click(object sender, EventArgs e)
        {
            if (MainTabControl.SelectedIndex < MainTabControl.TabPages.Count -1)
            {
                MainTabControl.SelectedIndex++;
            }
        }
        /// <summary>
        /// This is the event handler for the ExitToolStripMenuItem click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        /// <summary>
        /// This is the shared event handler for the AboutToolStripMenuItem and helpToolStripButton click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Program.aboutForm.ShowDialog();
        }
        /// <summary>
        /// This is the shared event handler for the OpenToolStripMenuItem and openMenuStripButton click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog();
        }
        public void OpenFileDialog()
        {
            //Configure the file dialog
            CharacterSheetOpenFileDialog.FileName = "Character";
            CharacterSheetOpenFileDialog.InitialDirectory = Directory.GetCurrentDirectory();
            CharacterSheetOpenFileDialog.Filter = "Text documents (*.txt)|*.txt| All Files(*.*)|*.*";
            CharacterSheetOpenFileDialog.DefaultExt = ".txt";

            //Open file dialog
            var _result = CharacterSheetOpenFileDialog.ShowDialog();
            if (_result != DialogResult.Cancel)
            {
                try
                {
                    using (StreamReader inputStream = new StreamReader(
                        File.Open(CharacterSheetOpenFileDialog.FileName, FileMode.Open)))
                    {
                        //Read stuff from the file into the Product object
                        Program.characterPortfolio.Identity.FirstName = inputStream.ReadLine();
                        Program.characterPortfolio.Identity.LastName = inputStream.ReadLine();

                        Program.characterPortfolio.Strength = inputStream.ReadLine();
                        Program.characterPortfolio.Dexterity = inputStream.ReadLine();
                        Program.characterPortfolio.Endurance = inputStream.ReadLine();
                        Program.characterPortfolio.Intellect = inputStream.ReadLine();
                        Program.characterPortfolio.Education = inputStream.ReadLine();
                        Program.characterPortfolio.SocialStanding = inputStream.ReadLine();

                        //Cleanup
                        inputStream.Close();
                        inputStream.Dispose();
                    }
                }
                catch (Exception exception)
                {
                    MessageBox.Show("Error " + exception.Message, "ERROR",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            //Fill up form fields with character information from file
            //Identity
            FirstNameDataLabel.Text = Program.characterPortfolio.Identity.FirstName;
            LastNameDataLabel.Text = Program.characterPortfolio.Identity.LastName;

            //Characteristics
            StrengthDataLabel.Text = Program.characterPortfolio.Strength;
            DexterityDataLabel.Text = Program.characterPortfolio.Dexterity;
            EnduranceDataLabel.Text = Program.characterPortfolio.Endurance;
            IntellectDataLabel.Text = Program.characterPortfolio.Intellect;
            EducationDataLabel.Text = Program.characterPortfolio.Education;
            SocialStandingDataLabel.Text = Program.characterPortfolio.SocialStanding;
        }
        /// <summary>
        /// This is the shared event handler for the SaveToolStripMenuItem and saveMenuStripButton click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Configure the file dialog
            CharacterSheetSaveFileDialog.FileName = "Character";
            CharacterSheetSaveFileDialog.InitialDirectory = Directory.GetCurrentDirectory();
            CharacterSheetSaveFileDialog.Filter = "Text documents (*.txt)|*.txt| All Files(*.*)|*.*";
            CharacterSheetSaveFileDialog.DefaultExt = ".txt";

            //Open file dialog
            var _result = CharacterSheetSaveFileDialog.ShowDialog();
            if (_result != DialogResult.Cancel)
            {
                try
                {
                    //Open stream to write
                    using (StreamWriter outputStream = new StreamWriter(
                        File.Open(CharacterSheetSaveFileDialog.FileName, FileMode.Create)))
                    {
                        //Write stuff to the file
                        outputStream.WriteLine(Program.characterPortfolio.Identity.FirstName);
                        outputStream.WriteLine(Program.characterPortfolio.Identity.LastName);

                        outputStream.WriteLine(Program.characterPortfolio.Strength);
                        outputStream.WriteLine(Program.characterPortfolio.Dexterity);
                        outputStream.WriteLine(Program.characterPortfolio.Endurance);
                        outputStream.WriteLine(Program.characterPortfolio.Intellect);
                        outputStream.WriteLine(Program.characterPortfolio.Education);
                        outputStream.WriteLine(Program.characterPortfolio.SocialStanding);

                        //Cleanup
                        outputStream.Close();
                        outputStream.Dispose();
                    }
                }
                catch (Exception exception)
                {
                    MessageBox.Show("ERROR: " + exception.Message, "ERROR",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                MessageBox.Show("File saved successfully!", "Saving...",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// This is the event handler for the GenerateNameButton click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GenerateNameButton_Click(object sender, EventArgs e)
        {
            //Get files
            string _firstNameFile = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), @"..\..\Data\firstNames.txt"));
            string _lastNameFile = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), @"..\..\Data\lastNames.txt"));

            //Fillup Character First Name and FirstNameDataLabel
            Program.characterPortfolio.Identity.FirstName = GetRandomItemFromFileList(_firstNameFile);
            FirstNameDataLabel.Text = Program.characterPortfolio.Identity.FirstName;

            //Fillup Character Last Name and LastNameDataLabel
            Program.characterPortfolio.Identity.LastName = GetRandomItemFromFileList(_lastNameFile);
            LastNameDataLabel.Text = Program.characterPortfolio.Identity.LastName;
        }
        /// <summary>
        /// This method returns a random item (line) from a file list
        /// </summary>
        /// <param name="_fileName"></param>
        /// <returns></returns>
        private string GetRandomItemFromFileList(string _fileName)
        {
            //Populate a list with file content
            List<string> _listFromFile = File.ReadAllLines(_fileName).ToList();

            //Get number of list items
            int _listLength = _listFromFile.Count;

            //Populate _result with a random item from list
            string _result = _listFromFile[randon.Next(_listLength)];

            return _result; 
        }
        /// <summary>
        /// This is the event handler for the GenerateAbilitiesButton click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GenerateAbilitiesButton_Click(object sender, EventArgs e)
        {
            //Start all abilities with zero
            Program.characterPortfolio.Strength = "0";
            Program.characterPortfolio.Dexterity = "0";
            Program.characterPortfolio.Endurance = "0";
            Program.characterPortfolio.Intellect = "0";
            Program.characterPortfolio.Education = "0";
            Program.characterPortfolio.SocialStanding = "0";

            StrengthDataLabel.Text = Program.characterPortfolio.Strength;
            DexterityDataLabel.Text = Program.characterPortfolio.Dexterity;
            EnduranceDataLabel.Text = Program.characterPortfolio.Endurance;
            IntellectDataLabel.Text = Program.characterPortfolio.Intellect;
            EducationDataLabel.Text = Program.characterPortfolio.Education;
            SocialStandingDataLabel.Text = Program.characterPortfolio.SocialStanding;

            //Define max points to abilities
            int _maxAbilitesPoints = 14;

            int _totalPoints = 0;

            //Distribute abilities
            while (_totalPoints <= _maxAbilitesPoints)
            {
                int _ability = randon.Next(1, 7);

                if (_ability == 1)
                {
                    Program.characterPortfolio.Strength = (Int32.Parse(Program.characterPortfolio.Strength) + 1).ToString(); 
                    StrengthDataLabel.Text = Program.characterPortfolio.Strength;
                    _totalPoints += Int32.Parse(Program.characterPortfolio.Strength);
                }
                else if (_ability == 2)
                {
                    Program.characterPortfolio.Dexterity = (Int32.Parse(Program.characterPortfolio.Dexterity) + 1).ToString();
                    DexterityDataLabel.Text = Program.characterPortfolio.Dexterity;
                    _totalPoints += Int32.Parse(Program.characterPortfolio.Dexterity);
                }
                else if (_ability == 3)
                {
                    Program.characterPortfolio.Endurance = (Int32.Parse(Program.characterPortfolio.Endurance) + 1).ToString();
                    EnduranceDataLabel.Text = Program.characterPortfolio.Endurance;
                    _totalPoints += Int32.Parse(Program.characterPortfolio.Endurance);
                }
                else if (_ability == 4)
                {
                    Program.characterPortfolio.Intellect = (Int32.Parse(Program.characterPortfolio.Intellect) + 1).ToString();
                    IntellectDataLabel.Text = Program.characterPortfolio.Intellect;
                    _totalPoints += Int32.Parse(Program.characterPortfolio.Intellect);
                }
                else if (_ability == 5)
                {
                    Program.characterPortfolio.Education = (Int32.Parse(Program.characterPortfolio.Education) + 1).ToString();
                    EducationDataLabel.Text = Program.characterPortfolio.Education;
                    _totalPoints += Int32.Parse(Program.characterPortfolio.Education);
                }
                else if (_ability == 6)
                {
                    Program.characterPortfolio.SocialStanding = (Int32.Parse(Program.characterPortfolio.SocialStanding) + 1).ToString();
                    SocialStandingDataLabel.Text = Program.characterPortfolio.SocialStanding;
                    _totalPoints += Int32.Parse(Program.characterPortfolio.SocialStanding);
                }
            }
        }
        /// <summary>
        /// This is the event handler for the CharacterGenerationForm closing event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CharacterGenerationForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
