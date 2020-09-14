namespace TCPServerForms
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.bConnect = new System.Windows.Forms.Button();
            this.tbAddress = new System.Windows.Forms.TextBox();
            this.tbPort = new System.Windows.Forms.TextBox();
            this.tbMain = new System.Windows.Forms.TextBox();
            this.tbSend = new System.Windows.Forms.TextBox();
            this.bSend = new System.Windows.Forms.Button();
            this.cbMode = new System.Windows.Forms.ComboBox();
            this.cbEchoSelf = new System.Windows.Forms.CheckBox();
            this.cbClearSend = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // bConnect
            // 
            this.bConnect.Location = new System.Drawing.Point(359, 11);
            this.bConnect.Name = "bConnect";
            this.bConnect.Size = new System.Drawing.Size(75, 28);
            this.bConnect.TabIndex = 0;
            this.bConnect.Text = "Connect";
            this.bConnect.UseVisualStyleBackColor = true;
            this.bConnect.Click += new System.EventHandler(this.bConnect_Click);
            // 
            // tbAddress
            // 
            this.tbAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbAddress.Location = new System.Drawing.Point(12, 12);
            this.tbAddress.Name = "tbAddress";
            this.tbAddress.Size = new System.Drawing.Size(243, 24);
            this.tbAddress.TabIndex = 1;
            this.tbAddress.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbAddress_KeyDown);
            // 
            // tbPort
            // 
            this.tbPort.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbPort.Location = new System.Drawing.Point(261, 12);
            this.tbPort.Name = "tbPort";
            this.tbPort.Size = new System.Drawing.Size(92, 24);
            this.tbPort.TabIndex = 2;
            this.tbPort.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbPort_KeyDown);
            // 
            // tbMain
            // 
            this.tbMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbMain.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbMain.Font = new System.Drawing.Font("Consolas", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbMain.Location = new System.Drawing.Point(12, 44);
            this.tbMain.Multiline = true;
            this.tbMain.Name = "tbMain";
            this.tbMain.ReadOnly = true;
            this.tbMain.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbMain.Size = new System.Drawing.Size(819, 276);
            this.tbMain.TabIndex = 3;
            // 
            // tbSend
            // 
            this.tbSend.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbSend.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbSend.Location = new System.Drawing.Point(12, 330);
            this.tbSend.Name = "tbSend";
            this.tbSend.Size = new System.Drawing.Size(553, 28);
            this.tbSend.TabIndex = 6;
            this.tbSend.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbSend_KeyDown);
            // 
            // bSend
            // 
            this.bSend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bSend.Enabled = false;
            this.bSend.Location = new System.Drawing.Point(571, 329);
            this.bSend.Name = "bSend";
            this.bSend.Size = new System.Drawing.Size(89, 32);
            this.bSend.TabIndex = 7;
            this.bSend.Text = "Send";
            this.bSend.UseVisualStyleBackColor = true;
            this.bSend.Click += new System.EventHandler(this.bSend_Click);
            // 
            // cbMode
            // 
            this.cbMode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cbMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMode.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cbMode.Location = new System.Drawing.Point(681, 330);
            this.cbMode.Name = "cbMode";
            this.cbMode.Size = new System.Drawing.Size(128, 28);
            this.cbMode.TabIndex = 8;
            // 
            // cbEchoSelf
            // 
            this.cbEchoSelf.AutoSize = true;
            this.cbEchoSelf.Checked = true;
            this.cbEchoSelf.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbEchoSelf.Location = new System.Drawing.Point(511, 15);
            this.cbEchoSelf.Name = "cbEchoSelf";
            this.cbEchoSelf.Size = new System.Drawing.Size(88, 21);
            this.cbEchoSelf.TabIndex = 9;
            this.cbEchoSelf.Text = "Echo self";
            this.cbEchoSelf.UseVisualStyleBackColor = true;
            // 
            // cbClearSend
            // 
            this.cbClearSend.AutoSize = true;
            this.cbClearSend.Location = new System.Drawing.Point(616, 15);
            this.cbClearSend.Name = "cbClearSend";
            this.cbClearSend.Size = new System.Drawing.Size(116, 21);
            this.cbClearSend.TabIndex = 10;
            this.cbClearSend.Text = "clear on send";
            this.cbClearSend.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(831, 367);
            this.Controls.Add(this.cbClearSend);
            this.Controls.Add(this.cbEchoSelf);
            this.Controls.Add(this.cbMode);
            this.Controls.Add(this.bSend);
            this.Controls.Add(this.tbSend);
            this.Controls.Add(this.tbMain);
            this.Controls.Add(this.tbPort);
            this.Controls.Add(this.tbAddress);
            this.Controls.Add(this.bConnect);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bConnect;
        private System.Windows.Forms.TextBox tbAddress;
        private System.Windows.Forms.TextBox tbPort;
        private System.Windows.Forms.TextBox tbMain;
        private System.Windows.Forms.TextBox tbSend;
        private System.Windows.Forms.Button bSend;
        private System.Windows.Forms.ComboBox cbMode;
        private System.Windows.Forms.CheckBox cbEchoSelf;
        private System.Windows.Forms.CheckBox cbClearSend;
    }
}

