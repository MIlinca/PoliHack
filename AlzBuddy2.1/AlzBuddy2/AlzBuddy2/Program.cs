using AlzBuddy2.Receiver;
using AlzBuddy2.Connections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using AlzBuddy2.Models;

namespace AlzBuddy2
{
    internal class Program
    {
        //public static AlzBuddyDB db = new AlzBuddyDB();
        static void Main(string[] args)
        {
            /*var tableToEmpty = db.Set<CriticLevel>();
            tableToEmpty.RemoveRange(tableToEmpty);

            db.SaveChanges();

            Console.WriteLine("Database cleared successfully.");*/

            // Set the server IP address and port
            string serverIp = "192.168.35.169";
            int port = 12345;

            // Create a TCP client socket
            TcpClient client = new TcpClient(serverIp, port);

            // Get the network stream
            NetworkStream stream = client.GetStream();

            try
            {
                // Continuous loop to listen for messages
                while (true)
                {
                    // Receive data from the server
                    byte[] data = new byte[1024];
                    int bytesRead = stream.Read(data, 0, data.Length);
                    string message = Encoding.ASCII.GetString(data, 0, bytesRead);
                    Console.WriteLine($"Received from server: {message}");

                    ReceiveData receiver = new ReceiveData();
                    receiver.AddReceivedData(message);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
            finally
            {
                // Close the client socket
                client.Close();
            }
        }
    }
}
