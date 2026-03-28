using System;
using System.Windows.Forms;

namespace UserInterface
{
    public partial class MainForm : Form
    {
        // 1. ライフサイクル
        private void MainForm_Load(object sender, EventArgs e)
        {
            // 子コントロールのLoadは自動的に実行される
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.can_UsrCtl1.CleanUp();
            this.serial_UsrCtl1.CleanUp();
        }

        // 2. コンストラクタ
        public MainForm()
        {
            InitializeComponent();
        }
    }
}

