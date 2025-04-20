using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameClient
{
    internal class CommunicationWithServer
    {
        static int portNo = 5000;
        private static string ipAddress = "127.0.0.1";
        static TcpClient client;
        static byte[] data;
        public static string firstName = "";




        public static void SendMessage(string message)
        {
            try
            {
                // send message to the server
                NetworkStream ns = client.GetStream();
                byte[] data = System.Text.Encoding.ASCII.GetBytes(message);

                // send the text
                ns.Write(data, 0, data.Length);
                ns.Flush();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        /// <summary>
        /// Asynchronously read data sent from the server in a seperate thread.
        /// Update the txtMessageHistory control using delegate.
        /// 
        /// Windows controls are not thread safed !
        /// </summary>
        /// <param name="ar"></param>
        public static void ReceiveMessage(IAsyncResult ar)
        {
            try
            {
                int bytesRead;

                // read the data from the server
                bytesRead = client.GetStream().EndRead(ar);

                if (bytesRead < 1)
                {
                    return;
                }
                else
                {
                    // invoke the delegate to display the recived data
                    string textFromServer = System.Text.Encoding.ASCII.GetString(data, 0, bytesRead);
                    if (textFromServer.Contains("TheFirstName:"))
                    {
                        firstName = textFromServer.Substring(13);
                        LoginAndRegister.ActiveForm.Hide();
                        GameBoard gb = new GameBoard(firstName);
                        gb.ShowDialog();
                        
                    }
                    else if (textFromServer.Equals("the username already exists"))
                    {
                        MessageBox.Show("the username already exists. pls change it");
                    }
                    else if (textFromServer.Equals("you have registered succesfully"))
                    {
                        MessageBox.Show("you have registered succesfully");
                    }
                    else if (textFromServer.Contains("LoggedIn"))
                    {
                        MessageBox.Show("Good Job, You are now logged in");
                        textFromServer = textFromServer.Substring(9);
                        GameBoard gb = new GameBoard(textFromServer);
                        gb.ShowDialog();
                    }
                    else if (textFromServer.Equals("youAreNotLogged"))
                    {
                        MessageBox.Show("username or password are incorrect"); 
                    }



                }

                // continue reading
                client.GetStream().BeginRead(data,
                                         0,
                                         System.Convert.ToInt32(client.ReceiveBufferSize),
                                         ReceiveMessage,
                                         null);
            }
            catch (Exception ex)
            {
                // ignor the error... fired when the user loggs off
            }
        }
        public static void Disconnect()
        {
            try
            {
                // disconnect form the server
                client.GetStream().Close();
                client.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        //this function connectes you with the server
        public static void connectWithServer(string nickname)
        {
            try
            {
                client = new TcpClient();
                client.Connect(ipAddress, portNo);
                MessageBox.Show(client.Client.LocalEndPoint.ToString());
                data = new byte[client.ReceiveBufferSize];
                SendMessage(nickname);
                client.GetStream().BeginRead(data,
                                                     0,
                                                     System.Convert.ToInt32(client.ReceiveBufferSize),
                                                     ReceiveMessage,
                                                        null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
       
    }
}
