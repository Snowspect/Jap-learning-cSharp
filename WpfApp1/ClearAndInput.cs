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
            string[] category_Display_Jap = { };
            string[] category_Display_Eng = { };

            //clear listbox
            ((MainWindow)System.Windows.Application.Current.MainWindow).listBox.Items.Clear();
            ((MainWindow)System.Windows.Application.Current.MainWindow).listBox2.Items.Clear();

            category_Display_Jap = System.IO.File.ReadAllLines(@"C:\Users\Dan\Source\Repos\Ladtos2\WpfApp1\" + txt + "_Jap.txt");
            category_Display_Eng = System.IO.File.ReadAllLines(@"C:\Users\Dan\Source\Repos\Ladtos2\WpfApp1\" + txt + "_Eng.txt");


            //string[] category_Display = System.IO.File.ReadAllLines(@"c:\users\tooth\onedrive\dokumenter\visual studio 2017\Projects\WpfApp1\WpfApp1\"+txt+".txt");

            //display content
            for (int i = 0; i < category_Display_Jap.Length; i++)
            {
                if(txt.Equals("Sentence_Pattern") || txt.Equals("Conjugation"))
                {
                    ((MainWindow)System.Windows.Application.Current.MainWindow).listBox.Items.Add(category_Display_Jap[i]);
                }
                else
                {
                    ((MainWindow)System.Windows.Application.Current.MainWindow).listBox.Items.Add(category_Display_Jap[i]);
                    ((MainWindow)System.Windows.Application.Current.MainWindow).listBox2.Items.Add(category_Display_Eng[i]);
                }

            }
        }
        
        //special method just for verb button
        public void ClearListAndInputValuesForVerbs(String txt1, String txt2, String txt3)
        {
            //clear listbox
            ((MainWindow)System.Windows.Application.Current.MainWindow).listBox.Items.Clear();
            ((MainWindow)System.Windows.Application.Current.MainWindow).listBox2.Items.Clear();

            String[] group1_Verbs_Display_Jap = System.IO.File.ReadAllLines(@"C:\Users\Dan\Source\Repos\Ladtos2\WpfApp1\" + txt1 + "_Jap.txt");
            String[] group2_Verbs_Display_Jap = System.IO.File.ReadAllLines(@"C:\Users\Dan\Source\Repos\Ladtos2\WpfApp1\" + txt2 + "_Jap.txt");
            String[] group3_Verbs_Display_Jap = System.IO.File.ReadAllLines(@"C:\Users\Dan\Source\Repos\Ladtos2\WpfApp1\" + txt3 + "_Jap.txt");
            String[] group1_Verbs_Display_Eng = System.IO.File.ReadAllLines(@"C:\Users\Dan\Source\Repos\Ladtos2\WpfApp1\" + txt1 + "_Eng.txt");
            String[] group2_Verbs_Display_Eng = System.IO.File.ReadAllLines(@"C:\Users\Dan\Source\Repos\Ladtos2\WpfApp1\" + txt2 + "_Eng.txt");
            String[] group3_Verbs_Display_Eng = System.IO.File.ReadAllLines(@"C:\Users\Dan\Source\Repos\Ladtos2\WpfApp1\" + txt3 + "_Eng.txt");



            //String[] group1_Verbs_Display = System.IO.File.ReadAllLines(@"c:\users\tooth\onedrive\dokumenter\visual studio 2017\Projects\WpfApp1\WpfApp1\" + txt1 + ".txt");
            //String[] group2_Verbs_Display = System.IO.File.ReadAllLines(@"c:\users\tooth\onedrive\dokumenter\visual studio 2017\Projects\WpfApp1\WpfApp1\" + txt2 + ".txt");
            //String[] group3_Verbs_Display = System.IO.File.ReadAllLines(@"c:\users\tooth\onedrive\dokumenter\visual studio 2017\Projects\WpfApp1\WpfApp1\" + txt3 + ".txt");

            //display content
            for (int i = 0; i < group1_Verbs_Display_Jap.Length; i++)
            {
                ((MainWindow)System.Windows.Application.Current.MainWindow).listBox.Items.Add(group1_Verbs_Display_Jap[i]);
                ((MainWindow)System.Windows.Application.Current.MainWindow).listBox2.Items.Add(group1_Verbs_Display_Eng[i]);
            }
            for (int i = 0; i < group2_Verbs_Display_Jap.Length; i++)
            {
                ((MainWindow)System.Windows.Application.Current.MainWindow).listBox.Items.Add(group2_Verbs_Display_Jap[i]);
                ((MainWindow)System.Windows.Application.Current.MainWindow).listBox2.Items.Add(group2_Verbs_Display_Eng[i]);
            }
            for (int i = 0; i < group3_Verbs_Display_Jap.Length; i++)
            {
                ((MainWindow)System.Windows.Application.Current.MainWindow).listBox.Items.Add(group3_Verbs_Display_Jap[i]);
                ((MainWindow)System.Windows.Application.Current.MainWindow).listBox2.Items.Add(group3_Verbs_Display_Eng[i]);
            }
        }
    }
}
