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
            
            con.Close();
        }

        public void RetrieveKatakanaData(String txt)
        {
            String SelectedNoun = ((MainWindow)System.Windows.Application.Current.MainWindow).listBox.SelectedItem.ToString();

            DatabaseCon db = new DatabaseCon();
            db.DBCon(true);
            SqlCommand cmd = new SqlCommand("select * from noun_object where object_hira = N'" + SelectedNoun + "'", db.con);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                ((MainWindow)System.Windows.Application.Current.MainWindow).Katakana_input.Content = dr.GetString(3);
            }
            dr.Close();
            db.DBCon(false);
        }
        /// <summary>
        // method for displaying all 3 verb groups
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

            while(dr.Read())
            {
                ((MainWindow)System.Windows.Application.Current.MainWindow).listBox.Items.Add(dr.GetString(1));
                ((MainWindow)System.Windows.Application.Current.MainWindow).listBox2.Items.Add(dr.GetString(2));
            }
            dr.Close();
        }
    }
}
