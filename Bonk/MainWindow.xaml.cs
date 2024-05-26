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
                //int index = item.Index;
                Gladiator gladiator = arena.GetGladiator(item.Index);

                GladiatorWindow gladiatorWindow = new GladiatorWindow();
                gladiatorWindow.ShowDialog();

                bool? result = gladiatorWindow.DialogResult;

                if (result == true)
                {
                    gladiator = gladiatorWindow.Gladiator;
                    arena.AddGladiator(gladiator);
                }
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}