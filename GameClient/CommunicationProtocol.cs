using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameClient
{
    public class CommunicationProtocol
    {// this class manages the communication protocol. the structure is first a message of what to do and the second is the data for each request 
       
        /// <summary>
        /// default constructor
        /// </summary>
        public CommunicationProtocol()
        {

        }

        /// <summary>
        /// this function transfers to the protocol. first is the command, second is the SpecialToken, and third is the Arguments
        /// </summary>
        /// <param name="command"></param>
        /// <param name="token"></param>
        /// <param name="info"></param>
        /// <returns></returns>
        public string TransferToProtocol(string command,string token, string info)
        {
            string answer = command + "\n" + token + "\n" + info;
            return answer;
        }
        /// <summary>
        /// this function takes the received message that the client sent and transfers it from the protocol. to the properties 'command' and arguments
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public HathatulMessage TransferFromProtocol(string message)
        {
            HathatulMessage ReturnedMessage = new HathatulMessage();
            string[] MessageSplited = message.Split('\n');
            ReturnedMessage.command = MessageSplited[0];
            if (MessageSplited.Length > 1)
            {
                ReturnedMessage.arguments = MessageSplited[1];
            }
            return ReturnedMessage;
        }
    }
}
