using System;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;

public class UDP
{
    private const int LocalPort = 5001;

    public static void Main()
    {
        UdpClient udpClient = new UdpClient(LocalPort);
        udpClient.EnableBroadcast = true;

        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();

        int packetsReceived = 0;

        try
        {
            Console.WriteLine("UDP client started. Waiting for data...");

            while (true)
            {
                if (udpClient.Available > 0)
                {
                    IPEndPoint remoteEndPoint = new IPEndPoint(IPAddress.Any, 0);
                    byte[] receivedData = udpClient.Receive(ref remoteEndPoint);
                    packetsReceived++;
                }

                if (stopwatch.ElapsedMilliseconds >= 1000)
                {
                    Console.WriteLine("FPS: " + packetsReceived);
                    packetsReceived = 0;
                    stopwatch.Restart();
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
