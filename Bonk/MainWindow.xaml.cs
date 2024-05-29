using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.WindowsAPICodePack.Dialogs;

namespace Bonk
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //Private variable for instance of class Arena.
        private Arena arena;
        //Private array of gladiators. Used for passing gladiators to fight in the arena.
        private Gladiator[] fighters = new Gladiator[2];
        //Private string variable
        private string filename = string.Empty;
        /// <summary>
        /// Constructor for MainWindow.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            arena = new Arena(lstArena);
        }
        /// <summary>
        /// Method that updates graphical elements of MainWindow.
        /// </summary>
        public void UpdateGUI()
        {
            lstGladiators.Items.Clear();
            List<Gladiator> gladiatorList = arena.GetGladiatorList();

            for (int i = 0; i < gladiatorList.Count; i++)
            {
                Gladiator gladiator = gladiatorList[i];
                string name = gladiator.Name;
                string gladClass = gladiator.GetType().Name;
                int maxHitPoints = gladiator.MaxHealthPoints;
                int defenseScore = gladiator.DefenseScore;

                lstGladiators.Items.Add(new GladiatorListViewItem { Name = name, Class = gladClass, MaxHitPoints = maxHitPoints, DefenseScore = defenseScore, Index = i });
            }

            if (fighters[0] != null)
            {
                lblGladiator1.Content = fighters[0].Name;
            }
            if (fighters[1] != null)
            {
                lblGladiator2.Content = fighters[1].Name;
            }
        }
        /// <summary>
        /// Method that runs when button Create gladiator is clicked.
        /// Starts instance of GladiatorWindow and passes results method AddGladiator in class Arena.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCreateGladiator_Click(object sender, RoutedEventArgs e)
        {
            Gladiator gladiator;

            GladiatorWindow gladiatorWindow = new GladiatorWindow();
            gladiatorWindow.ShowDialog();

            bool? result = gladiatorWindow.DialogResult;

            if (result == true)
            {
                gladiator = gladiatorWindow.Gladiator; 
                arena.AddGladiator(gladiator);
                UpdateGUI();
            }

        }
        /// <summary>
        /// Method that runs when button Edit gladiator is clicked.
        /// Retrieves gladiator and passes it to an instance of GladiatorWindow.
        /// Passes result method EditGladiator in class Arena.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEditGladiator_Click(object sender, RoutedEventArgs e)
        {
            if (lstGladiators.SelectedIndex != -1)
            {
                GladiatorListViewItem item = (GladiatorListViewItem)lstGladiators.SelectedItems[0];
                int index = item.Index;
                Gladiator gladiator = arena.GetGladiator(index);

                GladiatorWindow gladiatorWindow = new GladiatorWindow(gladiator);
                gladiatorWindow.ShowDialog();

                bool? result = gladiatorWindow.DialogResult;

                if (result == true)
                {
                    gladiator = gladiatorWindow.Gladiator;
                    arena.EditGladiator(index, gladiator);
                    UpdateGUI();
                }
            }
        }
        /// <summary>
        /// Method that runs when button gladiator is clicked.
        /// Calls method DeleteGladiator in class Arena.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (lstGladiators.SelectedIndex != -1)
            {
                GladiatorListViewItem item = (GladiatorListViewItem)lstGladiators.SelectedItems[0];
                int index = item.Index;

                arena.DeleteGladiator(index);
                UpdateGUI();
            }
        }
        /// <summary>
        /// Method to select gladiators as fighters.
        /// Places selected gladiator at index point in array fighters.
        /// </summary>
        /// <param name="index">The goal index in array fighters.</param>
        /// <returns>Returns true if the selected gladiators are not duplicates.</returns>
        private bool SelectGladiator(int index)
        {
            bool valid = true;

            if (lstGladiators.SelectedIndex != -1)
            {
                GladiatorListViewItem item = (GladiatorListViewItem)lstGladiators.SelectedItems[0];
                int gladiatorIndex = item.Index;
                Gladiator gladiator = arena.GetGladiator(gladiatorIndex);

                if (fighters[index] != null) 
                { 
                    if (fighters[index] == gladiator)
                    {
                        valid = false;
                    }
                    else
                    {
                        fighters[index] = gladiator;
                        UpdateGUI();
                    }
                }
                if (fighters[index] == null)
                {
                    int otherIndex = Math.Abs(index - 1);

                    if (fighters[otherIndex] == gladiator)
                    {
                        valid = false;
                    }
                    else
                    {
                        fighters[index] = gladiator;
                        UpdateGUI();
                    }
                }

            }
            return valid;
        }
        /// <summary>
        /// Method that runs when Select Gladiator 1 is clicked. 
        /// Calls method SelectGladiator and displays error message if that method returns false.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSelectGladiator1_Click(object sender, RoutedEventArgs e)
        {
            bool valid = SelectGladiator(0);

            if (!valid)
            {
                MessageBox.Show("Gladiator 1 cannot be the same as gladiator 2.");
            }

        }
        /// <summary>
        /// Method that runs when Select Gladiator 2 is clicked. 
        /// Calls method SelectGladiator and displays error message if that method returns false.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSelectGladiator2_Click(object sender, RoutedEventArgs e)
        {
            bool valid = SelectGladiator(1);

            if (!valid)
            {
                MessageBox.Show("Gladiator 2 cannot be the same as gladiator 1.");
            }
        }
        /// <summary>
        /// Method that runs when button Start fight is clicked.
        /// Calls method Fight in class Arena.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStartFight_Click(object sender, RoutedEventArgs e)
        {
            arena.Fight(fighters);
        }
        /// <summary>
        /// Method that runs when menu item New is clicked.
        /// Clears the arena list, starts new instance of arena and updates GUI elements.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNew_Click(object sender, RoutedEventArgs e)
        {
            lstArena.Items.Clear();
            arena = new Arena(lstArena);
            filename = string.Empty;
            Array.Clear(fighters, 0, fighters.Length);
            lblGladiator1.Content = string.Empty;
            lblGladiator2.Content = string.Empty;
            UpdateGUI();
        }
        /// <summary>
        /// Method that runs when menu item Save is clicked.
        /// Starts dialog if no output file name is chosen, otherwise uses that filename to save data.
        /// Calls method SerializeGladiators in class Arena.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (filename == string.Empty)
            {
                CommonSaveFileDialog commonSaveFileDialog = new CommonSaveFileDialog();
                CommonFileDialogResult result = commonSaveFileDialog.ShowDialog();

                if (result == CommonFileDialogResult.Ok)
                {
                    filename = commonSaveFileDialog.FileName;
                    arena.SerializeGladiators(filename);
                }
            }
            else
            {
                arena.SerializeGladiators(filename);
            }
        }
        /// <summary>
        /// Method that runs when menu item Save as is clicked.
        /// Starts dialog to chose output filename.
        /// Calls method SerializeGladiators in class Arena.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSaveAs_Click(object sender, RoutedEventArgs e)
        {
            CommonSaveFileDialog commonSaveFileDialog = new CommonSaveFileDialog();
            CommonFileDialogResult result = commonSaveFileDialog.ShowDialog();

            if (result == CommonFileDialogResult.Ok)
            {
                filename = commonSaveFileDialog.FileName;
                arena.SerializeGladiators(filename);
            }
        }
        /// <summary>
        /// Method that runs when menu item Open is clicked.
        /// Opens file dialog to get path and filename.
        /// Passes it to method DeSerializeGladiators in class Arena.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOpen_Click(object sender, RoutedEventArgs e)
        {
            CommonOpenFileDialog commonOpenFileDialog = new CommonOpenFileDialog();
            CommonFileDialogResult result = commonOpenFileDialog.ShowDialog();

            if (result == CommonFileDialogResult.Ok)
            {
                filename = commonOpenFileDialog.FileName;
                arena.DeSerializeGladiators(filename);
                UpdateGUI();
            }
        }
        /// <summary>
        /// Method that runs when menu item Close is clicked. 
        /// Closes the application.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}