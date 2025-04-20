namespace GameClient
{
    partial class WaitingRoom
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
            this.nickname = new System.Windows.Forms.Label();
            this.howManyAreConnected = new System.Windows.Forms.Label();
            this.StartGame = new System.Windows.Forms.Button();
            this.Rules = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.Rules)).BeginInit();
            this.SuspendLayout();
            // 
            // nickname
            // 
            this.nickname.BackColor = System.Drawing.Color.Transparent;
            this.nickname.Font = new System.Drawing.Font("MV Boli", 24F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nickname.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.nickname.Location = new System.Drawing.Point(2, 9);
            this.nickname.Name = "nickname";
            this.nickname.Size = new System.Drawing.Size(301, 154);
            this.nickname.TabIndex = 0;
            this.nickname.Text = "name";
            // 
            // howManyAreConnected
            // 
            this.howManyAreConnected.BackColor = System.Drawing.Color.Transparent;
            this.howManyAreConnected.Font = new System.Drawing.Font("Playbill", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.howManyAreConnected.ForeColor = System.Drawing.Color.White;
            this.howManyAreConnected.Location = new System.Drawing.Point(485, 9);
            this.howManyAreConnected.Name = "howManyAreConnected";
            this.howManyAreConnected.Size = new System.Drawing.Size(377, 174);
            this.howManyAreConnected.TabIndex = 1;
            this.howManyAreConnected.Text = "playersConnected: 0";
            // 
            // StartGame
            // 
            this.StartGame.Location = new System.Drawing.Point(365, 393);
            this.StartGame.Name = "StartGame";
            this.StartGame.Size = new System.Drawing.Size(121, 77);
            this.StartGame.TabIndex = 2;
            this.StartGame.Text = "Start";
            this.StartGame.UseVisualStyleBackColor = true;
            this.StartGame.Click += new System.EventHandler(this.StartGame_Click);
            // 
            // Rules
            // 
            this.Rules.BackColor = System.Drawing.Color.Transparent;
            this.Rules.Image = global::GameClient.Properties.Resources.RulesBook_removebg_preview;
            this.Rules.Location = new System.Drawing.Point(496, 393);
            this.Rules.Name = "Rules";
            this.Rules.Size = new System.Drawing.Size(100, 94);
            this.Rules.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Rules.TabIndex = 3;
            this.Rules.TabStop = false;
            this.Rules.Click += new System.EventHandler(this.Rules_Click);
            // 
            // WaitingRoom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::GameClient.Properties.Resources.waitingroom;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(813, 572);
            this.Controls.Add(this.Rules);
            this.Controls.Add(this.StartGame);
            this.Controls.Add(this.howManyAreConnected);
            this.Controls.Add(this.nickname);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "WaitingRoom";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "WaitingRoom";
            ((System.ComponentModel.ISupportInitialize)(this.Rules)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Label nickname;
        public System.Windows.Forms.Label howManyAreConnected;
        private System.Windows.Forms.Button StartGame;
        private System.Windows.Forms.PictureBox Rules;
    }
}