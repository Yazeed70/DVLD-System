namespace DVLD_Presentation
{
    partial class frmChangePassword
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
            this.txtConfirmPassword = new System.Windows.Forms.TextBox();
            this.txtNewPassword = new System.Windows.Forms.TextBox();
            this.txtCurrentPassword = new System.Windows.Forms.TextBox();
            this.l = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnShowHideCurrentPassword = new System.Windows.Forms.Button();
            this.btnShowHideNewPassword = new System.Windows.Forms.Button();
            this.btnShowHideConfirmPassword = new System.Windows.Forms.Button();
            this.ctrlUserDetails1 = new DVLD_Presentation.ctrlUserDetails();
            this.SuspendLayout();
            // 
            // txtConfirmPassword
            // 
            this.txtConfirmPassword.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtConfirmPassword.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtConfirmPassword.Location = new System.Drawing.Point(376, 605);
            this.txtConfirmPassword.Name = "txtConfirmPassword";
            this.txtConfirmPassword.PasswordChar = '*';
            this.txtConfirmPassword.Size = new System.Drawing.Size(145, 32);
            this.txtConfirmPassword.TabIndex = 3;
            this.txtConfirmPassword.TextChanged += new System.EventHandler(this.txtConfirmPassword_TextChanged);
            // 
            // txtNewPassword
            // 
            this.txtNewPassword.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtNewPassword.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNewPassword.Location = new System.Drawing.Point(376, 561);
            this.txtNewPassword.Name = "txtNewPassword";
            this.txtNewPassword.PasswordChar = '*';
            this.txtNewPassword.Size = new System.Drawing.Size(145, 32);
            this.txtNewPassword.TabIndex = 2;
            this.txtNewPassword.TextChanged += new System.EventHandler(this.txtNewPassword_TextChanged);
            // 
            // txtCurrentPassword
            // 
            this.txtCurrentPassword.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtCurrentPassword.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCurrentPassword.Location = new System.Drawing.Point(376, 510);
            this.txtCurrentPassword.Name = "txtCurrentPassword";
            this.txtCurrentPassword.PasswordChar = '*';
            this.txtCurrentPassword.Size = new System.Drawing.Size(145, 32);
            this.txtCurrentPassword.TabIndex = 1;
            this.txtCurrentPassword.TextChanged += new System.EventHandler(this.txtCurrentPassword_TextChanged);
            // 
            // l
            // 
            this.l.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.l.AutoSize = true;
            this.l.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l.Location = new System.Drawing.Point(162, 606);
            this.l.Name = "l";
            this.l.Size = new System.Drawing.Size(200, 24);
            this.l.TabIndex = 10;
            this.l.Text = "Confirm Password:";
            // 
            // lblPassword
            // 
            this.lblPassword.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblPassword.AutoSize = true;
            this.lblPassword.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPassword.Location = new System.Drawing.Point(197, 562);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(165, 24);
            this.lblPassword.TabIndex = 11;
            this.lblPassword.Text = "New Password:";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(165, 514);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(197, 24);
            this.label2.TabIndex = 12;
            this.label2.Text = "Current Password:";
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.btnSave.FlatAppearance.BorderSize = 2;
            this.btnSave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Algerian", 14F, System.Drawing.FontStyle.Bold);
            this.btnSave.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.btnSave.Image = global::DVLD_Presentation.Properties.Resources.Save_32;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(892, 621);
            this.btnSave.MinimumSize = new System.Drawing.Size(214, 65);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(214, 65);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "Save";
            this.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.btnClose.FlatAppearance.BorderSize = 2;
            this.btnClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Algerian", 14F, System.Drawing.FontStyle.Bold);
            this.btnClose.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.btnClose.Image = global::DVLD_Presentation.Properties.Resources.Cancel_32;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(660, 621);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(214, 65);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "Close";
            this.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnShowHideCurrentPassword
            // 
            this.btnShowHideCurrentPassword.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnShowHideCurrentPassword.BackColor = System.Drawing.Color.White;
            this.btnShowHideCurrentPassword.BackgroundImage = global::DVLD_Presentation.Properties.Resources.HidePassword_16;
            this.btnShowHideCurrentPassword.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnShowHideCurrentPassword.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnShowHideCurrentPassword.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.btnShowHideCurrentPassword.FlatAppearance.BorderSize = 0;
            this.btnShowHideCurrentPassword.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control;
            this.btnShowHideCurrentPassword.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShowHideCurrentPassword.Font = new System.Drawing.Font("Algerian", 14F, System.Drawing.FontStyle.Bold);
            this.btnShowHideCurrentPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.btnShowHideCurrentPassword.Location = new System.Drawing.Point(482, 511);
            this.btnShowHideCurrentPassword.Name = "btnShowHideCurrentPassword";
            this.btnShowHideCurrentPassword.Size = new System.Drawing.Size(39, 29);
            this.btnShowHideCurrentPassword.TabIndex = 17;
            this.btnShowHideCurrentPassword.UseVisualStyleBackColor = false;
            this.btnShowHideCurrentPassword.Visible = false;
            this.btnShowHideCurrentPassword.Click += new System.EventHandler(this.btnShowHidePassword_Click);
            // 
            // btnShowHideNewPassword
            // 
            this.btnShowHideNewPassword.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnShowHideNewPassword.BackColor = System.Drawing.Color.White;
            this.btnShowHideNewPassword.BackgroundImage = global::DVLD_Presentation.Properties.Resources.HidePassword_16;
            this.btnShowHideNewPassword.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnShowHideNewPassword.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnShowHideNewPassword.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.btnShowHideNewPassword.FlatAppearance.BorderSize = 0;
            this.btnShowHideNewPassword.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control;
            this.btnShowHideNewPassword.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShowHideNewPassword.Font = new System.Drawing.Font("Algerian", 14F, System.Drawing.FontStyle.Bold);
            this.btnShowHideNewPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.btnShowHideNewPassword.Location = new System.Drawing.Point(482, 562);
            this.btnShowHideNewPassword.Name = "btnShowHideNewPassword";
            this.btnShowHideNewPassword.Size = new System.Drawing.Size(39, 29);
            this.btnShowHideNewPassword.TabIndex = 17;
            this.btnShowHideNewPassword.UseVisualStyleBackColor = false;
            this.btnShowHideNewPassword.Visible = false;
            this.btnShowHideNewPassword.Click += new System.EventHandler(this.btnShowHidePassword_Click);
            // 
            // btnShowHideConfirmPassword
            // 
            this.btnShowHideConfirmPassword.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnShowHideConfirmPassword.BackColor = System.Drawing.Color.White;
            this.btnShowHideConfirmPassword.BackgroundImage = global::DVLD_Presentation.Properties.Resources.HidePassword_16;
            this.btnShowHideConfirmPassword.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnShowHideConfirmPassword.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnShowHideConfirmPassword.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.btnShowHideConfirmPassword.FlatAppearance.BorderSize = 0;
            this.btnShowHideConfirmPassword.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control;
            this.btnShowHideConfirmPassword.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShowHideConfirmPassword.Font = new System.Drawing.Font("Algerian", 14F, System.Drawing.FontStyle.Bold);
            this.btnShowHideConfirmPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.btnShowHideConfirmPassword.Location = new System.Drawing.Point(482, 606);
            this.btnShowHideConfirmPassword.Name = "btnShowHideConfirmPassword";
            this.btnShowHideConfirmPassword.Size = new System.Drawing.Size(39, 29);
            this.btnShowHideConfirmPassword.TabIndex = 17;
            this.btnShowHideConfirmPassword.UseVisualStyleBackColor = false;
            this.btnShowHideConfirmPassword.Visible = false;
            this.btnShowHideConfirmPassword.Click += new System.EventHandler(this.btnShowHidePassword_Click);
            // 
            // ctrlUserDetails1
            // 
            this.ctrlUserDetails1.Dock = System.Windows.Forms.DockStyle.Top;
            this.ctrlUserDetails1.Location = new System.Drawing.Point(0, 0);
            this.ctrlUserDetails1.Name = "ctrlUserDetails1";
            this.ctrlUserDetails1.Size = new System.Drawing.Size(1178, 479);
            this.ctrlUserDetails1.TabIndex = 0;
            // 
            // frmChangePassword
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(1178, 735);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnShowHideConfirmPassword);
            this.Controls.Add(this.btnShowHideNewPassword);
            this.Controls.Add(this.btnShowHideCurrentPassword);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.txtConfirmPassword);
            this.Controls.Add(this.txtNewPassword);
            this.Controls.Add(this.txtCurrentPassword);
            this.Controls.Add(this.l);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ctrlUserDetails1);
            this.MinimumSize = new System.Drawing.Size(1200, 791);
            this.Name = "frmChangePassword";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Change Password";
            this.Activated += new System.EventHandler(this.frmChangePassword_Activated);
            this.Load += new System.EventHandler(this.frmChangePassword_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ctrlUserDetails ctrlUserDetails1;
        private System.Windows.Forms.TextBox txtConfirmPassword;
        private System.Windows.Forms.TextBox txtNewPassword;
        private System.Windows.Forms.TextBox txtCurrentPassword;
        private System.Windows.Forms.Label l;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnShowHideCurrentPassword;
        private System.Windows.Forms.Button btnShowHideNewPassword;
        private System.Windows.Forms.Button btnShowHideConfirmPassword;
    }
}