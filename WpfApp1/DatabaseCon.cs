using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace WpfApp1
{
    class DatabaseCon
    {
        //needed to be able to reference it from other classes
        public SqlConnection con;

        public void DBCon(Boolean p)
        {
            SqlConnection con = new SqlConnection("server=(localdb)\\ProjectsV13;database=Japanese;Trusted_Connection=True");
            if (p == true)
            {
                con.Open();
            }
            else
            {
                con.Close();
            }
        }

    }
}
