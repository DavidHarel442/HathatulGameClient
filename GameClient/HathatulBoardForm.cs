using System;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Collections.Generic;
using System.Linq;
using GameClient;

namespace GameClient
{
    public partial class HathatulBoardForm : Form
    {// this class manages the 'HathatulBoardForm' form. it manages the Events happening in the game.

        /// <summary>
        /// this property means that if the player. first player. "you". draw a card from the stackOfCards it will turn this pictureBox to visible true.
        /// and will show you the picture of the card you had drawn from stack.
        /// and after you throw the card/switch it, it will turn to visible false. this picture box is the drawn card from stackOfCards.
        /// </summary>
        public PictureBox yourDrawnCardFromStack;
        /// <summary>
        /// this property means that if the player. first player. "you". gets the special card 'drawTwo' it will turn this pictureBox to visible true.
        /// and will show you the picture of the card you had drawn from stack.
        /// and after you throw the card/switch it, it will turn to visible false. this picture box is the first card drawn in the Special case 'DrawTwo'
        /// </summary>
        public PictureBox drawTwoFirstCard;
        /// <summary>
        /// this property means that if the player. first player. "you". gets the special card 'drawTwo' it will turn this pictureBox to visible true.
        /// and will show you the picture of the card you had drawn from stack.
        /// and after you throw the card/switch it, it will turn to visible false. this picture box is the second card drawn in the Special case 'DrawTwo'
        /// </summary>
        public PictureBox drawTwoSecondCard;
        /// <summary>
        /// this property is the picturebox of the Third player first card drawn.
        /// which means that when the third player gets a "drawTwo" special card it will show this pictureBox. or when he just draws a card
        /// and when the player throw the card or switch it with one of his cards it will turn visible to false.
        /// </summary>
        public PictureBox thirdPlayerFirstCardDrawn;
        /// <summary>
        /// this property is the picturebox of the Third player second card drawn.
        /// which means that when the third player gets a "drawTwo" special card it will show this pictureBox.
        /// and when the player throw the card or switch it with one of his cards it will turn visible to false.
        /// </summary>
        public PictureBox thirdPlayerSecondCardDrawn;
        /// <summary>
        /// this property is the picturebox of the Fourth player first card drawn.
        /// which means that when the fourth player gets a "drawTwo" special card it will show this pictureBox. or when he just draws a card
        /// and when the player throw the card or switch it with one of his cards it will turn visible to false.
        /// </summary>
        public PictureBox fourthPlayerFirstCardDrawn;
        /// <summary>
        /// this property is the picturebox of the Fourth player second card drawn.
        /// which means that when the fourth player gets a "drawTwo" special card it will show this pictureBox.
        /// and when the player throw the card or switch it with one of his cards it will turn visible to false.
        /// </summary>
        public PictureBox fourthPlayerSecondCardDrawn;
        /// <summary>
        /// this property is the picturebox of the Second player first card drawn.
        /// which means that when the second player gets a "drawTwo" special card it will show this pictureBox. or when he just draws a card
        /// and when the player throw the card or switch it with one of his cards it will turn visible to false.
        /// </summary>
        public PictureBox secondPlayerFirstCardDrawn;
        /// <summary>
        /// this property is the picturebox of the Second player second card drawn.
        /// which means that when the second player gets a "drawTwo" special card it will show this pictureBox.
        /// and when the player throw the card or switch it with one of his cards it will turn visible to false.
        /// </summary>
        public PictureBox secondPlayerSecondCardDrawn;
        /// <summary>
        /// this property is a property that contains the fourths player name.
        /// </summary>
        public Label fourthPlayer;
        /// <summary>
        /// this property is a property that contains the seconds player name.
        /// </summary>
        public Label secondPlayer;
        /// <summary>
        /// this property is a matrix 4 on 4 which contains all four players cards.
        /// (if there arent four players active then the values of the players that are not playing. their pictureBoxes will be null.
        /// for instance: if there are only three players. then the fourth player cards will be null. positions: (3,0) , (3,1) , (3,2) , (3,3) .
        /// </summary>
        public PictureBox[,] PlayersCards = new PictureBox[4,4];
        /// <summary>
        /// a property that helps transfer to the communication protocol forum
        /// </summary>
        public CommunicationProtocol communicationProtocol = null;
        /// <summary>
        /// a property that when the game starts will create all of the cards, pictureBoxes,Labels needed
        /// </summary>
        public CreateMidRun createMidRun = null;
        /// <summary>
        /// a property that starts as false but when a player presses the "Hathatul" button it starts the last turn and its value will turn to true
        /// </summary>
        public bool HathatulClicked = false;
        /// <summary>
        /// a boolean property that its default state is true, and it allows you to peek at your right card, for the first time and after that it turns to false
        /// </summary>
        public bool isFirstTurnOnRight = true;
        /// <summary>
        /// a boolean property that its default state is true, and it allows you to peek at your right card, for the first time and after that it turns to false
        /// </summary>
        public bool isFirstTurnOnLeft = true;
        /// <summary>
        /// a Unique Token that with it you communicate with the server.
        /// </summary>
        public string entryToken = "";
        /// <summary>
        /// a property that keeps as its value the name of the player of this current run
        /// </summary>
        public string username12 = "";
        /// <summary>
        /// if the player recieved a special card which caused a special situation (SpecialCard - 'peek') which allows the player to peek at one of his cards
        /// </summary>
        public bool specialCardPeek = false;
        /// <summary>
        /// if the player recieved a special card which caused a special situation (SpecialCard - 'DrawTwo') which deals the player two cards from the stackOfCards
        /// </summary>
        public bool specialCardDrawTwo = false;
        /// <summary>
        /// if the player recieved a special card which caused a special situation (SpecialCard - 'Swap') which allows the player to switch one of his cards with another card of another player
        /// </summary>
        public bool specialCardSwap = false;
        /// <summary>
        /// a property that when special situation 'Swap' is in place, this variable keeps the card that the player is trying to switch. (the other card, not your card)
        /// </summary>
        public string whichCardForSwap = "";
        /// <summary>
        /// a variable that turns to true if someone is trying to switch a card from the trashCards with one of his cards
        /// </summary>
        public bool choosingToSwitchCardFromTrashCards = false;
        /// <summary>
        /// a variable that keeps the value of the card in the trash
        /// </summary>
        public string whatIsTheCardInTheTrash = "";
        /// <summary>
        /// a variable that keeps the name of the first card drawn as a result of specialCard 'DrawTwo'
        /// </summary>
        public string specialCard1drawTwo = "";
        /// <summary>
        /// a  variable that keeps the name of the second card drawn as a result of specialCard 'DrawTwo'
        /// </summary>
        public string specialCard2drawTwo = "";
        /// <summary>
        /// it contains the object to handle multiple clients.
        /// </summary>
        public MultipulePlayersHandler players;
        /// <summary>
        /// a variable that turns to true if you pressed on the first drawn card as a result of specialCard 'DrawTwo'.
        /// (when you press on a card you try to do something with it. like throwing it or switching it with one of your cards
        /// </summary>
        public bool pressedOnSpecialCardDrawTwoFirstOne = false;
        /// <summary>
        /// a property that contains the name of the card that the player is holding
        /// </summary>
        public string whatsTheNameOfTheCardImHolding = "";
        /// <summary>
        /// a variable that turns to true if you pressed on the second drawn card as a result of specialCard 'DrawTwo'.
        /// (when you press on a card you try to do something with it. like throwing it or switching it with one of your cards
        /// </summary>
        public bool pressedOnSpecialCardDrawTwoSecondOne = false;
        /// <summary>
        /// a property that says how much time someone has for a turn. after each turn we reset it to the value of 30. and if someone gets a 'DrawTwo'/'Swap' card it adds 10 sec to the variable
        /// </summary>
        public int timeLeft = 30;
        /// <summary>
        /// a property sent through each class starting from HathatulClient. which you use to communicate with the server
        /// </summary>
        public HathatulTcpClient client = null;
        /// <summary>
        /// when the timer ended and you got a draw two but didnt press on any of them
        /// </summary>
        public bool timeEndedFirstCard = false;
        public bool timeEndedSecondCard = false;
        public bool afterFirstTurn = false;
        /// <summary>
        /// a default constructor. it initialized the 'GameBoard' form. and it also recieves the firstname,username, and a Unique token.
        /// the firstname is going to be seen on the form. the username is used to verify stuff, and also be put on the bottom of the screen. and the unique token is used to communication with the server
        /// </summary>
        /// <param name="name"></param>
        /// <param name="entryToken"></param>
        /// <param name="username1"></param>
        public HathatulBoardForm(string name,string entryToken,string username1,HathatulTcpClient client1,CommunicationProtocol communicationProtocol)
        {
            InitializeComponent();
            this.communicationProtocol = communicationProtocol;
            this.client = client1;
            this.entryToken = entryToken;
            username12 = username1;
            this.stackOfCards.Image = (Image)Properties.Resources.ResourceManager.GetObject("backOfCard");
            this.trashCards.Image = (Image)Properties.Resources.ResourceManager.GetObject("startOfGamePilePicture");
            nickname.Text = "hey," + name;
            string message = communicationProtocol.TransferToProtocol("DealMeCards", this.entryToken,"");// askes the server to deal cards to the player
            client.SendMessage(message);
            MessageBox.Show("at first you have to peek at your side cards");
            if(HathatulClient.waitingRoom.isFirstPlayer)
            {
                isItYourTurn.Text = "your turn";
                isItYourTurn.BackColor = Color.Green;

            }
        }
        /// <summary>
        /// when the form gets loaded and if the player is starting first then the timer should start.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GameBoard_Load_1(object sender, EventArgs e)
        {
            if (HathatulClient.waitingRoom.isFirstPlayer)
            {
                this.timeLeft = 30;
                this.timerButton.Text = "30sec";
                this.timerButton.Visible = true;
                this.Timer.Start();
            }
        }
        /// <summary>
        /// an Event Handler for the Player1_1 pictureBox that happens if someone holds this pictureBox.
        /// if it is allowed it will show the card of the left for player 1
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Player1_1_MouseDown(object sender, MouseEventArgs e)
        {
            if (isFirstTurnOnLeft)// if it is the players first turn. request that the server will show the player his Left card 
            {

                string message = communicationProtocol.TransferToProtocol("showMeLeftCardFirstTime", entryToken, "");
                client.SendMessage(message);//sends a message to show the left card and that it is the first time
            }
            else if (specialCardPeek)// if the player recieved a specialCard 'peek'. request that the server will show the player his Left card
            {
                string message = communicationProtocol.TransferToProtocol("showMeLeftCard", entryToken, "");
                client.SendMessage(message);//sends a message to show the left card
            }
        }
        /// <summary>
        /// an Event Handler for the Player1_1 pictureBox that happens if someone let go of this pictureBox.
        /// it will return the left picture box of player one to its default picture, that is the back of a card
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Player1_1_MouseUp(object sender, MouseEventArgs e)
        {
            if (isFirstTurnOnLeft || specialCardPeek)// after the player peeked it returns the pictureBox to its default picture
            {
                PlayersCards[0,0].Image = global::GameClient.Properties.Resources.backOfCard;
                isFirstTurnOnLeft = false;
                specialCardPeek = false;
            }
        }
        /// <summary>
        /// an Event Handler for the Player1_4 pictureBox that happens if someone holds this pictureBox.
        /// if it is allowed it will show the card of the right for player 1
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Player1_4_MouseDown(object sender, MouseEventArgs e)
        {
            if (isFirstTurnOnRight)// if it is the players first turn. request that the server will show the player his right card 
            {
                string message = communicationProtocol.TransferToProtocol("showMeRightCardFirstTime", entryToken, "");
                client.SendMessage(message);
            }
            else if (specialCardPeek) // if the player recieved a specialCard 'peek'. request that the server will show the player his right card
            {
                string message = communicationProtocol.TransferToProtocol("showMeRightCard", entryToken, "");
                client.SendMessage(message);
            }
        }
        /// <summary>
        /// an Event Handler for the Player1_4 pictureBox that happens if someone let go of this pictureBox.
        /// it will return the right picture box of player one to its default picture, that is the back of a card
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Player1_4_MouseUp(object sender, MouseEventArgs e)
        {
            if (isFirstTurnOnRight || specialCardPeek)// after the player peeked it returns the pictureBox to its default picture
            {
                PlayersCards[0, 3].Image = global::GameClient.Properties.Resources.backOfCard;
                isFirstTurnOnRight = false;
                specialCardPeek = false;
            }
        }
        /// <summary>
        /// Event Handler that occurs when someone drew a ccard from stack.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void StackOfCards_Click(object sender, EventArgs e)
        {
            if (!isFirstTurnOnLeft && !isFirstTurnOnRight)
            {   
                afterFirstTurn = true;
                string message = communicationProtocol.TransferToProtocol("drawCardFromStack", entryToken, "");
                client.SendMessage(message);
                hathatul.Enabled = false;
            }
            else if (isFirstTurnOnLeft || isFirstTurnOnRight)
            {
                MessageBox.Show("you need to peek at both of your cards before drawing card");
            }
        }
        /// <summary>
        /// Handles the click event of the trashCards PictureBox.
        /// It will only work if it is the players turn
        /// if someone got the special card 'DrawTwo' and pressed on the firstCard between the two cards then it throws his first card to the TrashCards
        /// if someone got the special card 'DrawTwo' and pressed on the SecondCard between the two cards then it throws his second card to the TrashCards
        /// if someone had already drawn a card and then pressed on the trashCards then it will throw his drawn card
        /// else. it will turn true the boolean which activate the switch card from trash. after it turns to true you pick a card of your own and it will switch between them
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void TrashCards_Click(object sender, EventArgs e)
        {
            if (!isFirstTurnOnLeft && !isFirstTurnOnRight && (isItYourTurn.BackColor == Color.Green) && afterFirstTurn)
            {
                if (pressedOnSpecialCardDrawTwoFirstOne)
                {
                    HandleSpecialCardDrawTwo(specialCard1drawTwo, drawTwoFirstCard, drawTwoSecondCard);
                    pressedOnSpecialCardDrawTwoFirstOne = false;
                    drawTwoSecondCard.Enabled = true;
                    
                }
                else if (pressedOnSpecialCardDrawTwoSecondOne)
                {
                    HandleSpecialCardDrawTwo(specialCard2drawTwo, drawTwoSecondCard, drawTwoFirstCard);
                    pressedOnSpecialCardDrawTwoSecondOne = false;
                    drawTwoFirstCard.Enabled = true;
                    
                    
                }
                else if (yourDrawnCardFromStack.Visible)
                {
                    HandleDrawnCardFromStack(whatsTheNameOfTheCardImHolding);
                }
                else
                {
                    HandleOtherCases(whatsTheNameOfTheCardImHolding);
                }
            }
        }
        /// <summary>
        /// Handles the actions when a special card that allows drawing two cards is drawn from the stack of cards, and thrown to the trash Cards.
        /// and if both drawn cards are thrown already it will move the turn
        /// </summary>
        /// <param name="specialCard"></param>
        /// <param name="firstCard"></param>
        /// <param name="secondCard"></param>
        public void HandleSpecialCardDrawTwo(string specialCard, PictureBox firstCard, PictureBox secondCard)
        {
            string message = "";
            if (specialCard == "drawTwo" && firstCard.Visible && secondCard.Visible)
            {
                MessageBox.Show("First, drop the other card and only then throw the draw Two");
                return;
            }
            if (pressedOnSpecialCardDrawTwoFirstOne || timeEndedFirstCard)
            {
                timeEndedFirstCard = false;
                message = communicationProtocol.TransferToProtocol("TurnToFalseFirstCard", entryToken, "");
                client.SendMessage(message);

            }
            else if (pressedOnSpecialCardDrawTwoSecondOne || timeEndedSecondCard)
            {
                message = communicationProtocol.TransferToProtocol("TurnToFalseSecondCard", entryToken, "");
                client.SendMessage(message);
                timeEndedSecondCard = false;
            }
                string data = specialCard + "|" + whatIsTheCardInTheTrash + "|";
                message = communicationProtocol.TransferToProtocol("throwCardToTrash", entryToken, data);
                client.SendMessage(message);
                firstCard.Image = null;
                firstCard.Visible = false;
                secondCard.Enabled = true;
                if ((!HathatulClicked || firstCard.Visible || secondCard.Visible) && (specialCard == "peek"))
                {
                    MessageBox.Show("You can look at one of your Cards");
                    specialCardPeek = true;
                }

                if (specialCard == "drawTwo")
                {
                    MessageBox.Show("You received a special card that allows you to draw two cards");
                    specialCardDrawTwo = true;
                    secondCard.Visible = true;
                    this.timeLeft = this.timeLeft + 10;
                    message = communicationProtocol.TransferToProtocol("specialCardDrawTwo", entryToken, "");
                    client.SendMessage(message);
                }
                else if (specialCard == "swap")
                {
                    this.timeLeft = this.timeLeft + 10;
                    MessageBox.Show("You have received a special card SWAP. Pick a card of your own and pick a card from someone else to switch them");
                    specialCardSwap = true;
                    whichCardForSwap = "";
                    if (!firstCard.Visible && !secondCard.Visible)
                    {
                        specialCardDrawTwo = false;
                    }
                }
            
            if (!firstCard.Visible && !secondCard.Visible && !specialCardSwap)
            {
                Timer.Stop();
                timerButton.Text = "";
                timerButton.Visible = false;
                message = communicationProtocol.TransferToProtocol("turnTheturnToAnotherPlayer", entryToken, "");
                client.SendMessage(message);
                hathatul.Enabled = false;
                this.isItYourTurn.Text = "Not your turn";
                this.isItYourTurn.BackColor = Color.Red;
                specialCardDrawTwo = false;
            }
        }
        /// <summary>
        /// Handles the actions when a drawn card from the stack is clicked. it will throw the card to the trash Cards and will move the turn
        /// </summary>
        /// <param name="cardName"></param>
        public void HandleDrawnCardFromStack(string cardName)
        {
            string data = cardName + "|" + whatIsTheCardInTheTrash + "|";
            string message = communicationProtocol.TransferToProtocol("throwCardToTrash", entryToken, data);
            client.SendMessage(message);

            yourDrawnCardFromStack.Image = null;
            yourDrawnCardFromStack.Visible = false;

            if (!HathatulClicked && (cardName == "peek"))
            {
                MessageBox.Show("You can look at one of your Cards");
                specialCardPeek = true;
            }

            if (cardName == "drawTwo")
            {
                MessageBox.Show("You received a special card that allows you to draw two cards");
                specialCardDrawTwo = true;
                drawTwoFirstCard.Visible = true;
                drawTwoSecondCard.Visible = true;
                this.timeLeft = this.timeLeft + 10;
                message = communicationProtocol.TransferToProtocol("specialCardDrawTwo", entryToken, "");
                client.SendMessage(message);
            }
            else if (cardName == "swap")
            {
                this.timeLeft = this.timeLeft + 10;
                MessageBox.Show("You have received special card SWAP. Pick a card of your own and pick a card from someone else to switch them");
                specialCardSwap = true;
                whichCardForSwap = "";
            }
            else
            {
                Timer.Stop();
                timerButton.Text = "";
                timerButton.Visible = false;
                message = communicationProtocol.TransferToProtocol("turnTheturnToAnotherPlayer", entryToken, "");
                client.SendMessage(message);
                hathatul.Enabled = false;
                this.isItYourTurn.Text = "Not your turn";
                this.isItYourTurn.BackColor = Color.Red;
            }
        }
        /// <summary>
        /// Handles the actions for other cases not covered by specific methods.
        /// Basically if you chose to switch the card from the trash with one of your cards
        /// </summary>
        /// <param name="cardName"></param>
        public void HandleOtherCases(string cardName)
        {
            if (cardName != "swap" && !specialCardDrawTwo)
            {
                choosingToSwitchCardFromTrashCards = true;
                stackOfCards.Enabled = false;
            }
        }
        /// <summary>
        /// Handles the click event for player1_1 PictureBox. calls for a function that handles all situations
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Player1_1Click(object sender, EventArgs e)
        {
            PictureBox clickedPictureBox = PlayersCards[0, 0];
            HandlePlayerClick(clickedPictureBox,"Left");

        }
        /// <summary>
        /// Handles the click event for player1_2 PictureBox. calls for a function that handles all situations
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Player1_2Click(object sender, EventArgs e)
        {
            PictureBox clickedPictureBox = PlayersCards[0, 1];
            HandlePlayerClick(clickedPictureBox,"MiddleLeft");
        }
        /// <summary>
        /// Handles the click event for player1_3 PictureBox. calls for a function that handles all situations
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Player1_3Click(object sender, EventArgs e)
        {
            PictureBox clickedPictureBox = PlayersCards[0, 2];
            HandlePlayerClick(clickedPictureBox,"MiddleRight");
        }
        /// <summary>
        /// Handles the click event for player1_4 PictureBox. calls for a function that handles all situations
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Player1_4Click(object sender, EventArgs e)
        {
            PictureBox clickedPictureBox = PlayersCards[0, 3];
            HandlePlayerClick(clickedPictureBox,"Right");
        }
        /// <summary>
        /// Central dispatcher for handling player 1 cards clicks. 
        /// if it was in the situation of the special card switch. then it will put the value of the card pressed in the variable 'whichard' (Contains Values: Left/Right/MiddleLeft/MiddleRight)
        /// if it was in the special situation with the special card 'DrawTwo' then it will call the function 'HandleSpecialCardDrawTwo'
        /// if the DrawnCard PictureBox Was visible meaning the player drew a card from stuck then it will call the function 'HandleDrawnCardFromStack'
        /// and if the player chose to switch from the TrashCards. (Variable "choosingToSwitchCardFromTrashCards" was true then it will call the function "HandleSwitchFromTrashCards"
        /// </summary>
        /// <param name="clickedPictureBox"></param>
        /// <param name="whichCard"></param>
        public void HandlePlayerClick(PictureBox clickedPictureBox,string whichCard)
        {
            if (specialCardSwap && string.IsNullOrEmpty(whichCardForSwap))
            {
                whichCardForSwap = whichCard;
            }
            else if (pressedOnSpecialCardDrawTwoFirstOne || pressedOnSpecialCardDrawTwoSecondOne)
            {
                HandleSpecialCardDrawTwo(clickedPictureBox, whichCard);
            }
            else if (yourDrawnCardFromStack.Visible)
            {
                HandleDrawnCardFromStack(clickedPictureBox,whichCard);
            }
            else if (choosingToSwitchCardFromTrashCards)
            {
                HandleSwitchFromTrashCards(clickedPictureBox,whichCard);
            }
        }
        /// <summary>
        /// Handles the special card draw two action based on the clicked PictureBox. it will turn the pictureBox chosen to false for all players for the said player.
        /// and it will switch the card he chosen with a card of his.  and it will call a function that moves the turn
        /// </summary>
        /// <param name="clickedPictureBox"></param>
        /// <param name="WhichCardForSwitch"></param>
        public void HandleSpecialCardDrawTwo(PictureBox clickedPictureBox,string WhichCardForSwitch)
        {
            string message = "";
            string specialCard = "";
            if (pressedOnSpecialCardDrawTwoFirstOne)
            {
                specialCard = specialCard1drawTwo;
                pressedOnSpecialCardDrawTwoFirstOne = false;
                drawTwoSecondCard.Enabled = true;
                drawTwoFirstCard.Visible = false;
                drawTwoFirstCard.Image = null;
                message = communicationProtocol.TransferToProtocol("TurnToFalseFirstCard", entryToken, "");
                client.SendMessage(message);// send the message to the server that will send everyone that the player threw his firstCard From the draw two to trash.
                                            // so they shouldnt see it anymore(the back of the card)
            }
            if (pressedOnSpecialCardDrawTwoSecondOne)
            {
                specialCard = specialCard2drawTwo;
                pressedOnSpecialCardDrawTwoSecondOne = false;
                drawTwoFirstCard.Enabled = true;
                drawTwoSecondCard.Visible = false;
                drawTwoSecondCard.Image = null;
                message = communicationProtocol.TransferToProtocol("TurnToFalseSecondCard", entryToken, "");
                client.SendMessage(message);// send the message to the server that will send everyone that the player threw his secondCard From the draw two to trash.
                                            // so they shouldnt see it anymore(the back of the card)
            }
            string command = "switch" + WhichCardForSwitch;
            string data = specialCard + "|" + whatIsTheCardInTheTrash + "|";
            message = communicationProtocol.TransferToProtocol(command, entryToken, data);
            client.SendMessage(message);
            if (!drawTwoFirstCard.Visible && !drawTwoSecondCard.Visible)
            {
                EndTurn();
            }
        }
        /// <summary>
        /// handles the situation that if someone is trying to switch between his drawn cards with one of his. and it will call a function that moves the turn
        /// </summary>
        /// <param name="clickedPictureBox"></param>
        /// <param name="WhichCardForSwitch"></param>
        public void HandleDrawnCardFromStack(PictureBox clickedPictureBox,string WhichCardForSwitch)
        {
            string data = whatsTheNameOfTheCardImHolding + "|" + whatIsTheCardInTheTrash + "|";
            string command = "switch" +  WhichCardForSwitch;
            string message = communicationProtocol.TransferToProtocol(command, entryToken, data);
            client.SendMessage(message);//send the request 
            yourDrawnCardFromStack.Image = null;
            yourDrawnCardFromStack.Visible = false;
            EndTurn();
        }
        /// <summary>
        /// handles the situation that if someone is trying to switch with the card from the trash with one of his cards. and it will call a function that moves the turn
        /// </summary>
        /// <param name="clickedPictureBox"></param>
        /// <param name="WhichCard"></param>
        public void HandleSwitchFromTrashCards(PictureBox clickedPictureBox, string WhichCard)
        {
            string data = whatIsTheCardInTheTrash + "|";
            string command = "SwitchFromTrashWithMy" + WhichCard;
            string message = communicationProtocol.TransferToProtocol(command, entryToken, data);
            client.SendMessage(message);// request that the server will switch the card from the trashCards with the card that the player chose  (has to be one of his cards)
            EndTurn();
        }
        /// <summary>
        /// function called when the turn ended. It stops the timer, and sends a request to the server to move the turn. and it changes the label of 'isItYourTurn'
        /// </summary>
        public void EndTurn()
        {
            Timer.Stop();
            timerButton.Text = "";
            timerButton.Visible = false;
            string message = communicationProtocol.TransferToProtocol("turnTheturnToAnotherPlayer", entryToken, "");
            client.SendMessage(message);// request that the server will move the turn
            hathatul.Enabled = false;
            this.isItYourTurn.Text = "not your turn";
            this.isItYourTurn.BackColor = Color.Red;
        }
        /// <summary>
        /// an Event Handler for the Player1_2 pictureBox that happens if someone holds this pictureBox.
        /// if it is allowed it will show the card of the MiddleLeft for player 1
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Player1_2_MouseDown(object sender, MouseEventArgs e)
        {
            if (specialCardPeek)// if the player recieved a specialCard 'peek'. request that the server will show the player his MiddleLeft card
            {
                string message = communicationProtocol.TransferToProtocol("showMeMiddleLeftCard", entryToken, "");
                client.SendMessage(message);//sends the request to the server
            }
        }
        /// <summary>
        /// an Event Handler for the Player1_2 pictureBox that happens if someone let go of this pictureBox.
        /// it will return the MiddleRight picture box of player one to its default picture, that is the back of a card
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Player1_2_MouseUp(object sender, MouseEventArgs e)
        {
            if (specialCardPeek)// after the player peeked it returns the pictureBox to its default picture
            {
                PlayersCards[0, 1].Image = global::GameClient.Properties.Resources.backOfCard;
                specialCardPeek = false;
            }
        }
        /// <summary>
        /// an Event Handler for the Player1_3 pictureBox that happens if someone holds this pictureBox.
        /// if it is allowed it will show the card of the MiddleRight for player 1
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Player1_3_MouseDown(object sender, MouseEventArgs e)
        {
            if (specialCardPeek)// if the player recieved a specialCard 'peek'. request that the server will show the player his MiddleRight card
            {
                string message = communicationProtocol.TransferToProtocol("showMeMiddleRightCard", entryToken, "");
                client.SendMessage(message);//sends the request to the server
            }
        }
        /// <summary>
        /// an Event Handler for the Player1_2 pictureBox that happens if someone let go of this pictureBox.
        /// it will return the MiddleLeft picture box of player one to its default picture, that is the back of a card
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Player1_3_MouseUp(object sender, MouseEventArgs e)
        {
            if (specialCardPeek)// after the player peeked it returns the pictureBox to its default picture
            {
                PlayersCards[0, 2].Image = global::GameClient.Properties.Resources.backOfCard;
                specialCardPeek = false;
            }
        }
        /// <summary>
        /// An Event Handler that happens if someone clicks the 'DrawTwoFirstCard'.
        /// it turns the boolean "pressedOnSpecialCardDrawTwoFirstOne" to true. meaning he is gonna play with that card
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void DrawTwoFirstCard_Click(object sender, EventArgs e)
        {
            pressedOnSpecialCardDrawTwoFirstOne = true;
            drawTwoSecondCard.Enabled = false;//disable the option to press on two drawn cards at the same time
        }
        /// <summary>
        /// An Event Handler that happens if someone clicks the 'DrawTwoSecondCard'.
        /// it turns the boolean "pressedOnSpecialCardDrawTwoSecondOne" to true. meaning he is gonna play with that card
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void DrawTwoSecondCard_Click(object sender, EventArgs e)
        {
            pressedOnSpecialCardDrawTwoSecondOne = true;
            drawTwoFirstCard.Enabled = false;//disable the option to press on two drawn cards at the same time
        }
        /// <summary>
        /// an event Handler that happens when the player clicks on Player2_4 pictureBox.
        /// it then calls the function "HandleCardSwitch" with the secondPlayer labels text.
        /// and the chosen card is the left one. this card is gonna be swapped if the player has the Special Card Swap.
        /// and it will be swapped with the card the player chose (the card chosen has to be his)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Player2_4Click(object sender, EventArgs e)
        {
            HandleCardSwitch(secondPlayer.Text, "Left");
        }
        /// <summary>
        /// an event Handler that happens when the player clicks on Player2_3 pictureBox.
        /// it then calls the function "HandleCardSwitch" with the secondPlayer labels text.
        /// and the chosen card is the MiddleLeft one. this card is gonna be swapped if the player has the Special Card Swap.
        /// and it will be swapped with the card the player chose (the card chosen has to be his)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Player2_3Click(object sender, EventArgs e)
        {
            HandleCardSwitch(secondPlayer.Text, "MiddleLeft");
        }
        /// <summary>
        /// an event Handler that happens when the player clicks on Player2_2 pictureBox.
        /// it then calls the function "HandleCardSwitch" with the secondPlayer labels text.
        /// and the chosen card is the MiddleRight one. this card is gonna be swapped if the player has the Special Card Swap.
        /// and it will be swapped with the card the player chose (the card chosen has to be his)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Player2_2Click(object sender, EventArgs e)
        {
            HandleCardSwitch(secondPlayer.Text, "MiddleRight");
        }
        /// <summary>
        /// an event Handler that happens when the player clicks on Player2_1 pictureBox.
        /// it then calls the function "HandleCardSwitch" with the secondPlayer labels text.
        /// and the chosen card is the Right one. this card is gonna be swapped if the player has the Special Card Swap.
        /// and it will be swapped with the card the player chose (the card chosen has to be his)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Player2_1Click(object sender, EventArgs e)
        {
            HandleCardSwitch(secondPlayer.Text, "Right");
        }
        /// <summary>
        /// an event Handler that happens when the player clicks on Player3_4 pictureBox.
        /// it then calls the function "HandleCardSwitch" with the thirdPlayer labels text.
        /// and the chosen card is the Left one. this card is gonna be swapped if the player has the Special Card Swap.
        /// and it will be swapped with the card the player chose (the card chosen has to be his)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Player3_4Click(object sender, EventArgs e)
        {
            HandleCardSwitch(thirdPlayer.Text, "Left");
        }
        /// <summary>
        /// an event Handler that happens when the player clicks on Player3_3 pictureBox.
        /// it then calls the function "HandleCardSwitch" with the thirdPlayer labels text.
        /// and the chosen card is the MiddleLeft one. this card is gonna be swapped if the player has the Special Card Swap.
        /// and it will be swapped with the card the player chose (the card chosen has to be his)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Player3_3Click(object sender, EventArgs e)
        {
            HandleCardSwitch(thirdPlayer.Text, "MiddleLeft");
        }
        /// <summary>
        /// an event Handler that happens when the player clicks on Player3_2 pictureBox.
        /// it then calls the function "HandleCardSwitch" with the thirdPlayer labels text.
        /// and the chosen card is the MiddleRight one. this card is gonna be swapped if the player has the Special Card Swap.
        /// and it will be swapped with the card the player chose (the card chosen has to be his)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Player3_2Click(object sender, EventArgs e)
        {
            HandleCardSwitch(thirdPlayer.Text, "MiddleRight");
        }
        /// <summary>
        /// an event Handler that happens when the player clicks on Player3_1 pictureBox.
        /// it then calls the function "HandleCardSwitch" with the thirdPlayer labels text.
        /// and the chosen card is the Right one. this card is gonna be swapped if the player has the Special Card Swap.
        /// and it will be swapped with the card the player chose (the card chosen has to be his)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Player3_1Click(object sender, EventArgs e)
        {
            HandleCardSwitch(thirdPlayer.Text, "Right");
        }
        /// <summary>
        /// an event Handler that happens when the player clicks on Player4_4 pictureBox.
        /// it then calls the function "HandleCardSwitch" with the fourthPlayer labels text.
        /// and the chosen card is the Left one. this card is gonna be swapped if the player has the Special Card Swap.
        /// and it will be swapped with the card the player chose (the card chosen has to be his)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Player4_4Click(object sender, EventArgs e)
        {
            HandleCardSwitch(fourthPlayer.Text, "Left");
        }
        /// <summary>
        /// an event Handler that happens when the player clicks on Player4_3 pictureBox.
        /// it then calls the function "HandleCardSwitch" with the fourthPlayer labels text.
        /// and the chosen card is the MiddleLeft one. this card is gonna be swapped if the player has the Special Card Swap.
        /// and it will be swapped with the card the player chose (the card chosen has to be his)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Player4_3Click(object sender, EventArgs e)
        {
            HandleCardSwitch(fourthPlayer.Text, "MiddleLeft");
        }
        /// <summary>
        /// an event Handler that happens when the player clicks on Player4_2 pictureBox.
        /// it then calls the function "HandleCardSwitch" with the fourthPlayer labels text.
        /// and the chosen card is the MiddleRight one. this card is gonna be swapped if the player has the Special Card Swap.
        /// and it will be swapped with the card the player chose (the card chosen has to be his)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Player4_2Click(object sender, EventArgs e)
        {
            HandleCardSwitch(fourthPlayer.Text, "MiddleRight");
        }
        /// <summary>
        /// an event Handler that happens when the player clicks on Player4_1 pictureBox.
        /// it then calls the function "HandleCardSwitch" with the fourthPlayer labels text.
        /// and the chosen card is the Right one. this card is gonna be swapped if the player has the Special Card Swap.
        /// and it will be swapped with the card the player chose (the card chosen has to be his)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Player4_1Click(object sender, EventArgs e)
        {
            HandleCardSwitch(fourthPlayer.Text, "Right");
        }
        /// <summary>
        /// Handles the switching of cards between players based on specified parameters.
        /// </summary>
        /// <param name="playerName"></param>
        /// <param name="cardPosition"></param>
        //
        private void HandleCardSwitch(string playerName, string cardPosition)
        {
            if (specialCardSwap && whichCardForSwap != "")
            {
                string data = whichCardForSwap + "|" + playerName + "|" + cardPosition;
                string message = communicationProtocol.TransferToProtocol("SwitchCard", entryToken, data);
                client.SendMessage(message);//A request for the server to switch the cards that the player request will be switched. All according to the rules of course
                whichCardForSwap = "";
                specialCardSwap = false;
            }
        }
        /// <summary>
        /// creates all of the pictureboxes to all of the players
        /// </summary>
        /// <param name="PlayerConnected"></param>
        public void CreateAllOfCards(string PlayerConnected)
        {
            createMidRun = new CreateMidRun(this);
            createMidRun.CreateAllOfCards(PlayerConnected);//creates all of the card for all of the players
        }
        /// <summary>
        /// this is a Event handler that occurs when someone presses on the button 'Hathatul'. 
        /// It creates special event and last turn of the game
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Hathatul_Click(object sender, EventArgs e)
        {
            string message = communicationProtocol.TransferToProtocol("Hathatul", entryToken, "");
            client.SendMessage(message);//a request to the server that will activate the "hathatul" situation (last turn for everyone)
            Timer.Stop();
            timerButton.Text = "";
            timerButton.Visible = false;
            message = communicationProtocol.TransferToProtocol("turnTheturnToAnotherPlayer", entryToken, "");
            client.SendMessage(message);//requests that the server will move the turn to another player
            this.isItYourTurn.Text = "not your turn";
            this.isItYourTurn.BackColor = Color.Red;
            hathatul.Enabled = false;
            turnEnded.Text = "It was Your Last Turn";
        }
        /// <summary>
        /// this function moves the turn after the swap special card
        /// </summary>
        public void HandleAfterSwapCase()
        {
            specialCardSwap = false;
            whichCardForSwap = "";
            hathatul.Enabled = false;
            isItYourTurn.Text = "not your turn";
            isItYourTurn.BackColor = Color.Red;
            Timer.Stop();// stops the timer 
            timerButton.Text = "";
            timerButton.Visible = false;
            string message = communicationProtocol.TransferToProtocol("turnTheturnToAnotherPlayer", entryToken, "");
            client.SendMessage(message);// this function requests that the server will move the turn

        }
        /// <summary>
        /// a function that handles the situation if the player recieved a message from the server suggesting that it is his turn
        /// </summary>
        public void YourTurn()
        {
            stackOfCards.Enabled = true;
            this.timeLeft = 30;
            this.timerButton.Text = "30sec";
            this.timerButton.Visible = true;
            this.Timer.Start();
            thirdPlayer.BackColor = Color.White;
            if (secondPlayer != null) {
                secondPlayer.BackColor = Color.White;   
            }
            if (fourthPlayer!=null)
            {
                fourthPlayer.BackColor = Color.White;
            }
            isItYourTurn.Text = "your turn";
            this.firstPlayer.BackColor = Color.Green;
            isItYourTurn.BackColor = Color.Green;
            if (!HathatulClicked)
            {
                hathatul.Enabled = true;
            }

        }
        /// <summary>
        /// a event Handler for every sec of the Timer Tick (1000 interval - 1 sec). if the time left is more than 1 then you lower 'timeLeft' by 1.
        /// otherwise if 'timeLeft' equals to 0 then it moves the turn to another player. and ends the players turn
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Timer_Tick(object sender, EventArgs e)
        {
            if (this.timeLeft > 0)
            {
                this.timeLeft--;
                timerButton.Text = this.timeLeft + "sec";
            }
            else
            {
                bool wentInIf = false;
                timerButton.Visible = false;
                Timer.Stop();
                timerButton.Text = "";
                if (yourDrawnCardFromStack.Visible)
                {
                    HandleDrawnCardFromStack(whatsTheNameOfTheCardImHolding);
                    // if he has already drawn a card but he doesnt have any time left. so throw the drawn card to the trashCards
                    wentInIf = true;
                }
                if(specialCard1drawTwo == "peek" || specialCard1drawTwo == "swap" || specialCard1drawTwo == "drawTwo")
                {
                    HandleSpecialCardDrawTwo(specialCard2drawTwo, drawTwoSecondCard, drawTwoFirstCard);
                    HandleSpecialCardDrawTwo(specialCard1drawTwo, drawTwoFirstCard, drawTwoSecondCard);
                    // if he had recieves the special card 'DrawTwo' then throw both cards to the trashCards.
                    // although make it a little more humane that the card on top will be: peek/swap/drawTwo which are the better cards.
                    wentInIf = true;
                }
                else if (specialCardDrawTwo)
                {
                    wentInIf = true;
                    timeEndedFirstCard = true;
                    timeEndedSecondCard = true;
                    HandleSpecialCardDrawTwo(specialCard1drawTwo, drawTwoFirstCard, drawTwoSecondCard);
                    HandleSpecialCardDrawTwo(specialCard2drawTwo, drawTwoSecondCard, drawTwoFirstCard);
                    // if he had recieves the special card 'DrawTwo' then throw both cards to the trashCards
                }
                if (!wentInIf && whatsTheNameOfTheCardImHolding !="swap")
                {
                    string message = communicationProtocol.TransferToProtocol("AFK", entryToken, "");
                    client.SendMessage(message);// if the player didnt play the whole turn
                }
                else if(whatsTheNameOfTheCardImHolding == "swap")
                {
                    specialCardSwap = false;
                    whichCardForSwap = "";
                }
                if(isItYourTurn.BackColor != Color.Green)
                {
                    MessageBox.Show("Time is Up");
                }
            }
        }

       
    }
}

