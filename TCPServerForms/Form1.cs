using System;
using System.Collections.Generic;
using System.Data;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace TCPServerForms
{
    public partial class Form1 : Form
    {



        ConnectionState state = ConnectionState.Closed;
        IPAddress address = null;
        int port = 0;

        TcpClient client;
        NetworkStream stream;
        Thread receiver;

        List<byte> Received = new List<byte>();
        byte[] ReceivedArray;
        List<byte> Send = new List<byte>();




        public Form1(string[] args)
        {
            InitializeComponent();

            for (int ID = 0; ID < args.Length; ID++)
            {
                if (args[ID] == "-port")
                {
                    ID++;
                    tbPort.Text = args[ID];
                }

                if (args[ID] == "-address")
                {
                    ID++;
                    tbAddress.Text = args[ID];
                }

                if (args[ID] == "-connect")
                {
                    state = ConnectionState.Connecting;
                }
            }
        }



        void Write(string text)
        {
            tbMain.AppendText(text);
        }

        void WriteLine(string text)
        {
            tbMain.AppendText(text + Environment.NewLine);
        }





        void Receiver()
        {

            for (; ; ) // restart on error
            {
                client = new TcpClient();
                stream = null;

                try
                {
                    client.Connect(address, port);
                    stream = client.GetStream();

                    if (stream != null)
                    {
                        WriteLine(Time() + " Connected\n");


                        for (; ; )  // main loop
                        {
                            if (stream != null)
                            {
                                if (stream.DataAvailable)
                                {
                                    Received.Clear();
                                    while (stream.DataAvailable)
                                    {
                                        Received.Add((byte)stream.ReadByte());
                                    }
                                    ReceivedArray = Received.ToArray();
                                    string asciiString = Encoding.ASCII.GetString(ReceivedArray);


                                    Write(Time() + " > ");

                                    if (asciiString == "Other connected") // byte_dec
                                    {
                                        WriteLine("Other connected");
                                    }
                                    else
                                    {
                                        string mode = (string)cbMode.SelectedItem;
                                        if (mode == "DEC") // byte_dec
                                        {
                                            foreach (byte b in Received)
                                                Write(b.ToString());
                                            WriteLine("");
                                        }
                                        if (mode == "HEX")
                                        {
                                            WriteLine(BitConverter.ToString(ReceivedArray).Replace("-", " "));
                                        }
                                        if (mode == "ASCII")
                                        {
                                            WriteLine(asciiString);
                                        }
                                        if (mode == "UTF-8")
                                        {
                                            WriteLine(Encoding.UTF8.GetString(ReceivedArray));
                                        }
                                    }
                                }
                                if (Send.Count > 0)
                                {
                                    byte[] arr = Send.ToArray();
                                    stream.Write(arr, 0, arr.Length);
                                    Send.Clear();
                                }
                            }
                            Thread.Sleep(40);
                        }
                    }
                    Thread.Sleep(100);
                }
                catch (Exception ex)
                {
                    WriteLine(Time() + ": Возникло исключение: " + ex.Message);
                    if (stream != null)
                        stream.Close();

                    if (client != null)
                        client.Close();

                    Thread.Sleep(100);
                }
            }
        }

        private static string Time()
        {
            return DateTime.Now.ToString("HH:mm:ss");
        }




        private void Form1_Load(object sender, EventArgs e)
        {
            cbMode.Items.Add("HEX");
            cbMode.Items.Add("DEC");
            cbMode.Items.Add("ASCII");
            cbMode.Items.Add("UTF-8");
            cbMode.SelectedIndex = 2; // ascii

            if (state == ConnectionState.Connecting)
            {
                state = ConnectionState.Closed;
                bConnect_Click(null, null);
            }
        }

        private void bConnect_Click(object sender, EventArgs e)
        {
            switch (state)
            {
                case ConnectionState.Closed:
                {
                    IPHostEntry hostEntry;
                    hostEntry = Dns.GetHostEntry(tbAddress.Text);
                    if (hostEntry.AddressList.Length < 1)
                    {
                        WriteLine("Host Error");
                        return;
                    }
                    address = hostEntry.AddressList[0];

                    if (!int.TryParse(tbPort.Text, out port))
                    {

                        WriteLine("Port error");
                        return;
                    }
                    receiver = new Thread(Receiver);
                    receiver.Start();
                    state = ConnectionState.Open;
                    bSend.Enabled = true;
                    break;
                }
                case ConnectionState.Open:
                {
                    receiver.Abort();
                    client.Close();
                    state = ConnectionState.Closed;
                    bSend.Enabled = false;
                    break;
                }
            }
        }

        private void bSend_Click(object sender, EventArgs e)
        {
            Send.AddRange(Encoding.ASCII.GetBytes(tbSend.Text));
            if (cbEchoSelf.Checked)
                WriteLine(tbSend.Text);
            if (cbClearSend.Checked)
                tbSend.Text = "";
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (state == ConnectionState.Open)
            {
                receiver.Abort();
                client.Close();
            }
        }

        private void tbSend_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                bSend_Click(null, null);
                e.SuppressKeyPress = true;
            }
        }

        private void tbAddress_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                tbPort.Focus();
                e.SuppressKeyPress = true;
            }
        }

        private void tbPort_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                bConnect_Click(null, null);
                e.SuppressKeyPress = true;
            }
        }
    }
}
