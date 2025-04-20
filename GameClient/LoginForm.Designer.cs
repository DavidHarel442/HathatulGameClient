﻿namespace GameClient
{
    partial class LoginForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.login = new System.Windows.Forms.Button();
            this.password5 = new System.Windows.Forms.TextBox();
            this.username = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.ShowPassword = new System.Windows.Forms.CheckBox();
            this.GetStartedLabel = new System.Windows.Forms.Label();
            this.CreateAccount = new System.Windows.Forms.Label();
            this.ClrearFields = new System.Windows.Forms.Button();
            this.ChangePassword = new System.Windows.Forms.Label();
            this.f = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // login
            // 
            this.login.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(157)))), ((int)(((byte)(88)))));
            this.login.Cursor = System.Windows.Forms.Cursors.Hand;
            this.login.FlatAppearance.BorderSize = 0;
            this.login.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.login.Font = new System.Drawing.Font("Nirmala UI", 12F, System.Drawing.FontStyle.Bold);
            this.login.ForeColor = System.Drawing.SystemColors.Window;
            this.login.Location = new System.Drawing.Point(25, 320);
            this.login.Margin = new System.Windows.Forms.Padding(4);
            this.login.Name = "login";
            this.login.Size = new System.Drawing.Size(216, 41);
            this.login.TabIndex = 38;
            this.login.Text = "Login";
            this.login.UseVisualStyleBackColor = false;
            this.login.Click += new System.EventHandler(this.Login_Click);
            // 
            // password5
            // 
            this.password5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(231)))), ((int)(((byte)(233)))));
            this.password5.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.password5.Font = new System.Drawing.Font("MV Boli", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.password5.Location = new System.Drawing.Point(25, 248);
            this.password5.Margin = new System.Windows.Forms.Padding(4);
            this.password5.Multiline = true;
            this.password5.Name = "password5";
            this.password5.PasswordChar = '•';
            this.password5.Size = new System.Drawing.Size(216, 28);
            this.password5.TabIndex = 30;
            this.password5.Text = "David24!";
            // 
            // username
            // 
            this.username.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(231)))), ((int)(((byte)(233)))));
            this.username.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.username.Font = new System.Drawing.Font("MV Boli", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.username.Location = new System.Drawing.Point(25, 160);
            this.username.Margin = new System.Windows.Forms.Padding(4);
            this.username.Multiline = true;
            this.username.Name = "username";
            this.username.Size = new System.Drawing.Size(216, 28);
            this.username.TabIndex = 29;
            this.username.Text = "david";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(22, 121);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(72, 17);
            this.label7.TabIndex = 26;
            this.label7.Text = "username:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(22, 211);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(66, 17);
            this.label6.TabIndex = 25;
            this.label6.Text = "password";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(1, 0);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(12, 17);
            this.label10.TabIndex = 40;
            this.label10.Text = " ";
            // 
            // ShowPassword
            // 
            this.ShowPassword.AutoSize = true;
            this.ShowPassword.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ShowPassword.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ShowPassword.Location = new System.Drawing.Point(122, 283);
            this.ShowPassword.Name = "ShowPassword";
            this.ShowPassword.Size = new System.Drawing.Size(119, 21);
            this.ShowPassword.TabIndex = 43;
            this.ShowPassword.Text = "Show Password";
            this.ShowPassword.UseVisualStyleBackColor = true;
            this.ShowPassword.CheckedChanged += new System.EventHandler(this.ShowPassword_CheckedChanged);
            // 
            // GetStartedLabel
            // 
            this.GetStartedLabel.AutoSize = true;
            this.GetStartedLabel.Font = new System.Drawing.Font("MS UI Gothic", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GetStartedLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(157)))), ((int)(((byte)(88)))));
            this.GetStartedLabel.Location = new System.Drawing.Point(52, 46);
            this.GetStartedLabel.Name = "GetStartedLabel";
            this.GetStartedLabel.Size = new System.Drawing.Size(155, 27);
            this.GetStartedLabel.TabIndex = 57;
            this.GetStartedLabel.Text = "Get Started";
            // 
            // CreateAccount
            // 
            this.CreateAccount.AutoSize = true;
            this.CreateAccount.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CreateAccount.Font = new System.Drawing.Font("Nirmala UI", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CreateAccount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(157)))), ((int)(((byte)(88)))));
            this.CreateAccount.Location = new System.Drawing.Point(70, 431);
            this.CreateAccount.Name = "CreateAccount";
            this.CreateAccount.Size = new System.Drawing.Size(122, 17);
            this.CreateAccount.TabIndex = 58;
            this.CreateAccount.Text = "Create An Account";
            this.CreateAccount.Click += new System.EventHandler(this.CreateAccount_Click);
            // 
            // ClrearFields
            // 
            this.ClrearFields.BackColor = System.Drawing.Color.White;
            this.ClrearFields.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ClrearFields.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ClrearFields.Font = new System.Drawing.Font("Nirmala UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ClrearFields.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(157)))), ((int)(((byte)(88)))));
            this.ClrearFields.Location = new System.Drawing.Point(25, 369);
            this.ClrearFields.Margin = new System.Windows.Forms.Padding(4);
            this.ClrearFields.Name = "ClrearFields";
            this.ClrearFields.Size = new System.Drawing.Size(216, 43);
            this.ClrearFields.TabIndex = 59;
            this.ClrearFields.Text = "Clear";
            this.ClrearFields.UseVisualStyleBackColor = false;
            this.ClrearFields.Click += new System.EventHandler(this.ClearFields_Click);
            // 
            // ChangePassword
            // 
            this.ChangePassword.AutoSize = true;
            this.ChangePassword.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ChangePassword.Font = new System.Drawing.Font("Nirmala UI", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChangePassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(157)))), ((int)(((byte)(88)))));
            this.ChangePassword.Location = new System.Drawing.Point(139, 466);
            this.ChangePassword.Name = "ChangePassword";
            this.ChangePassword.Size = new System.Drawing.Size(116, 17);
            this.ChangePassword.TabIndex = 63;
            this.ChangePassword.Text = "Change Password";
            this.ChangePassword.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ChangePassword.Click += new System.EventHandler(this.ChangePassword_Click);
            // 
            // f
            // 
            this.f.AutoSize = true;
            this.f.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.f.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(164)))), ((int)(((byte)(165)))), ((int)(((byte)(169)))));
            this.f.Location = new System.Drawing.Point(16, 466);
            this.f.Name = "f";
            this.f.Size = new System.Drawing.Size(117, 17);
            this.f.TabIndex = 62;
            this.f.Text = "Forgot Password?";
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(267, 512);
            this.Controls.Add(this.ChangePassword);
            this.Controls.Add(this.f);
            this.Controls.Add(this.ClrearFields);
            this.Controls.Add(this.CreateAccount);
            this.Controls.Add(this.GetStartedLabel);
            this.Controls.Add(this.ShowPassword);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.login);
            this.Controls.Add(this.password5);
            this.Controls.Add(this.username);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(164)))), ((int)(((byte)(165)))), ((int)(((byte)(169)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.LoginToGame_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button login;
        private System.Windows.Forms.TextBox password5;
        private System.Windows.Forms.TextBox username;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        public System.Windows.Forms.Label label10;
        private System.Windows.Forms.CheckBox ShowPassword;
        private System.Windows.Forms.Label GetStartedLabel;
        private System.Windows.Forms.Label CreateAccount;
        private System.Windows.Forms.Button ClrearFields;
        private System.Windows.Forms.Label ChangePassword;
        private System.Windows.Forms.Label f;
    }
}

