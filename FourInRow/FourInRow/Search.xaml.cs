using FourInRow.ServiceReference;
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

namespace FourInRow
{
    /// <summary>
    /// Interaction logic for Search.xaml
    /// </summary>
    public partial class Search : Window
    {
        public FourInRowServiceClient Client { get; set; }
        public ClientCallback Callback { get; set; }
        public string Username { get; set; }
        public Search()
        {
            InitializeComponent();
        }

        private void RadioButton_User(object sender, RoutedEventArgs e)
        {
            Client.Search("USR", Username);
        }

        private void RadioButton_Wins(object sender, RoutedEventArgs e)
        {
            Client.Search("WIN", Username);
        }

        private void RadioButton_Loses(object sender, RoutedEventArgs e)
        {
            Client.Search("LOSE", Username);
        }

        private void RadioButton_Games(object sender, RoutedEventArgs e)
        {
            Client.Search("GAME", Username);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Callback.srch += searchfunc;
        }
        private void searchfunc(string[] s)
        {
            Srchlst.ItemsSource = s;
        }
    }
}
