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
        public void InsertData(String button, String table, String column1, String column2, String column3)
        {
            DatabaseCon db = new DatabaseCon();
            SqlConnection con = new SqlConnection(db.DBCon());
            con.Open();

            if (button.Equals("noun") || button.Equals("users") || button.Equals("object") || button.Equals("places") || button.Equals("times"))
            {
                String jap_Input = ((MainWindow)System.Windows.Application.Current.MainWindow).InputSentence_Jap.ToString();
                String eng_Input = ((MainWindow)System.Windows.Application.Current.MainWindow).InputSentence_Eng.ToString();
                String kata_Input = ((MainWindow)System.Windows.Application.Current.MainWindow).InputSentence_Kata.ToString();

                SqlCommand cmd = new SqlCommand("insert into " + table + "(" + column1 + "," + column2 + "," + column3 + ") values(N'" + jap_Input + "', N'" + eng_Input + "',N'" + kata_Input + "')", con);
                cmd.ExecuteNonQuery();
            }
            else
            {
                String jap_Input = ((MainWindow)System.Windows.Application.Current.MainWindow).InputSentence_Jap.ToString();
                String eng_Input = ((MainWindow)System.Windows.Application.Current.MainWindow).InputSentence_Eng.ToString();
                SqlCommand cmd = new SqlCommand("insert into " + table + "(" + column1 + "," + column2 + ") values(N'" + jap_Input + "',N'" + eng_Input + "')", con);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
