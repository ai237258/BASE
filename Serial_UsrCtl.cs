using System;
using System.Windows.Forms;

namespace UserInterface
{
    public partial class Serial_UsrCtl : UserControl
    {
        // 1. ライフサイクル
        private void Serial_UsrCtl_Load(object sender, EventArgs e)
        {
            bool isOk;
            string port;

            port = "COM1";
            isOk = this.serialManager.Initialize(port, 115200);

            if (isOk)
            {
                this.serialManager.MessageReceived += this.OnSerialReceived;
                this.serialManager.StartListening();
            }
        }

        public void CleanUp()
        {
            this.serialManager.Dispose();
        }

        // 2. 解析
        private void ProcessSerialData(string message)
        {
            // 解析コード
        }

        // 3. ハンドラ
        private void OnSerialReceived(string message)
        {
            Action action;
            if (this.InvokeRequired)
            {
                action = new Action(() => this.ProcessSerialData(message));
                this.Invoke(action);
                return;
            }
            this.ProcessSerialData(message);
        }

        // 4. コンストラクタ
        public Serial_UsrCtl()
        {
            InitializeComponent();
            this.serialManager = new Serial_Manager();
        }

        // 5. フィールド
        private readonly Serial_Interface serialManager;
    }
}