using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;

namespace UARTDataProvider
{
    public partial class Form1 : Form
    {
        readonly List<int> baudRates = new List<int>() { 300, 600, 1200, 2400, 4800, 9600, 14400, 19200 };

        SerialPort comPort = new SerialPort();

        public Form1()
        {
            InitializeComponent();
            LoadComPortsList();
            LoadBaudRates();
        }

        private void LoadComPortsList()
        {
            List<string> arrayComPortsNames = new List<string>();
            arrayComPortsNames = SerialPort.GetPortNames().ToList();
            foreach (string s in arrayComPortsNames) comPorts.Items.Add(s);
        }

        private void LoadBaudRates()
        {
            foreach (int i in baudRates) baudRate.Items.Add(i.ToString());
        }

        private void SetComPort()
        {
            SetConfiguration();
            CompleteComPortConfigTable();
        }

        private void SetConfiguration()
        {
            comPort.PortName = comPorts.Text;
            comPort.BaudRate = int.Parse(baudRate.Text);
            comPort.Parity = Parity.None;
            comPort.Handshake = Handshake.None;
            comPort.DataBits = 8;
            comPort.StopBits = StopBits.One;
            comPort.ReadTimeout = 4000;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            GetData();
        }

        private void GetData()
        {
            List<string> comData = comPort.ReadExisting().Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries).ToList();
            foreach (string s in comData) if (s.Length >= 4) data.Items.Add(s); 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SetComPort();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            try { comPort.Open(); timer1.Enabled = true; }
            catch { MessageBox.Show("Connection Error! Please check your connection."); }
            comPort.RtsEnable = true;
            comPort.DtrEnable = true;
        }

        private void CompleteComPortConfigTable()
        {
            dataGridView1.Rows[0].SetValues(
                new object[] { comPort.PortName, comPort.BaudRate, comPort.DataBits, comPort.StopBits, comPort.Parity, comPort.Handshake, comPort.ReadTimeout });
        }
    }
}
