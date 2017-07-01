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

namespace Client
{
	public partial class ClientForm : Form
	{
		FileHandler fh;
		SocketHandler sh;
		public ClientForm()
		{
			InitializeComponent();
			Control.CheckForIllegalCrossThreadCalls = false;
			fh = new FileHandler(this);
			sh = new SocketHandler(this);
			connButton.Enabled = false;
		}

		private void fileButton_Click(object sender, EventArgs e)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();
			if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
			{
				string fileDir = openFileDialog.FileName.ToString();
				fh.setFileDir(fileDir);
				ListViewItem lvi = new ListViewItem();
				lvi.Text = "已选择文件 " + fileDir;
				logListView.Items.Add(lvi);
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
					this.idTextBox.Focus();
				}
			}
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
					sh.setIP(IPAddress.Parse(ip));
					ListViewItem lvi = new ListViewItem();
					lvi.Text = "已设置目标ip地址为 " + ip;
					logListView.Items.Add(lvi);
					this.portTextBox.Focus();
				}
			}
		}

		private void idTextBox_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				fh.setID(idTextBox.Text);
				ListViewItem lvi = new ListViewItem();
				lvi.Text = "已设置学号 " + idTextBox.Text + "\n";
				logListView.Items.Add(lvi);
				this.nameTextBox.Focus();
			}
		}

		private void nameTextBox_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				fh.setName(nameTextBox.Text);
				ListViewItem lvi = new ListViewItem();
				lvi.Text = "已设置姓名 " + nameTextBox.Text + "\n";
				logListView.Items.Add(lvi);
				if (fh.id != null && fh.name != null)
				{
					this.connButton.Enabled = true;
				}
				this.connButton.Focus();
			}
		}

		private void connButton_Click(object sender, EventArgs e)
		{
			if (fh.id == null || fh.name == null)
			{
				MessageBox.Show("请输入学号、姓名!");
			}
			else
			{
				sh.connect();
			}
		}

		private void sendButton_Click(object sender, EventArgs e)
		{
			fh.sendFile();
		}

		private void nameTextBox_TextChanged(object sender, EventArgs e)
		{

		}
	}
}
