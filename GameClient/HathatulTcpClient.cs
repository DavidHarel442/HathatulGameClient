using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Net.Sockets;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Web;
using System.Windows.Forms;
namespace GameClient
{
    public class HathatulTcpClient
    {// this class is incharge of communicaiting with the server

        /// <summary>
        /// this property contains the port that the server runs on
        /// </summary>
        int portNo = 5000;
        /// <summary>
        /// this property contains the ip of the server
        /// </summary>
        private string ipAddress = "127.0.0.1";
        /// <summary>
        /// this property contains the TcpClient that the clients runs on
        /// </summary>
        TcpClient tcpClient;
        /// <summary>
        /// this property contains in the 'SendMessage' function the data that is sent to the server.
        /// and in the 'RecieveMessage' function the data that the client recieved from the server
        /// </summary>
        byte[] data;

        /// <summary>
        /// this property contains the object that is used to communicate with the server
        /// </summary>
        public CommunicationProtocol communicationProtocol = null;

        /// <summary>
        /// constructor. gives the property 'communicationProtocol' the same spot in the memory as the ManageHathatulClient communicationProtocol
        /// </summary>
        /// <param name="communicationProtocol"></param>
        public HathatulTcpClient(CommunicationProtocol communicationProtocol)
        {
            this.communicationProtocol = communicationProtocol;
        }
        /// <summary>
        /// this function creates the connection with the server. Connects the client to the server
        /// </summary>
        /// <param name="nickname"></param>
        public void ConnectToServer(string nickname)
        {
            try
            {
                tcpClient = new TcpClient();
                tcpClient.Connect(ipAddress, portNo);
                MessageBox.Show(tcpClient.Client.LocalEndPoint.ToString());
                data = new byte[tcpClient.ReceiveBufferSize];
                SendMessage(nickname);
                tcpClient.GetStream().BeginRead(data,
                                                     0,
                                                     System.Convert.ToInt32(tcpClient.ReceiveBufferSize),
                                                     ReceiveMessage,
                                                        null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        /// <summary>
        /// this funcion is used when the player send a message. it converts the string into bytes and sends it using the Tcp Protocol
        /// </summary>
        /// <param name="message"></param>
        public void SendMessage(string message)
        {
            try
            {

                // Send message to the server
                NetworkStream ns = tcpClient.GetStream();
                byte[] data = System.Text.Encoding.ASCII.GetBytes(message);

                // Send the text
                ns.Write(data, 0, data.Length);
                ns.Flush();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        /// <summary>
        /// this function is an Async function. it runs and reads messages. it transfers from bytes to string.
        /// and the messages it recieves are from the server
        /// </summary>
        /// <param name="ar"></param>
        public void ReceiveMessage(IAsyncResult ar)
        {
            int bytesRead;
            try
            {
                lock (tcpClient.GetStream())
                {
                    // call EndRead to handle the end of an async read.
                    bytesRead = tcpClient.GetStream().EndRead(ar);
                }
                if (bytesRead < 1)
                {

                    return;
                }
                else
                {
                    string textFromServer = System.Text.Encoding.ASCII.GetString(data, 0, bytesRead);
                    HathatulMessage messageReceived = communicationProtocol.TransferFromProtocol(textFromServer);
                    if (messageReceived.command.Contains("Blocked"))
                    {
                        MessageBox.Show("You are Blocked try again in half an hour");
                        Disconnect();
                        return;
                    }
                    if (!HathatulClient.didWeStartTheGame)
                    {
                        if (messageReceived.command.Contains("loggedButGameStarted"))
                        {
                            MessageBox.Show("Succesfully Logged In But Game Started");
                            Disconnect();
                        }
                        else if (messageReceived.command.Contains("SomeoneAlreadyConnected"))
                        {
                            MessageBox.Show("Someone Already Connected From That Account");
                            if (ChangePasswordForm.ActiveForm == null)
                            {
                                HathatulClient.lgn = new LoginForm(this, communicationProtocol);
                                Thread thread = new Thread(() => { HathatulClient.lgn.ShowDialog(); });
                                thread.Start();
                            }
                            else
                            {
                                HathatulClient.lgn.changePasswordObj.Invoke((Action)(() => HathatulClient.lgn.changePasswordObj.username.Enabled = true));
                                HathatulClient.lgn.changePasswordObj.Invoke((Action)(() => HathatulClient.lgn.changePasswordObj.SendMail.Enabled = true));
                                HathatulClient.lgn.changePasswordObj.Invoke((Action)(() => HathatulClient.lgn.changePasswordObj.TheCode.Visible = false));
                                HathatulClient.lgn.changePasswordObj.Invoke((Action)(() => HathatulClient.lgn.changePasswordObj.SecondLabel.Visible = false));
                                HathatulClient.lgn.changePasswordObj.Invoke((Action)(() => HathatulClient.lgn.changePasswordObj.ValidateCode.Visible = false));

                            }
                        }
                        else if (messageReceived.command.Contains("UsernameDoesntExist"))
                        {
                            HathatulClient.lgn.changePasswordObj.Invoke((Action)(() => HathatulClient.lgn.changePasswordObj.username.Enabled = true));
                            HathatulClient.lgn.changePasswordObj.Invoke((Action)(() => HathatulClient.lgn.changePasswordObj.SendMail.Enabled = true));
                            HathatulClient.lgn.changePasswordObj.Invoke((Action)(() => HathatulClient.lgn.changePasswordObj.TheCode.Visible = false));
                            HathatulClient.lgn.changePasswordObj.Invoke((Action)(() => HathatulClient.lgn.changePasswordObj.SecondLabel.Visible = false));
                            HathatulClient.lgn.changePasswordObj.Invoke((Action)(() => HathatulClient.lgn.changePasswordObj.ValidateCode.Visible = false));
                        }
                        else if (messageReceived.command.Contains("registedButGameStarted"))
                        {
                            MessageBox.Show("Succesfully Registed But Game Already Started");
                            Disconnect();
                        }
                        else if (messageReceived.command.Contains("MaxPlayerReached"))
                        {
                            MessageBox.Show("Max Player Reached");
                            Disconnect();
                        }
                        else if (messageReceived.command.Contains("the username already exists"))
                        {
                            MessageBox.Show("the username already exists. Please change it");
                            RegisterForm register = new RegisterForm(this, communicationProtocol);
                            Thread thread = new Thread(() => { register.ShowDialog(); });
                            thread.Start();
                        }
                        else if (messageReceived.command.Contains("you have registered successfully"))
                        {
                            MessageBox.Show("You have registered successfully");
                            string[] s = messageReceived.arguments.Split('|');
                            HathatulClient.waitingRoom = new WaitingRoom(s[0], s[1], s[2],this, communicationProtocol);
                            Thread thread = new Thread(() => { HathatulClient.waitingRoom.StartForm(s[3]); });
                            thread.Start();
                            
                        }
                        else if (messageReceived.command.Contains("LoggedIn"))
                        {
                            MessageBox.Show("Good Job, You are now logged in");
                            string[] s = messageReceived.arguments.Split('|');
                            HathatulClient.waitingRoom = new WaitingRoom(s[0], s[1], s[2], this, communicationProtocol);
                            Console.WriteLine(s[3]);
                            Thread thread = new Thread(() => { HathatulClient.waitingRoom.StartForm(s[3]); });
                            thread.Start(); 
                        }
                        else if (messageReceived.command.Contains("NotLogged"))
                        {
                            MessageBox.Show("username/password are incorrect");
                            HathatulClient.lgn = new LoginForm(this,communicationProtocol);
                            HathatulClient.lgn.forgotPasswordClick = false;
                            Thread thread = new Thread(() => { HathatulClient.lgn.ShowDialog(); });
                            thread.Start();
                        }
                        else if (messageReceived.command.Contains("updateconnected"))
                        {
                            if (messageReceived.arguments.Equals("1"))
                            {
                                HathatulClient.waitingRoom.isFirstPlayer = true;
                            }
                            string show = "playersConnected: " + messageReceived.arguments;
                            HathatulClient.waitingRoom.Invoke((Action)(() => HathatulClient.waitingRoom.howManyAreConnected.Text = show));
                        }
                        else if (messageReceived.command.Contains("CodeValidated"))
                        {
                            HathatulClient.lgn.changePasswordObj.Invoke((Action)(() => MessageBox.Show("Correct Code")));
                            HathatulClient.lgn.changePasswordObj.Invoke((Action)(() => HathatulClient.lgn.changePasswordObj.HandleAfterCodeValidated()));
                        }
                        else if (messageReceived.command.Contains("WrongCode"))
                        {
                            ChangePasswordForm pascnge = new ChangePasswordForm(this,communicationProtocol,HathatulClient.lgn);
                            HathatulClient.lgn.changePasswordObj.Invoke((Action)(() => MessageBox.Show("Wrong Code")));
                        }
                        else if (messageReceived.command.Contains("PasswordChanged"))
                        {
                            HathatulClient.lgn.changePasswordObj.Invoke((Action)(() => MessageBox.Show("Password Changed. Press Back To Login To Login With The New Password")));
                            HathatulClient.lgn.changePasswordObj.Invoke((Action)(() => HathatulClient.lgn.changePasswordObj.HandleAfterPasswordChange()));
                        }
                        else if (messageReceived.command.Contains("blockedFor30Min"))
                        {
                            MessageBox.Show("Blocked For 30 min");
                        }
                        else if (messageReceived.command.Contains("startTheGame"))
                        {
                            
                            string[] s = messageReceived.arguments.Split('|');
                            HathatulClient.gb = new HathatulBoardForm(s[0],HathatulClient.waitingRoom.EntryToken,HathatulClient.waitingRoom.name, this,communicationProtocol);
                            Thread thread = new Thread(() => { HathatulClient.gb.ShowDialog(); });
                            thread.Start();
                            if (HathatulClient.waitingRoom.rulesBook != null)
                            {
                                HathatulClient.waitingRoom.rulesBook.Invoke((Action)(() => HathatulClient.waitingRoom.rulesBook.Hide()));
                            }
                            HathatulClient.waitingRoom.Invoke((Action)(() => HathatulClient.waitingRoom.Dispose()));
                            HathatulClient.gb.Invoke((Action)(() => HathatulClient.gb.CreateAllOfCards(s[2])));
                            
                            HathatulClient.didWeStartTheGame = true;
                        }
                    }
                    else
                    {
                        if (messageReceived.command.Contains("SecondCardToFalse"))
                        {
                            if (!HathatulClient.gb.specialCard2drawTwo.Equals("drawTwo"))
                            {
                                string[] name = messageReceived.arguments.Split('|');
                                if (HathatulClient.gb.thirdPlayer.Text.Equals(name[0]))
                                {
                                    HathatulClient.gb.Invoke((Action)(() => HathatulClient.gb.thirdPlayerSecondCardDrawn.Visible = false));
                                }
                                else if (HathatulClient.gb.firstPlayer.Text.Equals(name[0]))
                                {

                                }
                                else if (HathatulClient.gb.secondPlayer.Text.Equals(name[0]))
                                {
                                    HathatulClient.gb.Invoke((Action)(() => HathatulClient.gb.secondPlayerSecondCardDrawn.Visible = false));
                                }
                                else if (HathatulClient.gb.fourthPlayer.Text.Equals(name[0]))
                                {
                                    HathatulClient.gb.Invoke((Action)(() => HathatulClient.gb.fourthPlayerSecondCardDrawn.Visible = false));
                                }
                            }
                        }
                        else if (messageReceived.command.Contains("FirstCardToFalse"))
                        {
                            if (!HathatulClient.gb.specialCard1drawTwo.Equals("drawTwo"))
                            {
                                string[] name = messageReceived.arguments.Split('|');
                                if (HathatulClient.gb.thirdPlayer.Text.Equals(name[0]))
                                {
                                    HathatulClient.gb.Invoke((Action)(() => HathatulClient.gb.thirdPlayerFirstCardDrawn.Visible = false));
                                }
                                else if (HathatulClient.gb.firstPlayer.Text.Equals(name[0]))
                                {

                                }
                                else if (HathatulClient.gb.secondPlayer.Text.Equals(name[0]))
                                {
                                    HathatulClient.gb.Invoke((Action)(() => HathatulClient.gb.secondPlayerFirstCardDrawn.Visible = false));
                                }
                                else if (HathatulClient.gb.fourthPlayer.Text.Equals(name[0]))
                                {
                                    HathatulClient.gb.Invoke((Action)(() => HathatulClient.gb.fourthPlayerFirstCardDrawn.Visible = false));
                                }
                            }
                        }
                        else if (messageReceived.command.Contains("TheCardInTheTrashCardIS"))
                        {
                            if (messageReceived.arguments.Contains("|"))
                            {
                                string[] s = messageReceived.arguments.Split('|');

                                HathatulClient.gb.Invoke((Action)(() => HathatulClient.gb.whatIsTheCardInTheTrash = s[0]));

                                if (s.Count() > 2)
                                {
                                    if (s[2] == HathatulClient.gb.thirdPlayer.Text)
                                    {
                                        HathatulClient.gb.Invoke((Action)(() => HathatulClient.gb.thirdPlayerFirstCardDrawn.Visible = false));
                                    }
                                    else if (s[2] == HathatulClient.gb.firstPlayer.Text)
                                    {

                                    }
                                    else if (s[2] == HathatulClient.gb.secondPlayer.Text)
                                    {
                                        HathatulClient.gb.Invoke((Action)(() => HathatulClient.gb.secondPlayerFirstCardDrawn.Visible = false));
                                    }
                                    else if (s[2] == HathatulClient.gb.fourthPlayer.Text)
                                    {
                                        HathatulClient.gb.Invoke((Action)(() => HathatulClient.gb.fourthPlayerFirstCardDrawn.Visible = false));
                                    }
                                }


                            }
                            else
                            {
                                HathatulClient.gb.whatIsTheCardInTheTrash = messageReceived.arguments;
                            }
                            HathatulClient.gb.Invoke((Action)(() => HathatulClient.gb.trashCards.Image = (Image)Properties.Resources.ResourceManager.GetObject(HathatulClient.gb.whatIsTheCardInTheTrash)));
                        }
                        else if (messageReceived.command.Contains("showDrawnCard"))
                        {
                            if (messageReceived.arguments == HathatulClient.gb.thirdPlayer.Text)
                            {
                                HathatulClient.gb.Invoke((Action)(() => HathatulClient.gb.thirdPlayerFirstCardDrawn.Visible = true));
                            }
                            else if (messageReceived.arguments == HathatulClient.gb.firstPlayer.Text)
                            {

                            }
                            else if (messageReceived.arguments == HathatulClient.gb.secondPlayer.Text)
                            {
                                HathatulClient.gb.Invoke((Action)(() => HathatulClient.gb.secondPlayerFirstCardDrawn.Visible = true));
                            }
                            else if (messageReceived.arguments == HathatulClient.gb.fourthPlayer.Text)
                            {
                                HathatulClient.gb.Invoke((Action)(() => HathatulClient.gb.fourthPlayerFirstCardDrawn.Visible = true));
                            }
                        }
                        if (messageReceived.command.Contains("GameEnded"))
                        {
                            string[] s = messageReceived.arguments.Split('|');
                            Thread thread = new Thread(() => {MessageBox.Show("GameEnded"); });
                            thread.Start();
                            if (messageReceived.command.Contains("GameEndedCardsEnded"))
                            {
                                HathatulClient.gb.Invoke((Action)(() => HathatulClient.gb.stackOfCards.Image = (Image)Properties.Resources.ResourceManager.GetObject("EmptyCardDeck")));
                                HathatulClient.gb.Invoke((Action)(() => HathatulClient.gb.stackOfCards.Location = new Point(1000, 143)));
                                HathatulClient.gb.Invoke((Action)(() => HathatulClient.gb.stackOfCards.BringToFront()));
                            }
                            if (s[0].Contains("ItsATie"))
                            {
                                HathatulClient.gb.Invoke((Action)(() => HathatulClient.gb.turnEnded.Text = ("Its A Tie!")));
                            }
                            else
                            {
                                HathatulClient.gb.Invoke((Action)(() => HathatulClient.gb.turnEnded.Text = ("The Winner is " + s[0])));
                            }
                            HathatulClient.gb.Invoke((Action)(() => HathatulClient.gb.Timer.Stop()));
                            HathatulClient.gb.Invoke((Action)(() => HathatulClient.gb.turnEnded.Width = 882));
                            HathatulClient.gb.Invoke((Action)(() => HathatulClient.gb.turnEnded.Height = 261));
                            HathatulClient.gb.Invoke((Action)(() => HathatulClient.gb.turnEnded.Font = new Font("Nirmala UI", 50,FontStyle.Bold)));
                            HathatulClient.gb.Invoke((Action)(() => HathatulClient.gb.Enabled = false));
                        }
                        if (messageReceived.command.Equals("Imposter")){
                            Thread thread = new Thread(() => { MessageBox.Show("You Are An IMPOSTER!!!"); });
                            thread.Start();
                            HathatulClient.gb.Invoke((Action)(() =>Disconnect()));
                        }
                        if (messageReceived.command.Contains("AllOfTheCards"))
                        {
                            CreateMidRun create = HathatulClient.gb.createMidRun;
                            HathatulClient.gb.Invoke((Action)(() => HathatulClient.gb.players.ShowCards(messageReceived.arguments,create)));
                        }
                        else if (messageReceived.arguments.Contains("AllOfTheCards"))
                        {
                            CreateMidRun create = HathatulClient.gb.createMidRun;
                            HathatulClient.gb.Invoke((Action)(() => HathatulClient.gb.players.ShowCards(textFromServer.Split('\n')[2],create)));
                        }
                        else if (messageReceived.command.Contains("playerAndItsSit"))
                        {
                            HathatulClient.gb.players = new MultipulePlayersHandler();
                            HathatulClient.gb.players.CreateListOfPlayers(messageReceived.arguments);
                            int sit = HathatulClient.gb.players.GetSeatNumber(HathatulClient.gb.username12);
                            HathatulClient.gb.Invoke((Action)(() => HathatulClient.gb.players.ShowNameOnEachPlayerLocation()));
                        }
                        else if (messageReceived.command.Contains("yourLeftCardIs"))
                        {
                            HathatulClient.gb.Invoke((Action)(() => HathatulClient.gb.PlayersCards[0,0].Image = (Image)Properties.Resources.ResourceManager.GetObject(messageReceived.arguments)));
                        }
                        else if (messageReceived.command.Contains("yourRightCardIs"))
                        {
                            HathatulClient.gb.Invoke((Action)(() => HathatulClient.gb.PlayersCards[0,3].Image = (Image)Properties.Resources.ResourceManager.GetObject(messageReceived.arguments)));
                        }
                        else if (messageReceived.command.Contains("cardFromStackIs"))
                        {
                            HathatulClient.gb.Invoke((Action)(() => HathatulClient.gb.yourDrawnCardFromStack.Visible = true));
                            HathatulClient.gb.Invoke((Action)(() => HathatulClient.gb.stackOfCards.Enabled = false));
                            HathatulClient.gb.Invoke((Action)(() => HathatulClient.gb.whatsTheNameOfTheCardImHolding = messageReceived.arguments));
                            HathatulClient.gb.Invoke((Action)(() => HathatulClient.gb.yourDrawnCardFromStack.Image = (Image)Properties.Resources.ResourceManager.GetObject(messageReceived.arguments)));
                        }
                        else if (messageReceived.command.Contains("ITSNOTYOURTURN"))
                        {
                            MessageBox.Show("It's not your turn!!");
                        }
                        else if (messageReceived.command.Contains("LastTurn!!"))
                        {
                            HathatulClient.gb.Invoke((Action)(() => HathatulClient.gb.turnEnded.Text = "It was Your Last Turn"));    
                        }
                        if (messageReceived.command.Contains("yourMiddleLeftCardIs"))
                        {
                            HathatulClient.gb.Invoke((Action)(() => HathatulClient.gb.PlayersCards[0, 1].Image = (Image)Properties.Resources.ResourceManager.GetObject(messageReceived.arguments)));
                        }
                        else if (messageReceived.command.Contains("yourMiddleRightCardIs"))
                        {
                            HathatulClient.gb.Invoke((Action)(() => HathatulClient.gb.PlayersCards[0, 2].Image = (Image)Properties.Resources.ResourceManager.GetObject(messageReceived.arguments)));
                        }
                        else if (messageReceived.command.Contains("specialCardDrawTwo"))
                        {
                            string[] s = messageReceived.arguments.Split('|');
                            HathatulClient.gb.specialCard1drawTwo = s[0];
                            HathatulClient.gb.specialCard2drawTwo = s[1];
                            HathatulClient.gb.Invoke((Action)(() => HathatulClient.gb.drawTwoSecondCard.Image = (Image)Properties.Resources.ResourceManager.GetObject(s[1])));
                            Thread thread = new Thread(() => { HathatulClient.gb.drawTwoFirstCard.Image = (Image)Properties.Resources.ResourceManager.GetObject(s[0]); });
                            thread.Start();
                        }
                        if (messageReceived.command.Contains("hisTurn"))
                        {
                            string name = messageReceived.arguments.Split('|')[1].Trim();
                            HathatulClient.gb.Invoke((Action)(() => HathatulClient.gb.firstPlayer.BackColor = Color.White));
                            HathatulClient.gb.Invoke((Action)(() => HathatulClient.gb.thirdPlayer.BackColor = Color.White));
                            if (HathatulClient.gb.secondPlayer != null)
                            {
                                HathatulClient.gb.Invoke((Action)(() => HathatulClient.gb.secondPlayer.BackColor = Color.White));
                            }
                            if (HathatulClient.gb.fourthPlayer != null)
                            {
                                HathatulClient.gb.Invoke((Action)(() => HathatulClient.gb.fourthPlayer.BackColor = Color.White));
                            }

                            if (HathatulClient.gb.firstPlayer.Text.Equals(name))
                            {
                            }
                            else if (HathatulClient.gb.thirdPlayer.Text.Equals(name))
                            {
                                HathatulClient.gb.Invoke((Action)(() => HathatulClient.gb.thirdPlayer.BackColor = Color.Green));
                            }
                            else if (HathatulClient.gb.secondPlayer.Text.Equals(name))
                            {
                                HathatulClient.gb.Invoke((Action)(() => HathatulClient.gb.secondPlayer.BackColor = Color.Green));
                            }
                            else if (HathatulClient.gb.fourthPlayer.Text.Equals(name))
                            {
                                HathatulClient.gb.Invoke((Action)(() => HathatulClient.gb.fourthPlayer.BackColor = Color.Green));
                            }
                        }
                        else if (messageReceived.command.Contains("yourTurn"))
                        {
                            HathatulClient.gb.Invoke((Action)(() => HathatulClient.gb.YourTurn()));
                        }
                        else if (messageReceived.command.Contains("turnDrawnCardToFalse"))
                        {

                            string[] name = messageReceived.arguments.Split('|');
                            if (name.Length == 2)
                            {
                                if (name[1] == "hisTurn")
                                {
                                    textFromServer = textFromServer.Split('\n')[2];
                                    HathatulClient.gb.Invoke((Action)(() => HathatulClient.gb.firstPlayer.BackColor = Color.White));
                                    HathatulClient.gb.Invoke((Action)(() => HathatulClient.gb.thirdPlayer.BackColor = Color.White));
                                    if (HathatulClient.gb.secondPlayer != null)
                                    {
                                        HathatulClient.gb.Invoke((Action)(() => HathatulClient.gb.secondPlayer.BackColor = Color.White));
                                    }
                                    if (HathatulClient.gb.fourthPlayer != null)
                                    {
                                        HathatulClient.gb.Invoke((Action)(() => HathatulClient.gb.fourthPlayer.BackColor = Color.White));
                                    }

                                    if (HathatulClient.gb.firstPlayer.Text.Equals(textFromServer))
                                    {
                                    }
                                    else if (HathatulClient.gb.thirdPlayer.Text.Equals(textFromServer))
                                    {
                                        HathatulClient.gb.Invoke((Action)(() => HathatulClient.gb.thirdPlayer.BackColor = Color.Green));
                                    }
                                    if (HathatulClient.gb.secondPlayer != null)
                                    {
                                        if (HathatulClient.gb.secondPlayer.Text.Equals(textFromServer))
                                        {
                                            HathatulClient.gb.Invoke((Action)(() => HathatulClient.gb.secondPlayer.BackColor = Color.Green));
                                        }
                                    }
                                    if (HathatulClient.gb.fourthPlayer != null)
                                    {
                                        if (HathatulClient.gb.fourthPlayer.Text.Equals(textFromServer))
                                        {
                                            HathatulClient.gb.Invoke((Action)(() => HathatulClient.gb.fourthPlayer.BackColor = Color.Green));
                                        }
                                    }
                                }
                                else if (name[1].Contains("yourTurn"))
                                {
                                    HathatulClient.gb.Invoke((Action)(() => HathatulClient.gb.YourTurn()));
                                }
                            }
                           
                                if (HathatulClient.gb.thirdPlayer.Text.Equals(name[0]))
                                {
                                    HathatulClient.gb.Invoke((Action)(() => HathatulClient.gb.thirdPlayerFirstCardDrawn.Visible = false));
                                }
                                else if (HathatulClient.gb.firstPlayer.Text.Equals(name[0]))
                                {
                                }
                                else if (HathatulClient.gb.secondPlayer.Text.Equals(name[0]))
                                {
                                    HathatulClient.gb.Invoke((Action)(() => HathatulClient.gb.secondPlayerFirstCardDrawn.Visible = false));
                                }
                                else if (HathatulClient.gb.fourthPlayer.Text.Equals(name[0]))
                                {
                                    HathatulClient.gb.Invoke((Action)(() => HathatulClient.gb.fourthPlayerFirstCardDrawn.Visible = false));
                                }
                            
                            
                            
                        }
                        else if (messageReceived.command.Contains("switching the cards have been a success"))
                        {
                            if (!HathatulClient.gb.specialCardDrawTwo)
                            {
                                HathatulClient.gb.Invoke((Action)(() => HathatulClient.gb.HandleAfterSwapCase()));
                            }
                            Thread thread = new Thread(() => { MessageBox.Show(messageReceived.command); });
                            thread.Start();
                        }
                        else if (messageReceived.command.Contains("your card has been switched with player:"))
                        {
                            Thread thread = new Thread(() => { MessageBox.Show(messageReceived.command); });
                            thread.Start();
                        }
                        else if (messageReceived.command.Contains("lastTurn"))
                        {
                            HathatulClient.gb.Invoke((Action)(() => MessageBox.Show(messageReceived.arguments + " Called Hathatul")));
                            HathatulClient.gb.Invoke((Action)(() => HathatulClient.gb.HathatulClicked = true));

                        }
                        else if (messageReceived.command.Contains("ShowBothDrawnCards"))
                        {
                            if (HathatulClient.gb.firstPlayer.BackColor == Color.Green)
                            {
                                HathatulClient.gb.Invoke((Action)(() => HathatulClient.gb.drawTwoFirstCard.Visible = true));
                                HathatulClient.gb.Invoke((Action)(() => HathatulClient.gb.drawTwoSecondCard.Visible = true));
                            }
                            else if (HathatulClient.gb.thirdPlayer.BackColor == Color.Green)
                            {
                                HathatulClient.gb.Invoke((Action)(() => HathatulClient.gb.thirdPlayerFirstCardDrawn.Visible = true));
                                HathatulClient.gb.Invoke((Action)(() => HathatulClient.gb.thirdPlayerSecondCardDrawn.Visible = true));
                            }
                            else if (HathatulClient.gb.secondPlayer.BackColor == Color.Green)
                            {
                                HathatulClient.gb.Invoke((Action)(() => HathatulClient.gb.secondPlayerSecondCardDrawn.Visible = true));
                                HathatulClient.gb.Invoke((Action)(() => HathatulClient.gb.secondPlayerFirstCardDrawn.Visible = true));
                            }
                            else if (HathatulClient.gb.fourthPlayer.BackColor == Color.Green)
                            {
                                HathatulClient.gb.Invoke((Action)(() => HathatulClient.gb.fourthPlayerFirstCardDrawn.Visible = true));
                                HathatulClient.gb.Invoke((Action)(() => HathatulClient.gb.fourthPlayerSecondCardDrawn.Visible = true));
                            }
                        }
                        else if (messageReceived.command.Contains("ThrowToTrash"))
                        {
                            HathatulClient.gb.Invoke((Action)(() => HathatulClient.gb.trashCards.Image = (Image)Properties.Resources.ResourceManager.GetObject(messageReceived.arguments)));
                        }



                    }
                    tcpClient.GetStream().BeginRead(data,
                                         0,
                                         System.Convert.ToInt32(tcpClient.ReceiveBufferSize),
                                         ReceiveMessage,
                                         null);
                }

                // Continue reading
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                // Ignore the error... fired when the user logs off
            }

        }
        /// <summary>
        /// this function disconnects the link between the client and the server. closes the stream
        /// </summary>
        public void Disconnect()
        {
            try
            {
                // Disconnect from the server
                tcpClient.GetStream().Close();
                tcpClient.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
      
       
        
    }
}