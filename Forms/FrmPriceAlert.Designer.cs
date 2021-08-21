namespace CryptoTrader.Forms
{
    partial class FrmPriceNotify
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPriceNotify));
            this.panel1 = new System.Windows.Forms.Panel();
            this.CmdSave = new System.Windows.Forms.Button();
            this.CmdClose = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.TxtTokenPrice = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.PBar = new System.Windows.Forms.ProgressBar();
            this.MyTimer = new System.Windows.Forms.Timer(this.components);
            this.CmbToken = new System.Windows.Forms.ComboBox();
            this.CmbOperator = new System.Windows.Forms.ComboBox();
            this.Init_Timer = new System.Windows.Forms.Timer(this.components);
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
            this.panel1.Location = new System.Drawing.Point(0, 156);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(393, 49);
            this.panel1.TabIndex = 3;
            // 
            // CmdSave
            // 
            this.CmdSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(192)))), ((int)(((byte)(49)))));
            this.CmdSave.FlatAppearance.BorderSize = 0;
            this.CmdSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CmdSave.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmdSave.ForeColor = System.Drawing.Color.White;
            this.CmdSave.Location = new System.Drawing.Point(171, 2);
            this.CmdSave.Name = "CmdSave";
            this.CmdSave.Size = new System.Drawing.Size(105, 42);
            this.CmdSave.TabIndex = 3;
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
            this.CmdClose.Location = new System.Drawing.Point(282, 2);
            this.CmdClose.Name = "CmdClose";
            this.CmdClose.Size = new System.Drawing.Size(105, 42);
            this.CmdClose.TabIndex = 5;
            this.CmdClose.Text = "&CANCEL";
            this.CmdClose.UseVisualStyleBackColor = false;
            this.CmdClose.Click += new System.EventHandler(this.CmdClose_Click);
            // 
            // label12
            // 
            this.label12.BackColor = System.Drawing.Color.White;
            this.label12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label12.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.label12.Location = new System.Drawing.Point(11, 53);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(371, 32);
            this.label12.TabIndex = 52;
            this.label12.Text = " Operator";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TxtTokenPrice
            // 
            this.TxtTokenPrice.BackColor = System.Drawing.Color.Gainsboro;
            this.TxtTokenPrice.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TxtTokenPrice.Font = new System.Drawing.Font("Tahoma", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtTokenPrice.ForeColor = System.Drawing.Color.Navy;
            this.TxtTokenPrice.Location = new System.Drawing.Point(115, 98);
            this.TxtTokenPrice.Margin = new System.Windows.Forms.Padding(8, 3, 3, 3);
            this.TxtTokenPrice.Name = "TxtTokenPrice";
            this.TxtTokenPrice.Size = new System.Drawing.Size(263, 23);
            this.TxtTokenPrice.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.White;
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label5.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.label5.Location = new System.Drawing.Point(11, 94);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(371, 32);
            this.label5.TabIndex = 51;
            this.label5.Text = " Alert Price";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.White;
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label6.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.label6.Location = new System.Drawing.Point(12, 13);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(371, 32);
            this.label6.TabIndex = 50;
            this.label6.Text = " Token Name";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.label3.Location = new System.Drawing.Point(112, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(11, 20);
            this.label3.TabIndex = 55;
            this.label3.Text = ":";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.label2.Location = new System.Drawing.Point(112, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(11, 20);
            this.label2.TabIndex = 54;
            this.label2.Text = ":";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(112, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(11, 20);
            this.label1.TabIndex = 53;
            this.label1.Text = ":";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // PBar
            // 
            this.PBar.Location = new System.Drawing.Point(0, 141);
            this.PBar.Maximum = 50;
            this.PBar.Name = "PBar";
            this.PBar.Size = new System.Drawing.Size(391, 15);
            this.PBar.Step = 1;
            this.PBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.PBar.TabIndex = 56;
            this.PBar.Click += new System.EventHandler(this.PBar_Click);
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
            this.CmbToken.Location = new System.Drawing.Point(115, 16);
            this.CmbToken.Margin = new System.Windows.Forms.Padding(8, 3, 3, 3);
            this.CmbToken.Name = "CmbToken";
            this.CmbToken.Size = new System.Drawing.Size(265, 25);
            this.CmbToken.TabIndex = 0;
            this.CmbToken.SelectedIndexChanged += new System.EventHandler(this.CmbToken_SelectedIndexChanged);
            // 
            // CmbOperator
            // 
            this.CmbOperator.BackColor = System.Drawing.Color.Gainsboro;
            this.CmbOperator.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CmbOperator.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbOperator.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbOperator.ForeColor = System.Drawing.Color.Navy;
            this.CmbOperator.FormattingEnabled = true;
            this.CmbOperator.Items.AddRange(new object[] {
            "==   Equal  ",
            ">=   Greater-than",
            "<=   Less-than"});
            this.CmbOperator.Location = new System.Drawing.Point(115, 56);
            this.CmbOperator.Margin = new System.Windows.Forms.Padding(8, 3, 3, 3);
            this.CmbOperator.Name = "CmbOperator";
            this.CmbOperator.Size = new System.Drawing.Size(265, 25);
            this.CmbOperator.TabIndex = 1;
            // 
            // Init_Timer
            // 
            this.Init_Timer.Interval = 10;
            this.Init_Timer.Tick += new System.EventHandler(this.Init_Timer_Tick);
            // 
            // FrmPriceNotify
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(393, 205);
            this.Controls.Add(this.CmbOperator);
            this.Controls.Add(this.CmbToken);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.TxtTokenPrice);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.PBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(409, 244);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(409, 244);
            this.Name = "FrmPriceNotify";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " Token Alert Price ";
            this.Load += new System.EventHandler(this.FrmPriceAlert_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button CmdSave;
        private System.Windows.Forms.Button CmdClose;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox TxtTokenPrice;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ProgressBar PBar;
        private System.Windows.Forms.Timer MyTimer;
        public System.Windows.Forms.ComboBox CmbToken;
        public System.Windows.Forms.ComboBox CmbOperator;
        private System.Windows.Forms.Timer Init_Timer;
    }
}