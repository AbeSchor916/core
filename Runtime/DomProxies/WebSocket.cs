#if UNITY_EDITOR

using System;

namespace ReactUnity.DomProxies
{
    public class WebSocketProxy : WebSocketSharp.WebSocket
    {
        public Action<WebSocketSharp.MessageEventArgs> onmessage
        {
            set { OnMessage += (sender, e) => value?.Invoke(e); }
            get => null;
        }

        public Action<WebSocketSharp.CloseEventArgs> onclose
        {
            set { OnClose += (sender, e) => value?.Invoke(e); }
            get => null;
        }

        public Action<EventArgs> onopen
        {
            set { OnOpen += (sender, e) => value?.Invoke(e); }
            get => null;
        }

        public Action<WebSocketSharp.ErrorEventArgs> onerror
        {
            set { OnError += (sender, e) => value?.Invoke(e); }
            get => null;
        }

        public WebSocketProxy(string url, params string[] protocols) : base(url, protocols)
        {
            ConnectAsync();
        }

        public void close(WebSocketSharp.CloseStatusCode code = WebSocketSharp.CloseStatusCode.Normal, string reason = null)
        {
            CloseAsync(code, reason);
        }
    }
}

#endif
