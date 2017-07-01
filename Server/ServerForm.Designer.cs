namespace Server
{
	partial class ServerForm
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
		/// 设计器支持所需的方法 - 不要
		/// 使用代码编辑器修改此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
			this.panel1 = new System.Windows.Forms.Panel();
			this.unlistenButton = new System.Windows.Forms.Button();
			this.fileLocalButton = new System.Windows.Forms.Button();
			this.listenButton = new System.Windows.Forms.Button();
			this.portTextBox = new System.Windows.Forms.TextBox();
			this.ipTextBox = new System.Windows.Forms.MaskedTextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.panel2 = new System.Windows.Forms.Panel();
			this.logListView = new System.Windows.Forms.ListView();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.SystemColors.ControlLight;
			this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.panel1.Controls.Add(this.unlistenButton);
			this.panel1.Controls.Add(this.fileLocalButton);
			this.panel1.Controls.Add(this.listenButton);
			this.panel1.Controls.Add(this.portTextBox);
			this.panel1.Controls.Add(this.ipTextBox);
			this.panel1.Controls.Add(this.label2);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(202, 511);
			this.panel1.TabIndex = 0;
			// 
			// unlistenButton
			// 
			this.unlistenButton.Location = new System.Drawing.Point(61, 290);
			this.unlistenButton.Name = "unlistenButton";
			this.unlistenButton.Size = new System.Drawing.Size(75, 23);
			this.unlistenButton.TabIndex = 7;
			this.unlistenButton.Text = "停止监听";
			this.unlistenButton.UseVisualStyleBackColor = true;
			this.unlistenButton.Click += new System.EventHandler(this.unlistenButton_Click);
			// 
			// fileLocalButton
			// 
			this.fileLocalButton.Location = new System.Drawing.Point(61, 392);
			this.fileLocalButton.Name = "fileLocalButton";
			this.fileLocalButton.Size = new System.Drawing.Size(75, 23);
			this.fileLocalButton.TabIndex = 6;
			this.fileLocalButton.Text = "文件位置";
			this.fileLocalButton.UseVisualStyleBackColor = true;
			this.fileLocalButton.Click += new System.EventHandler(this.fileLocalButton_Click);
			// 
			// listenButton
			// 
			this.listenButton.Location = new System.Drawing.Point(61, 227);
			this.listenButton.Name = "listenButton";
			this.listenButton.Size = new System.Drawing.Size(75, 23);
			this.listenButton.TabIndex = 5;
			this.listenButton.Text = "开始监听";
			this.listenButton.UseVisualStyleBackColor = true;
			this.listenButton.Click += new System.EventHandler(this.listenButton_Click);
			// 
			// portTextBox
			// 
			this.portTextBox.Location = new System.Drawing.Point(49, 120);
			this.portTextBox.Name = "portTextBox";
			this.portTextBox.Size = new System.Drawing.Size(100, 21);
			this.portTextBox.TabIndex = 4;
			this.portTextBox.Text = "8834";
			this.portTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.portTextBox_KeyDown);
			// 
			// ipTextBox
			// 
			this.ipTextBox.Location = new System.Drawing.Point(49, 60);
			this.ipTextBox.Mask = "999.999.999.999";
			this.ipTextBox.Name = "ipTextBox";
			this.ipTextBox.PromptChar = ' ';
			this.ipTextBox.Size = new System.Drawing.Size(100, 21);
			this.ipTextBox.TabIndex = 3;
			this.ipTextBox.Text = "127000000001";
			this.ipTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ipTextBox_KeyDown);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(80, 105);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(41, 12);
			this.label2.TabIndex = 1;
			this.label2.Text = "端口号";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(80, 45);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(41, 12);
			this.label1.TabIndex = 0;
			this.label1.Text = "本地IP";
			// 
			// panel2
			// 
			this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.panel2.Controls.Add(this.logListView);
			this.panel2.Location = new System.Drawing.Point(208, 0);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(426, 511);
			this.panel2.TabIndex = 1;
			// 
			// logListView
			// 
			this.logListView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.logListView.Location = new System.Drawing.Point(0, 0);
			this.logListView.Name = "logListView";
			this.logListView.Size = new System.Drawing.Size(422, 507);
			this.logListView.TabIndex = 0;
			this.logListView.UseCompatibleStateImageBehavior = false;
			this.logListView.View = System.Windows.Forms.View.List;
			// 
			// ServerForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(634, 511);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.panel1);
			this.Name = "ServerForm";
			this.Text = "Server";
			this.Load += new System.EventHandler(this.ServerForm_Load);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.panel2.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.MaskedTextBox ipTextBox;
		private System.Windows.Forms.TextBox portTextBox;
		private System.Windows.Forms.Button fileLocalButton;
		public System.Windows.Forms.ListView logListView;
		public System.Windows.Forms.Button listenButton;
		public System.Windows.Forms.Button unlistenButton;
	}
}

