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
        public String DBCon()
        {
            return "server=(localdb)\\ProjectsV13;database=Japanese;Trusted_Connection=True";
        }

    }
}
