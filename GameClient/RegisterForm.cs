﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameClient
{
    public partial class RegisterForm : Form
    {// this class manges the events happening in the 'RegisterToGame' form

        /// <summary>
        /// a property sent through each class starting from HathatulClient. which you use to communicate with the server
        /// </summary>
        public HathatulTcpClient client = null;
        /// <summary>
        /// a property which helps you transfer the clients messages to the communication protocol forum
        /// </summary>
        public CommunicationProtocol communicationProtocol = null;
        /// <summary>
        /// defualt constructor which Initialize the form
        /// </summary>
        public RegisterForm(HathatulTcpClient client,CommunicationProtocol communicationProtocol)
        {
            InitializeComponent();
            this.communicationProtocol = communicationProtocol;
            this.client = client;
        }
        /// <summary>
        /// this function checks if all the boxes for the register are filled
        /// </summary>
        /// <returns></returns>
        public bool IsFilled()
        {
            if (nickname.Text.Count() <= 3 && nickname.Text.Count()>12)
            {
                MessageBox.Show("fix name");
                return false;
            }
            if (!ValidatePassword(password.Text))
            {
                MessageBox.Show("fix password: password should have: 1 capital letter, 1 lowercase letter, 1 numberic value and 1 special character");
                return false;
            }
            if (firstname.Text.Count() <= 1 && firstname.Text.Count() > 15)
            {
                MessageBox.Show("fix firstname");
                return false;
            }
            if (lastname.Text.Count() <= 1 && lastname.Text.Count() > 15)
            {
                MessageBox.Show("fix lastname");
                return false;
            }
            if (!IsValidEmail(emailTextBox.Text))
            {
                return false;
            }

            if (city.Text.Count() == 0)
            {
                MessageBox.Show("choose city");
                return false;
            }
            if (gender.Text.Count() == 0)
            {
                MessageBox.Show("choose gender");
                return false;
            }
            return true;
        }
        /// <summary>
        /// this function checks if the email wrote in the text box is valid
        /// </summary>
        /// <param name="emailaddress"></param>
        /// <returns></returns>
        public bool IsValidEmail(string emailaddress)
        {
            string email = emailTextBox.Text;
            if (email.Length == 0)
                return false;
            try
            {
                email = Regex.Replace(email, @"(@)(.+)$", DomainMapper,
                                      RegexOptions.None, TimeSpan.FromMilliseconds(200));
                string DomainMapper(Match match)
                {
                    var idn = new IdnMapping();
                    string domainName = idn.GetAscii(match.Groups[2].Value);
                    return match.Groups[1].Value + domainName;
                }
            }
            catch (ArgumentException e)
            {
                MessageBox.Show("Email Is Not Valid!");
                return false;
            }
            if (!Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$", RegexOptions.IgnoreCase))
            {
                MessageBox.Show("Email Is Not Valid!");
                return false;
            }
            return true;
        }
        /// <summary>
        /// this function checks if the password put in is valid.
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
        /// this function is an Event Handler for the register click.
        /// it sends a message to the server with all the info to register to the database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Regist_Click(object sender, EventArgs e)
        {
            if (this.IsFilled())
            {
                if (!HathatulClient.lgn.forgotPasswordClick)
                {
                    client.ConnectToServer(nickname.Text);
                }
                string data = nickname.Text + "|" + password.Text + "|" + firstname.Text + "|" + lastname.Text + "|" + emailTextBox.Text + "|" + city.Text + "|" + gender.Text;
                string message = communicationProtocol.TransferToProtocol("register:", "", data);
                client.SendMessage(message);
                this.Hide();


            }
        }
        /// <summary>
        /// this function is an Event Handler  and it sends the user back to the Login page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BackToLogin_Click(object sender, EventArgs e)
        {

            LoginForm BackToGame = new LoginForm(client, communicationProtocol);
            this.Hide();
            BackToGame.ShowDialog();
        }
        /// <summary>
        /// this function clears the fields
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClearFields_Click(object sender, EventArgs e)
        {
            this.nickname.Clear();
            this.password.Clear();
            this.firstname.Clear();
            this.lastname.Clear();
            this.emailTextBox.Clear();
            this.city.Text = "";
            this.gender.Text = "";
            this.nickname.Focus();
        }

       
    }
}
