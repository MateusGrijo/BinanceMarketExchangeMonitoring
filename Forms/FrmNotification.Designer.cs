namespace CryptoTrader
{
    partial class FrmNotification
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmNotification));
            this.Grid_Notify = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn19 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn21 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CurrentPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NotifyID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.CmdSave = new System.Windows.Forms.Button();
            this.CmdClose = new System.Windows.Forms.Button();
            this.ChkPlaySound = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.Grid_Notify)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Grid_Notify
            // 
            this.Grid_Notify.AllowUserToAddRows = false;
            this.Grid_Notify.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Azure;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Grid_Notify.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.Grid_Notify.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(49)))), ((int)(((byte)(57)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Grid_Notify.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.Grid_Notify.ColumnHeadersHeight = 28;
            this.Grid_Notify.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn19,
            this.dataGridViewTextBoxColumn21,
            this.Price,
            this.CurrentPrice,
            this.NotifyID});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.Grid_Notify.DefaultCellStyle = dataGridViewCellStyle5;
            this.Grid_Notify.EnableHeadersVisualStyles = false;
            this.Grid_Notify.Location = new System.Drawing.Point(10, 11);
            this.Grid_Notify.MultiSelect = false;
            this.Grid_Notify.Name = "Grid_Notify";
            this.Grid_Notify.RowHeadersVisible = false;
            this.Grid_Notify.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Grid_Notify.Size = new System.Drawing.Size(717, 258);
            this.Grid_Notify.TabIndex = 0;
            // 
            // dataGridViewTextBoxColumn19
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.dataGridViewTextBoxColumn19.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewTextBoxColumn19.Frozen = true;
            this.dataGridViewTextBoxColumn19.HeaderText = "No.";
            this.dataGridViewTextBoxColumn19.Name = "dataGridViewTextBoxColumn19";
            this.dataGridViewTextBoxColumn19.ReadOnly = true;
            this.dataGridViewTextBoxColumn19.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn19.Width = 40;
            // 
            // dataGridViewTextBoxColumn21
            // 
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridViewTextBoxColumn21.DefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewTextBoxColumn21.Frozen = true;
            this.dataGridViewTextBoxColumn21.HeaderText = "Time";
            this.dataGridViewTextBoxColumn21.MinimumWidth = 150;
            this.dataGridViewTextBoxColumn21.Name = "dataGridViewTextBoxColumn21";
            this.dataGridViewTextBoxColumn21.ReadOnly = true;
            this.dataGridViewTextBoxColumn21.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn21.Width = 150;
            // 
            // Price
            // 
            this.Price.HeaderText = "Price";
            this.Price.MinimumWidth = 105;
            this.Price.Name = "Price";
            this.Price.ReadOnly = true;
            this.Price.Width = 105;
            // 
            // CurrentPrice
            // 
            this.CurrentPrice.HeaderText = "Message";
            this.CurrentPrice.MinimumWidth = 400;
            this.CurrentPrice.Name = "CurrentPrice";
            this.CurrentPrice.ReadOnly = true;
            this.CurrentPrice.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.CurrentPrice.Width = 400;
            // 
            // NotifyID
            // 
            this.NotifyID.HeaderText = "NotifyID";
            this.NotifyID.MinimumWidth = 2;
            this.NotifyID.Name = "NotifyID";
            this.NotifyID.ReadOnly = true;
            this.NotifyID.Visible = false;
            this.NotifyID.Width = 2;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(49)))), ((int)(((byte)(57)))));
            this.panel1.Controls.Add(this.CmdSave);
            this.panel1.Controls.Add(this.CmdClose);
            this.panel1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 293);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(738, 51);
            this.panel1.TabIndex = 1;
            // 
            // CmdSave
            // 
            this.CmdSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(192)))), ((int)(((byte)(49)))));
            this.CmdSave.FlatAppearance.BorderSize = 0;
            this.CmdSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CmdSave.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmdSave.ForeColor = System.Drawing.Color.White;
            this.CmdSave.Location = new System.Drawing.Point(496, 5);
            this.CmdSave.Name = "CmdSave";
            this.CmdSave.Size = new System.Drawing.Size(121, 42);
            this.CmdSave.TabIndex = 1;
            this.CmdSave.Text = "&MINIMIZE";
            this.CmdSave.UseVisualStyleBackColor = false;
            this.CmdSave.Click += new System.EventHandler(this.CmdSave_Click);
            // 
            // CmdClose
            // 
            this.CmdClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(192)))), ((int)(((byte)(49)))));
            this.CmdClose.FlatAppearance.BorderSize = 0;
            this.CmdClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CmdClose.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmdClose.ForeColor = System.Drawing.Color.White;
            this.CmdClose.Location = new System.Drawing.Point(622, 5);
            this.CmdClose.Name = "CmdClose";
            this.CmdClose.Size = new System.Drawing.Size(105, 42);
            this.CmdClose.TabIndex = 2;
            this.CmdClose.Text = "&CLOSE";
            this.CmdClose.UseVisualStyleBackColor = false;
            this.CmdClose.Click += new System.EventHandler(this.CmdClose_Click);
            // 
            // ChkPlaySound
            // 
            this.ChkPlaySound.AutoSize = true;
            this.ChkPlaySound.Checked = true;
            this.ChkPlaySound.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ChkPlaySound.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChkPlaySound.Location = new System.Drawing.Point(10, 272);
            this.ChkPlaySound.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ChkPlaySound.Name = "ChkPlaySound";
            this.ChkPlaySound.Size = new System.Drawing.Size(134, 18);
            this.ChkPlaySound.TabIndex = 33;
            this.ChkPlaySound.Text = "Play Alarm Sound";
            this.ChkPlaySound.UseVisualStyleBackColor = true;
            this.ChkPlaySound.CheckedChanged += new System.EventHandler(this.ChkPlaySound_CheckedChanged);
            // 
            // FrmNotification
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(738, 344);
            this.Controls.Add(this.ChkPlaySound);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.Grid_Notify);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(754, 383);
            this.MinimumSize = new System.Drawing.Size(754, 383);
            this.Name = "FrmNotification";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Crypto Price Notification";
            this.Load += new System.EventHandler(this.FrmNotification_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Grid_Notify)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView Grid_Notify;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button CmdClose;
        private System.Windows.Forms.CheckBox ChkPlaySound;
        private System.Windows.Forms.Button CmdSave;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn19;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn21;
        private System.Windows.Forms.DataGridViewTextBoxColumn Price;
        private System.Windows.Forms.DataGridViewTextBoxColumn CurrentPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn NotifyID;
    }
}