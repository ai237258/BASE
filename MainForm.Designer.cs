namespace UserInterface
{
    partial class MainForm
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            // メソッド内の変数を先頭で宣言
            bool shouldDispose;

            shouldDispose = disposing && (this.components != null);

            if (shouldDispose)
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.can_UsrCtl1 = new UserInterface.Can_UsrCtl();
            this.serial_UsrCtl1 = new UserInterface.Serial_UsrCtl();
            this.SuspendLayout();

            // 
            // can_UsrCtl1
            // 
            this.can_UsrCtl1.Location = new System.Drawing.Point(12, 12);
            this.can_UsrCtl1.Name = "can_UsrCtl1";
            this.can_UsrCtl1.Size = new System.Drawing.Size(350, 200);
            this.can_UsrCtl1.TabIndex = 0;

            // 
            // serial_UsrCtl1
            // 
            this.serial_UsrCtl1.Location = new System.Drawing.Point(368, 12);
            this.serial_UsrCtl1.Name = "serial_UsrCtl1";
            this.serial_UsrCtl1.Size = new System.Drawing.Size(350, 200);
            this.serial_UsrCtl1.TabIndex = 1;

            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(734, 231);
            this.Controls.Add(this.can_UsrCtl1);
            this.Controls.Add(this.serial_UsrCtl1);
            this.Name = "MainForm";
            this.Text = "AGV BASE System";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);

            this.ResumeLayout(false);
        }

        #endregion

        // 自動生成の慣習に従い、配置したコントロールは下部に宣言
        private UserInterface.Can_UsrCtl can_UsrCtl1;
        private UserInterface.Serial_UsrCtl serial_UsrCtl1;
    }
}