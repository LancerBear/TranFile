namespace Client
{
	partial class ClientForm
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
			this.sendButton = new System.Windows.Forms.Button();
			this.fileButton = new System.Windows.Forms.Button();
			this.connButton = new System.Windows.Forms.Button();
			this.nameTextBox = new System.Windows.Forms.TextBox();
			this.idTextBox = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.portTextBox = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.ipTextBox = new System.Windows.Forms.MaskedTextBox();
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
			this.panel1.Controls.Add(this.sendButton);
			this.panel1.Controls.Add(this.fileButton);
			this.panel1.Controls.Add(this.connButton);
			this.panel1.Controls.Add(this.nameTextBox);
			this.panel1.Controls.Add(this.idTextBox);
			this.panel1.Controls.Add(this.label4);
			this.panel1.Controls.Add(this.label3);
			this.panel1.Controls.Add(this.portTextBox);
			this.panel1.Controls.Add(this.label2);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Controls.Add(this.ipTextBox);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(202, 511);
			this.panel1.TabIndex = 0;
			// 
			// sendButton
			// 
			this.sendButton.Location = new System.Drawing.Point(56, 434);
			this.sendButton.Name = "sendButton";
			this.sendButton.Size = new System.Drawing.Size(75, 23);
			this.sendButton.TabIndex = 10;
			this.sendButton.Text = "发送文件";
			this.sendButton.UseVisualStyleBackColor = true;
			this.sendButton.Click += new System.EventHandler(this.sendButton_Click);
			// 
			// fileButton
			// 
			this.fileButton.Location = new System.Drawing.Point(56, 377);
			this.fileButton.Name = "fileButton";
			this.fileButton.Size = new System.Drawing.Size(75, 23);
			this.fileButton.TabIndex = 9;
			this.fileButton.Text = "选择文件";
			this.fileButton.UseVisualStyleBackColor = true;
			this.fileButton.Click += new System.EventHandler(this.fileButton_Click);
			// 
			// connButton
			// 
			this.connButton.Location = new System.Drawing.Point(56, 324);
			this.connButton.Name = "connButton";
			this.connButton.Size = new System.Drawing.Size(75, 23);
			this.connButton.TabIndex = 8;
			this.connButton.Text = "建立连接";
			this.connButton.UseVisualStyleBackColor = true;
			this.connButton.Click += new System.EventHandler(this.connButton_Click);
			// 
			// nameTextBox
			// 
			this.nameTextBox.Location = new System.Drawing.Point(46, 264);
			this.nameTextBox.Name = "nameTextBox";
			this.nameTextBox.Size = new System.Drawing.Size(100, 21);
			this.nameTextBox.TabIndex = 7;
			this.nameTextBox.TextChanged += new System.EventHandler(this.nameTextBox_TextChanged);
			this.nameTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nameTextBox_KeyDown);
			// 
			// idTextBox
			// 
			this.idTextBox.Location = new System.Drawing.Point(46, 201);
			this.idTextBox.Name = "idTextBox";
			this.idTextBox.Size = new System.Drawing.Size(100, 21);
			this.idTextBox.TabIndex = 6;
			this.idTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.idTextBox_KeyDown);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(78, 249);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(29, 12);
			this.label4.TabIndex = 5;
			this.label4.Text = "姓名";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(80, 186);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(29, 12);
			this.label3.TabIndex = 4;
			this.label3.Text = "学号";
			// 
			// portTextBox
			// 
			this.portTextBox.Location = new System.Drawing.Point(46, 121);
			this.portTextBox.Name = "portTextBox";
			this.portTextBox.Size = new System.Drawing.Size(100, 21);
			this.portTextBox.TabIndex = 3;
			this.portTextBox.Text = "8834";
			this.portTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.portTextBox_KeyDown);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(78, 106);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(41, 12);
			this.label2.TabIndex = 2;
			this.label2.Text = "端口号";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(76, 46);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(41, 12);
			this.label1.TabIndex = 1;
			this.label1.Text = "目标IP";
			// 
			// ipTextBox
			// 
			this.ipTextBox.Location = new System.Drawing.Point(46, 61);
			this.ipTextBox.Mask = "999.999.999.999";
			this.ipTextBox.Name = "ipTextBox";
			this.ipTextBox.PromptChar = ' ';
			this.ipTextBox.Size = new System.Drawing.Size(100, 21);
			this.ipTextBox.TabIndex = 0;
			this.ipTextBox.Text = "127000000001";
			this.ipTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ipTextBox_KeyDown);
			// 
			// panel2
			// 
			this.panel2.BackColor = System.Drawing.SystemColors.ControlLight;
			this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.panel2.Controls.Add(this.logListView);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
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
			// ClientForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
			this.ClientSize = new System.Drawing.Size(634, 511);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.panel1);
			this.MaximizeBox = false;
			this.Name = "ClientForm";
			this.Text = "Client";
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.panel2.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.MaskedTextBox ipTextBox;
		private System.Windows.Forms.TextBox portTextBox;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox nameTextBox;
		private System.Windows.Forms.TextBox idTextBox;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button fileButton;
		private System.Windows.Forms.Button sendButton;
		public System.Windows.Forms.ListView logListView;
		public System.Windows.Forms.Button connButton;
	}
}

