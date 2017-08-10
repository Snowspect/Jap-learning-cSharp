using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace WpfApp1
{
    class DatabaseHandling
    {
        /// <summary>
        // method for displaying the rest of the word groups.
        /// </summary>
        public void RetrieveData(String table)
        {
            DatabaseCon db = new DatabaseCon();
            SqlConnection con = new SqlConnection(db.DBCon());
            con.Open();

            ((MainWindow)System.Windows.Application.Current.MainWindow).listBox.Items.Clear();
            ((MainWindow)System.Windows.Application.Current.MainWindow).listBox2.Items.Clear();

            SqlCommand cmd = new SqlCommand("select * from " + table, con);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                ((MainWindow)System.Windows.Application.Current.MainWindow).listBox.Items.Add(dr.GetString(1));
                ((MainWindow)System.Windows.Application.Current.MainWindow).listBox2.Items.Add(dr.GetString(2));
            }
            dr.Close();
            con.Close();
        }
        public void RetrieveKatakanaData(String table, String hiragana_column)
        {
            DatabaseCon db = new DatabaseCon();
            SqlConnection con = new SqlConnection(db.DBCon());
            con.Open();

            String SelectedNoun = ((MainWindow)System.Windows.Application.Current.MainWindow).listBox.SelectedItem.ToString();

            SqlCommand cmd = new SqlCommand("select * from " + table + " where " + hiragana_column + " = N'" + SelectedNoun + "'", con);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                ((MainWindow)System.Windows.Application.Current.MainWindow).Katakana_input.Content = dr.GetString(3);
            }
            dr.Close();
        }
        public void FindPatternExample()
        {
            DatabaseCon db = new DatabaseCon();
            SqlConnection con = new SqlConnection(db.DBCon());
            con.Open();

            String chosenIndexPattern = ((MainWindow)System.Windows.Application.Current.MainWindow).listBox.SelectedItem.ToString();

            SqlCommand cmd = new SqlCommand("select * from patterns where pattern_design = N'" + chosenIndexPattern + "'", con);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                ((MainWindow)System.Windows.Application.Current.MainWindow).Pattern_Box_Example.Content = dr.GetString(2);
            }
            dr.Close();
        }
        public void InsertData(String table, String column1, String column2, String column3)
        {
            DatabaseCon db = new DatabaseCon();
            SqlConnection con = new SqlConnection(db.DBCon());
            con.Open();

            if (table.Equals("users") || table.Equals("noun_object") || table.Equals("noun_place") || table.Equals("week_time"))
            {
                String jap_Input = ((MainWindow)System.Windows.Application.Current.MainWindow).InputSentence_Jap.Text.ToString();
                String eng_Input = ((MainWindow)System.Windows.Application.Current.MainWindow).InputSentence_Eng.Text.ToString();
                String kata_Input = ((MainWindow)System.Windows.Application.Current.MainWindow).InputSentence_Kata.Text.ToString();

                SqlCommand cmd = new SqlCommand("insert into " + table + "(" + column1 + "," + column2 + "," + column3 + ") values(N'" + jap_Input + "', N'" + eng_Input + "',N'" + kata_Input + "')", con);
                cmd.ExecuteNonQuery();

                ((MainWindow)System.Windows.Application.Current.MainWindow).InputSentence_Jap.Clear();
                ((MainWindow)System.Windows.Application.Current.MainWindow).InputSentence_Eng.Clear();
                ((MainWindow)System.Windows.Application.Current.MainWindow).InputSentence_Kata.Clear();

            }
            else if (table.Equals("verb_groups"))
            {
                String jap_Input = ((MainWindow)System.Windows.Application.Current.MainWindow).InputSentence_Jap.Text.ToString();
                String eng_Input = ((MainWindow)System.Windows.Application.Current.MainWindow).InputSentence_Eng.Text.ToString();

                if (((MainWindow)System.Windows.Application.Current.MainWindow).group1_choice.IsChecked == true)
                {
                    SqlCommand cmd = new SqlCommand("insert into " + table + "(" + column1 + "," + column2 + ",verb_group) values(N'" + jap_Input + "',N'" + eng_Input + "'," + 1 + ")", con);
                    cmd.ExecuteNonQuery();
                }
                if (((MainWindow)System.Windows.Application.Current.MainWindow).group2_choice.IsChecked == true)
                {
                    SqlCommand cmd = new SqlCommand("insert into " + table + "(" + column1 + "," + column2 + ",verb_group) values(N'" + jap_Input + "',N'" + eng_Input + "'," + 2 + ")", con);
                    cmd.ExecuteNonQuery();
                }
                if (((MainWindow)System.Windows.Application.Current.MainWindow).group3_choice.IsChecked == true)
                {
                    SqlCommand cmd = new SqlCommand("insert into " + table + "(" + column1 + "," + column2 + ",verb_group) values(N'" + jap_Input + "',N'" + eng_Input + "'," + 3 + ")", con);
                    cmd.ExecuteNonQuery();
                }
                ((MainWindow)System.Windows.Application.Current.MainWindow).InputSentence_Jap.Clear();
                ((MainWindow)System.Windows.Application.Current.MainWindow).InputSentence_Eng.Clear();
            }
            else
            {
                String jap_Input = ((MainWindow)System.Windows.Application.Current.MainWindow).InputSentence_Jap.Text.ToString();
                String eng_Input = ((MainWindow)System.Windows.Application.Current.MainWindow).InputSentence_Eng.Text.ToString();
                SqlCommand cmd = new SqlCommand("insert into " + table + "(" + column1 + "," + column2 + ") values(N'" + jap_Input + "',N'" + eng_Input + "')", con);
                cmd.ExecuteNonQuery();
                ((MainWindow)System.Windows.Application.Current.MainWindow).InputSentence_Jap.Clear();
                ((MainWindow)System.Windows.Application.Current.MainWindow).InputSentence_Eng.Clear();
            }
        }
        public void FindVerbGroup()
        {
            ((MainWindow)System.Windows.Application.Current.MainWindow).group1_verb.IsChecked = false;
            ((MainWindow)System.Windows.Application.Current.MainWindow).group2_verb.IsChecked = false;
            ((MainWindow)System.Windows.Application.Current.MainWindow).group3_verb.IsChecked = false;

            DatabaseCon db = new DatabaseCon();
            SqlConnection con = new SqlConnection(db.DBCon());
            con.Open();

            String selectedVerb = ((MainWindow)System.Windows.Application.Current.MainWindow).listBox.SelectedItem.ToString();

            SqlCommand cmd = new SqlCommand("select * from verb_groups where verb_hira = N'" + selectedVerb + "'", con);
            SqlDataReader dr = cmd.ExecuteReader();

            int verbGroup = 0;

            while (dr.Read())
            {
                verbGroup = dr.GetInt32(3);
            }
            if (verbGroup == 1)
            {
                ((MainWindow)System.Windows.Application.Current.MainWindow).group1_verb.IsChecked = true;
            }
            else if (verbGroup == 2)
            {
                ((MainWindow)System.Windows.Application.Current.MainWindow).group2_verb.IsChecked = true;
            }
            else
            {
                ((MainWindow)System.Windows.Application.Current.MainWindow).group3_verb.IsChecked = true;
            }
            dr.Close();
        }
    }
}
