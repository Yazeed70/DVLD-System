namespace DVLD_Presentation
{
    partial class frmLicenseHistory
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tpLocal = new System.Windows.Forms.TabPage();
            this.panel8 = new System.Windows.Forms.Panel();
            this.dgvLocalHistory = new System.Windows.Forms.DataGridView();
            this.CMSLocalDL = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.TSMShowLocalLicenseInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.tpInternational = new System.Windows.Forms.TabPage();
            this.panel7 = new System.Windows.Forms.Panel();
            this.dgvInternationalHistory = new System.Windows.Forms.DataGridView();
            this.CMSInternationalDL = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.TSMShowInternationalLicenseInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.lblRecords = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.ctrlPersonDetailsWithFilter1 = new DVLD_Presentation.ctrlPersonDetailsWithFilter();
            this.groupBox1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tpLocal.SuspendLayout();
            this.panel8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLocalHistory)).BeginInit();
            this.CMSLocalDL.SuspendLayout();
            this.tpInternational.SuspendLayout();
            this.panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInternationalHistory)).BeginInit();
            this.CMSInternationalDL.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label1.Location = new System.Drawing.Point(10, -8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1387, 100);
            this.label1.TabIndex = 1;
            this.label1.Text = "Licenses History";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tabControl1);
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 10F);
            this.groupBox1.Location = new System.Drawing.Point(12, 564);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1385, 307);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Driver Licenses";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tpLocal);
            this.tabControl1.Controls.Add(this.tpInternational);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.HotTrack = true;
            this.tabControl1.Location = new System.Drawing.Point(3, 28);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1379, 276);
            this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl1.TabIndex = 0;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tpLocal
            // 
            this.tpLocal.Controls.Add(this.panel8);
            this.tpLocal.Location = new System.Drawing.Point(4, 33);
            this.tpLocal.Name = "tpLocal";
            this.tpLocal.Padding = new System.Windows.Forms.Padding(3);
            this.tpLocal.Size = new System.Drawing.Size(1371, 239);
            this.tpLocal.TabIndex = 0;
            this.tpLocal.Text = "Local";
            this.tpLocal.UseVisualStyleBackColor = true;
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.dgvLocalHistory);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel8.Location = new System.Drawing.Point(3, 3);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(1365, 233);
            this.panel8.TabIndex = 4;
            // 
            // dgvLocalHistory
            // 
            this.dgvLocalHistory.AllowUserToAddRows = false;
            this.dgvLocalHistory.AllowUserToDeleteRows = false;
            this.dgvLocalHistory.AllowUserToOrderColumns = true;
            this.dgvLocalHistory.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvLocalHistory.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvLocalHistory.BackgroundColor = System.Drawing.Color.White;
            this.dgvLocalHistory.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 10F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvLocalHistory.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvLocalHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLocalHistory.ContextMenuStrip = this.CMSLocalDL;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 10F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvLocalHistory.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvLocalHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvLocalHistory.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.dgvLocalHistory.Location = new System.Drawing.Point(0, 0);
            this.dgvLocalHistory.Name = "dgvLocalHistory";
            this.dgvLocalHistory.ReadOnly = true;
            this.dgvLocalHistory.RowHeadersWidth = 62;
            this.dgvLocalHistory.RowTemplate.Height = 29;
            this.dgvLocalHistory.Size = new System.Drawing.Size(1365, 233);
            this.dgvLocalHistory.TabIndex = 3;
            // 
            // CMSLocalDL
            // 
            this.CMSLocalDL.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CMSLocalDL.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.CMSLocalDL.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TSMShowLocalLicenseInfo});
            this.CMSLocalDL.Name = "CMSLocalDL";
            this.CMSLocalDL.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.CMSLocalDL.ShowCheckMargin = true;
            this.CMSLocalDL.ShowImageMargin = false;
            this.CMSLocalDL.Size = new System.Drawing.Size(239, 38);
            // 
            // TSMShowLocalLicenseInfo
            // 
            this.TSMShowLocalLicenseInfo.Name = "TSMShowLocalLicenseInfo";
            this.TSMShowLocalLicenseInfo.Size = new System.Drawing.Size(238, 34);
            this.TSMShowLocalLicenseInfo.Text = "Show License Info";
            this.TSMShowLocalLicenseInfo.Click += new System.EventHandler(this.TSMShowLocalLicenseInfo_Click);
            // 
            // tpInternational
            // 
            this.tpInternational.Controls.Add(this.panel7);
            this.tpInternational.Location = new System.Drawing.Point(4, 28);
            this.tpInternational.Name = "tpInternational";
            this.tpInternational.Padding = new System.Windows.Forms.Padding(3);
            this.tpInternational.Size = new System.Drawing.Size(1371, 249);
            this.tpInternational.TabIndex = 1;
            this.tpInternational.Text = "Internaional";
            this.tpInternational.UseVisualStyleBackColor = true;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.dgvInternationalHistory);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel7.Location = new System.Drawing.Point(3, 3);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(1365, 243);
            this.panel7.TabIndex = 1;
            // 
            // dgvInternationalHistory
            // 
            this.dgvInternationalHistory.AllowUserToAddRows = false;
            this.dgvInternationalHistory.AllowUserToDeleteRows = false;
            this.dgvInternationalHistory.AllowUserToOrderColumns = true;
            this.dgvInternationalHistory.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvInternationalHistory.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvInternationalHistory.BackgroundColor = System.Drawing.Color.White;
            this.dgvInternationalHistory.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Tahoma", 10F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvInternationalHistory.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvInternationalHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInternationalHistory.ContextMenuStrip = this.CMSInternationalDL;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Tahoma", 10F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvInternationalHistory.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvInternationalHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvInternationalHistory.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.dgvInternationalHistory.Location = new System.Drawing.Point(0, 0);
            this.dgvInternationalHistory.Name = "dgvInternationalHistory";
            this.dgvInternationalHistory.ReadOnly = true;
            this.dgvInternationalHistory.RowHeadersWidth = 62;
            this.dgvInternationalHistory.RowTemplate.Height = 29;
            this.dgvInternationalHistory.Size = new System.Drawing.Size(1365, 243);
            this.dgvInternationalHistory.TabIndex = 3;
            // 
            // CMSInternationalDL
            // 
            this.CMSInternationalDL.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.CMSInternationalDL.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TSMShowInternationalLicenseInfo});
            this.CMSInternationalDL.Name = "CMSLocalDL";
            this.CMSInternationalDL.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.CMSInternationalDL.ShowCheckMargin = true;
            this.CMSInternationalDL.ShowImageMargin = false;
            this.CMSInternationalDL.Size = new System.Drawing.Size(227, 36);
            // 
            // TSMShowInternationalLicenseInfo
            // 
            this.TSMShowInternationalLicenseInfo.Name = "TSMShowInternationalLicenseInfo";
            this.TSMShowInternationalLicenseInfo.Size = new System.Drawing.Size(226, 32);
            this.TSMShowInternationalLicenseInfo.Text = "Show License Info";
            this.TSMShowInternationalLicenseInfo.Click += new System.EventHandler(this.TSMShowInternationalLicenseInfo_Click);
            // 
            // lblRecords
            // 
            this.lblRecords.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblRecords.AutoSize = true;
            this.lblRecords.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lblRecords.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblRecords.Location = new System.Drawing.Point(156, 906);
            this.lblRecords.Name = "lblRecords";
            this.lblRecords.Size = new System.Drawing.Size(110, 24);
            this.lblRecords.TabIndex = 21;
            this.lblRecords.Text = "No Records";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 10F);
            this.label4.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label4.Location = new System.Drawing.Point(50, 906);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(108, 24);
            this.label4.TabIndex = 22;
            this.label4.Text = "# Records:";
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
            this.btnClose.Location = new System.Drawing.Point(1183, 877);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(214, 65);
            this.btnClose.TabIndex = 23;
            this.btnClose.Text = "Close";
            this.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnClose.UseVisualStyleBackColor = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DVLD_Presentation.Properties.Resources.LicensesHistory;
            this.pictureBox1.Location = new System.Drawing.Point(10, 201);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(358, 282);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // ctrlPersonDetailsWithFilter1
            // 
            this.ctrlPersonDetailsWithFilter1.EnableFilter = true;
            this.ctrlPersonDetailsWithFilter1.FilterEnabled = true;
            this.ctrlPersonDetailsWithFilter1.Location = new System.Drawing.Point(374, 95);
            this.ctrlPersonDetailsWithFilter1.Name = "ctrlPersonDetailsWithFilter1";
            this.ctrlPersonDetailsWithFilter1.Size = new System.Drawing.Size(1023, 463);
            this.ctrlPersonDetailsWithFilter1.TabIndex = 2;
            // 
            // frmLicenseHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(1422, 950);
            this.Controls.Add(this.ctrlPersonDetailsWithFilter1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblRecords);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmLicenseHistory";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Licenses History";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmLicenseHistory_Load);
            this.groupBox1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tpLocal.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLocalHistory)).EndInit();
            this.CMSLocalDL.ResumeLayout(false);
            this.tpInternational.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvInternationalHistory)).EndInit();
            this.CMSInternationalDL.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private ctrlPersonDetailsWithFilter ctrlPersonDetailsWithFilter1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tpLocal;
        private System.Windows.Forms.TabPage tpInternational;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.DataGridView dgvLocalHistory;
        private System.Windows.Forms.DataGridView dgvInternationalHistory;
        private System.Windows.Forms.ContextMenuStrip CMSLocalDL;
        private System.Windows.Forms.ToolStripMenuItem TSMShowLocalLicenseInfo;
        private System.Windows.Forms.ContextMenuStrip CMSInternationalDL;
        private System.Windows.Forms.ToolStripMenuItem TSMShowInternationalLicenseInfo;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblRecords;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnClose;
    }
}