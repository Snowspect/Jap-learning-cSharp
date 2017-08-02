using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    class ChangeLayout
    {
        /// <summary>
        // method for changing layout of listboxes
        /// </summary>
        public void ChangeListBoxLayout(Boolean p)
        {
            if(p == true)
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

    }
}
