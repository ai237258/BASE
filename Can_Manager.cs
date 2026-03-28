using System;
using System.Threading;
using System.Threading.Tasks;
using Kvaser.CanLib;

namespace UserInterface
{
    public class Can_Manager : Can_Interface
    {
        // 1. フィールド（最上部）
        public event Action<int, byte[], int, long>? MessageReceived;
        private int canHandle;
        private bool isRunning;
        private CancellationTokenSource? cts;

        // 2. コンストラクタ
        public Can_Manager()
        {
            this.canHandle = -1;
            this.isRunning = false;
            this.cts = null;
        }

        // 3. メソッド
        public bool Initialize(int channel)
        {
            Canlib.canStatus status;

            Canlib.canInitializeLibrary();
            this.canHandle = Canlib.canOpenChannel(channel, Canlib.canOPEN_ACCEPT_VIRTUAL);

            if (this.canHandle < 0) return false;

            status = Canlib.canSetBusParams(this.canHandle, Canlib.canBITRATE_500K, 0, 0, 0, 0);
            if (status != Canlib.canStatus.canOK) return false;

            status = Canlib.canBusOn(this.canHandle);
            return status == Canlib.canStatus.canOK;
        }

        public void SendMessage(int id, byte[] msg, int dlc)
        {
            if (this.canHandle >= 0)
            {
                Canlib.canWrite(this.canHandle, id, msg, dlc, 0);
            }
        }

        public void StartListening()
        {
            if (this.canHandle < 0 || this.isRunning) return;

            this.isRunning = true;
            this.cts = new CancellationTokenSource();
            Task.Run(() => this.ReadLoop(this.cts.Token));
        }

        private void ReadLoop(CancellationToken token)
        {
            int id;
            byte[] msg;
            int dlc;
            int flag;
            long time;
            Canlib.canStatus status;

            msg = new byte[8];

            while (!token.IsCancellationRequested)
            {
                status = Canlib.canReadWait(this.canHandle, out id, msg, out dlc, out flag, out time, 100);
                if (status == Canlib.canStatus.canOK)
                {
                    this.MessageReceived?.Invoke(id, msg, dlc, time);
                }
            }
        }

        public void Dispose()
        {
            if (this.isRunning && this.cts != null)
            {
                this.cts.Cancel();
                this.isRunning = false;
            }

            if (this.canHandle >= 0)
            {
                Canlib.canBusOff(this.canHandle);
                Canlib.canClose(this.canHandle);
                this.canHandle = -1;
            }
        }
    }
}