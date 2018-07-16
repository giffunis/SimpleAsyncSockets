
using System.Net;
using System.Net.Sockets;

namespace SimpleAsyncSockets{
    public abstract class ISimpleAsyncListener{

        protected IPEndPoint ipEndPoint;
        protected int backlog;

        protected TcpListener listener;


        public ISimpleAsyncListener(){
            ipEndPoint = new IPEndPoint(IPAddress.Any, 0);
            listener = new TcpListener(ipEndPoint);
            listener.Start();
        }

        public ISimpleAsyncListener(int port){
            ipEndPoint = new IPEndPoint(IPAddress.Any, port);
            listener = new TcpListener(ipEndPoint);
            listener.Start();
        }

        public ISimpleAsyncListener(IPAddress ipAddress, int port){
            ipEndPoint = new IPEndPoint(ipAddress, port);
            listener = new TcpListener(ipEndPoint);
            listener.Start();
        }

        public abstract void StartListening();

    }
}
