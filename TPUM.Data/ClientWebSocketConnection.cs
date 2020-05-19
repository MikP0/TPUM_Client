﻿using System;
using System.Collections.Generic;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TPUM.Data
{
    public class ClientWebSocketConnection : WebSocketConnection
    {
        private ClientWebSocket m_ClientWebSocket = null;
        private Uri m_Peer = null;
        private readonly Action<string> m_Log;

        public ClientWebSocketConnection(ClientWebSocket clientWebSocket, Uri peer, Action<string> log)
        {
            m_ClientWebSocket = clientWebSocket;
            m_Peer = peer;
            m_Log = log;
            Task.Factory.StartNew(() => ClientMessageLoop());
        }

        public override Task SendTask(string message)
        {
            return m_ClientWebSocket.SendAsync(message.GetArraySegment(), WebSocketMessageType.Text, true, CancellationToken.None); ;
        }

        public override Task DisconnectAsync()
        {
            return m_ClientWebSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, "Shutdown procedure started", CancellationToken.None);
        }

        public override string ToString()
        {
            return m_Peer.ToString();
        }

        public void ClientMessageLoop()
        {
            try
            {
                byte[] buffer = new byte[1024];
                while (true)
                {
                    ArraySegment<byte> segment = new ArraySegment<byte>(buffer);
                    WebSocketReceiveResult result = m_ClientWebSocket.ReceiveAsync(segment, CancellationToken.None).Result;
                    if (result.MessageType == WebSocketMessageType.Close)
                    {
                        onClose?.Invoke();
                        m_ClientWebSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, "I am closing", CancellationToken.None).Wait();
                        return;
                    }
                    int count = result.Count;
                    while (!result.EndOfMessage)
                    {
                        if (count >= buffer.Length)
                        {
                            onClose?.Invoke();
                            m_ClientWebSocket.CloseAsync(WebSocketCloseStatus.InvalidPayloadData, "That's too long", CancellationToken.None).Wait();
                            return;
                        }
                        segment = new ArraySegment<byte>(buffer, count, buffer.Length - count);
                        result = m_ClientWebSocket.ReceiveAsync(segment, CancellationToken.None).Result;
                        count += result.Count;
                    }
                    string _message = Encoding.UTF8.GetString(buffer, 0, count);
                    m_Log(_message);
                    onMessage?.Invoke(_message);
                }
            }
            catch (Exception _ex)
            {
                m_Log($"Connection has been broken because of an exception {_ex}");
                m_ClientWebSocket.CloseAsync(WebSocketCloseStatus.InternalServerError, "Connection has been broken because of an exception", CancellationToken.None).Wait();
            }
        }
    }
}
