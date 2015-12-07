using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
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
        ViewModelSLP viewmodelslp;

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

        //private void Home_Selection(object sender, RoutedEventArgs e)
        //{
        //    MainFrame.SelectedIndex = 0;
        //}
        //private void SLP_Selection(object sender, RoutedEventArgs e)
        //{
            
        //    MainFrame.SelectedIndex = 1;
        //    if (slp == null)
        //    {
        //        slp = new SLP();
        //        slp.Add(new InputNeuron());
        //        slp.Add(new InputNeuron());
        //        slp.Add(new OutputNeuron());
        //        slp.FullConnect();
        //        viewmodelslp = new ViewModelSLP(slp, SLP_Canvas);
        //    }
            
        //}

        //private void MLP_Selection(object sender, RoutedEventArgs e)
        //{
        //    //if (slp == null) slp = new SLP();
        //    MainFrame.SelectedIndex = 2;
        //}

        //private void SLP_Canvas_SizeChanged(object sender, SizeChangedEventArgs e)
        //{
        //    viewmodelslp.formatNet();
        //}
        private void Lektion_1_Untertitel_1_Click(object sender, RoutedEventArgs e)
        {
            if(!(sender is MenuItem)) Menu_Visability(true);
            MainFrame.SelectedIndex=1;
        }
        
        private void Menu_Visability(bool decision)
        {
            if (decision)
            {
                Menu_Lektion_1.Visibility = Visibility.Visible;
                Menu_Lektion_2.Visibility = Visibility.Visible;
                Menu_Lektion_3.Visibility = Visibility.Visible;
                Menu_Lektion_4.Visibility = Visibility.Visible;
                Menu_Lektion_5.Visibility = Visibility.Visible;
                Menu_Lektion_6.Visibility = Visibility.Visible;
            }
            else
            {
                Menu_Lektion_1.Visibility = Visibility.Hidden;
                Menu_Lektion_2.Visibility = Visibility.Hidden;
                Menu_Lektion_3.Visibility = Visibility.Hidden;
                Menu_Lektion_4.Visibility = Visibility.Hidden;
                Menu_Lektion_5.Visibility = Visibility.Hidden;
                Menu_Lektion_6.Visibility = Visibility.Hidden;
            }
            
        }

        private void tab_forward(object sender, RoutedEventArgs e)
        {
            MainFrame.SelectedIndex++;
        }

        private void Set_En_Lang(object sender, RoutedEventArgs e)
        {
            ChangeLanguage("en-US");
        }

        private void Set_De_Lang(object sender, RoutedEventArgs e)
        {
            ChangeLanguage("de-DE");
        }

        /// <summary>
        /// Sprache wechseln
        /// </summary>
        /// <param name="culture">specific culture</param>
        public void ChangeLanguage(string culture)
        {
            // Alle Woerterbuecher finden   
            List<ResourceDictionary> dictionaryList = new List<ResourceDictionary>();
            foreach (ResourceDictionary dictionary in
                           Application.Current.Resources.MergedDictionaries)
            {
                dictionaryList.Add(dictionary);
            }

            // Woerterbuch waehlen
            string requestedCulture = string.Format("Resources/CultResource.{0}.xaml", culture);
            ResourceDictionary resourceDictionary =
                    dictionaryList.FirstOrDefault(d => d.Source.OriginalString == requestedCulture);

            // Altes Woerterbuch loeschen und Neues hinzufuegen       
            if (resourceDictionary != null)
            {
                Application.Current.Resources.MergedDictionaries.Remove(resourceDictionary);
                Application.Current.Resources.MergedDictionaries.Add(resourceDictionary);
            }

            // Hauptthread ueber neues Culture informieren
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(culture);
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(culture);
        }
    }
}
