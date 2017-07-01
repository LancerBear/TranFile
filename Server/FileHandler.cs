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

namespace Server

{
	class FileHandler
	{
		static private ServerForm form;
		private string fileDir;
		public string fileName;
		private string id;
		private string name;
		public uint sliceCount;
		private FileStream fileStream;

		public FileHandler(ServerForm f)
		{
			form = f;
		}

		public FileHandler()
		{
		}

		private byte calCheckByte(byte[] buffer,int recNum)
		{
			byte res = new byte();
			for (int i = 0; i < recNum-1; i++)
			{
				res += buffer[i];
			}
			res %= 0x10;
			return res;
		}

		public bool appendFile(byte[] buffer,uint recSliceCount,int recNum)
		{
			byte checkByte = new byte();
			checkByte = buffer[recNum-1];
			if (checkByte != calCheckByte(buffer,recNum))
			{
				return false;
			}
			byte[] nameByte = new byte[20];
			byte[] idByte = new byte[16];
			byte[] numByte = new byte[4];
			Buffer.BlockCopy(buffer, 36, numByte, 0, 4);
			Buffer.BlockCopy(buffer, 0, idByte, 0, 16);
			Buffer.BlockCopy(buffer, 16, nameByte, 0, 20);
			String idString = Encoding.Unicode.GetString(idByte);
			String nameString = Encoding.Unicode.GetString(nameByte);
			String numString = Encoding.Unicode.GetString(numByte);
			ListViewItem lvi = new ListViewItem();
			lvi.Text = "已接收数据片编号: " + numString;
			form.logListView.BeginUpdate();
			form.logListView.Items.Add(lvi);
			form.logListView.EndUpdate();
			if (recSliceCount < sliceCount)
			{
				byte[] fileBuf = new byte[256];
				Buffer.BlockCopy(buffer, 40, fileBuf, 0, 256);
				fileStream = new FileStream("D:\\recieve.lancer", FileMode.Append);
				fileStream.Write(fileBuf, 0, 256);
				fileStream.Close();
			}
			else
			{
				int left = recNum - 41;
				byte[] fileBuf = new byte[left];
				Buffer.BlockCopy(buffer, 40, fileBuf, 0, (int)left);
				fileStream = new FileStream("D:\\recieve.lancer", FileMode.Append);
				fileStream.Write(fileBuf, 0, (int)left);
				fileStream.Close();
				ListViewItem lvi2 = new ListViewItem();
				lvi2.Text = "已经全部成功接收！ ";
				form.logListView.BeginUpdate();
				form.logListView.Items.Add(lvi2);
				form.logListView.EndUpdate();
				FileInfo fi = new FileInfo("D:\\recieve.lancer");
				String newDir = "D:\\" + fileName;
				//fi.MoveTo(newDir);
			}
			return true;
		}

	}
}
