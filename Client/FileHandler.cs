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
using System.IO;

namespace Client
{
	//数据包格式：16字节学号+20字节姓名+4字节当前分片编号+文件数据+1字节校验
	class FileHandler
	{
		static private ClientForm form;
		private string fileDir;
		public string id;
		public string name;
		public int sliceCount;
		public byte[] buffer;
		private FileStream fileStream;
		private FileInfo fileInfo;
		private long fileLength;
		private SocketHandler sh = new SocketHandler();
		private uint left;
		public FileHandler(ClientForm f)
		{
			form = f;
		}
		public FileHandler()
		{ }

		public bool setFileDir(string fileDir)
		{
			this.fileDir = fileDir;
			string fileName = fileDir.Substring(fileDir.LastIndexOf("\\") + 1);
			fileStream = File.Open(fileDir, FileMode.Open);
			fileInfo = new FileInfo(fileDir);
			fileLength = fileInfo.Length;
			sliceCount = (int)(fileLength / 256);
			left = (uint)(fileLength % 256);
			if (left != 0)
				sliceCount++;
			Console.WriteLine("文件路径： " + fileDir);
			Console.WriteLine("文件大小： " + fileLength.ToString());
			Console.WriteLine("分片数: " + sliceCount);
			//MessageBox.Show(fileName);
			sh.sendSliceCount(sliceCount,name,id,fileName);
			return true;
		}

		public void pack(uint alreadySend)
		{
			if (alreadySend == sliceCount - 1)
			{
				buffer = new byte[left + 41];
				byte[] fileBuf = new byte[left];
				Buffer.BlockCopy(id.ToCharArray(), 0, buffer, 0, id.Length * sizeof(char));
				Buffer.BlockCopy(name.ToCharArray(), 0, buffer, 16, name.Length * sizeof(char));
				Buffer.BlockCopy((alreadySend + 1).ToString().ToCharArray(), 0, buffer, 36, (alreadySend + 1).ToString().Length*sizeof(char));
				fileStream.Read(fileBuf, 0, (int)left);
				Buffer.BlockCopy(fileBuf, 0, buffer, 40, (int)left);
				buffer[left + 40] = checkByte(buffer);
				return;
			}
			else
			{
				buffer = new byte[297];
				byte[] fileBuf = new byte[256];
				Buffer.BlockCopy(id.ToCharArray(), 0, buffer, 0, id.Length * sizeof(char));
				Buffer.BlockCopy(name.ToCharArray(), 0, buffer, 16, name.Length * sizeof(char));
				Buffer.BlockCopy((alreadySend + 1).ToString().ToCharArray(), 0, buffer, 36, (alreadySend + 1).ToString().Length*sizeof(char));
				fileStream.Read(fileBuf, 0, 256);
				Buffer.BlockCopy(fileBuf, 0, buffer, 40, 256);
				buffer[296] = checkByte(buffer);
			}
		}

		public void sendFile()
		{
			uint alreadySend = 0;
			while (alreadySend < sliceCount)
			{
				//Thread.Sleep(100);
				Console.WriteLine("send: " + alreadySend.ToString());
				pack(alreadySend);
				try
				{
					sh.sendSlice(buffer);
					alreadySend++;
				}
				catch(Exception ex)
				{
					Console.WriteLine(ex.ToString());
				}
			}
		}

		private byte checkByte(byte[] buffer)
		{
			byte res = new byte();
			for (int i = 0; i < buffer.Length-1; i++ )
			{
				res += buffer[i];
			}
			res %= 0x10;
			return res;
		}

		public void setName(string n)
		{
			this.name = n;
		}

		public void setID(string id)
		{
			this.id = id;
		}
	}
}
