using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for WindowLvl1.xaml
    /// </summary>
    public partial class WindowLvl1 : Window
    {
        public WindowLvl1()
        {
            InitializeComponent();
        }

        public void Second_Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void Level_1_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void Level_2_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void Level_3_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void Level_4_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void Level_5_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void Level_6_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void Level_7_Checked(object sender, RoutedEventArgs e)
        {

        }
        private void Level_8_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void Level_9_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void Level_FM_Checked(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            mw.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            mw.Show();
            this.Close();
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ListView_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ListView_SelectionChanged_2(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ListView_SelectionChanged_3(object sender, SelectionChangedEventArgs e)
        {

        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void RadioButton_Checked_1(object sender, RoutedEventArgs e)
        {

        }
    }
}
