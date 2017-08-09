using System;
using System.Windows;
using WpfApp1;

/// <summary>
/// This class holds the function of writing to the correct files when information is entered and submitted
/// </summary>
public class RadioButtonClass
{
    /// <summary>
    // method for inputting data into files atm.
    /// </summary>
    public void CheckifChecked()
    {
        DatabaseHandling dbh = new DatabaseHandling();

        if (((MainWindow)System.Windows.Application.Current.MainWindow).Verb.IsChecked == true)
        {
            dbh.InsertData("verb_groups", "verb_hira", "verb_eng", "verb_group");
        }
        if (((MainWindow)System.Windows.Application.Current.MainWindow).Name.IsChecked == true)
        {
            dbh.InsertData("users", "user_hira", "user_eng", "user_kata");
        }
        if (((MainWindow)System.Windows.Application.Current.MainWindow).Object.IsChecked == true)
        {
            dbh.InsertData("noun_object", "object_hira", "object_eng", "object_kata");
        }
        if (((MainWindow)System.Windows.Application.Current.MainWindow).Places.IsChecked == true)
        {
            dbh.InsertData("noun_place", "place_hira", "place_eng", "place_kata");
        }
        if (((MainWindow)System.Windows.Application.Current.MainWindow).Times.IsChecked == true)
        {
            dbh.InsertData("week_time", "week_day_hira", "week_day_eng", "week_day_kata");
        }
        if (((MainWindow)System.Windows.Application.Current.MainWindow).Particle.IsChecked == true)
        {
            dbh.InsertData("particles", "particle_hira", "particle_eng", "-");
        }
        if (((MainWindow)System.Windows.Application.Current.MainWindow).Conjugation.IsChecked == true)
        {
            dbh.InsertData("conjugation", "conjugation_hira", "conjugation_eng", "-");
        }
        if (((MainWindow)System.Windows.Application.Current.MainWindow).Number.IsChecked == true)
        {
            dbh.InsertData("numbers", "number_hira", "number_eng", "-");
        }
        if (((MainWindow)System.Windows.Application.Current.MainWindow).Sentence_Pattern.IsChecked == true)
        {
            dbh.InsertData("patterns", "pattern_design", "pattern_example", "-");
        }
        if (((MainWindow)System.Windows.Application.Current.MainWindow).Special_cases.IsChecked == true)
        {
            dbh.InsertData("special", "special_hira", "special_eng", "-");
        }
        if (((MainWindow)System.Windows.Application.Current.MainWindow).Sentence.IsChecked == true)
        {
            dbh.InsertData("sentences", "sentence_hira", "sentence_eng", "-");
        }
        if (((MainWindow)System.Windows.Application.Current.MainWindow).Kanjis.IsChecked == true)
        {
            dbh.InsertData("kanji", "kanji_kanji", "kanji_eng", "-");
        }
    }
}