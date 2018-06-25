using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    class ChangeLayout
    {
        /// 
        // method for changing layout of listboxes
        /// 
        public void ChangeListBoxLayout(Boolean p)
        {
            if (p == true)
            {
                ((MainWindow)System.Windows.Application.Current.MainWindow).listBox2.Visibility = System.Windows.Visibility.Collapsed;
                ((MainWindow)System.Windows.Application.Current.MainWindow).listBox.Width = 640;
                ((MainWindow)System.Windows.Application.Current.MainWindow).Translate_Headline.Visibility = System.Windows.Visibility.Collapsed;
            }
            else
            {
                ((MainWindow)System.Windows.Application.Current.MainWindow).listBox2.Visibility = System.Windows.Visibility.Visible;
                ((MainWindow)System.Windows.Application.Current.MainWindow).listBox.Width = 288;
                ((MainWindow)System.Windows.Application.Current.MainWindow).Translate_Headline.Visibility = System.Windows.Visibility.Visible;
            }
        }

        /// <summary>
        // method for displaying katakana equivelants.
        /// </summary>
        public void DisplayKatakanaEquivelant(Boolean p)
        {
            if (p == true)
            {
                ((MainWindow)System.Windows.Application.Current.MainWindow).Katakana_input.Visibility = System.Windows.Visibility.Visible;
                ((MainWindow)System.Windows.Application.Current.MainWindow).Katakana_label.Visibility = System.Windows.Visibility.Visible;
            }
            else
            {
                ((MainWindow)System.Windows.Application.Current.MainWindow).Katakana_input.Visibility = System.Windows.Visibility.Collapsed;
                ((MainWindow)System.Windows.Application.Current.MainWindow).Katakana_label.Visibility = System.Windows.Visibility.Collapsed;
            }
        }

        /// summary
        // Method for hiding user name radiobutton
        /// summary 

        public void Noun_Subcategories(Boolean p)
        {
            if (p == false)
            {
                ((MainWindow)System.Windows.Application.Current.MainWindow).Name.Visibility = System.Windows.Visibility.Collapsed;
                ((MainWindow)System.Windows.Application.Current.MainWindow).Name_Border.Visibility = System.Windows.Visibility.Collapsed;

                ((MainWindow)System.Windows.Application.Current.MainWindow).Object.Visibility = System.Windows.Visibility.Collapsed;
                ((MainWindow)System.Windows.Application.Current.MainWindow).object_Border.Visibility = System.Windows.Visibility.Collapsed;

                ((MainWindow)System.Windows.Application.Current.MainWindow).Places.Visibility = System.Windows.Visibility.Collapsed;
                ((MainWindow)System.Windows.Application.Current.MainWindow).Places_Border.Visibility = System.Windows.Visibility.Collapsed;

                ((MainWindow)System.Windows.Application.Current.MainWindow).Times.Visibility = System.Windows.Visibility.Collapsed;
                ((MainWindow)System.Windows.Application.Current.MainWindow).Times_Border.Visibility = System.Windows.Visibility.Collapsed;

                ((MainWindow)System.Windows.Application.Current.MainWindow).Katakana_Input_Border.Visibility = System.Windows.Visibility.Collapsed;
                ((MainWindow)System.Windows.Application.Current.MainWindow).Katakana_Pre_text.Visibility = System.Windows.Visibility.Collapsed;
                ((MainWindow)System.Windows.Application.Current.MainWindow).InputSentence_Kata.Visibility = System.Windows.Visibility.Collapsed;
            }
            else if (p == true)
            {
                ((MainWindow)System.Windows.Application.Current.MainWindow).Name.Visibility = System.Windows.Visibility.Visible;
                ((MainWindow)System.Windows.Application.Current.MainWindow).Name_Border.Visibility = System.Windows.Visibility.Visible;

                ((MainWindow)System.Windows.Application.Current.MainWindow).Object.Visibility = System.Windows.Visibility.Visible;
                ((MainWindow)System.Windows.Application.Current.MainWindow).object_Border.Visibility = System.Windows.Visibility.Visible;

                ((MainWindow)System.Windows.Application.Current.MainWindow).Places.Visibility = System.Windows.Visibility.Visible;
                ((MainWindow)System.Windows.Application.Current.MainWindow).Places_Border.Visibility = System.Windows.Visibility.Visible;

                ((MainWindow)System.Windows.Application.Current.MainWindow).Times.Visibility = System.Windows.Visibility.Visible;
                ((MainWindow)System.Windows.Application.Current.MainWindow).Times_Border.Visibility = System.Windows.Visibility.Visible;

                ((MainWindow)System.Windows.Application.Current.MainWindow).Katakana_Input_Border.Visibility = System.Windows.Visibility.Visible;
                ((MainWindow)System.Windows.Application.Current.MainWindow).Katakana_Pre_text.Visibility = System.Windows.Visibility.Visible;
                ((MainWindow)System.Windows.Application.Current.MainWindow).InputSentence_Kata.Visibility = System.Windows.Visibility.Visible;
            }
        }

        /// summary
        // method for showing verbgroup checkboxes
        /// summary 
        public void Verb_Subcategories(Boolean p)
        {
            if (p == true)
            {
                ((MainWindow)System.Windows.Application.Current.MainWindow).group1_verb.IsChecked = false;
                ((MainWindow)System.Windows.Application.Current.MainWindow).group2_verb.IsChecked = false;
                ((MainWindow)System.Windows.Application.Current.MainWindow).group3_verb.IsChecked = false;

                ((MainWindow)System.Windows.Application.Current.MainWindow).group1_verb.Visibility = System.Windows.Visibility.Visible;
                ((MainWindow)System.Windows.Application.Current.MainWindow).group2_verb.Visibility = System.Windows.Visibility.Visible;
                ((MainWindow)System.Windows.Application.Current.MainWindow).group3_verb.Visibility = System.Windows.Visibility.Visible;

                ((MainWindow)System.Windows.Application.Current.MainWindow).group1_choice.IsChecked = false;
                ((MainWindow)System.Windows.Application.Current.MainWindow).group1_choice.IsChecked = false;
                ((MainWindow)System.Windows.Application.Current.MainWindow).group1_choice.IsChecked = false;

                ((MainWindow)System.Windows.Application.Current.MainWindow).group1_choice.Visibility = System.Windows.Visibility.Visible;
                ((MainWindow)System.Windows.Application.Current.MainWindow).group2_choice.Visibility = System.Windows.Visibility.Visible;
                ((MainWindow)System.Windows.Application.Current.MainWindow).group3_choice.Visibility = System.Windows.Visibility.Visible;
            }
            else
            {
                ((MainWindow)System.Windows.Application.Current.MainWindow).group1_verb.Visibility = System.Windows.Visibility.Collapsed;
                ((MainWindow)System.Windows.Application.Current.MainWindow).group2_verb.Visibility = System.Windows.Visibility.Collapsed;
                ((MainWindow)System.Windows.Application.Current.MainWindow).group3_verb.Visibility = System.Windows.Visibility.Collapsed;

                ((MainWindow)System.Windows.Application.Current.MainWindow).group1_choice.Visibility = System.Windows.Visibility.Collapsed;
                ((MainWindow)System.Windows.Application.Current.MainWindow).group2_choice.Visibility = System.Windows.Visibility.Collapsed;
                ((MainWindow)System.Windows.Application.Current.MainWindow).group3_choice.Visibility = System.Windows.Visibility.Collapsed;
            }
        }
    }
}
