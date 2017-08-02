using System;
using System.Windows;
using WpfApp1;

/// <summary>
/// This class holds the function of writing to the correct files when information is entered and submitted
/// </summary>
public class RadioButtonClass
{
    /// <summary>
    // method for checking what radiobutton is pressed what element is pressed.
    /// </summary>
    public void CheckifChecked()
    {
        if (((MainWindow)System.Windows.Application.Current.MainWindow).Verb.IsChecked == true)
        {
            if (((MainWindow)System.Windows.Application.Current.MainWindow).group1_verb.IsChecked == true)
            {
                Insert_element("group1_verbs");
            }
            if (((MainWindow)System.Windows.Application.Current.MainWindow).group2_verb.IsChecked == true)
            {
                Insert_element("group2_verbs");
            }
            if (((MainWindow)System.Windows.Application.Current.MainWindow).group3_verb.IsChecked == true)
            {
                Insert_element("group3_verbs");
            }
        }
        if (((MainWindow)System.Windows.Application.Current.MainWindow).Noun.IsChecked == true)
        {
            Insert_element("Noun");
        }
        if (((MainWindow)System.Windows.Application.Current.MainWindow).Particle.IsChecked == true)
        {
            Insert_element("Particle");
        }
        if (((MainWindow)System.Windows.Application.Current.MainWindow).Conjugation.IsChecked == true)
        {
            Insert_element("Conjugation");
        }
        if (((MainWindow)System.Windows.Application.Current.MainWindow).Number.IsChecked == true)
        {
            Insert_element("Number");
        }
        if (((MainWindow)System.Windows.Application.Current.MainWindow).Sentence_Pattern.IsChecked == true)
        {
            Insert_element("Sentence_Pattern");
        }
        if (((MainWindow)System.Windows.Application.Current.MainWindow).Special_cases.IsChecked == true)
        {
            Insert_element("Special_Cases");
        }
        if (((MainWindow)System.Windows.Application.Current.MainWindow).Sentence.IsChecked == true)
        {
            Insert_element("Sentence");
        }
        if (((MainWindow)System.Windows.Application.Current.MainWindow).Kanjis.IsChecked == true)
        {
            Insert_element("Kanji");
        }
        if (((MainWindow)System.Windows.Application.Current.MainWindow).Name.IsChecked == true)
        {
            Insert_element("Users");
        }
    }


    /// <summary>
    // Method for writing to files
    /// </summary>
    private void Insert_element(string category)
    {
        //stationary
        //writes the japanese input into the file.
        using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\Users\Dan\Source\Repos\Ladtos2\WpfApp1\" + category + "_Jap.txt", true))

        //laptop
        //using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"c:\users\tooth\onedrive\dokumenter\visual studio 2017\Projects\WpfApp1\WpfApp1\" + category + ".txt", true))
        {
            string Texter = ((MainWindow)System.Windows.Application.Current.MainWindow).InputSentence.Text;

            file.WriteLine(Texter);
            ((MainWindow)System.Windows.Application.Current.MainWindow).InputSentence.Text = "";
        }
        //writes the english input into a file
        using (System.IO.StreamWriter file2 = new System.IO.StreamWriter(@"C:\Users\Dan\Source\Repos\Ladtos2\WpfApp1\" + category + "_Eng.txt", true))
        {
            string Texter = ((MainWindow)System.Windows.Application.Current.MainWindow).InputSentence_Eng.Text;
            file2.WriteLine(Texter);
            ((MainWindow)System.Windows.Application.Current.MainWindow).InputSentence_Eng.Text = "";
        }
    }
}