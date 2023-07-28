using System;
using System.Net.Sockets;
using System.Text;

public class ArduinoTcpClient
{
    private const string ServerIPAddress = "192.168.137.107"; 
    private const int ServerPort = 5001;

    public static void Main2()
    {
        try
        {
            TcpClient client = new TcpClient();
            client.Connect(ServerIPAddress, ServerPort);
            NetworkStream stream = client.GetStream();
            while (true)
            {
                byte[] receiveBuffer = new byte[520];
                int bytesRead = stream.Read(receiveBuffer, 0, receiveBuffer.Length);
                string receivedData = Encoding.ASCII.GetString(receiveBuffer, 0, bytesRead);
                Console.WriteLine(receivedData);
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
