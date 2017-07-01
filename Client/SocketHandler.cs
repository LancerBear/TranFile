using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;
using System.Threading;
using System.Windows.Forms;

namespace Client
{
	class SocketHandler
	{
		private ClientForm form;
		private IPAddress ip;
		private int port;
		private static Socket clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
		private static byte[] buffer = new byte[300];
		public SocketHandler(ClientForm form)
		{
			this.form = form;
			this.port = 8834;
			this.ip = IPAddress.Parse("127.0.0.1");
		}

		public SocketHandler() { }
		public void setIP(IPAddress ip)
		{
			this.ip = ip;
		}

		public void setPort(int port)
		{
			this.port = port;
		}

		public void connect()
		{
			try
			{
				clientSocket.Connect(new IPEndPoint(ip, port)); 
				ListViewItem lvi = new ListViewItem();
				lvi.Text = "连接服务器成功！";
				form.logListView.Items.Add(lvi);
				form.connButton.Enabled = false;
				Thread receiveThread = new Thread(receive);
				receiveThread.Start();
			}
			catch
			{
				ListViewItem lvi = new ListViewItem();
				lvi.Text = "连接服务器失败！";
				form.logListView.Items.Add(lvi);
				form.connButton.Enabled = true;
			}
		}

		private static void receive()
		{
			while (true)
			{
				int receiveNumber = 0;
				try
				{
					//buffer = new byte[297];
					receiveNumber = clientSocket.Receive(buffer);
					MessageBox.Show(Encoding.Unicode.GetString(buffer));
				}
				catch (Exception ex)
				{
					Console.WriteLine(ex.Message);
					clientSocket.Shutdown(SocketShutdown.Both);
					clientSocket.Close();
					break;
				}
			}
		}

		public void sendSliceCount(int sliceCount, String name, String id,String fileName)
		{
			clientSocket.Send(Encoding.ASCII.GetBytes(sliceCount.ToString()));
			Thread.Sleep(200);
			clientSocket.Send(Encoding.Unicode.GetBytes(name));
			Thread.Sleep(200);
			clientSocket.Send(Encoding.Unicode.GetBytes(id));
			Thread.Sleep(200);
			clientSocket.Send(Encoding.Unicode.GetBytes(fileName));
		}

		public void sendSlice(byte[] buffer)
		{
			clientSocket.Send(buffer);
		}
	}
}
