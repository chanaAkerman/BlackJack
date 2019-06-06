using System;
using System.Windows.Forms;

namespace BlackJack
{
    //public delegate void EndPlayerTurnDetected(Object sender, EventArgs e);
    partial class StartForm : Form
    {
        /// <summary>
        /// Main constructor for StartForm
        /// </summary>
        public StartForm()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Strart three-player game
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NewGameBtn_Click(object sender, EventArgs e)
        {

            DialogResult dialogResult = MessageBox.Show("Start a new Game?", "Game", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                //Start a new game
                BlackJack_Controller game_Control = new BlackJack_Controller(3);
            }
            if (dialogResult == DialogResult.No)
            {
                //continew the game
                BlackJack_Controller game_Control = new BlackJack_Controller(3,true);

            }
        }
        /// <summary>
        /// Brings up the options form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OptionsBtn_Click(object sender, EventArgs e)
        {
            // Show the Options panel
            using (OptionsForm optionsForm = new OptionsForm())
            {
                Hide();
                optionsForm.ShowDialog();
                Show();
            }
        }
        /// <summary>
        /// Exits the application
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExitBtn_Click(object sender, EventArgs e)
        {
            // Exit the Game
            Application.Exit();
        }
    }
}
