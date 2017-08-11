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
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        public void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ChangeLayout cl = new ChangeLayout();
            cl.Noun_Subcategories(false);
            cl.Verb_Subcategories(false);
            cl.DisplayKatakanaEquivelant(false);
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //constantly copyiing. not good solution.. can't get ctrl+c to work...
            System.Windows.Clipboard.SetText(string.Join(Environment.NewLine, listBox.SelectedItems.OfType<string>().ToArray()));

            //check the checkbox for verb group.
            CheckSelectAndMarkGroupLeftListbox();
        }

        private void ListBox2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //constantly copyiing. not good solution.. can't get ctrl+c to work...
            System.Windows.Clipboard.SetText(string.Join(Environment.NewLine, listBox.SelectedItems.OfType<string>().ToArray()));

            //check the checkbox for verb group.
            CheckSelectAndMarkGroupRightListbox();
        }

        public void Verb_Checked(object sender, RoutedEventArgs e)
        {
            //method for retrieving content from texfile(s)
            DatabaseHandling rtd = new DatabaseHandling();
            rtd.RetrieveData("verb_groups");

            //change layout of window
            ChangeLayout cl = new ChangeLayout();
            cl.Noun_Subcategories(false);
            cl.Verb_Subcategories(true);
            cl.ChangeListBoxLayout(false);
            cl.DisplayKatakanaEquivelant(false);
        }

        private void Noun_Checked(object sender, RoutedEventArgs e)
        {
            ChangeLayout cl = new ChangeLayout();
            //changes listbox size
            cl.ChangeListBoxLayout(false);
            cl.DisplayKatakanaEquivelant(true);
            cl.Noun_Subcategories(true);
            cl.Verb_Subcategories(false);

            //method for retrieving content from texfile(s)
            DatabaseHandling rtd = new DatabaseHandling();
            rtd.RetrieveData("noun_object");

        }

        private void Particle_Checked(object sender, RoutedEventArgs e)
        {
            //method for retrieving content from texfile(s)
            DatabaseHandling rtd = new DatabaseHandling();
            rtd.RetrieveData("particles");

            ChangeLayout cl = new ChangeLayout();
            cl.Noun_Subcategories(false);
            cl.Verb_Subcategories(false);
            cl.ChangeListBoxLayout(false);
            cl.DisplayKatakanaEquivelant(false);
        }

        private void Conjugation_Checked(object sender, RoutedEventArgs e)
        {
            //method for retrieving content from texfile(s)
            DatabaseHandling rtd = new DatabaseHandling();
            rtd.RetrieveData("conjugation");

            ChangeLayout cl = new ChangeLayout();
            cl.Noun_Subcategories(false);
            cl.Verb_Subcategories(false);
            cl.ChangeListBoxLayout(false);
            cl.DisplayKatakanaEquivelant(false);
        }

        private void Number_Checked(object sender, RoutedEventArgs e)
        {
            //method for retrieving content from texfile(s)
            DatabaseHandling rtd = new DatabaseHandling();
            rtd.RetrieveData("numbers");

            ChangeLayout cl = new ChangeLayout();
            cl.Noun_Subcategories(false);
            cl.Verb_Subcategories(false);
            cl.ChangeListBoxLayout(false);
            cl.DisplayKatakanaEquivelant(false);
        }

        private void Sentence_Pattern_Checked(object sender, RoutedEventArgs e)
        {
            //method for retrieving content from texfile(s)
            DatabaseHandling rtd = new DatabaseHandling();
            rtd.RetrieveData("patterns");

            ChangeLayout cl = new ChangeLayout();
            cl.Noun_Subcategories(false);
            cl.Verb_Subcategories(false);
            cl.ChangeListBoxLayout(true);
            cl.DisplayKatakanaEquivelant(false);
        }

        private void Special_cases_Checked(object sender, RoutedEventArgs e)
        {
            //method for retrieving content from texfile(s)
            DatabaseHandling rtd = new DatabaseHandling();
            rtd.RetrieveData("special");

            ChangeLayout cl = new ChangeLayout();
            cl.Noun_Subcategories(false);
            cl.Verb_Subcategories(false);
            cl.ChangeListBoxLayout(false);
            cl.DisplayKatakanaEquivelant(false);
        }

        private void Sentence_Checked(object sender, RoutedEventArgs e)
        {
            //method for retrieving content from texfile(s)
            DatabaseHandling rtd = new DatabaseHandling();
            rtd.RetrieveData("sentences");

            ChangeLayout cl = new ChangeLayout();
            cl.Noun_Subcategories(false);
            cl.Verb_Subcategories(false);
            cl.ChangeListBoxLayout(false);
            cl.DisplayKatakanaEquivelant(false);
        }

        private void Kanji_Checked(object sender, RoutedEventArgs e)
        {
            //method for retrieving content from texfile(s)
            DatabaseHandling rtd = new DatabaseHandling();
            rtd.RetrieveData("kanji");

            ChangeLayout cl = new ChangeLayout();
            cl.Noun_Subcategories(false);
            cl.Verb_Subcategories(false);
            cl.ChangeListBoxLayout(false);
            cl.DisplayKatakanaEquivelant(false);
        }

        private void Name_Checked(object sender, RoutedEventArgs e)
        {
            //method for retrieving content from texfile(s)
            DatabaseHandling rtd = new DatabaseHandling();
            rtd.RetrieveData("users");
        }

        private void Incorrect_Click(object sender, RoutedEventArgs e)
        {
            //put incorrect sentences into list with incorrect sentences
            string Texter = InputSentence_Jap.Text;

            //stationary
            System.IO.File.WriteAllText(@"C:\Users\Dan\Source\Repos\Ladtos2\WpfApp1\Input.txt", Texter);

            //laptop
            System.IO.File.WriteAllText(@"c:\users\tooth\onedrive\dokumenter\visual studio 2017\Projects\WpfApp1\WpfApp1\Input.txt", Texter);
        }

        private void Correct_Click(object sender, RoutedEventArgs e)
        {
            //put correct sentence into list with correct sentences
            //
            RadioButtonClass RadioBt = new RadioButtonClass();
            RadioBt.CheckifChecked();
        }



        private void CheckSelectAndMarkGroupLeftListbox()
        {
            //checks if an item is actually selected and mark correct check box based on selected verb.
            if (listBox.SelectedIndex != -1)
            {
                DatabaseCon db = new DatabaseCon();
                SqlConnection con = new SqlConnection(db.DBCon());
                con.Open();

                DatabaseHandling rtd = new DatabaseHandling();

                //select item and check what verb group it belongs to
                string selected_element = listBox.SelectedItem.ToString();

                //only does something if conjugation or pattern is not checked
                if (Sentence_Pattern.IsChecked == true)
                {
                    //do nothing
                } //do nothing
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
                    rtd.FindVerbGroup();
                }
                if (Sentence_Pattern.IsChecked == true)
                {
                    Pattern_Box.Content = listBox.SelectedItem.ToString();
                    rtd.FindPatternExample();
                }
                if (Name.IsChecked == true)
                {
                    rtd.RetrieveKatakanaData("users", "user_hira");

                }
                else if (Noun.IsChecked == true)
                {
                    rtd.RetrieveKatakanaData("noun_place", "place_hira");
                    rtd.RetrieveKatakanaData("noun_object", "object_hira");
                }
                else if (Object.IsChecked == true)
                {
                    rtd.RetrieveKatakanaData("noun_object", "object_hira");
                }
                else if (Times.IsChecked == true)
                {
                    rtd.RetrieveKatakanaData("week_time", "week_day_hira");
                }
                else if (Places.IsChecked == true)
                {
                    rtd.RetrieveKatakanaData("noun_place", "place_hira");
                }
            }
        }

        private void CheckSelectAndMarkGroupRightListbox()
        {
            //checks if an item is actually selected and mark correct check box based on selected verb.
            if (listBox2.SelectedIndex != -1)
            {
                //selects and scrolls to appropriate item

                int ChosenIndex = listBox2.SelectedIndex;
                listBox.SelectedIndex = ChosenIndex;
                listBox.ScrollIntoView(listBox.Items[listBox2.SelectedIndex]);
            }
        }

        private void Level_1_Checked(object sender, RoutedEventArgs e)
        {
            WindowLvl1 sw = new WindowLvl1();
            sw.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            sw.Show();
            this.Close();
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
            DatabaseHandling rtd = new DatabaseHandling();
            rtd.RetrieveData("noun_object");
        }

        private void Place_Checked(object sender, RoutedEventArgs e)
        {
            //method for retrieving content from texfile(s)
            DatabaseHandling rtd = new DatabaseHandling();
            rtd.RetrieveData("noun_place");
        }

        private void Times_Checked(object sender, RoutedEventArgs e)
        {
            //method for retrieving content from texfile(s)
            DatabaseHandling rtd = new DatabaseHandling();
            rtd.RetrieveData("week_time");
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            Boolean focused = InputSentence_Jap.IsFocused;
            if (InputSentence_Jap.Text.Length > 0)
            {
                Japan_Pre_text.Visibility = System.Windows.Visibility.Collapsed;
            }
            else
            {
                Japan_Pre_text.Visibility = System.Windows.Visibility.Visible;
            }
        }

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

        private void TextBox_TextChanged_Kata(object sender, TextChangedEventArgs e)
        {
            Boolean focused = InputSentence_Kata.IsFocused;
            if (InputSentence_Kata.Text.Length > 0)
            {
                Katakana_Pre_text.Visibility = System.Windows.Visibility.Collapsed;
            }
            else
            {
                Katakana_Pre_text.Visibility = System.Windows.Visibility.Visible;
            }
        }
    }
}