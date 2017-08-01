using System;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Forms;
using System.Linq;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //pre-defined arrays
        string[] group1_Verbs_Display;
        string[] group2_Verbs_Display;
        string[] group3_Verbs_Display;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Hide_Names();
            Hide_verbgroups();
        }

        //the container box 
        private void listBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //constantly copyiing. not good solution.. can't get ctrl+c to work...
            System.Windows.Clipboard.SetText(string.Join(Environment.NewLine, listBox.SelectedItems.OfType<string>().ToArray()));
            if (Verb.IsChecked == true)
            {
                //checks if an item is actually selected
                if (listBox.SelectedIndex != -1)
                {
                    //select item and check what verb group it belongs to
                    string selected_element = listBox.SelectedItem.ToString();
                    for (int i = 0; i < group1_Verbs_Display.Length; i++)
                    {
                        if (group1_Verbs_Display.Contains(selected_element))
                        {
                            group1_verb.IsChecked = true;
                            group2_verb.IsChecked = false;
                            group3_verb.IsChecked = false;
                        }
                        if (group2_Verbs_Display.Contains(selected_element))
                        {
                            group1_verb.IsChecked = false;
                            group2_verb.IsChecked = true;
                            group3_verb.IsChecked = false;
                        }
                        if (group3_Verbs_Display.Contains(selected_element))
                        {
                            group1_verb.IsChecked = false;
                            group2_verb.IsChecked = false;
                            group3_verb.IsChecked = true;
                        }
                    }
                }
                else
                {
                    // do nothing
                }
            }
        }


        private void Verb_Checked(object sender, RoutedEventArgs e)
        {
            // get verbs from list and return in list-box
            Show_verbgroups();

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

            ////////////////// clear listbox and read content from outside source
            listBox.Items.Clear();
            group1_Verbs_Display = System.IO.File.ReadAllLines(@"c:\users\tooth\onedrive\dokumenter\visual studio 2017\Projects\WpfApp1\WpfApp1\group1_verbs.txt");
            group2_Verbs_Display = System.IO.File.ReadAllLines(@"c:\users\tooth\onedrive\dokumenter\visual studio 2017\Projects\WpfApp1\WpfApp1\group2_verbs.txt");
            group3_Verbs_Display = System.IO.File.ReadAllLines(@"c:\users\tooth\onedrive\dokumenter\visual studio 2017\Projects\WpfApp1\WpfApp1\group3_verbs.txt");
            //display sources
            for (int i = 0; i < group1_Verbs_Display.Length; i++)
            {
                listBox.Items.Add(group1_Verbs_Display[i]);
            }
            for (int i = 0; i < group2_Verbs_Display.Length; i++)
            {
                listBox.Items.Add(group2_Verbs_Display[i]);
            }
            for (int i = 0; i < group3_Verbs_Display.Length; i++)
            {
                listBox.Items.Add(group3_Verbs_Display[i]);
            }
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

            //clear list box
            listBox.Items.Clear();

            Name.Visibility = System.Windows.Visibility.Visible;
            Name_Border.Visibility = System.Windows.Visibility.Visible;
            // get Nouns from source
            String[] noun_Display = System.IO.File.ReadAllLines(@"c:\users\tooth\onedrive\dokumenter\visual studio 2017\Projects\WpfApp1\WpfApp1\Noun.txt");

            //display content
            for (int i = 0; i < noun_Display.Length; i++)
            {
                listBox.Items.Add(noun_Display[i]);
            }

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

            //clear list box
            listBox.Items.Clear();

            //gets particle from source
            string[] particle_Display = System.IO.File.ReadAllLines(@"c:\users\tooth\onedrive\dokumenter\visual studio 2017\Projects\WpfApp1\WpfApp1\Particle.txt");

            //display content
            for (int i = 0; i < particle_Display.Length; i++)
            {
                listBox.Items.Add(particle_Display[i]);
            }

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

            //clear list box
            listBox.Items.Clear();

            //gets particle from source
            string[] conjugation_Display = System.IO.File.ReadAllLines(@"c:\users\tooth\onedrive\dokumenter\visual studio 2017\Projects\WpfApp1\WpfApp1\Conjugation.txt");

            //display content
            for (int i = 0; i < conjugation_Display.Length; i++)
            {
                listBox.Items.Add(conjugation_Display[i]);
            }

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

            //clear list box
            listBox.Items.Clear();

            //gets particle from source
            string[] number_Display = System.IO.File.ReadAllLines(@"c:\users\tooth\onedrive\dokumenter\visual studio 2017\Projects\WpfApp1\WpfApp1\Number.txt");

            //display content
            for (int i = 0; i < number_Display.Length; i++)
            {
                listBox.Items.Add(number_Display[i]);
            }

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

            //clear list box
            listBox.Items.Clear();

            //gets particle from source
            string[] sentence_Pattern_Display = System.IO.File.ReadAllLines(@"c:\users\tooth\onedrive\dokumenter\visual studio 2017\Projects\WpfApp1\WpfApp1\Sentence_Pattern.txt");

            //display content
            for (int i = 0; i < sentence_Pattern_Display.Length; i++)
            {
                listBox.Items.Add(sentence_Pattern_Display[i]);
            }

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

            //clear list box
            listBox.Items.Clear();

            //gets particle from source
            string[] special_Cases_Display = System.IO.File.ReadAllLines(@"c:\users\tooth\onedrive\dokumenter\visual studio 2017\Projects\WpfApp1\WpfApp1\Special_Cases.txt");

            //display content
            for (int i = 0; i < special_Cases_Display.Length; i++)
            {
                listBox.Items.Add(special_Cases_Display[i]);
            }

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

            //clear list box
            listBox.Items.Clear();

            string[] special_Cases_Display = System.IO.File.ReadAllLines(@"c:\users\tooth\onedrive\dokumenter\visual studio 2017\Projects\WpfApp1\WpfApp1\Sentence.txt");

            //display content
            for (int i = 0; i < special_Cases_Display.Length; i++)
            {
                listBox.Items.Add(special_Cases_Display[i]);
            }

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

            //clear list box
            listBox.Items.Clear();

            string[] kanji_Display = System.IO.File.ReadAllLines(@"c:\users\tooth\onedrive\dokumenter\visual studio 2017\Projects\WpfApp1\WpfApp1\Kanji.txt");

            //display content
            for (int i = 0; i < kanji_Display.Length; i++)
            {
                listBox.Items.Add(kanji_Display[i]);
            }

            Hide_verbgroups();
            Hide_Names();
        }

        //purpose not yet defined, plan: to remove elements from file
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

            if (Verb.IsChecked == true)
            {
                if (group1_verb.IsChecked == true)
                {
                    Insert_element("group1_verbs");
                }
                if (group2_verb.IsChecked == true)
                {
                    Insert_element("group2_verbs");
                }
                if (group3_verb.IsChecked == true)
                {
                    Insert_element("group3_verbs");
                }
            }
            if (Noun.IsChecked == true)
            {
                Insert_element("Noun");
            }
            if (Particle.IsChecked == true)
            {
                Insert_element("Particle");
            }
            if (Conjugation.IsChecked == true)
            {
                Insert_element("Conjugation");
            }
            if (Number.IsChecked == true)
            {
                Insert_element("Number");
            }
            if (Sentence_Pattern.IsChecked == true)
            {
                Insert_element("Sentence_Pattern");
            }
            if (Special_cases.IsChecked == true)
            {
                Insert_element("Special_Cases");
            }
            if (Sentence.IsChecked == true)
            {
                Insert_element("Sentence");
            }
            if (Kanjis.IsChecked == true)
            {
                Insert_element("Kanji");
            }
            if (Name.IsChecked == true)
            {
                Insert_element("Users");
            }
        }


        // nu purpose
        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            // holds no purpose
        }

        // method for writing to file
        private void Insert_element(string category)
        {
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"c:\users\tooth\onedrive\dokumenter\visual studio 2017\Projects\WpfApp1\WpfApp1\" + category + ".txt", true))
            {
                string Texter = InputSentence.Text;
                file.WriteLine(Texter);
                InputSentence.Text = "";
            }
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
        private void Hide_Names()
        {
            Name.Visibility = System.Windows.Visibility.Collapsed;
            Name_Border.Visibility = System.Windows.Visibility.Collapsed;
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

            //clear list box
            listBox.Items.Clear();

            string[] Users_Display = System.IO.File.ReadAllLines(@"c:\users\tooth\onedrive\dokumenter\visual studio 2017\Projects\WpfApp1\WpfApp1\Users.txt");

            //display content
            for (int i = 0; i < Users_Display.Length; i++)
            {
                listBox.Items.Add(Users_Display[i]);
            }
        }
    }
}