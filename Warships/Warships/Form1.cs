namespace Warships
{
    using System.Net;
    using System.Net.Sockets;
    using System.Windows.Forms;

    public partial class Form1 : Form
    {
        String playerName;
        Image icon = Image.FromFile("avs/1.png");
        Game g = new Game();
        public Form1()
        {
            InitializeComponent();
            pictureBox1.Image = icon;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            g.FirstAve = pictureBox1.Image;
            g.FirstName = textBox1.Text;
            Layout placement = new Layout(g);
            placement.Show();
           // this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            IPHostEntry ipHost = Dns.GetHostEntry("localhost");
            IPAddress ipAddr = ipHost.AddressList[0];
            IPEndPoint ipEndPoint = new IPEndPoint(ipAddr, 11000);

            Socket sListener = new Socket(ipAddr.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            label1.Text = "Ваш IP: " + ipHost.AddressList[1] + "/" + ipEndPoint.Port;
            button1.Hide();
            button2.Hide();
            button3.Hide();
            textBox1.Hide();
            textBox2.Hide();
            playerName = textBox1.Text;

            radioButton1.Visible = false;
            radioButton2.Visible = false;
            radioButton3.Visible = false;
            button4.Show();
            try
            {
                sListener.Bind(ipEndPoint);
                sListener.Listen(1);
                label1.Text = "fnjafbalkfa";
                //Console.WriteLine("Ожидаем соединение через порт {0}", ipEndPoint);

                // Программа приостанавливается, ожидая входящее соединение
                //Socket handler = sListener.Accept();
                string data = null;
            }
            catch (Exception ex) { }



        }

        private void button4_Click(object sender, EventArgs e)
        {
            label1.Text = "Никнейм";

            button1.Show();
            button2.Show();
            button3.Show();
            textBox1.Show();
            textBox2.Hide();
            button4.Hide();
            button5.Hide();
            textBox1.Text = playerName;
            radioButton1.Visible = true;
            radioButton2.Visible = true;
            radioButton3.Visible = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            button1.Hide();
            button2.Hide();
            button3.Hide();
            button4.Show();
            button5.Show();
            textBox2.Show();
            playerName = textBox1.Text;
            textBox1.Text = "127.0.0.1";
            textBox2.Text = "11000";

            radioButton1.Visible = false;
            radioButton2.Visible = false;
            radioButton3.Visible = false;
        }


        private void button5_Click(object sender, EventArgs e)
        {
            IPHostEntry host = Dns.GetHostEntry(textBox1.Text);
            IPAddress ipAddress = host.AddressList[0];

            int ip = int.Parse(textBox2.Text);
            IPEndPoint remoteEP = new IPEndPoint(ipAddress, ip);

            // Create a TCP/IP  socket.
            Socket client = new Socket(ipAddress.AddressFamily,
                SocketType.Stream, ProtocolType.Tcp);

            // Connect the socket to the remote endpoint. Catch any errors.
            try
            {
                // Connect to Remote EndPoint
                client.Connect(remoteEP);
                label1.Text = "qwerty";
                //Console.WriteLine("Socket connected to {0}", client.RemoteEndPoint.ToString());
            }
            catch { };
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK) { icon = Image.FromFile(openFileDialog1.FileName); }
        }
    }
}