using System.IO;
using System.Net.Sockets;
using System.Net;
using System.Text.Json;
using System.Text;
using StreetsLibrary;

namespace ConsoleStreetsServer
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            IPAddress iPAddress = IPAddress.Parse("192.168.178.34");

            int port = 996;

            IPEndPoint iPEndPoint = new IPEndPoint(iPAddress, port);

            Socket passiveSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);

            passiveSocket.Bind(iPEndPoint);
            passiveSocket.Listen(10);

            Console.WriteLine($"Server started at port {iPEndPoint.Port}");

            try
            {
                Socket currentSocket = passiveSocket.Accept();

                Console.WriteLine($"Client {currentSocket.RemoteEndPoint} was connected");

                byte[] bufferReceived = new byte[1024];
                int bytesRead = await currentSocket.ReceiveAsync(new ArraySegment<byte>(bufferReceived), SocketFlags.None);

                Console.WriteLine($"{bytesRead} bytes read from: {passiveSocket.RemoteEndPoint}");

                int data = Convert.ToInt32(Encoding.Default.GetString(bufferReceived, 0, bytesRead));

                List<Street> streets = new List<Street>();
                string? jsonData = null;

                using (StreamReader reader = new StreamReader("streets.json", Encoding.Default))
                {
                    jsonData = reader.ReadToEnd();
                }

                Console.WriteLine($"\nData: {data}");
                Console.WriteLine($"\nJson:\n {jsonData}");


                if (jsonData != null) 
                {
                    streets = JsonSerializer.Deserialize<List<Street>>(jsonData);
                }

                if (streets != null)
                {
                    List<Street> foundStreets = streets.Where(s => s.PostalIndex == data).ToList();

                    string jsonSend = JsonSerializer.Serialize(foundStreets);

                    byte[] bufferResponse = Encoding.Default.GetBytes(jsonSend);

                    int len = await currentSocket.SendAsync(new ArraySegment<byte>(bufferResponse), SocketFlags.None);

                    Console.WriteLine($"{len} bytes send to: {passiveSocket.RemoteEndPoint}");

                    currentSocket.Shutdown(SocketShutdown.Both);
                    currentSocket.Close();
                }

            }
            catch (SocketException ex)
            {
                Console.Error.WriteLine($"Socket Error: {ex.ToString()}");
                Console.ReadKey();
            }
            catch(Exception ex)
            {
                Console.Error.WriteLine($"Error: {ex.ToString()}");
                Console.ReadKey();
            }

            Console.ReadLine();
        }
    }
}
