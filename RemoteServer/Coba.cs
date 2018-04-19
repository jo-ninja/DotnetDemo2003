using System;
using System.Windows.Forms;

namespace RemoteServer
{
	/// <summary>
	/// Summary description for Coba.
	/// </summary>
	public class Coba : MarshalByRefObject
	{
		public Coba()
		{
		}

		public string Hei()
		{
			return "From Server";
		}
	}

}
