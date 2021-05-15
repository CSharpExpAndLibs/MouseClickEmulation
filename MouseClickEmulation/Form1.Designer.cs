
namespace MouseClickEmulation
{
    partial class Form1
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
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.realButton = new System.Windows.Forms.Button();
            this.dummyButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // realButton
            // 
            this.realButton.Location = new System.Drawing.Point(29, 63);
            this.realButton.Name = "realButton";
            this.realButton.Size = new System.Drawing.Size(75, 23);
            this.realButton.TabIndex = 0;
            this.realButton.Text = "Real";
            this.realButton.UseVisualStyleBackColor = true;
            this.realButton.Click += new System.EventHandler(this.realButton_Click);
            // 
            // dummyButton
            // 
            this.dummyButton.Location = new System.Drawing.Point(134, 63);
            this.dummyButton.Name = "dummyButton";
            this.dummyButton.Size = new System.Drawing.Size(75, 23);
            this.dummyButton.TabIndex = 1;
            this.dummyButton.Text = "Dummy";
            this.dummyButton.UseVisualStyleBackColor = true;
            this.dummyButton.Click += new System.EventHandler(this.dummyButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(238, 142);
            this.Controls.Add(this.dummyButton);
            this.Controls.Add(this.realButton);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button realButton;
        private System.Windows.Forms.Button dummyButton;
    }
}

