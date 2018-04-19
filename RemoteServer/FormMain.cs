using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;

namespace RemoteServer
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class FormMain : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button btnStart;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		private TcpChannel tcp = null;

		public FormMain()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.btnStart = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// btnStart
			// 
			this.btnStart.Location = new System.Drawing.Point(104, 112);
			this.btnStart.Name = "btnStart";
			this.btnStart.TabIndex = 0;
			this.btnStart.Text = "&Start";
			this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
			// 
			// FormMain
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(292, 273);
			this.Controls.Add(this.btnStart);
			this.Name = "FormMain";
			this.Text = "Server";
			this.Closed += new System.EventHandler(this.FormMain_Closed);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new FormMain());
		}

		public void btnStart_Click(object sender, System.EventArgs e)
		{
			try
			{
				if(btnStart.Text == "&Start")
				{
					tcp = new TcpChannel(8080);
					ChannelServices.RegisterChannel(tcp);

					RemotingConfiguration.RegisterWellKnownServiceType(typeof(Coba),"Demo",WellKnownObjectMode.Singleton);

					btnStart.Text = "&Stop";
				}
				else
				{
					btnStart.Text = "&Start";
					ChannelServices.UnregisterChannel(tcp);
				}
			}
			catch(Exception exc)
			{
				MessageBox.Show(exc.Message);
			}
		}

		private void FormMain_Closed(object sender, System.EventArgs e)
		{
			try
			{
				foreach(IChannel ch in ChannelServices.RegisteredChannels)
				{
					ChannelServices.UnregisterChannel(ch);
				}
			}
			catch(Exception exc)
			{
				MessageBox.Show(exc.Message);
			}
		}
	}
}
