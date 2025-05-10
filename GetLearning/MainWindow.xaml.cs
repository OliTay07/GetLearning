using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GetLearning
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        // Event handler for theme one
        private void Btn_ThemeOne_Click(object sender, RoutedEventArgs e)
        {

            // Shows the ThemeOneWindow when the button is clicked
            ThemeOneWindow window = new ThemeOneWindow();
            window.Show();
        }

        // Event handler for theme two
        private void Btn_ThemeTwo_Click(object sender, RoutedEventArgs e)
        {
            // Shows the ThemeTwoWindow when the button is clicked
            ThemeTwoWindow window = new ThemeTwoWindow();
            window.Show();
        }

        // Event handler for theme three
        private void Btn_ThemeThree_Click(object sender, RoutedEventArgs e)
        {
            // Shows the ThemeThreeWindow when the button is clicked
            ThemeThreeWindow window = new ThemeThreeWindow();
            window.Show();
        }

        // Event handler for theme four
        private void Btn_ThemeFour_Click(object sender, RoutedEventArgs e)
        {
            // Shows the ThemeFourWindow when the button is clicked
            ThemeFourWindow window = new ThemeFourWindow();
            window.Show();
        }
    }
}
