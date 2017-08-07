using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace WpfApp1
{
    class RetrieveDataFromDB
    {
        /// <summary>
        // method for displaying the rest of the word groups.
        /// </summary>
        public void RetrieveData(String txt)
        {
            SqlConnection con = new SqlConnection("server=(localdb)\\ProjectsV13;database=Japanese;Trusted_Connection=True");
            con.Open();
            //clear listbox
            ((MainWindow)System.Windows.Application.Current.MainWindow).listBox.Items.Clear();
            ((MainWindow)System.Windows.Application.Current.MainWindow).listBox2.Items.Clear();

            if (txt.Equals("Users"))
            {
                SqlCommand cmd = new SqlCommand("select * from users", con);
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    ((MainWindow)System.Windows.Application.Current.MainWindow).listBox.Items.Add(dr.GetString(1));
                    ((MainWindow)System.Windows.Application.Current.MainWindow).listBox2.Items.Add(dr.GetString(2));
                }
                dr.Close();
            }
            if (txt.Equals("Verbs"))
            {
                SqlCommand cmd = new SqlCommand("select * from verb_groups", con);
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    ((MainWindow)System.Windows.Application.Current.MainWindow).listBox.Items.Add(dr.GetString(1));
                    ((MainWindow)System.Windows.Application.Current.MainWindow).listBox2.Items.Add(dr.GetString(2));
                }
                dr.Close();
            }
            if (txt.Equals("Noun"))
            {
                SqlCommand cmd = new SqlCommand("select * from noun_object", con);
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    ((MainWindow)System.Windows.Application.Current.MainWindow).listBox.Items.Add(dr.GetString(1));
                    ((MainWindow)System.Windows.Application.Current.MainWindow).listBox2.Items.Add(dr.GetString(2));
                }
                dr.Close();

                cmd = new SqlCommand("select * from noun_place", con);
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    ((MainWindow)System.Windows.Application.Current.MainWindow).listBox.Items.Add(dr.GetString(1));
                    ((MainWindow)System.Windows.Application.Current.MainWindow).listBox2.Items.Add(dr.GetString(2));
                }
                dr.Close();
            }
            if (txt.Equals("Object"))
            {
                SqlCommand cmd = new SqlCommand("select * from noun_object", con);
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    ((MainWindow)System.Windows.Application.Current.MainWindow).listBox.Items.Add(dr.GetString(1));
                    ((MainWindow)System.Windows.Application.Current.MainWindow).listBox2.Items.Add(dr.GetString(2));
                }
                dr.Close();
            }
            if (txt.Equals("Places"))
            {
                SqlCommand cmd = new SqlCommand("select * from noun_place", con);
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    ((MainWindow)System.Windows.Application.Current.MainWindow).listBox.Items.Add(dr.GetString(1));
                    ((MainWindow)System.Windows.Application.Current.MainWindow).listBox2.Items.Add(dr.GetString(2));
                }
                dr.Close();
            }
            if (txt.Equals("Time"))
            {
                SqlCommand cmd = new SqlCommand("select * from week_time", con);
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    ((MainWindow)System.Windows.Application.Current.MainWindow).listBox.Items.Add(dr.GetString(1));
                    ((MainWindow)System.Windows.Application.Current.MainWindow).listBox2.Items.Add(dr.GetString(2));
                }
                dr.Close();
            }
            if (txt.Equals("Particle"))
            {
                SqlCommand cmd = new SqlCommand("select * from particles", con);
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    ((MainWindow)System.Windows.Application.Current.MainWindow).listBox.Items.Add(dr.GetString(1));
                    ((MainWindow)System.Windows.Application.Current.MainWindow).listBox2.Items.Add(dr.GetString(2));
                }
                dr.Close();
            }
            con.Close();
        }

        public void RetrieveKatakanaData(String txt)
        {
            DatabaseCon db = new DatabaseCon();

            SqlConnection con = new SqlConnection(db.DBCon());
            con.Open();

            String SelectedNoun = ((MainWindow)System.Windows.Application.Current.MainWindow).listBox.SelectedItem.ToString();
            
            // checks for katakana equivelants in the noun tab
            if (txt.Equals("Noun_kata"))
            {
                SqlCommand cmd = new SqlCommand("select * from noun_object where object_hira = N'" + SelectedNoun + "'", con);
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    ((MainWindow)System.Windows.Application.Current.MainWindow).Katakana_input.Content = dr.GetString(3);
                }
                dr.Close();

                SqlCommand cmd2 = new SqlCommand("select * from noun_place where place_hira = N'" + SelectedNoun + "'", con);
                SqlDataReader dr2 = cmd2.ExecuteReader();
                while (dr2.Read())
                {
                    ((MainWindow)System.Windows.Application.Current.MainWindow).Katakana_input.Content = dr2.GetString(3);
                }
                dr2.Close();
            }
            // --||-- in the "names" tab
            if (txt.Equals("Users_kata"))
            {
                //find the equivalent katakana if it exists.
                String chosenIndexNoun = ((MainWindow)System.Windows.Application.Current.MainWindow).listBox.SelectedItem.ToString();

                SqlCommand cmd = new SqlCommand("select * from users where user_hira = N'" + chosenIndexNoun + "'", con);
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    ((MainWindow)System.Windows.Application.Current.MainWindow).Katakana_input.Content = dr.GetString(3);
                }
                dr.Close();
            }
            // --||--
            if (txt.Equals("Object_kata"))
            {
                //find the equivalent katakana if it exists.
                String chosenIndexNoun = ((MainWindow)System.Windows.Application.Current.MainWindow).listBox.SelectedItem.ToString();

                SqlCommand cmd = new SqlCommand("select * from noun_object where object_hira = N'" + chosenIndexNoun + "'", con);
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    ((MainWindow)System.Windows.Application.Current.MainWindow).Katakana_input.Content = dr.GetString(3);
                }
                dr.Close();
            }
            // --||--
            if (txt.Equals("Times_kata"))
            {
                //find the equivalent katakana if it exists.
                String chosenIndexNoun = ((MainWindow)System.Windows.Application.Current.MainWindow).listBox.SelectedItem.ToString();

                SqlCommand cmd = new SqlCommand("select * from week_time where week_day_hira = N'" + chosenIndexNoun + "'", con);
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    ((MainWindow)System.Windows.Application.Current.MainWindow).Katakana_input.Content = dr.GetString(3);
                }
                dr.Close();
            }
            // --||--
            if (txt.Equals("Places_Kata"))
            {
                //find the equivalent katakana if it exists.
                String chosenIndexNoun = ((MainWindow)System.Windows.Application.Current.MainWindow).listBox.SelectedItem.ToString();

                SqlCommand cmd = new SqlCommand("select * from noun_place where place_hira = N'" + chosenIndexNoun + "'", con);
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    ((MainWindow)System.Windows.Application.Current.MainWindow).Katakana_input.Content = dr.GetString(3);
                }
                dr.Close();
            }
        }
        /// <summary>
        // method for displaying all 3 verb groups
        // not used atm.
        /// </summary>
        public void ClearListAndInputValuesForVerbs(String txt1, String txt2, String txt3)
        {
            //clear listbox
            ((MainWindow)System.Windows.Application.Current.MainWindow).listBox.Items.Clear();
            ((MainWindow)System.Windows.Application.Current.MainWindow).listBox2.Items.Clear();

            //create connection
            SqlConnection con = new SqlConnection("server=(localdb)\\ProjectsV13;database=Japanese;Trusted_Connection=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from verb_groups", con);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                ((MainWindow)System.Windows.Application.Current.MainWindow).listBox.Items.Add(dr.GetString(1));
                ((MainWindow)System.Windows.Application.Current.MainWindow).listBox2.Items.Add(dr.GetString(2));
            }
            dr.Close();
        }
    }
}
