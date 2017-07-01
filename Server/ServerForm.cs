using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace Server
{
	public partial class ServerForm : Form
	{
		FileHandler fh;
		SocketHandler sh;
		public ServerForm()
		{
			InitializeComponent();
			Control.CheckForIllegalCrossThreadCalls = false;
			fh = new FileHandler(this);
			sh = new SocketHandler(this);
			unlistenButton.Enabled = false;
		}

		private void ipTextBox_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				bool sucFlag = true;
				string ip = "";
				try
				{
					ip = ipTextBox.Text.Replace(" ", "");
					IPAddress.Parse(ip);
				}
				catch
				{
					MessageBox.Show("ip地址不合法！");
					ipTextBox.Text = "";
					ip = "";
					sucFlag = false;
				}
				if (sucFlag)
				{
					Console.WriteLine(ip);
					sh.setIP(IPAddress.Parse(ip));
					ListViewItem lvi = new ListViewItem();
					lvi.Text = "已设置目标ip地址为 " + ip;
					logListView.Items.Add(lvi);
					this.portTextBox.Focus();
				}
			}
		}

		private void portTextBox_KeyDown(object sender, KeyEventArgs e)
		{
			bool sucFlag = true;
			if (e.KeyCode == Keys.Enter)
			{
				int portNum = 0;
				try
				{
					portNum = int.Parse(portTextBox.Text.ToString());
					sucFlag = true;
				}
				catch
				{
					MessageBox.Show("输入的端口号不合法！");
					portTextBox.Text = "";
					sucFlag = false;
				}
				if (portNum > 65535 || portNum < 0)
				{
					MessageBox.Show("端口号数值在0~65535！");
					portTextBox.Text = "";
					sucFlag = false;
				}
				if (sucFlag)
				{
					sh.setPort(portNum);
					ListViewItem lvi = new ListViewItem();
					lvi.Text = "已设置端口号为 " + portNum.ToString();
					logListView.Items.Add(lvi);
					this.listenButton.Focus();
				}
			}
		}

		private void listenButton_Click(object sender, EventArgs e)
		{
			sh.listen();
		}

		private void unlistenButton_Click(object sender, EventArgs e)
		{
			sh.unlisten();
		}

		private void ServerForm_Load(object sender, EventArgs e)
		{

		}

		private void fileLocalButton_Click(object sender, EventArgs e)
		{
			System.Diagnostics.Process.Start("Explorer.exe", "D:");
		}
	}
}
