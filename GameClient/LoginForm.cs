using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace GameClient
{
    public partial class LoginForm : Form
    {// this class is incharge of the form 'LoginToGame' 
        /// <summary>
        /// this property turns to true if the client pressed on the "ForgotPassword" label.
        /// </summary>
        public bool forgotPasswordClick = false;
        /// <summary>
        /// a static property incharge that if someone presses the 'ChangePassword' button it shows the form of the 'PasswordChange'.
        /// </summary>
        public ChangePasswordForm changePasswordObj = null;
        /// <summary>
        /// a property that helps the client to communicate with the server. it transfers it to the communication protocol forum 
        /// </summary>
        public CommunicationProtocol communicationProtocol = null;
        /// <summary>
        /// a property sent through each class starting from HathatulClient. which the client uses to communicate with the server
        /// </summary>
        public HathatulTcpClient client = null;
        /// <summary>
        /// default constructor that initialized the form 'LoginToGame'
        /// </summary>
        public LoginForm(HathatulTcpClient client, CommunicationProtocol communicationProtocol)
        {
            InitializeComponent();
            this.client = client;
            this.communicationProtocol = communicationProtocol;
            changePasswordObj = new ChangePasswordForm(client, communicationProtocol, this);
        }
        /// <summary>
        /// this function checks if the recieved password is valid.
        /// has atleast 1 small letter. 1 capital letter. 1 special case letter, And at least 1 number
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        public bool ValidatePassword(string password)
        {

            string Uppercase = @"[A-Z]";
            string lowerCase = @"[a-z]";
            string number = @"\d";
            string symbol = @"[^a-zA-Z0-9]";
            if (Regex.IsMatch(password, Uppercase) && Regex.IsMatch(password, lowerCase) && Regex.IsMatch(password, number) && Regex.IsMatch(password, symbol))
            {
                return true;
            }
            return false;

        }
        /// <summary>
        /// this function is An Event Handler that occurs when someone presses on the 'Login' Button.
        /// it sends a message to the server to check whether the username and password wrote are correct in the Sql DataBase
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Login_Click(object sender, EventArgs e)
        {
            if (username.Text.Count() > 1 && password5.Text.Count() > 1)
            {
                if (ValidatePassword(password5.Text))
                {
                    if (!forgotPasswordClick)
                    {
                        client.ConnectToServer(username.Text);
                    }
                    this.Hide();
                    string data = username.Text + "|" + password5.Text;
                    string message = communicationProtocol.TransferToProtocol("checkLogin", "", data);
                    client.SendMessage(message);
                }
                else
                {
                    MessageBox.Show("fix password: password should have: 1 capital letter, 1 lowercase letter, 1 numberic value and 1 special character");
                }


            }
            else
            {
                MessageBox.Show("your username/password is too short");
            }
            


        }
        /// <summary>
        /// An Event Handler that happens when the 'LoginToGame' form closed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoginToGame_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
        }
        /// <summary>
        /// An Event Handler that occurs when someone is pressing on the 'ClearFields' button. and it clears all the fields textboxes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClearFields_Click(object sender, EventArgs e)
        {
            this.username.Clear();
            this.password5.Clear();
            this.username.Focus();

        }
        /// <summary>
        /// An Event Handler that occurs when someone is pressing on the 'ShowPassword'. if it wasnt pressed it shows the password wrote in if it was pressed it encrypts it
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            if(ShowPassword.Checked)
            {
                this.password5.PasswordChar = '\0';
            }
            else
            {
                this.password5.PasswordChar = '•';
            }
        }
        /// <summary>
        /// happens when someone presses on the 'ChangePassword' label.
        /// it transfers them to the 'PasswordChange' form. and closes the 'LoginToGame' form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChangePassword_Click(object sender, EventArgs e)
        {
            this.Hide();
            changePasswordObj.ShowDialog();
        }
        /// <summary>
        /// happens when someone presses on the 'CreateAccount' label.
        /// it transfers them to the 'RegisterToGame' form. and closes the 'LoginToGame' form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CreateAccount_Click(object sender, EventArgs e)
        {
            RegisterForm register = new RegisterForm(client, communicationProtocol);
            this.Hide();
            register.ShowDialog();
        }
    }
}

