using System;
using System.Collections.Generic;
using System.Linq;
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

namespace Bonk
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class GladiatorWindow : Window
    {
        //Private integer variable for remaining ability scores.
        private int remainingScore = 20;
        private int? strengthScore = null;
        private int? agilityScore = null;
        private int? intelligenceScore = null;
        private int? constitutionScore = null;
        //Private variable for instance of class Gladiator.
        private Gladiator gladiator;
        /// <summary>
        /// Public property for private variable gladiator.
        /// Read access.
        /// </summary>
        public Gladiator Gladiator
        {
            get { return gladiator; }
        }

        public GladiatorWindow()
        {
            InitializeComponent();
            InitializeGUI();
        }
        private void InitializeGUI()
        {
            lblRemainingAbilityScoreValue.Content = remainingScore.ToString();
        }
        private bool UpdateRemainingScores(int value)
        {
            bool validRemainingScores = true;

            remainingScore -= value;
            
            if (remainingScore < 0)
            {
                validRemainingScores = false;
            }
            else
            {
                lblRemainingAbilityScoreValue.Content = remainingScore.ToString();
            }
            return (validRemainingScores);
        }
        private int CalculateDifference(int? value1, int? value2)
        {
            return ((value1 ?? default(int)) - (value2 ?? default(int)));
        }
        private void upDownStrength_ValueChanged(object sender, EventArgs e)
        {
            int difference = CalculateDifference(upDownStrength.Value, strengthScore);
            strengthScore = upDownStrength.Value;
            UpdateRemainingScores(difference); //TODO check that update is valid
        }
        private void upDownAgility_ValueChanged(object sender, EventArgs e)
        {
            int difference = CalculateDifference(upDownAgility.Value, agilityScore);
            agilityScore = upDownAgility.Value;
            UpdateRemainingScores(difference);
        }
        private void upDownIntelligence_ValueChanged(object sender, EventArgs e)
        {
            int difference = CalculateDifference(upDownIntelligence.Value, intelligenceScore);
            intelligenceScore = upDownIntelligence.Value;
            UpdateRemainingScores(difference);
        }
        private void upDownConstitution_ValueChanged(object sender, EventArgs e)
        {
            int difference = CalculateDifference(upDownConstitution.Value, constitutionScore);
            constitutionScore = upDownConstitution.Value;
            UpdateRemainingScores(difference);
        }
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
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            string name = txtName.Text;

            bool scoresValid = true;
            scoresValid = validateAbilityScore(strengthScore, out int strength);
            scoresValid = validateAbilityScore(agilityScore, out int agility);
            scoresValid = validateAbilityScore(intelligenceScore, out int intelligence);
            scoresValid = validateAbilityScore(constitutionScore, out int constitution);

            if (scoresValid)
            {
                this.DialogResult = true;
                this.Close();
            }
            else
            {
                MessageBox.Show("Please fill in a value for all scores");
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
