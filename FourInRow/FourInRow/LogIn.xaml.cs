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
using System.ServiceModel;
using _4InARowWCFService;

namespace FourInRow
{
    /// <summary>
    /// Interaction logic for LogIn.xaml
    /// </summary>
    public partial class LogIn : Window
    {
        
        public LogIn()
        {
            InitializeComponent();
        }

        private void ButtonPlay_Click(object sender, RoutedEventArgs e)
        {

            InitializeComponent();
            MainWindow mainWindow = new MainWindow();
            mainWindow.off_on = false;
            mainWindow.Show();

        }

        private void ButtonRegister_Click(object sender, RoutedEventArgs e)
        {
            InitializeComponent();
            Register R = new Register();
            R.Show();

        }
        
        private void ButtonConnect_Click(object sender, RoutedEventArgs e)
        {
            ClientCallback callback=new ClientCallback();
            FourInRowServiceClient client=new FourInRowServiceClient(new InstanceContext(callback));
            if (client.LogIn(tbUsername.Text, tbPassword.Password))
            {
                Online online = new Online();
                online.usrLbl.Content = "ID:"+tbUsername.Text.ToUpper();
                online.Username = tbUsername.Text.ToString();
                online.Client = client;
                online.Callback = callback;
                this.Close();
                online.Show();
            }
            else
                MessageBox.Show("Failed to connect. please check the username and password.");
          
        
        }


    }
}
