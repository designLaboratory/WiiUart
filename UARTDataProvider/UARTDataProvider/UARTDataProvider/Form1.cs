﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;

namespace UARTDataProvider
{
    public partial class Form1 : Form
    {
        readonly List<int> baudRates = new List<int>() { 300, 600, 1200, 2400, 4800, 9600, 14400, 19200, 38400, 57600, 115200 };

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
            List<string> comData = comPort.ReadExisting().Split(new string[] {"\r\n"}, StringSplitOptions.RemoveEmptyEntries).ToList();
            comData = comData.Where(s => (s.Substring(0, 1) == "A" && s.Substring(s.Length - 1, 1) == "F")).ToList();
            foreach (string s in comData) { DisplayData(s); ConvertData(s);}
        }

        private void DisplayData(string s)
        {
            data.Items.Add(s); data.TopIndex = data.Items.Count - 1;
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

        private void button3_Click(object sender, EventArgs e)
        {
            StartApp();
        }

        private void StartApp()
        {
            if(path.Text!="Target Shooter Data Folder Path HERE")
                try { Process.Start(new ProcessStartInfo() {FileName = path.Text + "\\Target Shooter.exe"}); }
                catch { MessageBox.Show("Unable to find exe file in this path.");}
            else
                MessageBox.Show("Complete data folder path field!!");
        }

        private void ConvertData(string content)
        {
            List<string> temp = content.Split(new string[] {";"}, System.StringSplitOptions.RemoveEmptyEntries).ToList();
            temp = temp.Where(s => s != "F").ToList();
            temp = temp.Select(s => s.Remove(0, 3)).ToList();
            SaveToFile(temp);
        }

        private void SaveToFile(List<string> content)
        {
            try { File.WriteAllLines(path.Text +"\\Target Shooter_Data\\Resources\\outputData.csv", content.ToArray()); }
            catch { return; }
        }
    }
}
