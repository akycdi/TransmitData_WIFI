using System.Net;
using System.Net.Sockets;

public class UDP
{
    private const int LocalPort = 5001;

    public  void UD1P()
    {
        UdpClient udpClient = new UdpClient(LocalPort);
        udpClient.EnableBroadcast = true;

        try
        {
            Console.WriteLine("UDP client started. Waiting for data...");


            while (true)
            {
                IPEndPoint remoteEndPoint = new IPEndPoint(IPAddress.Any, 0);
                byte[] receivedData = udpClient.Receive(ref remoteEndPoint);
                string receivedString = System.Text.Encoding.ASCII.GetString(receivedData);
                if (receivedString != null)
                {
                    Console.WriteLine(receivedString);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
        finally
        {
            udpClient.Close();
        }
    }
}