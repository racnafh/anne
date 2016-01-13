using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        ObservableCollection<SchwellenwertelementInput> Uebung_1_Daten;

        int Uebung_1_SubIndex;
        bool MenuVisibility;

        public MainWindow()
        {
            InitializeComponent();
            Uebung_1_SubIndex = 0;
            MenuVisibility = false;
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
            if (!MenuVisibility) MenuVisibility = Menu_Visibility(!MenuVisibility);
            MainFrame.SelectedIndex=1;
        }

        private void Uebung_1_Untertitel_1_Click(object sender, RoutedEventArgs e)
        {
            if (!MenuVisibility) MenuVisibility = Menu_Visibility(!MenuVisibility);
            Uebung_1_Untertitel_1_Init();
            MainFrame.SelectedIndex = 6;
        }

        private void Uebung_1_Untertitel_1_Init()
        {
            Uebung_1_Daten = new ObservableCollection<SchwellenwertelementInput>();

            Uebung_1_Input.ItemsSource = Uebung_1_Daten;

            swe = new Schwellenwertelement();

            swe.Init();

            SWEVM = new SchwellenwertelementVM(swe);

            SWEVM.ClearEvent += ClearEvent;

            SWEVM.FirstLineEvent += FirstLineEvent;

            SWEVM.SecondLineEvent += SecondLineEvent;

            SWEVM.ThirdLineEventTrue += ThirdLineEventTrue;

            SWEVM.ThirdLineEventFalse += ThirdLineEventFalse;

            SWEVM.FourthLineEvent += FourthLineEvent;

            SWEVM.FourthLineBatchEvent += FourthLineBatchEvent;

            SWEVM.BatchEvent += BatchEvent;

            SWEVM.ResetEvent += ResetEvent;

            SWE_Canvas.DataContext = SWEVM;
        }

        private void Uebung_1_Untertitel_1_Release()
        {
            //Garbage Collector wird gerufen - bei arbeitslosigkeit der Anwendung....
            Uebung_1_Daten = null;
            swe = null;
            SWEVM = null;
        }
        
        private bool Menu_Visibility(bool decision)
        {
            if (decision)
            {
                Menu_Lektion_1.Visibility = Visibility.Visible;
                Menu_Lektion_2.Visibility = Visibility.Visible;
                Menu_Lektion_3.Visibility = Visibility.Visible;
                Menu_Lektion_4.Visibility = Visibility.Visible;
                Menu_Lektion_5.Visibility = Visibility.Visible;
                Menu_Lektion_6.Visibility = Visibility.Visible;
                Home_Menu.Visibility = Visibility.Visible;
            }
            else
            {
                Menu_Lektion_1.Visibility = Visibility.Hidden;
                Menu_Lektion_2.Visibility = Visibility.Hidden;
                Menu_Lektion_3.Visibility = Visibility.Hidden;
                Menu_Lektion_4.Visibility = Visibility.Hidden;
                Menu_Lektion_5.Visibility = Visibility.Hidden;
                Menu_Lektion_6.Visibility = Visibility.Hidden;
                Home_Menu.Visibility = Visibility.Hidden;
            }
            return !decision;
        }

        private void tab_forward(object sender, RoutedEventArgs e)
        {
            switch(MainFrame.SelectedIndex)
            {
                case 5: MainFrame.SelectedIndex++;
                        Uebung_1_Untertitel_1_Init();
                        Uebung_1_Aufgabe.Content = FindResource("Uebung_1_Untertitel_1_Aufgabe");
                        Uebung_1_Aufgabe_Detail.Content = FindResource("Uebung_1_Untertitel_1_Aufgabe_Detail");
                        Uebung_1_back.Content = FindResource("Lektion_1_Untertitel_3_3");
                        Uebung_1_label.Content = FindResource("Uebung_1_Untertitel_1");
                        Uebung_1_forward.Content = FindResource("Uebung_1_Untertitel_2");
                        Uebung_1_Add_Button.Click += new RoutedEventHandler(Add_Schwellenwert_Std_AND_Input);
                        Uebung_1_SubIndex++;
                    break;
                case 6: if (Uebung_1_SubIndex == 1)
                        {
                            Uebung_1_Untertitel_1_Init();
                            Uebung_1_Aufgabe.Content = FindResource("Uebung_1_Untertitel_2_Aufgabe");
                            Uebung_1_Aufgabe_Detail.Content = FindResource("Uebung_1_Untertitel_2_Aufgabe_Detail");
                            Uebung_1_back.Content = FindResource("Uebung_1_Untertitel_1");
                            Uebung_1_label.Content = FindResource("Uebung_1_Untertitel_2");
                            Uebung_1_forward.Content = FindResource("Extra_1_Untertitel_1");
                            Uebung_1_Add_Button.Click -= Add_Schwellenwert_Std_AND_Input;
                            Uebung_1_Add_Button.Click += new RoutedEventHandler(Add_Schwellenwert_Std_OR_Input);
                            Uebung_1_SubIndex++;
                        }
                        else
                        {
                            MainFrame.SelectedIndex++;
                            Uebung_1_Untertitel_1_Release();
                            Uebung_1_SubIndex = 0;
                        }
                    break;
                default: MainFrame.SelectedIndex++;
                    break;

            }
        }

        private void tab_back(object sender, RoutedEventArgs e)
        {
            switch (MainFrame.SelectedIndex)
            {
                case 6: if (Uebung_1_SubIndex == 2)
                        {
                            Uebung_1_Untertitel_1_Init();
                            Uebung_1_Aufgabe.Content = FindResource("Uebung_1_Untertitel_1_Aufgabe");
                            Uebung_1_Aufgabe_Detail.Content = FindResource("Uebung_1_Untertitel_1_Aufgabe_Detail");
                            Uebung_1_back.Content = FindResource("Lektion_1_Untertitel_3_3");
                            Uebung_1_label.Content = FindResource("Uebung_1_Untertitel_1");
                            Uebung_1_forward.Content = FindResource("Uebung_1_Untertitel_2");
                            Uebung_1_Add_Button.Click -= Add_Schwellenwert_Std_OR_Input;
                            Uebung_1_Add_Button.Click += new RoutedEventHandler(Add_Schwellenwert_Std_AND_Input);
                            Uebung_1_SubIndex--;
                        }
                        else
                        {
                            MainFrame.SelectedIndex--;
                            Uebung_1_Untertitel_1_Release();
                            Uebung_1_SubIndex = 0;
                        }
                    break;
                case 7: MainFrame.SelectedIndex--;
                        Uebung_1_Untertitel_1_Init();
                        Uebung_1_Aufgabe.Content = FindResource("Uebung_1_Untertitel_2_Aufgabe");
                        Uebung_1_Aufgabe_Detail.Content = FindResource("Uebung_1_Untertitel_2_Aufgabe_Detail");
                        Uebung_1_back.Content = FindResource("Uebung_1_Untertitel_1");
                        Uebung_1_label.Content = FindResource("Uebung_1_Untertitel_2");
                        Uebung_1_forward.Content = FindResource("Extra_1_Untertitel_1");
                        Uebung_1_Add_Button.Click += new RoutedEventHandler(Add_Schwellenwert_Std_OR_Input);
                        Uebung_1_SubIndex=2;
                    break;
                default: MainFrame.SelectedIndex--;
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
            Uebung_1_Daten.Add(new SchwellenwertelementInput(x1, x2, y));
        }

        private void Add_Schwellenwert_Std_AND_Input(object sender, RoutedEventArgs e)
        {
            Uebung_1_Daten.Add(new SchwellenwertelementInput(0.0, 0.0, 0.0));
            Uebung_1_Daten.Add(new SchwellenwertelementInput(1.0, 0.0, 0.0));
            Uebung_1_Daten.Add(new SchwellenwertelementInput(0.0, 1.0, 0.0));
            Uebung_1_Daten.Add(new SchwellenwertelementInput(1.0, 1.0, 1.0));
        }

        private void Add_Schwellenwert_Std_OR_Input(object sender, RoutedEventArgs e)
        {
            Uebung_1_Daten.Add(new SchwellenwertelementInput(0.0, 0.0, 0.0));
            Uebung_1_Daten.Add(new SchwellenwertelementInput(1.0, 0.0, 1.0));
            Uebung_1_Daten.Add(new SchwellenwertelementInput(0.0, 1.0, 1.0));
            Uebung_1_Daten.Add(new SchwellenwertelementInput(1.0, 1.0, 1.0));
        }

        private void Schwellenwert_Training(object sender, RoutedEventArgs e)
        {
            if (IsOnline.IsChecked == true)
            {
                SWEVM.ErrorMax = 0.0;
                Change_Line.Visibility = Visibility.Visible;
                SWEVM.Online_Training(Uebung_1_Daten);               
            }
            else
            {
                SWEVM.ErrorMax = 0.0;
                Delta_Line.Visibility = Visibility.Visible;
                SWEVM.Batch_Training(Uebung_1_Daten);
            }
        }

        private void Schwellenwert_Clear(object sender, RoutedEventArgs e)
        {
            SWEVM.Clear();
        }

        private void ClearEvent(Object sender, EventArgs e)
        {
            Input_X1_Line.Visibility = Visibility.Hidden;
            Input_X2_Line.Visibility = Visibility.Hidden;
            Input_Y_Line.Visibility = Visibility.Hidden;
            Entscheidung.Background = null;
            Entscheidung.Content=String.Empty;
            W1_Line.Background = null;
            W2_Line.Background = null;
            Mainball.Fill = new SolidColorBrush(Colors.Blue);
            fourthsball.Visibility = Visibility.Hidden;
            fifthsball.Visibility = Visibility.Hidden;
            firstball.Visibility = Visibility.Visible;
        }

        private void ResetEvent(Object sender, EventArgs e)
        {
            Input_X1_Line.Visibility = Visibility.Hidden;
            Input_X2_Line.Visibility = Visibility.Hidden;
            Input_Y_Line.Visibility = Visibility.Hidden;
            Entscheidung.Background = null;
            Entscheidung.Content = String.Empty;
            W1_Line.Background = null;
            W2_Line.Background = null;
            Mainball.Fill = new SolidColorBrush(Colors.Blue);
            fourthsball.Visibility = Visibility.Hidden;
            fifthsball.Visibility = Visibility.Hidden;
            Change_Line.Visibility = Visibility.Hidden;
            Delta_Line.Visibility = Visibility.Hidden;
        }

        private void FirstLineEvent(Object sender, EventArgs e)
        {
            Input_X1_Line.Visibility = Visibility.Visible;
            Input_X2_Line.Visibility = Visibility.Visible;
            firstball.Visibility = Visibility.Hidden;
            secondball.Visibility = Visibility.Visible;
        }

        private void SecondLineEvent(Object sender, EventArgs e)
        {
            Input_Y_Line.Visibility = Visibility.Visible;
            secondball.Visibility = Visibility.Hidden;
            thirdball.Visibility = Visibility.Visible;
        }

        private void ThirdLineEventTrue(Object sender, EventArgs e)
        {
            Entscheidung.Background=new SolidColorBrush(Colors.Green);
            Entscheidung.Content = FindResource("wahr");
            thirdball.Visibility = Visibility.Hidden;
            fourthsball.Visibility = Visibility.Visible;
        }

        private void ThirdLineEventFalse(Object sender, EventArgs e)
        {
            Entscheidung.Background = new SolidColorBrush(Colors.Red);
            Entscheidung.Content = FindResource("falsch");
            thirdball.Visibility = Visibility.Hidden;
            fourthsball.Visibility = Visibility.Visible;
        }

        private void FourthLineEvent(Object sender, EventArgs e)
        {
            fourthsball.Visibility = Visibility.Hidden;
            fifthsball.Visibility = Visibility.Visible;
        }

        private void FourthLineBatchEvent(Object sender, EventArgs e)
        {
            fourthsball.Visibility = Visibility.Hidden;
            fifthsball.Visibility = Visibility.Visible;
        }

        private void BatchEvent(Object sender, EventArgs e)
        {
            W1_Line.Background = new SolidColorBrush(Colors.Red);
            W2_Line.Background = new SolidColorBrush(Colors.Red);
            Mainball.Fill = new SolidColorBrush(Colors.Red);
        }

        private void RndValue_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if(SWEVM!=null) SWEVM.RoundMax = ((Slider)sender).Value;
        }

        private void ErrorValue_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (SWEVM != null) SWEVM.ErrorMax = ((Slider)sender).Value;
        }

        private void LPValue_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (SWEVM != null) SWEVM.LP = ((Slider)sender).Value;
        }

        private void Delete_Line(object sender, RoutedEventArgs e)
        {
            SchwellenwertelementInput SWEI = (SchwellenwertelementInput)((Button)sender).Tag;
            Uebung_1_Daten.Remove(SWEI);
        }

        private void Home_Menu_Click(object sender, RoutedEventArgs e)
        {
            switch(MainFrame.SelectedIndex)
            {
                case 6: Uebung_1_Untertitel_1_Release();
                        Uebung_1_SubIndex = 0;
                        break;
                default:
                    MenuVisibility = Menu_Visibility(!MenuVisibility);
                    MainFrame.SelectedIndex = 0;
                    break;
            }
        }
    }

    public class DSConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            return values[0].ToString() + "/" + values[1].ToString();
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            return new[] { value, value };
        }
    }

    public class ChangeConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            return "T: " + values[0].ToString() + " W1: " + values[1].ToString() + " W2: " + values[2].ToString();
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            return new[] { value, value };
        }
    }

    public class DeltaConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            return "dT: " + values[0].ToString() + " dW1: " + values[1].ToString() + " dW2: " + values[2].ToString();
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            return new[] { value, value };
        }
    }

    public class UnsetValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return DependencyProperty.UnsetValue;
        }
    }
}
