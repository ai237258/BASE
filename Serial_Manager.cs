using System;
using System.IO.Ports;

namespace UserInterface
{
    public class Serial_Manager : Serial_Interface
    {
        // 1. フィールド
        public event Action<string>? MessageReceived;
        private SerialPort serialPort;
        private bool isRunning;

        // 2. コンストラクタ
        public Serial_Manager()
        {
            this.serialPort = new SerialPort();
            this.isRunning = false;
        }

        // 3. メソッド
        public bool Initialize(string portName, int baudRate)
        {
            bool isSuccess;

            try
            {
                this.serialPort.PortName = portName;
                this.serialPort.BaudRate = baudRate;
                this.serialPort.DataBits = 8;
                this.serialPort.Parity = Parity.None;
                this.serialPort.StopBits = StopBits.One;
                this.serialPort.Open();
                isSuccess = true;
            }
            catch
            {
                isSuccess = false;
            }
            return isSuccess;
        }

        public void SendMessage(string message)
        {
            if (this.serialPort.IsOpen)
            {
                this.serialPort.Write(message);
            }
        }

        public string[] GetAvailablePorts()
        {
            string[] ports;
            ports = SerialPort.GetPortNames();
            return ports;
        }

        public void StartListening()
        {
            if (this.serialPort.IsOpen && !this.isRunning)
            {
                this.isRunning = true;
                this.serialPort.DataReceived += this.OnDataReceived;
            }
        }

        private void OnDataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            string data;
            data = this.serialPort.ReadExisting();

            if (!string.IsNullOrEmpty(data))
            {
                this.MessageReceived?.Invoke(data);
            }
        }

        public void Dispose()
        {
            if (this.serialPort != null)
            {
                this.serialPort.DataReceived -= this.OnDataReceived;
                if (this.serialPort.IsOpen) this.serialPort.Close();
                this.serialPort.Dispose();
            }
            this.isRunning = false;
        }
    }
}