using System;
using SimpleAsyncSockets.AsyncTcpSockets;

namespace SimpleAsyncSockets
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Aplicación de consola que demuestra el funcionamiento de los Sockets");
            ISimpleAsyncListener asyncTcpListener = new AsyncTcpListener(8085);
            asyncTcpListener.StartListening();
        }
    }
}
