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
using System.Windows.Threading;

namespace Dictionaries_2___Atletiekvereniging
{

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // Declaratie van variabelen.
        #region Init
        // Array voor CboNamen.
        private List<string> _names = new List<string>() { "Sander", "Quirino", "Thomas", "Cédric",
        "Jason", "Domenico", "Rickert", "Klaas", "Tom", "Stephan", "Alexander", "Yannick", "Robin" ,
        "Dave", "Lynn", "Arno", "Niels", "Maxiem", "Matthijs", "Kobe", "Michaël", "Bram", "Achraf",
        "Raf", "Sven", "Gerben", "Kevin", "Cem", "Steff", "Steven", "Rani", "Djordy" , "Nick",
        "Mikail", "Konstantin", "Asad", "Viktor", "Antonio", "Senne", "Benjamin", "Stef", "Abdul",
        "Christiaan", "Abdurrahman", "Jurgen", "Kevin", "Silvio", "Nathan", "Stijn", "Bart",
        "Frank", "Steven", "Matty", "Arend", "Simon", "Ziggy", "Pascal", "Michaël", "Danny",
        "Robby", "Johan", "Vincent", "Wim", "Tuba", "Kristof", "Kenneth" };

        private string[,] _pricePerCategory = { { "Preminiem", "150" }, { "Miniem", "150" }, {"Junior", "170" }, { "Cadet", "170" },{ "Senior", "200" } };

        private TextBox[] _prognoseBoxes = new TextBox[6];
        #endregion

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            foreach (var name in _names)
            {
                ComboBoxItem cbi = new ComboBoxItem();
                cbi.Content = name;
                namesComboBox.Items.Add(cbi);
            }
            //Initialiseren (alle items uit het panel).
            int i = 0;
            foreach (object item in prognoseStackPanel.Children)
            {
                if (item is TextBox)
                {
                    _prognoseBoxes[i] = (TextBox)item;
                    i++;
                }
            }
            // Vermits deze wijzigingen bij het opstarten worden doorlopen,
            // wordt het event calculateButton_Click doorlopen (test: namesComboBox.SelectedIndex == -1)
            competitionCheckBox.IsChecked = false;
            newSubscriptionCheckBox.IsChecked = false;
            orderTextBox.Text = "1";
            // Installeren van timer dmv de klasse aan te spreken.
            DispatcherTimer timer = new DispatcherTimer();
            // Timer laten aflopen om de seconde.
            timer.Tick += new EventHandler(DispatcherTimer_Tick);
            timer.Interval = new TimeSpan(0, 0, 1); //uren, minuten, seconden
            // Timer laten starten
            timer.Start();
            // TIJD instellen.
            ShowTime();
        }

        private void DispatcherTimer_Tick(object sender, EventArgs e)
        {
            ShowTime();
        }

        private void ShowTime()
        {
            timeLabel.Content = $"{DateTime.Now.ToLongTimeString()}";
        }

        private void closeButton_Click(object sender, RoutedEventArgs e)
        { 
            Close();
        }

        private void Calculate()
        {
            float amountToPay;
            float subscriptionAmount = 0;
            float improvement = 0.05f;
            int width = 380;
            if (namesComboBox.SelectedIndex != -1)
            {
                //Basisbedrag.
                int i = 0;
                foreach (RadioButton rb in categoriesStackPanel.Children)
                {
                    if (rb.IsChecked == true)
                    {
                        subscriptionAmount = int.Parse(_pricePerCategory[i, 1]);
                        break;
                    }
                    i++;
                }
                // Competitielid betaalt 50 euro meer.
                amountToPay = (competitionCheckBox.IsChecked == true) ? subscriptionAmount + 50 : subscriptionAmount;
                //amountToPay = subscriptionAmount + ((competitionCheckBox.IsChecked == true) ? 50 : 0);

                // Rangnummer van gezin.
                //5% korting = 95% betalen
                //10% korting = 90% betalen
                //90% = 0.90
                //95% = 0.95
                amountToPay *= 1 - ((float.Parse(orderTextBox.Text) - 1) * 0.05f);
                //amountToPay *= 100 - ((float.Parse(orderTextBox.Text) - 1) * 5);

                //Resultaat afdrukken.
                resultTextBox.Text = $"Inschrijvingsbedrag voor {((ComboBoxItem)namesComboBox.SelectedValue).Content}\n\n" +
                $"Basisbedrag voor {namesComboBox.Text} : {subscriptionAmount}\n" +
                $"Te betalen: {amountToPay}";

                if (newSubscriptionCheckBox.IsChecked == true)
                {
                    //Prognosestaafjes herschikken voor nieuw lid.
                    if (float.TryParse(timeTextBox.Text, out float time))
                    {
                        //Prognose zichtbaar maken.
                        prognoseInfoLabel.Visibility = Visibility.Visible;
                        prognoseStackPanel.Visibility = Visibility.Visible;
                        foreach (TextBox tb in _prognoseBoxes)
                        {
                            tb.Text = $"{time:f2}";
                            tb.Width = width;
                            time *= (1 - improvement);
                            width = (int)(width * (1 - improvement)); // ! casting naar int
                            improvement -= 0.005f;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Geef een correcte tijd in", "Foute tijd", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                        timeTextBox.Focus();
                    }
                }
                else
                {
                    //Prognose Onzichtbaar maken.
                    prognoseStackPanel.Visibility = Visibility.Hidden;
                    prognoseInfoLabel.Visibility = Visibility.Hidden;
                }
            }
        }

        private void calculateButton_Click(object sender, RoutedEventArgs e)
        {
            Calculate();
        }

        private void Clear()
        {
            // Tekstvakken van formulier leeg maken.
            foreach (TextBox tb in _prognoseBoxes)
            {
                // TextBox wordt leeggemaakt.
                tb.Clear();
            }
            //Prognose onzichtbaar maken.
            prognoseStackPanel.Visibility = Visibility.Hidden;
            prognoseInfoLabel.Visibility = Visibility.Hidden;
            namesComboBox.SelectedIndex = -1;
            timeTextBox.Clear();
            resultTextBox.Clear();
            orderTextBox.Clear();
            cadetRadioButton.IsChecked = true; // Roept BtnBerekenen op!!
            competitionCheckBox.IsChecked = false;
            newSubscriptionCheckBox.IsChecked = false;
            namesComboBox.Focus();
        }

        private void clearButton_Click(object sender, RoutedEventArgs e)
        {
            Clear();
        }

        private void namesComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Calculate();
        }
    }
}
