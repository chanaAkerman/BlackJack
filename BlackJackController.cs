using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace BlackJack
{
    public delegate void EndPlayerTurnDetected(Object sender, EventArgs e);
    class BlackJack_Controller
    {
        public List<BlackJackForm> blackjackform = new List<BlackJackForm>();
        public Player dealer;
        public PictureBox[] dealerCards;
        public int currentPlayer = 1;
        public int isEndRound = 0;
        public Boolean endGame = false;
        public int numOfPlayers;
        public Boolean isSavedGame;

        //public Dictionary<int, BlackJackGame> games = new Dictionary<int, BlackJackGame>();

        public int CurrentPlayer { get { return currentPlayer; } set { currentPlayer = value; } }

        public List<BlackJackForm> BlackJackForms { get { return blackjackform; } }

        public BlackJack_Controller(int num, Boolean isSavedGame = false)
        {
            if (isSavedGame)
            {
                this.isSavedGame = true;
            }
            this.numOfPlayers = num;
            this.blackjackform = new List<BlackJackForm>();
            InitializeForms();
        }
        /// <summary>
        /// Start Game
        /// </summary>
        public void InitializeForms()
        {
            dealer = new Player();
            dealer.NewHand();
            for (int i = 0; i < this.numOfPlayers; i++)
            {
                // Show the main BlackJack UI game
                BlackJackForm form1 = new BlackJackForm(dealer);
                form1.Show();
                form1.endMoveDetected += new EndPlayerTurnDetected(DetectChangeForm);
                form1.exitDetected += new ExitDetection(CloseAllWindows);
                blackjackform.Add(form1);
            }
            int h = 0;
            foreach (BlackJackForm form in blackjackform)
            {
                form.UpdatePlayerImage(++h);
            }
            if (isSavedGame)
            {
                blackjackform[0].UpdatePlayerBalance(1, Properties.Settings.Default.InitBalance1);
                blackjackform[0].UpdatePlayerBalance(2, Properties.Settings.Default.InitBalance2);
                blackjackform[0].UpdatePlayerBalance(3, Properties.Settings.Default.InitBalance3);

                blackjackform[1].UpdatePlayerBalance(1, Properties.Settings.Default.InitBalance2);
                blackjackform[1].UpdatePlayerBalance(2, Properties.Settings.Default.InitBalance1);
                blackjackform[1].UpdatePlayerBalance(3, Properties.Settings.Default.InitBalance3);

                blackjackform[2].UpdatePlayerBalance(1, Properties.Settings.Default.InitBalance3);
                blackjackform[2].UpdatePlayerBalance(2, Properties.Settings.Default.InitBalance1);
                blackjackform[2].UpdatePlayerBalance(3, Properties.Settings.Default.InitBalance2);

                
            }

            MessageBox.Show("Player " + currentPlayer + " Turn");
            blackjackform[1].Enabled = false;
            blackjackform[2].Enabled = false;
            blackjackform[0].BringToFront();
        }
        /// <summary>
        /// Next Player
        /// </summary>
        public void nextPlayer()
        {
            if (currentPlayer == 2)
            {
                currentPlayer = 0;
            }
            else
            {
                currentPlayer++;
            }
        }
        public void DetectChangeForm(object sender, EventArgs e)
        {
            // end game
            if (endGame)
            {
                EndGame();
                endGame = false;
                isEndRound = 0;
                fixView();
                nextPlayer();
            }
            else
            {
                // סיים לחלק קלפים
                if (isEndRound < 3)
                {
                    //first Round
                    if (isEndRound == 0)
                    {
                        try
                        {
                            foreach (BlackJackForm Bform in blackjackform)
                            {
                                Bform.ClearTable();
                            }
                            dealer = new Player();
                            dealer.NewHand();
                            dealerCards = null;
                            foreach (BlackJackForm form in blackjackform)
                            {
                                form.Game.DealNewGame(dealer);
                                dealer.CurrentDeck = form.Game.CurrentDeck;
                            }
                        }
                        catch (NotImplementedException)
                        {
                            MessageBox.Show("Card skin images are not loading correctly.  Make sure the card skin images are in the correct location.");
                        }
                        blackjackform[0].UpdateUIDealerCards(dealer);
                        blackjackform[1].UpdateUIDealerCards(dealer);
                        blackjackform[2].UpdateUIDealerCards(dealer);

                        blackjackform[isEndRound].Game.DealNewGame(dealer);
                        blackjackform[isEndRound].UpdateUIPlayerCards();
                    }

                    blackjackform[isEndRound].Game.DealNewGame(dealer);
                    blackjackform[isEndRound].UpdateUIPlayerCards();
                    fixView();
                }
                if (isEndRound > 2 && isEndRound < 6)
                {
                    fixView();
                    if (currentPlayer == 2)
                    {
                        endGame = true;
                    }
                }
                isEndRound++;
                nextPlayer();
            }

        }
        public void fixView()
        {
            MessageBox.Show("player " + (currentPlayer + 1) + " Turn");
            int i = 0;
            foreach (BlackJackForm form in blackjackform)
            {
                if (currentPlayer == i)
                {
                    int h = 0;
                    foreach (BlackJackForm form1 in blackjackform)
                    {
                        dealer.CurrentDeck = form.Game.CurrentDeck;
                        form1.UpdatePlayerImage(++h);
                    }
                    blackjackform[i].Enabled = true;
                    blackjackform[i].BringToFront();
                    foreach (BlackJackForm f in blackjackform)
                    {
                        f.UpdatePlayerTurn(currentPlayer);
                    }
                }
                else
                {
                    blackjackform[i].Enabled = false;
                }
                i++;
            }
        }
        public void EndGame()
        {
            foreach (BlackJackForm Bform in blackjackform)
            {
                Bform.endRound();
                blackjackform[0].UpdatePlayerBalance(2, blackjackform[1].ShowBankValue());
                blackjackform[0].UpdatePlayerBalance(3, blackjackform[2].ShowBankValue());
                blackjackform[1].UpdatePlayerBalance(2, blackjackform[0].ShowBankValue());
                blackjackform[1].UpdatePlayerBalance(3, blackjackform[2].ShowBankValue());
                blackjackform[2].UpdatePlayerBalance(2, blackjackform[0].ShowBankValue());
                blackjackform[2].UpdatePlayerBalance(3, blackjackform[1].ShowBankValue());
            }
            foreach (BlackJackForm Bform in blackjackform)
            {
                Bform.Game.DealerPlay(dealer);
                Bform.UpdateUIDealerCards(dealer);
            }
            isEndRound = 0;
            MessageBox.Show("Starting New Round");
            foreach (BlackJackForm Bform in blackjackform)
            {
                Bform.ClearTable();
            }
        }
        public void CloseAllWindows(object sender, EventArgs e)
        {
            Properties.Settings.Default.InitBalance1 = (int)(blackjackform[0].Game.CurrentPlayer.Balance);
            Properties.Settings.Default.InitBalance2 = (int)(blackjackform[1].Game.CurrentPlayer.Balance);
            Properties.Settings.Default.InitBalance3 = (int)(blackjackform[2].Game.CurrentPlayer.Balance);
            Properties.Settings.Default.Save();
            foreach (BlackJackForm form in blackjackform)
            {
                form.Close();
            }
        }
    }
}
