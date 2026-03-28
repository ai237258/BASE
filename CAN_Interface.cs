using System;

namespace UserInterface
{
    public interface Can_Interface : IDisposable
    {
        event Action<int, byte[], int, long>? MessageReceived;
        void SendMessage(int id, byte[] msg, int dlc);
        bool Initialize(int channel);
        void StartListening();
    }
}

