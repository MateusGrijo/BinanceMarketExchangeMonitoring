namespace CryptoTrader
{
    partial class FrmTransaction
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmTransaction));
            this.panel1 = new System.Windows.Forms.Panel();
            this.CmdSave = new System.Windows.Forms.Button();
            this.CmdClose = new System.Windows.Forms.Button();
            this.TxtBuyPrice = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.TxtSellPrice = new System.Windows.Forms.TextBox();
            this.TxtCapital = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.PBar = new System.Windows.Forms.ProgressBar();
            this.MyTimer = new System.Windows.Forms.Timer(this.components);
            this.CmbToken = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.TxtTransactionFee = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.CmbStatus = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TxtTransactionID = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(49)))), ((int)(((byte)(57)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.CmdSave);
            this.panel1.Controls.Add(this.CmdClose);
            this.panel1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 301);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(424, 49);
            this.panel1.TabIndex = 7;
            // 
            // CmdSave
            // 
            this.CmdSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(192)))), ((int)(((byte)(49)))));
            this.CmdSave.FlatAppearance.BorderSize = 0;
            this.CmdSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CmdSave.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmdSave.ForeColor = System.Drawing.Color.White;
            this.CmdSave.Location = new System.Drawing.Point(202, 2);
            this.CmdSave.Name = "CmdSave";
            this.CmdSave.Size = new System.Drawing.Size(105, 42);
            this.CmdSave.TabIndex = 7;
            this.CmdSave.Text = "&SAVE";
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
            this.CmdClose.Location = new System.Drawing.Point(313, 2);
            this.CmdClose.Name = "CmdClose";
            this.CmdClose.Size = new System.Drawing.Size(105, 42);
            this.CmdClose.TabIndex = 9;
            this.CmdClose.Text = "&CANCEL";
            this.CmdClose.UseVisualStyleBackColor = false;
            this.CmdClose.Click += new System.EventHandler(this.CmdClose_Click);
            // 
            // TxtBuyPrice
            // 
            this.TxtBuyPrice.BackColor = System.Drawing.Color.Gainsboro;
            this.TxtBuyPrice.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TxtBuyPrice.Font = new System.Drawing.Font("Tahoma", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtBuyPrice.ForeColor = System.Drawing.Color.Green;
            this.TxtBuyPrice.Location = new System.Drawing.Point(152, 138);
            this.TxtBuyPrice.Margin = new System.Windows.Forms.Padding(8, 3, 3, 3);
            this.TxtBuyPrice.Name = "TxtBuyPrice";
            this.TxtBuyPrice.Size = new System.Drawing.Size(255, 23);
            this.TxtBuyPrice.TabIndex = 3;
            // 
            // label12
            // 
            this.label12.BackColor = System.Drawing.Color.White;
            this.label12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label12.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.label12.Location = new System.Drawing.Point(15, 134);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(397, 32);
            this.label12.TabIndex = 52;
            this.label12.Text = " BUY - Price";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TxtSellPrice
            // 
            this.TxtSellPrice.BackColor = System.Drawing.Color.Gainsboro;
            this.TxtSellPrice.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TxtSellPrice.Font = new System.Drawing.Font("Tahoma", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtSellPrice.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.TxtSellPrice.Location = new System.Drawing.Point(152, 180);
            this.TxtSellPrice.Margin = new System.Windows.Forms.Padding(8, 3, 3, 3);
            this.TxtSellPrice.Name = "TxtSellPrice";
            this.TxtSellPrice.Size = new System.Drawing.Size(255, 23);
            this.TxtSellPrice.TabIndex = 4;
            // 
            // TxtCapital
            // 
            this.TxtCapital.BackColor = System.Drawing.Color.Gainsboro;
            this.TxtCapital.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TxtCapital.Font = new System.Drawing.Font("Tahoma", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtCapital.ForeColor = System.Drawing.Color.Navy;
            this.TxtCapital.Location = new System.Drawing.Point(152, 99);
            this.TxtCapital.Margin = new System.Windows.Forms.Padding(8, 3, 3, 3);
            this.TxtCapital.Name = "TxtCapital";
            this.TxtCapital.Size = new System.Drawing.Size(255, 23);
            this.TxtCapital.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.White;
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label5.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.label5.Location = new System.Drawing.Point(15, 176);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(397, 32);
            this.label5.TabIndex = 51;
            this.label5.Text = " SELL - Price";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.White;
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label6.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.label6.Location = new System.Drawing.Point(14, 94);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(398, 32);
            this.label6.TabIndex = 50;
            this.label6.Text = " Capital (USDT)";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // PBar
            // 
            this.PBar.Location = new System.Drawing.Point(0, 297);
            this.PBar.Maximum = 50;
            this.PBar.Name = "PBar";
            this.PBar.Size = new System.Drawing.Size(424, 18);
            this.PBar.Step = 1;
            this.PBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.PBar.TabIndex = 53;
            // 
            // MyTimer
            // 
            this.MyTimer.Interval = 1;
            this.MyTimer.Tick += new System.EventHandler(this.MyTimer_Tick);
            // 
            // CmbToken
            // 
            this.CmbToken.BackColor = System.Drawing.Color.Gainsboro;
            this.CmbToken.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CmbToken.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbToken.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbToken.ForeColor = System.Drawing.Color.Navy;
            this.CmbToken.FormattingEnabled = true;
            this.CmbToken.Location = new System.Drawing.Point(152, 58);
            this.CmbToken.Margin = new System.Windows.Forms.Padding(8, 3, 3, 3);
            this.CmbToken.Name = "CmbToken";
            this.CmbToken.Size = new System.Drawing.Size(255, 25);
            this.CmbToken.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(14, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(399, 32);
            this.label1.TabIndex = 55;
            this.label1.Text = " Token Name";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TxtTransactionFee
            // 
            this.TxtTransactionFee.BackColor = System.Drawing.Color.Gainsboro;
            this.TxtTransactionFee.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TxtTransactionFee.Font = new System.Drawing.Font("Tahoma", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtTransactionFee.ForeColor = System.Drawing.Color.Navy;
            this.TxtTransactionFee.Location = new System.Drawing.Point(152, 220);
            this.TxtTransactionFee.Margin = new System.Windows.Forms.Padding(8, 3, 3, 3);
            this.TxtTransactionFee.Name = "TxtTransactionFee";
            this.TxtTransactionFee.Size = new System.Drawing.Size(255, 23);
            this.TxtTransactionFee.TabIndex = 5;
            this.TxtTransactionFee.Text = "0.075";
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.label2.Location = new System.Drawing.Point(15, 216);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(396, 32);
            this.label2.TabIndex = 57;
            this.label2.Text = " Transaction Fee";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // CmbStatus
            // 
            this.CmbStatus.BackColor = System.Drawing.Color.Gainsboro;
            this.CmbStatus.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbStatus.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbStatus.ForeColor = System.Drawing.Color.Navy;
            this.CmbStatus.FormattingEnabled = true;
            this.CmbStatus.Items.AddRange(new object[] {
            "",
            "BUY",
            "SELL"});
            this.CmbStatus.Location = new System.Drawing.Point(152, 260);
            this.CmbStatus.Margin = new System.Windows.Forms.Padding(8, 3, 3, 3);
            this.CmbStatus.Name = "CmbStatus";
            this.CmbStatus.Size = new System.Drawing.Size(255, 25);
            this.CmbStatus.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.label3.Location = new System.Drawing.Point(16, 257);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(396, 32);
            this.label3.TabIndex = 59;
            this.label3.Text = " Status";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TxtTransactionID
            // 
            this.TxtTransactionID.BackColor = System.Drawing.Color.Gainsboro;
            this.TxtTransactionID.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TxtTransactionID.Font = new System.Drawing.Font("Tahoma", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtTransactionID.ForeColor = System.Drawing.Color.Navy;
            this.TxtTransactionID.Location = new System.Drawing.Point(152, 21);
            this.TxtTransactionID.Margin = new System.Windows.Forms.Padding(8, 3, 3, 3);
            this.TxtTransactionID.Name = "TxtTransactionID";
            this.TxtTransactionID.ReadOnly = true;
            this.TxtTransactionID.Size = new System.Drawing.Size(255, 23);
            this.TxtTransactionID.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.White;
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label4.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.label4.Location = new System.Drawing.Point(14, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(398, 32);
            this.label4.TabIndex = 61;
            this.label4.Text = " Transaction ID";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FrmTransaction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(424, 350);
            this.Controls.Add(this.TxtTransactionID);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.CmbStatus);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.TxtTransactionFee);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.CmbToken);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.TxtBuyPrice);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.TxtSellPrice);
            this.Controls.Add(this.TxtCapital);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.PBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmTransaction";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " Trading Transaction";
            this.Load += new System.EventHandler(this.FrmTransaction_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button CmdSave;
        private System.Windows.Forms.Button CmdClose;
        private System.Windows.Forms.TextBox TxtBuyPrice;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox TxtSellPrice;
        private System.Windows.Forms.TextBox TxtCapital;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ProgressBar PBar;
        private System.Windows.Forms.Timer MyTimer;
        public System.Windows.Forms.ComboBox CmbToken;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TxtTransactionFee;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.ComboBox CmbStatus;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TxtTransactionID;
        private System.Windows.Forms.Label label4;
    }
}