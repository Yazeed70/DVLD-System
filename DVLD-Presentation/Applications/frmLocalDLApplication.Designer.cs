namespace DVLD_Presentation
{
    partial class frmLocalDrivingLicenseApplication
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLocalDrivingLicenseApplication));
            this.lblMode = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tbPersonalInfo = new System.Windows.Forms.TabPage();
            this.ctrlPersonDetailsWithFilter1 = new DVLD_Presentation.ctrlPersonDetailsWithFilter();
            this.tbApplicationInfo = new System.Windows.Forms.TabPage();
            this.cbLicenseClass = new System.Windows.Forms.ComboBox();
            this.lblApplicationFees = new System.Windows.Forms.Label();
            this.lblCreatedBy = new System.Windows.Forms.Label();
            this.lblApplicationDate = new System.Windows.Forms.Label();
            this.lblLocalDLApplicationID = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.l = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnLeft = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnRight = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tbPersonalInfo.SuspendLayout();
            this.tbApplicationInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblMode
            // 
            this.lblMode.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblMode.Font = new System.Drawing.Font("Algerian", 20F, System.Drawing.FontStyle.Bold);
            this.lblMode.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblMode.Location = new System.Drawing.Point(2, 9);
            this.lblMode.Name = "lblMode";
            this.lblMode.Size = new System.Drawing.Size(1071, 90);
            this.lblMode.TabIndex = 2;
            this.lblMode.Text = "New Local Driving License Application";
            this.lblMode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Appearance = System.Windows.Forms.TabAppearance.Buttons;
            this.tabControl1.Controls.Add(this.tbPersonalInfo);
            this.tabControl1.Controls.Add(this.tbApplicationInfo);
            this.tabControl1.HotTrack = true;
            this.tabControl1.Location = new System.Drawing.Point(10, 102);
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1071, 516);
            this.tabControl1.TabIndex = 6;
            // 
            // tbPersonalInfo
            // 
            this.tbPersonalInfo.Controls.Add(this.ctrlPersonDetailsWithFilter1);
            this.tbPersonalInfo.Location = new System.Drawing.Point(4, 31);
            this.tbPersonalInfo.Name = "tbPersonalInfo";
            this.tbPersonalInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tbPersonalInfo.Size = new System.Drawing.Size(1063, 481);
            this.tbPersonalInfo.TabIndex = 0;
            this.tbPersonalInfo.Text = "Personal Info";
            this.tbPersonalInfo.UseVisualStyleBackColor = true;
            // 
            // ctrlPersonDetailsWithFilter1
            // 
            this.ctrlPersonDetailsWithFilter1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlPersonDetailsWithFilter1.EnableFilter = true;
            this.ctrlPersonDetailsWithFilter1.FilterEnabled = true;
            this.ctrlPersonDetailsWithFilter1.Location = new System.Drawing.Point(3, 3);
            this.ctrlPersonDetailsWithFilter1.Name = "ctrlPersonDetailsWithFilter1";
            this.ctrlPersonDetailsWithFilter1.Size = new System.Drawing.Size(1057, 475);
            this.ctrlPersonDetailsWithFilter1.TabIndex = 0;
            this.ctrlPersonDetailsWithFilter1.OnPersonSelected += new System.Action<int>(this.ctrlPersonDetailsWithFilter1_OnPersonSelected);
            // 
            // tbApplicationInfo
            // 
            this.tbApplicationInfo.Controls.Add(this.cbLicenseClass);
            this.tbApplicationInfo.Controls.Add(this.lblApplicationFees);
            this.tbApplicationInfo.Controls.Add(this.lblCreatedBy);
            this.tbApplicationInfo.Controls.Add(this.lblApplicationDate);
            this.tbApplicationInfo.Controls.Add(this.lblLocalDLApplicationID);
            this.tbApplicationInfo.Controls.Add(this.label4);
            this.tbApplicationInfo.Controls.Add(this.l);
            this.tbApplicationInfo.Controls.Add(this.lblPassword);
            this.tbApplicationInfo.Controls.Add(this.label2);
            this.tbApplicationInfo.Controls.Add(this.label3);
            this.tbApplicationInfo.Location = new System.Drawing.Point(4, 31);
            this.tbApplicationInfo.Name = "tbApplicationInfo";
            this.tbApplicationInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tbApplicationInfo.Size = new System.Drawing.Size(1063, 481);
            this.tbApplicationInfo.TabIndex = 1;
            this.tbApplicationInfo.Text = "Application Info";
            this.tbApplicationInfo.UseVisualStyleBackColor = true;
            // 
            // cbLicenseClass
            // 
            this.cbLicenseClass.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cbLicenseClass.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbLicenseClass.FormattingEnabled = true;
            this.cbLicenseClass.Location = new System.Drawing.Point(329, 164);
            this.cbLicenseClass.Name = "cbLicenseClass";
            this.cbLicenseClass.Size = new System.Drawing.Size(332, 32);
            this.cbLicenseClass.TabIndex = 5;
            // 
            // lblApplicationFees
            // 
            this.lblApplicationFees.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblApplicationFees.AutoSize = true;
            this.lblApplicationFees.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblApplicationFees.Location = new System.Drawing.Point(325, 223);
            this.lblApplicationFees.Name = "lblApplicationFees";
            this.lblApplicationFees.Size = new System.Drawing.Size(62, 24);
            this.lblApplicationFees.TabIndex = 1;
            this.lblApplicationFees.Text = "[????]";
            // 
            // lblCreatedBy
            // 
            this.lblCreatedBy.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblCreatedBy.AutoSize = true;
            this.lblCreatedBy.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCreatedBy.Location = new System.Drawing.Point(325, 278);
            this.lblCreatedBy.Name = "lblCreatedBy";
            this.lblCreatedBy.Size = new System.Drawing.Size(62, 24);
            this.lblCreatedBy.TabIndex = 1;
            this.lblCreatedBy.Text = "[????]";
            // 
            // lblApplicationDate
            // 
            this.lblApplicationDate.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblApplicationDate.AutoSize = true;
            this.lblApplicationDate.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblApplicationDate.Location = new System.Drawing.Point(325, 113);
            this.lblApplicationDate.Name = "lblApplicationDate";
            this.lblApplicationDate.Size = new System.Drawing.Size(62, 24);
            this.lblApplicationDate.TabIndex = 1;
            this.lblApplicationDate.Text = "[????]";
            // 
            // lblLocalDLApplicationID
            // 
            this.lblLocalDLApplicationID.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblLocalDLApplicationID.AutoSize = true;
            this.lblLocalDLApplicationID.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLocalDLApplicationID.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblLocalDLApplicationID.Location = new System.Drawing.Point(325, 58);
            this.lblLocalDLApplicationID.Name = "lblLocalDLApplicationID";
            this.lblLocalDLApplicationID.Size = new System.Drawing.Size(62, 24);
            this.lblLocalDLApplicationID.TabIndex = 1;
            this.lblLocalDLApplicationID.Text = "[????]";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(201, 278);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(115, 24);
            this.label4.TabIndex = 1;
            this.label4.Text = "Created By:";
            // 
            // l
            // 
            this.l.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.l.AutoSize = true;
            this.l.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l.Location = new System.Drawing.Point(154, 223);
            this.l.Name = "l";
            this.l.Size = new System.Drawing.Size(162, 24);
            this.l.TabIndex = 1;
            this.l.Text = "Application Fees:";
            // 
            // lblPassword
            // 
            this.lblPassword.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblPassword.AutoSize = true;
            this.lblPassword.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPassword.Location = new System.Drawing.Point(192, 168);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(124, 24);
            this.lblPassword.TabIndex = 1;
            this.lblPassword.Text = "License Clss:";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(152, 113);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(164, 24);
            this.label2.TabIndex = 1;
            this.label2.Text = "Application Date:";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(126, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(190, 24);
            this.label3.TabIndex = 0;
            this.label3.Text = "D. L. Application ID:";
            // 
            // btnLeft
            // 
            this.btnLeft.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnLeft.BackColor = System.Drawing.SystemColors.Control;
            this.btnLeft.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLeft.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnLeft.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLeft.Image = ((System.Drawing.Image)(resources.GetObject("btnLeft.Image")));
            this.btnLeft.Location = new System.Drawing.Point(315, 632);
            this.btnLeft.Name = "btnLeft";
            this.btnLeft.Size = new System.Drawing.Size(106, 60);
            this.btnLeft.TabIndex = 12;
            this.btnLeft.UseVisualStyleBackColor = false;
            this.btnLeft.Click += new System.EventHandler(this.btnLeft_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.Enabled = false;
            this.btnSave.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.btnSave.FlatAppearance.BorderSize = 2;
            this.btnSave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Algerian", 14F, System.Drawing.FontStyle.Bold);
            this.btnSave.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.btnSave.Image = global::DVLD_Presentation.Properties.Resources.Save_32;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(849, 632);
            this.btnSave.MinimumSize = new System.Drawing.Size(214, 65);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(214, 65);
            this.btnSave.TabIndex = 13;
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
            this.btnClose.Location = new System.Drawing.Point(617, 632);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(214, 65);
            this.btnClose.TabIndex = 14;
            this.btnClose.Text = "Close";
            this.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnRight
            // 
            this.btnRight.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnRight.BackColor = System.Drawing.SystemColors.Control;
            this.btnRight.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRight.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnRight.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRight.Image = ((System.Drawing.Image)(resources.GetObject("btnRight.Image")));
            this.btnRight.Location = new System.Drawing.Point(427, 632);
            this.btnRight.Name = "btnRight";
            this.btnRight.Size = new System.Drawing.Size(106, 60);
            this.btnRight.TabIndex = 11;
            this.btnRight.UseVisualStyleBackColor = false;
            this.btnRight.Click += new System.EventHandler(this.btnRight_Click);
            // 
            // frmLocalDrivingLicenseApplication
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(1085, 768);
            this.Controls.Add(this.btnLeft);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnRight);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.lblMode);
            this.MinimumSize = new System.Drawing.Size(1107, 824);
            this.Name = "frmLocalDrivingLicenseApplication";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Local Driving License Application";
            this.Activated += new System.EventHandler(this.frmLocalDrivingLicenseApplication_Activated);
            this.Load += new System.EventHandler(this.frmLocalD_Load);
            this.tabControl1.ResumeLayout(false);
            this.tbPersonalInfo.ResumeLayout(false);
            this.tbApplicationInfo.ResumeLayout(false);
            this.tbApplicationInfo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblMode;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tbPersonalInfo;
        private System.Windows.Forms.TabPage tbApplicationInfo;
        private System.Windows.Forms.Label lblLocalDLApplicationID;
        private System.Windows.Forms.Label l;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbLicenseClass;
        private System.Windows.Forms.Label lblApplicationFees;
        private System.Windows.Forms.Label lblCreatedBy;
        private System.Windows.Forms.Label lblApplicationDate;
        private ctrlPersonDetailsWithFilter ctrlPersonDetailsWithFilter1;
        private System.Windows.Forms.Button btnLeft;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnRight;
    }
}