using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameClient
{
    public  class CreateMidRun
    {// this class is incharge of creating all of the cards mid run.   

        /// <summary>
        /// contains the object of the current runned HathatulBoardForm
        /// </summary>
        HathatulBoardForm board;
       
        /// <summary>
        /// default constructor. creates the board.
        /// </summary>
        /// <param name="board"></param>
        public CreateMidRun(HathatulBoardForm board)
        {
            this.board = board;
        }
        
        /// <summary>
        /// this function is incharge of creating all of the cards. this is the handler which calls, one of the four function that creates each player cards. 
        /// depending on how many players are in the game
        /// </summary>
        /// <param name="PlayerConnected"></param>
        public void CreateAllOfCards(string PlayerConnected)
        {
            board.secondPlayerPanel.Visible = false;
            board.fourthPlayerPanel.Visible = false;
            CreatePlayer1Cards();
            CreatePlayer3Cards();
            if (PlayerConnected == "3")
            {
                board.secondPlayerPanel.Visible = true;
                CreatePlayer2Cards();
                RotateSecondPlayerImages();
                board.secondPlayer = new System.Windows.Forms.Label();
                board.secondPlayer.Location = new System.Drawing.Point(15, 435);
                board.secondPlayer.Name = "secondPlayer";
                board.secondPlayer.Size = new System.Drawing.Size(136, 128);
                board.secondPlayer.TabIndex = 16;
                board.secondPlayer.Text = "hey";
                board.secondPlayer.AutoSize = true;
                board.secondPlayer.Font = new Font("Nirmala UI", 14, FontStyle.Bold);
                board.Controls.Add(board.secondPlayer);
                board.secondPlayerPanel.Controls.Add(board.secondPlayer);
            }
            if (PlayerConnected == "4")
            {
                board.fourthPlayerPanel.Visible = true;
                CreatePlayer4Cards();
                RotateFourthPlayerImages();
                board.fourthPlayer = new System.Windows.Forms.Label();
                board.fourthPlayer.Location = new System.Drawing.Point(200, 140);
                board.fourthPlayer.Name = "ForthPlayer";
                board.fourthPlayer.Size = new System.Drawing.Size(120, 63);
                board.fourthPlayer.TabIndex = 17;
                board.fourthPlayer.Text = "hey";
                board.fourthPlayer.AutoSize = true;
                board.fourthPlayer.Font = new Font("Nirmala UI", 14, FontStyle.Bold);
                board.Controls.Add(board.fourthPlayer);
                board.fourthPlayerPanel.Controls.Add(board.fourthPlayer);
                board.secondPlayerPanel.Visible = true;
                CreatePlayer2Cards();
                RotateSecondPlayerImages();
                board.secondPlayer = new System.Windows.Forms.Label();
                board.secondPlayer.Location = new System.Drawing.Point(15, 435);
                board.secondPlayer.Name = "secondPlayer";
                board.secondPlayer.Size = new System.Drawing.Size(136, 128);
                board.secondPlayer.TabIndex = 16;
                board.secondPlayer.Text = "hey";
                board.secondPlayer.AutoSize = true;
                board.secondPlayer.Font = new Font("Nirmala UI", 14, FontStyle.Bold);
                board.Controls.Add(board.secondPlayer);
                board.secondPlayerPanel.Controls.Add(board.secondPlayer);

            }
        }

        /// <summary>
        /// this function creates all of the cards for player 2. 4 cards and 2 drawn cards. and it also calls a function which spins the cards 90 degrees.
        /// </summary>
        public void CreatePlayer2Cards()
        {
            for (int i = 1; i <= 4; i++)
            {
                board.PlayersCards[1,i - 1] = new PictureBox();
                ((System.ComponentModel.ISupportInitialize)(board.PlayersCards[1, i - 1])).BeginInit();
                int k = 135 * (i - 1);
                string player = "player2_" + i;
                board.PlayersCards[1, i - 1].Image = (Image)Properties.Resources.ResourceManager.GetObject("backOfCard");
                board.PlayersCards[1, i - 1].Location = new System.Drawing.Point(138, 70 + k);
                board.PlayersCards[1, i - 1].Name = player;
                board.PlayersCards[1, i - 1].Size = new System.Drawing.Size(122, 156);
                board.PlayersCards[1, i - 1].SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                board.PlayersCards[1, i - 1].TabIndex = i;
                board.PlayersCards[1, i - 1].TabStop = false;
                if (i == 1)
                {
                    board.PlayersCards[1,i - 1].Click += new System.EventHandler(board.Player2_1Click);
                }
                if (i == 2)
                {
                   board.PlayersCards[1,i - 1].Click += new System.EventHandler(board.Player2_2Click);
                }
                if (i == 3)
                {
                    board.PlayersCards[1, i - 1].Click += new System.EventHandler(board.Player2_3Click);
                }
                if (i == 4)
                {
                    board.PlayersCards[1, i - 1].Click += new System.EventHandler(board.Player2_4Click);
                }
                board.Controls.Add(board.PlayersCards[1, i - 1]);
                board.PlayersCards[1, i - 1].Refresh();
                board.secondPlayerPanel.Controls.Add(board.PlayersCards[1, i - 1]);
                ((System.ComponentModel.ISupportInitialize)(board.PlayersCards[1, i - 1])).EndInit();
            }
            board.secondPlayerFirstCardDrawn = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(board.secondPlayerFirstCardDrawn)).BeginInit();
            board.secondPlayerFirstCardDrawn.Image = (Image)Properties.Resources.ResourceManager.GetObject("backOfCard");
            board.secondPlayerFirstCardDrawn.Location = new System.Drawing.Point(165, 600);
            board.secondPlayerFirstCardDrawn.Name = "SecondPlayerFirstCardDrawn";
            board.secondPlayerFirstCardDrawn.Size = new System.Drawing.Size(91, 146);
            board.secondPlayerFirstCardDrawn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            board.secondPlayerFirstCardDrawn.TabIndex = 28;
            board.secondPlayerFirstCardDrawn.TabStop = false;
            board.secondPlayerFirstCardDrawn.Visible = false;
            board.Controls.Add(board.secondPlayerFirstCardDrawn);
            board.secondPlayerPanel.Controls.Add(board.secondPlayerFirstCardDrawn);
            ((System.ComponentModel.ISupportInitialize)(board.secondPlayerFirstCardDrawn)).EndInit();

            board.secondPlayerSecondCardDrawn = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(board.secondPlayerSecondCardDrawn)).BeginInit();
            board.secondPlayerSecondCardDrawn.Image = (Image)Properties.Resources.ResourceManager.GetObject("backOfCard");
            board.secondPlayerSecondCardDrawn.Location = new System.Drawing.Point(165, 650);
            board.secondPlayerSecondCardDrawn.Name = "SecondPlayerSecondCardDrawn";
            board.secondPlayerSecondCardDrawn.Size = new System.Drawing.Size(91, 146);
            board.secondPlayerSecondCardDrawn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            board.secondPlayerSecondCardDrawn.TabIndex = 27;
            board.secondPlayerSecondCardDrawn.TabStop = false;
            board.secondPlayerSecondCardDrawn.Visible = false;
            board.Controls.Add(board.secondPlayerSecondCardDrawn);
            board.secondPlayerPanel.Controls.Add(board.secondPlayerSecondCardDrawn);
            ((System.ComponentModel.ISupportInitialize)(board.secondPlayerSecondCardDrawn)).EndInit();
        }

        /// <summary>
        /// this function creates all of the cards for player 4. 4 cards and 2 drawn cards. and it also calls a function which spins the cards 90 degress.
        /// </summary>
        public void CreatePlayer4Cards()
        {
            for (int i = 1; i <= 4; i++)
            {
                board.PlayersCards[3, i - 1] = new PictureBox();
                ((System.ComponentModel.ISupportInitialize)(board.PlayersCards[3,i - 1])).BeginInit();
                int k = 135 * (i - 1);
                string player = "player4_" + i;
                board.PlayersCards[3, i - 1].Image = (Image)Properties.Resources.ResourceManager.GetObject("backOfCard");
                board.PlayersCards[3, i - 1].Location = new System.Drawing.Point(5, 70 + k);
                board.PlayersCards[3, i - 1].Name = player;
                board.PlayersCards[3, i - 1].Size = new System.Drawing.Size(122, 156);
                board.PlayersCards[3, i - 1].SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                board.PlayersCards[3, i - 1].TabIndex = i;
                board.PlayersCards[3, i - 1].TabStop = false;
                if (i == 1)
                {
                    board.PlayersCards[3, i - 1].Click += new System.EventHandler(board.Player4_1Click);
                }
                if (i == 2)
                {
                    board.PlayersCards[3, i - 1].Click += new System.EventHandler(board.Player4_2Click);
                }
                if (i == 3)
                {
                    board.PlayersCards[3, i - 1].Click += new System.EventHandler(board.Player4_3Click);
                }
                if (i == 4)
                {
                    board.PlayersCards[3, i - 1].Click += new System.EventHandler(board.Player4_4Click);
                }
                board.Controls.Add(board.PlayersCards[3, i - 1]);
                board.PlayersCards[3, i - 1].Refresh();
                board.fourthPlayerPanel.Controls.Add(board.PlayersCards[3, i - 1]);
                ((System.ComponentModel.ISupportInitialize)(board.PlayersCards[3,i - 1])).EndInit();
            }
            board.fourthPlayerFirstCardDrawn = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(board.fourthPlayerFirstCardDrawn)).BeginInit();
            board.fourthPlayerFirstCardDrawn.Image = (Image)Properties.Resources.ResourceManager.GetObject("backOfCard");
            board.fourthPlayerFirstCardDrawn.Location = new System.Drawing.Point(50, 600);
            board.fourthPlayerFirstCardDrawn.Name = "ForthPlayerFirstCardDrawn";
            board.fourthPlayerFirstCardDrawn.Size = new System.Drawing.Size(91, 146);
            board.fourthPlayerFirstCardDrawn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            board.fourthPlayerFirstCardDrawn.TabIndex = 28;
            board.fourthPlayerFirstCardDrawn.TabStop = false;
            board.fourthPlayerFirstCardDrawn.Visible = false;
            board.Controls.Add(board.fourthPlayerFirstCardDrawn);
            board.fourthPlayerPanel.Controls.Add(board.fourthPlayerFirstCardDrawn);
            ((System.ComponentModel.ISupportInitialize)(board.fourthPlayerFirstCardDrawn)).EndInit();


            board.fourthPlayerSecondCardDrawn = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(board.fourthPlayerSecondCardDrawn)).BeginInit();
            board.fourthPlayerSecondCardDrawn.Image = (Image)Properties.Resources.ResourceManager.GetObject("backOfCard");
            board.fourthPlayerSecondCardDrawn.Location = new System.Drawing.Point(50, 650);
            board.fourthPlayerSecondCardDrawn.Name = "ForthPlayerSecondCardDrawn";
            board.fourthPlayerSecondCardDrawn.Size = new System.Drawing.Size(91, 146);
            board.fourthPlayerSecondCardDrawn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            board.fourthPlayerSecondCardDrawn.TabIndex = 27;
            board.fourthPlayerSecondCardDrawn.TabStop = false;
            board.fourthPlayerSecondCardDrawn.Visible = false;
            board.Controls.Add(board.secondPlayerSecondCardDrawn);
            board.fourthPlayerPanel.Controls.Add(board.fourthPlayerSecondCardDrawn);
            ((System.ComponentModel.ISupportInitialize)(board.fourthPlayerSecondCardDrawn)).EndInit();
        }

        /// <summary>
        /// this function creates all of the cards for player 3. 4 cards and 2 drawn cards.
        /// </summary>
        public void CreatePlayer3Cards()
        {
            for (int i = 1; i <= 4; i++)
            {
                board.PlayersCards[2, i - 1] = new PictureBox();
                ((System.ComponentModel.ISupportInitialize)(board.PlayersCards[2, i - 1])).BeginInit();
                int k = 150 * (i - 1);
                string player = "player3_" + i;
                board.PlayersCards[2, i - 1].Image = (Image)Properties.Resources.ResourceManager.GetObject("backOfCard");
                board.PlayersCards[2, i - 1].Location = new System.Drawing.Point(85 + k, 50);
                board.PlayersCards[2, i - 1].Name = player;
                board.PlayersCards[2, i - 1].Size = new System.Drawing.Size(122, 156);
                board.PlayersCards[2, i - 1].SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                board.PlayersCards[2, i - 1].TabIndex = i;
                board.PlayersCards[2, i - 1].TabStop = false;
                if (i == 1)
                {
                    board.PlayersCards[2, i - 1].Click += new System.EventHandler(board.Player3_1Click);
                }
                if (i == 2)
                {
                    board.PlayersCards[2, i - 1].Click += new System.EventHandler(board.Player3_2Click);
                }
                if (i == 3)
                {
                    board.PlayersCards[2, i - 1].Click += new System.EventHandler(board.Player3_3Click);
                }
                if (i == 4)
                {
                    board.PlayersCards[2, i - 1].Click += new System.EventHandler(board.Player3_4Click);
                }
                board.Controls.Add(board.PlayersCards[2, i - 1]);
                board.PlayersCards[2, i - 1].Refresh();
                board.thirdPlayerPanel.Controls.Add(board.PlayersCards[2, i - 1]);
                ((System.ComponentModel.ISupportInitialize)(board.PlayersCards[2, i - 1])).EndInit();
            }
            board.thirdPlayerFirstCardDrawn = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(board.thirdPlayerFirstCardDrawn)).BeginInit();
            board.thirdPlayerPanel.Controls.Add(board.thirdPlayerFirstCardDrawn);
            board.thirdPlayerFirstCardDrawn.Image = (Image)Properties.Resources.ResourceManager.GetObject("backOfCard");
            board.thirdPlayerFirstCardDrawn.Location = new System.Drawing.Point(691, 67);
            board.thirdPlayerFirstCardDrawn.Name = "ThirdPlayerFirstCardDrawn";
            board.thirdPlayerFirstCardDrawn.Size = new System.Drawing.Size(91, 146);
            board.thirdPlayerFirstCardDrawn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            board.thirdPlayerFirstCardDrawn.TabIndex = 29;
            board.thirdPlayerFirstCardDrawn.TabStop = false;
            board.thirdPlayerFirstCardDrawn.Visible = false;
            board.Controls.Add(board.thirdPlayerFirstCardDrawn);
            board.thirdPlayerPanel.Controls.Add(board.thirdPlayerFirstCardDrawn);
            ((System.ComponentModel.ISupportInitialize)(board.thirdPlayerFirstCardDrawn)).EndInit();

            board.thirdPlayerSecondCardDrawn = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(board.thirdPlayerSecondCardDrawn)).BeginInit();
            board.thirdPlayerSecondCardDrawn.Image = (Image)Properties.Resources.ResourceManager.GetObject("backOfCard");
            board.thirdPlayerSecondCardDrawn.Location = new System.Drawing.Point(788, 67);
            board.thirdPlayerSecondCardDrawn.Name = "ThirdPlayerSecondCardDrawn";
            board.thirdPlayerSecondCardDrawn.Size = new System.Drawing.Size(91, 146);
            board.thirdPlayerSecondCardDrawn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            board.thirdPlayerSecondCardDrawn.TabIndex = 29;
            board.thirdPlayerSecondCardDrawn.TabStop = false;
            board.thirdPlayerSecondCardDrawn.Visible = false;
            board.Controls.Add(board.thirdPlayerSecondCardDrawn);
            board.thirdPlayerPanel.Controls.Add(board.thirdPlayerSecondCardDrawn);
            ((System.ComponentModel.ISupportInitialize)(board.thirdPlayerSecondCardDrawn)).EndInit();

        }

        /// <summary>
        /// this function creates all of the cards for player 1. 4 cards and 3 drawn cards, 1 for normal draw, and two for SpecialCase DrawTwo
        /// </summary>
        public void CreatePlayer1Cards()
        {
            for (int i = 1; i <= 4; i++)
            {
                board.PlayersCards[0,i - 1] = new PictureBox();
                ((System.ComponentModel.ISupportInitialize)(board.PlayersCards[0, i - 1])).BeginInit();
                int k = 150 * (i - 1);
                string player = "player1_" + i;
                board.PlayersCards[0,i-1].Image = (Image)Properties.Resources.ResourceManager.GetObject("backOfCard");
                board.PlayersCards[0, i - 1].Location = new System.Drawing.Point(85 + k, 88);
                board.PlayersCards[0, i - 1].Name = player;
                board.PlayersCards[0, i - 1].Size = new System.Drawing.Size(122, 156);
                board.PlayersCards[0, i - 1].SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                board.PlayersCards[0, i - 1].TabIndex = i;
                board.PlayersCards[0, i - 1].TabStop = false;
                if (i == 1)
                {
                    board.PlayersCards[0, i - 1].Click += new System.EventHandler(board.Player1_1Click);
                    board.PlayersCards[0, i - 1].MouseDown += new System.Windows.Forms.MouseEventHandler(board.Player1_1_MouseDown);
                    board.PlayersCards[0, i - 1].MouseUp += new System.Windows.Forms.MouseEventHandler(board.Player1_1_MouseUp);
                }
                if (i == 2)
                {
                    board.PlayersCards[0, i - 1].Click += new System.EventHandler(board.Player1_2Click);
                    board.PlayersCards[0, i - 1].MouseDown += new System.Windows.Forms.MouseEventHandler(board.Player1_2_MouseDown);
                    board.PlayersCards[0, i - 1].MouseUp += new System.Windows.Forms.MouseEventHandler(board.Player1_2_MouseUp);
                }
                if (i == 3)
                {
                    board.PlayersCards[0, i - 1].Click += new System.EventHandler(board.Player1_3Click);
                    board.PlayersCards[0, i - 1].MouseDown += new System.Windows.Forms.MouseEventHandler(board.Player1_3_MouseDown);
                    board.PlayersCards[0, i - 1].MouseUp += new System.Windows.Forms.MouseEventHandler(board.Player1_3_MouseUp);
                }
                if (i == 4)
                {
                    board.PlayersCards[0, i - 1].Click += new System.EventHandler(board.Player1_4Click);
                    board.PlayersCards[0, i - 1].MouseDown += new System.Windows.Forms.MouseEventHandler(board.Player1_4_MouseDown);
                    board.PlayersCards[0, i - 1].MouseUp += new System.Windows.Forms.MouseEventHandler(board.Player1_4_MouseUp);
                }
                board.Controls.Add(board.PlayersCards[0, i - 1]);
                board.PlayersCards[0, i - 1].Refresh();
                board.firstPlayerPanel.Controls.Add(board.PlayersCards[0, i - 1]);
                ((System.ComponentModel.ISupportInitialize)(board.PlayersCards[0, i - 1])).EndInit();
            }

            board.yourDrawnCardFromStack = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(board.yourDrawnCardFromStack)).BeginInit();
            board.yourDrawnCardFromStack.Location = new System.Drawing.Point(685, 40);
            board.yourDrawnCardFromStack.Name = "yourDrawnCardFromStack";
            board.yourDrawnCardFromStack.Size = new System.Drawing.Size(91, 146);
            board.yourDrawnCardFromStack.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            board.yourDrawnCardFromStack.TabIndex = 11;
            board.yourDrawnCardFromStack.TabStop = false;
            board.yourDrawnCardFromStack.Visible = false;
            board.firstPlayerPanel.Controls.Add(board.yourDrawnCardFromStack);
            ((System.ComponentModel.ISupportInitialize)(board.yourDrawnCardFromStack)).EndInit();


            board.drawTwoFirstCard = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(board.drawTwoFirstCard)).BeginInit();
            board.drawTwoFirstCard.Location = new System.Drawing.Point(685, 40);
            board.drawTwoFirstCard.Name = "drawTwoFirstCard";
            board.drawTwoFirstCard.Size = new System.Drawing.Size(91, 146);
            board.drawTwoFirstCard.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            board.drawTwoFirstCard.TabIndex = 12;
            board.drawTwoFirstCard.TabStop = false;
            board.drawTwoFirstCard.Visible = false;
            board.drawTwoFirstCard.Click += new System.EventHandler(board.DrawTwoFirstCard_Click);
            board.firstPlayerPanel.Controls.Add(board.drawTwoFirstCard);
            ((System.ComponentModel.ISupportInitialize)(board.drawTwoFirstCard)).EndInit();

            board.drawTwoSecondCard = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(board.drawTwoSecondCard)).BeginInit();
            board.drawTwoSecondCard.Location = new System.Drawing.Point(782, 40);
            board.drawTwoSecondCard.Name = "drawTwoSecondCard";
            board.drawTwoSecondCard.Size = new System.Drawing.Size(91, 146);
            board.drawTwoSecondCard.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            board.drawTwoSecondCard.TabIndex = 13;
            board.drawTwoSecondCard.TabStop = false;
            board.drawTwoSecondCard.Visible = false;
            board.drawTwoSecondCard.Click += new System.EventHandler(board.DrawTwoSecondCard_Click);
            board.firstPlayerPanel.Controls.Add(board.drawTwoSecondCard);
            ((System.ComponentModel.ISupportInitialize)(board.drawTwoSecondCard)).EndInit();
        }

        /// <summary>
        /// this function rotates fourths player's cards by 90 degrees
        /// </summary>
        public void RotateFourthPlayerImages()
        {
            board.PlayersCards[3, 0].Image.RotateFlip(RotateFlipType.Rotate270FlipNone);
            int temp = board.PlayersCards[3, 0].Width;
            board.PlayersCards[3, 0].Width = board.PlayersCards[3, 0].Height + 15;
            board.PlayersCards[3, 0].Height = temp;

            board.PlayersCards[3, 1].Image.RotateFlip(RotateFlipType.Rotate270FlipNone);
            temp = board.PlayersCards[3, 1].Width;
            board.PlayersCards[3, 1].Width = board.PlayersCards[3, 1].Height + 15;
            board.PlayersCards[3, 1].Height = temp;

            board.PlayersCards[3, 2].Image.RotateFlip(RotateFlipType.Rotate270FlipNone);
            temp = board.PlayersCards[3, 2].Width;
            board.PlayersCards[3, 2].Width = board.PlayersCards[3, 2].Height + 15;
            board.PlayersCards[3, 2].Height = temp;

            board.PlayersCards[3, 3].Image.RotateFlip(RotateFlipType.Rotate270FlipNone);
            temp = board.PlayersCards[3, 3].Width;
            board.PlayersCards[3, 3].Width = board.PlayersCards[3, 3].Height + 15;
            board.PlayersCards[3, 3].Height = temp;

            board.fourthPlayerFirstCardDrawn.Image.RotateFlip(RotateFlipType.Rotate270FlipNone);
            temp = board.fourthPlayerFirstCardDrawn.Width;
            board.fourthPlayerFirstCardDrawn.Width = board.fourthPlayerFirstCardDrawn.Height + 15;
            board.fourthPlayerFirstCardDrawn.Height = temp;

            board.fourthPlayerSecondCardDrawn.Image.RotateFlip(RotateFlipType.Rotate270FlipNone);
            temp = board.fourthPlayerSecondCardDrawn.Width;
            board.fourthPlayerSecondCardDrawn.Width = board.fourthPlayerSecondCardDrawn.Height + 15;
            board.fourthPlayerSecondCardDrawn.Height = temp;
        }

        /// <summary>
        /// this function rotates second player's cards by 90 degrees
        /// </summary>
        public void RotateSecondPlayerImages()
        {
            board.PlayersCards[1, 0].Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
            int temp = board.PlayersCards[1, 0].Width;
            board.PlayersCards[1, 0].Width = board.PlayersCards[1, 0].Height + 15;
            board.PlayersCards[1, 0].Height = temp;

            board.PlayersCards[1, 1].Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
            temp = board.PlayersCards[1, 1].Width;
            board.PlayersCards[1, 1].Width = board.PlayersCards[1, 1].Height + 15;
            board.PlayersCards[1, 1].Height = temp;

            board.PlayersCards[1, 2].Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
            temp = board.PlayersCards[1, 2].Width;
            board.PlayersCards[1, 2].Width = board.PlayersCards[1, 2].Height + 15;
            board.PlayersCards[1, 2].Height = temp;

            board.PlayersCards[1, 3].Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
            temp = board.PlayersCards[1, 3].Width;
            board.PlayersCards[1, 3].Width = board.PlayersCards[1, 3].Height + 15;
            board.PlayersCards[1, 3].Height = temp;

            board.secondPlayerFirstCardDrawn.Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
            temp = board.secondPlayerFirstCardDrawn.Width;
            board.secondPlayerFirstCardDrawn.Width = board.secondPlayerFirstCardDrawn.Height + 15;
            board.secondPlayerFirstCardDrawn.Height = temp;

            board.secondPlayerSecondCardDrawn.Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
            temp = board.secondPlayerSecondCardDrawn.Width;
            board.secondPlayerSecondCardDrawn.Width = board.secondPlayerSecondCardDrawn.Height + 15;
            board.secondPlayerSecondCardDrawn.Height = temp;
        }
    }
}
