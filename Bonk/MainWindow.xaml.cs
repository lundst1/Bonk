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

namespace Bonk
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //Private variable for instance of class Arena.
        private Arena arena;
        private Gladiator[] fighters = new Gladiator[2];
        /// <summary>
        /// Constructor for MainWindow.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            arena = new Arena(lstArena);
        }
        public void UpdateGUI()
        {
            lstGladiators.Items.Clear();
            List<Gladiator> gladiatorList = arena.GetGladiatorList();

            for (int i = 0; i < gladiatorList.Count; i++)
            {
                Gladiator gladiator = gladiatorList[i];
                string name = gladiator.Name;
                string gladClass = gladiator.GetType().Name;

                lstGladiators.Items.Add(new GladiatorListViewItem { Name = name, Class = gladClass, Index = i });
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
        private bool SelectGladiator()
        {
            bool valid = true;

            if (lstGladiators.SelectedIndex != -1)
            {
                GladiatorListViewItem item = (GladiatorListViewItem)lstGladiators.SelectedItems[0];
                int index = item.Index;
                Gladiator gladiator = arena.GetGladiator(index);

                if (fighters[0] != null) 
                { 
                    if (fighters[0] == gladiator)
                    {
                        valid = false;
                    }
                    else
                    {
                        fighters[1] = gladiator;
                        UpdateGUI();
                    }
                }
                if (fighters[0] == null)
                {
                    fighters[0] = gladiator;
                    UpdateGUI();
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
            bool valid = SelectGladiator();

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
            bool valid = SelectGladiator();

            if (!valid)
            {
                MessageBox.Show("Gladiator 2 cannot be the same as gladiator 1.");
            }
        }

        private void btnStartFight_Click(object sender, RoutedEventArgs e)
        {
            arena.Fight(fighters);
        }
    }
}