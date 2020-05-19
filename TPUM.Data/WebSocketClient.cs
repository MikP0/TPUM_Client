using System;
using System.Collections.Generic;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TPUM.Data
{
    public static class WebSocketClient
    {
        public static WebSocketConnection _connectionSocket;

        public static async Task<WebSocketConnection> Connect(Uri peer, Action<string> log)
        {
            ClientWebSocket m_ClientWebSocket = new ClientWebSocket();
            await m_ClientWebSocket.ConnectAsync(peer, CancellationToken.None);
            switch (m_ClientWebSocket.State)
            {
                case WebSocketState.Open:
                    log($"Opening WebSocket connection to remote server {peer}");
                    WebSocketConnection _socket = new ClientWebSocketConnection(m_ClientWebSocket, peer, log);
                    _connectionSocket = _socket;
                    return _socket;

                default:
                    log?.Invoke($"Cannot connect to remote node status {m_ClientWebSocket.State}");
                    throw new WebSocketException($"Cannot connect to remote node status {m_ClientWebSocket.State}");
            }
        }
    }
}
