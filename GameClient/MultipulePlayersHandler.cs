using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace GameClient
{
    public  class MultipulePlayersHandler 
    {// this class is incharge of managing multiple players. for a single player. like showing all of the cards.
     // and showing the name of all the players.

        /// <summary>
        /// this property 'playerList' contains a list of all the players. of type 'Players'
        /// </summary>
        private List<Players> playerList;
        /// <summary>
        /// this property 'sit' contains the sit of this player
        /// </summary>
        public int sit;
       
        
        
        /// <summary>
        /// getters and setters for PlayerList
        /// </summary>
        public List<Players> PlayerList { get => playerList; set => playerList = value; }

        
        /// <summary>
        /// this function returns the sit of the player by its name.
        /// </summary>
        /// <param name="playerName"></param>
        /// <returns></returns>
        public int GetSeatNumber(string playerName)
        {
            foreach (Players player in PlayerList)
            {
                if (player.Name == playerName)
                {
                    return player.Sit;
                }
            }
            return -1;
        }

        /// <summary>
        /// this function creates the list of all the players. it, which contains the name and sit of the player
        /// </summary>
        /// <param name="allInfo"></param>
        public void CreateListOfPlayers(string allInfo)
        {
            
                allInfo = allInfo.Remove(allInfo.Length - 1);
            
            string[] playerData = allInfo.Split('|');

            // Create a list to hold Player objects
            PlayerList = new List<Players>();

            // Parse the player data and populate the players list
            for (int i = 0; i < playerData.Length; i += 2)
            {
                if (i + 1 < playerData.Length)
                {
                    string playerName = playerData[i + 1];
                    int seatNumber;
                    if (int.TryParse(playerData[i], out seatNumber))
                    {
                        // Create a new Player object and add it to the list
                        PlayerList.Add(new Players(playerName, seatNumber));
                    }
                }
            }
            // Sort the players array by seat number
            PlayerList.Sort((p1, p2) => p1.Sit.CompareTo(p2.Sit));
        }

        /// <summary>
        /// this function puts the name of the player located on with its sit.clock wise. sit 1 of its left will be sit 2. 
        /// </summary>
        public void ShowNameOnEachPlayerLocation()
        {
            sit = GetSeatNumber(HathatulClient.gb.username12);
            if (PlayerList.Count == 2)
            {
                if (sit == 1)
                {
                    HathatulClient.gb.firstPlayer.Text = PlayerList.ElementAt(0).Name;
                    HathatulClient.gb.firstPlayer.BackColor = Color.Green;
                    HathatulClient.gb.thirdPlayer.Text = PlayerList.ElementAt(1).Name;
                }
                if (sit == 2)
                {
                    HathatulClient.gb.firstPlayer.Text = PlayerList.ElementAt(1).Name;
                    HathatulClient.gb.thirdPlayer.BackColor = Color.Green; 
                    HathatulClient.gb.thirdPlayer.Text = PlayerList.ElementAt(0).Name;
                }
            }
            else
            {
                if (sit == 1)
                {
                    HathatulClient.gb.firstPlayer.BackColor = Color.Green;
                    HathatulClient.gb.firstPlayer.Text = PlayerList.ElementAt(0).Name;
                    HathatulClient.gb.secondPlayer.Text = PlayerList.ElementAt(1).Name;
                    HathatulClient.gb.thirdPlayer.Text = PlayerList.ElementAt(2).Name;
                    if (PlayerList.Count == 4)
                    {
                        HathatulClient.gb.fourthPlayer.Text = PlayerList.ElementAt(3).Name;
                    }
                }
                if (sit == 2)
                {
                    if (PlayerList.Count == 4)
                    {
                        HathatulClient.gb.fourthPlayer.Text = PlayerList.ElementAt(0).Name;
                        HathatulClient.gb.fourthPlayer.BackColor = Color.Green;
                        HathatulClient.gb.firstPlayer.Text = PlayerList.ElementAt(1).Name;
                        HathatulClient.gb.secondPlayer.Text = PlayerList.ElementAt(2).Name;
                        HathatulClient.gb.thirdPlayer.Text = PlayerList.ElementAt(3).Name;
                    }
                    if (PlayerList.Count == 3)
                    {
                        HathatulClient.gb.thirdPlayer.BackColor = Color.Green;
                        HathatulClient.gb.firstPlayer.Text = PlayerList.ElementAt(1).Name;
                        HathatulClient.gb.secondPlayer.Text = PlayerList.ElementAt(2).Name;
                        HathatulClient.gb.thirdPlayer.Text = PlayerList.ElementAt(0).Name;
                    }
                }
                if (sit == 3)
                {
                    if (PlayerList.Count == 4)
                    {
                        HathatulClient.gb.thirdPlayer.BackColor = Color.Green;
                        HathatulClient.gb.fourthPlayer.Text = PlayerList.ElementAt(1).Name;
                        HathatulClient.gb.firstPlayer.Text = PlayerList.ElementAt(2).Name;
                        HathatulClient.gb.secondPlayer.Text = PlayerList.ElementAt(3).Name;
                        HathatulClient.gb.thirdPlayer.Text = PlayerList.ElementAt(0).Name;
                    }
                    if (PlayerList.Count == 3)
                    {
                        HathatulClient.gb.secondPlayer.BackColor = Color.Green;
                        HathatulClient.gb.firstPlayer.Text = PlayerList.ElementAt(2).Name;
                        HathatulClient.gb.secondPlayer.Text = PlayerList.ElementAt(0).Name;
                        HathatulClient.gb.thirdPlayer.Text = PlayerList.ElementAt(1).Name;

                    }
                }
                if (sit == 4)
                {
                    if (PlayerList.Count == 4)
                    {
                        HathatulClient.gb.secondPlayer.BackColor = Color.Green;
                        HathatulClient.gb.fourthPlayer.Text = PlayerList.ElementAt(2).Name;
                        HathatulClient.gb.firstPlayer.Text = PlayerList.ElementAt(3).Name;
                        HathatulClient.gb.secondPlayer.Text = PlayerList.ElementAt(0).Name;
                        HathatulClient.gb.thirdPlayer.Text = PlayerList.ElementAt(1).Name;
                    }
                }
            }
        }

        /// <summary>
        /// this function shows all of the cards on the board
        /// </summary>
        /// <param name="info"></param>
        /// <param name="turnCards"></param>
        public void ShowCards(string info, CreateMidRun turnCards)
        {
            string[] Sits = info.Split(',');
            string[] Sit1Cards = Sits[0].Split('|');
            string[] Sit2Cards = Sits[1].Split('|');
            string[] Sit3Cards = null;
            string[] Sit4Cards = null;
            if (HathatulClient.gb.players.PlayerList.Count > 2)
            {
                Sit3Cards = Sits[2].Split('|');
            }
            if (HathatulClient.gb.players.PlayerList.Count > 3)
            {
                Sit4Cards = Sits[3].Split('|');
            }
            switch (sit) {
                case 1:
                    for (int i = 0; i < 4; i++)
                    {
                        HathatulClient.gb.PlayersCards[0, i].Image = (Image)Properties.Resources.ResourceManager.GetObject(Sit1Cards[i]);
                    }
                    if (playerList.Count == 2)
                    {
                        for (int i = 0; i < 4; i++)
                        {
                            HathatulClient.gb.PlayersCards[2, i].Image = (Image)Properties.Resources.ResourceManager.GetObject(Sit2Cards[3-i]);
                        }
                    }
                    if(playerList.Count>2)
                    {
                        for (int i = 0; i < 4; i++)
                        {
                            HathatulClient.gb.PlayersCards[1, i].Image = (Image)Properties.Resources.ResourceManager.GetObject(Sit2Cards[i]);
                            
                        }
                        turnCards.RotateSecondPlayerImages();
                        for (int j = 0; j < 4; j++)
                        {
                            HathatulClient.gb.PlayersCards[1, j].Height = HathatulClient.gb.PlayersCards[1, j].Height - 40;
                            HathatulClient.gb.PlayersCards[1, j].Width = HathatulClient.gb.PlayersCards[1, j].Width + 40;
                        }
                        for (int i = 0; i < 4; i++)
                        {
                            HathatulClient.gb.PlayersCards[2, i].Image = (Image)Properties.Resources.ResourceManager.GetObject(Sit3Cards[3 - i]);
                        }
                    }
                    if(playerList.Count == 4)
                    {
                        for (int i = 0; i < 4; i++)
                        {
                            HathatulClient.gb.PlayersCards[3, i].Image = (Image)Properties.Resources.ResourceManager.GetObject(Sit4Cards[i]);
                        }
                        turnCards.RotateFourthPlayerImages();
                        for (int i = 0; i < 4; i++)
                        {
                            HathatulClient.gb.PlayersCards[3, i].Height = HathatulClient.gb.PlayersCards[3, i].Height - 40;
                            HathatulClient.gb.PlayersCards[3, i].Width = HathatulClient.gb.PlayersCards[3, i].Width + 40;
                        }
                    }
                    break;
                case 2:
                    for (int i = 0; i < 4; i++)
                    {
                        HathatulClient.gb.PlayersCards[0, i].Image = (Image)Properties.Resources.ResourceManager.GetObject(Sit2Cards[i]);
                    }
                    if (playerList.Count == 2)
                    {
                        for (int i = 0; i < 4; i++)
                        {
                            HathatulClient.gb.PlayersCards[2, i].Image = (Image)Properties.Resources.ResourceManager.GetObject(Sit1Cards[3-i]);
                        }
                    }
                    if (playerList.Count == 3)
                    {
                        for (int i = 0; i < 4; i++)
                        {
                            HathatulClient.gb.PlayersCards[1, i].Image = (Image)Properties.Resources.ResourceManager.GetObject(Sit3Cards[i]);
                        }
                        turnCards.RotateSecondPlayerImages();
                        for (int j = 0; j < 4; j++)
                        {
                            HathatulClient.gb.PlayersCards[1, j].Height = HathatulClient.gb.PlayersCards[1, j].Height - 40;
                            HathatulClient.gb.PlayersCards[1, j].Width = HathatulClient.gb.PlayersCards[1, j].Width + 40;
                        }
                        for (int i = 0; i < 4; i++)
                        {
                            HathatulClient.gb.PlayersCards[2, i].Image = (Image)Properties.Resources.ResourceManager.GetObject(Sit1Cards[3-i]);
                        }
                    }
                    if (playerList.Count == 4)
                    {
                        for (int i = 0; i < 4; i++)
                        {
                            HathatulClient.gb.PlayersCards[1, i].Image = (Image)Properties.Resources.ResourceManager.GetObject(Sit3Cards[i]);
                            
                        }
                        turnCards.RotateSecondPlayerImages();
                        for (int j = 0; j < 4; j++)
                        {
                            HathatulClient.gb.PlayersCards[1, j].Height = HathatulClient.gb.PlayersCards[1, j].Height - 40;
                            HathatulClient.gb.PlayersCards[1, j].Width = HathatulClient.gb.PlayersCards[1, j].Width + 40;
                        }
                        for (int i = 0; i < 4; i++)
                        {
                            HathatulClient.gb.PlayersCards[2, i].Image = (Image)Properties.Resources.ResourceManager.GetObject(Sit4Cards[3-i]);
                        }
                        for (int i = 0; i < 4; i++)
                        {
                            HathatulClient.gb.PlayersCards[3, i].Image = (Image)Properties.Resources.ResourceManager.GetObject(Sit1Cards[i]);
                        }
                        turnCards.RotateFourthPlayerImages();
                        for (int i = 0; i < 4; i++)
                        {
                            HathatulClient.gb.PlayersCards[3, i].Height = HathatulClient.gb.PlayersCards[3, i].Height - 40;
                            HathatulClient.gb.PlayersCards[3, i].Width = HathatulClient.gb.PlayersCards[3, i].Width + 40;
                        }
                    }
                    break;
                case 3:
                    for (int i = 0; i < 4; i++)
                    {
                        HathatulClient.gb.PlayersCards[0, i].Image = (Image)Properties.Resources.ResourceManager.GetObject(Sit3Cards[i]);
                    }
                    if (playerList.Count == 3)
                    {
                        for (int i = 0; i < 4; i++)
                        {
                            HathatulClient.gb.PlayersCards[1, i].Image = (Image)Properties.Resources.ResourceManager.GetObject(Sit1Cards[i]);
                            
                        }
                        turnCards.RotateSecondPlayerImages();
                        for (int j = 0; j < 4; j++)
                        {
                            HathatulClient.gb.PlayersCards[1, j].Height = HathatulClient.gb.PlayersCards[1, j].Height - 40;
                            HathatulClient.gb.PlayersCards[1, j].Width = HathatulClient.gb.PlayersCards[1, j].Width + 40;
                        }
                        for (int i = 0; i < 4; i++)
                        {
                            HathatulClient.gb.PlayersCards[2, i].Image = (Image)Properties.Resources.ResourceManager.GetObject(Sit2Cards[3-i]);
                        }
                    }
                    if (playerList.Count == 4)
                    {
                        for (int i = 0; i < 4; i++)
                        {
                            HathatulClient.gb.PlayersCards[1, i].Image = (Image)Properties.Resources.ResourceManager.GetObject(Sit4Cards[i]);
                            
                        }
                        turnCards.RotateSecondPlayerImages();
                        for (int j = 0; j < 4; j++)
                        {
                            HathatulClient.gb.PlayersCards[1, j].Height = HathatulClient.gb.PlayersCards[1, j].Height - 40;
                            HathatulClient.gb.PlayersCards[1, j].Width = HathatulClient.gb.PlayersCards[1, j].Width + 40;
                        }
                        for (int i = 0; i < 4; i++)
                        {
                            HathatulClient.gb.PlayersCards[2, i].Image = (Image)Properties.Resources.ResourceManager.GetObject(Sit1Cards[3-i]);
                        }
                        for (int i = 0; i < 4; i++)
                        {
                            HathatulClient.gb.PlayersCards[3, i].Image = (Image)Properties.Resources.ResourceManager.GetObject(Sit2Cards[i]);
                        }
                        turnCards.RotateFourthPlayerImages();
                        for (int i = 0; i < 4; i++)
                        {
                            HathatulClient.gb.PlayersCards[3, i].Height = HathatulClient.gb.PlayersCards[3, i].Height - 40;
                            HathatulClient.gb.PlayersCards[3, i].Width = HathatulClient.gb.PlayersCards[3, i].Width + 40;
                        }
                    }
                    break;
                case 4:
                    for (int i = 0; i < 4; i++)
                    {
                        HathatulClient.gb.PlayersCards[0, i].Image = (Image)Properties.Resources.ResourceManager.GetObject(Sit4Cards[i]);
                        
                    }
                    for (int i = 0; i < 4; i++)
                    {
                        HathatulClient.gb.PlayersCards[1, i].Image = (Image)Properties.Resources.ResourceManager.GetObject(Sit1Cards[i]);
                    }
                    turnCards.RotateSecondPlayerImages();
                    for (int j = 0; j < 4; j++)
                    {
                        HathatulClient.gb.PlayersCards[1, j].Height = HathatulClient.gb.PlayersCards[1, j].Height - 40;
                        HathatulClient.gb.PlayersCards[1, j].Width = HathatulClient.gb.PlayersCards[1, j].Width + 40;
                    }
                    for (int i = 0; i < 4; i++)
                    {
                        HathatulClient.gb.PlayersCards[2, i].Image = (Image)Properties.Resources.ResourceManager.GetObject(Sit2Cards[3-i]);
                    }
                    for (int i = 0; i < 4; i++)
                    {
                        HathatulClient.gb.PlayersCards[3, i].Image = (Image)Properties.Resources.ResourceManager.GetObject(Sit3Cards[i]);   
                    }
                    turnCards.RotateFourthPlayerImages();
                    for (int i = 0; i < 4; i++)
                    {
                        HathatulClient.gb.PlayersCards[3, i].Height = HathatulClient.gb.PlayersCards[3, i].Height - 40;
                        HathatulClient.gb.PlayersCards[3, i].Width = HathatulClient.gb.PlayersCards[3, i].Width + 40;
                    }
                    break;
                
            }
           




        }
    }
}
