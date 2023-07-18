using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

class Program
{
    static void Main()
    {
        IPAddress serverIP = IPAddress.Parse("192.168.137.227"); 
        int serverPort = 2390; 

       
        using (UdpClient client = new UdpClient())
        {
           
            client.Connect(serverIP, serverPort);

         
            string messageToSend = "Harish is tanker!";
            byte[] dataToSend = Encoding.ASCII.GetBytes(messageToSend);
            client.Send(dataToSend, dataToSend.Length);

           
            IPEndPoint serverEndPoint = new IPEndPoint(IPAddress.Any, 0);
            byte[] receivedData = client.Receive(ref serverEndPoint);
            string receivedMessage = Encoding.ASCII.GetString(receivedData);

            Console.WriteLine("Received message: " + receivedMessage);
        }

        Console.WriteLine("Press any key to exit.");
        Console.ReadKey();
    }
}
