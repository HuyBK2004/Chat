using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace ChatServer
{
    class Program
    {
        static List<TcpClient> clients = new List<TcpClient>();
        static Dictionary<TcpClient, string> clientIds = new Dictionary<TcpClient, string>();
        static int clientCounter = 1;

        static void Main(string[] args)
        {
            TcpListener server = new TcpListener(IPAddress.Any, 8888);
            server.Start();
            Console.WriteLine("Server started...");

            while (true)
            {
                TcpClient client = server.AcceptTcpClient();
                string clientId = $"ID: {clientCounter:D2}";
                clientIds[client] = clientId;
                clients.Add(client);
                clientCounter++;

                Console.WriteLine($"{clientId} connected.");

                BroadcastClientList();

                Thread clientThread = new Thread(HandleClient);
                clientThread.Start(client);
            }
        }

        static void HandleClient(object obj)
        {
            TcpClient client = (TcpClient)obj;
            try
            {
                NetworkStream stream = client.GetStream();
                byte[] buffer = new byte[1024];
                int bytesRead;

                while ((bytesRead = stream.Read(buffer, 0, buffer.Length)) != 0)
                {
                    string message = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                    Console.WriteLine($"Received: {message}");
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine($"Client connection closed: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            finally
            {
                client.Close();
            }
        }

        static void BroadcastMessage(string message)
        {
            byte[] buffer = Encoding.UTF8.GetBytes(message);
            foreach (var client in clients)
            {
                NetworkStream stream = client.GetStream();
                stream.Write(buffer, 0, buffer.Length);
            }
        }

        static void SendPrivateMessage(string targetId, string message)
        {
            foreach (var client in clientIds)
            {
                if (client.Value == targetId)
                {
                    NetworkStream stream = client.Key.GetStream();
                    byte[] buffer = Encoding.UTF8.GetBytes(message);
                    stream.Write(buffer, 0, buffer.Length);
                    break;
                }
            }
        }

        static void BroadcastClientList()
        {
            string clientList = string.Join(",", clientIds.Values);
            byte[] buffer = Encoding.UTF8.GetBytes($"CLIENT_LIST:{clientList}");

            foreach (var client in clients)
            {
                NetworkStream stream = client.GetStream();
                stream.Write(buffer, 0, buffer.Length);
            }
        }
    }
}
