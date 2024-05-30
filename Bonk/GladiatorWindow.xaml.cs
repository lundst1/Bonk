using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Bonk.Enums;
using Bonk.Gladiators;
using Newtonsoft.Json;

namespace Bonk
{
    /// <summary>
    /// Interaction logic for GladiatorWindow.xaml
    /// </summary>
    public partial class GladiatorWindow : Window
    {
        //Private integer variable for remaining ability scores.
        private int remainingScore = 20;
        //Private nullable integer for the gladiators strength score.
        [JsonIgnore]
        private int? strengthScore = null;
        //Private nullable integer for the gladiators agility score.
        private int? agilityScore = null;
        //Private nullable integer for the gladiators intelligence score.
        private int? intelligenceScore = null;
        //Private nullable integer for the gladiators constitution score.
        private int? constitutionScore = null;
        //Private variable for instance of class Gladiator.
        private Gladiator gladiator;
        private bool ignoreEvent = false;
        /// <summary>
        /// Public property for private variable gladiator.
        /// Read access.
        /// </summary>
        public Gladiator Gladiator
        {
            get { return gladiator; }
        }
        /// <summary>
        /// Constructor for GladiatorWindow.
        /// </summary>
        public GladiatorWindow()
        {
            InitializeComponent();
            InitializeGUI();
        }
        /// <summary>
        /// Constructor for GladiatorWindow.
        /// Takes one intance of class gladiator as argument and shows its information in the window.
        /// </summary>
        /// <param name="gladiator"></param>
        public GladiatorWindow(Gladiator gladiator) : this()
        {
            txtName.Text = gladiator.Name;

            int strength = gladiator.Strength;
            int agility = gladiator.Agility;
            int intelligence = gladiator.Intelligence;
            int constitution = gladiator.Constitution;

            strengthScore = strength;
            agilityScore = agility;
            intelligenceScore = intelligence;
            constitutionScore = constitution;

            ignoreEvent = true;
            upDownStrength.Value = strength;
            upDownAgility.Value = agility;
            upDownIntelligence.Value = intelligence;
            upDownConstitution.Value = constitution;
            ignoreEvent = false;

            remainingScore = remainingScore - strength - agility - intelligence - constitution;
            lblRemainingAbilityScoreValue.Content = remainingScore.ToString();

            if (gladiator.GetType() == typeof(Mage))
            {
                cBoxClass.SelectedItem = Classes.Mage;
            }
            if (gladiator.GetType() == typeof(Rouge))
            {
                cBoxClass.SelectedItem = Classes.Rouge;
            }
            if (gladiator.GetType() == typeof(Warrior))
            {
                cBoxClass.SelectedItem = Classes.Warrior;
            }
        } 
        /// <summary>
        /// Method to initialize GUI elements.
        /// </summary>
        private void InitializeGUI()
        {
            lblRemainingAbilityScoreValue.Content = remainingScore.ToString();
            cBoxClass.ItemsSource = Enum.GetValues(typeof(Classes)).Cast<Classes>();
            cBoxClass.SelectedIndex = 0;
            upDownStrength.Value = 0;
            upDownAgility.Value = 0;
            upDownIntelligence.Value = 0;
            upDownConstitution.Value = 0;
        }
        /// <summary>
        /// Method that updates how many remaining scorepoints exist.
        /// Calculates new remaining score and checks that it is not below 0 before setting it.
        /// </summary>
        /// <param name="value">The value that changes remaining score points.</param>
        /// <returns>Returns true if remaining scorepoints is 0 or greater.</returns>
        private bool UpdateRemainingScores(int value)
        {
            bool validRemainingScores = true;

            int newScore = remainingScore - value;
            
            if (newScore < 0)
            {
                validRemainingScores = false;
            }
            else
            {
                remainingScore = newScore;
                lblRemainingAbilityScoreValue.Content = remainingScore.ToString();
            }
            return (validRemainingScores);
        }
        /// <summary>
        /// Method that calculates difference between to nullable integers.
        /// </summary>
        /// <param name="value1">The first nullable integer.</param>
        /// <param name="value2">The second nullable integer.</param>
        /// <returns>Returns the difference between two nullable integers as a non nullable integer.</returns>
        private int CalculateDifference(int? value1, int? value2)
        {
            return ((value1 ?? default(int)) - (value2 ?? default(int)));
        }
        /// <summary>
        /// Method that handles the event that the control upDownStrength has its value changed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void upDownStrength_ValueChanged(object sender, EventArgs e)
        {
            if (!ignoreEvent)
            {
                int difference = CalculateDifference(upDownStrength.Value, strengthScore);
                bool validRemainingScore = UpdateRemainingScores(difference);

                if (validRemainingScore)
                {
                    strengthScore = upDownStrength.Value;
                }
                else
                {
                    upDownStrength.Value = strengthScore;
                }
            }
        }
        /// <summary>
        /// Method that handles the event that the control upDownAgility has its value changed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void upDownAgility_ValueChanged(object sender, EventArgs e)
        {
            int difference = CalculateDifference(upDownAgility.Value, agilityScore);
            bool validRemainingScore = UpdateRemainingScores(difference);

            if (validRemainingScore)
            {
                agilityScore = upDownAgility.Value;
            }
            else
            {
                upDownAgility.Value = agilityScore;
            }
        }
        /// <summary>
        /// Method that handles the event that the control upDownIntelligence has its value changed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void upDownIntelligence_ValueChanged(object sender, EventArgs e)
        {
            int difference = CalculateDifference(upDownIntelligence.Value, intelligenceScore);
            bool validRemainingScore = UpdateRemainingScores(difference);

            if (validRemainingScore)
            {
                intelligenceScore = upDownIntelligence.Value;
            }
            else
            {
                upDownIntelligence.Value = intelligenceScore;
            }

        }
        /// <summary>
        /// Method that handles the event that the control upDownConstitution has its value changed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void upDownConstitution_ValueChanged(object sender, EventArgs e)
        {
            int difference = CalculateDifference(upDownConstitution.Value, constitutionScore);
            bool validRemainingScore = UpdateRemainingScores(difference);

            if (validRemainingScore)
            {
                constitutionScore = upDownConstitution.Value;
            }
            else
            {
                upDownConstitution.Value = constitutionScore;
            }
        }
        /// <summary>
        /// Method to validate ability scores.
        /// Checks that the score, which is a nullable int is not null.
        /// </summary>
        /// <param name="nullableScore"></param>
        /// <param name="score"></param>
        /// <returns></returns>
        private bool validateAbilityScore(int? nullableScore, out int score)
        {
            bool valid = false;
            if (nullableScore.HasValue)
            {
                score = nullableScore.Value;
                valid = true;
            }
            else
            {
                score = 0;
            }
            return valid;
        }
        /// <summary>
        /// Method that runs when the button Save is clicked.
        /// Validates ability score and other data.
        /// Creates an instance of class Gladiator.
        /// Closes the window.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            bool valid = true;
            bool scoresValid = true;

            string name = txtName.Text;

            scoresValid = validateAbilityScore(strengthScore, out int strength);
            scoresValid = validateAbilityScore(agilityScore, out int agility);
            scoresValid = validateAbilityScore(intelligenceScore, out int intelligence);
            scoresValid = validateAbilityScore(constitutionScore, out int constitution);

            bool validClass = Enum.TryParse(cBoxClass.SelectedItem.ToString(), out Classes gladiatorClass);

            if (name == String.Empty)
            {
                MessageBox.Show("Please enter a name for the gladiator.");
                valid = false;
            }
            if (!scoresValid)
            {
                MessageBox.Show("Please fill in a value for all scores.");
                valid = false;
            }
            if (!validClass)
            {
                MessageBox.Show("Semething went wrong. Please reselect class");
            }
            if (valid)
            {
                if (gladiatorClass == Classes.Mage)
                {
                    gladiator = new Mage(name, strength, agility, intelligence, constitution);
                }
                if (gladiatorClass == Classes.Rouge)
                {
                    gladiator = new Rouge(name, strength, agility, intelligence, constitution);
                }
                if (gladiatorClass == Classes.Warrior)
                {
                    gladiator = new Warrior(name, strength, agility, intelligence, constitution);
                }

                this.DialogResult = true;
                this.Close();
            } 
        }
        /// <summary>
        /// Method that runs when button Cancel is clicked.
        /// Closes the window.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }
    }
}
