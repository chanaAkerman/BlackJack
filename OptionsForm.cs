using System;
using System.Windows.Forms;
using System.Drawing;

namespace BlackJack
{
    partial class OptionsForm : Form
    {
        /// <summary>
        /// Main constructor for OptionsForm
        /// </summary>
        public OptionsForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Performs setup actions when the form loads
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OptionsForm_Load(object sender, EventArgs e)
        {
            try
            {
                // Loads the player image from file and displays the image in the "preview" box
                player1PictureBox.Image = Image.FromFile(Properties.Settings.Default.PlayerImage1);
                player2PictureBox.Image = Image.FromFile(Properties.Settings.Default.PlayerImage2);
                player3PictureBox.Image = Image.FromFile(Properties.Settings.Default.PlayerImage3);
                // Loads the path name for the other images
                string image1 = Properties.Settings.Default.DefaultImage1;
                string image2 = Properties.Settings.Default.DefaultImage2;
                string image3 = Properties.Settings.Default.DefaultImage3;
                string image4 = Properties.Settings.Default.DefaultImage4;

                // Loads each image and displays it in the image list
                defaultImageList.Images.Add(image1, Image.FromFile(image1));
                defaultImageListView1.Items.Add(image1, image1);
                defaultImageListView2.Items.Add(image1, image1);
                defaultImageListView3.Items.Add(image1, image1);

                defaultImageList.Images.Add(image2, Image.FromFile(image2));
                defaultImageListView1.Items.Add(image2, image2);
                defaultImageListView2.Items.Add(image2, image2);
                defaultImageListView3.Items.Add(image2, image2);

                defaultImageList.Images.Add(image3, Image.FromFile(image3));
                defaultImageListView1.Items.Add(image3, image3);
                defaultImageListView2.Items.Add(image3, image3);
                defaultImageListView3.Items.Add(image3, image3);

                defaultImageList.Images.Add(image4, Image.FromFile(image4));
                defaultImageListView1.Items.Add(image4, image4);
                defaultImageListView2.Items.Add(image4, image4);
                defaultImageListView3.Items.Add(image4, image4);

                defaultImageListView1.Items[0].Text = "";
                defaultImageListView1.Items[1].Text = "";
                defaultImageListView1.Items[2].Text = "";
                defaultImageListView1.Items[3].Text = "";

                defaultImageListView2.Items[0].Text = "";
                defaultImageListView2.Items[1].Text = "";
                defaultImageListView2.Items[2].Text = "";
                defaultImageListView2.Items[3].Text = "";

                defaultImageListView3.Items[0].Text = "";
                defaultImageListView3.Items[1].Text = "";
                defaultImageListView3.Items[2].Text = "";
                defaultImageListView3.Items[3].Text = "";

                player1NameTextBox.Text = Properties.Settings.Default.PlayerName1;
                player2NameTextBox.Text = Properties.Settings.Default.PlayerName2;
                player3NameTextBox.Text = Properties.Settings.Default.PlayerName3;


            }
            catch (OutOfMemoryException)
            {
                MessageBox.Show("Images did not load properly.  Verify that images are in the correct location");
            }
        }

        /// <summary>
        /// Invoked when a user selects an image in the scroll list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Player1DefaultImageList_ItemActivate(object sender, EventArgs e)
        {
            // Selects an image from the image scroll list
            ListView.SelectedListViewItemCollection items = defaultImageListView1.SelectedItems;
            Properties.Settings.Default.PlayerImage1 = items[0].ImageKey;
            player1PictureBox.Image = Image.FromFile(Properties.Settings.Default.PlayerImage1);
        }
        private void Player2DefaultImageList_ItemActivate(object sender, EventArgs e)
        {
            // Selects an image from the image scroll list
            ListView.SelectedListViewItemCollection items = defaultImageListView2.SelectedItems;
            Properties.Settings.Default.PlayerImage2 = items[0].ImageKey;
            player2PictureBox.Image = Image.FromFile(Properties.Settings.Default.PlayerImage2);
        }
        private void Player3DefaultImageList_ItemActivate(object sender, EventArgs e)
        {
            // Selects an image from the image scroll list
            ListView.SelectedListViewItemCollection items = defaultImageListView3.SelectedItems;
            Properties.Settings.Default.PlayerImage3 = items[0].ImageKey;
            player3PictureBox.Image = Image.FromFile(Properties.Settings.Default.PlayerImage3);
        }

        /// <summary>
        /// Cancels any changes made in the option form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCance_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Reload();
            this.Close();
        }
        /// <summary>
        /// Saves current changes made in the options form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOK_Click(object sender, EventArgs e)
        {
            // Saves the player name to the settings file
            Properties.Settings.Default.PlayerName1 = player1NameTextBox.Text;
            Properties.Settings.Default.PlayerName2 = player2NameTextBox.Text;
            Properties.Settings.Default.PlayerName3 = player3NameTextBox.Text;

            Properties.Settings.Default.InitBalance1 = 4000;
            Properties.Settings.Default.InitBalance2 = 4000;
            Properties.Settings.Default.InitBalance3 = 4000;
            // Saves the values in the setting file to be used in the game
            Properties.Settings.Default.Save();
            this.Close();
        }
    }
}