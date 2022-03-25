using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace TicTacToe
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        #region Private Variables
        //Holds the current results of cells in the active game
        private MarkType[] mResults;


        //True if it is player 1's turn (x) or player 2's turn (O)
        private bool mPlayer1Turn;

        //True if the game has ended
        private bool mGameEnded;

        //Tracks number of wins for Player1
        private int player1Wins;

        //Trakcs number of wins for Player 2
        private int player2Wins;

        //True if someone won despite the board being full
        private bool mWinnerFound;
        #endregion

        #region Constructor
        //Default constructor
        public MainWindow()
        {
            InitializeComponent();

            NewGame();
        }

        #endregion

        //Starts a new game and clears all values back to the default values
        private void NewGame()
        {
            //Initialize a new blank array of free cells
            mResults = new MarkType[9];

            for (int i = 0; i < mResults.Length; i++)
                mResults[i] = MarkType.Free;

            mPlayer1Turn = true;

            //Iterate through every button on the grid
            Board.Children.Cast<Button>().ToList().ForEach(button =>
            {
                //Change background, foreground and content to default values
                button.Content = string.Empty;
                button.Background = Brushes.White;
                button.Foreground = Brushes.Blue;
            });

            //Checks to make sure the game hasn't ended
            mGameEnded = false;
        }


        //Handles button click event
        //<param name="sender> The button that was clicked </param>
        //<param name="e">The events of the click</param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //Start a new game on button click after previous game has ended
            if (mGameEnded)
            {
                NewGame();
                return;
            }

            //Cast the sender to a button
            var button = (Button) sender;

            //Find the buttons position in the array
            var column = Grid.GetColumn(button);
            var row = Grid.GetRow(button);

            var index = column + (row * 3);

            //Don't do anything if the cell already has a button within it
            if(mResults[index] != MarkType.Free)
                return;

            //Set the cell value based on which players' turn it is
            mResults[index] = mPlayer1Turn ? MarkType.Cross : MarkType.Circle;

            //Update the button content based on the current player turn

            button.Content = mPlayer1Turn ? "X" : "O";

            //Change the color of player2's variable
            if(!mPlayer1Turn)
                button.Foreground = Brushes.Green;

            //Toggle the player's turns
            if (mPlayer1Turn)
                mPlayer1Turn = false;
            else
                mPlayer1Turn = true;

            //Check for winner
            WinnerCheck();
            
        }

        //Checks to see if there is a winner within the current tic tac toe game
        private void WinnerCheck()
        {
            #region Horizontal Win
            //Check for horizontal wins 
            //Row 0 
            if (mResults[0] != MarkType.Free && (mResults[0] & mResults[1] & mResults[2]) == mResults[0])
            {
                //Game has ended
                mGameEnded = true;

                //Winner found
                mWinnerFound = true;

                //Checks to see which player won and displays who won and the number of wins
                if (mResults[0] == MarkType.Cross)
                {
                    player1Wins += 1;
                    MessageBox.Show("Player 1 Wins! \nScore count is: \n" + "Player 1: " + player1Wins + "\nPlayer 2: " + player2Wins);
                }
                else
                {
                    player2Wins += 1;
                    MessageBox.Show("Player 2 Wins! \nScore count is: \n" + "Player1: " + player1Wins + "\nPlayer2: " + player2Wins);
                }

                //Highlight winning row
                Button0_0.Background = Button1_0.Background = Button2_0.Background = Brushes.LightGreen;
            }

            //Row 1 
            if (mResults[3] != MarkType.Free && (mResults[3] & mResults[4] & mResults[5]) == mResults[3])
            {
                //Game has ended
                mGameEnded = true;

                //Winner found
                mWinnerFound = true;

                //Checks to see which player won and displays who won and the number of wins
                if (mResults[0] == MarkType.Cross)
                {
                    player1Wins += 1;
                    MessageBox.Show("Player 1 Wins! \nScore count is: \n" + "Player 1: " + player1Wins + "\nPlayer 2: " + player2Wins);
                }
                else
                {
                    player2Wins += 1;
                    MessageBox.Show("Player 2 Wins! \nScore count is: \n" + "Player1: " + player1Wins + "\nPlayer2: " + player2Wins);
                }

                //Highlight winning row
                Button0_1.Background = Button1_1.Background = Button2_1.Background = Brushes.LightGreen;
            }

            //Row 2
            if (mResults[6] != MarkType.Free && (mResults[6] & mResults[7] & mResults[8]) == mResults[6])
            {
                //Game has ended
                mGameEnded = true;

                //Winner found
                mWinnerFound = true;

                //Checks to see which player won and displays who won and the number of wins
                if (mResults[0] == MarkType.Cross)
                {
                    player1Wins += 1;
                    MessageBox.Show("Player 1 Wins! \nScore count is: \n" + "Player 1: " + player1Wins + "\nPlayer 2: " + player2Wins);
                }
                else
                {
                    player2Wins += 1;
                    MessageBox.Show("Player 2 Wins! \nScore count is: \n" + "Player1: " + player1Wins + "\nPlayer2: " + player2Wins);
                }

                //Highlight winning row
                Button0_2.Background = Button1_2.Background = Button2_2.Background = Brushes.LightGreen;
            }
            #endregion


            #region Vertical Win
            //Check for vertical wins
            //Column 0
            if (mResults[0] != MarkType.Free && (mResults[0] & mResults[3] & mResults[6]) == mResults[0])
            {
                //Game has ended
                mGameEnded = true;

                //Winner found
                mWinnerFound = true;

                //Checks to see which player won and displays who won and the number of wins
                if (mResults[0] == MarkType.Cross)
                {
                    player1Wins += 1;
                    MessageBox.Show("Player 1 Wins! \nScore count is: \n" + "Player 1: " + player1Wins + "\nPlayer 2: " + player2Wins);
                }
                else
                {
                    player2Wins += 1;
                    MessageBox.Show("Player 2 Wins! \nScore count is: \n" + "Player1: " + player1Wins + "\nPlayer2: " + player2Wins);
                }

                //Highlight winning row
                Button0_0.Background = Button0_1.Background = Button0_2.Background = Brushes.LightGreen;
            }

            //Column 1
            if (mResults[1] != MarkType.Free && (mResults[1] & mResults[4] & mResults[7]) == mResults[1])
            {
                //Game has ended
                mGameEnded = true;

                //Winner found
                mWinnerFound = true;

                //Checks to see which player won and displays who won and the number of wins
                if (mResults[0] == MarkType.Cross)
                {
                    player1Wins += 1;
                    MessageBox.Show("Player 1 Wins! \nScore count is: \n" + "Player 1: " + player1Wins + "\nPlayer 2: " + player2Wins);
                }
                else
                {
                    player2Wins += 1;
                    MessageBox.Show("Player 2 Wins! \nScore count is: \n" + "Player1: " + player1Wins + "\nPlayer2: " + player2Wins);
                }

                //Highlight winning row
                Button1_0.Background = Button1_1.Background = Button1_2.Background = Brushes.LightGreen;
            }

            //Column 2
            if (mResults[2] != MarkType.Free && (mResults[2] & mResults[5] & mResults[8]) == mResults[2])
            {
                //Game has ended
                mGameEnded = true;

                //Winner found
                mWinnerFound = true;

                //Checks to see which player won and displays who won and the number of wins
                if (mResults[0] == MarkType.Cross)
                {
                    player1Wins += 1;
                    MessageBox.Show("Player 1 Wins! \nScore count is: \n" + "Player 1: " + player1Wins + "\nPlayer 2: " + player2Wins);
                }
                else
                {
                    player2Wins += 1;
                    MessageBox.Show("Player 2 Wins! \nScore count is: \n" + "Player1: " + player1Wins + "\nPlayer2: " + player2Wins);
                }

                //Highlight winning row
                Button2_0.Background = Button2_1.Background = Button2_2.Background = Brushes.LightGreen;
            }
            #endregion


            #region Diagonal Win
            //Check for diagonal wins
            //Top left to bottom right
            if (mResults[0] != MarkType.Free && (mResults[0] & mResults[4] & mResults[8]) == mResults[0])
            {
                //Game has ended
                mGameEnded = true;

                //Winner found
                mWinnerFound = true;

                //Checks to see which player won and displays who won and the number of wins
                if (mResults[0] == MarkType.Cross)
                {
                    player1Wins += 1;
                    MessageBox.Show("Player 1 Wins! \nScore count is: \n" + "Player 1: " + player1Wins + "\nPlayer 2: " + player2Wins);
                }
                else
                {
                    player2Wins += 1;
                    MessageBox.Show("Player 2 Wins! \nScore count is: \n" + "Player1: " + player1Wins + "\nPlayer2: " + player2Wins);
                }

                //Highlight winning row
                Button0_0.Background = Button1_1.Background = Button2_2.Background = Brushes.LightGreen;
            }

            //Top right to bottom left
            if (mResults[2] != MarkType.Free && (mResults[2] & mResults[4] & mResults[6]) == mResults[2])
            {
                //Game has ended
                mGameEnded = true;

                //Winner found
                mWinnerFound = true;

                //Checks to see which player won and displays who won and the number of total wins
                if (mResults[0] == MarkType.Cross)
                {
                    player1Wins += 1;
                    MessageBox.Show("Player 1 Wins! \nScore count is: \n" + "Player 1: " + player1Wins + "\nPlayer 2: " + player2Wins);
                }
                else
                {
                    player2Wins += 1;
                    MessageBox.Show("Player 2 Wins! \nScore count is: \n" + "Player1: " + player1Wins + "\nPlayer2: " + player2Wins);
                }

                //Highlight winning row
                Button2_0.Background = Button1_1.Background = Button0_2.Background = Brushes.LightGreen;
            }
            #endregion

            //No tic tac toe has been found and all squares are full
            if (!mResults.Any(f => f == MarkType.Free) && mWinnerFound == false)
            {
                //Game has ended due to all squares being filled
                mGameEnded = true;

                //Displays current win count
                MessageBox.Show("Tie! \nScore count is: \n" + "Player 1: " + player1Wins + "\nPlayer 2: " + player2Wins);

                //All cells are turned orange since the ga
                Board.Children.Cast<Button>().ToList().ForEach(button =>
                {
                    button.Background = Brushes.Orange;
                });
            }
        }
    }
}
