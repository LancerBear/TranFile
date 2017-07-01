using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;
using System.Threading;
using System.Windows.Forms;

namespace Server
{
	class SocketHandler
	{
		static private ServerForm form;
		private IPAddress ip;
		private int port;
		private Thread listenThread;
		static private TcpListener listener;
		static private bool isListening = false;
		public static Socket serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
		public static Socket clientSocket;
		static private Byte[] buffer;
		static private FileHandler fh = new FileHandler();
		public SocketHandler(ServerForm f)
		{
			form = f;
			ip = IPAddress.Parse("127.0.0.1");
			port = 8834;
		}
		public SocketHandler() 
		{
		}
		public void setIP(IPAddress ip)
		{
			this.ip = ip;
		}

		public void setPort(int port)
		{
			this.port = port;
		}

		public void listen()
		{
			if (isListening == false)
			{
				Console.WriteLine("Empty");
				serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
				serverSocket.Bind(new IPEndPoint(ip, port));
				serverSocket.Listen(1024);
			}
			Console.WriteLine("start to listen");
			isListening = true;
			listenThread = new Thread(ListenClientConnect);
			listenThread.Start();
			ListViewItem lvi = new ListViewItem();
			lvi.Text = "已开始监听......";
			form.logListView.Items.Add(lvi);
			form.listenButton.Enabled = false;
			form.unlistenButton.Enabled = true;
		}

		public void unlisten()
		{
			isListening = false;
			serverSocket.Close();

			listenThread.Abort();
			Console.WriteLine("Stop Listen");
			ListViewItem lvi = new ListViewItem();
			lvi.Text = "已停止监听......";
			form.logListView.Items.Add(lvi);
			form.listenButton.Enabled = true;
			form.unlistenButton.Enabled = false;
		}

		private static void ListenClientConnect()
		{
			while (isListening)
			{
				clientSocket = serverSocket.Accept();
				ListViewItem lvi = new ListViewItem();
				lvi.Text = "已经建立连接！";
				form.logListView.Items.Add(lvi);
				buffer = new byte[297];
				int receiveNumber = clientSocket.Receive(buffer);
				ListViewItem lv = new ListViewItem();
				lv.Text = "待接收文件分片数量: " + Encoding.ASCII.GetString(buffer);
				fh.sliceCount = uint.Parse(Encoding.ASCII.GetString(buffer));
				form.logListView.Items.Add(lv);

				buffer = new byte[297];
				receiveNumber = clientSocket.Receive(buffer);
				ListViewItem lv1 = new ListViewItem();
				lv1.Text = "姓名: " + Encoding.Unicode.GetString(buffer);
				form.logListView.Items.Add(lv1);

				buffer = new byte[297];
				receiveNumber = clientSocket.Receive(buffer);
				ListViewItem lv2 = new ListViewItem();
				lv2.Text = "学号: " + Encoding.Unicode.GetString(buffer);
				form.logListView.Items.Add(lv2);

				buffer = new byte[297];
				receiveNumber = clientSocket.Receive(buffer);
				fh.fileName = Encoding.Unicode.GetString(buffer);

				Thread receiveThread = new Thread(ReceiveFile);
				receiveThread.Start(clientSocket);
			}
		}


		private static void ReceiveFile(Object cSocket)
		{
			Socket clientSocket = (Socket)cSocket;
			uint recSliceCount = 0;
			while (true)
			{
				int receiveNumber = 0;
				bool res = true;
				try
				{
					//buffer = new byte[297];   
					receiveNumber = clientSocket.Receive(buffer);
					res = fh.appendFile(buffer, ++recSliceCount, receiveNumber);
				}
				catch (Exception ex)
				{
					Console.WriteLine(ex.Message);
					clientSocket.Shutdown(SocketShutdown.Both);
					clientSocket.Close();
					break;
				}
				while (res == false)
				{
					clientSocket.Send(Encoding.Unicode.GetBytes(recSliceCount.ToString()));
				}
			}
		}
	}
}
