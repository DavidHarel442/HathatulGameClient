using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace GameClient
{
    public partial class WaitingRoom : Form
    {// this class is the waiting room. incharge of the waiting, room.
     
        /// <summary>
        /// this property 'rulesBook' is incharge of opening the rules' if the client pressed on the specific button.
        /// </summary>
        public RulesBookForm rulesBook = null;
        /// <summary>
        /// this property 'EntryToken' is a string recieved in the constructor, the token will be used to communicate with the server
        /// </summary>
        public string EntryToken = "";
        /// <summary>
        /// this property 'name' is a string recieved in the constructor, the name is the first name of the usert
        /// </summary>
        public string name = "";

        /// <summary>
        /// a property sent through each class starting from HathatulClient. which the client uses to communicate with the server
        /// </summary>
        public HathatulTcpClient client = null;
        /// <summary>
        /// a property which helps the client transfer his messages to the communication protocol forum
        /// </summary>
        public CommunicationProtocol communicationProtocol = null;
        /// <summary>
        /// this property turns to true if the text box says there is only one player connected.
        /// which then means the player is going to play first
        /// </summary>
        public bool isFirstPlayer = false;
        /// <summary>
        /// constructor which initialized the form of the waiting room and helps to transfer to the gameboard the username,token, and firstname.
        /// </summary>
        /// <param name="username"></param>
        /// <param name="entryToken"></param>
        /// <param name="name1"></param>
        public WaitingRoom(string username,string entryToken,string name1,HathatulTcpClient client,CommunicationProtocol communicationProtocol)
        {
            InitializeComponent();
            this.client = client;
            this.communicationProtocol = communicationProtocol;
            nickname.Text = username;
            EntryToken = entryToken;
            name = name1;
            this.communicationProtocol = communicationProtocol;
            

        }

        /// <summary>
        /// this is an Event Handler when someone presses on the button. if there are more then 1 players it starts the game.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StartGame_Click(object sender, EventArgs e)
        {
            if (!howManyAreConnected.Text.Contains("1"))
            {
                string message = communicationProtocol.TransferToProtocol("startYourEngines", "", "");
                client.SendMessage(message);
            }
            else
            {
                
                MessageBox.Show("you need to have more than one player connected");
                
            }
        }

        
        /// <summary>
        /// this is an Event Handler that happens when someone presses on the picturBox. it opens the form of the rules.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Rules_Click(object sender, EventArgs e)
        {
            rulesBook = new RulesBookForm();
            rulesBook.Show();
        }

        /// <summary>
        /// this function is called when the form is shown
        /// </summary>
        /// <param name="connected"></param>
        public void StartForm(string connected)
        {
            this.howManyAreConnected.Text = "playersConnected: " + connected;
            if (connected.Equals("1"))
            {
                HathatulClient.waitingRoom.isFirstPlayer = true;
            }
            this.ShowDialog();
        }
    }
}
