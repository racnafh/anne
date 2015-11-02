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

namespace anne
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SLP slp;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Minimize_Button_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void CloseCommandHandler(object sender, ExecutedRoutedEventArgs e)
        {
            this.Close();
        }

        private void Home_Selection(object sender, RoutedEventArgs e)
        {
            MainFrame.SelectedIndex = 0;
        }
        private void SLP_Selection(object sender, RoutedEventArgs e)
        {
            
            MainFrame.SelectedIndex = 1;
            if (slp == null)
            {
                slp = new SLP();
                slp.drawNet(SLP_Canvas);
            }
            
        }

        private void MLP_Selection(object sender, RoutedEventArgs e)
        {
            //if (slp == null) slp = new SLP();
            MainFrame.SelectedIndex = 2;
        }

        private void SLP_Canvas_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            slp.formatNet(SLP_Canvas);
        }
    }
}
