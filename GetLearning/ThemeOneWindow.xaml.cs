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
using System.Windows.Shapes;

namespace GetLearning
{
    /// <summary>
    /// Interaction logic for ThemeOneWindow.xaml
    /// </summary>
    public partial class ThemeOneWindow : Window
    {
        public ThemeOneWindow()
        {
            InitializeComponent();
            
            this.DataContext = new ThemeOneViewModel();
        }
    }
}
