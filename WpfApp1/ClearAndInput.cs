using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    class ClearAndInput
    {
        public ClearAndInput()
        {
        }

        public void ClearListAndInputValues(String txt)
        {
            //clear listbox
            ((MainWindow)System.Windows.Application.Current.MainWindow).listBox.Items.Clear();

            string[] category_Display = System.IO.File.ReadAllLines(@"c:\users\tooth\onedrive\dokumenter\visual studio 2017\Projects\WpfApp1\WpfApp1\"+txt+".txt");

            //display content
            for (int i = 0; i < category_Display.Length; i++)
            {
                ((MainWindow)System.Windows.Application.Current.MainWindow).listBox.Items.Add(category_Display[i]);
            }
        }
        
        //special method just for verb button
        public void ClearListAndInputValuesForVerbs(String txt1, String txt2, String txt3)
        {
            //clear listbox
            ((MainWindow)System.Windows.Application.Current.MainWindow).listBox.Items.Clear();

            String[] group1_Verbs_Display = System.IO.File.ReadAllLines(@"c:\users\tooth\onedrive\dokumenter\visual studio 2017\Projects\WpfApp1\WpfApp1\" + txt1 + ".txt");
            String[] group2_Verbs_Display = System.IO.File.ReadAllLines(@"c:\users\tooth\onedrive\dokumenter\visual studio 2017\Projects\WpfApp1\WpfApp1\" + txt2 + ".txt");
            String[] group3_Verbs_Display = System.IO.File.ReadAllLines(@"c:\users\tooth\onedrive\dokumenter\visual studio 2017\Projects\WpfApp1\WpfApp1\" + txt3 + ".txt");

            //display content
            for (int i = 0; i < group1_Verbs_Display.Length; i++)
            {
                ((MainWindow)System.Windows.Application.Current.MainWindow).listBox.Items.Add(group1_Verbs_Display[i]);
            }
            for (int i = 0; i < group2_Verbs_Display.Length; i++)
            {
                ((MainWindow)System.Windows.Application.Current.MainWindow).listBox.Items.Add(group2_Verbs_Display[i]);
            }
            for (int i = 0; i < group3_Verbs_Display.Length; i++)
            {
                ((MainWindow)System.Windows.Application.Current.MainWindow).listBox.Items.Add(group3_Verbs_Display[i]);
            }
        }
    }
}
