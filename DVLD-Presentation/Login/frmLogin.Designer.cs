namespace DVLD_Presentation
{
    partial class frmLogin
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLogin));
            this.bntLogIn = new System.Windows.Forms.Button();
            this.lnkClearAll = new System.Windows.Forms.LinkLabel();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lnkResetPassword = new System.Windows.Forms.LinkLabel();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnMinimize = new System.Windows.Forms.Button();
            this.txtbUsername = new System.Windows.Forms.TextBox();
            this.txtbPassword = new System.Windows.Forms.TextBox();
            this.lblLockedMessage = new System.Windows.Forms.Label();
            this.LockedTimer = new System.Windows.Forms.Timer(this.components);
            this.btnShowHidePassword = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.chkRememberMe = new System.Windows.Forms.CheckBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // bntLogIn
            // 
            this.bntLogIn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(239)))));
            this.bntLogIn.FlatAppearance.BorderSize = 0;
            this.bntLogIn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.bntLogIn.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bntLogIn.ForeColor = System.Drawing.Color.White;
            this.bntLogIn.Location = new System.Drawing.Point(749, 562);
            this.bntLogIn.Name = "bntLogIn";
            this.bntLogIn.Size = new System.Drawing.Size(154, 56);
            this.bntLogIn.TabIndex = 5;
            this.bntLogIn.Text = "Log in";
            this.bntLogIn.UseVisualStyleBackColor = false;
            this.bntLogIn.Click += new System.EventHandler(this.bntLogIn_Click);
            // 
            // lnkClearAll
            // 
            this.lnkClearAll.AutoSize = true;
            this.lnkClearAll.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkClearAll.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.lnkClearAll.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.lnkClearAll.Location = new System.Drawing.Point(898, 519);
            this.lnkClearAll.Name = "lnkClearAll";
            this.lnkClearAll.Size = new System.Drawing.Size(84, 28);
            this.lnkClearAll.TabIndex = 4;
            this.lnkClearAll.TabStop = true;
            this.lnkClearAll.Text = "Clear All";
            this.lnkClearAll.Visible = false;
            this.lnkClearAll.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkClearAll_LinkClicked);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(660, 430);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(132, 38);
            this.label3.TabIndex = 4;
            this.label3.Text = "Password";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 28F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(738, 233);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(180, 74);
            this.label1.TabIndex = 4;
            this.label1.Text = "DVLD";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(660, 352);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(142, 38);
            this.label2.TabIndex = 4;
            this.label2.Text = "Username";
            // 
            // lnkResetPassword
            // 
            this.lnkResetPassword.AutoSize = true;
            this.lnkResetPassword.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkResetPassword.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.lnkResetPassword.Location = new System.Drawing.Point(867, 635);
            this.lnkResetPassword.Name = "lnkResetPassword";
            this.lnkResetPassword.Size = new System.Drawing.Size(58, 28);
            this.lnkResetPassword.TabIndex = 6;
            this.lnkResetPassword.TabStop = true;
            this.lnkResetPassword.Text = "Reset";
            this.lnkResetPassword.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkResetPassword_LinkClicked);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Underline);
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(696, 635);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(167, 28);
            this.label4.TabIndex = 9;
            this.label4.Text = "Forgot Password?";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(523, 740);
            this.panel1.TabIndex = 6;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox2.Image = global::DVLD_Presentation.Properties.Resources.Background;
            this.pictureBox2.Location = new System.Drawing.Point(0, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(523, 740);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 0;
            this.pictureBox2.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnClose);
            this.panel2.Controls.Add(this.btnMinimize);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(523, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(633, 46);
            this.panel2.TabIndex = 7;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(23)))), ((int)(((byte)(61)))));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Image = global::DVLD_Presentation.Properties.Resources.Close_16;
            this.btnClose.Location = new System.Drawing.Point(591, 3);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(37, 40);
            this.btnClose.TabIndex = 4;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnMinimize
            // 
            this.btnMinimize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMinimize.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(23)))), ((int)(((byte)(61)))));
            this.btnMinimize.FlatAppearance.BorderSize = 0;
            this.btnMinimize.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btnMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMinimize.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMinimize.ForeColor = System.Drawing.Color.White;
            this.btnMinimize.Image = global::DVLD_Presentation.Properties.Resources.minimize_sign_16;
            this.btnMinimize.Location = new System.Drawing.Point(542, 3);
            this.btnMinimize.Name = "btnMinimize";
            this.btnMinimize.Size = new System.Drawing.Size(37, 40);
            this.btnMinimize.TabIndex = 4;
            this.btnMinimize.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnMinimize.UseVisualStyleBackColor = false;
            this.btnMinimize.Click += new System.EventHandler(this.btnMinimize_Click);
            // 
            // txtbUsername
            // 
            this.txtbUsername.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txtbUsername.Location = new System.Drawing.Point(667, 393);
            this.txtbUsername.Name = "txtbUsername";
            this.txtbUsername.Size = new System.Drawing.Size(315, 32);
            this.txtbUsername.TabIndex = 1;
            this.txtbUsername.TextChanged += new System.EventHandler(this.txtbUsername_TextChanged);
            // 
            // txtbPassword
            // 
            this.txtbPassword.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txtbPassword.Location = new System.Drawing.Point(665, 475);
            this.txtbPassword.Name = "txtbPassword";
            this.txtbPassword.PasswordChar = '*';
            this.txtbPassword.Size = new System.Drawing.Size(313, 32);
            this.txtbPassword.TabIndex = 2;
            this.txtbPassword.TextChanged += new System.EventHandler(this.txtbPassword_TextChanged);
            // 
            // lblLockedMessage
            // 
            this.lblLockedMessage.AutoSize = true;
            this.lblLockedMessage.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Underline);
            this.lblLockedMessage.ForeColor = System.Drawing.Color.Red;
            this.lblLockedMessage.Location = new System.Drawing.Point(598, 307);
            this.lblLockedMessage.Name = "lblLockedMessage";
            this.lblLockedMessage.Size = new System.Drawing.Size(457, 28);
            this.lblLockedMessage.TabIndex = 4;
            this.lblLockedMessage.Text = "You are locked , you can try again after 30 Seconds.";
            this.lblLockedMessage.Visible = false;
            // 
            // LockedTimer
            // 
            this.LockedTimer.Interval = 1000;
            this.LockedTimer.Tick += new System.EventHandler(this.LockedTimer_Tick);
            // 
            // btnShowHidePassword
            // 
            this.btnShowHidePassword.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnShowHidePassword.BackColor = System.Drawing.Color.White;
            this.btnShowHidePassword.BackgroundImage = global::DVLD_Presentation.Properties.Resources.HidePassword_16;
            this.btnShowHidePassword.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnShowHidePassword.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnShowHidePassword.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.btnShowHidePassword.FlatAppearance.BorderSize = 0;
            this.btnShowHidePassword.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control;
            this.btnShowHidePassword.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShowHidePassword.Font = new System.Drawing.Font("Algerian", 14F, System.Drawing.FontStyle.Bold);
            this.btnShowHidePassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.btnShowHidePassword.Location = new System.Drawing.Point(939, 475);
            this.btnShowHidePassword.Name = "btnShowHidePassword";
            this.btnShowHidePassword.Size = new System.Drawing.Size(39, 26);
            this.btnShowHidePassword.TabIndex = 18;
            this.btnShowHidePassword.UseVisualStyleBackColor = false;
            this.btnShowHidePassword.Visible = false;
            this.btnShowHidePassword.Click += new System.EventHandler(this.btnShowHidePassword_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DVLD_Presentation.Properties.Resources.DVLD2;
            this.pictureBox1.Location = new System.Drawing.Point(667, 52);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(307, 178);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // chkRememberMe
            // 
            this.chkRememberMe.AutoSize = true;
            this.chkRememberMe.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkRememberMe.ForeColor = System.Drawing.Color.White;
            this.chkRememberMe.Location = new System.Drawing.Point(665, 519);
            this.chkRememberMe.Name = "chkRememberMe";
            this.chkRememberMe.Size = new System.Drawing.Size(165, 32);
            this.chkRememberMe.TabIndex = 3;
            this.chkRememberMe.Text = "Remember Me";
            this.chkRememberMe.UseVisualStyleBackColor = true;
            // 
            // frmLogin
            // 
            this.AcceptButton = this.bntLogIn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(23)))), ((int)(((byte)(61)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(1156, 740);
            this.ControlBox = false;
            this.Controls.Add(this.chkRememberMe);
            this.Controls.Add(this.btnShowHidePassword);
            this.Controls.Add(this.txtbPassword);
            this.Controls.Add(this.txtbUsername);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.bntLogIn);
            this.Controls.Add(this.lnkResetPassword);
            this.Controls.Add(this.lnkClearAll);
            this.Controls.Add(this.lblLockedMessage);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.panel1);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmLogin_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bntLogIn;
        private System.Windows.Forms.LinkLabel lnkClearAll;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.LinkLabel lnkResetPassword;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnMinimize;
        private System.Windows.Forms.Button btnShowHidePassword;
        private System.Windows.Forms.TextBox txtbUsername;
        private System.Windows.Forms.TextBox txtbPassword;
        private System.Windows.Forms.Label lblLockedMessage;
        private System.Windows.Forms.Timer LockedTimer;
        private System.Windows.Forms.CheckBox chkRememberMe;
    }
}

