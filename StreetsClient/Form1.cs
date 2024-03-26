using StreetsLibrary;
using System.Diagnostics;
using System.Net.Sockets;
using System.Net;
using System.Text.Json;
using System.Text;

namespace StreetsClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Process.Start("ConsoleStreetsServer.exe");
        }

        private async void buttonFind_Click(object sender, EventArgs e)
        {
            IPAddress iPAddress = IPAddress.Parse("192.168.178.34");

            int port = 996;

            IPEndPoint iPEndPoint = new IPEndPoint(iPAddress, port);

            Socket activeSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);

            try
            {
                await activeSocket.ConnectAsync(iPEndPoint);

                if(activeSocket.Connected)
                {
                    byte[] bufferData  = Encoding.Default.GetBytes(textBox1.Text);
                    await activeSocket.SendAsync(new ArraySegment<byte>(bufferData), SocketFlags.None);

                    byte[] bufferResponse = new byte[1024];
                    int bytesRead = await activeSocket.ReceiveAsync(new ArraySegment<byte>(bufferResponse), SocketFlags.None);

                    string dataResponce = Encoding.Default.GetString(bufferResponse, 0, bytesRead);
                    List<Street> streets = JsonSerializer.Deserialize<List<Street>>(dataResponce);

                    if(streets != null)
                    {
                        dataGridViewStreets.DataSource = null;
                        dataGridViewStreets.DataSource = streets;
                    }
                }
            }
            catch (SocketException ex)
            {
                MessageBox.Show($"Socket Error: {ex.ToString()}");
            }
            finally
            {
                activeSocket.Shutdown(SocketShutdown.Both);
                activeSocket.Close();
            }
        }
    }
}
