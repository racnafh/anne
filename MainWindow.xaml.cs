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

        Schwellenwertelement swe;
        SchwellenwertelementVM SWEVM;
        List<SchwellenwertelementInput> AND_Daten;

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

        private void Uebung_1_Untertitel_1_Click(object sender, RoutedEventArgs e)
        {
            if (!(sender is MenuItem)) Menu_Visability(true);
            Uebung_1_Untertitel_1_Init();
            MainFrame.SelectedIndex = 6;
        }

        private void Uebung_1_Untertitel_1_Init()
        {
            AND_Daten = new List<SchwellenwertelementInput>();

            swe = new Schwellenwertelement();

            swe.Init();

            SWEVM = new SchwellenwertelementVM(swe);

            SWE_Canvas.DataContext = SWEVM;
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

            switch(MainFrame.SelectedIndex)
            {
                case 6: Uebung_1_Untertitel_1_Init();
                    break;
            }
        }

        private void tab_back(object sender, RoutedEventArgs e)
        {
            MainFrame.SelectedIndex--;

            switch (MainFrame.SelectedIndex)
            {
                case 6: Uebung_1_Untertitel_1_Init();
                    break;
            }
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

        private void Add_Schwellenwert_Input(object sender, RoutedEventArgs e)
        {
            double x1, x2, y;
            if (!double.TryParse(SWE_X1_Input.Text, out x1)) { MessageBox.Show("ungültige Eingabe"); return; }
            if (!double.TryParse(SWE_X2_Input.Text, out x2)) { MessageBox.Show("ungültige Eingabe"); return; }
            if (!double.TryParse(SWE_Y_Input.Text, out y)) { MessageBox.Show("ungültige Eingabe"); return; }
            AND_Input.Items.Add(new SchwellenwertelementInput(x1, x2, y));
            AND_Daten.Add(new SchwellenwertelementInput(x1, x2, y));
        }

        private void Schwellenwert_AND_Training(object sender, RoutedEventArgs e)
        {
            if (IsOnlineAND.IsChecked == true)
            {
                SWEVM.Online_Training(AND_Daten);               
            }
            else
            {

            }
        }

        private void Schwellenwert_AND_Clear(object sender, RoutedEventArgs e)
        {
            SWEVM.Clear();
        }

    }
}
