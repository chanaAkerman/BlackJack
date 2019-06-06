namespace BlackJack
{
    partial class OptionsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OptionsForm));
            this.optionsLabel = new System.Windows.Forms.Label();
            this.player1NameTextBox = new System.Windows.Forms.TextBox();
            this.player1NameLabel = new System.Windows.Forms.Label();
            this.player1PictureBox = new System.Windows.Forms.PictureBox();
            this.playerPictureLabel = new System.Windows.Forms.Label();
            this.selectFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.defaultImageListView1 = new System.Windows.Forms.ListView();
            this.defaultImageList = new System.Windows.Forms.ImageList(this.components);
            this.previewLabel = new System.Windows.Forms.Label();
            this.iconPictureBox = new System.Windows.Forms.PictureBox();
            this.player2NameLabel = new System.Windows.Forms.Label();
            this.player3NameLabel = new System.Windows.Forms.Label();
            this.player2NameTextBox = new System.Windows.Forms.TextBox();
            this.player3NameTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.defaultImageListView2 = new System.Windows.Forms.ListView();
            this.defaultImageListView3 = new System.Windows.Forms.ListView();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.player2PictureBox = new System.Windows.Forms.PictureBox();
            this.player3PictureBox = new System.Windows.Forms.PictureBox();
            this.cancelButton = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.player1PictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.player2PictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.player3PictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // optionsLabel
            // 
            this.optionsLabel.AutoSize = true;
            this.optionsLabel.BackColor = System.Drawing.Color.Transparent;
            this.optionsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optionsLabel.ForeColor = System.Drawing.Color.White;
            this.optionsLabel.Location = new System.Drawing.Point(24, 9);
            this.optionsLabel.Name = "optionsLabel";
            this.optionsLabel.Size = new System.Drawing.Size(322, 39);
            this.optionsLabel.TabIndex = 0;
            this.optionsLabel.Text = "BlackJack Options";
            // 
            // player1NameTextBox
            // 
            this.player1NameTextBox.BackColor = System.Drawing.Color.Silver;
            this.player1NameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::BlackJack.Properties.Settings.Default, "PlayerName", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.player1NameTextBox.Location = new System.Drawing.Point(178, 111);
            this.player1NameTextBox.Name = "player1NameTextBox";
            this.player1NameTextBox.Size = new System.Drawing.Size(171, 32);
            this.player1NameTextBox.TabIndex = 1;
            this.player1NameTextBox.Text = "Player 1";
            // 
            // player1NameLabel
            // 
            this.player1NameLabel.AutoSize = true;
            this.player1NameLabel.BackColor = System.Drawing.Color.Transparent;
            this.player1NameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.player1NameLabel.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.player1NameLabel.Location = new System.Drawing.Point(12, 113);
            this.player1NameLabel.Name = "player1NameLabel";
            this.player1NameLabel.Size = new System.Drawing.Size(146, 25);
            this.player1NameLabel.TabIndex = 2;
            this.player1NameLabel.Text = "Player Name";
            this.player1NameLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // player1PictureBox
            // 
            this.player1PictureBox.BackColor = System.Drawing.Color.Silver;
            this.player1PictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.player1PictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.player1PictureBox.Location = new System.Drawing.Point(178, 374);
            this.player1PictureBox.Name = "player1PictureBox";
            this.player1PictureBox.Size = new System.Drawing.Size(126, 116);
            this.player1PictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.player1PictureBox.TabIndex = 3;
            this.player1PictureBox.TabStop = false;
            // 
            // playerPictureLabel
            // 
            this.playerPictureLabel.AutoSize = true;
            this.playerPictureLabel.BackColor = System.Drawing.Color.Transparent;
            this.playerPictureLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.playerPictureLabel.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.playerPictureLabel.Location = new System.Drawing.Point(12, 157);
            this.playerPictureLabel.Name = "playerPictureLabel";
            this.playerPictureLabel.Size = new System.Drawing.Size(160, 25);
            this.playerPictureLabel.TabIndex = 4;
            this.playerPictureLabel.Text = "Player Picture";
            this.playerPictureLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // defaultImageListView1
            // 
            this.defaultImageListView1.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.defaultImageListView1.BackColor = System.Drawing.Color.Silver;
            this.defaultImageListView1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.defaultImageListView1.LargeImageList = this.defaultImageList;
            this.defaultImageListView1.Location = new System.Drawing.Point(178, 157);
            this.defaultImageListView1.Margin = new System.Windows.Forms.Padding(0);
            this.defaultImageListView1.MultiSelect = false;
            this.defaultImageListView1.Name = "defaultImageListView1";
            this.defaultImageListView1.Size = new System.Drawing.Size(207, 203);
            this.defaultImageListView1.TabIndex = 2;
            this.defaultImageListView1.UseCompatibleStateImageBehavior = false;
            this.defaultImageListView1.ItemActivate += new System.EventHandler(this.Player1DefaultImageList_ItemActivate);
            // 
            // defaultImageList
            // 
            this.defaultImageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.defaultImageList.ImageSize = new System.Drawing.Size(130, 130);
            this.defaultImageList.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // previewLabel
            // 
            this.previewLabel.AutoSize = true;
            this.previewLabel.BackColor = System.Drawing.Color.Transparent;
            this.previewLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.previewLabel.ForeColor = System.Drawing.Color.White;
            this.previewLabel.Location = new System.Drawing.Point(63, 374);
            this.previewLabel.Name = "previewLabel";
            this.previewLabel.Size = new System.Drawing.Size(95, 25);
            this.previewLabel.TabIndex = 17;
            this.previewLabel.Text = "Preview";
            // 
            // iconPictureBox
            // 
            this.iconPictureBox.BackColor = System.Drawing.Color.Transparent;
            this.iconPictureBox.ErrorImage = null;
            this.iconPictureBox.Image = global::BlackJack.Properties.Resources.StartMenuIcon;
            this.iconPictureBox.InitialImage = null;
            this.iconPictureBox.Location = new System.Drawing.Point(1327, -1);
            this.iconPictureBox.Name = "iconPictureBox";
            this.iconPictureBox.Size = new System.Drawing.Size(156, 144);
            this.iconPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.iconPictureBox.TabIndex = 18;
            this.iconPictureBox.TabStop = false;
            // 
            // player2NameLabel
            // 
            this.player2NameLabel.AutoSize = true;
            this.player2NameLabel.BackColor = System.Drawing.Color.Transparent;
            this.player2NameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.player2NameLabel.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.player2NameLabel.Location = new System.Drawing.Point(470, 113);
            this.player2NameLabel.Name = "player2NameLabel";
            this.player2NameLabel.Size = new System.Drawing.Size(146, 25);
            this.player2NameLabel.TabIndex = 19;
            this.player2NameLabel.Text = "Player Name";
            this.player2NameLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // player3NameLabel
            // 
            this.player3NameLabel.AutoSize = true;
            this.player3NameLabel.BackColor = System.Drawing.Color.Transparent;
            this.player3NameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.player3NameLabel.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.player3NameLabel.Location = new System.Drawing.Point(934, 118);
            this.player3NameLabel.Name = "player3NameLabel";
            this.player3NameLabel.Size = new System.Drawing.Size(146, 25);
            this.player3NameLabel.TabIndex = 20;
            this.player3NameLabel.Text = "Player Name";
            this.player3NameLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // player2NameTextBox
            // 
            this.player2NameTextBox.BackColor = System.Drawing.Color.Silver;
            this.player2NameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::BlackJack.Properties.Settings.Default, "PlayerName", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.player2NameTextBox.Location = new System.Drawing.Point(654, 111);
            this.player2NameTextBox.Name = "player2NameTextBox";
            this.player2NameTextBox.Size = new System.Drawing.Size(171, 32);
            this.player2NameTextBox.TabIndex = 21;
            this.player2NameTextBox.Text = "Player 1";
            // 
            // player3NameTextBox
            // 
            this.player3NameTextBox.BackColor = System.Drawing.Color.Silver;
            this.player3NameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::BlackJack.Properties.Settings.Default, "PlayerName", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.player3NameTextBox.Location = new System.Drawing.Point(1116, 111);
            this.player3NameTextBox.Name = "player3NameTextBox";
            this.player3NameTextBox.Size = new System.Drawing.Size(171, 32);
            this.player3NameTextBox.TabIndex = 22;
            this.player3NameTextBox.Text = "Player 1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Location = new System.Drawing.Point(470, 157);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(160, 25);
            this.label1.TabIndex = 23;
            this.label1.Text = "Player Picture";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label2.Location = new System.Drawing.Point(934, 170);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(160, 25);
            this.label2.TabIndex = 24;
            this.label2.Text = "Player Picture";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // defaultImageListView2
            // 
            this.defaultImageListView2.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.defaultImageListView2.BackColor = System.Drawing.Color.Silver;
            this.defaultImageListView2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.defaultImageListView2.LargeImageList = this.defaultImageList;
            this.defaultImageListView2.Location = new System.Drawing.Point(654, 157);
            this.defaultImageListView2.Margin = new System.Windows.Forms.Padding(0);
            this.defaultImageListView2.MultiSelect = false;
            this.defaultImageListView2.Name = "defaultImageListView2";
            this.defaultImageListView2.Size = new System.Drawing.Size(207, 203);
            this.defaultImageListView2.TabIndex = 25;
            this.defaultImageListView2.UseCompatibleStateImageBehavior = false;
            this.defaultImageListView2.ItemActivate += new System.EventHandler(this.Player2DefaultImageList_ItemActivate);
            // 
            // defaultImageListView3
            // 
            this.defaultImageListView3.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.defaultImageListView3.BackColor = System.Drawing.Color.Silver;
            this.defaultImageListView3.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.defaultImageListView3.LargeImageList = this.defaultImageList;
            this.defaultImageListView3.Location = new System.Drawing.Point(1116, 157);
            this.defaultImageListView3.Margin = new System.Windows.Forms.Padding(0);
            this.defaultImageListView3.MultiSelect = false;
            this.defaultImageListView3.Name = "defaultImageListView3";
            this.defaultImageListView3.Size = new System.Drawing.Size(207, 203);
            this.defaultImageListView3.TabIndex = 26;
            this.defaultImageListView3.UseCompatibleStateImageBehavior = false;
            this.defaultImageListView3.ItemActivate += new System.EventHandler(this.Player3DefaultImageList_ItemActivate);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(521, 374);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 25);
            this.label3.TabIndex = 27;
            this.label3.Text = "Preview";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(999, 374);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 25);
            this.label4.TabIndex = 28;
            this.label4.Text = "Preview";
            // 
            // player2PictureBox
            // 
            this.player2PictureBox.BackColor = System.Drawing.Color.Silver;
            this.player2PictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.player2PictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.player2PictureBox.Location = new System.Drawing.Point(654, 374);
            this.player2PictureBox.Name = "player2PictureBox";
            this.player2PictureBox.Size = new System.Drawing.Size(126, 116);
            this.player2PictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.player2PictureBox.TabIndex = 29;
            this.player2PictureBox.TabStop = false;
            // 
            // player3PictureBox
            // 
            this.player3PictureBox.BackColor = System.Drawing.Color.Silver;
            this.player3PictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.player3PictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.player3PictureBox.Location = new System.Drawing.Point(1116, 374);
            this.player3PictureBox.Name = "player3PictureBox";
            this.player3PictureBox.Size = new System.Drawing.Size(126, 116);
            this.player3PictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.player3PictureBox.TabIndex = 30;
            this.player3PictureBox.TabStop = false;
            // 
            // cancelButton
            // 
            this.cancelButton.BackColor = System.Drawing.Color.Transparent;
            this.cancelButton.BackgroundImage = global::BlackJack.Properties.Resources.ButtonSquare;
            this.cancelButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.cancelButton.FlatAppearance.BorderSize = 0;
            this.cancelButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cancelButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelButton.Location = new System.Drawing.Point(1215, 625);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(185, 41);
            this.cancelButton.TabIndex = 34;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = false;
            this.cancelButton.Click += new System.EventHandler(this.btnCance_Click);
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.Transparent;
            this.button5.BackgroundImage = global::BlackJack.Properties.Resources.ButtonSquare;
            this.button5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button5.FlatAppearance.BorderSize = 0;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.Location = new System.Drawing.Point(978, 625);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(185, 41);
            this.button5.TabIndex = 35;
            this.button5.Text = "All Set";
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // OptionsForm
            // 
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.BackgroundImage = global::BlackJack.Properties.Resources.backGreen;
            this.ClientSize = new System.Drawing.Size(1484, 761);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.player3PictureBox);
            this.Controls.Add(this.player2PictureBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.defaultImageListView3);
            this.Controls.Add(this.defaultImageListView2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.player3NameTextBox);
            this.Controls.Add(this.player2NameTextBox);
            this.Controls.Add(this.player3NameLabel);
            this.Controls.Add(this.player2NameLabel);
            this.Controls.Add(this.iconPictureBox);
            this.Controls.Add(this.previewLabel);
            this.Controls.Add(this.defaultImageListView1);
            this.Controls.Add(this.playerPictureLabel);
            this.Controls.Add(this.player1PictureBox);
            this.Controls.Add(this.player1NameLabel);
            this.Controls.Add(this.player1NameTextBox);
            this.Controls.Add(this.optionsLabel);
            this.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "OptionsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BlackJack Options";
            this.Load += new System.EventHandler(this.OptionsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.player1PictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.player2PictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.player3PictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label optionsLabel;
        private System.Windows.Forms.TextBox player1NameTextBox;
        private System.Windows.Forms.Label player1NameLabel;
        private System.Windows.Forms.PictureBox player1PictureBox;
        private System.Windows.Forms.Label playerPictureLabel;
        private System.Windows.Forms.OpenFileDialog selectFileDialog;
        private System.Windows.Forms.ListView defaultImageListView1;
        private System.Windows.Forms.ImageList defaultImageList;
        private System.Windows.Forms.Label previewLabel;
        private System.Windows.Forms.PictureBox iconPictureBox;
        private System.Windows.Forms.Label player2NameLabel;
        private System.Windows.Forms.Label player3NameLabel;
        private System.Windows.Forms.TextBox player2NameTextBox;
        private System.Windows.Forms.TextBox player3NameTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListView defaultImageListView2;
        private System.Windows.Forms.ListView defaultImageListView3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox player2PictureBox;
        private System.Windows.Forms.PictureBox player3PictureBox;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button button5;
    }
}

