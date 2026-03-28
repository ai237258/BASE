using System;
using System.Windows.Forms;

namespace UserInterface
{
    public partial class Can_UsrCtl : UserControl
    {
        // 1. ライフサイクル
        private void Can_UsrCtl_Load(object sender, EventArgs e)
        {
            bool isOk;
            isOk = this.canManager.Initialize(0);

            if (isOk)
            {
                this.canManager.MessageReceived += this.OnCanReceived;
                this.canManager.StartListening();
            }
        }

        public void CleanUp()
        {
            this.canManager.Dispose();
        }

        // 2. 解析ロジック
        private void ProcessCanData(int id, byte[] msg, int dlc)
        {
            // 解析コード
        }

        // 3. ハンドラ
        private void OnCanReceived(int id, byte[] msg, int dlc, long time)
        {
            Action action;
            if (this.InvokeRequired)
            {
                action = new Action(() => this.ProcessCanData(id, msg, dlc));
                this.Invoke(action);
                return;
            }
            this.ProcessCanData(id, msg, dlc);
        }

        // 4. コンストラクタ
        public Can_UsrCtl()
        {
            InitializeComponent();
            this.canManager = new Can_Manager();
        }

        // 5. フィールド
        private readonly Can_Interface canManager;
    }
}