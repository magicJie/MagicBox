namespace GetMachineInfo
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.获取机器码 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox1.Location = new System.Drawing.Point(1, 1);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(423, 91);
            this.textBox1.TabIndex = 0;
            this.textBox1.Text = "    本程序会提取所在设备的机器码，成功提取后悔在所在运行目录产生Machine.txt文件，请将这个文件发送给授权方进行License授权。";
            // 
            // 获取机器码
            // 
            this.获取机器码.Location = new System.Drawing.Point(169, 98);
            this.获取机器码.Name = "获取机器码";
            this.获取机器码.Size = new System.Drawing.Size(75, 35);
            this.获取机器码.TabIndex = 1;
            this.获取机器码.Text = "提取机器码";
            this.获取机器码.UseVisualStyleBackColor = true;
            this.获取机器码.Click += new System.EventHandler(this.获取机器码_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(428, 137);
            this.Controls.Add(this.获取机器码);
            this.Controls.Add(this.textBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button 获取机器码;
    }
}

