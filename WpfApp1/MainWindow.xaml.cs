using System;
using System.Windows;
using System.Windows.Controls;
using System.Linq;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        // starts the whole thing up
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        // small tasks to handle when the window opens up, such as hide certain boxes
        /// </summary>
        public void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Hide_Names();
            Hide_verbgroups();
        }

        /// summary
        // LISTBOX LEFT
        // method for listbox interaction + selecting corresponding element in other listbox
        /// summary 
        private void listBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ClearAndInput clinCheckVerbGroup = new ClearAndInput();
            //constantly copyiing. not good solution.. can't get ctrl+c to work...
            System.Windows.Clipboard.SetText(string.Join(Environment.NewLine, listBox.SelectedItems.OfType<string>().ToArray()));

            //check the checkbox for verb group.
            CheckSelectAndMarkGroupLeftListbox();
        }

        /// summary
        // LISTBOX RIGHT
        // method for listbox interaction + selecting corresponding element in other listbox
        /// summary 
        private void listBox2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //constantly copyiing. not good solution.. can't get ctrl+c to work...
            System.Windows.Clipboard.SetText(string.Join(Environment.NewLine, listBox.SelectedItems.OfType<string>().ToArray()));
            CheckSelectAndMarkGroupRightListbox();
        }

        /// summary
        // VERB RADIOBUTTON
        // method for inputting Verbs
        /// summary 
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

            ChangeLayout chng = new ChangeLayout();
            chng.ChangeListBoxLayout(false);

            //method for retrieving content from texfile(s)
            ClearAndInput clin = new ClearAndInput();
            clin.ClearListAndInputValuesForVerbs("group1_verbs", "group2_verbs", "group3_verbs");

            Hide_Names();
        }

        /// summary
        // NOUN RADIOBUTTON
        // method for inputting Nouns
        /// summary 
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

            ChangeLayout chng = new ChangeLayout();
            chng.ChangeListBoxLayout(false);

            //method for retrieving content from texfile(s)
            ClearAndInput clin = new ClearAndInput();
            clin.ClearListAndInputValues("Noun");

            //hide verb_group checkboxes (could't hide them otherwize for unknown reasons.
            Hide_verbgroups();
        }

        /// summary
        // PARTICLE RADIOBUTTON
        // method for inputting Particles
        /// summary 
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

            ChangeLayout chng = new ChangeLayout();
            chng.ChangeListBoxLayout(false);

            //method for retrieving content from texfile(s)
            ClearAndInput clin = new ClearAndInput();
            clin.ClearListAndInputValues("Particle");

            //hide verb_group checkboxes (could't hide them otherwize for unknown reasons.
            Hide_verbgroups();
            Hide_Names();
        }

        /// summary
        // CONJUGATION RADIOBUTTON
        // method for inputting Conjugations
        /// summary 
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

            ChangeLayout chng = new ChangeLayout();
            chng.ChangeListBoxLayout(true);

            //method for retrieving content from texfile(s)
            ClearAndInput clin = new ClearAndInput();
            clin.ClearListAndInputValues("Conjugation");

            //hide verb_group checkboxes (could't hide them otherwize for unknown reasons.
            Hide_verbgroups();
            Hide_Names();
        }

        /// summary
        // NUMBER RADIOBUTTON
        // method for inputting Numbers
        /// summary 
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

            ChangeLayout chng = new ChangeLayout();
            chng.ChangeListBoxLayout(false);

            //method for retrieving content from texfile(s)
            ClearAndInput clin = new ClearAndInput();
            clin.ClearListAndInputValues("Number");

            //hide verb_group checkboxes (could't hide them otherwize for unknown reasons.
            Hide_verbgroups();
            Hide_Names();
        }

        /// summary
        // PATTERN RADIOBUTTON
        // method for inputting Sentence patterns
        /// summary 
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

            ChangeLayout chng = new ChangeLayout();
            chng.ChangeListBoxLayout(true);

            //method for retrieving content from texfile(s)
            ClearAndInput clin = new ClearAndInput();
            clin.ClearListAndInputValues("Sentence_Pattern");

            //hide verb_group checkboxes (could't hide them otherwize for unknown reasons.
            Hide_verbgroups();
            Hide_Names();
            //see method for explanation of parameter "1"
            ShowOrChangePatternBox(1);
        }

        /// summary
        // SPECIAL RADIOBUTTON
        // method for inputting special elements
        /// summary 
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

            ChangeLayout chng = new ChangeLayout();
            chng.ChangeListBoxLayout(false);

            //method for retrieving content from texfile(s)
            ClearAndInput clin = new ClearAndInput();
            clin.ClearListAndInputValues("Special_Cases");

            Hide_verbgroups();
            Hide_Names();
        }

        /// summary
        // SENTENCE RADIOBUTTON
        // method for inputting Sentences
        /// summary 
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

            ChangeLayout chng = new ChangeLayout();
            chng.ChangeListBoxLayout(false);

            //method for retrieving content from texfile(s)
            ClearAndInput clin = new ClearAndInput();
            clin.ClearListAndInputValues("Sentence");

            Hide_verbgroups();
            Hide_Names();
        }

        /// summary
        // KANJI RADIOBUTTON
        // method for inputting Kanji
        /// summary 
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

            ChangeLayout chng = new ChangeLayout();
            chng.ChangeListBoxLayout(false);

            //method for retrieving content from texfile(s)
            ClearAndInput clin = new ClearAndInput();
            clin.ClearListAndInputValues("kanji");

            Hide_verbgroups();
            Hide_Names();
        }

        /// summary
        // USER RADIOBUTTON
        // method for inputting user names
        /// summary 
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

            ChangeLayout chng = new ChangeLayout();
            chng.ChangeListBoxLayout(false);

            //method for retrieving content from texfile(s)
            ClearAndInput clin = new ClearAndInput();
            clin.ClearListAndInputValues("Users");
        }

        /// <summary>
        // plan to make it remove element from database once that is implemented.
        /// </summary>
        private void incorrect_Click(object sender, RoutedEventArgs e)
        {
            //put incorrect sentences into list with incorrect sentences
            string Texter = InputSentence.Text;

            //stationary
            System.IO.File.WriteAllText(@"C:\Users\Dan\Source\Repos\Ladtos2\WpfApp1\Input.txt", Texter);

            //laptop
            System.IO.File.WriteAllText(@"c:\users\tooth\onedrive\dokumenter\visual studio 2017\Projects\WpfApp1\WpfApp1\Input.txt", Texter);
        }

        /// summary
        // method for writing to file
        /// summary 
        private void Correct_Click(object sender, RoutedEventArgs e)
        {
            //put correct sentence into list with correct sentences
            //
            RadioButtonClass RadioBt = new RadioButtonClass();
            RadioBt.CheckifChecked();
        }

        /// <summary>
        // Hides hint text when text entered in japanese input box
        /// </summary>
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            Boolean focused = InputSentence.IsFocused;
            if (InputSentence.Text.Length > 0)
            {
                Japan_Pre_text.Visibility = System.Windows.Visibility.Collapsed;
            }
            else
            {
                Japan_Pre_text.Visibility = System.Windows.Visibility.Visible;
            }
        }

        /// <summary>
        // Hides hint text when text entered in english input box
        /// </summary>
        private void TextBox_TextChanged_Eng(object sender, TextChangedEventArgs e)
        {
            Boolean focused = InputSentence_Eng.IsFocused;
            if (InputSentence_Eng.Text.Length > 0)
            {
                English_Pre_text.Visibility = System.Windows.Visibility.Collapsed;
            }
            else
            {
                English_Pre_text.Visibility = System.Windows.Visibility.Visible;
            }
        }

        /// summary
        // method for showing verbgroup checkboxes
        /// summary 
        private void Show_verbgroups()
        {
            if (Verb.IsChecked == true)
            {
                group1_verb.Visibility = System.Windows.Visibility.Visible;
                group2_verb.Visibility = System.Windows.Visibility.Visible;
                group3_verb.Visibility = System.Windows.Visibility.Visible;
            }
        }

        /// summary
        // method for hiding verbgroup checkboxes
        /// summary 
        private void Hide_verbgroups()
        {
            group1_verb.Visibility = System.Windows.Visibility.Collapsed;
            group2_verb.Visibility = System.Windows.Visibility.Collapsed;
            group3_verb.Visibility = System.Windows.Visibility.Collapsed;
        }
        /// summary
        // Method for hiding user name radiobutton
        /// summary 
        private void Hide_Names()
        {
            Name.Visibility = System.Windows.Visibility.Collapsed;
            Name_Border.Visibility = System.Windows.Visibility.Collapsed;
        }

        /// summary
        // to focus item in listbox 2 when item chosen in listbox 1.
        /// summary 
        private void CheckSelectAndMarkGroupLeftListbox()
        {
            //checks if an item is actually selected and mark correct check box based on selected verb.
            if (listBox.SelectedIndex != -1)
            {
                //select item and check what verb group it belongs to
                string selected_element = listBox.SelectedItem.ToString();

                //only does something if conjugation or pattern is not checked
                if (Conjugation.IsChecked == true || Sentence_Pattern.IsChecked == true)
                {
                    //do nothing
                }
                else
                {
                    //selects and scrolls to appropriate item
                    int ChosenIndex = listBox.SelectedIndex;
                    listBox2.SelectedIndex = ChosenIndex;
                    listBox2.ScrollIntoView(listBox2.Items[listBox.SelectedIndex]);
                }

                // checks what Verb group is marked and checks out checkboxes
                if (Verb.IsChecked == true)
                {
                    WhatVerbGroup();
                }
                if (Sentence_Pattern.IsChecked == true)
                {
                    ShowOrChangePatternBox(3);
                }
            }
        }

        /// summary
        // to focus item in listbox 1 when item chosen in listbox 2.
        /// summary 
        private void CheckSelectAndMarkGroupRightListbox()
        {
            //checks if an item is actually selected and mark correct check box based on selected verb.
            if (listBox2.SelectedIndex != -1)
            {

                if (Conjugation.IsChecked == true || Sentence_Pattern.IsChecked == true)
                {
                    //do nothing
                }
                else
                {
                    //selects and scrolls to appropriate item
                    int ChosenIndex = listBox2.SelectedIndex;
                    listBox.SelectedIndex = ChosenIndex;
                    listBox.ScrollIntoView(listBox.Items[listBox2.SelectedIndex]);
                }
                if (Verb.IsChecked == true)
                {
                    //select item and check what verb group it belongs to
                    WhatVerbGroup();
                }
            }
        }

        /// summary
        //pulls entire japanese word list out and checks what group is belongs too.
        /// summary 
        private void WhatVerbGroup()
        {

            string selected_element = listBox.SelectedItem.ToString();

            //stationary
            String[] grp1_Tmp = System.IO.File.ReadAllLines(@"C:\Users\Dan\Source\Repos\Ladtos2\WpfApp1\group1_verbs_Jap.txt");
            String[] grp2_Tmp = System.IO.File.ReadAllLines(@"C:\Users\Dan\Source\Repos\Ladtos2\WpfApp1\group2_verbs_Jap.txt");
            String[] grp3_Tmp = System.IO.File.ReadAllLines(@"C:\Users\Dan\Source\Repos\Ladtos2\WpfApp1\group3_verbs_Jap.txt");

            //laptop
            //String[] grp1_Tmp = System.IO.File.ReadAllLines(@"c:\users\tooth\onedrive\dokumenter\visual studio 2017\Projects\WpfApp1\WpfApp1\group1_verbs.txt");
            //String[] grp2_Tmp = System.IO.File.ReadAllLines(@"c:\users\tooth\onedrive\dokumenter\visual studio 2017\Projects\WpfApp1\WpfApp1\group2_verbs.txt");
            //String[] grp3_Tmp = System.IO.File.ReadAllLines(@"c:\users\tooth\onedrive\dokumenter\visual studio 2017\Projects\WpfApp1\WpfApp1\group3_verbs.txt");

            //the length stays the same nomatter whether eng or jap
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

        /// <summary>
        // Shows/Hide pattern box and copies selected element down into it.
        // takes int argument 1, 2 and 3
        /// </summary>
        private void ShowOrChangePatternBox(int Action)
        {
            if (Action == 1)
            {
                Pattern_Box.Visibility = System.Windows.Visibility.Visible;
            }
            else if (Action == 2)
            {
                Pattern_Box.Visibility = System.Windows.Visibility.Collapsed;
            }
            else if (Action == 3)
            {
                String pattern_Tmp = listBox.SelectedItem.ToString();
                Pattern_Box.Content = pattern_Tmp;
            }
        }


    }
}