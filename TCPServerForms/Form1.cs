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

    public enum MODES { STR_HEX, ADV_HEX, ASCII, UTF8 }

    public partial class Form1 : Form
    {
        private ConnectionState state = ConnectionState.Closed;
        private IPAddress address = null;
        private int port = 0;
        private TcpClient client;
        private NetworkStream stream;
        private Thread receiver;
        private List<byte> Received = new List<byte>();
        private byte[] ReceivedArray;
        private List<byte> Send = new List<byte>();




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

        private void WriteLine(string text, bool localString = false, bool additional = true)
        {
            if (additional)
                tbMain.AppendText(Environment.NewLine);
            if (localString)
                tbMain.AppendText(DateTime.Now.ToString("HH:mm:ss "));
            else
                tbMain.AppendText(DateTime.Now.ToString("HH:mm:ss > "));
            tbMain.AppendText(text);
            tbMain.AppendText(Environment.NewLine);
        }

        private void Receiver()
        {
            bool restart = true;

            for (; restart;) // restart on error
            {
                client = new TcpClient();
                stream = null;

                try
                {
                    client.Connect(address, port);
                    stream = client.GetStream();

                    if (stream != null)
                    {
                        WriteLine("Connected", true);


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

                                    if (asciiString == "Other connected") // byte_dec
                                    {
                                        WriteLine("Other connected");
                                    }
                                    else
                                    {
                                        MODES mode = (MODES)cbMode.SelectedIndex;
                                        if (mode == MODES.STR_HEX)
                                        {
                                            WriteLine(BitConverter.ToString(ReceivedArray).Replace("-", " "));
                                        }
                                        if (mode == MODES.ADV_HEX)
                                        {
                                            string byteStr = BitConverter.ToString(ReceivedArray).Replace("-", " ");
                                            for (int q = 0; q < byteStr.Length; q += 48) //16x3
                                            {
                                                int w = Math.Min(48, byteStr.Length - q);
                                                WriteLine(byteStr.Substring(q, w));
                                            }
                                        }
                                        if (mode == MODES.ASCII)
                                        {
                                            WriteLine(asciiString);
                                        }
                                        if (mode == MODES.UTF8)
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
                            Thread.Sleep(1);
                        }
                    }
                    Thread.Sleep(100);
                }
                catch (ThreadAbortException)
                {
                    WriteLine("Stopped", true);
                    if (stream != null)
                        stream.Close();

                    if (client != null)
                        client.Close();
                    restart = false;
                }
                catch (Exception ex)
                {
                    WriteLine("Error: " + ex.Message, true);
                    if (stream != null)
                        stream.Close();

                    if (client != null)
                        client.Close();

                    Thread.Sleep(100);
                }
            }
        }



        private void Form1_Load(object sender, EventArgs e)
        {
            cbMode.DataSource = Enum.GetValues(typeof(MODES));
            cbMode.SelectedIndex = (int)MODES.ASCII;

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
                        WriteLine("Host Error", true);
                        return;
                    }
                    address = hostEntry.AddressList[0];

                    if (!int.TryParse(tbPort.Text, out port))
                    {

                        WriteLine("Port error", true);
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
                WriteLine(tbSend.Text, true);
            if (cbClearSend.Checked)
                tbSend.Text = "";
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (state == ConnectionState.Open)
            {
                receiver.Abort();
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

        private void button1_Click(object sender, EventArgs e)
        {
            tbMain.Text = "";
        }
    }
}
