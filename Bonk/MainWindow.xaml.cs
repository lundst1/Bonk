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
            }

        }
        private void btnEditGladiator_Click(object sender, RoutedEventArgs e)
        {
            int index = lstGladiators.SelectedIndex;
            if (index != -1)
            {
                Gladiator gladiator = arena.GetGladiator(index);

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