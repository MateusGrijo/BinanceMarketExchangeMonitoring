namespace CryptoTrader.Forms
{
    partial class FrmToken
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmToken));
            this.TxtTokenSymbol = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.TxtTokenName = new System.Windows.Forms.TextBox();
            this.TxtTokenID = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.CmdSave = new System.Windows.Forms.Button();
            this.CmdClose = new System.Windows.Forms.Button();
            this.PBar = new System.Windows.Forms.ProgressBar();
            this.MyTimer = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // TxtTokenSymbol
            // 
            this.TxtTokenSymbol.BackColor = System.Drawing.Color.Gainsboro;
            this.TxtTokenSymbol.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TxtTokenSymbol.Font = new System.Drawing.Font("Tahoma", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtTokenSymbol.ForeColor = System.Drawing.Color.Navy;
            this.TxtTokenSymbol.Location = new System.Drawing.Point(123, 70);
            this.TxtTokenSymbol.Margin = new System.Windows.Forms.Padding(8, 3, 3, 3);
            this.TxtTokenSymbol.Name = "TxtTokenSymbol";
            this.TxtTokenSymbol.Size = new System.Drawing.Size(255, 23);
            this.TxtTokenSymbol.TabIndex = 1;
            // 
            // label12
            // 
            this.label12.BackColor = System.Drawing.Color.White;
            this.label12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label12.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.label12.Location = new System.Drawing.Point(11, 65);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(371, 32);
            this.label12.TabIndex = 39;
            this.label12.Text = " Token Symbol ";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TxtTokenName
            // 
            this.TxtTokenName.BackColor = System.Drawing.Color.Gainsboro;
            this.TxtTokenName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TxtTokenName.Font = new System.Drawing.Font("Tahoma", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtTokenName.ForeColor = System.Drawing.Color.Navy;
            this.TxtTokenName.Location = new System.Drawing.Point(124, 111);
            this.TxtTokenName.Margin = new System.Windows.Forms.Padding(8, 3, 3, 3);
            this.TxtTokenName.Name = "TxtTokenName";
            this.TxtTokenName.Size = new System.Drawing.Size(255, 23);
            this.TxtTokenName.TabIndex = 2;
            // 
            // TxtTokenID
            // 
            this.TxtTokenID.BackColor = System.Drawing.Color.Gainsboro;
            this.TxtTokenID.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TxtTokenID.Font = new System.Drawing.Font("Tahoma", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtTokenID.ForeColor = System.Drawing.Color.Navy;
            this.TxtTokenID.Location = new System.Drawing.Point(124, 30);
            this.TxtTokenID.Margin = new System.Windows.Forms.Padding(8, 3, 3, 3);
            this.TxtTokenID.Name = "TxtTokenID";
            this.TxtTokenID.ReadOnly = true;
            this.TxtTokenID.Size = new System.Drawing.Size(255, 23);
            this.TxtTokenID.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.White;
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label5.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.label5.Location = new System.Drawing.Point(11, 106);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(371, 32);
            this.label5.TabIndex = 36;
            this.label5.Text = " Token Name ";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.White;
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label6.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.label6.Location = new System.Drawing.Point(12, 25);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(371, 32);
            this.label6.TabIndex = 35;
            this.label6.Text = " Token ID    ";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(49)))), ((int)(((byte)(57)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.CmdSave);
            this.panel1.Controls.Add(this.CmdClose);
            this.panel1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 165);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(392, 49);
            this.panel1.TabIndex = 3;
            // 
            // CmdSave
            // 
            this.CmdSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(192)))), ((int)(((byte)(49)))));
            this.CmdSave.FlatAppearance.BorderSize = 0;
            this.CmdSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CmdSave.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmdSave.ForeColor = System.Drawing.Color.White;
            this.CmdSave.Location = new System.Drawing.Point(171, 3);
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
            this.CmdClose.Location = new System.Drawing.Point(282, 3);
            this.CmdClose.Name = "CmdClose";
            this.CmdClose.Size = new System.Drawing.Size(105, 42);
            this.CmdClose.TabIndex = 5;
            this.CmdClose.Text = "&CANCEL";
            this.CmdClose.UseVisualStyleBackColor = false;
            this.CmdClose.Click += new System.EventHandler(this.CmdClose_Click);
            // 
            // PBar
            // 
            this.PBar.Location = new System.Drawing.Point(0, 153);
            this.PBar.Maximum = 50;
            this.PBar.Name = "PBar";
            this.PBar.Size = new System.Drawing.Size(391, 15);
            this.PBar.Step = 1;
            this.PBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.PBar.TabIndex = 45;
            // 
            // MyTimer
            // 
            this.MyTimer.Interval = 1;
            this.MyTimer.Tick += new System.EventHandler(this.MyTimer_Tick);
            // 
            // FrmToken
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(392, 214);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.TxtTokenSymbol);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.TxtTokenName);
            this.Controls.Add(this.TxtTokenID);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.PBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(408, 253);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(408, 253);
            this.Name = "FrmToken";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add/Update  Crypto Token";
            this.Load += new System.EventHandler(this.FrmToken_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TxtTokenSymbol;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox TxtTokenName;
        private System.Windows.Forms.TextBox TxtTokenID;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button CmdSave;
        private System.Windows.Forms.Button CmdClose;
        private System.Windows.Forms.ProgressBar PBar;
        private System.Windows.Forms.Timer MyTimer;
    }
}