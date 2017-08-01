using System;
using System.Windows;
using System.Windows.Controls;
using System.Linq;

namespace WpfApp1
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

        public void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Hide_Names();
            Hide_verbgroups();
        }

        //the container box 
        private void listBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ClearAndInput clinCheckVerbGroup = new ClearAndInput();
            //constantly copyiing. not good solution.. can't get ctrl+c to work...
            System.Windows.Clipboard.SetText(string.Join(Environment.NewLine, listBox.SelectedItems.OfType<string>().ToArray()));
            if (Verb.IsChecked == true)
            {
                //checks if an item is actually selected and mark correct check box based on selected verb.
                if (listBox.SelectedIndex != -1)
                {
                    //select item and check what verb group it belongs to
                    string selected_element = listBox.SelectedItem.ToString();
                    String[] grp1_Tmp = System.IO.File.ReadAllLines(@"c:\users\tooth\onedrive\dokumenter\visual studio 2017\Projects\WpfApp1\WpfApp1\group1_verbs.txt");
                    String[] grp2_Tmp = System.IO.File.ReadAllLines(@"c:\users\tooth\onedrive\dokumenter\visual studio 2017\Projects\WpfApp1\WpfApp1\group2_verbs.txt");
                    String[] grp3_Tmp = System.IO.File.ReadAllLines(@"c:\users\tooth\onedrive\dokumenter\visual studio 2017\Projects\WpfApp1\WpfApp1\group3_verbs.txt");

                    int TotalLenght = grp1_Tmp.Length + grp2_Tmp.Length + grp3_Tmp.Length;

                    for (int i = 0; i < TotalLenght; i++)
                    {
                        if (grp1_Tmp.Contains(selected_element))
                        {
                            group1_verb.IsChecked = true;
                            group2_verb.IsChecked = false;
                            group3_verb.IsChecked = false;
                        }
                        if (grp2_Tmp.Contains(selected_element))
                        {
                            group1_verb.IsChecked = false;
                            group2_verb.IsChecked = true;
                            group3_verb.IsChecked = false;
                        }
                        if (grp3_Tmp.Contains(selected_element))
                        {
                            group1_verb.IsChecked = false;
                            group2_verb.IsChecked = false;
                            group3_verb.IsChecked = true;
                        }
                    }
                }
            }
        }


        public void Verb_Checked(object sender, RoutedEventArgs e)
        {
            // get verbs from list and return in list-box
            Show_verbgroups();

            group1_verb.IsChecked = false;
            group2_verb.IsChecked = false;
            group3_verb.IsChecked = false;

            /////////////////// set radiobutton values as active or not /////////////
            Verb.IsChecked = true;
            Noun.IsChecked = false;
            Particle.IsChecked = false;
            Conjugation.IsChecked = false;
            Number.IsChecked = false;
            Sentence_Pattern.IsChecked = false;
            Special_cases.IsChecked = false;
            Sentence.IsChecked = false;
            Kanjis.IsChecked = false;

            //method for retrieving content from texfile(s)
            ClearAndInput clin = new ClearAndInput();
            clin.ClearListAndInputValuesForVerbs("group1_verbs","group2_verbs","group3_verbs");

            Hide_Names();
        }

        private void Noun_Checked(object sender, RoutedEventArgs e)
        {
            /////////////////// set radiobutton values as active or not /////////////
            Verb.IsChecked = false;
            Noun.IsChecked = true;
            Particle.IsChecked = false;
            Conjugation.IsChecked = false;
            Number.IsChecked = false;
            Sentence_Pattern.IsChecked = false;
            Special_cases.IsChecked = false;
            Sentence.IsChecked = false;
            Kanjis.IsChecked = false;
            
            //display 
            Name.Visibility = System.Windows.Visibility.Visible;
            Name_Border.Visibility = System.Windows.Visibility.Visible;

            //method for retrieving content from texfile(s)
            ClearAndInput clin = new ClearAndInput();
            clin.ClearListAndInputValues("Noun");

            //hide verb_group checkboxes (could't hide them otherwize for unknown reasons.
            Hide_verbgroups();
        }

        private void Particle_Checked(object sender, RoutedEventArgs e)
        {
            /////////////////// set radiobutton values as active or not /////////////
            Verb.IsChecked = false;
            Noun.IsChecked = false;
            Particle.IsChecked = true;
            Conjugation.IsChecked = false;
            Number.IsChecked = false;
            Sentence_Pattern.IsChecked = false;
            Special_cases.IsChecked = false;
            Sentence.IsChecked = false;
            Kanjis.IsChecked = false;

            //method for retrieving content from texfile(s)
            ClearAndInput clin = new ClearAndInput();
            clin.ClearListAndInputValues("Particle");

            //hide verb_group checkboxes (could't hide them otherwize for unknown reasons.
            Hide_verbgroups();
            Hide_Names();
        }

        private void Conjugation_Checked(object sender, RoutedEventArgs e)
        {
            /////////////////// set radiobutton values as active or not /////////////
            Verb.IsChecked = false;
            Noun.IsChecked = false;
            Particle.IsChecked = false;
            Conjugation.IsChecked = true;
            Number.IsChecked = false;
            Sentence_Pattern.IsChecked = false;
            Special_cases.IsChecked = false;
            Sentence.IsChecked = false;
            Kanjis.IsChecked = false;

            //method for retrieving content from texfile(s)
            ClearAndInput clin = new ClearAndInput();
            clin.ClearListAndInputValues("Conjugation");

            //hide verb_group checkboxes (could't hide them otherwize for unknown reasons.
            Hide_verbgroups();
            Hide_Names();
        }

        private void Number_Checked(object sender, RoutedEventArgs e)
        {
            /////////////////// set radiobutton values as active or not /////////////
            Verb.IsChecked = false;
            Noun.IsChecked = false;
            Particle.IsChecked = false;
            Conjugation.IsChecked = false;
            Number.IsChecked = true;
            Sentence_Pattern.IsChecked = false;
            Special_cases.IsChecked = false;
            Sentence.IsChecked = false;
            Kanjis.IsChecked = false;

            //method for retrieving content from texfile(s)
            ClearAndInput clin = new ClearAndInput();
            clin.ClearListAndInputValues("Number");

            //hide verb_group checkboxes (could't hide them otherwize for unknown reasons.
            Hide_verbgroups();
            Hide_Names();
        }

        private void Sentence_Pattern_Checked(object sender, RoutedEventArgs e)
        {
            /////////////////// set radiobutton values as active or not /////////////
            Verb.IsChecked = false;
            Noun.IsChecked = false;
            Particle.IsChecked = false;
            Conjugation.IsChecked = false;
            Number.IsChecked = false;
            Sentence_Pattern.IsChecked = true;
            Special_cases.IsChecked = false;
            Sentence.IsChecked = false;
            Kanjis.IsChecked = false;

            //method for retrieving content from texfile(s)
            ClearAndInput clin = new ClearAndInput();
            clin.ClearListAndInputValues("Sentence_Pattern");

            //hide verb_group checkboxes (could't hide them otherwize for unknown reasons.
            Hide_verbgroups();
            Hide_Names();
        }

        private void Special_cases_Checked(object sender, RoutedEventArgs e)
        {
            /////////////////// set radiobutton values as active or not /////////////
            Verb.IsChecked = false;
            Noun.IsChecked = false;
            Particle.IsChecked = false;
            Conjugation.IsChecked = false;
            Number.IsChecked = false;
            Sentence_Pattern.IsChecked = false;
            Special_cases.IsChecked = true;
            Sentence.IsChecked = false;
            Kanjis.IsChecked = false;

            //method for retrieving content from texfile(s)
            ClearAndInput clin = new ClearAndInput();
            clin.ClearListAndInputValues("Special_Cases");

            Hide_verbgroups();
            Hide_Names();
        }

        private void Sentence_Checked(object sender, RoutedEventArgs e)
        {
            /////////////////// set radiobutton values as active or not /////////////
            Verb.IsChecked = false;
            Noun.IsChecked = false;
            Particle.IsChecked = false;
            Conjugation.IsChecked = false;
            Number.IsChecked = false;
            Sentence_Pattern.IsChecked = false;
            Special_cases.IsChecked = false;
            Sentence.IsChecked = true;
            Kanjis.IsChecked = false;

            //method for retrieving content from texfile(s)
            ClearAndInput clin = new ClearAndInput();
            clin.ClearListAndInputValues("Sentence");

            Hide_verbgroups();
            Hide_Names();
        }

        private void Kanji_Checked(object sender, RoutedEventArgs e)
        {
            Verb.IsChecked = false;
            Noun.IsChecked = false;
            Particle.IsChecked = false;
            Conjugation.IsChecked = false;
            Number.IsChecked = false;
            Sentence_Pattern.IsChecked = false;
            Special_cases.IsChecked = false;
            Sentence.IsChecked = false;
            Kanjis.IsChecked = true;

            //method for retrieving content from texfile(s)
            ClearAndInput clin = new ClearAndInput();
            clin.ClearListAndInputValues("kanji");

            Hide_verbgroups();
            Hide_Names();
        }

        private void Name_Checked(object sender, RoutedEventArgs e)
        {
            Verb.IsChecked = false;
            Noun.IsChecked = false;
            Particle.IsChecked = false;
            Conjugation.IsChecked = false;
            Number.IsChecked = false;
            Sentence_Pattern.IsChecked = false;
            Special_cases.IsChecked = false;
            Sentence.IsChecked = false;
            Kanjis.IsChecked = false;
            Name.IsChecked = true;

            //method for retrieving content from texfile(s)
            ClearAndInput clin = new ClearAndInput();
            clin.ClearListAndInputValues("Users");
        }

        /// <summary>
        /// plan to make it remove element from database once that is implemented.
        /// </summary>
        private void incorrect_Click(object sender, RoutedEventArgs e)
        {
            //put incorrect sentences into list with incorrect sentences
            string Texter = InputSentence.Text;
            System.IO.File.WriteAllText(@"c:\users\tooth\onedrive\dokumenter\visual studio 2017\Projects\WpfApp1\WpfApp1\Input.txt", Texter);
        }

        //method for writing to file
        private void Correct_Click(object sender, RoutedEventArgs e)
        {
            //put correct sentence into list with correct sentences
            //
            RadioButtonClass RadioBt = new RadioButtonClass();
            RadioBt.CheckifChecked();
        }


        // no purpose
        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            // holds no purpose
        }

        //method for showing verbgroup checkboxes
        private void Show_verbgroups()
        {
            if (Verb.IsChecked == true)
            {
                group1_verb.Visibility = System.Windows.Visibility.Visible;
                group2_verb.Visibility = System.Windows.Visibility.Visible;
                group3_verb.Visibility = System.Windows.Visibility.Visible;
            }
        }
        //method for hiding verbgroup checkboxes
        private void Hide_verbgroups()
        {
            group1_verb.Visibility = System.Windows.Visibility.Collapsed;
            group2_verb.Visibility = System.Windows.Visibility.Collapsed;
            group3_verb.Visibility = System.Windows.Visibility.Collapsed;
        }
        //method for hiding user name button
        private void Hide_Names()
        {
            Name.Visibility = System.Windows.Visibility.Collapsed;
            Name_Border.Visibility = System.Windows.Visibility.Collapsed;
        }


    }
}