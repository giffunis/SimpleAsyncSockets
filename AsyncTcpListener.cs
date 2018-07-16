
using System;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SimpleAsyncSockets.AsyncTcpSockets{
    public class AsyncTcpListener : ISimpleAsyncListener
    {
        private int connectedClients = 0;

        public const string ENDS_MARK = "<EOF>";

        public AsyncTcpListener () : base() {}

        public AsyncTcpListener (int port) : base(port) {}

        public AsyncTcpListener (IPAddress ipAddress, int port) : base(ipAddress, port) {}

        public override void StartListening()
        {
            if (this.listener != null)
            {
                // Listening.
                while (true)
                {
                    Console.WriteLine($"Waiting for client... {connectedClients} connected at the moment.");
                    Listen(); // Helper to listen on the background and return.
                }
            }
        }

        private async void Listen() {
            var clientTask = this.listener.AcceptTcpClientAsync(); // Get the client

            if (clientTask.Result != null)
            {
                connectedClients++;
                Console.WriteLine("Client connected. Waiting for data.");
                var client = clientTask.Result;
                string fullMessage = string.Empty;
                string message = "";

                await Task.Run(() => {
                    while (message != null && !message.EndsWith(ENDS_MARK))
                    {
                        fullMessage += message;
                        byte[] buffer = new byte[1024];
                        client.GetStream().Read(buffer, 0, buffer.Length);

                        message = Encoding.ASCII.GetString(buffer);
                        Console.WriteLine(message);
                    }
                });

                Console.WriteLine($"The full message is:\n {fullMessage}");
                Console.WriteLine($"Closing connection. {--connectedClients} connected at the moment.");
                client.GetStream().Dispose();
            }
}
    }
}