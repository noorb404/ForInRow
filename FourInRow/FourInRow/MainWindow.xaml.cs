using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using FourInRow.ServiceReference;


namespace FourInRow
{   /***************************************GAME CODE***********************************************/
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            startGameBord();
            //reset = MyCanvas;
        }
        SolidColorBrush redcolor = new SolidColorBrush(Color.FromRgb(255, 0, 0));
        SolidColorBrush yellowcolor = new SolidColorBrush(Color.FromRgb(255, 255, 0));
        public SolidColorBrush CurrentPlayerColor = new SolidColorBrush();
        public FourInRowServiceClient Client { get; set; }
        private int[,] GameBoard = new int[7, 6];
        private int clr = 0;
        private int pos = 0;
        private int[] IJ = new int[2];
        public bool turn = true;
        public bool off_on = true;/*true means online . false means offline*/
        public string username { get; set; }
        public int onetimeflag = 1;
        public delegate void SendColNumDelegate(double colNum);
        public event SendColNumDelegate newStepInBoard;


        public void startGameBord()
        {
           
            int i = 0, j = 0;
            for (i = 0; i < 7; i++)
            {
                for (j = 0; j < 6; j++)
                {
                    GameBoard[i, j] = 0;
                }
            }
        }
        public void oneTimeFunc()
        {
            if (onetimeflag == 1)
            {
                onetimeflag = 0;
               
            }
        }
        bool isOutOfRange(int i, int j)
        {
            if (i > 6 && j > 5)
                return true;
            else
                return false;

        }
        int GetPos(Ball ball)
        {
            int p;
            if (ball.X < 70)
                p = 0;
            else if (ball.X < 160)
                p = 1;
            else if (ball.X < 250)
                p = 2;
            else if (ball.X < 340)
                p = 3;
            else if (ball.X < 430)
                p = 4;
            else if (ball.X < 520)
                p = 5;
            else
                p = 6;
            int i = 5, r = -1;
            for (i = 5; i >= 0; i--)
            {
                if (GameBoard[p, i] == 0)
                {
                    if (ball.EL.Fill == yellowcolor)
                        GameBoard[p, i] = 1;
                    else
                        GameBoard[p, i] = 2;
                    r = i;
                    break;
                }
            }
            if (r != -1)
            {
                IJ[0] = p; IJ[1] = r;
            }
            switch (r)
            {
                case 0:
                    r = 4;
                    break;
                case 1:
                    r = 58;
                    break;
                case 2:
                    r = 110;
                    break;
                case 3:
                    r = 165;
                    break;
                case 4:
                    r = 220;
                    break;
                case 5:
                    r = 272;
                    break;

            }
            return r;
        }
        public void mshow()
        {
            Show();
        }
        private bool Tie()
        {
            int i = 0, j = 0;
            for (i = 0; i < 7; i++)
            {
                if (GameBoard[i, j] == 0)
                    return false;
            }
            return true;
        }
        private int checkWinner()
        {
            int i = -1, j = 0, cnt = 0, C = 0;
            int[] count = new int[4];
            while (i < 6)
            {
                /*****************COLUMONS*******************/
                while (C == 0 && i < 6)
                {
                    i++;
                    C = GameBoard[IJ[0], i];
                }
                if (GameBoard[IJ[0], i] != 0 && GameBoard[IJ[0], i] == C)
                {
                    cnt++;
                    if (cnt == 4)
                        return C;
                }
                else if (GameBoard[IJ[0], i] != 0)
                {
                    C = GameBoard[IJ[0], i];
                    cnt = 0;
                }
                i++;
            }
            /*****************ROWS****************/
            i = 0; C = 0; cnt = 0;
            while (i < 7)
            {
                while (C == 0 && i < 6)
                {
                    C = GameBoard[i, IJ[1]];
                    if (C != 0) break;
                    i++;
                }
                if (GameBoard[i, IJ[1]] != 0 && GameBoard[i, IJ[1]] == C)
                {
                    cnt++;
                    if (cnt == 4)
                        return C;
                }
                else
                {
                    C = GameBoard[i, IJ[1]];
                    cnt = 0;
                }
                i++;
            }
            /******************************************/
            i = 0; j = 0;
            int k = 0;
            C = GameBoard[IJ[0], IJ[1]];
            if (IJ[0] - IJ[1] >= 0)
            {
                i = IJ[0] - IJ[1];
                j = 0;
            }
            else
            {
                i = 0;
                j = IJ[0] - IJ[1];
                j *= -1;
            }
            while ((i + k) < 7 && (j + k) < 6 && (GameBoard[i + k, j + k] != C))
            {
                i++; j++;
            }
            k = 0;
            while ((i + k) < 7 && (j + k) < 6 && (GameBoard[i + k, j + k] == C))
            {
                k++;
                if (k == 4)
                {
                    return C;
                }
            }
            /****************************************/
            i = 0; j = 0;
            k = 0;
            if (IJ[0] + IJ[1] <= 6)
            {
                i = IJ[0] + IJ[1];
                j = 0;
            }
            else
            {
                i = 6;
                j = IJ[0] + IJ[1];
                j -= 6;
            }

            while ((i - k) > -1 && (j + k) < 6 && (GameBoard[i + k, j + k] != C))
            {
                i--; j++;
            }
            if (j == -1) j++;
            while ((i - k) > -1 && (j + k) < 6 && (GameBoard[i - k, j + k] == C))
            {
                k++;
                if (k == 4)
                {
                    return C;
                }
            }

            return 0;
        }


        private void MyCanvas_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (turn || !off_on)
            {
                Point p = e.GetPosition(MyCanvas);
                Ball newBall = new Ball(p);
                int winner;
                if (clr == 0) { clr = 1; newBall.EL.Fill = redcolor; }
                else { clr = 0; newBall.EL.Fill = yellowcolor; }
                pos = GetPos(newBall);
                if (pos != -1)
                {
                    Canvas.SetTop(newBall.EL, 4);
                    Canvas.SetLeft(newBall.EL, newBall.X);
                    MyCanvas.Children.Add(newBall.EL);
                    ThreadPool.QueueUserWorkItem(MoveBall, newBall);
                    if(off_on)
                    newStepInBoard(p.X);
                    winner = checkWinner();
                    if (off_on)
                    {
                        if (winner == 1)
                        {
                            if (CurrentPlayerColor.Color == yellowcolor.Color)
                            {
                                MessageBox.Show(username + " Won!", "Finish");
                                Client.UpdateWin(username);
                            }
                            else
                            {
                                Client.UpdateLose(username);
                                MessageBox.Show(username + " Lose!", "Finish");
                            }
                            MyWindow.Hide();
                        }
                        else if (winner == 2)
                        {
                            if (CurrentPlayerColor.Color == redcolor.Color)
                            {
                                MessageBox.Show(username + " Won!", "Finish");
                                Client.UpdateWin(username);
                            }
                            else
                            {
                                MessageBox.Show(username + " Lose!", "Finish");
                                Client.UpdateLose(username);
                            }

                            MyWindow.Hide();
                        }

                        if (Tie() == true)
                        {
                            MessageBox.Show("Its a tie!", "Finish");
                            MyWindow.Hide();
                        }
                    }
                    else
                    {
                        if (winner == 1)
                        {
                            MessageBox.Show("Yellow Player Won!", "Finish");
                        }
                        else if (winner == 2)
                        {
                            MessageBox.Show("Red Player Won!", "Finish");
                        }

                        if (Tie() == true)
                        {
                            MessageBox.Show("Its a tie!", "Finish");
                            MyWindow.Hide();
                        }
                    }
                }
                else
                {
                    if (clr == 0) clr = 1;
                    else clr = 0;
                }
            }
            turn = false;
        }
        public void updateBallStep(double col)
        {
            Point p = new Point(col, 5);
            Ball newBall = new Ball(p);
            if (clr == 0) { clr = 1; newBall.EL.Fill = redcolor; }
            else { clr = 0; newBall.EL.Fill = yellowcolor; }    
            pos = GetPos(newBall);
            int winner;
            if (pos != -1)
            {
                Canvas.SetTop(newBall.EL, newBall.Y);
                Canvas.SetLeft(newBall.EL, newBall.X);
                MyCanvas.Children.Add(newBall.EL);
                ThreadPool.QueueUserWorkItem(MoveBall, newBall);
                winner = checkWinner();
                if (winner == 1)
                {
                    if (CurrentPlayerColor.Color == yellowcolor.Color)
                    {
                        MessageBox.Show(username + " Won!", "Finish");
                        Client.UpdateWin(username);
                    }
                    else
                    {
                        Client.UpdateLose(username);
                        MessageBox.Show(username + " Lose!", "Finish");
                    }
                    MyWindow.Hide();
                }
                else if (winner == 2)
                {
                    if (CurrentPlayerColor.Color == redcolor.Color)
                    {
                        MessageBox.Show(username + " Won!", "Finish");
                        Client.UpdateWin(username);
                    }
                    else
                    {
                        MessageBox.Show(username + " Lose!", "Finish");
                        Client.UpdateLose(username);
                    }

                    MyWindow.Hide();
                }
                if (Tie() == true)
                {
                    MessageBox.Show("Its a tie!", "Finish");
                    MyWindow.Hide();
                }
            }
            else
            {
                if (clr == 0) clr = 1;
                else clr = 0;
            }
            turn = true;

        }
        void MoveBall(object obj)
        {
            Ball ball = obj as Ball;
            while (ball.Y != pos)
            {
                this.Dispatcher.Invoke((Action)(() =>
                {
                    if (ball.X < 70)
                    {
                        ball.X = 10;
                        ball.Y += ball.Yspeed;
                        if (ball.Y + ball.Yspeed > pos)
                        {
                            ball.Y = pos;
                        }

                    }
                    else if (ball.X < 160)
                    {
                        ball.X = 105;
                        ball.Y += ball.Yspeed;
                        if (ball.Y + ball.Yspeed > pos)
                        {
                            ball.Y = pos;
                        }
                    }
                    else if (ball.X < 250)
                    {
                        ball.X = 195;
                        ball.Y += ball.Yspeed;
                        if (ball.Y + ball.Yspeed > pos)
                        {
                            ball.Y = pos;
                        }
                    }
                    else if (ball.X < 340)
                    {
                        ball.X = 285;
                        ball.Y += ball.Yspeed;
                        if (ball.Y + ball.Yspeed > pos)
                        {
                            ball.Y = pos;
                        }
                    }
                    else if (ball.X < 430)
                    {
                        ball.X = 375;
                        ball.Y += ball.Yspeed;
                        if (ball.Y + ball.Yspeed > pos)
                        {
                            ball.Y = pos;
                        }
                    }
                    else if (ball.X < 520)
                    {
                        ball.X = 465;
                        ball.Y += ball.Yspeed;
                        if (ball.Y + ball.Yspeed > pos)
                        {
                            ball.Y = pos;
                        }
                    }
                    else
                    {
                        ball.X = 555;
                        ball.Y += ball.Yspeed;
                        if (ball.Y + ball.Yspeed > pos)
                        {
                            ball.Y = pos;
                        }
                    }
                    Canvas.SetTop(ball.EL, ball.Y);
                    Canvas.SetLeft(ball.EL, ball.X);
                }));
                Thread.Sleep(10);

            }
        }

        private void MyWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
           /* e.Cancel = true;
            this.Visibility = Visibility.Hidden;
            startGameBord();
            MyCanvas = reset;*/
        }
    }
}
