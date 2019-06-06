using System;
using System.Text;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using BlackJack.CardGameFramework;

namespace BlackJack
{
    public delegate void ExitDetection(object sender, EventArgs e);
    partial class BlackJackForm : Form
    {
        #region Fields

        //Creates a new blackjack game with one player and an inital balance set through the settings designer
        private BlackJackGame game = new BlackJackGame(Properties.Settings.Default.InitBalance1);
        private Player dealer;
        private PictureBox[] playerCards;
        private PictureBox[] dealerCards;
        private bool firstTurn;
        public EndResult endResult;

        public event EndPlayerTurnDetected endMoveDetected;
        public event ExitDetection exitDetected;
        public int cur = 0;

        #endregion

        #region Main Constructor

        /// <summary>
        /// Main constructor for the BlackJackForm.  Initializes components, loads the card skin images, and sets up the new game
        /// </summary>
        public BlackJackForm(Player dealer)
        {
            this.dealer = dealer;
            InitializeComponent();
            LoadCardSkinImages();
            SetUpNewGame();
        }

        public Player Dealer { get { return dealer; } }
        public PictureBox[] DealerCards { get { return dealerCards; } set { this.dealerCards = value; } }
        public BlackJackGame Game { get { return game; } }

        #endregion

        #region Game Event Handlers

        /// <summary>
        /// Invoked when the deal button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DealBtn_Click(object sender, EventArgs e)
        {
            try
            {
                // If the current bet is equal to 0, ask the player to place a bet
                if ((game.CurrentPlayer.Bet == 0) && (game.CurrentPlayer.Balance > 0))
                {
                    MessageBox.Show("You must place a bet before the dealer deals.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    // Place the bet
                    game.CurrentPlayer.PlaceBet();
                    ShowBankValue();

                    SetUpGameInPlay();
                    //game.DealNewGame(dealer);
                    UpdateUIPlayerCards();

                    EndMoveDetected();

                    // Check see if the current player has blackjack
                    if (game.CurrentPlayer.HasBlackJack())
                    {
                        EndMoveDetected();
                        endResult = EndResult.PlayerBlackJack;
                    }
                }
            }
            catch (Exception NotEnoughMoneyException)
            {
                MessageBox.Show(NotEnoughMoneyException.Message);
            }
        }

        /// <summary>
        /// Invoked when the player has finished their turn and clicked the stand button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StandBtn_Click(object sender, EventArgs e)
        {
            // Dealer should finish playing and the UI should be updated
            UpdateUIPlayerCards();

            // Check who won the game
            EndMoveDetected();
            endResult = GetGameResult();
        }

        /// <summary>
        /// Invoked when the hit button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HitBtn_Click(object sender, EventArgs e)
        {
            // It is no longer the first turn, set this to false so that the cards will all be facing upwards
            firstTurn = false;
            // Hit once and update UI cards
            game.CurrentPlayer.Hit();
            UpdateUIPlayerCards();

            // Check to see if player has bust
            if (game.CurrentPlayer.HasBust())
            {
                EndMoveDetected();
                endResult = EndResult.PlayerBust;
            }
        }

        /// <summary>
        /// Invoked when the double down button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DblDwnBtn_Click(object sender, EventArgs e)
        {
            try
            {
                // Double the player's bet amount
                game.CurrentPlayer.DoubleDown();
                UpdateUIPlayerCards();
                ShowBankValue();

                //Make sure that the player didn't bust
                if (game.CurrentPlayer.HasBust())
                {
                    EndMoveDetected();
                    endResult = EndResult.PlayerBust;
                }
                else
                {
                    // Otherwise, let the dealer finish playing
                    game.DealerPlay(dealer);
                    UpdateUIPlayerCards();
                    EndMoveDetected();
                    endResult = GetGameResult();
                }
            }
            catch (Exception NotEnoughMoneyException)
            {
                MessageBox.Show(NotEnoughMoneyException.Message);
            }
        }

        public void endRound()
        {
            EndGame(endResult);
        }

        public void EndMoveDetected()
        {
            endMoveDetected(this, new EventArgs());
        }

        /// <summary>
        /// Exits the game
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExitBtn_Click(object sender, EventArgs e)
        {
            ExitDetected();
        }
        public void ExitDetected()
        {
            exitDetected(this, new EventArgs());
        }
        /// <summary>
        /// Place a bet for 10 dollars
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TenBtn_Click(object sender, EventArgs e)
        {
            Bet(10);
        }

        /// <summary>
        /// Place a bet for 25 dollars
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TwentyFiveBtn_Click(object sender, EventArgs e)
        {
            Bet(25);
        }

        /// <summary>
        /// Place a bet for 50 dollars
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FiftyBtn_Click(object sender, EventArgs e)
        {
            Bet(50);
        }

        /// <summary>
        /// Place a bet for 100 dollars
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HundredBtn_Click(object sender, EventArgs e)
        {
            Bet(100);
        }

        /// <summary>
        /// Clear the bet
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClearBetBtn_Click(object sender, EventArgs e)
        {
            //Clear the bet amount
            game.CurrentPlayer.ClearBet();
            ShowBankValue();
        }

        #endregion

        #region Game Methods

        /// <summary>
        /// This method updates the current bet by a specified bet amount
        /// </summary>
        /// <param name="betValue"></param>
        private void Bet(decimal betValue)
        {
            try
            {
                // Update the bet amount
                game.CurrentPlayer.IncreaseBet(betValue);

                // Update the "My Bet" and "My Account" values
                ShowBankValue();
            }
            catch (Exception NotEnoughMoneyException)
            {
                MessageBox.Show(NotEnoughMoneyException.Message);
            }
        }

        /// <summary>
        /// Set the "My Account" value in the UI
        /// </summary>
        public decimal ShowBankValue()
        {
            // Update the "My Account" value
            myAccount1TextBox.Text = "$" + game.CurrentPlayer.Balance.ToString();
            myBetTextBox.Text = "$" + game.CurrentPlayer.Bet.ToString();
            return game.CurrentPlayer.Balance;
        }

        /// <summary>
        /// Clear the dealer and player cards
        /// </summary>
        public void ClearTable()
        {
            for (int i = 0; i < 6; i++)
            {
                dealerCards[i].Image = null;
                dealerCards[i].Visible = false;

                playerCards[i].Image = null;
                playerCards[i].Visible = false;
            }
        }

        /// <summary>
        /// Get the game result.  This returns an EndResult value
        /// </summary>
        /// <returns></returns>
        private EndResult GetGameResult()
        {
            EndResult endState;
            // Check for blackjack
            if (dealer.Hand.NumCards == 2 && dealer.HasBlackJack())
            {
                endState = EndResult.DealerBlackJack;
            }
            // Check if the dealer has bust
            else if (dealer.HasBust())
            {
                endState = EndResult.DealerBust;
            }
            else if (dealer.Hand.CompareFaceValue(game.CurrentPlayer.Hand) > 0)
            {
                //dealer wins
                endState = EndResult.DealerWin;
            }
            else if (dealer.Hand.CompareFaceValue(game.CurrentPlayer.Hand) == 0)
            {
                // push
                endState = EndResult.Push;
            }
            else
            {
                // player wins
                endState = EndResult.PlayerWin;
            }
            return endState;
        }

        /// <summary>
        /// Takes an EndResult value and shows the resulting game ending in the UI
        /// </summary>
        /// <param name="endState"></param>
        private void EndGame(EndResult endState)
        {
            switch (endState)
            {
                case EndResult.DealerBust:
                    gameOverTextBox.Text = "Dealer Bust!";
                    game.PlayerWin();
                    break;
                case EndResult.DealerBlackJack:
                    gameOverTextBox.Text = "Dealer BlackJack!";
                    game.PlayerLose();
                    break;
                case EndResult.DealerWin:
                    gameOverTextBox.Text = "Dealer Won!";
                    game.PlayerLose();
                    break;
                case EndResult.PlayerBlackJack:
                    gameOverTextBox.Text = "BlackJack!";
                    game.CurrentPlayer.Balance += (game.CurrentPlayer.Bet * (decimal)2.5);
                    game.CurrentPlayer.Wins += 1;
                    break;
                case EndResult.PlayerBust:
                    gameOverTextBox.Text = "You Bust!";
                    game.PlayerLose();
                    break;
                case EndResult.PlayerWin:
                    gameOverTextBox.Text = "You Won!";
                    game.PlayerWin();
                    break;
                case EndResult.Push:
                    gameOverTextBox.Text = "Push";
                    game.CurrentPlayer.Push += 1;
                    game.CurrentPlayer.Balance += game.CurrentPlayer.Bet;
                    break;
            }
            // Update the "My Record" values
            winTextBox.Text = game.CurrentPlayer.Wins.ToString();
            lossTextBox.Text = game.CurrentPlayer.Losses.ToString();
            tiesTextBox.Text = game.CurrentPlayer.Push.ToString();
            SetUpNewGame();
            ShowBankValue();
            gameOverTextBox.Show();
            // Check if the current player is out of money
            if (game.CurrentPlayer.Balance == 0)
            {
                MessageBox.Show("Out of Money.  Please create a new game to play again.");
                this.Close();
            }
        }

        #endregion

        #region Game UI Methods

        /// <summary>
        /// Load the Deck Card Images
        /// </summary>
        public void LoadCardSkinImages()
        {
            try
            {
                // Load the card skin image from file
                Image cardSkin = Image.FromFile(Properties.Settings.Default.CardGameImageSkinPath);
                // Set the three cards on the UI to the card skin image
                deckCard1PictureBox.Image = cardSkin;
                deckCard2PictureBox.Image = cardSkin;
                deckCard3PictureBox.Image = cardSkin;
            }
            catch (OutOfMemoryException)
            {
                MessageBox.Show("Card skin images are not loading correctly.  Make sure the card skin images are in the correct location.");
            }

            playerCards = new PictureBox[] { playerCard1, playerCard2, playerCard3, playerCard4, playerCard5, playerCard6 };
            dealerCards = new PictureBox[] { dealerCard1PictureBox, dealerCard2PictureBox, dealerCard3PictureBox, dealerCard4PictureBox, dealerCard5PictureBox, dealerCard6PictureBox };
        }

        /// <summary>
        /// Set up the UI for when the game is in play after the player has hit deal game
        /// </summary>
        private void SetUpGameInPlay()
        {
            tenButton.Enabled = false;
            twentyFiveButton.Enabled = false;
            fiftyButton.Enabled = false;
            hundredButton.Enabled = false;
            clearBetButton.Enabled = false;
            standButton.Enabled = true;
            hitButton.Enabled = true;
            gameOverTextBox.Hide();
            playerTotalLabel.Show();
            dealButton.Enabled = false;

            if (firstTurn)
                doubleDownButton.Enabled = true;
        }

        /// <summary>
        /// Set up the UI for a new game
        /// </summary>
        private void SetUpNewGame()
        {
            PlayerNumber.Text = "Turn player " + (cur + 1);
            dealButton.Enabled = true;
            doubleDownButton.Enabled = false;
            standButton.Enabled = false;
            hitButton.Enabled = false;
            clearBetButton.Enabled = true;
            tenButton.Enabled = true;
            twentyFiveButton.Enabled = true;
            fiftyButton.Enabled = true;
            hundredButton.Enabled = true;
            gameOverTextBox.Hide();
            playerTotalLabel.Hide();
            firstTurn = true;
            ShowBankValue();
        }

        public void UpdatePlayerTurn(int cur)
        {
            this.cur = cur;
            PlayerNumber.Text = "Player " + (cur + 1) + "Turn";
        }

        public void UpdatePlayerBalance(int num, decimal balance)
        {
            switch (num)
            {
                case 1:
                    myAccount1TextBox.Text = balance.ToString();
                    break;
                case 2:
                    myAccount2TextBox.Text = balance.ToString();
                    break;
                case 3:
                    myAccount3TextBox.Text = balance.ToString();
                    break;
                default:
                    break;
            }
        }
        public void updateBalance(decimal b1, decimal b2,decimal b3)
        {
            myAccount1TextBox.Text = b1.ToString();
            myAccount2TextBox.Text = b1.ToString();
            myAccount3TextBox.Text = b2.ToString();
        }



        public void UpdatePlayerImage(int num)
        {
            switch (num)
            {
                case 1:
                    photoPictureBox1.ImageLocation = Properties.Settings.Default.PlayerImage1;
                    photoPictureBox2.ImageLocation = Properties.Settings.Default.PlayerImage2;
                    photoPictureBox3.ImageLocation = Properties.Settings.Default.PlayerImage3;
                    photoPictureBox1.Visible = true;
                    photoPictureBox2.Visible = true;
                    photoPictureBox3.Visible = true;
                    player1NameLabel.Text = Properties.Settings.Default.PlayerName1;
                    player2NameLabel.Text = Properties.Settings.Default.PlayerName2;
                    player3NameLabel.Text = Properties.Settings.Default.PlayerName3;
                    break;
                case 2:
                    photoPictureBox1.ImageLocation = Properties.Settings.Default.PlayerImage2;
                    photoPictureBox2.ImageLocation = Properties.Settings.Default.PlayerImage1;
                    photoPictureBox3.ImageLocation = Properties.Settings.Default.PlayerImage3;
                    photoPictureBox1.Visible = true;
                    photoPictureBox2.Visible = true;
                    photoPictureBox3.Visible = true;
                    player1NameLabel.Text = Properties.Settings.Default.PlayerName2;
                    player2NameLabel.Text = Properties.Settings.Default.PlayerName1;
                    player3NameLabel.Text = Properties.Settings.Default.PlayerName3;
                    break;
                case 3:
                    photoPictureBox1.ImageLocation = Properties.Settings.Default.PlayerImage3;
                    photoPictureBox2.ImageLocation = Properties.Settings.Default.PlayerImage1;
                    photoPictureBox3.ImageLocation = Properties.Settings.Default.PlayerImage2;
                    photoPictureBox1.Visible = true;
                    photoPictureBox2.Visible = true;
                    photoPictureBox3.Visible = true;
                    player1NameLabel.Text = Properties.Settings.Default.PlayerName3;
                    player2NameLabel.Text = Properties.Settings.Default.PlayerName1;
                    player3NameLabel.Text = Properties.Settings.Default.PlayerName2;
                    break;
                default:
                    break;
            }
        }
        /// <summary>
        /// Refresh the UI to update the player cards
        /// </summary>
        public void UpdateUIPlayerCards()
        {
            // Update the value of the hand
            playerTotalLabel.Text = game.CurrentPlayer.Hand.GetSumOfHand().ToString();

            List<Card> pcards = game.CurrentPlayer.Hand.Cards;
            for (int i = 0; i < pcards.Count; i++)
            {
                // Load each card from file
                LoadCard(playerCards[i], pcards[i]);
                playerCards[i].Visible = true;
                playerCards[i].BringToFront();
            }

            List<Card> dcards = dealer.Hand.Cards;
            for (int i = 0; i < dcards.Count; i++)
            {
                LoadCard(dealerCards[i], dcards[i]);
                dealerCards[i].Visible = true;
                dealerCards[i].BringToFront();
            }

        }

        public void UpdateUIDealerCards(Player myDealer)
        {

            List<Card> dcards = myDealer.Hand.Cards;
            for (int i = 0; i < dcards.Count; i++)
            {
                LoadCard(dealerCards[i], dcards[i]);
                dealerCards[i].Visible = true;
                dealerCards[i].BringToFront();
            }

        }
        /// <summary>
        /// Takes the card value and loads the corresponding card image from file
        /// </summary>
        /// <param name="pb"></param>
        /// <param name="c"></param>
        private void LoadCard(PictureBox pb, Card c)
        {
            try
            {
                StringBuilder image = new StringBuilder();

                switch (c.Suit)
                {
                    case Suit.Diamonds:
                        image.Append("di");
                        break;
                    case Suit.Hearts:
                        image.Append("he");
                        break;
                    case Suit.Spades:
                        image.Append("sp");
                        break;
                    case Suit.Clubs:
                        image.Append("cl");
                        break;
                }

                switch (c.FaceVal)
                {
                    case FaceValue.Ace:
                        image.Append("1");
                        break;
                    case FaceValue.King:
                        image.Append("k");
                        break;
                    case FaceValue.Queen:
                        image.Append("q");
                        break;
                    case FaceValue.Jack:
                        image.Append("j");
                        break;
                    case FaceValue.Ten:
                        image.Append("10");
                        break;
                    case FaceValue.Nine:
                        image.Append("9");
                        break;
                    case FaceValue.Eight:
                        image.Append("8");
                        break;
                    case FaceValue.Seven:
                        image.Append("7");
                        break;
                    case FaceValue.Six:
                        image.Append("6");
                        break;
                    case FaceValue.Five:
                        image.Append("5");
                        break;
                    case FaceValue.Four:
                        image.Append("4");
                        break;
                    case FaceValue.Three:
                        image.Append("3");
                        break;
                    case FaceValue.Two:
                        image.Append("2");
                        break;
                }

                image.Append(Properties.Settings.Default.CardGameImageExtension);
                string cardGameImagePath = Properties.Settings.Default.CardGameImagePath;
                string cardGameImageSkinPath = Properties.Settings.Default.CardGameImageSkinPath;
                image.Insert(0, cardGameImagePath);
                //check to see if the card should be faced down or up;
                if (!c.IsCardUp)
                    image.Replace(image.ToString(), cardGameImageSkinPath);

                pb.Image = new Bitmap(image.ToString());
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Card images are not loading correctly.  Make sure all card images are in the right location.");
            }
        }
        #endregion

    }
}
