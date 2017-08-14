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
        Boolean firstGrid = true;
        Boolean secondGrid = false;
        Boolean thirdGrid = false;
        public WindowLvl1()
        {
            InitializeComponent();
        }

        public void Second_Window_Loaded(object sender, RoutedEventArgs e)
        {
            First_alphabet_grid.Margin = new Thickness(178, 112, 0, 0); //sets location of alphabet grid
            Second_alphabet_grid.Visibility = System.Windows.Visibility.Collapsed;
            Third_alphabet_grid.Visibility = System.Windows.Visibility.Collapsed;
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
            //Margin = "178,112,0,0"
        }

        private void Button_Click_Previous(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_Next(object sender, RoutedEventArgs e)
        {
            if (firstGrid == true)
            {
                firstGrid = false;
                First_alphabet_grid.Visibility = System.Windows.Visibility.Collapsed;
                secondGrid = true;
                Second_alphabet_grid.Visibility = System.Windows.Visibility.Visible;
                Second_alphabet_grid.Margin = new Thickness(178, 112, 0, 0);
            }
            else if (secondGrid == true)
            {
                secondGrid = false;
                Second_alphabet_grid.Visibility = System.Windows.Visibility.Collapsed;
                thirdGrid = true;
                Third_alphabet_grid.Visibility = System.Windows.Visibility.Visible;
                Third_alphabet_grid.Margin = new Thickness(178, 112, 0, 0);
            }
            else if(thirdGrid == true)
            {
                thirdGrid = false;
                Third_alphabet_grid.Visibility = System.Windows.Visibility.Collapsed;
                firstGrid = true;
                First_alphabet_grid.Visibility = System.Windows.Visibility.Visible;
                First_alphabet_grid.Margin = new Thickness(178, 112, 0, 0);
            }

        }
    }
}
