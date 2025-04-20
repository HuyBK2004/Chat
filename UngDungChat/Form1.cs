using System;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace UngDungChat
{
    public partial class Form1 : Form
    {
        TcpClient client;
        NetworkStream stream;
        string currentChatTarget = "ALL";
        public Form1()
        {
            InitializeComponent();
            ConnectToServer();
        }

        private void ConnectToServer()
        {
            try
            {
                client = new TcpClient("127.0.0.1", 8888);
                stream = client.GetStream();

                Thread receiveThread = new Thread(ReceiveMessages);
                receiveThread.Start();

                AppendMessage("Connected to server!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error connecting to server: {ex.Message}");
            }
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            string deleteCommand = "/DELETE";
            byte[] buffer = Encoding.UTF8.GetBytes(deleteCommand);
            stream.Write(buffer, 0, buffer.Length);

            AppendMessage("You deleted a message.");
        }

        private void btnGui_Click(object sender, EventArgs e)
        {
            string message = txtGuiTin.Text;

            if (string.IsNullOrWhiteSpace(message))
                return;

            if (currentChatTarget == "ALL")
            {
                byte[] buffer = Encoding.UTF8.GetBytes(message);
                stream.Write(buffer, 0, buffer.Length);
            }
            else
            {
                string privateMessage = $"/PRIVATE|{currentChatTarget}|{message}";
                byte[] buffer = Encoding.UTF8.GetBytes(privateMessage);
                stream.Write(buffer, 0, buffer.Length);
            }

            AppendMessage($"Me: {message}");
            txtGuiTin.Clear();
        }

        private void lbNguoiDung_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbNguoiDung.SelectedItem != null)
            {
                currentChatTarget = lbNguoiDung.SelectedItem.ToString();
                AppendMessage($"Switched to private chat with {currentChatTarget}");
            }
        }

        void ReceiveMessages()
        {
            try
            {
                byte[] buffer = new byte[1024];
                int bytesRead;

                while ((bytesRead = stream.Read(buffer, 0, buffer.Length)) != 0)
                {
                    string message = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                    Invoke(new Action(() =>
                    {
                        txtTinNhan.AppendText(message + Environment.NewLine);
                    }));
                }
            }
            catch (IOException ex)
            {
                MessageBox.Show($"Server closed the connection: {ex.Message}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void Reconnect()
        {
            while (!client.Connected)
            {
                try
                {
                    client = new TcpClient("127.0.0.1", 8888);
                    stream = client.GetStream();
                    MessageBox.Show("Reconnected to server!");
                    return;
                }
                catch
                {
                    Thread.Sleep(5000); // Đợi 5 giây trước khi thử lại
                }
            }
        }
        private void AppendMessage(string message)
        {
            txtTinNhan.AppendText(message + Environment.NewLine);
        }
    }
}
