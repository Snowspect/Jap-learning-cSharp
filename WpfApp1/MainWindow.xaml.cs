using System;
using System.Windows;
using System.Windows.Controls;
using System.Linq;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Data.SqlClient;

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
            ChangeLayout cl = new ChangeLayout();
            cl.Noun_Subcategories(false);
            cl.Verb_Subcategories(false);
            cl.DisplayKatakanaEquivelant(false);
        }

        /// summary
        // LISTBOX LEFT
        // method for listbox interaction + selecting corresponding element in other listbox
        /// summary 
        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //constantly copyiing. not good solution.. can't get ctrl+c to work...
            System.Windows.Clipboard.SetText(string.Join(Environment.NewLine, listBox.SelectedItems.OfType<string>().ToArray()));

            //check the checkbox for verb group.
            CheckSelectAndMarkGroupLeftListbox();
        }

        /// summary
        // LISTBOX RIGHT
        // method for listbox interaction + selecting corresponding element in other listbox
        /// summary 
        private void ListBox2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //constantly copyiing. not good solution.. can't get ctrl+c to work...
            System.Windows.Clipboard.SetText(string.Join(Environment.NewLine, listBox.SelectedItems.OfType<string>().ToArray()));

            //check the checkbox for verb group.
            CheckSelectAndMarkGroupRightListbox();
        }

        /// summary
        // VERB RADIOBUTTON
        // method for inputting Verbs
        /// summary 
        public void Verb_Checked(object sender, RoutedEventArgs e)
        {
            group1_verb.IsChecked = false;
            group2_verb.IsChecked = false;
            group3_verb.IsChecked = false;

            //method for retrieving content from texfile(s)
            RetrieveDataFromDB rtd = new RetrieveDataFromDB();
            rtd.RetrieveData("Verbs");

            //change layout of window
            ChangeLayout cl = new ChangeLayout();
            cl.Noun_Subcategories(false);
            cl.Verb_Subcategories(true);
            cl.ChangeListBoxLayout(false);
            cl.DisplayKatakanaEquivelant(false);
        }

        /// summary
        // NOUN RADIOBUTTON
        // method for inputting Nouns
        /// summary 
        private void Noun_Checked(object sender, RoutedEventArgs e)
        {

            ChangeLayout cl = new ChangeLayout();
            //changes listbox size
            cl.ChangeListBoxLayout(false);
            cl.DisplayKatakanaEquivelant(true);
            cl.Noun_Subcategories(true);
            cl.Verb_Subcategories(false);

            //method for retrieving content from texfile(s)
            RetrieveDataFromDB rtd = new RetrieveDataFromDB();
            rtd.RetrieveData("Noun");

        }

        /// summary
        // PARTICLE RADIOBUTTON
        // method for inputting Particles
        /// summary 
        private void Particle_Checked(object sender, RoutedEventArgs e)
        {
            //method for retrieving content from texfile(s)
            RetrieveDataFromDB rtd = new RetrieveDataFromDB();
            rtd.RetrieveData("Particle");

            ChangeLayout cl = new ChangeLayout();
            cl.Noun_Subcategories(false);
            cl.Verb_Subcategories(false);
            cl.ChangeListBoxLayout(false);
            cl.DisplayKatakanaEquivelant(false);
        }

        /// summary
        // CONJUGATION RADIOBUTTON
        // method for inputting Conjugations
        /// summary 
        private void Conjugation_Checked(object sender, RoutedEventArgs e)
        {
            //method for retrieving content from texfile(s)
            RetrieveDataFromDB rtd = new RetrieveDataFromDB();
            rtd.RetrieveData("Conjugation");

            ChangeLayout cl = new ChangeLayout();
            cl.Noun_Subcategories(false);
            cl.Verb_Subcategories(false);
            cl.ChangeListBoxLayout(true);
            cl.DisplayKatakanaEquivelant(false);
        }

        /// summary
        // NUMBER RADIOBUTTON
        // method for inputting Numbers
        /// summary 
        private void Number_Checked(object sender, RoutedEventArgs e)
        {
            //method for retrieving content from texfile(s)
            RetrieveDataFromDB rtd = new RetrieveDataFromDB();
            rtd.RetrieveData("Number");

            ChangeLayout cl = new ChangeLayout();
            cl.Noun_Subcategories(false);
            cl.Verb_Subcategories(false);
            cl.ChangeListBoxLayout(false);
            cl.DisplayKatakanaEquivelant(false);
        }

        /// summary
        // PATTERN RADIOBUTTON
        // method for inputting Sentence patterns
        /// summary 
        private void Sentence_Pattern_Checked(object sender, RoutedEventArgs e)
        {
            //method for retrieving content from texfile(s)
            RetrieveDataFromDB rtd = new RetrieveDataFromDB();
            rtd.RetrieveData("Sentence_Pattern");

            ChangeLayout cl = new ChangeLayout();
            cl.Noun_Subcategories(false);
            cl.Verb_Subcategories(false);
            cl.ChangeListBoxLayout(true);
            cl.DisplayKatakanaEquivelant(false);
        }

        /// summary
        // SPECIAL RADIOBUTTON
        // method for inputting special elements
        /// summary 
        private void Special_cases_Checked(object sender, RoutedEventArgs e)
        {
            //method for retrieving content from texfile(s)
            RetrieveDataFromDB rtd = new RetrieveDataFromDB();
            rtd.RetrieveData("Special_Cases");

            ChangeLayout cl = new ChangeLayout();
            cl.Noun_Subcategories(false);
            cl.Verb_Subcategories(false);
            cl.ChangeListBoxLayout(false);
            cl.DisplayKatakanaEquivelant(false);
        }

        /// summary
        // SENTENCE RADIOBUTTON
        // method for inputting Sentences
        /// summary 
        private void Sentence_Checked(object sender, RoutedEventArgs e)
        {
           //method for retrieving content from texfile(s)
            RetrieveDataFromDB rtd = new RetrieveDataFromDB();
            rtd.RetrieveData("Sentence");

            ChangeLayout cl = new ChangeLayout();
            cl.Noun_Subcategories(false);
            cl.Verb_Subcategories(false);
            cl.ChangeListBoxLayout(false);
            cl.DisplayKatakanaEquivelant(false);
        }

        /// summary
        // KANJI RADIOBUTTON
        // method for inputting Kanji
        /// summary 
        private void Kanji_Checked(object sender, RoutedEventArgs e)
        {
            //method for retrieving content from texfile(s)
            RetrieveDataFromDB rtd = new RetrieveDataFromDB();
            rtd.RetrieveData("kanji");

            ChangeLayout cl = new ChangeLayout();
            cl.Noun_Subcategories(false);
            cl.Verb_Subcategories(false);
            cl.ChangeListBoxLayout(false);
            cl.DisplayKatakanaEquivelant(false);
        }

        /// summary
        // USER RADIOBUTTON
        // method for inputting user names
        /// summary 
        private void Name_Checked(object sender, RoutedEventArgs e)
        {
            //method for retrieving content from texfile(s)
            RetrieveDataFromDB rtd = new RetrieveDataFromDB();
            rtd.RetrieveData("Users");
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
        // to focus item in listbox 2 when item chosen in listbox 1.
        /// summary 
        private void CheckSelectAndMarkGroupLeftListbox()
        {
            //checks if an item is actually selected and mark correct check box based on selected verb.
            if (listBox.SelectedIndex != -1)
            {
                //connect to database
                SqlConnection con = new SqlConnection("server=(localdb)\\ProjectsV13;database=Japanese;Trusted_Connection=True");
                con.Open();

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
                    ShowOrChangePatternBox();
                }
                if (Name.IsChecked == true)
                {
                    //find the equivalent katakana if it exists.
                    String chosenIndexNoun = listBox.SelectedItem.ToString();

                    SqlCommand cmd = new SqlCommand("select * from users where user_hira = N'" + chosenIndexNoun + "'", con);
                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        Katakana_input.Content = dr.GetString(3);
                    }
                    dr.Close();
                }
                else if (Noun.IsChecked == true)
                {
                    //find the equivalent katakana if it exists.
                    String SelectedNoun = listBox.SelectedItem.ToString();

                    SqlCommand cmd = new SqlCommand("select * from noun_object where object_hira = N'" + SelectedNoun + "'", con);
                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        Katakana_input.Content = dr.GetString(3);
                    }
                    dr.Close();

                    SqlCommand cmd2 = new SqlCommand("select * from noun_place where place_hira = N'" + SelectedNoun + "'", con);
                    SqlDataReader dr2 = cmd2.ExecuteReader();
                    while (dr2.Read())
                    {
                        Katakana_input.Content = dr2.GetString(3);
                    }
                    dr2.Close();
                }
                else if (Name.IsChecked == true)
                {

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
                //selects and scrolls to appropriate item
                int ChosenIndex = listBox2.SelectedIndex;
                listBox.SelectedIndex = ChosenIndex;
                listBox.ScrollIntoView(listBox.Items[listBox2.SelectedIndex]);
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
        // 
        /// </summary>
        private void ShowOrChangePatternBox()
        {
            // pull example list out of file and get ready to display
            String[] category_Display_Example = System.IO.File.ReadAllLines(@"C:\Users\Dan\Source\Repos\Ladtos2\WpfApp1\Sentence_Pattern_Eng.txt");
            // get index of pattern selected
            int example_Index = listBox.SelectedIndex;

            // display pattern in top label of two labels.
            String pattern_Tmp = listBox.SelectedItem.ToString();
            Pattern_Box.Content = pattern_Tmp;

            Pattern_Box_Example.Content = category_Display_Example[example_Index];
        }



        private void Level_1_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void Level_2_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void Level_3_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void Level_4_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void Level_5_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void Level_6_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void Level_7_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void Level_8_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void Level_9_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void Level_FM_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void Object_Checked(object sender, RoutedEventArgs e)
        {
            //method for retrieving content from texfile(s)
            RetrieveDataFromDB rtd = new RetrieveDataFromDB();
            rtd.RetrieveData("Object");
        }

        private void Place_Checked(object sender, RoutedEventArgs e)
        {
            //method for retrieving content from texfile(s)
            RetrieveDataFromDB rtd = new RetrieveDataFromDB();
            rtd.RetrieveData("Places");
        }

        private void Times_Checked(object sender, RoutedEventArgs e)
        {
            //method for retrieving content from texfile(s)
            RetrieveDataFromDB rtd = new RetrieveDataFromDB();
            rtd.RetrieveData("Time");
        }
    }
}