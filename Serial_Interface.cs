using System;

namespace UserInterface
{
    public interface Serial_Interface : IDisposable
    {
        event Action<string>? MessageReceived;
        void SendMessage(string message);
        bool Initialize(string portName, int baudRate);
        void StartListening();
        string[] GetAvailablePorts();
    }
}


