using System.Drawing;
using System.Windows.Forms;

namespace GameClient
{
    partial class HathatulBoardForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
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
            this.nickname = new System.Windows.Forms.Label();
            this.thirdPlayer = new System.Windows.Forms.Label();
            this.firstPlayer = new System.Windows.Forms.Label();
            this.thirdPlayerPanel = new System.Windows.Forms.Panel();
            this.fourthPlayerPanel = new System.Windows.Forms.Panel();
            this.secondPlayerPanel = new System.Windows.Forms.Panel();
            this.firstPlayerPanel = new System.Windows.Forms.Panel();
            this.hathatul = new System.Windows.Forms.Button();
            this.isItYourTurn = new System.Windows.Forms.Label();
            this.turnEnded = new System.Windows.Forms.Label();
            this.Timer = new System.Windows.Forms.Timer(this.components);
            this.trashCards = new System.Windows.Forms.PictureBox();
            this.stackOfCards = new System.Windows.Forms.PictureBox();
            this.timerButton = new GameClient.CircleButton();
            this.thirdPlayerPanel.SuspendLayout();
            this.firstPlayerPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trashCards)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stackOfCards)).BeginInit();
            this.SuspendLayout();
            // 
            // nickname
            // 
            this.nickname.Font = new System.Drawing.Font("Nirmala UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nickname.Location = new System.Drawing.Point(-3, -1);
            this.nickname.Name = "nickname";
            this.nickname.Size = new System.Drawing.Size(213, 110);
            this.nickname.TabIndex = 0;
            this.nickname.Text = "name";
            // 
            // thirdPlayer
            // 
            this.thirdPlayer.AutoSize = true;
            this.thirdPlayer.Font = new System.Drawing.Font("Nirmala UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.thirdPlayer.Location = new System.Drawing.Point(371, 14);
            this.thirdPlayer.Name = "thirdPlayer";
            this.thirdPlayer.Size = new System.Drawing.Size(43, 25);
            this.thirdPlayer.TabIndex = 14;
            this.thirdPlayer.Text = "hey";
            // 
            // firstPlayer
            // 
            this.firstPlayer.AutoSize = true;
            this.firstPlayer.Font = new System.Drawing.Font("Nirmala UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.firstPlayer.Location = new System.Drawing.Point(365, 264);
            this.firstPlayer.Name = "firstPlayer";
            this.firstPlayer.Size = new System.Drawing.Size(43, 25);
            this.firstPlayer.TabIndex = 18;
            this.firstPlayer.Text = "hey";
            // 
            // thirdPlayerPanel
            // 
            this.thirdPlayerPanel.Controls.Add(this.thirdPlayer);
            this.thirdPlayerPanel.Location = new System.Drawing.Point(362, 12);
            this.thirdPlayerPanel.Name = "thirdPlayerPanel";
            this.thirdPlayerPanel.Size = new System.Drawing.Size(905, 231);
            this.thirdPlayerPanel.TabIndex = 27;
            // 
            // fourthPlayerPanel
            // 
            this.fourthPlayerPanel.Location = new System.Drawing.Point(1244, 53);
            this.fourthPlayerPanel.Name = "fourthPlayerPanel";
            this.fourthPlayerPanel.Size = new System.Drawing.Size(267, 747);
            this.fourthPlayerPanel.TabIndex = 28;
            // 
            // secondPlayerPanel
            // 
            this.secondPlayerPanel.Location = new System.Drawing.Point(52, 59);
            this.secondPlayerPanel.Name = "secondPlayerPanel";
            this.secondPlayerPanel.Size = new System.Drawing.Size(319, 774);
            this.secondPlayerPanel.TabIndex = 29;
            // 
            // firstPlayerPanel
            // 
            this.firstPlayerPanel.Controls.Add(this.timerButton);
            this.firstPlayerPanel.Controls.Add(this.hathatul);
            this.firstPlayerPanel.Controls.Add(this.firstPlayer);
            this.firstPlayerPanel.Location = new System.Drawing.Point(368, 499);
            this.firstPlayerPanel.Name = "firstPlayerPanel";
            this.firstPlayerPanel.Size = new System.Drawing.Size(879, 301);
            this.firstPlayerPanel.TabIndex = 30;
            // 
            // hathatul
            // 
            this.hathatul.Enabled = false;
            this.hathatul.Font = new System.Drawing.Font("Nirmala UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hathatul.Location = new System.Drawing.Point(699, 192);
            this.hathatul.Name = "hathatul";
            this.hathatul.Size = new System.Drawing.Size(128, 75);
            this.hathatul.TabIndex = 19;
            this.hathatul.Text = "Hathatul";
            this.hathatul.UseVisualStyleBackColor = true;
            this.hathatul.Click += new System.EventHandler(this.Hathatul_Click);
            // 
            // isItYourTurn
            // 
            this.isItYourTurn.AutoSize = true;
            this.isItYourTurn.BackColor = System.Drawing.Color.Red;
            this.isItYourTurn.Font = new System.Drawing.Font("Nirmala UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.isItYourTurn.ForeColor = System.Drawing.SystemColors.ControlText;
            this.isItYourTurn.Location = new System.Drawing.Point(1273, 9);
            this.isItYourTurn.Name = "isItYourTurn";
            this.isItYourTurn.Size = new System.Drawing.Size(176, 32);
            this.isItYourTurn.TabIndex = 32;
            this.isItYourTurn.Text = "Not Your Turn";
            // 
            // turnEnded
            // 
            this.turnEnded.Enabled = false;
            this.turnEnded.Font = new System.Drawing.Font("Nirmala UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.turnEnded.Location = new System.Drawing.Point(365, 235);
            this.turnEnded.Name = "turnEnded";
            this.turnEnded.Size = new System.Drawing.Size(234, 103);
            this.turnEnded.TabIndex = 33;
            this.turnEnded.Text = ".";
            // 
            // Timer
            // 
            this.Timer.Interval = 1000;
            this.Timer.Tick += new System.EventHandler(this.Timer_Tick);
            // 
            // trashCards
            // 
            this.trashCards.Location = new System.Drawing.Point(643, 286);
            this.trashCards.Name = "trashCards";
            this.trashCards.Size = new System.Drawing.Size(116, 160);
            this.trashCards.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.trashCards.TabIndex = 10;
            this.trashCards.TabStop = false;
            this.trashCards.Click += new System.EventHandler(this.TrashCards_Click);
            // 
            // stackOfCards
            // 
            this.stackOfCards.Location = new System.Drawing.Point(1006, 286);
            this.stackOfCards.Name = "stackOfCards";
            this.stackOfCards.Size = new System.Drawing.Size(129, 160);
            this.stackOfCards.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.stackOfCards.TabIndex = 9;
            this.stackOfCards.TabStop = false;
            this.stackOfCards.Click += new System.EventHandler(this.StackOfCards_Click);
            // 
            // timerButton
            // 
            this.timerButton.BackColor = System.Drawing.Color.Coral;
            this.timerButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.timerButton.Enabled = false;
            this.timerButton.FlatAppearance.BorderSize = 0;
            this.timerButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.timerButton.Font = new System.Drawing.Font("Nirmala UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timerButton.Location = new System.Drawing.Point(9, 14);
            this.timerButton.Name = "timerButton";
            this.timerButton.Size = new System.Drawing.Size(71, 68);
            this.timerButton.TabIndex = 21;
            this.timerButton.Text = "30sec";
            this.timerButton.UseVisualStyleBackColor = false;
            this.timerButton.Visible = false;
            // 
            // HathatulBoardForm
            // 
            this.ClientSize = new System.Drawing.Size(1541, 812);
            this.Controls.Add(this.turnEnded);
            this.Controls.Add(this.stackOfCards);
            this.Controls.Add(this.fourthPlayerPanel);
            this.Controls.Add(this.isItYourTurn);
            this.Controls.Add(this.secondPlayerPanel);
            this.Controls.Add(this.thirdPlayerPanel);
            this.Controls.Add(this.trashCards);
            this.Controls.Add(this.nickname);
            this.Controls.Add(this.firstPlayerPanel);
            this.Font = new System.Drawing.Font("Vivaldi", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "HathatulBoardForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.GameBoard_Load_1);
            this.thirdPlayerPanel.ResumeLayout(false);
            this.thirdPlayerPanel.PerformLayout();
            this.firstPlayerPanel.ResumeLayout(false);
            this.firstPlayerPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trashCards)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stackOfCards)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label username;
       
        public System.Windows.Forms.PictureBox pictureBox2;
        public System.Windows.Forms.PictureBox stackOfCards;
        public System.Windows.Forms.PictureBox trashCards;
        public System.Windows.Forms.Label nickname;
        public System.Windows.Forms.Label thirdPlayer;
        public System.Windows.Forms.Label firstPlayer;
        public System.Windows.Forms.Panel thirdPlayerPanel;
        public System.Windows.Forms.Panel fourthPlayerPanel;
        public System.Windows.Forms.Panel secondPlayerPanel;
        public System.Windows.Forms.Panel firstPlayerPanel;
        public System.Windows.Forms.Label isItYourTurn;
        public System.Windows.Forms.Button hathatul;
        public Label turnEnded;
        public Timer Timer;
        private CircleButton timerButton;
    }
}