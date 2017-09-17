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
        public void RetrieveAllStructures()
        {
            ((MainWindow)System.Windows.Application.Current.MainWindow).listBox.Items.Clear();
            ((MainWindow)System.Windows.Application.Current.MainWindow).listBox2.Items.Clear();

            DatabaseCon db = new DatabaseCon();
            SqlConnection con = new SqlConnection(db.DBCon());
            con.Open();

            SqlCommand cmd = new SqlCommand("select * from patterns", con);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                ((MainWindow)System.Windows.Application.Current.MainWindow).structureArray.Add(dr.GetString(1));
            }
            dr.Close();
            con.Close();
        }
        public void RetrieveStructure(int chosenStructure)
        {
            DatabaseCon db = new DatabaseCon();
            SqlConnection con = new SqlConnection(db.DBCon());
            con.Open();

            SqlCommand cmd = new SqlCommand("select * from patterns where pattern_index = " + chosenStructure, con);
            SqlDataReader dr = cmd.ExecuteReader();

            string dissect = "";
            while (dr.Read())
            {
                ((MainWindow)System.Windows.Application.Current.MainWindow).listBox2.Items.Add(dr.GetString(1));
                dissect = dr.GetString(1);
            }
            dr.Close();

            List<string> conjugations = new List<string>();
            List<string> objects = new List<string>();
            List<string> places = new List<string>();
            List<string> numbers = new List<string>();
            List<string> special = new List<string>();
            List<string> verbs = new List<string>();
            List<string> times = new List<string>();
            List<string> users = new List<string>();

            if (1 == 1)
            {
                cmd = new SqlCommand("select * from patterns", con);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    ((MainWindow)System.Windows.Application.Current.MainWindow).structureArray.Add(dr.GetString(1));
                }
                dr.Close();

                cmd = new SqlCommand("select * from conjugation", con);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    conjugations.Add(dr.GetString(1));
                }
                dr.Close();

                cmd = new SqlCommand("select * from noun_object", con);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    objects.Add(dr.GetString(1));
                }
                dr.Close();

                cmd = new SqlCommand("select * from noun_place", con);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    places.Add(dr.GetString(1));
                }
                dr.Close();

                cmd = new SqlCommand("select * from numbers", con);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    numbers.Add(dr.GetString(1));
                }
                dr.Close();

                cmd = new SqlCommand("select * from users", con);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    users.Add(dr.GetString(1));
                }
                dr.Close();

                cmd = new SqlCommand("select * from verb_groups", con);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    verbs.Add(dr.GetString(1));
                }
                dr.Close();

                cmd = new SqlCommand("select * from week_time", con);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    times.Add(dr.GetString(1));
                }
                dr.Close();
            }

            Random nrd = new Random();
            string time = "";
            string noun1 = "";
            string noun2 = "";
            string object1 = "";
            string object2 = "";
            string person = "";
            string place = "";
            string conjugation = "";
            string verb_notCJ = "";
            string verb_CJ = "";

            if (dissect.Equals("time+object+を+verb"))
            {
                cmd = new SqlCommand("select * from week_time where week_day_index = " + nrd.Next(1, times.Count), con);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    time = dr.GetString(1);
                }
                dr.Close();
                cmd = new SqlCommand("select * from noun_object where object_index = " + nrd.Next(1, objects.Count), con);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    object1 = dr.GetString(1);
                }
                dr.Close();
                cmd = new SqlCommand("select * from verb_groups where verb_index = " + nrd.Next(1, verbs.Count), con);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    verb_notCJ = dr.GetString(1);
                }
                dr.Close();
                ((MainWindow)System.Windows.Application.Current.MainWindow).InputSentence_Jap.Text = "" + time + object1 + "を" + verb_notCJ;
            }
            if (dissect.Equals("(person)+noun+は+verb"))
            {
                cmd = new SqlCommand("select * from users where user_index = " + nrd.Next(1, users.Count), con);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    time = dr.GetString(1);
                }
                dr.Close();

                cmd = new SqlCommand("select * from noun_object where object_index = " + nrd.Next(1, objects.Count), con);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    objects.Add(dr.GetString(1));
                }
                dr.Close();

                cmd = new SqlCommand("select * from verb_groups where verb_index = " + nrd.Next(1, verbs.Count), con);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    verbs.Add(dr.GetString(1));
                }
                dr.Close();

                Random rnd = new Random();
                cmd = new SqlCommand("select * from users", con); 
                dr = cmd.ExecuteReader();
                while(dr.Read())
                {
                    users.Add(dr.GetString(1));
                }
                dr.Close();
            }
            dr.Close();
            con.Close();
        }
    }
}
