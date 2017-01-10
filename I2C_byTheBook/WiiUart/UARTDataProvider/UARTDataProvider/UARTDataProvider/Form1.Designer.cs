namespace UARTDataProvider
{
    partial class Form1
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
            this.comPorts = new System.Windows.Forms.ComboBox();
            this.baudRate = new System.Windows.Forms.ComboBox();
            this.data = new System.Windows.Forms.ListBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.portname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.baud = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.databits = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stopbits = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.parity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.handshake = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.readtimeout = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // comPorts
            // 
            this.comPorts.FormattingEnabled = true;
            this.comPorts.Location = new System.Drawing.Point(623, 6);
            this.comPorts.Name = "comPorts";
            this.comPorts.Size = new System.Drawing.Size(121, 21);
            this.comPorts.TabIndex = 0;
            this.comPorts.Text = "Choose port";
            // 
            // baudRate
            // 
            this.baudRate.FormattingEnabled = true;
            this.baudRate.Location = new System.Drawing.Point(623, 42);
            this.baudRate.Name = "baudRate";
            this.baudRate.Size = new System.Drawing.Size(121, 21);
            this.baudRate.TabIndex = 1;
            this.baudRate.Text = "Choose baud rate";
            // 
            // data
            // 
            this.data.FormattingEnabled = true;
            this.data.Location = new System.Drawing.Point(12, 162);
            this.data.Name = "data";
            this.data.Size = new System.Drawing.Size(732, 173);
            this.data.TabIndex = 2;
            // 
            // timer1
            // 
            this.timer1.Interval = 10;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button1.Location = new System.Drawing.Point(12, 69);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(563, 30);
            this.button1.TabIndex = 3;
            this.button1.Text = "SET COM PORT";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.portname,
            this.baud,
            this.databits,
            this.stopbits,
            this.parity,
            this.handshake,
            this.readtimeout});
            this.dataGridView1.Location = new System.Drawing.Point(12, 6);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(563, 57);
            this.dataGridView1.TabIndex = 4;
            // 
            // portname
            // 
            this.portname.HeaderText = "Port Name";
            this.portname.Name = "portname";
            this.portname.ReadOnly = true;
            this.portname.Width = 70;
            // 
            // baud
            // 
            this.baud.HeaderText = "Baud Rate";
            this.baud.Name = "baud";
            this.baud.ReadOnly = true;
            this.baud.Width = 70;
            // 
            // databits
            // 
            this.databits.HeaderText = "Data Bits";
            this.databits.Name = "databits";
            this.databits.ReadOnly = true;
            this.databits.Width = 70;
            // 
            // stopbits
            // 
            this.stopbits.HeaderText = "Stop Bits";
            this.stopbits.Name = "stopbits";
            this.stopbits.ReadOnly = true;
            this.stopbits.Width = 70;
            // 
            // parity
            // 
            this.parity.HeaderText = "Parity";
            this.parity.Name = "parity";
            this.parity.ReadOnly = true;
            this.parity.Width = 70;
            // 
            // handshake
            // 
            this.handshake.HeaderText = "Handshake";
            this.handshake.Name = "handshake";
            this.handshake.ReadOnly = true;
            this.handshake.Width = 70;
            // 
            // readtimeout
            // 
            this.readtimeout.HeaderText = "Read Timeout";
            this.readtimeout.Name = "readtimeout";
            this.readtimeout.ReadOnly = true;
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button2.Location = new System.Drawing.Point(12, 126);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(732, 30);
            this.button2.TabIndex = 5;
            this.button2.Text = "START TRANSMISSION";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(756, 342);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.data);
            this.Controls.Add(this.baudRate);
            this.Controls.Add(this.comPorts);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.ComboBox comPorts;
        public System.Windows.Forms.ComboBox baudRate;
        public System.Windows.Forms.ListBox data;
        private System.Windows.Forms.Button button1;
        public System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.DataGridViewTextBoxColumn portname;
        private System.Windows.Forms.DataGridViewTextBoxColumn baud;
        private System.Windows.Forms.DataGridViewTextBoxColumn databits;
        private System.Windows.Forms.DataGridViewTextBoxColumn stopbits;
        private System.Windows.Forms.DataGridViewTextBoxColumn parity;
        private System.Windows.Forms.DataGridViewTextBoxColumn handshake;
        private System.Windows.Forms.DataGridViewTextBoxColumn readtimeout;
        private System.Windows.Forms.Button button2;
        public System.Windows.Forms.DataGridView dataGridView1;
    }
}

