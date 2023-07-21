using System;
using System.Net.Sockets;
using System.Text;

public class ArduinoTcpClient
{
    private const string ServerIPAddress = "192.168.137.244"; // Replace with the Arduino's IP address
    private const int ServerPort = 5001; // Replace with the Arduino's server port

    public static void Main()
    {
        try
        {
            TcpClient client = new TcpClient();
            client.Connect(ServerIPAddress, ServerPort);

            Console.WriteLine("Connected to Arduino TCP server.");

            NetworkStream stream = client.GetStream();

            while (true)
            {
                byte[] receiveBuffer = new byte[1024];
                int bytesRead = stream.Read(receiveBuffer, 0, receiveBuffer.Length);
                string receivedData = Encoding.ASCII.GetString(receiveBuffer, 0, bytesRead);
                Console.WriteLine("Received data from Arduino: " + receivedData);
            }

            // Close the connection
            stream.Close();
            client.Close();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
