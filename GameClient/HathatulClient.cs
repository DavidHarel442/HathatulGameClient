using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameClient
{
    public class HathatulClient
    {// the class that runs when you start the run.By pressing 'Start'. this class is incharge of the whole client.


        /// <summary>
        /// this property is a static property. it contains the form of the gameboard
        /// </summary>
        public static HathatulBoardForm gb;
        /// <summary>
        /// this property is a static property. it contains the form of the the waiting room
        /// </summary>
        public static WaitingRoom waitingRoom;
        
        /// <summary>
        /// this property is a static property. it turns true if the game started.
        /// </summary>
        public static bool didWeStartTheGame = false;
        /// <summary>
        /// this static property is in charge of opening the login form
        /// </summary>
        public static LoginForm lgn = null;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        
        
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            CommunicationProtocol communicationProtocol = new CommunicationProtocol();
            HathatulTcpClient client = new HathatulTcpClient(communicationProtocol);// creating the communication object.
            lgn = new LoginForm(client,communicationProtocol);
            Application.Run(lgn);
           
        }
    }
}
