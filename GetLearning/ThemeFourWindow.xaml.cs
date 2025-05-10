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
    /// Interaction logic for ThemeFourWindow.xaml
    /// </summary>
    public partial class ThemeFourWindow : Window
    {
        public ThemeFourWindow()
        {
            InitializeComponent();

            this.DataContext = new ThemeFourViewModel();
        }
    }
}
