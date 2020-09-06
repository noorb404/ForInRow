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
using FourInRow.ServiceReference;
using System.Threading;

namespace FourInRow
{
    /// <summary>
    /// Interaction logic for Online.xaml
    /// </summary>
    public partial class Online : Window
    {
        public FourInRowServiceClient Client { get; set; }
        public ClientCallback Callback { get; set; }
        public string Username { get; set; }
        public MainWindow board;
        public delegate void myshow();
        myshow show;
        SolidColorBrush clr = new SolidColorBrush();
        public Online()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Callback.displayChallenge += DisplayChallenge;
            Callback.updateUsers += UpdateUsers;
            Callback.updateInfo += UpdateInfo;
            Callback.newStep += UpdateNewStep;
        }

        private void UpdateInfo(string s)
        {
            ProfileList.Items.Clear();
            ProfileList.Items.Add(s);
        }
        private void UpdateUsers(IEnumerable<string> users)
        {
            PlayersList.ItemsSource = users;
        }
        private void UpdateNewStep(double loc)
        {
            board.updateBallStep(loc);
        }
        private void updateNewStepClient(double colNum)
        {
            Client.AddStepToTheBoard(colNum, Username);
        }
        private void Window_Closed(object sender, EventArgs e)
        {
            try
            {
                Client.LogOut(Username);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            finally
            {
                System.Environment.Exit(System.Environment.ExitCode);
            }
        }

        private void Button_Search(object sender, RoutedEventArgs e)
        {
            Search searchWindow = new Search();
            searchWindow.Client = Client;
            searchWindow.Callback = Callback;
            searchWindow.Username = Username;
            searchWindow.Show();
        }

        private void Button_Info(object sender, RoutedEventArgs e)
        {
            Client.ShowInfo(Username,PlayersList.SelectedItem as string);
        }

        private void Button_Challenge(object sender, RoutedEventArgs e)
        {
            bool answer = false;
            board = new MainWindow();
            board.newStepInBoard += updateNewStepClient;
            if (PlayersList.SelectedItem != null)
            {
                answer = Client.SendChallenge(Username,
                       PlayersList.SelectedItem as string);

                if (answer == true)
                {
                    MessageBox.Show(PlayersList.SelectedItem as string + " Accepted your CHALLENGE!");
                    board.turn = true;
                    board.username = Username;
                    board.Title = "Connected Four - id: " + Username;
                    clr.Color = Color.FromRgb(255, 0, 0);
                    board.CurrentPlayerColor = clr;
                    board.Client = Client;
                    show = board.mshow;
                    // Client.LogOut(Username);
                    //board.Show();
                    show();
                    board.clrLbl.Foreground = clr;
                    board.clrLbl.Content = "You Are Red! Good luck.";
                }
                else MessageBox.Show(PlayersList.SelectedItem as string + " Is AFRAID to play.");
            }

            else
            {
                MessageBox.Show("Please choose a player from the list of Online players.");
            }

        }
        private bool DisplayChallenge(string fromClient)
        {
            MessageBoxResult res = MessageBoxResult.None;
            board = new MainWindow();
            board.newStepInBoard += updateNewStepClient;
            while (res == MessageBoxResult.None)
            {
                res = (MessageBox.Show(fromClient + " Challenged You,do you accept?", "Game resquest",
                                 MessageBoxButton.YesNo));
                if (res == MessageBoxResult.Yes)
                {
                    board.turn = false;
                    board.username = Username;
                    board.Title = "Connected Four - id: " + Username;
                    clr.Color = Color.FromRgb(255, 255, 0);
                    board.CurrentPlayerColor = clr;
                    board.Client = Client;
                    //Client.LogOut(Username);
                    //board.Show();
                    show = board.mshow;
                    show();
                    board.clrLbl.Foreground = clr;
                    board.clrLbl.Content = "You Are Yellow! Good luck.";
                    return true;
                }
                if (res == MessageBoxResult.No) return false;
            }
            return false;
        }
      
    }
}
