using AlzBuddy2.Receiver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace AlzBuddy2.Connections
{
    internal class Communication
    {
        public static AlzBuddyDB db = new AlzBuddyDB();

       /* public void Receive()
        {
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
                   
                    //ReceiveData receiver = new ReceiveData();
                    //receiver.AddReceivedData(message);
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

        public void Send()
        {
            var listener = new HttpListener();
            listener.Prefixes.Add("http://localhost:8080/");
            listener.Start();

            Console.WriteLine("Listening for requests...");

            while (listener.IsListening)
            {
                var context = listener.GetContext();
                ProcessRequest(context);
            }

            listener.Stop();
        }

        static void ProcessRequest(HttpListenerContext context)
        {
            var request = context.Request;
            var response = context.Response;

            if (request.HttpMethod == "GET" && request.Url.PathAndQuery == "/api/data")
            {
                SendResponse(response, GetDataFromDatabase());
            }
            else
            {
                response.StatusCode = (int)HttpStatusCode.NotFound;
            }

            response.Close();
        }


        public static string GetDataFromDatabase()
        {
            var stateValuesData = db.StateValues.ToList();
            var patientTableData = db.Pacients.ToList();
            var errorTableData = db.CriticLevels.ToList();

            var formattedData = stateValuesData.Select(sv =>
                $"{sv.TemperatureValue}, {sv.WaterLevelValue}, {sv.CarbonMonoxideValue}, {sv.FridgeDoorOpenMinutes}");

            formattedData = formattedData.Concat(patientTableData.Select(ot =>
                $"{ot.Name}, {ot.Age}, {ot.Address}"));

            formattedData = formattedData.Concat(errorTableData.Select(er =>
                $"{er.State}, {er.Message}, {er.Value}, {er.Date}, {er.Hour}"));

            return string.Join(Environment.NewLine, formattedData);
        }

        static void SendResponse(HttpListenerResponse response, string content)
        {
            var buffer = System.Text.Encoding.UTF8.GetBytes(content);
            response.ContentLength64 = buffer.Length;
            response.OutputStream.Write(buffer, 0, buffer.Length);
        }*/
    }
}
